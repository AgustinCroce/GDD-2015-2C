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

namespace AerolineaFrba.Consulta_Millas
{
    public partial class ConsultaForm : Form
    {

        int cliCod;
        public ConsultaForm(int cliCod)
        {
            InitializeComponent();
            this.cliCod = cliCod;
            DbComunicator db = new DbComunicator();
            db.EjecutarQuery("SELECT Cli_Nombre FROM TS.Cliente WHERE Cli_Cod = " + cliCod);
            db.getLector().Read();
            nombreLabel.Text = "Cliente Nombre: " + db.getLector()["Cli_Nombre"].ToString();
            db.CerrarConexion();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DbComunicator db = new DbComunicator();
            
                string hoy = Properties.Settings.Default.FechaSistema.ToString();
                
                string queryMillas = "SELECT M.Mil_Fecha Fecha, M.Mil_Cantidad Cantidad";
                queryMillas = queryMillas + " FROM TS.Milla as M WHERE M.Cli_Cod = " + cliCod;
                queryMillas = queryMillas + " AND M.Mil_Valida = 1 AND DATEDIFF(DAY, M.Mil_Fecha, '" + hoy + "') <= 365";
                queryMillas = queryMillas + " ORDER BY M.Mil_Fecha DESC";
                millasGridView.DataSource = db.GetDataAdapter(queryMillas).Tables[0];

                string queryCompras = "SELECT C.Canje_Fecha Fecha, P.Prod_Nombre Producto, C.Canje_Cantidad_Prod Cantidad, C.Canje_Total Total ";
                queryCompras = queryCompras + " FROM TS.Canje as C, TS.Producto as P WHERE C.Cli_Cod = " + cliCod;
                queryCompras = queryCompras + " AND C.Prod_Cod = P.Prod_Cod AND DATEDIFF(DAY, C.Canje_Fecha, '"+ hoy +"') <= 365";
                queryCompras = queryCompras + " ORDER BY C.Canje_Fecha DESC";
                comprasGridView.DataSource = db.GetDataAdapter(queryCompras).Tables[0];

                SqlCommand storeProcedure = db.GetStoreProcedure("TS.fnConsultarSaldoMillas");
                SqlParameter returnParameter = storeProcedure.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                storeProcedure.Parameters.Add(new SqlParameter("@Hoy", hoy));
                storeProcedure.Parameters.Add(new SqlParameter("@Cli_Cod", cliCod));
                storeProcedure.ExecuteNonQuery();
                db.CerrarConexion();

                saldoLabel.Text = "Su saldo es de: " + (int)returnParameter.Value;
        }
    }
}
