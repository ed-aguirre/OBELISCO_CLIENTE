namespace ReproductosCliente
{
    partial class FormUsarPC
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
            this.btnAceptarUsar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desbloquear el equipo para usarlo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(599, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Se te cobrará $3 por usar el equipo. (Hasta máximo 2 horas)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(176, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "¿Deseas continuar?";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnAceptarUsar
            // 
            this.btnAceptarUsar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptarUsar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAceptarUsar.FlatAppearance.BorderSize = 0;
            this.btnAceptarUsar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptarUsar.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptarUsar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAceptarUsar.Location = new System.Drawing.Point(62, 261);
            this.btnAceptarUsar.Name = "btnAceptarUsar";
            this.btnAceptarUsar.Size = new System.Drawing.Size(513, 38);
            this.btnAceptarUsar.TabIndex = 1;
            this.btnAceptarUsar.Text = "Aceptar";
            this.btnAceptarUsar.UseVisualStyleBackColor = false;
            this.btnAceptarUsar.Click += new System.EventHandler(this.btnAceptarUsar_Click);
            // 
            // FormUsarPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(646, 370);
            this.Controls.Add(this.btnAceptarUsar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormUsarPC";
            this.ShowInTaskbar = false;
            this.Text = "FormUsarPC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAceptarUsar;
    }
}