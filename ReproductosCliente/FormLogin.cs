using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReproductosCliente
{
    public partial class FormLogin : Form
    {
        private string txtAlerta= "";
        private string tabla = "usuario";
        ConectorBD mysql = ConectorBD.getInstancia();
        
        public FormLogin()
        {
            InitializeComponent();
            Console.WriteLine("LOGIN INICIADO");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public Dictionary<string,Object> iniciarSesion()
        {
            IConsumidor cliente = new Consumidor();
            Dictionary<string, Object> dataUser;
            cliente.setIdUsuario(inputMatricula.Text.ToUpper()) ;
            cliente.setClaveAcceso(inputClaveAcceso.Text.ToUpper());

            dataUser = mysql.login(tabla, cliente);
            
            return dataUser;
        }

        public Boolean validarCampos()
        {
            if( inputMatricula.Text.Length <= 0)
            {
                txtAlerta = "Ingresa una Matricula o N° Personal.";
                new MyMessageBox().Show(txtAlerta);
                return false;
            }
            if (inputClaveAcceso.Text.Length <= 0)
            {
                txtAlerta = "Ingresa una Clave de Acceso";
                new MyMessageBox().Show(txtAlerta);
                return false;
            }
            return true;
        }

    }
}
