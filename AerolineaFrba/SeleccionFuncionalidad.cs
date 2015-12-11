using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Commons;

namespace AerolineaFrba
{
    public partial class SeleccionFuncionalidad : Form
    {
        string rol;
        DbComunicator db;

        public SeleccionFuncionalidad(string rolNombre)
        {
            InitializeComponent();
            this.rol = rolNombre;
            this.db = new DbComunicator();
        }

        private void SeleccionFuncionalidad_Load(object sender, EventArgs e)
        {
            string QueryFuncionalidades = "SELECT F.Func_Nombre Nombre FROM [GD2C2015].[TS].[Funcionalidad] AS F, [GD2C2015].[TS].[Rol_Funcionalidad] AS RF WHERE F.Func_Cod=RF.Func_Cod AND RF.Rol_Nombre='" + rol + "' AND F.Func_Borrado=0";
            Dictionary<object, object> Funcionalidades = this.db.GetQueryDictionary(QueryFuncionalidades, "Nombre", "Nombre");
            CB_funcionalidades.DataSource = new BindingSource(Funcionalidades, null);
            CB_funcionalidades.DisplayMember = "Value";
            CB_funcionalidades.ValueMember = "Key";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form re = null;
            if (CB_funcionalidades.SelectedValue.ToString() == "ABM de Usuario") MessageBox.Show("No existe form para esta funcionalidad");
            if (CB_funcionalidades.SelectedValue.ToString() == "ABM de Rol") re = new Abm_Rol.ListadoRol();
            if (CB_funcionalidades.SelectedValue.ToString() == "ABM de Ciudades") re = new Abm_Ciudad.ListadoCiudad();
            if (CB_funcionalidades.SelectedValue.ToString() == "ABM de Ruta Aerea") re = new Abm_Ruta.ListadoRutas();
            if (CB_funcionalidades.SelectedValue.ToString() == "ABM de Aeronaves") re = new Abm_Aeronave.ListadoAeronave();
            if (CB_funcionalidades.SelectedValue.ToString() == "Registrar Viaje") re = new Generacion_Viaje.GenerarViaje();
            if (CB_funcionalidades.SelectedValue.ToString() == "Registro de Llegada Destino") re = new Registro_Llegada_Destino.Llegada();
            if (CB_funcionalidades.SelectedValue.ToString() == "Compra de Pasaje o Encomienda") re = new Compra.SeleccionVueloForm();
            if (CB_funcionalidades.SelectedValue.ToString() == "Cancelacion de Pasaje o Encomienda") re = new Devolucion.DevolucionForm();
            if (CB_funcionalidades.SelectedValue.ToString() == "Consulta de Millas de Pasajero Frecuente") re = new Consulta_Millas.ConsultaForm();
            if (CB_funcionalidades.SelectedValue.ToString() == "Canje de Millas de Pasajero Frecuente") re = new Canje_Millas.CanjeForm();
            if (CB_funcionalidades.SelectedValue.ToString() == "Listado Estadistico") re = new Listado_Estadistico.Listado();
            if (re != null) re.ShowDialog();
        }
    }
}
