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
    public partial class DatosEncomienda : DatosBuscadorForm
    {
        private DataGridView encomiendaGridView;
        private int maxKgs;

        public DatosEncomienda(DataGridView encomiendaGridView, int maxKgs)
        {
            InitializeComponent();
            this.encomiendaGridView = encomiendaGridView;
            this.maxKgs = maxKgs;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(kgsTextBox.Text) > maxKgs){
                MessageBox.Show("No puede superar más de los " + maxKgs.ToString() + " kilos");
            } else {
                this.encomiendaGridView.Rows.Insert(0, this.cliCod, dniTextBox.Text, fullNameTextBox.Text, addressTextBox.Text, phoneTextBox.Text, bornDateTimePicker.Value, mailTextBox.Text, kgsTextBox.Text);
                this.Close();
            }
        }
    }
}
