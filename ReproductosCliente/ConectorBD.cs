using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
        

        const byte ID_USUARIO_EXISTE = 1;
        const byte ID_USUARIO_INEXISTENTE = 0;
        const byte UPDATE_EXITO = 1;
        const byte UPDATE_SIN_EXITO = 0;

        MySqlConnection conexionBD;

        public ConectorBD()
        {
            Console.WriteLine("Servicio de DB ");
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
            string sql = "SELECT * FROM programaeducativo";
            try
            {   
                MySqlDataReader reader = null;
                MySqlCommand cmd = new MySqlCommand(sql, conexionBD);
                conexionBD.Open();

                reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        programas.Add( reader.GetString(0),
                            reader.GetString(1));
                    }
                    reader.NextResult();
                    
                }
                reader.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                reader.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return respuesta;
        }

        public Dictionary<string, Object> login(string matricula, string clave)
        {
            string txtAlerta;
            Dictionary<string, Object> mapa = new Dictionary<string, Object>();

            if (existeMatricula(matricula) == 1)
            {
                txtAlerta = "La matricula no coincide con la contraseña";
            }
            else
            {
                txtAlerta = "No se encontró ningun usuario con esa matricula.";
                new MyMessageBox().Show(txtAlerta);
                return mapa;
            }

            Header();
            string sql = string.Format("SELECT * FROM usuario WHERE idUsuario = '{0}' AND claveAcceso = '{1}'", matricula, clave);

            try
            {
                MySqlDataReader reader = null;
                MySqlCommand cmd = new MySqlCommand(sql, conexionBD);
                conexionBD.Open();

                reader = cmd.ExecuteReader(); 
                if( reader.HasRows)
                {
                    reader.Read();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        mapa.Add(reader.GetName(i), reader.GetValue(i));
                    }
                }
                else
                {
                    new MyMessageBox().Show(txtAlerta);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return mapa;
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

        public int updateEstadoUsuario(string matricula)
        {
            int respuesta = 0;
            string sql = string.Format(
                "UPDATE usuario SET estadoUsuario = 4 WHERE idUsuario = '{0}'",
                matricula);
            
            Header();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conexionBD);
                conexionBD.Open();

                respuesta = cmd.ExecuteNonQuery();
                if( respuesta > 0)
                {
                    return respuesta;
                }

            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return respuesta;
        }

        public int updateSaldo(float saldo,string matricula)
        {
            string sql = string.Format("UPDATE usuario SET saldo = {0} WHERE idUsuario = '{1}'",
                saldo, matricula);
            int respuesta = 0;

            Header();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conexionBD);
                conexionBD.Open();

                respuesta = cmd.ExecuteNonQuery();
                if(respuesta > 0)
                {
                    return UPDATE_EXITO;
                }
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return UPDATE_SIN_EXITO;
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
