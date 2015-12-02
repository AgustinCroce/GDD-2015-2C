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

namespace AerolineaFrba.Abm_Rol
{
    public partial class BaseRol : Form
    {
        public DbComunicator db;
        public Commons.Validator validator;
        public Commons.EnabledButtons enabledButtons;

        public BaseRol()
        {
            InitializeComponent();
            this.db = new DbComunicator();
            this.validator = new Commons.Validator();
            this.enabledButtons = new Commons.EnabledButtons();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
