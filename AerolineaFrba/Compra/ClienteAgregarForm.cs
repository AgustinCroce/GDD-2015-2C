using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Commons;

namespace AerolineaFrba.Compra
{
    public partial class ClienteAgregarForm : DatosBase
    {
        public ClienteAgregarForm()
        {
            InitializeComponent();
            this.dni = "";
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            DbComunicator dbStoreProcedure = new DbComunicator();
            SqlCommand storeProcedure = dbStoreProcedure.GetStoreProcedure("TS.spCrearCliente");
            SqlParameter returnParameter = storeProcedure.Parameters.Add("RetVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            storeProcedure.Parameters.Add(new SqlParameter("@Cli_DNI", dniTextBox.Text));
            storeProcedure.Parameters.Add(new SqlParameter("@Cli_Nombre", fullNameTextBox.Text));
            storeProcedure.Parameters.Add(new SqlParameter("@Cli_Mail", mailTextBox.Text));
            storeProcedure.Parameters.Add(new SqlParameter("@Cli_Tel", phoneTextBox.Text));
            storeProcedure.Parameters.Add(new SqlParameter("@Cli_Direccion", addressTextBox.Text));
            storeProcedure.Parameters.Add(new SqlParameter("@Cli_Fecha_Nacimiento", bornDateTimePicker.Value));
            storeProcedure.ExecuteNonQuery();
            dbStoreProcedure.CerrarConexion();

            if ((int)returnParameter.Value == -1)
            {
                MessageBox.Show("Ya existe un cliente con el DNI especificado.");
            }

            if ((int)returnParameter.Value != 0 && (int)returnParameter.Value != -1)
            {
                MessageBox.Show("Error inesperado");
            }

            if ((int)returnParameter.Value == 0)
            {
                MessageBox.Show("Creación realizada");
                this.dni = dniTextBox.Text;
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string dni { get; set; }
    }
}
