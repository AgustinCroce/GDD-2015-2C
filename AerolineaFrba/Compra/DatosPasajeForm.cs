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
    public partial class DatosPasajeForm : DatosBuscadorForm
    {
        private DataGridView pasajeGridView;
        public int butacaReservada;
        int viajCod;

        public DatosPasajeForm(int viajCod, DataGridView pasajeGridView, List<int> butacasReservadas)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.pasajeGridView = pasajeGridView;
            this.butacaReservada = 0;
            this.viajCod = viajCod;
            acceptButton.Enabled = false;
            string butacasR = "";
            butacaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (var butaca in butacasReservadas)
            {
                butacasR += " AND B.But_Cod != " + butaca + " ";
            }
            
            string queryButacas = "SELECT B.But_Cod, CAST (B.But_Piso AS nvarchar(255)) + ' ' + CAST (B.But_Numero AS nvarchar(255)) + ' ' + B.But_Tipo But_Label FROM TS.Butaca as B, TS.Viaje as V ";
            queryButacas += "WHERE B.But_Cod NOT IN (SELECT But_Cod FROM TS.Pasaje_Compra as PC, TS.Pasaje as P WHERE P.Pas_Cod = PC.Pas_Cod AND P.Viaj_Cod = "+ viajCod + ") ";
            queryButacas += "AND B.Aero_Num = V.Aero_Num AND V.Viaj_Cod = " + viajCod + " " + butacasR;
            queryButacas += "ORDER BY B.But_Piso ASC, B.But_Numero ASC";
            DbComunicator db = new DbComunicator();
            butacaComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryButacas, "But_Cod", "But_Label"), null);
            butacaComboBox.DisplayMember = "Value";
            butacaComboBox.ValueMember = "Key";
        }

        override public void foundCliCod(string cliCod)
        {
            acceptButton.Enabled = true;
        }

        override public void notFoundCliCod()
        {
            acceptButton.Enabled = false;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            bool clienteDuplicado = false;
            DbComunicator db = new DbComunicator();

            foreach (DataGridViewRow row in pasajeGridView.Rows)
            {
                clienteDuplicado = clienteDuplicado || (row.Cells[1].Value != null && (row.Cells[1].Value.ToString() == dniTextBox.Text));
            }

            db.EjecutarQuery("SELECT COUNT(*) Cantidad FROM TS.Pasaje_Compra as PC, TS.Pasaje as P WHERE P.Pas_Cod = Pc.Pas_Cod AND P.Viaj_Cod = "+ viajCod + " AND P.Cli_Cod = " + this.cliCod);
            db.getLector().Read();

            clienteDuplicado = clienteDuplicado || (Convert.ToInt32(db.getLector()["Cantidad"]) >= 1);

            if (clienteDuplicado)
            {
                MessageBox.Show("Ya se ha sacado un pasaje para este cliente en este vuelo.");
            }
            else {
                this.pasajeGridView.Rows.Insert(0, this.cliCod, dniTextBox.Text, fullNameTextBox.Text, addressTextBox.Text, phoneTextBox.Text, bornDateTimePicker.Value, mailTextBox.Text, butacaComboBox.SelectedValue);
                this.butacaReservada = Convert.ToInt32(butacaComboBox.SelectedValue);
                this.Close();
            }
            
        }
    }
}
