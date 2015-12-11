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

namespace AerolineaFrba.Abm_Rol
{
    public partial class AltaRol : AerolineaFrba.Abm_Rol.BaseRol
    {
        public AltaRol()
        {
            InitializeComponent();
            this.enabledButtons.RegisterTextBox(TB_nombre);
            this.enabledButtons.RegisterButton(BT_guardar);
        }

        private void BT_guardar_Click(object sender, EventArgs e)
        {
            if (CB_estado.Text == "Habilitado" || CB_estado.Text == "Deshabilitado")
            {
                SqlCommand spALtaRol = this.db.GetStoreProcedure("TS.spAltaRol");
                spALtaRol.Parameters.Add(new SqlParameter("@nombre", TB_nombre.Text));
                spALtaRol.Parameters.Add(new SqlParameter("@estado", CB_estado.Text));
                SqlParameter returnParameter = spALtaRol.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                spALtaRol.ExecuteNonQuery();
                if ((int)returnParameter.Value == -1) MessageBox.Show("El nombre del rol es unico, este nombre de rol ya esta utilizado, por favor cambielo");
                else this.Close();
            } else MessageBox.Show("Seleccione un estado valido (Habilitado o Deshabilitado)");
        }
    }
}
