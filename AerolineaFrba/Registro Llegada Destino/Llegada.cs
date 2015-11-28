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

namespace AerolineaFrba.Registro_Llegada_Destino
{
    public partial class Llegada : Form
    {
        public Llegada()
        {
            InitializeComponent();
            string queryCiudades = "SELECT Ciudad_Nombre FROM TS.Ciudad";
            DbComunicator db = new DbComunicator();
            origenComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryCiudades, "Ciudad_Nombre", "Ciudad_Nombre"), null);
            origenComboBox.DisplayMember = "Key";
            origenComboBox.ValueMember = "Value";
            origenComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryCiudades, "Ciudad_Nombre", "Ciudad_Nombre"), null);
            origenComboBox.DisplayMember = "Key";
            origenComboBox.ValueMember = "Value";
            string queryAeronaves = "SELECT Aero_Num FROM TS.Aeronave";
            aeronaveComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryAeronaves, "Aero_Num", "Aero_Num"), null);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            DbComunicator dbStoreProcedure = new DbComunicator();
            SqlCommand storeConsulta = dbStoreProcedure.GetStoreProcedure("TS.spConsultarViaje");
            SqlParameter cantidadDeViajes = storeConsulta.Parameters.Add("RetVal", SqlDbType.Int);
            cantidadDeViajes.Direction = ParameterDirection.ReturnValue;
            storeConsulta.Parameters.Add(new SqlParameter("@CiudadOrigen", origenComboBox.SelectedValue));
            storeConsulta.Parameters.Add(new SqlParameter("@CiudadLlegada", llegadaComboBox.SelectedValue));
            storeConsulta.Parameters.Add(new SqlParameter("@AeroNum", aeronaveComboBox.SelectedValue));
            storeConsulta.ExecuteNonQuery();

            if ((int)cantidadDeViajes.Value == 1){
                SqlCommand storeProcedure = dbStoreProcedure.GetStoreProcedure("TS.spRegistrarLlegadaUnica");
                SqlParameter returnParameter = storeProcedure.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                storeProcedure.Parameters.Add(new SqlParameter("@CiudadOrigen", origenComboBox.SelectedValue));
                storeProcedure.Parameters.Add(new SqlParameter("@CiudadLlegada", llegadaComboBox.SelectedValue));
                storeProcedure.Parameters.Add(new SqlParameter("@AeroNum", aeronaveComboBox.SelectedValue));
                storeProcedure.Parameters.Add(new SqlParameter("@HorarioLlegada", llegadaTimePicker.Value));
                storeProcedure.ExecuteNonQuery();
                MessageBox.Show("Registro de llegada realizado");
                this.refreshValues();
            }

            if ((int)cantidadDeViajes.Value == 0)
            {
                MessageBox.Show("No hay ningun viaje que cumpla con los parametros especificados");
            }

            if ((int)cantidadDeViajes.Value > 1)
            {
                //Levantar nueva 
            }
        }

        private void refreshValues()
        {
            throw new NotImplementedException();
        }

    }
}
