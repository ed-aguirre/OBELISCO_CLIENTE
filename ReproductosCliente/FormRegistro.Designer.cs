namespace ReproductosCliente
{
    partial class FormRegistro
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
            this.inputNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputApellidoPaterno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputMatricula = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboPrograma = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.inputContra = new System.Windows.Forms.TextBox();
            this.inputApellidoMaterno = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombres";
            // 
            // inputNombre
            // 
            this.inputNombre.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputNombre.Location = new System.Drawing.Point(36, 83);
            this.inputNombre.MaxLength = 30;
            this.inputNombre.Name = "inputNombre";
            this.inputNombre.Size = new System.Drawing.Size(262, 29);
            this.inputNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(300, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Apellidos";
            // 
            // inputApellidoPaterno
            // 
            this.inputApellidoPaterno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputApellidoPaterno.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputApellidoPaterno.ForeColor = System.Drawing.Color.Silver;
            this.inputApellidoPaterno.Location = new System.Drawing.Point(304, 83);
            this.inputApellidoPaterno.MaxLength = 30;
            this.inputApellidoPaterno.Name = "inputApellidoPaterno";
            this.inputApellidoPaterno.Size = new System.Drawing.Size(94, 29);
            this.inputApellidoPaterno.TabIndex = 2;
            this.inputApellidoPaterno.Click += new System.EventHandler(this.inputApellidoPaterno_Click);
            this.inputApellidoPaterno.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.inputApellidoPaterno.Leave += new System.EventHandler(this.inputApellidoPaterno_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Matricula/N° Academico";
            // 
            // inputMatricula
            // 
            this.inputMatricula.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputMatricula.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputMatricula.Location = new System.Drawing.Point(36, 153);
            this.inputMatricula.MaxLength = 10;
            this.inputMatricula.Name = "inputMatricula";
            this.inputMatricula.Size = new System.Drawing.Size(583, 29);
            this.inputMatricula.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Programa Educativo";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboPrograma
            // 
            this.comboPrograma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboPrograma.BackColor = System.Drawing.SystemColors.Window;
            this.comboPrograma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPrograma.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPrograma.FormattingEnabled = true;
            this.comboPrograma.Location = new System.Drawing.Point(36, 224);
            this.comboPrograma.MaxDropDownItems = 15;
            this.comboPrograma.Name = "comboPrograma";
            this.comboPrograma.Size = new System.Drawing.Size(583, 28);
            this.comboPrograma.TabIndex = 5;
            this.comboPrograma.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Contraseña";
            this.label5.Click += new System.EventHandler(this.label4_Click);
            // 
            // inputContra
            // 
            this.inputContra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputContra.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputContra.Location = new System.Drawing.Point(36, 295);
            this.inputContra.MaxLength = 30;
            this.inputContra.Name = "inputContra";
            this.inputContra.Size = new System.Drawing.Size(583, 29);
            this.inputContra.TabIndex = 6;
            this.inputContra.UseSystemPasswordChar = true;
            // 
            // inputApellidoMaterno
            // 
            this.inputApellidoMaterno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputApellidoMaterno.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputApellidoMaterno.ForeColor = System.Drawing.Color.Silver;
            this.inputApellidoMaterno.Location = new System.Drawing.Point(512, 83);
            this.inputApellidoMaterno.MaxLength = 30;
            this.inputApellidoMaterno.Name = "inputApellidoMaterno";
            this.inputApellidoMaterno.Size = new System.Drawing.Size(107, 29);
            this.inputApellidoMaterno.TabIndex = 3;
            this.inputApellidoMaterno.Click += new System.EventHandler(this.inputApellidoMaterno_Click);
            this.inputApellidoMaterno.Leave += new System.EventHandler(this.inputApellidoMaterno_Leave);
            // 
            // FormRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(663, 370);
            this.Controls.Add(this.inputApellidoMaterno);
            this.Controls.Add(this.comboPrograma);
            this.Controls.Add(this.inputApellidoPaterno);
            this.Controls.Add(this.inputContra);
            this.Controls.Add(this.inputMatricula);
            this.Controls.Add(this.inputNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FormRegistro";
            this.Text = "FormRegistro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputApellidoPaterno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputMatricula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboPrograma;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inputContra;
        private System.Windows.Forms.TextBox inputApellidoMaterno;
    }
}