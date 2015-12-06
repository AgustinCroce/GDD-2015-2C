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

namespace AerolineaFrba.Compra
{
    public partial class DatosBase : Form
    {
        public Commons.Validator validator;
        public DatosBase()
        {
            InitializeComponent();
            this.validator = new Commons.Validator();
            dniTextBox.KeyPress += this.InputNumField_KeyPress;
        }

        public void InputNumField_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validator.KeyPressBinding(this.validator.validateInt, false, e);
        }
                  
    }
}
