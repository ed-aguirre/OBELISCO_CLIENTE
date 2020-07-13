using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReproductosCliente
{
    public partial class FormConfig : Form
    {
        
        Dictionary<string, string> mapa = new Dictionary<string, string>();
        Logica logica = Logica.getInstancia();
        public FormConfig()
        {
            InitializeComponent();
        }

        public Boolean validarCampos()
        {
            string alert = "Es necesario llenar todos los campos.";
            if(inputServidor.Text.Length <= 0)
            {
                new MyMessageBox().Show(alert);
                return false;
            }
            if (inputPuertoMysql.Text.Length <= 0)
            {
                new MyMessageBox().Show(alert);
                return false;
            }
            if (inputUsuario.Text.Length <= 0)
            {
                new MyMessageBox().Show(alert);
                return false;
            }
            if (inputContrasena.Text.Length <= 0)
            {
                new MyMessageBox().Show(alert);
                return false;
            }
            if (inputNombreBD.Text.Length <= 0)
            {
                new MyMessageBox().Show(alert);
                return false;
            }
            if (inputPuertoSocket.Text.Length <= 0)
            {
                new MyMessageBox().Show(alert);
                return false;
            }
            return true;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if( validarCampos())
            {
                mapa.Add("servidor",     inputServidor.Text);
                mapa.Add("puertoMysql",  inputPuertoMysql.Text);
                mapa.Add("usuario",      inputUsuario.Text);
                mapa.Add("contra",       inputContrasena.Text);
                mapa.Add("nombreBD",     inputNombreBD.Text);
                mapa.Add("puertoSocket", inputPuertoSocket.Text);

                logica.setHeader(mapa);

                this.Close();
            }
        }

        public Dictionary<string, string> getMapa()
        {
            return mapa;
        }

        private void FormConfig_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
