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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.inputServidor = new System.Windows.Forms.TextBox();
            this.inputPuertoMysql = new System.Windows.Forms.TextBox();
            this.inputUsuario = new System.Windows.Forms.TextBox();
            this.inputContrasena = new System.Windows.Forms.TextBox();
            this.inputNombreBD = new System.Windows.Forms.TextBox();
            this.inputPuertoSocket = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(713, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuración del conector de BD: Ingresa los valores que tendrá el conector a la" +
    " BD.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 13F);
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Servidor/IP addres";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 13F);
            this.label3.Location = new System.Drawing.Point(59, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Puerto MYSQL";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 13F);
            this.label4.Location = new System.Drawing.Point(118, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Usuario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 13F);
            this.label5.Location = new System.Drawing.Point(83, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Contraseña";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 13F);
            this.label6.Location = new System.Drawing.Point(33, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nombre de la BD";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F);
            this.label7.Location = new System.Drawing.Point(17, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(455, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Configuración del Socket: Ingrese el puerto del socket";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 13F);
            this.label8.Location = new System.Drawing.Point(61, 323);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 22);
            this.label8.TabIndex = 7;
            this.label8.Text = "Puerto Socket";
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
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox inputServidor;
        private System.Windows.Forms.TextBox inputPuertoMysql;
        private System.Windows.Forms.TextBox inputUsuario;
        private System.Windows.Forms.TextBox inputContrasena;
        private System.Windows.Forms.TextBox inputNombreBD;
        private System.Windows.Forms.TextBox inputPuertoSocket;
    }
}