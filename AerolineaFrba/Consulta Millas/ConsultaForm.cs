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

namespace AerolineaFrba.Consulta_Millas
{
    public partial class ConsultaForm : Form
    {
        public ConsultaForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DbComunicator db = new DbComunicator();
            try
            {
                string hoy = Properties.Settings.Default.FechaSistema.ToString();
                
                string queryMillas = "SELECT M.Mil_Fecha Fecha, M.Mil_Cantidad Cantidad";
                queryMillas = queryMillas + "FROM TS.Milla as M, TS.Cliente as C WHERE Cli.Cli_DNI = " + dniTextBox.Text;
                queryMillas = queryMillas + " AND M.Cli_Cod = C.Cli_Cod";
                queryMillas = queryMillas + " ORDER BY Deposito_Fecha DESC";
                millasGridView.DataSource = db.GetDataAdapter(queryMillas).Tables[0];

                string queryCompras = "SELECT C.Canje_Fecha Fecha, P.Prod_Nombre Producto, C.Canje_Cantidad_Prod Cantidad, C.Canje_Total Total ";
                queryCompras = queryCompras + "FROM TS.Canje as C, TS.Cliente as Cli, TS.Producto as P WHERE Cli.Cli_DNI = " + dniTextBox.Text;
                queryCompras = queryCompras + " AND C.Cli_Cod = Cli.Cli_Cod AND C.Prod_Cod = P.Prod_Cod AND AND DATEDIFF(DAY, C.Canje_Fecha, "+ hoy +") <= 365";
                queryCompras = queryCompras + " ORDER BY C.Canje_Fecha DESC";
                comprasGridView.DataSource = db.GetDataAdapter(queryCompras).Tables[0];
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("La cuenta buscada no existe");
            }
        }
    }
}
