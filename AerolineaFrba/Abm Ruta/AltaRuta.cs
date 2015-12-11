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
            this.enabledButtons.RegisterTextBox(TB_codigo);
            this.enabledButtons.RegisterTextBox(TB_precio_pasaje);
            this.enabledButtons.RegisterButton(BT_guardar);
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(CB_origen.SelectedValue) == Convert.ToInt64(CB_destino.SelectedValue)){
                MessageBox.Show("La ciudad destino tiene que ser distinta a la ciudad origen");
                return;
            }
            if (TB_precio_kg.Text != "" && TB_precio_pasaje.Text != ""){
                if (Convert.ToDouble(TB_precio_kg.Text) > 0 && Convert.ToDouble(TB_precio_pasaje.Text) > 0){
                     SqlCommand spALtaRuta = this.db.GetStoreProcedure("TS.spAltaRuta");
                     spALtaRuta.Parameters.Add(new SqlParameter("@origen", Convert.ToInt64(CB_origen.SelectedValue)));
                     spALtaRuta.Parameters.Add(new SqlParameter("@destino", Convert.ToInt64(CB_destino.SelectedValue)));
                     spALtaRuta.Parameters.Add(new SqlParameter("@codigo", Convert.ToInt64(TB_codigo.Text)));
                     spALtaRuta.Parameters.Add(new SqlParameter("@precio_kg", Convert.ToInt64(TB_precio_kg.Text)));
                     spALtaRuta.Parameters.Add(new SqlParameter("@precio_pasaje", Convert.ToInt64(TB_precio_pasaje.Text)));
                     SqlParameter returnParameter = spALtaRuta.Parameters.Add("RetVal", SqlDbType.Int);
                     returnParameter.Direction = ParameterDirection.ReturnValue;
                     spALtaRuta.ExecuteNonQuery();
                     if ((int)returnParameter.Value == -1) MessageBox.Show("El codigo de ruta es unico, este codigo de ruta ya esta utilizado, por favor cambielo");
                     else if ((int)returnParameter.Value == -2) MessageBox.Show("Este origen y destino ya esta en una ruta, por favor cambielo");
                     else this.Close();
                }
                else MessageBox.Show("El precio tanto de pasaje como de kg tiene que ser mayor a 0");
            }
            else MessageBox.Show("El precio tanto de pasaje como de kg tiene que ser mayor a 0");
        }
    }
}
