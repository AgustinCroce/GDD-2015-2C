using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;

namespace AerolineaFrba.Commons{

    public class DbComunicator{
        private SqlConnection ConexionConBD;
        private SqlCommand Consulta;
        private SqlDataReader Lector;

        public SqlDataReader getLector(){
            return this.Lector;
        }

        public void EjecutarQuery(string query){
            this.ConectarConDB();
            this.ObtenerQuery(query);
        }

        public void ObtenerQuery(string query){
            this.ConectarConDB();
            Consulta = new SqlCommand(query, this.ConexionConBD);
            this.Lector = Consulta.ExecuteReader();
        }

        public Dictionary<object, object> GetQueryDictionary(string query, string keyName, string valueName)
        {
            Dictionary<object, object> queryDictionary = new Dictionary<object, object>();

            this.EjecutarQuery(query);

            while (this.getLector().Read()){
                queryDictionary.Add(this.getLector()[keyName], this.getLector()[valueName]);
            }
            if (queryDictionary.Values.Count == 0){
                queryDictionary.Add(-1 , "No hay elementos para listar");
            }
            return queryDictionary;
        }

        public DataSet GetDataAdapter(string query)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, this.GetConectionString());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        private string GetConectionString() {
            string strConexión = "Data Source=" + AerolineaFrba.Properties.Settings.Default.DbSource +
                    ";Initial Catalog=" + AerolineaFrba.Properties.Settings.Default.DbName +
                    ";Integrated Security=True" +
                    ";User ID=" + AerolineaFrba.Properties.Settings.Default.DbUser +
                    ";Password=" + AerolineaFrba.Properties.Settings.Default.DbPassword;
            return strConexión;
        }

        public void ConectarConDB(){
            // Crear la conexión con la base de datos
            this.ConexionConBD = new SqlConnection(this.GetConectionString());

            // Abrir la base de datos
            this.ConexionConBD.Open();
        }

        public void CargarAutocomplete(AutoCompleteStringCollection col, string query, string name) {
            this.EjecutarQuery(query);
            while (this.getLector().Read())
            {
                col.Add(this.getLector()[name].ToString());
            }        
        }

        public void CerrarConexion(){
            // Cerrar la conexión cuando ya no sea necesaria
            if (Lector != null)
                Lector.Close();
            if (ConexionConBD != null)
                ConexionConBD.Close();
        }

        public void ExecuteTransaction(string nombre, List<string> querys){
            this.ConectarConDB();
            SqlCommand command = this.ConexionConBD.CreateCommand();
            SqlTransaction transaction;
            transaction = this.ConexionConBD.BeginTransaction(nombre);
            command.Connection = this.ConexionConBD;
            command.Transaction = transaction;
            try{
                foreach (string query in querys){
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception ex){
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                Console.WriteLine(" Message: {0}", ex.Message);
                try{
                    transaction.Rollback();
                } catch (Exception ex2){
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    Console.WriteLine(" Message: {0}", ex2.Message);
                }
            }
            this.CerrarConexion();
        }

        public SqlCommand GetStoreProcedure(string nameStoreProcedure)
        {
            this.ConectarConDB();
            SqlCommand storeProcedure = new SqlCommand(nameStoreProcedure, this.ConexionConBD);
            storeProcedure.CommandType = CommandType.StoredProcedure;
            return storeProcedure;
        }

        // Ejemplo de uso
        public static void MainEjemplo(){
            DbComunicator db = new DbComunicator();
            try {
                db.EjecutarQuery("SELECT Nombre FROM CLIENT");
            }
            catch (Exception e){
                Console.WriteLine("Error: " + e.Message);
            }
            finally {
                Console.WriteLine("Los nombres de los clientes son: ");
                while (db.Lector.Read()){
                    Console.WriteLine(" - " + db.Lector["Nombre"]);
                };
                db.CerrarConexion();
            }
        }


        public SqlCommand GetInsert(string insert){
            this.ConectarConDB();
            SqlCommand cmd = new SqlCommand(insert, this.ConexionConBD);
            return cmd;
        }
    }

}
