using System;
using System.Collections.Generic;
using System.Linq;
/*using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;*/

namespace ReproductosCliente
{
    class SocketCliente
    {
        private static SocketCliente socket = null;
        private string puerto = "";
        private string servidor = "";
        private SocketCliente()
        {

        }

        public static SocketCliente getInstancia()
        {
            if(socket == null)
            {
                socket = new SocketCliente();
            }
            return socket;
        }

        public void setServidor(string servidor)
        {
            this.servidor = servidor;
        }

        public void setPuerto(string puerto)
        {
            this.puerto = puerto;
        }
    }
}
