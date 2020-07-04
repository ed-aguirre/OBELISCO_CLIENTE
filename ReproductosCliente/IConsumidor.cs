using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductosCliente
{
    interface IConsumidor
    {
        void setNombre(string nombre);
        string getNombre();

        void setApellidoMaterno(string apMaterno);
        string getApellidoMaterno();

        void setApellidoPaterno(string apPaterno);
        string getApellidoPaterno();

        void setIdUsuario(string matricula);
        string getIdUsuario();

        void setClaveAcceso(string claveAcceso);
        string getClaveAcceso();

        void setTipoUsuario();
        void setTipoUsuario(int tipoUser);
        int getTipoUsuario();

        void setPrgmaEducativo(int idPrograma);
        int getPrgmaEducativo();

        void setSaldo();
        void setSaldo(float saldo);
        float getSaldo();

        void setEstadoUsuario();
        void setEstadoUsuario(int estadoUser);
        int getEstadoUsuario();

        void setFechaExpiracion(string fecha);
        string getFechaExpiracion();

        string getString();
    }
}
