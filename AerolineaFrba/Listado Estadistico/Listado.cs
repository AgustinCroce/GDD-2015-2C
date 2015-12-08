using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AerolineaFrba.Commons;

namespace AerolineaFrba.Listado_Estadistico
{
    public partial class Listado : Form
    {
        string listadoActual, vwActual;
        DataGridView DGVActual;
        DbComunicator db;

        public Listado()
        {
            InitializeComponent();
            this.db = new DbComunicator();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            this.changeTag(sender, e);
            CB_semestre.SelectedText = "1";
            CB_anio.Text = "2015";
            TC_listado.SelectedIndexChanged += this.changeTag;
        }

        private void changeTag(object sender, EventArgs e)
        {
            this.listadoActual = TC_listado.SelectedTab.Text;
            if (this.listadoActual == "Destinos vas vendidos"){
                this.vwActual = "TS.vsDestinoConMasPasajesComprados";
                this.DGVActual = DGV_1;
            } else if (this.listadoActual == "Destinos con aeronaves mas vacías"){
                this.vwActual = "TS.vsDestinoAernovesMasVacias";
                this.DGVActual = DGV_2;
            } else if (this.listadoActual == "Clientes con mas millas"){
                this.vwActual = "TS.vsClientesConMasMillas";
                this.DGVActual = DGV_3;
            } else if (this.listadoActual == "Destinos mas cancelados"){
                this.vwActual = "TS.vsDestinosConMasPasajesCancelados";
                this.DGVActual = DGV_4;
            } else if (this.listadoActual == "Aeronaces mas fuera de servicio"){
                this.vwActual = "TS.vsAeronaveMasFueraDeServicio";
                this.DGVActual = DGV_5;
            }
            this.loadDGV();
        }

        private void loadDGV(){
            this.ejectutarQuerySemetral();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ejectutarQuerySemetral()
        {
            string queryListado = null;
            if (CB_semestre.Text == "1")
                queryListado = "SELECT TOP 5 V.Nombre, SUM(V.Cantidad) AS Cantidad FROM " + this.vwActual + " AS V WHERE V.Anio="+ CB_anio.Text +" AND V.Mes IN (1,2,3,4,5,6) GROUP BY V.Nombre ORDER BY Cantidad DESC";
            if (CB_semestre.Text == "2")
                queryListado = "SELECT TOP 5 V.Nombre, SUM(V.Cantidad) AS Cantidad FROM " + this.vwActual + " AS V WHERE V.Anio=" + CB_anio.Text + " AND V.Mes IN (7,8,9,10,11,12) GROUP BY V.Nombre ORDER BY Cantidad DESC";
            if (queryListado != null) this.DGVActual.DataSource = db.GetDataAdapter(queryListado).Tables[0];
        }


        private void BT_actualizar_Click(object sender, EventArgs e)
        {
            this.ejectutarQuerySemetral();
        }
    }
}
