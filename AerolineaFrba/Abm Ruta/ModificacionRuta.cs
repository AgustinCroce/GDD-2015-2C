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
        DataGridViewRow selected;

        public ModificacionRuta(DataGridViewRow selected)
        {
            InitializeComponent();
            this.selected = selected;
            TB_codigo.Text = selected.Cells["Codigo"].Value.ToString();
            TB_precio_kg.Text = selected.Cells["Precio Kg"].Value.ToString();
            TB_precio_pasaje.Text = selected.Cells["Precio Pasaje"].Value.ToString();
            TB_codigo_unico.Text = selected.Cells["Codigo Unico"].Value.ToString();
            this.enabledButtons.RegisterTextBox(TB_codigo);
            this.enabledButtons.RegisterTextBox(TB_precio_kg);
            this.enabledButtons.RegisterTextBox(TB_precio_pasaje);
            this.enabledButtons.RegisterButton(BT_guardar);
        }

        private void UseItem(string Item, ComboBox ComboBox)
        {
            ComboBox.SelectedIndex = ComboBox.FindStringExact(Item);
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(CB_origen.SelectedValue) == Convert.ToInt64(CB_destino.SelectedValue))
            {
                MessageBox.Show("La ciudad destino tiene que ser distinta a la ciudad origen");
                return;
            }
            if (TB_precio_kg.Text != "" && TB_precio_pasaje.Text != ""){
                if (Convert.ToDouble(TB_precio_kg.Text) > 0 && Convert.ToDouble(TB_precio_pasaje.Text) > 0){
                    DialogResult dialogResult = MessageBox.Show("¿Usted esta seguro de modificar esta ruta? (en caso de modificarla se cancelaran todos los pasajes y encomiendas que pasen por esa ruta)", "Confirmación", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SqlCommand spModificarRuta = this.db.GetStoreProcedure("TS.spModificarRuta");
                        spModificarRuta.Parameters.Add(new SqlParameter("@HOY", Convert.ToDateTime(AerolineaFrba.Properties.Settings.Default.FechaSistema)));
                        spModificarRuta.Parameters.Add(new SqlParameter("@origen", Convert.ToInt64(CB_origen.SelectedValue)));
                        spModificarRuta.Parameters.Add(new SqlParameter("@destino", Convert.ToInt64(CB_destino.SelectedValue)));
                        spModificarRuta.Parameters.Add(new SqlParameter("@codigo_unico", Convert.ToInt64(TB_codigo_unico.Text)));
                        spModificarRuta.Parameters.Add(new SqlParameter("@codigo", Convert.ToInt64(TB_codigo.Text)));
                        spModificarRuta.Parameters.Add(new SqlParameter("@precio_kg", Convert.ToDouble(TB_precio_kg.Text)));
                        spModificarRuta.Parameters.Add(new SqlParameter("@precio_pasaje", Convert.ToDouble(TB_precio_pasaje.Text)));
                        SqlParameter returnParameter = spModificarRuta.Parameters.Add("RetVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        spModificarRuta.ExecuteNonQuery();
                        if ((int)returnParameter.Value == -1) MessageBox.Show("El codigo de ruta es unico, este codigo de ruta ya esta utilizado, por favor cambielo");
                        else if ((int)returnParameter.Value == -2) MessageBox.Show("Este origen y destino ya esta en una ruta, por favor cambielo");
                        else this.Close();
                    }
                } else MessageBox.Show("El precio tanto de pasaje como de kg tiene que ser mayor a 0");
            } else MessageBox.Show("El precio tanto de pasaje como de kg tiene que ser mayor a 0");
        }

        private void ModificacionRuta_Load(object sender, EventArgs e)
        {
            this.UseItem(this.selected.Cells["Origen"].Value.ToString(), CB_origen);
            this.UseItem(this.selected.Cells["Destino"].Value.ToString(), CB_destino);
        }
    }
}
