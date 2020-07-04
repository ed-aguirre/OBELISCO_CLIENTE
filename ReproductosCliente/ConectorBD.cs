using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReproductosCliente
{
    class ConectorBD
    {
        string servidor = "localhost";
        string puerto = "3306";
        string usuario = "root";
        string pass = "";
        string bd = "ccomputo";
        

        const int ID_USUARIO_EXISTE = 1;
        const int ID_USUARIO_INEXISTENTE = 0;

        MySqlConnection conexionBD;

        public ConectorBD()
        {
            Console.WriteLine("Servicio de B A S E ");
        }
        public void Header()
        {
            string cadenaCon = "server=" + servidor + "; port=" + puerto + "; user=" + usuario
            + "; password=" + pass + "; database=" + bd + ";";

            conexionBD = new MySqlConnection(cadenaCon);
        }

        public Dictionary<string,string> getProgramas()
        {
            Header();
            Dictionary<string, string> programas = new Dictionary<string, string>();
            string sql = "SELECT* FROM programaeducativo";
            try
            {
                
                MySqlDataReader reader = null;
                MySqlCommand cmd = new MySqlCommand(sql, conexionBD);
                conexionBD.Open();

                reader = cmd.ExecuteReader();
                /*int respuesta = cmd.ExecuteNonQuery();
                if( respuesta > 0)
                {
                    //almenos un registro se debio de haber afectado
                }*/
                while (reader.HasRows)
                {
                    /*Console.WriteLine("\t{0}\t{1}", reader.GetName(0),
                        reader.GetName(1));*/

                    while (reader.Read())
                    {
                        programas.Add( reader.GetString(0),
                            reader.GetString(1));
                    }
                    reader.NextResult();
                    
                }

            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine(programas.Count);
            return programas;
            
        }

        public int existeMatricula(string matricula)
        {
            int respuesta = ID_USUARIO_INEXISTENTE;
            string sql = "SELECT * FROM usuario WHERE idUsuario = ";
            sql += string.Format("'{0}'", matricula);

            Header();
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;

                MySqlCommand cmd = new MySqlCommand(sql, conexionBD);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    respuesta = ID_USUARIO_EXISTE;
                }

            }catch(MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return respuesta;
        }

        public int registrarUsuario(Dictionary<string, Object> mapa)
        {
            if ( existeMatricula( (string)mapa["idUsuario"] ) == 1)
            {
                return ID_USUARIO_EXISTE;
            }

            string sql = "INSERT INTO usuario VALUES (";
            foreach(Object dato in mapa.Values)
            {
                if( Object.ReferenceEquals( dato.GetType(), this.bd.GetType()))
                {
                    sql += string.Format("'{0}', ", dato);
                }
                else
                {
                    sql += dato + ", ";
                }
            }
            sql = sql.Substring(0, sql.Length - 2);
            sql += ");";

            Console.WriteLine(sql);

            int respuesta = 0;
            Header();
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;

                MySqlCommand cmd = new MySqlCommand(sql, conexionBD);
                respuesta = cmd.ExecuteNonQuery();

                if( respuesta > 0) //todo salio bien
                {
                    return respuesta;
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return respuesta;
        }

        public void Conectar()
        {
            Header();
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;

                MySqlCommand cmd = new MySqlCommand("show tables", conexionBD); //se envia la consulta
                reader = cmd.ExecuteReader(); //se ejecuta la consulta y se guarda en la variable

                while( reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + "\n");//se le pone cero por que queremos el dato de la posicion cero

                }
            }
            catch( MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //MessageBox.Show(datos);
        }
    }
}
