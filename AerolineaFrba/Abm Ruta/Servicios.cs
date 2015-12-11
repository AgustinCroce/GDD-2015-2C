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
    public partial class Servicios : Form
    {
        string rutacod, accion;
        DbComunicator db;

        public Servicios(DataGridViewRow selected, string accion)
        {
            InitializeComponent();
            this.rutacod= selected.Cells["Codigo Unico"].Value.ToString();
            this.accion = accion;
            this.db = new DbComunicator();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
            string storedProcedure = "";
            Boolean execsp = this.accion == "Agregar";
            if (this.accion == "Agregar") storedProcedure = "TS.spAltaRutaServicio";
            else{
                storedProcedure = "TS.spBorrarRutaServicio";
                DialogResult dialogResult = MessageBox.Show("¿Usted esta seguro de modificar esta ruta sacandole un servicio? (en caso de modificarla se cancelaran todos los pasajes y encomiendas que pasen por esa ruta mediante ese servicio)", "Confirmación", MessageBoxButtons.YesNo);
                execsp = dialogResult == DialogResult.Yes;
            }
            if (execsp){
                SqlCommand spRutaServicio = this.db.GetStoreProcedure(storedProcedure);
                spRutaServicio.CommandTimeout = 0;
                spRutaServicio.Parameters.Add(new SqlParameter("@HOY", Convert.ToDateTime(AerolineaFrba.Properties.Settings.Default.FechaSistema)));
                spRutaServicio.Parameters.Add(new SqlParameter("@ruta", Convert.ToInt64(this.rutacod)));
                spRutaServicio.Parameters.Add(new SqlParameter("@servicio", CB_servicios.SelectedValue));
                spRutaServicio.ExecuteNonQuery();
                this.Close();
            }
        }

        private void Servicios_Load(object sender, EventArgs e)
        {
            string QueryServicio = "";
            if (this.accion == "Agregar") BT_guardar.Text = "Agregar";
            else BT_guardar.Text = "Eliminar";
            if (this.accion == "Agregar") QueryServicio = "SELECT TipoSer_Nombre Nombre FROM [GD2C2015].[TS].[Tipo_Servicio]";
            else QueryServicio = "SELECT Tipo_Servicio Nombre FROM [GD2C2015].[TS].[Ruta_Servicio] WHERE Ruta_Cod = " + this.rutacod;
            Dictionary<object, object> Servicios = this.db.GetQueryDictionary(QueryServicio, "Nombre", "Nombre");
            CB_servicios.DataSource = new BindingSource(Servicios, null);
            CB_servicios.DisplayMember = "Value";
            CB_servicios.ValueMember = "Key";
        }
    }
}
