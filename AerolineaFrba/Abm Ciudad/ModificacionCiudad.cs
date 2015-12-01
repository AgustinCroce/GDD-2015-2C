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

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class ModificacionCiudad : AerolineaFrba.Abm_Ciudad.BaseCiudad
    {
        public ModificacionCiudad(DataGridViewRow selected)
        {
            InitializeComponent();
            TB_nombre.Text = selected.Cells["Nombre"].Value.ToString();
            TB_codigo.Text = selected.Cells["Codigo"].Value.ToString();
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
            SqlCommand spModificarCiudad = this.db.GetStoreProcedure("TS.spModificarCiudad");
            spModificarCiudad.Parameters.Add(new SqlParameter("@nombre", TB_nombre.Text));
            spModificarCiudad.Parameters.Add(new SqlParameter("@codigo", Convert.ToInt64(TB_codigo.Text)));
            spModificarCiudad.ExecuteNonQuery();
            this.Close();
        }
    }
}
