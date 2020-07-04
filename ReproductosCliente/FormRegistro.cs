using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ReproductosCliente
{
    public partial class FormRegistro : Form
    {
        private IConsumidor consumidor = new Consumidor();
        private string programaEducativo = null;
        private string contra = "";
        string txtAlerta;
        string[] apellidos;

        private const int ID_EXISTENTE = 1;
        Dictionary<string, string> programas;

        public FormRegistro()
        {
            Console.WriteLine("REGISTRO");
            programas = new ConectorBD().getProgramas();
            
            InitializeComponent();
            comboPrograma.DataSource = programas.Values.ToArray();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (String key in programas.Keys)
            {
                if( string.Compare(programas[key],comboPrograma.Text) == 0)
                {
                    this.programaEducativo = key;
                    return;
                }
            }
        }

        public Boolean validarCampos()
        {
            
            apellidos = inputApellidos.Text.Split(' ');

            if ( inputNombre.Text.Length <= 0)
            {
                txtAlerta = "Ingresa tu nombre";
                new MyMessageBox().Show(txtAlerta);
                inputNombre.Focus();
                return false;
            }
            if( inputApellidos.Text.Length <= 0 || apellidos.Length < 2)
            {
                txtAlerta = "Ingresa tus dos apellidos separados por un espacio.";
                new MyMessageBox().Show(txtAlerta);
                inputApellidos.Focus();
                return false;
            }
            if( inputMatricula.Text.Length <= 0)
            {
                txtAlerta = "Ingresa tu matricula o N° Personal Academico";
                new MyMessageBox().Show(txtAlerta);
                inputMatricula.Focus();
                return false;
            }
            if( inputContra.Text.Length <= 0)
            {
                txtAlerta = "Ingresa una clave de acceso.";
                new MyMessageBox().Show(txtAlerta);
                inputContra.Focus();
                return false;
            }
            return true;
        }

        public void setCampos()
        {
            consumidor.setIdUsuario(inputMatricula.Text.ToUpper());
            consumidor.setClaveAcceso(inputContra.Text);
            consumidor.setApellidoMaterno(apellidos[1].ToUpper());
            consumidor.setApellidoPaterno(apellidos[0].ToUpper());
            consumidor.setNombre(inputNombre.Text.ToUpper());
            consumidor.setTipoUsuario();
            consumidor.setPrgmaEducativo(int.Parse(programaEducativo));
            consumidor.setSaldo();
            consumidor.setEstadoUsuario();
            consumidor.setFechaExpiracion(Consumidor.calcularFecha(inputMatricula.Text.ToUpper()));

            Console.WriteLine(consumidor.getString());
        }

        public int EnviarDatosUsuario()
        {
            int respuesta = new ConectorBD().existeMatricula(consumidor.getIdUsuario()));
            if ( respuesta == ID_EXISTENTE)
            {
                txtAlerta = "La matricula ingresada ya existe.";
                new MyMessageBox().Show(txtAlerta);
            }
            else
            {
                return new ConectorBD().registrarUsuario( Consumidor.toMap(consumidor) );
            }
            return 0;
        }
    }
}
