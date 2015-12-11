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
        public Commons.Validator validator;

        public DevolucionForm()
        {
            InitializeComponent();
            this.validator = new Commons.Validator();
            pnrTextBox.TextChanged += new EventHandler(pnrTextBox_TextChanged);
            encomiendaGroupBox.Enabled = false;
            pasajesGroupBox.Enabled = false;
            encomiendaGridView.CellClick += this.ActivarAcciones;
            encomiendaGridView.RowHeaderMouseClick += this.ActivarAcciones;
            pasajeGridView.CellClick += this.ActivarAcciones;
            pasajeGridView.RowHeaderMouseClick += this.ActivarAcciones;
            acceptButton.Enabled = false;
        }

        private void ActivarAcciones(object sender, EventArgs e)
        {
            acceptButton.Enabled = pasajeGridView.SelectedRows.Count > 0 || encomiendaGridView.SelectedRows.Count > 0;
        }


        private void InputNumField_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validator.KeyPressBinding(this.validator.validateInt, false, e);
        }

        private void fillRows()
        {
            acceptButton.Enabled = false;
            if (!String.IsNullOrEmpty(pnrTextBox.Text)) {
                DbComunicator db = new DbComunicator();
                db.EjecutarQuery("SELECT COUNT(*) Cantidad FROM TS.Encomienda WHERE Com_PNR = " + pnrTextBox.Text);
                db.getLector().Read();

                if (Convert.ToInt16(db.getLector()["Cantidad"].ToString()) > 0)
                {
                    string queryEncomieda = "SELECT E.Enc_Cod, C.Com_Fecha, E.Enc_Kg";
                    queryEncomieda += " FROM TS.Encomienda AS E, TS.Compra AS C, TS.Viaje AS V";
                    queryEncomieda += " WHERE E.Com_PNR = " + pnrTextBox.Text + " AND E.Com_PNR = C.Com_PNR AND E.Can_Cod IS NULL AND V.Viaj_Cod = E.Viaj_Cod AND V.Fecha_Llegada IS NULL";
                    encomiendaGridView.DataSource = db.GetDataAdapter(queryEncomieda).Tables[0];
                    encomiendaGridView.ClearSelection();
                    encomiendaGroupBox.Enabled = true;
                }
                else
                {
                    DbComunicator dbC = new DbComunicator();
                    string queryEncomieda = "SELECT E.Enc_Cod, NULL Com_Fecha, E.Enc_Kg";
                    queryEncomieda += " FROM TS.Encomienda AS E, TS.Compra AS C";
                    queryEncomieda += " WHERE E.Enc_Cod= -1" ;
                    encomiendaGridView.DataSource = dbC.GetDataAdapter(queryEncomieda).Tables[0];
                    encomiendaGroupBox.Enabled = false;
                }

                db = new DbComunicator();
                db.EjecutarQuery("SELECT COUNT(*) Cantidad FROM TS.Pasaje WHERE Com_PNR = " + pnrTextBox.Text);
                db.getLector().Read();

                if (Convert.ToInt16(db.getLector()["Cantidad"].ToString()) > 0)
                {
                    string queryPasajes = "SELECT P.Pas_Cod, CM.Com_Fecha, P.Pas_Precio, C.Cli_Nombre";
                    queryPasajes += " FROM TS.Pasaje as P, TS.Cliente AS C, TS.Compra AS CM, TS.Viaje AS V";
                    queryPasajes += " WHERE P.Cli_Cod = C.Cli_Cod AND P.Com_PNR = " + pnrTextBox.Text + " AND P.Can_Cod IS NULL AND CM.Com_PNR = P.Com_PNR AND V.Viaj_Cod = P.Viaj_Cod AND V.Fecha_Llegada IS NULL";
                    pasajeGridView.DataSource = db.GetDataAdapter(queryPasajes).Tables[0];
                    pasajeGridView.ClearSelection();
                    pasajesGroupBox.Enabled = true;
                }
                else
                {
                    DbComunicator dbP = new DbComunicator();
                    string queryPasajes = "SELECT P.Pas_Cod, NULL Com_Fecha, P.Pas_Precio, '' Cli_Nombre";
                    queryPasajes += " FROM TS.Pasaje as P";
                    queryPasajes += " WHERE P.Pas_Cod = -1";
                    pasajeGridView.DataSource = dbP.GetDataAdapter(queryPasajes).Tables[0];
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
            storeProcedure.Parameters.Add(new SqlParameter("@Can_Fecha", Properties.Settings.Default.FechaSistema));
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

        private void refreshPasajeButton_Click(object sender, EventArgs e)
        {
            pasajeGridView.ClearSelection();
            acceptButton.Enabled = pasajeGridView.SelectedRows.Count > 0 || encomiendaGridView.SelectedRows.Count > 0;
        }

        private void refreshEncomiendaButton_Click(object sender, EventArgs e)
        {
            encomiendaGridView.ClearSelection();
            acceptButton.Enabled = pasajeGridView.SelectedRows.Count > 0 || encomiendaGridView.SelectedRows.Count > 0;
        }

        private void DevolucionForm_Load(object sender, EventArgs e)
        {
            pnrTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            pnrTextBox.KeyPress += this.InputNumField_KeyPress;
            pnrTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            string queryCompras = "SELECT P.Com_PNR Com_PNR FROM TS.Pasaje as P, TS.Viaje as V";
            queryCompras += " WHERE P.Can_Cod IS NULL AND P.Viaj_Cod = V.Viaj_Cod AND V.Fecha_Llegada IS NULL";
            queryCompras += " UNION SELECT E.Com_PNR FROM TS.Encomienda as E, TS.Viaje as V";
            queryCompras += " WHERE E.Can_Cod IS NULL AND E.Viaj_Cod = V.Viaj_Cod AND V.Fecha_Llegada IS NULL";
            DbComunicator db = new DbComunicator();
            db.CargarAutocomplete(col, queryCompras, "Com_PNR");
            pnrTextBox.AutoCompleteCustomSource = col;
            db.CerrarConexion();
        }

    }
}
