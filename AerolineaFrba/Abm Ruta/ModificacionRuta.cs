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

namespace AerolineaFrba.Abm_Ruta
{
    public partial class ModificacionRuta : AerolineaFrba.Abm_Ruta.BaseRuta
    {
        public ModificacionRuta(DataGridViewRow selected)
        {
            InitializeComponent();
            TB_codigo.Text = selected.Cells["Codigo"].Value.ToString();
            TB_precio_kg.Text = selected.Cells["Precio Kg"].Value.ToString();
            TB_precio_pasaje.Text = selected.Cells["Precio Pasaje"].Value.ToString();
            TB_codigo_unico.Text = selected.Cells["Codigo Unico"].Value.ToString();
            CB_origen.Text = selected.Cells["Origen"].Value.ToString();
            CB_destino.Text = selected.Cells["Destino"].Value.ToString();
            CB_servicio.Text = selected.Cells["Servicio"].Value.ToString();
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
            SqlCommand spModificarRuta = this.db.GetStoreProcedure("TS.spModificarRuta");
            spModificarRuta.Parameters.Add(new SqlParameter("@origen", CB_origen.SelectedValue));
            spModificarRuta.Parameters.Add(new SqlParameter("@destino", CB_destino.SelectedValue));
            spModificarRuta.Parameters.Add(new SqlParameter("@servicio", CB_servicio.SelectedValue));
            spModificarRuta.Parameters.Add(new SqlParameter("@codigo", Convert.ToInt64(TB_codigo_unico.Text)));
            spModificarRuta.Parameters.Add(new SqlParameter("@precio_kg", Convert.ToInt64(TB_precio_kg.Text)));
            spModificarRuta.Parameters.Add(new SqlParameter("@precio_pasaje", Convert.ToInt64(TB_precio_pasaje.Text)));
            spModificarRuta.ExecuteNonQuery();
        }
    }
}
