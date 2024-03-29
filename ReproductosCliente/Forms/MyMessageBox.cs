﻿using System;
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
    public partial class MyMessageBox : Form
    {
        private const int BOTONES_ACEPTAR = 0;
        private const int BOTONES_YES_NO = 1;
        public MyMessageBox()
        {
            TopMost = true;
            InitializeComponent();

        }

        public DialogResult Show(int tipo)
        {
            switch (tipo)
            {
                case 1://registro realizado con exito
                    Text = "Registro realizado";
                    lblData.Text = "Ve con el Administrador para completar el registro.\nNo olvides llevar tu credencial UV.";
                    MostrarBotones(BOTONES_ACEPTAR);
                    break;
                case 2: //cuando sea 2 será el caso de Tiempo excedido
                    Text = "Tiempo excedido";
                    lblData.Text = "Tu tiempo se ha agotado, ¿deseas seguir utilizando el equipo?";
                    MostrarBotones(BOTONES_YES_NO);
                    break;
                case 3: //3: el tiempo agotado del tiempo rápido
                    Text = "Tiempo excedido";
                    lblData.Text = "Tu tiempo se ha agotado. Se cerrará la sesión.";
                    MostrarBotones(BOTONES_ACEPTAR);
                    break;
                case 4: //cuando sea uno sera el caso de CerrarSesion
                    Text = "Cerrar Sesión";
                    lblData.Text = "¿Deseas cerrar sesión?";
                    MostrarBotones(BOTONES_YES_NO);
                    break;
                case 5:
                    Text = "Login exitoso.";
                    lblData.Text = "Iniciando sesión...";
                    MostrarBotones(BOTONES_ACEPTAR);
                    break;
                case 6:
                    Text = "CERRANDO OBELISCO";
                    lblData.Text = "ALERTA\n" +
                        "Cierre de programa inesperado." +
                        "Se bloqueará tu usuario en el sistema y ya no podras acceder." +
                        "¿Deseas continuar?";
                    MostrarBotones(BOTONES_YES_NO);
                    break;
                case 7:
                    Text = "Apagar equipo";
                    lblData.Text = "¿Deseas apagar el equipo?";
                    MostrarBotones(BOTONES_YES_NO);
                    break;
                default:
                    Text = "ERROR";
                    lblData.Text = "Al parecer ocurrio un error.";
                    MostrarBotones(BOTONES_ACEPTAR);
                    break;
            }

            return this.ShowDialog();
        }

        public DialogResult Show(string textoAlerta)
        {
            Text = "Alerta";
            lblData.Text = textoAlerta;
            MostrarBotones(BOTONES_ACEPTAR);

            return this.ShowDialog();
        }

        public DialogResult Show(string textoAlerta, int botonesSINO)
        {
            Text = "Alerta";
            lblData.Text = textoAlerta;
            MostrarBotones(BOTONES_YES_NO);

            return this.ShowDialog();
        }

        private void MostrarBotones(int tipo)
        {
            if( tipo == BOTONES_ACEPTAR)
            {
                btnAceptar.Visible = true;
                btnNo.Visible = false;
                btnYes.Visible = false;
            }
            else
            {
                btnAceptar.Visible = false;
                btnNo.Visible = true;
                btnYes.Visible = true;
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }


    }
}
