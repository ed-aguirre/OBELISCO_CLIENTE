namespace ReproductosCliente
{
    partial class FormConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblServidor = new System.Windows.Forms.Label();
            this.lblPuertoMysql = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContra = new System.Windows.Forms.Label();
            this.lblBDName = new System.Windows.Forms.Label();
            this.lblDesc2 = new System.Windows.Forms.Label();
            this.lblPuertoSocket = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.inputServidor = new System.Windows.Forms.TextBox();
            this.inputPuertoMysql = new System.Windows.Forms.TextBox();
            this.inputUsuario = new System.Windows.Forms.TextBox();
            this.inputContrasena = new System.Windows.Forms.TextBox();
            this.inputNombreBD = new System.Windows.Forms.TextBox();
            this.inputPuertoSocket = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblDesc.Location = new System.Drawing.Point(13, 13);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(713, 18);
            this.lblDesc.TabIndex = 0;
            this.lblDesc.Text = "Configuración del conector de BD: Ingresa los valores que tendrá el conector a la" +
    " BD.";
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Font = new System.Drawing.Font("Verdana", 13F);
            this.lblServidor.Location = new System.Drawing.Point(16, 64);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(181, 22);
            this.lblServidor.TabIndex = 1;
            this.lblServidor.Text = "Servidor/IP addres";
            this.lblServidor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPuertoMysql
            // 
            this.lblPuertoMysql.AutoSize = true;
            this.lblPuertoMysql.Font = new System.Drawing.Font("Verdana", 13F);
            this.lblPuertoMysql.Location = new System.Drawing.Point(59, 102);
            this.lblPuertoMysql.Name = "lblPuertoMysql";
            this.lblPuertoMysql.Size = new System.Drawing.Size(137, 22);
            this.lblPuertoMysql.TabIndex = 2;
            this.lblPuertoMysql.Text = "Puerto MYSQL";
            this.lblPuertoMysql.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Verdana", 13F);
            this.lblUsuario.Location = new System.Drawing.Point(118, 143);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(78, 22);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContra
            // 
            this.lblContra.AutoSize = true;
            this.lblContra.Font = new System.Drawing.Font("Verdana", 13F);
            this.lblContra.Location = new System.Drawing.Point(83, 182);
            this.lblContra.Name = "lblContra";
            this.lblContra.Size = new System.Drawing.Size(113, 22);
            this.lblContra.TabIndex = 4;
            this.lblContra.Text = "Contraseña";
            this.lblContra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBDName
            // 
            this.lblBDName.AutoSize = true;
            this.lblBDName.Font = new System.Drawing.Font("Verdana", 13F);
            this.lblBDName.Location = new System.Drawing.Point(33, 223);
            this.lblBDName.Name = "lblBDName";
            this.lblBDName.Size = new System.Drawing.Size(164, 22);
            this.lblBDName.TabIndex = 5;
            this.lblBDName.Text = "Nombre de la BD";
            this.lblBDName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDesc2
            // 
            this.lblDesc2.AutoSize = true;
            this.lblDesc2.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblDesc2.Location = new System.Drawing.Point(17, 279);
            this.lblDesc2.Name = "lblDesc2";
            this.lblDesc2.Size = new System.Drawing.Size(455, 18);
            this.lblDesc2.TabIndex = 6;
            this.lblDesc2.Text = "Configuración del Socket: Ingrese el puerto del socket";
            // 
            // lblPuertoSocket
            // 
            this.lblPuertoSocket.AutoSize = true;
            this.lblPuertoSocket.Font = new System.Drawing.Font("Verdana", 13F);
            this.lblPuertoSocket.Location = new System.Drawing.Point(61, 323);
            this.lblPuertoSocket.Name = "lblPuertoSocket";
            this.lblPuertoSocket.Size = new System.Drawing.Size(136, 22);
            this.lblPuertoSocket.TabIndex = 7;
            this.lblPuertoSocket.Text = "Puerto Socket";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnConfirmar.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.Location = new System.Drawing.Point(87, 372);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(639, 46);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // inputServidor
            // 
            this.inputServidor.Font = new System.Drawing.Font("Verdana", 12F);
            this.inputServidor.Location = new System.Drawing.Point(214, 62);
            this.inputServidor.MaximumSize = new System.Drawing.Size(512, 40);
            this.inputServidor.Name = "inputServidor";
            this.inputServidor.Size = new System.Drawing.Size(512, 27);
            this.inputServidor.TabIndex = 9;
            // 
            // inputPuertoMysql
            // 
            this.inputPuertoMysql.Font = new System.Drawing.Font("Verdana", 12F);
            this.inputPuertoMysql.Location = new System.Drawing.Point(214, 100);
            this.inputPuertoMysql.MaximumSize = new System.Drawing.Size(512, 40);
            this.inputPuertoMysql.Name = "inputPuertoMysql";
            this.inputPuertoMysql.Size = new System.Drawing.Size(512, 27);
            this.inputPuertoMysql.TabIndex = 10;
            // 
            // inputUsuario
            // 
            this.inputUsuario.Font = new System.Drawing.Font("Verdana", 12F);
            this.inputUsuario.Location = new System.Drawing.Point(214, 141);
            this.inputUsuario.MaximumSize = new System.Drawing.Size(512, 40);
            this.inputUsuario.Name = "inputUsuario";
            this.inputUsuario.Size = new System.Drawing.Size(512, 27);
            this.inputUsuario.TabIndex = 11;
            // 
            // inputContrasena
            // 
            this.inputContrasena.Font = new System.Drawing.Font("Verdana", 12F);
            this.inputContrasena.Location = new System.Drawing.Point(214, 180);
            this.inputContrasena.MaximumSize = new System.Drawing.Size(512, 40);
            this.inputContrasena.Name = "inputContrasena";
            this.inputContrasena.Size = new System.Drawing.Size(512, 27);
            this.inputContrasena.TabIndex = 12;
            // 
            // inputNombreBD
            // 
            this.inputNombreBD.Font = new System.Drawing.Font("Verdana", 12F);
            this.inputNombreBD.Location = new System.Drawing.Point(214, 220);
            this.inputNombreBD.MaximumSize = new System.Drawing.Size(512, 40);
            this.inputNombreBD.Name = "inputNombreBD";
            this.inputNombreBD.Size = new System.Drawing.Size(512, 27);
            this.inputNombreBD.TabIndex = 13;
            // 
            // inputPuertoSocket
            // 
            this.inputPuertoSocket.Font = new System.Drawing.Font("Verdana", 12F);
            this.inputPuertoSocket.Location = new System.Drawing.Point(214, 323);
            this.inputPuertoSocket.MaximumSize = new System.Drawing.Size(512, 40);
            this.inputPuertoSocket.Name = "inputPuertoSocket";
            this.inputPuertoSocket.Size = new System.Drawing.Size(512, 27);
            this.inputPuertoSocket.TabIndex = 14;
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.inputPuertoSocket);
            this.Controls.Add(this.inputNombreBD);
            this.Controls.Add(this.inputContrasena);
            this.Controls.Add(this.inputUsuario);
            this.Controls.Add(this.inputPuertoMysql);
            this.Controls.Add(this.inputServidor);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblPuertoSocket);
            this.Controls.Add(this.lblDesc2);
            this.Controls.Add(this.lblBDName);
            this.Controls.Add(this.lblContra);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblPuertoMysql);
            this.Controls.Add(this.lblServidor);
            this.Controls.Add(this.lblDesc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar conector de BD";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConfig_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.Label lblPuertoMysql;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContra;
        private System.Windows.Forms.Label lblBDName;
        private System.Windows.Forms.Label lblDesc2;
        private System.Windows.Forms.Label lblPuertoSocket;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox inputServidor;
        private System.Windows.Forms.TextBox inputPuertoMysql;
        private System.Windows.Forms.TextBox inputUsuario;
        private System.Windows.Forms.TextBox inputContrasena;
        private System.Windows.Forms.TextBox inputNombreBD;
        private System.Windows.Forms.TextBox inputPuertoSocket;
    }
}