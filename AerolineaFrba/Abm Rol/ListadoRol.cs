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

namespace AerolineaFrba.Abm_Rol
{
    public partial class ListadoRol : Form
    {
        DbComunicator db;

        public ListadoRol()
        {
            InitializeComponent();
            this.db = new DbComunicator();
        }

        private void ListadoRol_Load(object sender, EventArgs e)
        {
            string QueryRol = "SELECT Rol_Nombre Nombre, Rol_Estado Estado, Rol_Borrado Borrado FROM [GD2C2015].[TS].[Rol]";
            DGV_rol.DataSource = db.GetDataAdapter(QueryRol).Tables[0];
            DGV_rol.CellClick += this.ActivarAcciones;
            DGV_rol.RowHeaderMouseClick += this.ActivarAcciones;
        }

        private void ActivarAcciones(object sender, EventArgs e)
        {
            if (!DGV_rol.SelectedRows[0].Cells["Nombre"].Value.ToString().Equals(""))
            {
                if (!Convert.ToBoolean(DGV_rol.SelectedRows[0].Cells["Borrado"].Value)) this.BT_eliminar.Enabled = true;
                this.BT_modificar.Enabled = true;
                this.BT_Habilitar.Enabled = true;
                this.BT_Deshabilitar.Enabled = true;
                this.BT_eliminar_funcionalidad.Enabled = true;
                this.BT_agregar_funcionalidad.Enabled = true;
                DGV_rol.SelectionChanged += this.DesactivarAcciones;
            }
            else this.DesactivarAcciones(sender, e);
        }

        private void DesactivarAcciones(object sender, EventArgs e)
        {
            this.BT_eliminar.Enabled = false;
            this.BT_modificar.Enabled = false;
            this.BT_Habilitar.Enabled = false;
            this.BT_Deshabilitar.Enabled = false;
            this.BT_eliminar_funcionalidad.Enabled = false;
            this.BT_agregar_funcionalidad.Enabled = false;
            DGV_rol.SelectionChanged -= this.DesactivarAcciones;
        }

        private void BT_buscar_Click(object sender, EventArgs e)
        {
            string QueryBusqueda = "SELECT Rol_Nombre Nombre, Rol_Estado Estado, Rol_Borrado Borrado FROM [GD2C2015].[TS].[Rol] WHERE Rol_Nombre LIKE '%" + TB_rol.Text + "%'";
            DGV_rol.DataSource = db.GetDataAdapter(QueryBusqueda).Tables[0];
        }

        private void BT_agregar_Click(object sender, EventArgs e)
        {
            AltaRol re = new AltaRol();
            re.FormClosed += new FormClosedEventHandler(ListadoRol_Load);
            re.ShowDialog();
        }

        private void BT_modificar_Click(object sender, EventArgs e)
        {
            ModificacionRol re = new ModificacionRol(DGV_rol.SelectedRows[0]);
            re.FormClosed += new FormClosedEventHandler(ListadoRol_Load);
            re.ShowDialog();
        }

        private void BT_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Usted esta seguro de borrar este rol?", "Confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand spBorrarRol = this.db.GetStoreProcedure("TS.spBorrarRol");
                spBorrarRol.Parameters.Add(new SqlParameter("@nombre", DGV_rol.SelectedRows[0].Cells["Nombre"].Value));
                spBorrarRol.ExecuteNonQuery();
            }
            this.ListadoRol_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_Habilitar_Click(object sender, EventArgs e)
        {
            SqlCommand spHabilitarRol = this.db.GetStoreProcedure("TS.spHabilitarRol");
            spHabilitarRol.Parameters.Add(new SqlParameter("@nombre", DGV_rol.SelectedRows[0].Cells["Nombre"].Value));
            spHabilitarRol.ExecuteNonQuery();
            this.ListadoRol_Load(sender, e);
        }

        private void BT_Deshabilitar_Click(object sender, EventArgs e)
        {
            SqlCommand spDeshabilitarRol = this.db.GetStoreProcedure("TS.spDeshabilitarRol");
            spDeshabilitarRol.Parameters.Add(new SqlParameter("@nombre", DGV_rol.SelectedRows[0].Cells["Nombre"].Value));
            spDeshabilitarRol.ExecuteNonQuery();
            this.ListadoRol_Load(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Funcionalidades re = new Funcionalidades(DGV_rol.SelectedRows[0], "Agregar");
            re.FormClosed += new FormClosedEventHandler(ListadoRol_Load);
            re.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Funcionalidades re = new Funcionalidades(DGV_rol.SelectedRows[0], "Eliminar");
            re.FormClosed += new FormClosedEventHandler(ListadoRol_Load);
            re.ShowDialog();
        }


    }
}
