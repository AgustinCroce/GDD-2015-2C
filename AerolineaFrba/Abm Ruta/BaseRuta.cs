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

namespace AerolineaFrba.Abm_Ruta
{
    public partial class BaseRuta : Form
    {
        public DbComunicator db;
        public Commons.Validator validator, validator2, validator3;
        public Commons.EnabledButtons enabledButtons;

        public BaseRuta()
        {
            InitializeComponent();
            this.db = new DbComunicator();
            this.validator = new Commons.Validator();
            this.validator2 = new Commons.Validator();
            this.validator3 = new Commons.Validator();
            this.enabledButtons = new Commons.EnabledButtons();
            TB_precio_kg.KeyPress += this.InputNumField_KeyPress2;
            TB_precio_pasaje.KeyPress += this.InputNumField_KeyPress3;
            TB_codigo_unico.KeyPress += this.InputNumField_KeyPress;
        }

        private void InputNumField_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validator.KeyPressBinding(this.validator.validateInt, false, e);
        }

        private void InputNumField_KeyPress2(object sender, KeyPressEventArgs e)
        {
            this.validator2.KeyPressBinding2(this.validator2.validateDouble, false, e, TB_precio_kg.Text);
        }

        private void InputNumField_KeyPress3(object sender, KeyPressEventArgs e)
        {
            this.validator3.KeyPressBinding2(this.validator3.validateDouble, false, e, TB_precio_pasaje.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BaseRuta_Load(object sender, EventArgs e)
        {
            string QueryCiudades = "SELECT Ciudad_Cod Codigo, Ciudad_Nombre 'Nombre' FROM [GD2C2015].[TS].[Ciudad] WHERE Ciudad_Borrada = 0";
            Dictionary<object, object> Ciudades = this.db.GetQueryDictionary(QueryCiudades, "Codigo", "Nombre");
            CB_destino.DataSource = new BindingSource(Ciudades, null);
            CB_origen.DataSource = new BindingSource(Ciudades, null);
            CB_destino.DisplayMember = "Value";
            CB_destino.ValueMember = "Key";
            CB_origen.DisplayMember = "Value";
            CB_origen.ValueMember = "Key";

        }
    }
}
