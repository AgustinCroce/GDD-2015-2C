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
    public partial class Funcionalidades : Form
    {
        string RolNombre, accion;
        DbComunicator db;

        public Funcionalidades(DataGridViewRow selected, string accion)
        {
            InitializeComponent();
            this.RolNombre = selected.Cells["Nombre"].Value.ToString();
            this.accion = accion;
            this.db = new DbComunicator();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Funcionalidades_Load(object sender, EventArgs e)
        {
            if (this.accion == "Agregar")
            {
                string QueryFuncionalidades = "SELECT Func_Cod Codigo, Func_Nombre Nombre FROM [GD2C2015].[TS].[Funcionalidad]";
                Dictionary<object, object> Funcionalidades = this.db.GetQueryDictionary(QueryFuncionalidades, "Codigo", "Nombre");
                CB_funcionalidades.DataSource = new BindingSource(Funcionalidades, null);
                CB_funcionalidades.DisplayMember = "Value";
                CB_funcionalidades.ValueMember = "Key";
                BT_guardar.Text = "Agregar";
            }
            else
            {
                string QueryFuncionalidades = "SELECT F.Func_Cod Codigo, F.Func_Nombre Nombre FROM [GD2C2015].[TS].[Funcionalidad] AS F, [GD2C2015].[TS].[Rol_Funcionalidad] AS RF WHERE F.Func_Cod=RF.Func_Cod AND RF.Rol_Nombre='" + this.RolNombre + "'" ;
                Dictionary<object, object> Funcionalidades = this.db.GetQueryDictionary(QueryFuncionalidades, "Codigo", "Nombre");
                CB_funcionalidades.DataSource = new BindingSource(Funcionalidades, null);
                CB_funcionalidades.DisplayMember = "Value";
                CB_funcionalidades.ValueMember = "Key";
                BT_guardar.Text = "Eliminar";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.accion == "Agregar"){
                SqlCommand spALtaRolFuncionalidad = this.db.GetStoreProcedure("TS.spAltaRolFuncionalidad");
                spALtaRolFuncionalidad.Parameters.Add(new SqlParameter("@rol", this.RolNombre));
                spALtaRolFuncionalidad.Parameters.Add(new SqlParameter("@funcionalidad", Convert.ToInt64(CB_funcionalidades.SelectedValue)));
                spALtaRolFuncionalidad.ExecuteNonQuery();
            }
            else {
                SqlCommand spBorrarRolFuncionalidad = this.db.GetStoreProcedure("TS.spBorrarRolFuncionalidad");
                spBorrarRolFuncionalidad.Parameters.Add(new SqlParameter("@rol", this.RolNombre));
                spBorrarRolFuncionalidad.Parameters.Add(new SqlParameter("@funcionalidad", Convert.ToInt64(CB_funcionalidades.SelectedValue)));
                spBorrarRolFuncionalidad.ExecuteNonQuery();
            }
            this.Close();
        }
    }
}
