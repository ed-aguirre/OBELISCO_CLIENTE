using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ReproductosCliente
{
    public partial class FormRegistro : Form
    {
        private IConsumidor consumidor = new Consumidor();
        private Regex regex = new Regex("^(ZS+[0-9]{8}$|^[0-9]{5,7}$)");
        Dictionary<string, string> programas;
        
        private string programaEducativo;
        private string txtAlerta;
        private const int ID_EXISTENTE = 1;
        
        public FormRegistro()
        {
            Console.WriteLine("REGISTRO");
            InitializeComponent();
        }

        public FormRegistro(Dictionary<string, string> programas)
        {
            this.programas = programas;

            InitializeComponent();
            comboPrograma.DataSource = programas.Values.ToArray();
            inputApellidoPaterno.Text = "Apellido Paterno";
            inputApellidoMaterno.Text = "Apellido Materno";
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
            if ( inputNombre.Text.Length <= 0)
            {
                txtAlerta = "Ingresa tu nombre";
                new MyMessageBox().Show(txtAlerta);
                inputNombre.Focus();
                return false;
            }
            if( inputApellidoPaterno.Text.Length <= 0 || inputApellidoPaterno.Text == "Apellido Paterno")
            {
                txtAlerta = "Ingresa tu apellido paterno.";
                new MyMessageBox().Show(txtAlerta);
                inputApellidoPaterno.Focus();
                return false;
            }
            if (inputApellidoMaterno.Text.Length <= 0 || inputApellidoMaterno.Text == "Apellido Materno")
            {
                txtAlerta = "Ingresa tu apellido materno.";
                new MyMessageBox().Show(txtAlerta);
                inputApellidoMaterno.Focus();
                return false;
            }
            if( !regex.IsMatch(inputMatricula.Text.ToUpper()))
            {
                txtAlerta = "Ingresa tu matricula o N° Personal Academico\n" +
                    "Matricula Estudiante: Incluir la Z al principio.\n" +
                    "N° Personal: Debe poseer entre 5 y 7 caracteres. ";
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
            consumidor.setApellidoMaterno(inputApellidoMaterno.Text.ToUpper());
            consumidor.setApellidoPaterno(inputApellidoPaterno.Text.ToUpper());
            consumidor.setNombre(inputNombre.Text.ToUpper());
            consumidor.setTipoUsuario();
            consumidor.setPrgmaEducativo(int.Parse(programaEducativo));
            consumidor.setSaldo();
            consumidor.setEstadoUsuario();
            DateTime date = Convert.ToDateTime(Consumidor.calcularFecha(inputMatricula.Text.ToUpper()));
            consumidor.setFechaExpiracion( date );

            //Console.WriteLine(consumidor.getString());
        }

        public int EnviarDatosUsuario()
        {
            int respuesta = new ConectorBD().existeMatricula(consumidor.getIdUsuario() );
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

        private void inputApellidoPaterno_Click(object sender, EventArgs e)
        {
            if( inputApellidoPaterno.Text == "Apellido Paterno")
            {
                inputApellidoPaterno.Text = "";
                inputApellidoPaterno.ForeColor = Color.Black;
            }
        }

        private void inputApellidoPaterno_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(inputApellidoPaterno.Text))
            {
                inputApellidoPaterno.Text = "Apellido Paterno";
                inputApellidoPaterno.ForeColor = Color.Silver;
            }
            else
            {
                inputApellidoPaterno.ForeColor = Color.Black;
            }
        }

        private void inputApellidoMaterno_Click(object sender, EventArgs e)
        {
            if (inputApellidoMaterno.Text == "Apellido Materno")
            {
                inputApellidoMaterno.Text = "";
                inputApellidoMaterno.ForeColor = Color.Black;
            }
        }

        private void inputApellidoMaterno_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputApellidoMaterno.Text))
            {
                inputApellidoMaterno.Text = "Apellido Materno";
                inputApellidoMaterno.ForeColor = Color.Silver;
            }
            else
            {
                inputApellidoMaterno.ForeColor = Color.Black;
            }
        }
    }
}
