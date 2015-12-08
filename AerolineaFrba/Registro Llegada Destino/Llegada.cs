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
            string queryCiudades = "SELECT Ciudad_Nombre, Ciudad_Cod FROM TS.Ciudad";
            DbComunicator db = new DbComunicator();
            origenComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryCiudades, "Ciudad_Nombre", "Ciudad_Cod"), null);
            origenComboBox.DisplayMember = "Key";
            origenComboBox.ValueMember = "Value";
            origenComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            llegadaComboBox.DataSource = new BindingSource(db.GetQueryDictionary(queryCiudades, "Ciudad_Nombre", "Ciudad_Cod"), null);
            llegadaComboBox.DisplayMember = "Key";
            llegadaComboBox.ValueMember = "Value";
            llegadaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(matriculaTextBox.Text))
            {
                MessageBox.Show("Debe ingresarse una matricula para poder realizar el registro");
            }
            else
            {
                DbComunicator dbStoreProcedure = new DbComunicator();
                SqlCommand storeConsulta = dbStoreProcedure.GetStoreProcedure("TS.spConsultarViaje");
                SqlParameter cantidadDeViajes = storeConsulta.Parameters.Add("RetVal", SqlDbType.Int);
                DateTime dateSalida = salidaDatePicker.Value.Date + salidaTimePicker.Value.TimeOfDay;
                DateTime dateLlegada = llegadaDayPicker.Value.Date + llegadaTimePicker.Value.TimeOfDay;
                cantidadDeViajes.Direction = ParameterDirection.ReturnValue;
                storeConsulta.Parameters.Add(new SqlParameter("@Ciudad_Origen", origenComboBox.SelectedValue));
                storeConsulta.Parameters.Add(new SqlParameter("@Ciudad_Destino", llegadaComboBox.SelectedValue));
                storeConsulta.Parameters.Add(new SqlParameter("@Aero_Matricula", matriculaTextBox.Text));
                storeConsulta.Parameters.Add(new SqlParameter("@Fecha_Salida", dateSalida));
                storeConsulta.Parameters.Add(new SqlParameter("@Fecha_Llegada", dateLlegada));
                storeConsulta.ExecuteNonQuery();

                if ((int)cantidadDeViajes.Value == 1)
                {
                    SqlCommand storeProcedure = dbStoreProcedure.GetStoreProcedure("TS.spRegistrarLlegada");
                    SqlParameter returnParameter = storeProcedure.Parameters.Add("RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    storeProcedure.Parameters.Add(new SqlParameter("@Ciudad_Origen", origenComboBox.SelectedValue));
                    storeProcedure.Parameters.Add(new SqlParameter("@Ciudad_Destino", llegadaComboBox.SelectedValue));
                    storeProcedure.Parameters.Add(new SqlParameter("@Aero_Matricula", matriculaTextBox.Text));
                    storeProcedure.Parameters.Add(new SqlParameter("@Fecha_Salida", dateSalida));
                    storeProcedure.Parameters.Add(new SqlParameter("@Fecha_Llegada", dateLlegada));
                    storeProcedure.ExecuteNonQuery();
                    MessageBox.Show("Registro de llegada realizado");
                }

                if ((int)cantidadDeViajes.Value == 0)
                {
                    MessageBox.Show("No hay ningun viaje que cumpla con los parametros especificados");
                }

                if ((int)cantidadDeViajes.Value == -1)
                {
                    MessageBox.Show("La ciudad de llegada seleccionada no concuerda con la establecida para el viaje");
                }

                if ((int)cantidadDeViajes.Value == -2)
                {
                    MessageBox.Show("La fecha de llegada debe ser posterior a la de salida");
                }
            }


        }

    }
}
