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

namespace AerolineaFrba.Canje_Millas
{
    public partial class CanjeForm : Form
    {
        public Commons.Validator validator;

        public CanjeForm()
        {
            InitializeComponent();
            this.validator = new Commons.Validator();
            quantityTextBox.KeyPress += this.InputNumField_KeyPress;
            string queryCiudades = "SELECT Cli_Nombre + ' DNI: ' + Cli_DNI Cli_Detalle, Cli_Cod FROM TS.Cliente ";
            DbComunicator db = new DbComunicator();
            clienteComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryCiudades, "Cli_Detalle", "Cli_Cod"), null);
            clienteComboBox.DisplayMember = "Key";
            clienteComboBox.ValueMember = "Value";
            string queryProductos = "SELECT Prod_Nombre + ' (' + CAST (Prod_Stock AS nvarchar(255)) + ')' Prod_Detalle, Prod_Cod FROM TS.Producto";
            productoComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryProductos, "Prod_Detalle", "Prod_Cod"), null);
            productoComboBox.DisplayMember = "Key";
            productoComboBox.ValueMember = "Value";
            db.CerrarConexion();
        }

        private void InputNumField_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validator.KeyPressBinding(this.validator.validateInt, false, e);
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            DbComunicator dbStoreProcedure = new DbComunicator();
            SqlCommand storeProcedure = dbStoreProcedure.GetStoreProcedure("TS.spRegistrarCanje");
            SqlParameter returnParameter = storeProcedure.Parameters.Add("RetVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            storeProcedure.Parameters.Add(new SqlParameter("@Cli_Cod", clienteComboBox.SelectedValue.ToString()));
            storeProcedure.Parameters.Add(new SqlParameter("@Cli_DNI", dniTextBox.Text.ToString()));
            storeProcedure.Parameters.Add(new SqlParameter("@Canje_Fecha", dateTimePicker.Value));
            storeProcedure.Parameters.Add(new SqlParameter("@Prod_Cod", productoComboBox.SelectedValue.ToString()));
            storeProcedure.Parameters.Add(new SqlParameter("@Canje_Cantidad_Prod", quantityTextBox.Text));
            storeProcedure.ExecuteNonQuery();
            dbStoreProcedure.CerrarConexion();

            if ((int)returnParameter.Value == -2)
            {
                MessageBox.Show("No hay suficiente stock del producto elegido");
            }

            if ((int)returnParameter.Value == -1) {
                MessageBox.Show("El DNI ingresado no corresponde al cliente elegido");
            }

            if ((int)returnParameter.Value == 0)
            {
                MessageBox.Show("El cliente no tiene saldo suficiente");
            }

            MessageBox.Show("Canje Realizado");
        }
    }
}
