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
    public partial class ModificacionAeronave : AerolineaFrba.Abm_Aeronave.BaseAeronave
    {
        public ModificacionAeronave(DataGridViewRow selected)
        {
            InitializeComponent();
            TB_fabricante.Text = selected.Cells["Fabricante"].Value.ToString();
            TB_kg_disponibles.Text = selected.Cells["KG Disponible"].Value.ToString();
            TB_matricula.Text = selected.Cells["Matricula"].Value.ToString();
            TB_modelo.Text = selected.Cells["Modelo"].Value.ToString();
            TB_numero.Text = selected.Cells["Numero"].Value.ToString();
            TB_butacas_pasillo.Text = selected.Cells["Butacas Pasillo"].Value.ToString();
            TB_butacas_ventanilla.Text = selected.Cells["Butacas Ventanilla"].Value.ToString();
            CB_servicio.Text = selected.Cells["Servicio"].Value.ToString();
        }

        public ModificacionAeronave()
        {
            InitializeComponent();
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
            if (TB_butacas_pasillo.Text != "" && TB_butacas_ventanilla.Text != "" && TB_kg_disponibles.Text != "")
            {
                if (Convert.ToDouble(TB_butacas_pasillo.Text) > 0 && Convert.ToDouble(TB_butacas_ventanilla.Text) > 0 && Convert.ToDouble(TB_kg_disponibles.Text) > 0)
                {
                    SqlCommand spModificarAeronave = this.db.GetStoreProcedure("TS.spModificarAeronave");
                    spModificarAeronave.Parameters.Add(new SqlParameter("@modelo", TB_modelo.Text));
                    spModificarAeronave.Parameters.Add(new SqlParameter("@matricula", TB_matricula.Text));
                    spModificarAeronave.Parameters.Add(new SqlParameter("@fabricante", TB_fabricante.Text));
                    spModificarAeronave.Parameters.Add(new SqlParameter("@servicio", CB_servicio.SelectedValue));
                    spModificarAeronave.Parameters.Add(new SqlParameter("@numero", Convert.ToInt64(TB_numero.Text)));
                    spModificarAeronave.Parameters.Add(new SqlParameter("@kg_disponibles", Convert.ToInt64(TB_kg_disponibles.Text)));
                    SqlParameter returnParameter = spModificarAeronave.Parameters.Add("RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    spModificarAeronave.ExecuteNonQuery();
                    if ((int)returnParameter.Value == -1) MessageBox.Show("La matricula no es unica, por favor use otra");
                    else this.Close();
                } else MessageBox.Show("La cantidad de butacas pasillo, butacas ventanilla y kg disponibles tienen que ser mayor a 0");
            } else MessageBox.Show("La cantidad de butacas pasillo, butacas ventanilla y kg disponibles tienen que ser mayor a 0");
        }

        private void ModificacionAeronave_Load(object sender, EventArgs e)
        {

        }
    }
}
