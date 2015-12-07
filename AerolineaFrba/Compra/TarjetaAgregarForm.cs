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
    public partial class TarjetaAgregarForm : TarjetaBaseForm
    {
        string cliCod;
        public string tarjetaNumero;
        public TarjetaAgregarForm(string cliCod)
        {
            InitializeComponent();
            this.cliCod = cliCod;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cardNumberTextBoxt.Text) || String.IsNullOrEmpty(cardCodeTextBox.Text) || String.IsNullOrEmpty(cardDateTextBox.Text))
            {
                MessageBox.Show("Ningun campo debe estar vacio para poder llevar a cabo la creación.");
            }
            else if (this.validarFecha()){
                DbComunicator dbStoreProcedure = new DbComunicator();
                SqlCommand storeProcedure = dbStoreProcedure.GetStoreProcedure("TS.spCrearTarjeta");
                SqlParameter returnParameter = storeProcedure.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                storeProcedure.Parameters.Add(new SqlParameter("@Tar_Numero", cardNumberTextBoxt.Text));
                storeProcedure.Parameters.Add(new SqlParameter("@Tar_Fecha_Vencimiento", cardDateTextBox.Text));
                storeProcedure.Parameters.Add(new SqlParameter("@Tar_Codigo_Seguridad", cardCodeTextBox.Text));
                storeProcedure.Parameters.Add(new SqlParameter("@Cli_Cod", this.cliCod));
                storeProcedure.Parameters.Add(new SqlParameter("@TipoTar_Cod", cardEmitterComboBox.SelectedValue.ToString()));
                storeProcedure.ExecuteNonQuery();
                dbStoreProcedure.CerrarConexion();

                if ((int)returnParameter.Value == -1)
                {
                    MessageBox.Show("Ya existe una tarjeta con el numero especificado.");
                }

                if ((int)returnParameter.Value != 0 && (int)returnParameter.Value != -1)
                {
                    MessageBox.Show("Error inesperado");
                }

                if ((int)returnParameter.Value == 0)
                {
                    MessageBox.Show("Creación realizada");
                    this.tarjetaNumero = cardNumberTextBoxt.Text;
                    this.Close();
                }
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
