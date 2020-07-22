using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ReproductosCliente
{
    class ConectorBD
    {
        private static ConectorBD mysql = null;
        string servidor = "";//localhost
        string puerto = "";//3306
        string usuario = "";//root
        string pass = "";//
        string bd = "";//ccomputo
        
        const byte ID_USUARIO_EXISTENTE = 1;
        const byte ID_USUARIO_INEXISTENTE = 0;

        const byte ID_EQUIPO_EXISTENTE = 1;
        const byte ID_EQUIPO_INEXISTENTE = 0;

        const byte UPDATE_EXITO = 1;
        const byte UPDATE_SIN_EXITO = 0;

        const byte REGISTRO_EXITO = 1;
        const byte REGISTRO_SIN_EXITO = 0;

        MySqlConnection conexionBD;

        private ConectorBD()
        {
            Console.WriteLine("Servicio de DB ");
        }

        public static ConectorBD getInstancia()
        {
            if(mysql == null)
            {
                mysql = new ConectorBD();
            }
            return mysql;
        }

        public void setHeader()
        {
            string[] header;
            string s;
            Dictionary<string, string> mapa = new Dictionary<string, string>();

            StreamReader sr = File.OpenText("config.txt");
            while( (s = sr.ReadLine()) != null)
            {
                header = s.Split(' ');
                mapa.Add(header[0], header[1]);
            }
            sr.Close();

            servidor = mapa["servidor"];
            puerto =   mapa["puertoMysql"];
            usuario =  mapa["usuario"];
            pass =     mapa["contra"];
            bd =       mapa["nombreBD"];
            //Falta el socket.setPuerto( mapa["servidor"],mapa["puertoSocket"] )
        }

        public void Header()
        {
            string cadenaCon = "server=" + servidor + "; port=" + puerto + "; uid=" + usuario
            + "; password=" + pass + "; database=" + bd + ";old guids=true;";

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
                conexionBD.Close();
            }
            catch(MySqlException ex)
            {
                new MyMessageBox().Show(ex.ToString());
            }
            return programas;
        }

        public int existeMatricula(string tabla, string matricula)
        {
            string columna = (tabla == "usuario") ? "idUsuario" : "descComputadora";
            int respuesta = ID_USUARIO_INEXISTENTE;
            string sql = string.Format("SELECT * FROM {0} WHERE {1} = '{2}' LIMIT 1",
                                tabla,columna,matricula);

            Header();
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;

                MySqlCommand cmd = new MySqlCommand(sql, conexionBD);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    respuesta = ID_USUARIO_EXISTENTE;
                }
                reader.Close();
                conexionBD.Close();
            }
            catch(MySqlException ex)
            {
                new MyMessageBox().Show(ex.ToString());
            }
            return respuesta;
        }

        public Dictionary<string, Object> login(string tabla, IConsumidor consumidor)
        {
            string txtAlerta;
            Dictionary<string, Object> mapa = new Dictionary<string, Object>();

            if (existeMatricula(tabla, consumidor.getIdUsuario()) == 1)
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
            string sql = string.Format("SELECT * FROM usuario WHERE idUsuario = '{0}' AND claveAcceso = '{1}' LIMIT 1",
                consumidor.getIdUsuario(), consumidor.getClaveAcceso());

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
                conexionBD.Close();
            }
            catch (MySqlException ex)
            {
                new MyMessageBox().Show(ex.ToString());
            }
            return mapa;
        }

        public int registrarEquipo(string tabla, string nombreEquipo)
        {
            if (existeMatricula(tabla, nombreEquipo) == 1){
                return ID_EQUIPO_EXISTENTE;
            }

            string sql = string.Format(
                "INSERT INTO {0} (descComputadora) VALUES ('{1}')",
                tabla, nombreEquipo);
            int respuesta = 0;
            Header();
            try
            {
                conexionBD.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conexionBD);
                respuesta = cmd.ExecuteNonQuery();

                if(respuesta > 0)//salio bien todo
                {
                    return respuesta;
                }
                conexionBD.Close();
            }
            catch(MySqlException ex)
            {
                new MyMessageBox().Show(ex.ToString());
            }
            return respuesta;
        }

        public int registrarHistorial(string equipo,string matricula,string horaInicio)
        {
            string sql = string.Format("INSERT INTO detallecomputadora (idComputadora,idUsuario,horaInicio) " +
                "SELECT computadora.idComputadora, '{1}', '{2}' FROM computadora " +
                "WHERE computadora.descComputadora = '{0}'",equipo,matricula,horaInicio);
            Header();

            try
            {
                conexionBD.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conexionBD);

                if(cmd.ExecuteNonQuery() > 0)
                {
                    MySqlCommand cmd2 = new MySqlCommand("SELECT LAST_INSERT_ID()", conexionBD);
                    object idDetalle = cmd2.ExecuteScalar();

                    return Convert.ToInt32(idDetalle);
                }
                conexionBD.Close();
            }
            catch(MySqlException ex)
            {
                new MyMessageBox().Show(ex.ToString());
            }
            return REGISTRO_SIN_EXITO;
        }

        public int updateHistorial(int idDetalle, string horaFinal)
        {
            string sql = string.Format("UPDATE detallecomputadora SET horaFinal = '{1}' WHERE idDetalle = {0}",
                idDetalle, horaFinal);
            Header();

            try
            {
                conexionBD.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conexionBD);

                if(cmd.ExecuteNonQuery() > 0)
                {
                    return UPDATE_EXITO;
                }
                conexionBD.Close();
            }
            catch(MySqlException ex)
            {
                new MyMessageBox().Show(ex.ToString());
            }
            return UPDATE_SIN_EXITO;
        }

        public int registrarUsuario(string tabla,Dictionary<string, Object> mapa)
        {
            if ( existeMatricula( tabla,(string)mapa["idUsuario"] ) == 1)
            {
                return ID_USUARIO_EXISTENTE;
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

            //Console.WriteLine(sql);

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
                conexionBD.Close();
            }
            catch(MySqlException ex)
            {
                new MyMessageBox().Show(ex.ToString());
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
                conexionBD.Close();
            }
            catch(MySqlException ex)
            {
                new MyMessageBox().Show(ex.ToString());
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
                conexionBD.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return UPDATE_SIN_EXITO;
        }

        public bool Conectar()
        {
            setHeader();
            Header();
            bool respuesta = false;
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;

                MySqlCommand cmd = new MySqlCommand("show tables", conexionBD); //se envia la consulta
                reader = cmd.ExecuteReader(); //se ejecuta la consulta y se guarda en la variable

                if( reader.Read())
                {
                    Console.WriteLine("CONEXION A BD CORRECTA");
                    respuesta = true;
                }
                conexionBD.Close();
                return respuesta;
            }
            catch( MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return respuesta;
        }
    }
}
