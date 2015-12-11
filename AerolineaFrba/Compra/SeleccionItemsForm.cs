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
        private double kgsLibres;
        private int cantidadPasajes;
        List<int> butacasReservadas;
        int viajCod;
        public DataTable Pas_Lista;
        public double Enc_Cod;
        public double Enc_Kgs;
        public bool habilitado;
        public double precio = 0;

        public SeleccionItemsForm(int viajCod, double kgsLibres, int cantidadPasajes)
        {
            InitializeComponent();
            this.kgsLibres = kgsLibres;
            this.cantidadPasajes = cantidadPasajes;
            this.viajCod = viajCod;
            this.butacasReservadas = new List<int>();
            this.Enc_Cod = 0;
            this.Enc_Kgs = 0;

            if (this.kgsLibres == 0) {
                addEncomiendaButton.Enabled = false;
                deleteEncomiendaButton.Enabled = false;
            }

            if (this.cantidadPasajes == 0) {
                addPasajeButton.Enabled = false;
                deletePasajeButton.Enabled = false;
            }
            
            encomiendaGridView.ColumnCount = 6;
            encomiendaGridView.Columns[0].Name = "Cod";
            encomiendaGridView.Columns[1].Name = "Dni";
            encomiendaGridView.Columns[2].Name = "Nombre";
            encomiendaGridView.Columns[3].Name = "Dirección";
            encomiendaGridView.Columns[4].Name = "Kgs";
            encomiendaGridView.Columns[5].Name = "Precio";


            pasajeGridView.ColumnCount = 6;
            pasajeGridView.Columns[0].Name = "Cod";
            pasajeGridView.Columns[1].Name = "Dni";
            pasajeGridView.Columns[2].Name = "Nombre";
            pasajeGridView.Columns[3].Name = "Dirección";
            pasajeGridView.Columns[4].Name = "Butaca";
            pasajeGridView.Columns[5].Name = "Precio";

        }

        private void addEncomiendaButton_Click(object sender, EventArgs e)
        {
            if (encomiendaGridView.RowCount > 1)
            {
                MessageBox.Show("Solo se puede cargar una encomieda");
            }
            else {
                DatosEncomienda de = new DatosEncomienda(viajCod, encomiendaGridView, kgsLibres);
                de.ShowDialog();
            }
            
        }

        private void addPasajeButton_Click(object sender, EventArgs e)
        {
            if (pasajeGridView.RowCount >= cantidadPasajes)
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

        private void acceptButton_Click(object sender, EventArgs e)
        {
            this.habilitado = encomiendaGridView.RowCount >= 1 || pasajeGridView.RowCount >= 1;
            if (this.habilitado)
            {
                DataTable pasajes = new DataTable();
                pasajes.Columns.Add("Cli_Cod", typeof(double));
                pasajes.Columns.Add("But_Cod", typeof(double));

                foreach (DataGridViewRow row in pasajeGridView.Rows)
                {
                    pasajes.Rows.Add(row.Cells[0].Value, row.Cells[4].Value);
                    this.precio += Convert.ToDouble(row.Cells[5].Value);
                }

                if (encomiendaGridView.RowCount >= 1)
                {
                    this.Enc_Cod = Convert.ToDouble(encomiendaGridView.Rows[0].Cells[0].Value);
                    this.Enc_Kgs = Convert.ToDouble(encomiendaGridView.Rows[0].Cells[4].Value);
                    this.precio += Convert.ToDouble(encomiendaGridView.Rows[0].Cells[5].Value);
                }

                this.Pas_Lista = pasajes;

                this.Close();
            }
            else {
                MessageBox.Show("Debe agregar por lo menos un item para poder continuar");
            }   

        }

        private void deleteEncomiendaButton_Click(object sender, EventArgs e)
        {
            encomiendaGridView.Rows.RemoveAt(this.encomiendaGridView.SelectedRows[0].Index);
        }

        private void deletePasajeButton_Click(object sender, EventArgs e)
        {
            butacasReservadas.Remove(Convert.ToInt32(pasajeGridView.SelectedRows[0].Cells[4].Value));
            pasajeGridView.Rows.RemoveAt(this.pasajeGridView.SelectedRows[0].Index);
        }

        private void ActivarAccionesPasaje(object sender, EventArgs e)
        {
            if (!pasajeGridView.SelectedRows[0].Cells["Cod"].Value.ToString().Equals(""))
            {
                this.deletePasajeButton.Enabled = true;
                pasajeGridView.SelectionChanged += this.DesactivarAccionesPasaje;
            }
            else this.DesactivarAccionesPasaje(sender, e);
        }

        private void DesactivarAccionesPasaje(object sender, EventArgs e)
        {
            this.deletePasajeButton.Enabled = false;
            pasajeGridView.SelectionChanged -= this.DesactivarAccionesPasaje;
        }

        private void ActivarAccionesEncomienda(object sender, EventArgs e)
        {
            if (!encomiendaGridView.SelectedRows[0].Cells["Cod"].Value.ToString().Equals(""))
            {
                this.deleteEncomiendaButton.Enabled = true;
                encomiendaGridView.SelectionChanged += this.DesactivarAccionesEncomienda;
            }
            else this.DesactivarAccionesEncomienda(sender, e);
        }

        private void DesactivarAccionesEncomienda(object sender, EventArgs e)
        {
            this.deleteEncomiendaButton.Enabled = false;
            encomiendaGridView.SelectionChanged -= this.DesactivarAccionesEncomienda;
        }

        private void SeleccionItemsForm_Load(object sender, EventArgs e)
        {
            pasajeGridView.CellClick += this.ActivarAccionesPasaje;
            pasajeGridView.RowHeaderMouseClick += this.ActivarAccionesPasaje;
            encomiendaGridView.CellClick += this.ActivarAccionesEncomienda;
            encomiendaGridView.RowHeaderMouseClick += this.ActivarAccionesEncomienda;
        }
    }
}
