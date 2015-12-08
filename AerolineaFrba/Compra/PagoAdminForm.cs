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
            aceptarButton.Enabled = true;
        }

        public void cardCheckBox_CheckedChanged(object sender, EventArgs e) {
            creditCardGroupBox.Enabled = cardCheckBox.Checked;
            if (cardCheckBox.Checked)
            {
                aceptarButton.Enabled = false;
            }
            else {
                aceptarButton.Enabled = true;
                cardCodeTextBox.Text = "";
                cardEmitterTextBox.Text = "";
                cardNumberDuesComboBox.DataSource = null;
                cardDateTextBox.Text = "";
            }
            this.fillInputs();
        }

        public override void foundCard() {
            aceptarButton.Enabled = true;
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            this.habilitado = true;
            if (cardCheckBox.Checked)
            {
                if (this.validarFechaTarjeta(cardDateTextBox.Text, Convert.ToDateTime(Properties.Settings.Default.FechaSistema)))
                {
                    this.Tar_Numero = Convert.ToDouble(cardNumberTextBox.Text);
                    this.Com_Cuotas = Convert.ToDouble(cardNumberDuesComboBox.SelectedValue);
                    this.Com_Forma_Pago = "Tarjeta";
                }
                else {
                    this.habilitado = false;
                    MessageBox.Show("La tarjeta que selecciono se encuentra vencida");
                }
            }
            else
            {
                this.Tar_Numero = 0;
                this.Com_Cuotas = 0;
                this.Com_Forma_Pago = "Efectivo";
            }

            if (this.habilitado) {
                this.Close();
            }
            
        }
    }
}
