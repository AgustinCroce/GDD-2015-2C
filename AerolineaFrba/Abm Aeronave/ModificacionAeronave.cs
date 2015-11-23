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
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
            SqlCommand spModificarAeronave = this.db.GetStoreProcedure("TS.spModificarAeronave");
            spModificarAeronave.Parameters.Add(new SqlParameter("@modelo", TB_modelo.Text));
            spModificarAeronave.Parameters.Add(new SqlParameter("@matricula", TB_matricula));
            spModificarAeronave.Parameters.Add(new SqlParameter("@fabricante", TB_fabricante));
            spModificarAeronave.Parameters.Add(new SqlParameter("@numero", Convert.ToInt64(TB_numero.Text)));
            spModificarAeronave.Parameters.Add(new SqlParameter("@butacas_v", Convert.ToInt64(TB_butacas_ventanilla.Text)));
            spModificarAeronave.Parameters.Add(new SqlParameter("@butacas_p", Convert.ToInt64(TB_butacas_pasillo.Text)));
            spModificarAeronave.Parameters.Add(new SqlParameter("@kg_disponibles", Convert.ToInt64(TB_kg_disponibles.Text)));
            spModificarAeronave.ExecuteNonQuery();
        }
    }
}
