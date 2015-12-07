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
    public partial class TarjetaBaseForm : Form
    {
        public Commons.Validator validator;
        public TarjetaBaseForm()
        {
            InitializeComponent();
            this.validator = new Commons.Validator();
            cardDateTextBox.KeyPress += InputNumField_KeyPress;
            cardCodeTextBox.KeyPress += InputNumField_KeyPress;
            cardNumberTextBoxt.KeyPress += InputNumField_KeyPress;
            string queryCiudades = "SELECT TipoTar_Nombre, TipoTar_Cod FROM TS.Tipo_Tarjeta";
            DbComunicator db = new DbComunicator();
            cardEmitterComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryCiudades, "TipoTar_Nombre", "TipoTar_Cod"), null);
            cardEmitterComboBox.DisplayMember = "Key";
            cardEmitterComboBox.ValueMember = "Value";
            cardEmitterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            db.CerrarConexion();
        }

        private void InputNumField_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validator.KeyPressBinding(this.validator.validateInt, false, e);
        }

        public bool validarFecha() {
            bool ok = true;
            int mes = 0;
            if (cardDateTextBox.Text.Length < 4)
            {
                ok = false;
            }
            else {
                mes = Convert.ToInt32(cardDateTextBox.Text.Substring(0, 2));
                if (mes <= 0 || mes > 12) {
                    ok = false;
                }
            }

            if (!ok) {
                MessageBox.Show("El campo fecha debe tener 4 digitos que representen en form MMAA la fecha de vencimiento de la tarjeta");
            }

            return ok;
        }
    }
}
