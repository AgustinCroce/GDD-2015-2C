using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Compra
{
    public partial class PagoAdminForm : PagoKioskoForm
    {
        public PagoAdminForm()
        {
            InitializeComponent();
            cardCheckBox.CheckedChanged += new EventHandler(cardCheckBox_CheckedChanged);
            cardCheckBox.Checked = false;
            creditCardGroupBox.Enabled = false;
        }

        public void cardCheckBox_CheckedChanged(object sender, EventArgs e) {
            creditCardGroupBox.Enabled = cardCheckBox.Checked; 
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            this.habilitado = true;
            if (cardCheckBox.Checked)
            {
                this.Tar_Numero = Convert.ToDouble(cardNumberTextBox.Text);
                this.Com_Cuotas = Convert.ToDouble(cardNumberDuesComboBox.SelectedValue);
                this.Com_Forma_Pago = "Tarjeta";
            }
            else {
                this.Tar_Numero = 0;
                this.Com_Cuotas = 0;
                this.Com_Forma_Pago = "Efectivo";
            }
            this.Close();
        }
    }
}
