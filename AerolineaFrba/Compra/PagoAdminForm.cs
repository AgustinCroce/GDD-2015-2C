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
    }
}
