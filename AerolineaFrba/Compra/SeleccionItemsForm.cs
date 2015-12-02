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
        List<int> butacasReservadas;
        int viajCod;

        public SeleccionItemsForm(int viajCod, int kgsLibres, int cantidadPasajes)
        {
            InitializeComponent();
            this.kgsLibres = kgsLibres;
            this.cantidadPasajes = cantidadPasajes;
            this.viajCod = viajCod;
            this.butacasReservadas = new List<int>();

            if (this.kgsLibres == 0) {
                addEncomiendaButton.Enabled = false;
                deleteEncomiendaButton.Enabled = false;
            }

            if (this.cantidadPasajes == 0) {
                addPasajeButton.Enabled = false;
                deletePasajeButton.Enabled = false;
            }
            
            encomiendaGridView.ColumnCount = 8;
            encomiendaGridView.Columns[1].Name = "Cod";
            encomiendaGridView.Columns[1].Name = "Dni";
            encomiendaGridView.Columns[2].Name = "Nombre";
            encomiendaGridView.Columns[3].Name = "Dirección";
            encomiendaGridView.Columns[4].Name = "Teléfono";
            encomiendaGridView.Columns[5].Name = "Fecha de Nacimiento";
            encomiendaGridView.Columns[6].Name = "Mail";
            encomiendaGridView.Columns[7].Name = "Kgs";

            pasajeGridView.ColumnCount = 8;
            pasajeGridView.Columns[0].Name = "Cod";
            pasajeGridView.Columns[1].Name = "Dni";
            pasajeGridView.Columns[2].Name = "Nombre";
            pasajeGridView.Columns[3].Name = "Dirección";
            pasajeGridView.Columns[4].Name = "Teléfono";
            pasajeGridView.Columns[5].Name = "Fecha de Nacimiento";
            pasajeGridView.Columns[6].Name = "Mail";
            pasajeGridView.Columns[7].Name = "Butaca";

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
            if (encomiendaGridView.RowCount > cantidadPasajes)
            {
                MessageBox.Show("Usted ha pedido " + this.cantidadPasajes + " pasajes.");
            }
            else
            {
                DatosPasajeForm dp = new DatosPasajeForm(viajCod, pasajeGridView, butacasReservadas);
                dp.ShowDialog();
                if (dp.butacaReservada != 0) {
                    this.butacasReservadas.Add(dp.butacaReservada);
                }
            }
        }
    }
}
