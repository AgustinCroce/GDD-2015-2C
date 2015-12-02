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

namespace AerolineaFrba.Abm_Rol
{
    public partial class ModificacionRol : AerolineaFrba.Abm_Rol.BaseRol
    {
        public ModificacionRol(DataGridViewRow selected)
        {
            InitializeComponent();
            TB_nombre.Text = selected.Cells["Nombre"].Value.ToString();
            CB_estado.Text = selected.Cells["Estado"].Value.ToString();
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
            SqlCommand spModificarRol = this.db.GetStoreProcedure("TS.spModificarRol");
            spModificarRol.Parameters.Add(new SqlParameter("@estado", CB_estado.SelectedText));
            spModificarRol.ExecuteNonQuery();
            this.Close();
        }
    }
}
