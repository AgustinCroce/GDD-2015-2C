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
    public partial class SeleccionVueloForm : Form
    {
        public SeleccionVueloForm()
        {
            InitializeComponent();
            string queryCiudades = "SELECT Ciudad_Nombre FROM TS.Ciudad";
            DbComunicator db = new DbComunicator();
            origenComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryCiudades, "Ciudad_Nombre", "Ciudad_Nombre"), null);
            origenComboBox.DisplayMember = "Key";
            origenComboBox.ValueMember = "Value";
            destinoComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryCiudades, "Ciudad_Nombre", "Ciudad_Nombre"), null);
            destinoComboBox.DisplayMember = "Key";
            destinoComboBox.ValueMember = "Value";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DbComunicator db = new DbComunicator();
            string queryVuelos = "SELECT Viaj_Cod, Fecha_Salida, R.Ruta_Ciudad_Origen, R.Ruta_Ciudad_Destino ,Fecha_Llegada_Estimada, Ruta_Servicio ";
            queryVuelos += "FROM TS.Ruta as R, Ts.Viaje as V ";
            queryVuelos += "WHERE R.Ruta_Cod = V.Ruta_Cod AND R.Ruta_Ciudad_Origen = '" + origenComboBox.SelectedValue.ToString() +"' AND R.Ruta_Ciudad_Destino = '"+ destinoComboBox.SelectedValue.ToString() +"' AND Fecha_Salida ='"+ despegueTimePicker.Value.ToShortDateString() +"'";
            vuelosGridView.DataSource = db.GetDataAdapter(queryVuelos).Tables[0];
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {
            this.vuelosGridView.DataSource = null;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            SeleccionCantidadesForm sc = new SeleccionCantidadesForm(vuelosGridView.SelectedRows[0]);
            sc.FormClosed += new FormClosedEventHandler(selectItems);
            sc.Show();

        }

        private void selectItems(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

       
    }
}
