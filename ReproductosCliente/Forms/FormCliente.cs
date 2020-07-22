using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReproductosCliente
{
    public partial class FormCliente : Form
    {
        private IConsumidor consumidor;
        TextInfo capital = new CultureInfo("en-US", false).TextInfo;
        private Dictionary<string, string> programas;

        private const byte DESBLOQUEAR_FORM = 1;
        public FormCliente()
        {
            InitializeComponent();
            btnDesbloquear.Visible = false;
        }

        public FormCliente(Dictionary<string, Object> datosUser, Dictionary<string, string> programas)
        {
            Console.WriteLine("CLIENTE INICIADA");
            InitializeComponent();
            
            btnDesbloquear.Visible = false;
            btnExit.Visible = false;

            consumidor = Consumidor.FromMap(datosUser);
            this.programas = programas;
            setValores();
            mostrarBtn();
        }

        public FormCliente(Dictionary<string, Object> datosUser)
        {
            Console.WriteLine("Modo Admin");
            InitializeComponent();

            consumidor = Consumidor.FromMap(datosUser);
            setValores();
            mostrarBtn();
        }

        private void setValores()
        {
            string nombre = capital.ToTitleCase(consumidor.getNombre().ToLower());
            string paterno = capital.ToTitleCase(consumidor.getApellidoPaterno().ToLower());
            string materno = capital.ToTitleCase(consumidor.getApellidoMaterno().ToLower());
            string completo = string.Format("{0} {1} {2}", nombre, paterno, materno);
            string programaEduca = "";
            if (programas != null)
            {
                programaEduca = programas[consumidor.getPrgmaEducativo().ToString()];
            }


            lblNombreCompleto.Text = completo;
            lblPrgmEducativo.Text = programaEduca;
            lblMatricula.Text = consumidor.getIdUsuario();
            lblSaldo.Text = consumidor.getSaldo().ToString();
        }
        private void mostrarBtn()
        {
            if(consumidor.getTipoUsuario() != 1)
            {
                btnDesbloquear.Visible = true;
                btnExit.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //inservibleeeee
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            Logica logica = Logica.getInstancia();
            logica.manipularForm(DESBLOQUEAR_FORM);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
