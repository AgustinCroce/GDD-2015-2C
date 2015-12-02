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
    public partial class AltaRol : AerolineaFrba.Abm_Rol.BaseRol
    {
        public AltaRol()
        {
            InitializeComponent();
            this.enabledButtons.RegisterTextBox(TB_nombre);
            this.enabledButtons.RegisterButton(BT_guardar);
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
            SqlCommand spALtaRol = this.db.GetStoreProcedure("TS.spAltaRol");
            spALtaRol.Parameters.Add(new SqlParameter("@nombre", TB_nombre.Text));
            spALtaRol.Parameters.Add(new SqlParameter("@estado", CB_estado.Text));
            spALtaRol.ExecuteNonQuery();
            this.Close();
        }
    }
}
