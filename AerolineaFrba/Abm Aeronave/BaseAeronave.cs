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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class BaseAeronave : Form
    {
        public DbComunicator db;
        public Commons.Validator validator;
        public Commons.EnabledButtons enabledButtons;

        public BaseAeronave()
        {
            InitializeComponent();
            this.db = new DbComunicator();
            this.validator = new Commons.Validator();
            this.enabledButtons = new Commons.EnabledButtons();
            TB_butacas_pasillo.KeyPress += this.InputNumField_KeyPress;
            TB_butacas_ventanilla.KeyPress += this.InputNumField_KeyPress;
            TB_kg_disponibles.KeyPress += this.InputNumField_KeyPress;
            TB_numero.KeyPress += this.InputNumField_KeyPress;
        }

        private void InputNumField_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validator.KeyPressBinding(this.validator.validateInt, false, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
