﻿using System;
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

namespace AerolineaFrba.Generacion_Viaje
{
    public partial class GenerarViaje : Form
    {
        DbComunicator db;
        EnabledButtons enabledButtons;

        public GenerarViaje()
        {
            InitializeComponent();
            this.db = new DbComunicator();
            this.enabledButtons = new EnabledButtons();
        }

        private void GenerarViaje_Load(object sender, EventArgs e)
        {
            string QueryRutas = "SELECT [Ruta_Cod] Codigo, CAST([Ruta_Codigo] AS NVARCHAR(255)) + ' - Desde: ' + C1.Ciudad_Nombre + ' hasta ' + C2.Ciudad_Nombre Nombre FROM [GD2C2015].[TS].[Ruta] AS R, [GD2C2015].[TS].[Ciudad] AS C1, [GD2C2015].[TS].[Ciudad] AS C2 WHERE C1.Ciudad_Cod = R.Ruta_Ciudad_Origen AND C2.Ciudad_Cod = R.Ruta_Ciudad_Destino AND R.Ruta_Borrada = 0";
            Dictionary<object, object> Rutas = this.db.GetQueryDictionary(QueryRutas, "Codigo", "Nombre");
            CB_ruta.DataSource = new BindingSource(Rutas, null);
            CB_ruta.DisplayMember = "Value";
            CB_ruta.ValueMember = "Key";
            CB_ruta.SelectedValueChanged += this.onChangeRuta;
            DateTime Hoy = Convert.ToDateTime(AerolineaFrba.Properties.Settings.Default.FechaSistema);
            DTP_fecha_estimada_llegada.MinDate = Hoy;
            DTP_fecha_salida.MinDate = Hoy;
        }

        private void onChangeRuta(object sender, EventArgs e)
        {
            string QueryServicios = "SELECT Tipo_Servicio Nombre FROM [GD2C2015].[TS].[Ruta_Servicio] WHERE Ruta_Cod = " + CB_ruta.SelectedValue;
            Dictionary<object, object> Servicios = this.db.GetQueryDictionary(QueryServicios, "Nombre", "Nombre");
            CB_servicio.DataSource = new BindingSource(Servicios, null);
            CB_servicio.DisplayMember = "Value";
            CB_servicio.ValueMember = "Key";
            CB_servicio.SelectedValueChanged += this.onChangeServicio;
            CB_servicio.Enabled = true;
        }

        private void onChangeServicio(object sender, EventArgs e)
        {
            string QueryAeronaves = "SELECT A.Aero_Num Codigo, A.Aero_Matricula  + ' (Modelo: ' + A.Aero_Modelo + ' fabricante: ' + A.Aero_Fabricante + ')' Nombre FROM [GD2C2015].[TS].[Ruta] AS R, [GD2C2015].[TS].[Aeronave] as A WHERE R.Ruta_Cod = " + CB_ruta.SelectedValue + " AND A.Aero_Servicio='" + CB_servicio.SelectedValue + "' AND A.Aero_Borrado = 0";
            Dictionary<object, object> Aeronaves = this.db.GetQueryDictionary(QueryAeronaves, "Codigo", "Nombre");
            CB_aeronave.DataSource = new BindingSource(Aeronaves, null);
            CB_aeronave.DisplayMember = "Value";
            CB_aeronave.ValueMember = "Key";
            CB_aeronave.Enabled = true;
            BT_guardar.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime salida = DTP_fecha_salida.Value;
            DateTime llegada = DTP_fecha_estimada_llegada.Value;
            TimeSpan ts = llegada - salida;
            int differenceInDays = ts.Days;
            if (Convert.ToInt64(CB_aeronave.SelectedValue) == -1){
                MessageBox.Show("Para generar un viaje tiene que seleccionar una aeronave, de no tener aeronaves en la lista agregue el servicio deseado a la ruta solicitada");
                return;
            }

            if (differenceInDays >= 0 && differenceInDays <= 1){
                DateTime dateSalida = DTP_fecha_salida.Value.Date + DTP_hora_salida.Value.TimeOfDay;
                DateTime dateLlegada = DTP_hora_estimada_llegada.Value.Date + DTP_hora_estimada_llegada.Value.TimeOfDay;
                SqlCommand spALtaViaje = this.db.GetStoreProcedure("TS.spAltaViaje");
                spALtaViaje.Parameters.Add(new SqlParameter("@Fecha_salida", dateSalida));
                spALtaViaje.Parameters.Add(new SqlParameter("@Fecha_estimada", dateLlegada));
                spALtaViaje.Parameters.Add(new SqlParameter("@Aero", Convert.ToInt64(CB_aeronave.SelectedValue)));
                spALtaViaje.Parameters.Add(new SqlParameter("@Ruta", Convert.ToInt64(CB_ruta.SelectedValue)));
                SqlParameter returnParameter = spALtaViaje.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                spALtaViaje.ExecuteNonQuery();
                if ((int)returnParameter.Value == -1) MessageBox.Show("La aeronave ya tiene un viaje para ese dia, por favor seleccione otra");
                else MessageBox.Show("Ya esta guardado el nuevo Viaje");
            }
            else MessageBox.Show("La diferencia entre la salida y la llegada tiene que ser de menor aun dia");
        }
        
    }
}
