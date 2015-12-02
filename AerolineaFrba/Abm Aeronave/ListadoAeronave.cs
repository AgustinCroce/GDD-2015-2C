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
using AerolineaFrba.Commons;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class ListadoAeronave : Form
    {
        DbComunicator db;

        public ListadoAeronave()
        {
            InitializeComponent();
            this.db = new DbComunicator();
        }

        private void ListadoAeronave_Load(object sender, EventArgs e)
        {
            string QueryAeronave = "SELECT Aero_Num Numero, Aero_Modelo Modelo, Aero_Matricula Matricula, Aero_Fabricante Fabricante, Aero_Servicio Servicio, Aero_Cantidad_Kg_Disponibles 'KG Disponible', TS.fnButacasAeronave(Aero_Num, 'Ventanilla') 'Butacas Ventanilla', TS.fnButacasAeronave(Aero_Num, 'Pasillo') 'Butacas Pasillo', Aero_Borrado Borrada FROM [GD2C2015].[TS].[Aeronave]";
            string QueryServicio = "SELECT DISTINCT Aero_Servicio Nombre FROM [GD2C2015].[TS].[Aeronave]";
            DGV_aeronave.DataSource = db.GetDataAdapter(QueryAeronave).Tables[0];
            Dictionary<object, object> Servicios = this.db.GetQueryDictionary(QueryServicio, "Nombre", "Nombre");
            CB_servicio.DataSource = new BindingSource(Servicios, null);
            CB_servicio.DisplayMember = "Value";
            CB_servicio.ValueMember = "Key";
            DGV_aeronave.CellClick += this.ActivarAcciones;
            DGV_aeronave.RowHeaderMouseClick += this.ActivarAcciones;
        }

        private void ActivarAcciones(object sender, EventArgs e)
        {
            if (!DGV_aeronave.SelectedRows[0].Cells["Matricula"].Value.ToString().Equals(""))
            {
                this.BT_eliminar.Enabled = true;
                this.BT_modificar.Enabled = true;
                DGV_aeronave.SelectionChanged += this.DesactivarAcciones;
            }
            else this.DesactivarAcciones(sender, e);
        }

        private void DesactivarAcciones(object sender, EventArgs e)
        {
            this.BT_eliminar.Enabled = false;
            this.BT_modificar.Enabled = false;
            DGV_aeronave.SelectionChanged -= this.DesactivarAcciones;
        }

        private void BT_buscar_Click(object sender, EventArgs e)
        {
            string QueryBusqueda = "SELECT Aero_Num Numero, Aero_Modelo Modelo, Aero_Matricula Matricula, Aero_Fabricante Fabricante, Aero_Servicio Servicio, Aero_Cantidad_Kg_Disponibles 'KG Disponible', TS.fnButacasAeronave(Aero_Num, 'Ventanilla') 'Butacas Ventanilla', TS.fnButacasAeronave(Aero_Num, 'Pasillo') 'Butacas Pasillo', Aero_Borrado Borrada FROM [GD2C2015].[TS].[Aeronave] WHERE Aero_Servicio LIKE '%" + CB_servicio.SelectedValue + "%'";
            DGV_aeronave.DataSource = db.GetDataAdapter(QueryBusqueda).Tables[0];
        }

        private void BT_agregar_Click(object sender, EventArgs e)
        {
            AltaAeronave re = new AltaAeronave();
            re.FormClosed += new FormClosedEventHandler(ListadoAeronave_Load);
            re.Show();
        }

        private void BT_modificar_Click(object sender, EventArgs e)
        {
            ModificacionAeronave re = new ModificacionAeronave(DGV_aeronave.SelectedRows[0]);
            re.FormClosed += new FormClosedEventHandler(ListadoAeronave_Load);
            re.Show();
        }

        private void BT_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Usted esta seguro de borrar esta aeronave?", "Confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand spBorrarAeronave = this.db.GetStoreProcedure("TS.spBorrarAeronave");
                spBorrarAeronave.Parameters.Add(new SqlParameter("@numero", Convert.ToInt64(DGV_aeronave.SelectedRows[0].Cells["Numero"].Value)));
                spBorrarAeronave.ExecuteNonQuery();
            }
            this.ListadoAeronave_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
