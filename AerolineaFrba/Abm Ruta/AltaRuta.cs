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


    public partial class AltaRuta : AerolineaFrba.Abm_Ruta.BaseRuta
    {
        public AltaRuta()
        {
            InitializeComponent();
            this.enabledButtons.RegisterTextBox(TB_precio_kg);
            this.enabledButtons.RegisterTextBox(TB_precio_pasaje);
            this.enabledButtons.RegisterButton(BT_guardar);
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
            SqlCommand spALtaRuta = this.db.GetStoreProcedure("TS.spAltaRuta");
            spALtaRuta.Parameters.Add(new SqlParameter("@origen", Convert.ToInt64(CB_origen.SelectedValue)));
            spALtaRuta.Parameters.Add(new SqlParameter("@destino", Convert.ToInt64(CB_destino.SelectedValue)));
            spALtaRuta.Parameters.Add(new SqlParameter("@codigo", Convert.ToInt64(TB_codigo.Text)));
            spALtaRuta.Parameters.Add(new SqlParameter("@precio_kg", Convert.ToInt64(TB_precio_kg.Text)));
            spALtaRuta.Parameters.Add(new SqlParameter("@precio_pasaje", Convert.ToInt64(TB_precio_pasaje.Text)));
            spALtaRuta.ExecuteNonQuery();
            this.Close();
        }
    }
}
