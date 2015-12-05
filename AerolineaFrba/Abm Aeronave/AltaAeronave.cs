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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class AltaAeronave : AerolineaFrba.Abm_Aeronave.BaseAeronave
    {
        public AltaAeronave()
        {
            InitializeComponent();
            this.enabledButtons.RegisterTextBox(TB_butacas_pasillo);
            this.enabledButtons.RegisterTextBox(TB_butacas_ventanilla);
            this.enabledButtons.RegisterTextBox(TB_fabricante);
            this.enabledButtons.RegisterTextBox(TB_kg_disponibles);
            this.enabledButtons.RegisterTextBox(TB_matricula);
            this.enabledButtons.RegisterTextBox(TB_modelo);
            this.enabledButtons.RegisterButton(BT_guardar);
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
            SqlCommand spALtaAeronave = this.db.GetStoreProcedure("TS.spAltaAeronave");
            spALtaAeronave.Parameters.Add(new SqlParameter("@modelo", TB_modelo.Text));
            spALtaAeronave.Parameters.Add(new SqlParameter("@HOY", Convert.ToDateTime(AerolineaFrba.Properties.Settings.Default.FechaSistema)));
            spALtaAeronave.Parameters.Add(new SqlParameter("@matricula", TB_matricula.Text));
            spALtaAeronave.Parameters.Add(new SqlParameter("@fabricante", TB_fabricante.Text));
            spALtaAeronave.Parameters.Add(new SqlParameter("@servicio", CB_servicio.SelectedValue));
            spALtaAeronave.Parameters.Add(new SqlParameter("@butacas_v", Convert.ToInt64(TB_butacas_ventanilla.Text)));
            spALtaAeronave.Parameters.Add(new SqlParameter("@butacas_p", Convert.ToInt64(TB_butacas_pasillo.Text)));
            spALtaAeronave.Parameters.Add(new SqlParameter("@kg_disponibles", Convert.ToInt64(TB_kg_disponibles.Text)));
            SqlParameter returnParameter = spALtaAeronave.Parameters.Add("Status", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            spALtaAeronave.ExecuteNonQuery();
            if ((int)returnParameter.Value == -1)
            {
                MessageBox.Show("La matricula no es unica, por favor use otra");
            }
            else
            {
                this.Close();
            }
        }
    }
}
