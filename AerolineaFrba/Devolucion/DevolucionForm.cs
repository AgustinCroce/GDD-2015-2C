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
using System.Data.SqlClient;

namespace AerolineaFrba.Devolucion
{
    public partial class DevolucionForm : Form
    {
        public DevolucionForm()
        {
            InitializeComponent();
            pnrTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            pnrTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            string queryCuentas = "SELECT Com_PNR FROM TS.Compra";
            DbComunicator db = new DbComunicator();
            db.CargarAutocomplete(col, queryCuentas, "Com_PNR");
            pnrTextBox.AutoCompleteCustomSource = col;
            pnrTextBox.TextChanged += new EventHandler(pnrTextBox_TextChanged);
            encomiendaGroupBox.Enabled = false;
            pasajesGroupBox.Enabled = false;
            db.CerrarConexion();
        }

        private void fillRows()
        {
            if (!String.IsNullOrEmpty(pnrTextBox.Text)) {
                DbComunicator db = new DbComunicator();
                db.EjecutarQuery("SELECT COUNT(*) Cantidad FROM TS.Encomienda_Compra WHERE Com_PNR = " + pnrTextBox.Text);
                db.getLector().Read();

                if (Convert.ToInt16(db.getLector()["Cantidad"].ToString()) > 0)
                {
                    string queryEncomieda = "SELECT E.Enc_Cod, E.Enc_Fecha_Compra, E.Enc_Kg";
                    queryEncomieda += " FROM TS.Encomienda_Compra AS EC, TS.Encomienda AS E";
                    queryEncomieda += " WHERE EC.Enc_Cod = E.Enc_Cod AND EC.Com_PNR = " + pnrTextBox.Text;
                    encomiendaGridView.DataSource = db.GetDataAdapter(queryEncomieda).Tables[0];
                    encomiendaGroupBox.Enabled = true;
                }
                else
                {
                    encomiendaGridView = new DataGridView();
                    encomiendaGroupBox.Enabled = false;
                }

                db = new DbComunicator();
                db.EjecutarQuery("SELECT COUNT(*) Cantidad FROM TS.Pasaje_Compra WHERE Com_PNR = " + pnrTextBox.Text);
                db.getLector().Read();

                if (Convert.ToInt16(db.getLector()["Cantidad"].ToString()) > 0)
                {
                    string queryPasajes = "SELECT P.Pas_Cod, P.Pas_Fecha_Compra, P.Pas_Precio, C.Cli_Nombre";
                    queryPasajes += " FROM TS.Pasaje_Compra AS PC, TS.Pasaje as P, TS.Cliente AS C";
                    queryPasajes += " WHERE PC.Pas_Cod = P.Pas_Cod AND P.Cli_Cod = C.Cli_Cod AND PC.Com_PNR = " + pnrTextBox.Text;
                    pasajeGridView.DataSource = db.GetDataAdapter(queryPasajes).Tables[0];
                    pasajesGroupBox.Enabled = true;
                }
                else
                {
                    pasajeGridView = new DataGridView();
                    pasajesGroupBox.Enabled = false;
                }

                db.CerrarConexion();
            }
        }

        private void pnrTextBox_TextChanged(object sender, EventArgs e)
        {
            fillRows();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            DbComunicator dbStoreProcedure = new DbComunicator();
            SqlCommand storeProcedure = dbStoreProcedure.GetStoreProcedure("TS.spCancelarCompra");
            SqlParameter returnParameter = storeProcedure.Parameters.Add("RetVal", SqlDbType.BigInt);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            storeProcedure.Parameters.Add(new SqlParameter("@Com_PNR", pnrTextBox.Text));
            storeProcedure.Parameters.Add(new SqlParameter("@Can_Fecha", dateTimePicker.Value));
            storeProcedure.Parameters.Add(new SqlParameter("@Can_Motivo", motivoTextBox.Text));

            DataTable pasajes = new DataTable();
            pasajes.Columns.Add("Pas_Cod", typeof(double));

            if (pasajesGroupBox.Enabled) {
                foreach (DataGridViewRow row in pasajeGridView.SelectedRows)
                {
                    pasajes.Rows.Add(row.Cells[0].Value);
                }
            }

            int encCod = 0;

            if (encomiendaGroupBox.Enabled && encomiendaGridView.SelectedRows.Count > 0) {
                encCod = Convert.ToInt32(encomiendaGridView.SelectedRows[0].Cells[0].Value);
            }

            storeProcedure.Parameters.Add(new SqlParameter("@Enc_Cod", encCod));
            storeProcedure.Parameters.Add(new SqlParameter("@ListaPasajes", pasajes));

            storeProcedure.ExecuteNonQuery();
            dbStoreProcedure.CerrarConexion();

            if ((int)returnParameter.Value == 0)
            {
                MessageBox.Show("Cancelación realiza con éxito.");
                fillRows();
            }
        }

    }
}
