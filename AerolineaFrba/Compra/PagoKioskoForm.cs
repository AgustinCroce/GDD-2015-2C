using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Commons;

namespace AerolineaFrba.Compra
{
    public partial class PagoKioskoForm : DatosBuscadorForm
    {
        int cardTypeCode;
        public bool habilitado = false;
        public double Cli_Cod;
        public double Tar_Numero;
        public double Com_Cuotas;
        public string Com_Forma_Pago;

        public PagoKioskoForm(){
            InitializeComponent();
            cardNumberTextBox.Enabled = false;
            cardCodeTextBox.Enabled = false;
            cardDateTextBox.Enabled = false;
            cardEmitterTextBox.Enabled = false;
            cardNumberDuesComboBox.Enabled = false;
            addCreditCardButton.Enabled = false;
            editCreditCardButton.Enabled = false;

            //cardNumberTextBox.KeyPress += this.InputNumField_KeyPress;
        }

        private void cardNumberTextBoxt_valueChanged(object sender, EventArgs e)
        {
            fillCardInputs();
        }

        override public void foundCliCod(string cliCod)
        {
            DbComunicator db1 = new DbComunicator();
            cardNumberTextBox.SelectedValueChanged -= this.cardNumberTextBoxt_valueChanged;
            string queryCuentas = "SELECT Tar_Numero FROM TS.Tarjeta WHERE Cli_Cod = " + this.cliCod;
            cardNumberTextBox.DataSource = new BindingSource(db1.GetQueryDictionary(queryCuentas, "Tar_Numero", "Tar_Numero"), null);
            cardNumberTextBox.DisplayMember = "Value";
            cardNumberTextBox.ValueMember = "Key";
            cardNumberTextBox.Enabled = true;
            addCreditCardButton.Enabled = true;
            cardNumberTextBox.SelectedValueChanged += this.cardNumberTextBoxt_valueChanged;
            cardNumberTextBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cardNumberDuesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Cli_Cod = Convert.ToDouble(this.cliCod);
            db1.CerrarConexion();
        }

        public bool validarFechaTarjeta(string tarFecha, DateTime hoy) { 
            int anio = 2000 + Convert.ToInt32(tarFecha.Substring(2,2));
            int mes = Convert.ToInt32(tarFecha.Substring(0, 2));

            if( anio < hoy.Year){
                return false;
            }
            else if (anio > hoy.Year) {
                return true;
            } 
            else if (anio == hoy.Year && mes < hoy.Month) {
                return false;
            }

            return true;
        }

        public override void notFoundCliCod()
        {
            cardNumberTextBox.SelectedValueChanged -= this.cardNumberTextBoxt_valueChanged;
            cardCodeTextBox.Text = "";
            cardDateTextBox.Text = "";
            cardEmitterTextBox.Text = "";
            cardNumberTextBox.DataSource = null;
            cardNumberDuesComboBox.DataSource = null;
            this.acceptButton.Enabled = false;
        }

        private void fillCardInputs()
        {
            if (Convert.ToInt64(cardNumberTextBox.SelectedValue) != -1) {
                DbComunicator db = new DbComunicator();
                db.EjecutarQuery("SELECT Tar_Numero, Tar_Fecha_Vencimiento, Tar_Codigo_Seguridad, T.TipoTar_Cod, TipoTar_Nombre FROM TS.Tarjeta as T, TS.Tipo_Tarjeta as TT WHERE T.TipoTar_Cod = TT.TipoTar_cod AND Cli_Cod = " + this.cliCod + " AND Tar_Numero = " + cardNumberTextBox.SelectedValue);
                db.getLector().Read();
                cardNumberTextBox.Text = db.getLector()["Tar_Numero"].ToString();
                cardCodeTextBox.Text = db.getLector()["Tar_Codigo_Seguridad"].ToString();
                cardDateTextBox.Text = db.getLector()["Tar_Fecha_Vencimiento"].ToString();
                cardEmitterTextBox.Text = db.getLector()["TipoTar_Nombre"].ToString();
                editCreditCardButton.Enabled = true;
                acceptButton.Enabled = true;

                cardNumberDuesComboBox.Enabled = true;
                string tipoTarCod = db.getLector()["TipoTar_Cod"].ToString();
                this.cardTypeCode = Convert.ToInt32(tipoTarCod);
                db = new DbComunicator();
                db.EjecutarQuery("SELECT TipoTar_Cuotas FROM TS.Tipo_Tarjeta WHERE TipoTar_Cod = " + tipoTarCod);
                db.getLector().Read();
                Dictionary<object, object> duesDictionary = new Dictionary<object, object>();

                for (int i = 1; Convert.ToInt16(db.getLector()["TipoTar_Cuotas"]) >= i; i++)
                {
                    duesDictionary.Add(i, i);
                }

                cardNumberDuesComboBox.DataSource = new BindingSource(duesDictionary, null);
                cardNumberDuesComboBox.DisplayMember = "Value";
                cardNumberDuesComboBox.ValueMember = "Key";
                db.CerrarConexion();
                this.foundCard();
                acceptButton.Enabled = true;
            }
            
        }

        public virtual void foundCard() { }

        private void addCreditCardButton_Click(object sender, EventArgs e)
        {
            TarjetaAgregarForm ta = new TarjetaAgregarForm(this.cliCod);
            ta.ShowDialog();
            foundCliCod(this.cliCod);
            fillCardInputs();
        }

        private void editCreditCardButton_Click(object sender, EventArgs e)
        {
            TarjetaEditarForm te = new TarjetaEditarForm(this.cliCod, cardNumberTextBox.Text, cardCodeTextBox.Text, cardDateTextBox.Text, this.cardTypeCode - 1);
            te.ShowDialog();
            fillCardInputs();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (this.validarFechaTarjeta(cardDateTextBox.Text, Convert.ToDateTime(AerolineaFrba.Properties.Settings.Default.FechaSistema)))
            {
                this.Tar_Numero = Convert.ToDouble(cardNumberTextBox.Text);
                this.habilitado = true;
                this.Com_Cuotas = Convert.ToInt16(cardNumberDuesComboBox.SelectedValue);
                this.Com_Forma_Pago = "Tarjeta";
                this.Close();
            }
            else {
                MessageBox.Show("La tarjeta que selecciono se encuentra vencida");
            }
            
        }
    }
}
