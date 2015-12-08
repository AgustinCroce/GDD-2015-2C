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
            db.CerrarConexion();
            string queryClientes = "SELECT Cli_DNI + ' Nombre: ' + Cli_Nombre Cli_Detalle, Cli_Cod FROM TS.Cliente ";
            dniComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryClientes, "Cli_Detalle", "Cli_Cod"), null);
            dniComboBox.DisplayMember = "Key";
            dniComboBox.ValueMember = "Value";
            dniComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dniComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            dniComboBox.SelectedValueChanged += dniComboBox_SelectedValueChanged;
            dniComboBox.TextChanged += dniComboBox_TextChanged;

            fullNameTextBox.Enabled = false;
            addressTextBox.Enabled = false;
            phoneTextBox.Enabled = false;
            bornDateTimePicker.Enabled = false;
            mailTextBox.Enabled = false;
            cliCod = "";
            editClientButton.Enabled = false;
        }

        private void dniComboBox_TextChanged(object sender, EventArgs e)
        {
            int index = -1;
            index = dniComboBox.FindStringExact(dniComboBox.Text);
            if (index == -1)
            {
                fillInputs();
            }
            else {
                editClientButton.Enabled = false;
                fullNameTextBox.Text = "";
                addressTextBox.Text = "";
                phoneTextBox.Text = "";
                mailTextBox.Text = "";
                this.notFoundCliCod();
            }
        }

        private void dniComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            fillInputs();
        }

        public virtual void foundCliCod(string cliCod) {
            
        }

        public void fillInputs() {
            DbComunicator db = new DbComunicator();
            if (dniComboBox.SelectedValue != null)
            {
                db.EjecutarQuery("SELECT Cli_Cod, Cli_Nombre, Cli_Direccion, Cli_Tel, Cli_Mail, Cli_Fecha_Nacimiento FROM TS.Cliente WHERE Cli_Cod = '" + dniComboBox.SelectedValue + "'");
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
                fullNameTextBox.Text = "";
                addressTextBox.Text = "";
                phoneTextBox.Text = "";
                mailTextBox.Text = "";
                this.notFoundCliCod();
            }

            db.CerrarConexion();
        }

        public virtual void notFoundCliCod()
        {
            
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
