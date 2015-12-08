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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class ListadoAeronave : Form
    {
        DbComunicator db;

        public ListadoAeronave()
        {
            InitializeComponent();
            this.db = new DbComunicator();
        }

        private void ListadoAeronave_Load(object sender, EventArgs e)
        {
            string QueryAeronave = "SELECT Aero_Num Numero, Aero_Modelo Modelo, Aero_Matricula Matricula, Aero_Fabricante Fabricante, Aero_Servicio Servicio, Aero_Cantidad_Kg_Disponibles 'KG Disponible', TS.fnButacasAeronave(Aero_Num, 'Ventanilla') 'Butacas Ventanilla', TS.fnButacasAeronave(Aero_Num, 'Pasillo') 'Butacas Pasillo', Aero_Borrado Borrada FROM [GD2C2015].[TS].[Aeronave]";
            string QueryServicio = "SELECT TipoSer_Nombre Nombre FROM [GD2C2015].[TS].[Tipo_Servicio]";
            DGV_aeronave.DataSource = db.GetDataAdapter(QueryAeronave).Tables[0];
            Dictionary<object, object> Servicios = this.db.GetQueryDictionary(QueryServicio, "Nombre", "Nombre");
            CB_servicio.DataSource = new BindingSource(Servicios, null);
            CB_servicio.DisplayMember = "Value";
            CB_servicio.ValueMember = "Key";
            DGV_aeronave.CellClick += this.ActivarAcciones;
            DGV_aeronave.RowHeaderMouseClick += this.ActivarAcciones;
        }

        private void ActivarAcciones(object sender, EventArgs e)
        {
            if (!DGV_aeronave.SelectedRows[0].Cells["Matricula"].Value.ToString().Equals(""))
            {
                this.BT_eliminar.Enabled = true;
                this.BT_modificar.Enabled = true;
                this.BT_fuera_servicio.Enabled = true;
                this.BT_baja_serivicio.Enabled = true;
                DGV_aeronave.SelectionChanged += this.DesactivarAcciones;
            }
            else this.DesactivarAcciones(sender, e);
        }

        private void DesactivarAcciones(object sender, EventArgs e)
        {
            this.BT_eliminar.Enabled = false;
            this.BT_modificar.Enabled = false;
            this.BT_fuera_servicio.Enabled = false;
            this.BT_baja_serivicio.Enabled = false;
            DGV_aeronave.SelectionChanged -= this.DesactivarAcciones;
        }

        private void BT_buscar_Click(object sender, EventArgs e)
        {
            string QueryBusqueda = "SELECT Aero_Num Numero, Aero_Modelo Modelo, Aero_Matricula Matricula, Aero_Fabricante Fabricante, Aero_Servicio Servicio, Aero_Cantidad_Kg_Disponibles 'KG Disponible', TS.fnButacasAeronave(Aero_Num, 'Ventanilla') 'Butacas Ventanilla', TS.fnButacasAeronave(Aero_Num, 'Pasillo') 'Butacas Pasillo', Aero_Borrado Borrada FROM [GD2C2015].[TS].[Aeronave] WHERE Aero_Servicio='" + CB_servicio.SelectedValue +"'";
            DGV_aeronave.DataSource = db.GetDataAdapter(QueryBusqueda).Tables[0];
        }

        private void BT_agregar_Click(object sender, EventArgs e)
        {
            AltaAeronave re = new AltaAeronave();
            re.FormClosed += new FormClosedEventHandler(ListadoAeronave_Load);
            re.Show();
        }

        private void BT_modificar_Click(object sender, EventArgs e)
        {
            ModificacionAeronave re = new ModificacionAeronave(DGV_aeronave.SelectedRows[0]);
            re.FormClosed += new FormClosedEventHandler(ListadoAeronave_Load);
            re.Show();
        }

        private void RemplazarEnViaje(string aeronum, string fecha, string viaje)
        {
            DbComunicator db2 = new DbComunicator();
            db2.EjecutarQuery("SELECT TS.fnAeronavesParaRemplazarAEn(" + aeronum + "," + viaje + ") as Cantidad");
            db2.getLector().Read();
            if (Convert.ToInt16(db.getLector()["Cantidad"].ToString()) > 0)
            {
                DbComunicator db3 = new DbComunicator();
                db3.EjecutarQuery("SELECT TOP 1 A2.Aero_Num as AeroFutura FROM TS.Aeronave AS A, TS.Aeronave AS A2 WHERE A.Aero_Num=@Aero AND A.Aero_Num!=A2.Aero_Num AND A2.Aero_Fabricante=A.Aero_Fabricante AND A.Aero_Servicio=A2.Aero_Servicio AND A.Aero_Modelo=A2.Aero_Modelo");
                db3.getLector().Read();
                string aerofutura = db.getLector()["AeroFutura"].ToString();
                SqlCommand spRemplazarAeroEn = this.db.GetStoreProcedure("TS.spRemplazarAeroEn");
                spRemplazarAeroEn.Parameters.Add(new SqlParameter("@Aero", aeronum));
                spRemplazarAeroEn.Parameters.Add(new SqlParameter("@HOY", Convert.ToDateTime(fecha)));
                spRemplazarAeroEn.Parameters.Add(new SqlParameter("@Aero", aerofutura));
                spRemplazarAeroEn.ExecuteNonQuery();
                MessageBox.Show("Ya se remplazo la aeronave " + aeronum + " por la aeronave " + aerofutura + " en el viaje " + viaje);
            }
            else
            {
                MessageBox.Show("No existe aeronave que pueda remplazar la aeronave actual en el viaje: " + viaje);
                AgregarAeronaveRemplazo form = new AgregarAeronaveRemplazo(DGV_aeronave.SelectedRows[0]);
                form.Show();
                this.RemplazarEnViaje(aeronum, fecha, viaje);
            }
        }

        private void RemplazarEnViajes(string aeronum, string fecha) {
            db = new DbComunicator();
            db.EjecutarQuery("SELECT Viaj_Cod as Viaje FROM TS.Viaje WHERE Aero_Num=" + aeronum + " AND DATEDIFF(minute, convert(datetime, '" + fecha + "'), V.Fecha_Salida)>0");
            while (db.getLector().Read())
                this.RemplazarEnViaje(aeronum, fecha, db.getLector()["Viaje"].ToString());
            db.CerrarConexion();
        }

        private void RemplazoDeAeronave(string aeronum, string fecha)
        {
            DialogResult dialogResult = MessageBox.Show("Esta aeronave tiene viajes pendientes de realizar ¿quiere buscar un remplazo de la aeronave?", "Confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db = new DbComunicator();
                db.EjecutarQuery("SELECT TS.fnAeronavesParaRemplazarA(" + aeronum + ") as Cantidad");
                db.getLector().Read();
                if (Convert.ToInt16(db.getLector()["Cantidad"].ToString()) > 0) RemplazarEnViajes(aeronum, fecha);
                else
                {
                    MessageBox.Show("No existe aeronave que pueda remplazar la aeronave actual");
                    AgregarAeronaveRemplazo form = new AgregarAeronaveRemplazo(DGV_aeronave.SelectedRows[0]);
                    form.Show();
                    this.RemplazoDeAeronave(aeronum, fecha);
                }
            }
        }

        private void CambiosAeronave(object sender, EventArgs e)
        {
            DbComunicator db = new DbComunicator();
            string fecha = Convert.ToString(AerolineaFrba.Properties.Settings.Default.FechaSistema);
            string aeronum = DGV_aeronave.SelectedRows[0].Cells["Numero"].Value.ToString();
            db.EjecutarQuery("SELECT TS.fnViajesPendientes(" + aeronum + ",convert(datetime, '" + fecha + "')) as Cantidad");
            db.getLector().Read();
            if (Convert.ToInt16(db.getLector()["Cantidad"].ToString()) > 0) this.RemplazoDeAeronave(aeronum, fecha);
            else MessageBox.Show("Esta aeronave no tiene viajes en el futuro");
        }

        private void BT_eliminar_Click(object sender, EventArgs e)
        {
            this.CambiosAeronave(sender, e);
            DialogResult dialogResult = MessageBox.Show("¿Usted esta seguro de borrar esta aeronave?", "Confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand spBorrarAeronave = this.db.GetStoreProcedure("TS.spBorrarAeronave");
                spBorrarAeronave.Parameters.Add(new SqlParameter("@numero", Convert.ToInt64(DGV_aeronave.SelectedRows[0].Cells["Numero"].Value)));
                spBorrarAeronave.ExecuteNonQuery();
            }
            this.ListadoAeronave_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_baja_serivicio_Click(object sender, EventArgs e)
        {
            this.CambiosAeronave(sender, e);
            DialogResult dialogResult = MessageBox.Show("¿Usted esta seguro de dejar sin vida util a esta aeronave?", "Confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand spFinVidaUtilAeronave = this.db.GetStoreProcedure("TS.spFinVidaUtilAeronave");
                spFinVidaUtilAeronave.Parameters.Add(new SqlParameter("@numero", Convert.ToInt64(DGV_aeronave.SelectedRows[0].Cells["Numero"].Value)));
                spFinVidaUtilAeronave.Parameters.Add(new SqlParameter("@hoy", Convert.ToDateTime(AerolineaFrba.Properties.Settings.Default.FechaSistema)));
                spFinVidaUtilAeronave.ExecuteNonQuery();
            }
            this.ListadoAeronave_Load(sender, e);
        }

        private void BT_fuera_servicio_Click(object sender, EventArgs e)
        {
            FueraDeServicio form = new FueraDeServicio();
            form.ShowDialog();
            this.CambiosAeronaveDesdeHasta(form.desde, form.hasta);
            DialogResult dialogResult = MessageBox.Show("¿Usted esta seguro de dejar fuera de servicio a esta aeronave?", "Confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand spFueraDeServicioAeronave = this.db.GetStoreProcedure("TS.spFueraDeServicioAeronave");
                spFueraDeServicioAeronave.Parameters.Add(new SqlParameter("@numero", Convert.ToInt64(DGV_aeronave.SelectedRows[0].Cells["Numero"].Value)));
                spFueraDeServicioAeronave.Parameters.Add(new SqlParameter("@Desde", Convert.ToDateTime(form.desde)));
                spFueraDeServicioAeronave.Parameters.Add(new SqlParameter("@Hasta", Convert.ToDateTime(form.hasta)));
                spFueraDeServicioAeronave.ExecuteNonQuery();
            }
            this.ListadoAeronave_Load(sender, e);
        }

        private void RemplazarEnViajeDesdeHasta(string aeronum, string fecha1, string fecha2, string viaje)
        {
            DbComunicator db2 = new DbComunicator();
            db2.EjecutarQuery("SELECT TS.fnAeronavesParaRemplazarAEn(" + aeronum + "," + viaje + ") as Cantidad");
            db2.getLector().Read();
            if (Convert.ToInt16(db.getLector()["Cantidad"].ToString()) > 0)
            {
                DbComunicator db3 = new DbComunicator();
                db3.EjecutarQuery("SELECT TOP 1 A2.Aero_Num as AeroFutura FROM TS.Aeronave AS A, TS.Aeronave AS A2 WHERE A.Aero_Num=@Aero AND A.Aero_Num!=A2.Aero_Num AND A2.Aero_Fabricante=A.Aero_Fabricante AND A.Aero_Servicio=A2.Aero_Servicio AND A.Aero_Modelo=A2.Aero_Modelo");
                db3.getLector().Read();
                string aerofutura = db.getLector()["AeroFutura"].ToString();
                SqlCommand spRemplazarAeroEn = this.db.GetStoreProcedure("TS.spRemplazarAeroEnDesdeHasta");
                spRemplazarAeroEn.Parameters.Add(new SqlParameter("@Aero", aeronum));
                spRemplazarAeroEn.Parameters.Add(new SqlParameter("@Desde", Convert.ToDateTime(fecha1)));
                spRemplazarAeroEn.Parameters.Add(new SqlParameter("@Hasta", Convert.ToDateTime(fecha2)));
                spRemplazarAeroEn.Parameters.Add(new SqlParameter("@Aero", aerofutura));
                spRemplazarAeroEn.ExecuteNonQuery();
                MessageBox.Show("Ya se remplazo la aeronave " + aeronum + " por la aeronave " + aerofutura + " en el viaje " + viaje);
            }
            else
            {
                MessageBox.Show("No existe aeronave que pueda remplazar la aeronave actual en el viaje: " + viaje);
                AgregarAeronaveRemplazo form = new AgregarAeronaveRemplazo(DGV_aeronave.SelectedRows[0]);
                form.Show();
                this.RemplazarEnViajeDesdeHasta(aeronum, fecha1, fecha2, viaje);
            }
        }

        private void RemplazarEnViajesDesdeHasta(string aeronum, string fecha1, string fecha2)
        {
            db = new DbComunicator();
            db.EjecutarQuery("SELECT Viaj_Cod as Viaje FROM TS.Viaje WHERE Aero_Num=" + aeronum + " AND DATEDIFF(minute, convert(datetime, '" + fecha2 + "'), V.Fecha_Salida)>0 AND DATEDIFF(minute, convert(datetime, '" + fecha2 + "'), V.Fecha_Salida)>0");
            while (db.getLector().Read())
                this.RemplazarEnViajeDesdeHasta(aeronum, fecha1, fecha2, db.getLector()["Viaje"].ToString());
            db.CerrarConexion();
        }

        private void RemplazoDeAeronaveDesdeHasta(string aeronum, string fecha1, string fecha2)
        {
            DialogResult dialogResult = MessageBox.Show("Esta aeronave tiene viajes pendientes de realizar ¿quiere buscar un remplazo de la aeronave?", "Confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db = new DbComunicator();
                db.EjecutarQuery("SELECT TS.fnAeronavesParaRemplazarA(" + aeronum + ") as Cantidad");
                db.getLector().Read();
                if (Convert.ToInt16(db.getLector()["Cantidad"].ToString()) > 0) RemplazarEnViajesDesdeHasta(aeronum, fecha1, fecha2);
                else
                {
                    MessageBox.Show("No existe aeronave que pueda remplazar la aeronave actual");
                    AgregarAeronaveRemplazo form = new AgregarAeronaveRemplazo(DGV_aeronave.SelectedRows[0]);
                    form.Show();
                    this.RemplazoDeAeronaveDesdeHasta(aeronum, fecha1, fecha2);
                }
            }
        }

        private void CambiosAeronaveDesdeHasta(DateTime desde, DateTime hasta)
        {
            DbComunicator db = new DbComunicator();
            string fecha1 = Convert.ToString(desde);
            string fecha2 = Convert.ToString(hasta);
            string aeronum = DGV_aeronave.SelectedRows[0].Cells["Numero"].Value.ToString();
            db.EjecutarQuery("SELECT TS.fnViajesPendientesDesdeHasta(" + aeronum + ", convert(datetime, '" + fecha1 + "'),convert(datetime, '" + fecha2 + "')) as Cantidad");
            db.getLector().Read();
            if (Convert.ToInt16(db.getLector()["Cantidad"].ToString()) > 0) this.RemplazoDeAeronaveDesdeHasta(aeronum, fecha1, fecha2);
            else MessageBox.Show("Esta aeronave no tiene viajes en el futuro");
        }
    }
}
