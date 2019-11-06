using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Conexion
{
    class ConexionYOper : IConexion
    {
        public string conec;
        public ConexionYOper(string dataSource, string nombreBase) {

            StringBuilder conec = new StringBuilder();
            conec.Append($"Data Source=[{dataSource}]; Initial Catalog =[{nombreBase}]; Integrated Security = True");

            this.conec = conec.ToString();
        }



        private SqlConnection InciarConexion() {

            bool todoOk = true;
            SqlConnection conexion = null;

            try
            {               
                conexion = new SqlConnection(this.conec);
            }
            catch(Exception) {
                todoOk = false; 
            }

            return conexion;
        }


        public bool Conexion() {

            bool todoOk = true;

            try
            {
                this.InciarConexion();
            }
            catch (Exception)
            {
                todoOk = false;
            }

            return todoOk;
        }

        public string Consulta(string consulta) {

            string aux="";

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;

                comando.Connection = this.InciarConexion();

                comando.CommandText = consulta;
                SqlConnection connection = this.InciarConexion();
                connection.Open();

                SqlDataReader oDr = comando.ExecuteReader();

                while (oDr.Read())
                {
                    aux = oDr.ToString();
                }
            }
            catch (Exception) {

                aux = "ALGO FALLO EN LA CONSULTA";
            }


            return aux;

        }

        public bool Operacion(string consulta) {

            String oper = consulta;
            bool todoOk = true;
            

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;

                comando.Connection = this.InciarConexion();

                SqlConnection connection = this.InciarConexion();
                comando.ExecuteNonQuery();
            }
            catch {

                todoOk = false;
            
            }

            return todoOk;
        }



    }
}
