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
    public partial class SeleccionItemsForm : Form
    {
        private int kgsLibres;
        private int cantidadPasajes;

        public SeleccionItemsForm(int kgsLibres, int cantidadPasajes)
        {
            InitializeComponent();
            this.kgsLibres = kgsLibres;
            this.cantidadPasajes = cantidadPasajes;

            if (this.kgsLibres == 0) {
                addEncomiendaButton.Enabled = false;
                deleteEncomiendaButton.Enabled = false;
            }

            if (this.cantidadPasajes == 0) {
                addPasajeButton.Enabled = false;
                deletePasajeButton.Enabled = false;
            }
            
            encomiendaGridView.ColumnCount = 7;
            encomiendaGridView.Columns[0].Name = "Dni";
            encomiendaGridView.Columns[1].Name = "Nombre";
            encomiendaGridView.Columns[2].Name = "Dirección";
            encomiendaGridView.Columns[3].Name = "Teléfono";
            encomiendaGridView.Columns[4].Name = "Fecha de Nacimiento";
            encomiendaGridView.Columns[5].Name = "Mail";
            encomiendaGridView.Columns[6].Name = "Kgs";

            pasajeGridView.ColumnCount = 7;
            pasajeGridView.Columns[0].Name = "Dni";
            pasajeGridView.Columns[1].Name = "Nombre";
            pasajeGridView.Columns[2].Name = "Dirección";
            pasajeGridView.Columns[3].Name = "Teléfono";
            pasajeGridView.Columns[4].Name = "Fecha de Nacimiento";
            pasajeGridView.Columns[5].Name = "Mail";
            pasajeGridView.Columns[6].Name = "Butaca";

        }

        private void addEncomiendaButton_Click(object sender, EventArgs e)
        {
            if (encomiendaGridView.RowCount > 1)
            {
                MessageBox.Show("Solo se puede cargar una encomieda");
            }
            else {
                DatosEncomienda de = new DatosEncomienda(encomiendaGridView, kgsLibres);
                de.Show();
            }
            
        }

        private void addPasajeButton_Click(object sender, EventArgs e)
        {
            if (encomiendaGridView.RowCount >= cantidadPasajes)
            {
                MessageBox.Show("Usted ha pedido " + this.cantidadPasajes + " pasajes.");
            }
            else
            {
                DatosPasajeForm dp = new DatosPasajeForm(pasajeGridView);
                dp.Show();
            }
        }
    }
}
