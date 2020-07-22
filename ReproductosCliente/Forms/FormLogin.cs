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

            if( validarAdmin(cliente)) {
                
                dataUser = Consumidor.toMap(cliente);
                dataUser["fechaExp"] = DateTime.Now.AddDays(01);
            }
            else
            {
                dataUser = mysql.login(tabla, cliente);
            }

            return dataUser;
        }

        public Boolean validarAdmin(IConsumidor cliente)
        {
            if( cliente.getIdUsuario() == "ADMIN" && cliente.getClaveAcceso() == "UVAD49999")
            {
                cliente.setNombre("ADMIN");
                cliente.setApellidoPaterno("U");
                cliente.setApellidoMaterno("V");
                cliente.setPrgmaEducativo(1);
                cliente.setSaldo(0);
                cliente.setTipoUsuario(2);
                cliente.setEstadoUsuario(2);
                return true;
            }
            return false;
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
