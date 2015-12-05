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
    public partial class AgregarAeronaveRemplazo : ModificacionAeronave
    {
        DataGridViewRow selected;

        public AgregarAeronaveRemplazo(DataGridViewRow selected)
        {
            InitializeComponent();
            this.selected = selected;
            TB_fabricante.Text = selected.Cells["Fabricante"].Value.ToString();
            TB_kg_disponibles.Text = selected.Cells["KG Disponible"].Value.ToString();
            TB_matricula.Text = selected.Cells["Matricula"].Value.ToString();
            TB_modelo.Text = selected.Cells["Modelo"].Value.ToString();
            TB_numero.Text = selected.Cells["Numero"].Value.ToString();
            TB_butacas_pasillo.Text = selected.Cells["Butacas Pasillo"].Value.ToString();
            TB_butacas_ventanilla.Text = selected.Cells["Butacas Ventanilla"].Value.ToString();
            CB_servicio.Text = selected.Cells["Servicio"].Value.ToString();
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(TB_kg_disponibles.Text) >= Convert.ToInt64(this.selected.Cells["KG Disponible"].Value.ToString())
                && Convert.ToInt64(TB_butacas_pasillo.Text) >= Convert.ToInt64(this.selected.Cells["Butacas Pasillo"].Value.ToString())
                && Convert.ToInt64(TB_butacas_ventanilla.Text) >= Convert.ToInt64(this.selected.Cells["Butacas Ventanilla"].Value.ToString()))
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
                if ((int)returnParameter.Value == -1) MessageBox.Show("La matricula no es unica, por favor use otra");
                else this.Close();
            }
            else MessageBox.Show("La cantidad de butacas y la cantidad de kgs tiene que ser igual a mayor a la de la aeronave a remplazar");
        }
    }
}
