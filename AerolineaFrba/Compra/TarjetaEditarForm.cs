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
    public partial class TarjetaEditarForm : TarjetaBaseForm
    {
        public TarjetaEditarForm(string cliCod, string tarNum, string tarCod, string tarFecha, int tipoTar)
        {
            InitializeComponent();
            cardNumberTextBoxt.Text = tarNum;
            cardNumberTextBoxt.Enabled = false;
            cardCodeTextBox.Text = tarCod;
            cardDateTextBox.Text = tarFecha;
            cardEmitterComboBox.SelectedIndex = tipoTar;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cardNumberTextBoxt.Text) || String.IsNullOrEmpty(cardCodeTextBox.Text) || String.IsNullOrEmpty(cardDateTextBox.Text))
            {
                MessageBox.Show("Ningun campo debe estar vacio para poder llevar a cabo la edición");
            }
            else if (this.validarFecha()){
                DbComunicator dbStoreProcedure = new DbComunicator();
                SqlCommand storeProcedure = dbStoreProcedure.GetStoreProcedure("TS.spEditarTarjeta");
                SqlParameter returnParameter = storeProcedure.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                storeProcedure.Parameters.Add(new SqlParameter("@Tar_Numero", cardNumberTextBoxt.Text));
                storeProcedure.Parameters.Add(new SqlParameter("@Tar_Fecha_Vencimiento", cardDateTextBox.Text));
                storeProcedure.Parameters.Add(new SqlParameter("@Tar_Codigo_Seguridad", cardCodeTextBox.Text));
                storeProcedure.Parameters.Add(new SqlParameter("@TipoTar_Cod", cardEmitterComboBox.SelectedValue.ToString()));
                storeProcedure.ExecuteNonQuery();
                dbStoreProcedure.CerrarConexion();

                if ((int)returnParameter.Value != 0 && (int)returnParameter.Value != -1)
                {
                    MessageBox.Show("Error inesperado");
                }

                if ((int)returnParameter.Value == 0)
                {
                    MessageBox.Show("Edición Realizada");
                    this.Close();
                }
            }
            
        }
    }
}
