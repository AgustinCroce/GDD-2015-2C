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
        public PagoKioskoForm()
        {
            InitializeComponent();
            cardNumberTextBox.Enabled = false;
            cardCodeTextBox.Enabled = false;
            cardDateTextBox.Enabled = false;
            cardEmitterTextBox.Enabled = false;
            cardNumberDuesComboBox.Enabled = false;
            addCreditCardButton.Enabled = false;
            editCreditCardButton.Enabled = false;
        }

        private void cardNumberTextBoxt_textChanged(object sender, EventArgs e)
        {
            fillCardInputs();
        }

        override public void foundCliCod(string cliCod)
        {
            DbComunicator db = new DbComunicator();
            cardNumberTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cardNumberTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            string queryCuentas = "SELECT Tar_Numero FROM TS.Tarjeta WHERE Cli_Cod = " + this.cliCod;
            db.CargarAutocomplete(col, queryCuentas, "Tar_Numero");
            cardNumberTextBox.AutoCompleteCustomSource = col;
            cardNumberTextBox.TextChanged += new EventHandler(cardNumberTextBoxt_textChanged);
            cardNumberTextBox.Enabled = true;
            addCreditCardButton.Enabled = true;
            db.CerrarConexion();
        }

        private void fillCardInputs()
        {
            DbComunicator db = new DbComunicator();
            db.EjecutarQuery("SELECT COUNT(*) Cantidad FROM TS.Tarjeta WHERE Cli_Cod = " + this.cliCod + " AND Tar_Numero = " + cardNumberTextBox.Text + "");
            db.getLector().Read();

            if (Convert.ToInt16(db.getLector()["Cantidad"].ToString()) > 0)
            {
                db.EjecutarQuery("SELECT Tar_Numero, Tar_Fecha_Vencimiento, Tar_Codigo_Seguridad, T.TipoTar_Cod, TipoTar_Nombre FROM TS.Tarjeta as T, TS.Tipo_Tarjeta as TT WHERE T.TipoTar_Cod = TT.TipoTar_cod AND Cli_Cod = " + this.cliCod + " AND Tar_Numero = " + cardNumberTextBox.Text);
                db.getLector().Read();
                cardNumberTextBox.Text = db.getLector()["Tar_Numero"].ToString();
                cardCodeTextBox.Text = db.getLector()["Tar_Codigo_Seguridad"].ToString();
                cardDateTextBox.Text = db.getLector()["Tar_Fecha_Vencimiento"].ToString();
                cardEmitterTextBox.Text = db.getLector()["TipoTar_Nombre"].ToString();
                editCreditCardButton.Enabled = true;

                cardNumberDuesComboBox.Enabled = true;
                string tipoTarCod = db.getLector()["TipoTar_Cod"].ToString();
                this.cardTypeCode = Convert.ToInt32(tipoTarCod);
                db.EjecutarQuery("SELECT TipoTar_Cuotas FROM TS.Tipo_Tarjeta WHERE TipoTar_Cod = " + tipoTarCod);
                db.getLector().Read();
                cardNumberDuesComboBox.Items.Clear();

                for (int i = 0; Convert.ToInt16(db.getLector()["TipoTar_Cuotas"]) >= i; i++)
                {
                    cardNumberDuesComboBox.Items.Add(i);
                }

                db.CerrarConexion();
            }
            else
            {
                editCreditCardButton.Enabled = false;

            }

            db.CerrarConexion();
        }

        private void addCreditCardButton_Click(object sender, EventArgs e)
        {
            TarjetaAgregarForm ta = new TarjetaAgregarForm(this.cliCod);
            ta.ShowDialog();
            cardNumberTextBox.Text = ta.tarjetaNumero;
            fillCardInputs();
            foundCliCod(this.cliCod);
        }

        private void editCreditCardButton_Click(object sender, EventArgs e)
        {
            TarjetaEditarForm te = new TarjetaEditarForm(this.cliCod, cardNumberTextBox.Text, cardCodeTextBox.Text, cardDateTextBox.Text, this.cardTypeCode - 1);
            te.ShowDialog();
            fillCardInputs();
        }
    }
}
