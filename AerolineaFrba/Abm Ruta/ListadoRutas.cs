using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AerolineaFrba.Commons;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class ListadoRutas : Form
    {
        DbComunicator db;

        public ListadoRutas()
        {
            InitializeComponent();
            this.db = new DbComunicator();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListadoRutas_Load(object sender, EventArgs e)
        {
            string QueryRutas = "SELECT Ruta_Cod 'Codigo Unico', Ruta_Codigo 'Codigo', C1.Ciudad_Nombre 'Origen', C2.Ciudad_Nombre 'Destino', Ruta_Servicio 'Servicio', Ruta_Precio_Base_Kg 'Precio Kg', Ruta_Precio_Base_Pasaje 'Precio Pasaje', Ruta_Borrada Borrada FROM [GD2C2015].[TS].[Ruta], [GD2C2015].[TS].[Ciudad] as C1, [GD2C2015].[TS].[Ciudad] as C2 WHERE C1.Ciudad_Cod = Ruta_Ciudad_Origen AND  C2.Ciudad_Cod = Ruta_Ciudad_Destino";
            string QueryCiudades = "SELECT Ciudad_Nombre 'Nombre' FROM [GD2C2015].[TS].[Ciudad]";
            DGV_rutas.DataSource = db.GetDataAdapter(QueryRutas).Tables[0];
            Dictionary<object, object> Ciudades = this.db.GetQueryDictionary(QueryCiudades, "Nombre", "Nombre");
            CB_ciudad.DataSource = new BindingSource(Ciudades, null);
            CB_ciudad.DisplayMember = "Value";
            CB_ciudad.ValueMember = "Key";
            DGV_rutas.CellClick += this.ActivarAcciones;
            DGV_rutas.RowHeaderMouseClick += this.ActivarAcciones;
        }

        private void ActivarAcciones(object sender, EventArgs e)
        {
            if (!DGV_rutas.SelectedRows[0].Cells["Codigo"].Value.ToString().Equals(""))
            {
                this.BT_eliminar.Enabled = true;
                this.BT_modificar.Enabled = true;
                DGV_rutas.SelectionChanged += this.DesactivarAcciones;
            }
            else this.DesactivarAcciones(sender, e);
        }

        private void DesactivarAcciones(object sender, EventArgs e)
        {
            this.BT_eliminar.Enabled = false;
            this.BT_modificar.Enabled = false;
            DGV_rutas.SelectionChanged -= this.DesactivarAcciones;
        }


        private void BT_buscar_Click(object sender, EventArgs e)
        {
            string QueryBusqueda = "SELECT Ruta_Cod 'Codigo Unico', Ruta_Codigo 'Codigo', C1.Ciudad_Nombre 'Origen', C2.Ciudad_Nombre 'Destino', Ruta_Servicio 'Servicio', Ruta_Precio_Base_Kg 'Precio Kg', Ruta_Precio_Base_Pasaje 'Precio Pasaje', Ruta_Borrada Borrada FROM [GD2C2015].[TS].[Ruta], [GD2C2015].[TS].[Ciudad] as C1, [GD2C2015].[TS].[Ciudad] as C2 WHERE (C1.Ciudad_Cod = Ruta_Ciudad_Origen AND C1.Ciudad_Nombre LIKE '%" + CB_ciudad.SelectedValue + "%' AND C2.Ciudad_Cod = Ruta_Ciudad_Destino) OR (C1.Ciudad_Cod = Ruta_Ciudad_Origen AND C2.Ciudad_Nombre LIKE '%" + CB_ciudad.SelectedValue + "%' AND C2.Ciudad_Cod = Ruta_Ciudad_Destino)";
            DGV_rutas.DataSource = db.GetDataAdapter(QueryBusqueda).Tables[0];
        }

        private void BT_modificar_Click(object sender, EventArgs e)
        {
            ModificacionRuta re = new ModificacionRuta(DGV_rutas.SelectedRows[0]);
            re.FormClosed += new FormClosedEventHandler(ListadoRutas_Load);
            re.ShowDialog();
        }

        private void BT_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Usted esta seguro de borrar esta ruta? (en caso de borrarla se cancelaran todos los pasajes y encomiendas que pasen por esa ruta)", "Confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand spBorrarRuta = this.db.GetStoreProcedure("TS.spBorrarRuta");
                spBorrarRuta.Parameters.Add(new SqlParameter("@HOY", Convert.ToDateTime(AerolineaFrba.Properties.Settings.Default.FechaSistema)));
                spBorrarRuta.Parameters.Add(new SqlParameter("@Codigo", Convert.ToInt64(DGV_rutas.SelectedRows[0].Cells["Codigo Unico"].Value)));
                spBorrarRuta.ExecuteNonQuery();
            }
            this.ListadoRutas_Load(sender, e);
        }

        private void BT_agregar_Click(object sender, EventArgs e)
        {
            AltaRuta re = new AltaRuta();
            re.FormClosed += new FormClosedEventHandler(ListadoRutas_Load);
            re.ShowDialog();
        }
    }
}
