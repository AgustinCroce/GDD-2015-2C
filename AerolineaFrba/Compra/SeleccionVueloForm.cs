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
            string queryCiudades = "SELECT Ciudad_Cod, Ciudad_Nombre FROM TS.Ciudad";
            DbComunicator db = new DbComunicator();
            origenComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryCiudades, "Ciudad_Cod", "Ciudad_Nombre"), null);
            origenComboBox.DisplayMember = "Value";
            origenComboBox.ValueMember = "Key";
            destinoComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryCiudades, "Ciudad_Cod", "Ciudad_Nombre"), null);
            destinoComboBox.DisplayMember = "Value";
            destinoComboBox.ValueMember = "Key";
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DbComunicator db = new DbComunicator();
            string queryVuelos = "SELECT Viaj_Cod Codigo, Fecha_Salida, C2.Ciudad_Nombre Salida, C1.Ciudad_Nombre Destino ,Fecha_Llegada_Estimada Fecha_Llegada, Ruta_Servicio Servicio, Viaj_Kgs_Disponibles Kgs_Libres, Viaj_Butacas_Disponibles Butacas_Libres";
            queryVuelos += " FROM TS.Ruta as R, TS.Viaje as V, TS.Aeronave as A, TS.Ciudad as C1, TS.Ciudad as C2";
            queryVuelos += " WHERE R.Ruta_Cod = V.Ruta_Cod AND V.Ruta_Cod = R.Ruta_Cod AND C1.Ciudad_Cod = R.Ruta_Ciudad_Destino AND C2.Ciudad_Cod = R.Ruta_Ciudad_Origen";
            queryVuelos += " AND A.Aero_Num = V.Aero_Num AND A.Aero_Borrado = 0 AND A.Aero_Baja_Vida_Util = 0 AND A.Aero_Baja_Fuera_De_Servicio = 0";
            queryVuelos += " AND C2.Ciudad_Cod = ' " + origenComboBox.SelectedValue +"' AND C1.Ciudad_Cod = ' " + destinoComboBox.SelectedValue + "' AND convert(date, V.Fecha_Salida) = convert(date, '" + despegueTimePicker.Value +"')";
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
                        PagoAdminForm pa = new PagoAdminForm(si.precio);
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
                                storeProcedure.Parameters.Add(new SqlParameter("@Tar_Numero", 23));
                                storeProcedure.Parameters.Add(new SqlParameter("@Com_Cuotas", 1));
                            }
                            
                            storeProcedure.ExecuteNonQuery();
                            dbStoreProcedure.CerrarConexion();

                            MessageBox.Show("Se ha creado su compra de $ " + si.precio + "con PNR: " + (int)returnParameter.Value);
                        }
                    }

                    if (Properties.Settings.Default.Modo == "Kiosko") {
                        PagoKioskoForm pa = new PagoKioskoForm(si.precio);
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

                            MessageBox.Show("Se ha creado su compra de $ "+ si.precio + "con PNR: " + (int)returnParameter.Value);
                        }
                    }
                    
                }
            }

        }

        private void SeleccionVueloForm_Load(object sender, EventArgs e)
        {
            despegueTimePicker.MinDate = Convert.ToDateTime(AerolineaFrba.Properties.Settings.Default.FechaSistema);
            vuelosGridView.CellClick += this.ActivarAcciones;
            vuelosGridView.RowHeaderMouseClick += this.ActivarAcciones;
        }

        private void ActivarAcciones(object sender, EventArgs e)
        {
            if (!vuelosGridView.SelectedRows[0].Cells["Codigo"].Value.ToString().Equals(""))
            {
                this.selectButton.Enabled = true;
                vuelosGridView.SelectionChanged += this.DesactivarAcciones;
            }
            else this.DesactivarAcciones(sender, e);
        }

        private void DesactivarAcciones(object sender, EventArgs e)
        {
            this.selectButton.Enabled = false;
            vuelosGridView.SelectionChanged -= this.DesactivarAcciones;
        }
    }
}
