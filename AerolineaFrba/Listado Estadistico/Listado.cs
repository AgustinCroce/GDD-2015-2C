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
            string queryListado = "SELECT * FROM " + this.vwActual;
            this.DGVActual.DataSource = db.GetDataAdapter(queryListado).Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
