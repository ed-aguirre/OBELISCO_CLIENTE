using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ReproductosCliente
{
   
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            bloquearForm();
            customDesing(1);
        }

        private void customDesing(int casoInicio)// inicia y setea los valores de los paneles principales
        {
            if(casoInicio == 1)
            {
                subPanel1.Visible = false;//Y VUELVE INVISIBLE EL PRIMER PANEL
                btnIngresar.Visible = false;
                btnRegistrarAccion.Visible = false;
                btnBack.Visible = false;
            }
            else if(casoInicio == 0) 
            {
                cambioMenu(); //cambio la vista de los submenus principales
                btnIngresar.Visible = false; //vuelve invisible a los botones de login
                btnRegistrarAccion.Visible = false;
                btnBack.Visible = false;

                btnRegistrar.BackColor = Color.CornflowerBlue;//regresa a los colores originales:)
                btnLogin.BackColor = Color.CornflowerBlue;
            }
            
        }

        public void cambioMenu()//cambia la visibilidad de los paneles cuando selecciona login o registrar
        {
            if(subPanel2.Visible == true)
            {
                subPanel2.Visible = false;
                subPanel1.Visible = true;
            }
            else if (subPanel1.Visible == true)
            {
                subPanel1.Visible = false;
                subPanel2.Visible = true;
            }
            
        }

        public void cambioBotones(int boton)
        {
            btnBack.Visible = true;
            if(boton == 0)
            {
                btnRegistrar.BackColor = Color.LightSteelBlue;//cambia los colores
                btnLogin.BackColor = Color.CornflowerBlue;

                btnIngresar.Visible = false;//cambia la visibilidad
                btnRegistrarAccion.Visible = true;
            }
            else if( boton == 1)
            {
                btnLogin.BackColor = Color.LightSteelBlue;//cambia lo colores
                btnRegistrar.BackColor = Color.CornflowerBlue;

                btnRegistrarAccion.Visible = false;//cambia la visibilidad
                btnIngresar.Visible = true;
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            FormLogin fl = new FormLogin();
            abrirChildForm(fl);//se crea el objeto formLogin y se pasa como parametro
            cambioBotones(1); //se envia un parametro uno, para indicar al metodo que es login
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FormRegistro fm2 = new FormRegistro();
            abrirChildForm(fm2);//igual que el metodo anterior pero con el formRegistro
            cambioBotones(0);//se envia como parametro 0 para indicar al metodo que es el registro
        }
        private void btnIngresar_Click(object sender, EventArgs e) //este es el que manda datos al dataCliente
        {
            FormCliente fm3 = new FormCliente();
            abrirChildForm(fm3); // se abre el form cliente
            customDesing(0); // se cambia a la vista para mostrar los botones del cliente

             
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            activeForm.Close(); //cierra cualquier form activo
            customDesing(1);//regresa a la vista de Arranque
        }

        private Form activeForm = null;
        private void abrirChildForm(Form childForm)//cambio de formularios
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void panelBase_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            abrirChildForm( new FormUsarPC() );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            abrirChildForm( new FormCliente() );
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            abrirChildForm(new FormUsoRapido());
        }
        private void bloquearForm() //bloquea el form1 para que el usuario no pueda manipularlo
        { 
            // no se di dejar esta funcion, pues en la class1 tambien se hace esto, hmm
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }

        public void cerrarActiveFormYCerrarSesion()
        {
            activeForm.Close(); //cierra el form activo
            cambioMenu(); //cambia al meun inicial

            FormCollection fc = Application.OpenForms; //objecto de FormCollection
            fc[1].Close();//el FormTimer siempre va a estar en la posición 1 del FormCollection, y lo cierra

            bloquearForm(); //bloquea el form
        }

        private void button3_Click(object sender, EventArgs e) //btnCerrarSesion
        {
            Class1 cl = new Class1();
            int respuesta = cl.alerta(1); //guarda el valor del dialog result(1 o 0)
            if( respuesta == 1) //si selecciona si, se cerrará todo los forms y saldra de la sesion
            {
                activeForm.Close();
                cambioMenu();
                if(cl.verificarForm() == true)
                {
                    FormCollection fc = Application.OpenForms;
                    fc[1].Close();//el FormTimer siempre va a estar en la posición 1 del FormCollection
                }
                bloquearForm();
                
            }
            else
            {
                Console.WriteLine("El usuario cancelo la accion.");
            }
        }

        private void btnRegistrarAccion_Click(object sender, EventArgs e)
        {
            new Class1().alerta(4); // se manda la alerta del registro
        }
    }
}
