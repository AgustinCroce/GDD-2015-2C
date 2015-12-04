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
    public partial class SeleccionVueloForm : Form
    {
        public SeleccionVueloForm()
        {
            InitializeComponent();
            string queryCiudades = "SELECT Ciudad_Nombre FROM TS.Ciudad";
            DbComunicator db = new DbComunicator();
            origenComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryCiudades, "Ciudad_Nombre", "Ciudad_Nombre"), null);
            origenComboBox.DisplayMember = "Key";
            origenComboBox.ValueMember = "Value";
            destinoComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryCiudades, "Ciudad_Nombre", "Ciudad_Nombre"), null);
            destinoComboBox.DisplayMember = "Key";
            destinoComboBox.ValueMember = "Value";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DbComunicator db = new DbComunicator();
            string queryVuelos = "SELECT Viaj_Cod, Fecha_Salida, R.Ruta_Ciudad_Origen, R.Ruta_Ciudad_Destino ,Fecha_Llegada_Estimada, Ruta_Servicio, Viaj_Kgs_Disponibles, Viaj_Butacas_Disponibles ";
            queryVuelos += "FROM TS.Ruta as R, TS.Viaje as V, TS.Aeronave as A ";
            queryVuelos += "WHERE R.Ruta_Cod = V.Ruta_Cod AND R.Ruta_Ciudad_Origen = '" + origenComboBox.SelectedValue.ToString() +"' AND R.Ruta_Ciudad_Destino = '"+ destinoComboBox.SelectedValue.ToString() +"' AND Fecha_Salida ='"+ despegueTimePicker.Value.ToShortDateString() +"' ";
            queryVuelos += "AND V.Aero_Num = A.Aero_Num AND A.Aero_Baja_Fuera_De_Servicio = 0 AND A.Aero_Baja_Vida_Util = 0";
            vuelosGridView.DataSource = db.GetDataAdapter(queryVuelos).Tables[0];
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {
            this.vuelosGridView.DataSource = null;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            int Viaj_Cod = Convert.ToInt32(vuelosGridView.SelectedRows[0].Cells[0].Value);
            SeleccionCantidadesForm sc = new SeleccionCantidadesForm(vuelosGridView.SelectedRows[0]);
            sc.ShowDialog();
            
            if (sc.habilitado) {
                SeleccionItemsForm si = new SeleccionItemsForm(Viaj_Cod, sc.kgsHabilitados, sc.pasajesHabilitados);
                si.ShowDialog();
                if (si.habilitado) {
                    double Enc_Cod = si.Enc_Cod;
                    double Enc_Kgs = si.Enc_Kgs;
                    DataTable Pas_Lista = si.Pas_Lista;

                    if (Properties.Settings.Default.Modo == "Admin") {
                        PagoAdminForm pa = new PagoAdminForm();
                        pa.ShowDialog();
                        if (pa.habilitado)
                        {
                            double Com_Cli = pa.Cli_Cod;
                            string Com_Forma_Pago = pa.Com_Forma_Pago;
                            double Tar_Numero = pa.Tar_Numero;
                            double Com_Cuotas = pa.Com_Cuotas;

                            DbComunicator dbStoreProcedure = new DbComunicator();
                            SqlCommand storeProcedure = dbStoreProcedure.GetStoreProcedure("TS.spCrearCompra");
                            SqlParameter returnParameter = storeProcedure.Parameters.Add("RetVal", SqlDbType.BigInt);
                            returnParameter.Direction = ParameterDirection.ReturnValue;
                            storeProcedure.Parameters.Add(new SqlParameter("@Viaj_Cod", Viaj_Cod));
                            storeProcedure.Parameters.Add(new SqlParameter("@Com_Fecha", Properties.Settings.Default.FechaSistema));
                            storeProcedure.Parameters.Add(new SqlParameter("@Com_Cli", Com_Cli));
                            storeProcedure.Parameters.Add(new SqlParameter("@Enc_Cli", Enc_Cod));
                            storeProcedure.Parameters.Add(new SqlParameter("@Enc_Kgs", Enc_Kgs));
                            storeProcedure.Parameters.Add(new SqlParameter("@Pas_Lista", Pas_Lista));
                            storeProcedure.Parameters.Add(new SqlParameter("@Com_Forma_Pago", Com_Forma_Pago));

                            if (Com_Forma_Pago == "Tarjeta")
                            {
                                storeProcedure.Parameters.Add(new SqlParameter("@Tar_Numero", Tar_Numero));
                                storeProcedure.Parameters.Add(new SqlParameter("@Com_Cuotas", Com_Cuotas));
                            }
                            else {
                                storeProcedure.Parameters.Add(new SqlParameter("@Tar_Numero", 0));
                                storeProcedure.Parameters.Add(new SqlParameter("@Com_Cuotas", 1));
                            }
                            
                            storeProcedure.ExecuteNonQuery();
                            dbStoreProcedure.CerrarConexion();

                            MessageBox.Show("Se ha creado su compra con PNR: " + (double)returnParameter.Value);
                        }
                    }

                    if (Properties.Settings.Default.Modo == "Kiosko") {
                        PagoKioskoForm pa = new PagoKioskoForm();
                        pa.ShowDialog();
                        if (pa.habilitado)
                        {
                            double Com_Cli = pa.Cli_Cod;
                            string Com_Forma_Pago = pa.Com_Forma_Pago;
                            double Tar_Numero = pa.Tar_Numero;
                            double Com_Cuotas = pa.Com_Cuotas;

                            DbComunicator dbStoreProcedure = new DbComunicator();
                            SqlCommand storeProcedure = dbStoreProcedure.GetStoreProcedure("TS.spCrearCompra");
                            SqlParameter returnParameter = storeProcedure.Parameters.Add("RetVal", SqlDbType.BigInt);
                            returnParameter.Direction = ParameterDirection.ReturnValue;
                            storeProcedure.Parameters.Add(new SqlParameter("@Viaj_Cod", Viaj_Cod));
                            storeProcedure.Parameters.Add(new SqlParameter("@Com_Fecha", Properties.Settings.Default.FechaSistema));
                            storeProcedure.Parameters.Add(new SqlParameter("@Com_Cli", Com_Cli));
                            storeProcedure.Parameters.Add(new SqlParameter("@Tar_Numero", Tar_Numero));
                            storeProcedure.Parameters.Add(new SqlParameter("@Com_Forma_Pago", Com_Forma_Pago));
                            storeProcedure.Parameters.Add(new SqlParameter("@Com_Cuotas", Com_Cuotas));
                            storeProcedure.Parameters.Add(new SqlParameter("@Enc_Cli", Enc_Cod));
                            storeProcedure.Parameters.Add(new SqlParameter("@Enc_Kgs", Enc_Kgs));
                            storeProcedure.Parameters.Add(new SqlParameter("@Pas_Lista", Pas_Lista));
                            storeProcedure.ExecuteNonQuery();
                            dbStoreProcedure.CerrarConexion();

                            MessageBox.Show("Se ha creado su compra con PNR: " + (double)returnParameter.Value);
                        }
                    }
                    
                }
            }

        }
    }
}
