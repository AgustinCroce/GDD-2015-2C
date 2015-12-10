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
        }

        private void UseItem(string Item, ComboBox ComboBox)
        {
            ComboBox.SelectedIndex = ComboBox.FindStringExact(Item);
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
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
                spModificarRuta.ExecuteNonQuery();
                this.Close();
            }
        }

        private void ModificacionRuta_Load(object sender, EventArgs e)
        {
            this.UseItem(this.selected.Cells["Origen"].Value.ToString(), CB_origen);
            this.UseItem(this.selected.Cells["Destino"].Value.ToString(), CB_destino);
        }
    }
}
