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

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class ListadoCiudad : Form
    {
        DbComunicator db;

        public ListadoCiudad()
        {
            InitializeComponent();
            this.db = new DbComunicator();
        }

        private void ListadoCiudad_Load(object sender, EventArgs e)
        {
            string QueryCiudad = "SELECT Ciudad_Cod Codigo, Ciudad_Nombre Nombre, Ciudad_Borrada Borrada FROM [GD2C2015].[TS].[Ciudad]";
            string QueryCiudadNombres = "SELECT Ciudad_Nombre Nombre FROM [GD2C2015].[TS].[Ciudad]";
            DGV_ciudad.DataSource = db.GetDataAdapter(QueryCiudad).Tables[0];
            Dictionary<object, object> Nombres = this.db.GetQueryDictionary(QueryCiudadNombres, "Nombre", "Nombre");
            DGV_ciudad.CellClick += this.ActivarAcciones;
            DGV_ciudad.RowHeaderMouseClick += this.ActivarAcciones;
        }

        private void ActivarAcciones(object sender, EventArgs e)
        {
            if (!DGV_ciudad.SelectedRows[0].Cells["Nombre"].Value.ToString().Equals(""))
            {
                this.BT_eliminar.Enabled = true;
                this.BT_modificar.Enabled = true;
                DGV_ciudad.SelectionChanged += this.DesactivarAcciones;
            }
            else this.DesactivarAcciones(sender, e);
        }

        private void DesactivarAcciones(object sender, EventArgs e)
        {
            this.BT_eliminar.Enabled = false;
            this.BT_modificar.Enabled = false;
            DGV_ciudad.SelectionChanged -= this.DesactivarAcciones;
        }

        private void BT_buscar_Click(object sender, EventArgs e)
        {
            string QueryBusqueda = "SELECT Ciudad_Cod Codigo, Ciudad_Nombre Nombre, Ciudad_Borrada Borrada FROM [GD2C2015].[TS].[Ciudad] WHERE Ciudad_Nombre LIKE '%" + TB_ciudad.Text + "%'";
            DGV_ciudad.DataSource = db.GetDataAdapter(QueryBusqueda).Tables[0];
        }

        private void BT_agregar_Click(object sender, EventArgs e)
        {
            AltaCiudad re = new AltaCiudad();
            re.FormClosed += new FormClosedEventHandler(ListadoCiudad_Load);
            re.ShowDialog();
        }

        private void BT_modificar_Click(object sender, EventArgs e)
        {
            ModificacionCiudad re = new ModificacionCiudad(DGV_ciudad.SelectedRows[0]);
            re.FormClosed += new FormClosedEventHandler(ListadoCiudad_Load);
            re.ShowDialog();
        }

        private void BT_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Usted esta seguro de borrar esta ciudad?", "Confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand spBorrarCiudad = this.db.GetStoreProcedure("TS.spBorrarCiudad");
                spBorrarCiudad.Parameters.Add(new SqlParameter("@Codigo", Convert.ToInt64(DGV_ciudad.SelectedRows[0].Cells["Codigo"].Value)));
                spBorrarCiudad.ExecuteNonQuery();
            }
            this.ListadoCiudad_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
