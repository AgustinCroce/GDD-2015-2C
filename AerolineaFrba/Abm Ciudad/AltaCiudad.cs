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
    public partial class AltaCiudad : AerolineaFrba.Abm_Ciudad.BaseCiudad
    {
        public AltaCiudad()
        {
            InitializeComponent();
            this.enabledButtons.RegisterTextBox(TB_nombre);
            this.enabledButtons.RegisterButton(BT_guardar);
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
            SqlCommand spALtaCiudad = this.db.GetStoreProcedure("TS.spAltaCiudad");
            spALtaCiudad.Parameters.Add(new SqlParameter("@nombre", TB_nombre.Text));
            spALtaCiudad.ExecuteNonQuery();
            this.Close();
        }
    }
}
