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
    public partial class DatosBuscadorForm : DatosBase
    {
        public string cliCod;
        public DatosBuscadorForm()
        {
            InitializeComponent();
            DbComunicator db = new DbComunicator();
            dniTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dniTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            string queryCuentas = "SELECT Cli_DNI FROM TS.Cliente";
            db.CargarAutocomplete(col, queryCuentas, "Cli_DNI");
            dniTextBox.AutoCompleteCustomSource = col;
            dniTextBox.TextChanged += new EventHandler(dniTextBox_TextChanged);
            db.CerrarConexion();

            fullNameTextBox.Enabled = false;
            addressTextBox.Enabled = false;
            phoneTextBox.Enabled = false;
            bornDateTimePicker.Enabled = false;
            mailTextBox.Enabled = false;
            cliCod = "";
            editClientButton.Enabled = false;
        }

        public virtual void foundCliCod(string cliCod) {
            
        }

        public void fillInputs() {
            DbComunicator db = new DbComunicator();
            db.EjecutarQuery("SELECT COUNT(*) Cantidad FROM TS.Cliente WHERE Cli_DNI = '" + dniTextBox.Text + "'");
            db.getLector().Read();

            if (Convert.ToInt16(db.getLector()["Cantidad"].ToString()) > 0)
            {
                db.EjecutarQuery("SELECT Cli_Cod, Cli_Nombre, Cli_Direccion, Cli_Tel, Cli_Mail, Cli_Fecha_Nacimiento FROM TS.Cliente WHERE Cli_DNI = '" + dniTextBox.Text + "'");
                db.getLector().Read();
                fullNameTextBox.Text = db.getLector()["Cli_Nombre"].ToString();
                addressTextBox.Text = db.getLector()["Cli_Direccion"].ToString();
                phoneTextBox.Text = db.getLector()["Cli_Tel"].ToString();
                bornDateTimePicker.Value = Convert.ToDateTime(db.getLector()["Cli_Fecha_Nacimiento"].ToString());
                mailTextBox.Text = db.getLector()["Cli_Mail"].ToString();
                cliCod = db.getLector()["Cli_Cod"].ToString();
                editClientButton.Enabled = true;
                this.foundCliCod(this.cliCod);
            }
            else
            {
                editClientButton.Enabled = false;
                
            }

            db.CerrarConexion();
        }

        private void dniTextBox_TextChanged(object sender, EventArgs e)
        {
            fillInputs();
        }

        private void editClientButton_Click(object sender, EventArgs e)
        {
            ClienteEditarForm ce = new ClienteEditarForm(cliCod, dniTextBox.Text ,fullNameTextBox.Text, addressTextBox.Text, phoneTextBox.Text, mailTextBox.Text, bornDateTimePicker.Value);
            ce.ShowDialog();
            fillInputs();
        }

        private void addClientButton_Click(object sender, EventArgs e)
        {
            ClienteAgregarForm ca = new ClienteAgregarForm();
            ca.ShowDialog();
            dniTextBox.Text = ca.dni;
            fillInputs();
        }
    }
}
