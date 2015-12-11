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
using System.Data.SqlClient;

namespace AerolineaFrba.Compra
{
    public partial class DatosEncomienda : DatosBuscadorForm
    {
        private DataGridView encomiendaGridView;
        private double maxKgs;
        public Commons.Validator validator;
        public double viajCod;

        public DatosEncomienda(double viajCod, DataGridView encomiendaGridView, double maxKgs)
        {
            InitializeComponent();
            this.validator = new Commons.Validator();
            this.encomiendaGridView = encomiendaGridView;
            this.maxKgs = maxKgs;
            kgsTextBox.KeyPress += InputNumField_KeyPress;
            kgsTextBox.TextChanged += kgsTextBox_TextChanged;
            acceptButton.Enabled = false;
            this.viajCod = viajCod;
        }

        private void kgsTextBox_TextChanged(object sender, EventArgs e)
        {
            int kgs = 0;
            if (!String.IsNullOrEmpty(kgsTextBox.Text)) {
                kgs = Convert.ToInt32(kgsTextBox.Text);
            }

            DbComunicator db = new DbComunicator();
            SqlCommand storeProcedure = db.GetStoreProcedure("TS.fnGetPrecioEncomienda");
            SqlParameter returnParameter = storeProcedure.Parameters.Add("RetVal", SqlDbType.Decimal);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            storeProcedure.Parameters.Add(new SqlParameter("@Enc_Kgs", kgs));
            storeProcedure.Parameters.Add(new SqlParameter("@Viaj_Cod", viajCod));
            storeProcedure.ExecuteNonQuery();
            db.CerrarConexion();

            precioTextBox.Text = Convert.ToDecimal(returnParameter.Value).ToString();
        }

        private void InputNumField_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validator.KeyPressBinding(this.validator.validateInt, false, e);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(kgsTextBox.Text)) {
                MessageBox.Show("Debe ingresar un peso en la casilla Kgs.");
            }
            else if (Convert.ToInt16(kgsTextBox.Text) <= 0) {
                MessageBox.Show("El kg de la encomienda debe ser más de 0.");
            }
            else if (Convert.ToInt16(kgsTextBox.Text) > maxKgs)
            {
                MessageBox.Show("No puede superar más de los " + maxKgs.ToString() + " kilos");
            }
            else
            {
                string cliDni = "";
                DbComunicator db = new DbComunicator();
                db.EjecutarQuery("SELECT Cli_DNI FROM TS.Cliente WHERE Cli_Cod = " + this.cliCod);
                db.getLector().Read();
                cliDni = db.getLector()["Cli_DNI"].ToString();
                db.CerrarConexion();
                this.encomiendaGridView.Rows.Insert(0, this.cliCod, cliDni, fullNameTextBox.Text, addressTextBox.Text, kgsTextBox.Text, precioTextBox.Text);
                this.Close();
            }
        }

        override public void foundCliCod(string cliCod){
            acceptButton.Enabled = true;
        }

        override public void notFoundCliCod()
        {
            acceptButton.Enabled = false;
        }
    }
}
