using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductosCliente
{
    class Consumidor : IConsumidor
    {
        private string idUsuario;
        string claveAcceso;
        string apellidoMaterno;
        string apellidoPaterno;
        string nombres;
        int idTpoUsuario;
        int idProgramaEducativo;
        float saldo;
        int estadoUsuario;
        string fechaExp;

        private const int ID_CONSUMIDOR = 1;
        private const int ID_NO_VALIDADO = 1;
        public Consumidor() { }


        string IConsumidor.getApellidoMaterno()
        {
            return apellidoMaterno;
        }

        string IConsumidor.getApellidoPaterno()
        {
            return apellidoPaterno;
        }

        string IConsumidor.getClaveAcceso()
        {
            return claveAcceso;
        }

        int IConsumidor.getEstadoUsuario()
        {
            return estadoUsuario;
        }

        string IConsumidor.getFechaExpiracion()
        {
            return fechaExp;
        }

        string IConsumidor.getIdUsuario()
        {
            return idUsuario;
        }

        string IConsumidor.getNombre()
        {
            return nombres;
        }

        int IConsumidor.getPrgmaEducativo()
        {
            return idProgramaEducativo;
        }

        float IConsumidor.getSaldo()
        {
            return saldo;
        }

        string IConsumidor.getString()
        {
            return string.Format("Matricula: {0},Clave: {1}, Nombres: {2}, ApellidoPat: {3},ApellidoMat: {4}, TipoUser: {5}, ProgramaEduca: {6}, Saldo: {7}, EstadoUser: {8}, FechaExp: {9}",
                idUsuario, claveAcceso, nombres, apellidoPaterno, apellidoMaterno, idTpoUsuario, idProgramaEducativo, saldo, estadoUsuario , fechaExp);
        }

        int IConsumidor.getTipoUsuario()
        {
            return idTpoUsuario;
        }

        void IConsumidor.setApellidoMaterno(string apMaterno)
        {
            this.apellidoMaterno = apMaterno;
        }

        void IConsumidor.setApellidoPaterno(string apPaterno)
        {
            this.apellidoPaterno = apPaterno;
        }

        void IConsumidor.setClaveAcceso(string claveAcceso)
        {
            this.claveAcceso = claveAcceso;
        }

        void IConsumidor.setEstadoUsuario()
        {
            this.estadoUsuario = ID_NO_VALIDADO;
        }

        void IConsumidor.setFechaExpiracion(string fecha)
        {
            this.fechaExp = fecha;
        }

        void IConsumidor.setIdUsuario(string matricula)
        {
            this.idUsuario = matricula;
        }

        void IConsumidor.setNombre(string nombre)
        {
            this.nombres = nombre;
        }

        void IConsumidor.setPrgmaEducativo(int idPrograma)
        {
            this.idProgramaEducativo = idPrograma;
        }

        void IConsumidor.setSaldo()
        {
            this.saldo = 0;
        }

        void IConsumidor.setTipoUsuario()
        {
            this.idTpoUsuario = ID_CONSUMIDOR;
        }
        void IConsumidor.setTipoUsuario(int tipoUser)
        {
            this.idTpoUsuario = tipoUser;
        }

        void IConsumidor.setEstadoUsuario(int estadoUser)
        {
            this.estadoUsuario = estadoUser;
        }

        void IConsumidor.setSaldo(float saldo)
        {
            this.saldo = saldo;
        }

        public static string calcularFecha(string matricula)
        {
            if (matricula.StartsWith("S") || matricula.StartsWith("Z"))
            {
                char[] anio = matricula.ToCharArray();
                Array.Reverse(anio);
                string fin = new string(anio);

                fin = fin.Substring(6, 2);
                char[] anioFin = fin.ToCharArray();
                Array.Reverse(anioFin);
                string temp = new string(anioFin);

                int completo = (int.Parse("20" + temp)) + 6;
                return completo.ToString() + "-07-30";
            }
            else
            {
                return "0000-00-00";
            }
        }

        static string nombrarTipoUsuario(int idTipoUser)
        {
            string nombreTipoUsuario = "";
            switch (idTipoUser)
            {
                case 1:
                    nombreTipoUsuario = "CONSUMIDOR";
                    break;
                case 2:
                    nombreTipoUsuario = "MODERADOR";
                    break;
                case 3:
                    nombreTipoUsuario = "ADMINISTRADOR";
                    break;
            }
            return nombreTipoUsuario;
        }

        static string nombrarTipoEstado(int idEstadoUser)
        {
            string nombreEstadoUsuario = "";
            switch (idEstadoUser)
            {
                case 1:
                    nombreEstadoUsuario = "NO VALIDADO";
                    break;
                case 2:
                    nombreEstadoUsuario = "VALIDADO";
                    break;
                case 3:
                    nombreEstadoUsuario = "SUSPENDIDO";
                    break;
                case 4:
                    nombreEstadoUsuario = "FECHA EXPIRADA";
                    break;
            }
            return nombreEstadoUsuario;
        }

        public static IConsumidor FromMap( Dictionary<string, Object> mapa)
        {
            IConsumidor consumidor = new Consumidor();
            if (mapa.ContainsKey("idUsuario"))
                consumidor.setIdUsuario((string) mapa["idUsuario"]);
            if (mapa.ContainsKey("claveAcceso"))
                consumidor.setClaveAcceso((string)mapa["claveAcceso"]);
            if (mapa.ContainsKey("apellidoMaterno"))
                consumidor.setApellidoMaterno((string)mapa["apellidoMaterno"]);
            if (mapa.ContainsKey("apellidoPaterno"))
                consumidor.setApellidoPaterno((string)mapa["apellidoPaterno"]);
            if (mapa.ContainsKey("nombres"))
                consumidor.setNombre((string)mapa["nombres"]);
            if (mapa.ContainsKey("idTipoUsuario"))
                consumidor.setTipoUsuario((int)mapa["idTipoUsuario"]);
            if (mapa.ContainsKey("idProgramaEducativo"))
                consumidor.setPrgmaEducativo((int)mapa["idProgramaEducativo"]);
            if (mapa.ContainsKey("saldo"))
                consumidor.setSaldo((float)mapa["saldo"]);
            if (mapa.ContainsKey("estadoUsuario"))
                consumidor.setEstadoUsuario((int)mapa["estadoUsuario"]);
            if (mapa.ContainsKey("fechaExp"))
                consumidor.setFechaExpiracion((string)mapa["fechaExp"]);

            return consumidor;
        }

        public static Dictionary<string, Object> toMap(IConsumidor consumidor)
        {
            Dictionary<string, Object> mapa = new Dictionary<string, object>();
            if (consumidor.getIdUsuario() != null)
                mapa.Add("idUsuario", consumidor.getIdUsuario());
            if (consumidor.getClaveAcceso() != null)
                mapa.Add("claveAcceso", consumidor.getClaveAcceso());
            if (consumidor.getApellidoMaterno() != null)
                mapa.Add("apellidoMaterno", consumidor.getApellidoMaterno());
            if (consumidor.getApellidoPaterno() != null)
                mapa.Add("apellidoPaterno", consumidor.getApellidoPaterno());
            if (consumidor.getNombre() != null)
                mapa.Add("nombres", consumidor.getNombre());
            if (consumidor.getTipoUsuario() != 0)
                mapa.Add("idTipoUsuario", consumidor.getTipoUsuario());
            if (consumidor.getPrgmaEducativo() != 0)
                mapa.Add("idProgramaEducativo", consumidor.getPrgmaEducativo());
            if (consumidor.getSaldo() > -1)
                mapa.Add("saldo", consumidor.getSaldo());
            if (consumidor.getEstadoUsuario() != 0)
                mapa.Add("estadoUsuario", consumidor.getEstadoUsuario());
            if (consumidor.getFechaExpiracion() != null)
                mapa.Add("fechaExp", consumidor.getFechaExpiracion());

            return mapa;
        }

    }
}
