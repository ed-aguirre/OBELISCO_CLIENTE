using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ReproductosCliente
{
    
    public partial class FormPrincipal : Form
    {
        FormRegistro FR;
        FormLogin FL;
        FormCliente FC;
        FormUsarPC FPC;
        FormUsoRapido FUR;
        Logica logica = new Logica();

        private const byte REGISTRO_EXITO = 1;
        private const byte REGISTRO_SIN_EXITO = 0;

        private const byte VISTA_ARRANQUE = 1;
        private const byte VISTA_CONSUMIDOR = 0;

        private const byte MOSTRAR_BTN_REGISTRARSE = 0;
        private const byte MOSTRAR_BTN_INGRESAR = 1;

        private const byte LOGIN_EXITO = 5;

        public FormPrincipal()
        {
            InitializeComponent();

            logica.setPrgmsEducativos();
            Colorear_panel();
            bloquearForm();
            customDesing(VISTA_ARRANQUE);
        }
        private void Colorear_panel() //pinta el panel lateral
        {
            panelBase.BackColor = ColorTranslator.FromHtml("#005baa");
            subPanel1.BackColor = ColorTranslator.FromHtml("#005baa");
            subPanel2.BackColor = ColorTranslator.FromHtml("#005baa");
            panel1.BackColor = ColorTranslator.FromHtml("#005baa");
        }

        private void customDesing(int casoInicio)// inicia y setea los valores de los paneles principales
        {
            if(casoInicio == VISTA_ARRANQUE)
            {
                subPanel1.Visible = false;//Y VUELVE INVISIBLE EL PRIMER PANEL
                btnIngresar.Visible = false;
                btnRegistrarse.Visible = false;
                btnBack.Visible = false;
            }
            else if(casoInicio == VISTA_CONSUMIDOR) 
            {
                cambioMenu(); //cambio la vista de los submenus principales
                btnIngresar.Visible = false; //vuelve invisible a los botones de login
                btnRegistrarse.Visible = false;
                btnBack.Visible = false;

                btnRegistrar.BackColor = Color.CornflowerBlue;//regresa a los colores originales:)
                btnIniciarSesion.BackColor = Color.CornflowerBlue;
            }
            
        }

        public void cambioMenu()//cambia la visibilidad de los paneles cuando selecciona login o registrar
        {
            if(subPanel2.Visible)
            {
                subPanel2.Visible = false;
                subPanel1.Visible = true;
            }
            else if (subPanel1.Visible)
            {
                subPanel1.Visible = false;
                subPanel2.Visible = true;
            }
            
        }

        public void cambioBotones(int boton)
        {
            btnBack.Visible = true;
            if(boton == MOSTRAR_BTN_REGISTRARSE)
            {
                btnRegistrar.BackColor = Color.LightSteelBlue;//cambia los colores
                btnIniciarSesion.BackColor = Color.CornflowerBlue;

                btnIngresar.Visible = false;//cambia la visibilidad
                btnRegistrarse.Visible = true;
            }
            else if( boton == MOSTRAR_BTN_INGRESAR)
            {
                btnIniciarSesion.BackColor = Color.LightSteelBlue;//cambia lo colores
                btnRegistrar.BackColor = Color.CornflowerBlue;

                btnRegistrarse.Visible = false;//cambia la visibilidad
                btnIngresar.Visible = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FL = new FormLogin();
            abrirChildForm(FL);//se crea el objeto formLogin y se pasa como parametro
            cambioBotones( MOSTRAR_BTN_INGRESAR ); //se envia un parametro uno, para indicar al metodo que es login
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FR = new FormRegistro(logica.getPrgmsEducativo()) ;
            
            abrirChildForm(FR);
            cambioBotones(MOSTRAR_BTN_REGISTRARSE);
        }
        private void btnIngresar_Click(object sender, EventArgs e) //este es el que manda datos al dataCliente
        {
            if (FL.validarCampos())
            {
                logica.setDatosCliente(FL.iniciarSesion());
                if(logica.getDatosCliente().Count > 0)
                {
                    if ( logica.ValidarTipoUsuario( Consumidor.FromMap(logica.getDatosCliente()) ) ) //true == pasa
                    {
                        new MyMessageBox().Show(LOGIN_EXITO);

                        FC = new FormCliente( logica.getDatosCliente(), logica.getPrgmsEducativo() );
                        abrirChildForm(FC);
                        customDesing(VISTA_CONSUMIDOR);
                    }

                }
            }

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            activeForm.Close(); //cierra cualquier form activo
            customDesing(VISTA_ARRANQUE);//regresa a la vista de Arranque
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

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            FC = new FormCliente(logica.getDatosCliente(), logica.getPrgmsEducativo());
            abrirChildForm(FC);
        }

        private void btnUsarPC_Click(object sender, EventArgs e)
        {
            FPC = new FormUsarPC( logica.getDatosCliente() );
            abrirChildForm( FPC );
        }

        private void btnUsoRapido_Click(object sender, EventArgs e)
        {
            FUR = new FormUsoRapido();
            abrirChildForm(FUR);
        }

        public void bloquearForm() //bloquea el form1 para que el usuario no pueda manipularlo
        { 
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            //ESTA LINEA DE CODIGO ES IMPORTANTE, 
            WindowState = FormWindowState.Maximized;
        }


        private void btnRegistrarAccion_Click(object sender, EventArgs e)//boton RegistrarAccion
        {
            int respuesta = 0;
            if(FR.validarCampos())//true = todo bien
            {
                FR.setCampos();
                respuesta = FR.EnviarDatosUsuario();

                if (respuesta == REGISTRO_EXITO)
                {
                    new MyMessageBox().Show(REGISTRO_EXITO);
                    activeForm.Close();
                    customDesing(VISTA_ARRANQUE);
                }
                else
                {
                    new MyMessageBox().Show(REGISTRO_SIN_EXITO);
                }
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (logica.cerrarSesion()) //si selecciona si, se cerrará todo los forms y saldra de la sesion
            {
                activeForm.Close();
                cambioMenu();
                logica.vaciarDatosUsuario();

                if (logica.verificarForm())
                {
                    FormCollection fc = Application.OpenForms;
                    fc[1].Close();
                    //el FormTimer siempre va a estar en la posición 1 del FormCollection
                }
                bloquearForm();
            }
        }

    }
}
