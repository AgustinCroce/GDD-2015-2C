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
using System.Data.SqlClient;

namespace AerolineaFrba
{
    public partial class Form1 : Form
    {
        Commons.EnabledButtons enabledButtons;
        public Form1()
        {
            InitializeComponent();
            this.enabledButtons = new Commons.EnabledButtons();
            this.enabledButtons.RegisterTextBox(this.usernameTextBox);
            //this.enabledButtons.RegisterTextBox(this.passwordTextBox);
            this.enabledButtons.RegisterButton(this.logInButton);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                this.logInButton.PerformClick();
            }
        }

        public int GetCountUsers(DbComunicator dbCount, string username)
        {
            dbCount.EjecutarQuery("SELECT count(*) FROM [GD1C2015].[NULL].[USUARIO] WHERE Usr_Username = '"
            + usernameTextBox.Text + "'");

            dbCount.getLector().Read();
            int count = dbCount.getLector().GetInt32(0);
            dbCount.CerrarConexion();

            return count;
        }

        public int LlamarProcedureLogin(string username, string password)
        {
            DbComunicator dbStoreProcedure = new DbComunicator();
            SqlCommand storeProcedure = dbStoreProcedure.GetStoreProcedure("TS.spRealizarLogin");
            SqlParameter returnParameter = storeProcedure.Parameters.Add("RetVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            storeProcedure.Parameters.Add(new SqlParameter("@Username", username));
            storeProcedure.Parameters.Add(new SqlParameter("@Password", password));
            storeProcedure.ExecuteNonQuery();
            dbStoreProcedure.CerrarConexion();
            return (int)returnParameter.Value;
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            DbComunicator db1 = new DbComunicator();
            string username = usernameTextBox.Text;
            string password = new Sha256Generator().GetHashString(passTextBox.Text);
            int resultado = this.LlamarProcedureLogin(username, password);
            switch (resultado)
            {
                case 0:
                    MessageBox.Show("Te logeaste master!"); break;
                case 1: MessageBox.Show("Login Invalido!"); break;
                case 2: MessageBox.Show("El usuario no existe"); break;
                case 3: MessageBox.Show("El usuario se encuentra deshabilitado. Comuniquese con un administrador del sistema."); break;
            }
            passTextBox.Text = "";
            db1.CerrarConexion();
        }
    }
}
