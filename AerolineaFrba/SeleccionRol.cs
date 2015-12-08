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
    public partial class SeleccionRol : Form
    {
        string rol, username;
        DbComunicator db;

        public SeleccionRol(string user)
        {
            InitializeComponent();
            this.username = user;
            this.db = new DbComunicator();
            string queryRol = "SELECT RU.Rol_Nombre Nombre FROM TS.Rol_Usuario AS RU WHERE RU.Usr_Username='" + username + "' AND RU.Rol_Usuario_Borrado=0";
            Dictionary<object, object> Roles = this.db.GetQueryDictionary(queryRol, "Nombre", "Nombre");
            CB_roles.DataSource = new BindingSource(Roles, null);
            CB_roles.DisplayMember = "Value";
            CB_roles.ValueMember = "Key";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rol = CB_roles.SelectedValue.ToString();
            SeleccionFuncionalidad re = new SeleccionFuncionalidad(rol, username);
            re.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
