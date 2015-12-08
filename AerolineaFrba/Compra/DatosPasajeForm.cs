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

            DbComunicator db = new DbComunicator();
            SqlCommand storeProcedure = db.GetStoreProcedure("TS.fnGetPrecioPasaje");
            SqlParameter returnParameter = storeProcedure.Parameters.Add("RetVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            storeProcedure.Parameters.Add(new SqlParameter("@Viaj_Cod", viajCod));
            storeProcedure.ExecuteNonQuery();
            db.CerrarConexion();

            precioTextBox.Text = ((int)returnParameter.Value).ToString();

            foreach (var butaca in butacasReservadas)
            {
                butacasR += " AND B.But_Cod != " + butaca + " ";
            }
            
            string queryButacas = "SELECT B.But_Cod, CAST (B.But_Piso AS nvarchar(255)) + ' ' + CAST (B.But_Numero AS nvarchar(255)) + ' ' + B.But_Tipo But_Label FROM TS.Butaca as B, TS.Viaje as V ";
            queryButacas += "WHERE B.But_Cod NOT IN (SELECT But_Cod FROM TS.Pasaje_Compra as PC, TS.Pasaje as P WHERE P.Pas_Cod = PC.Pas_Cod AND P.Viaj_Cod = "+ viajCod + ") ";
            queryButacas += "AND B.Aero_Num = V.Aero_Num AND V.Viaj_Cod = " + viajCod + " " + butacasR;
            queryButacas += "ORDER BY B.But_Piso ASC, B.But_Numero ASC";
            DbComunicator db2 = new DbComunicator();
            butacaComboBox.DataSource = new BindingSource(db2.GetQueryDictionary(queryButacas, "But_Cod", "But_Label"), null);
            butacaComboBox.DisplayMember = "Value";
            butacaComboBox.ValueMember = "Key";
            db2.CerrarConexion();
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
                db = new DbComunicator();
                SqlCommand storeProcedure = db.GetStoreProcedure("TS.fnValidarViajeCliente");
                SqlParameter returnParameter = storeProcedure.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                storeProcedure.Parameters.Add(new SqlParameter("@Cli_Cod", this.cliCod));
                storeProcedure.Parameters.Add(new SqlParameter("@Viaj_Cod", this.viajCod));
                storeProcedure.ExecuteNonQuery();
                db.CerrarConexion();

                if ((int)returnParameter.Value == 1)
                {
                    string cliDni = "";
                    DbComunicator db1 = new DbComunicator();
                    db1.EjecutarQuery("SELECT Cli_DNI FROM TS.Cliente WHERE Cli_Cod = " + this.cliCod);
                    db1.getLector().Read();
                    cliDni = db1.getLector()["Cli_DNI"].ToString();
                    this.pasajeGridView.Rows.Insert(0, this.cliCod, cliDni, fullNameTextBox.Text, addressTextBox.Text, butacaComboBox.SelectedValue, precioTextBox.Text);
                    this.butacaReservada = Convert.ToInt32(butacaComboBox.SelectedValue);
                    db1.CerrarConexion();
                    this.Close();
                }
                else {
                    MessageBox.Show("El cliente ya tiene un pasaje para un vuelo que sale el mismo dia que el viaje selccionado.");
                }
                
            }
            
        }
    }
}
