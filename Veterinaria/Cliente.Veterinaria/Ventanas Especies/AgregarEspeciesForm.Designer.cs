namespace Cliente.Veterinaria.Ventanas_Especies
{
    partial class AgregarEspeciesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEspeciesForm));
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelarAgregar = new System.Windows.Forms.Button();
            this.btnAgregarEspecie = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIngresoEdadMadurezEspecie = new System.Windows.Forms.TextBox();
            this.txtIngresoPesoPromedioEspecie = new System.Windows.Forms.TextBox();
            this.txtIngresoNombreEspecie = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(44, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 25);
            this.label6.TabIndex = 25;
            this.label6.Text = "Agregar Especie";
            // 
            // btnCancelarAgregar
            // 
            this.btnCancelarAgregar.Location = new System.Drawing.Point(141, 160);
            this.btnCancelarAgregar.Name = "btnCancelarAgregar";
            this.btnCancelarAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarAgregar.TabIndex = 24;
            this.btnCancelarAgregar.Text = "Cancelar";
            this.btnCancelarAgregar.UseVisualStyleBackColor = true;
            this.btnCancelarAgregar.Click += new System.EventHandler(this.btnCancelarAgregar_Click);
            // 
            // btnAgregarEspecie
            // 
            this.btnAgregarEspecie.Location = new System.Drawing.Point(22, 160);
            this.btnAgregarEspecie.Name = "btnAgregarEspecie";
            this.btnAgregarEspecie.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarEspecie.TabIndex = 23;
            this.btnAgregarEspecie.Text = "Agregar";
            this.btnAgregarEspecie.UseVisualStyleBackColor = true;
            this.btnAgregarEspecie.Click += new System.EventHandler(this.btnAgregarEspecie_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Edad Madurez";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Peso Promedio";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre";
            // 
            // txtIngresoEdadMadurezEspecie
            // 
            this.txtIngresoEdadMadurezEspecie.Location = new System.Drawing.Point(99, 98);
            this.txtIngresoEdadMadurezEspecie.Name = "txtIngresoEdadMadurezEspecie";
            this.txtIngresoEdadMadurezEspecie.Size = new System.Drawing.Size(100, 20);
            this.txtIngresoEdadMadurezEspecie.TabIndex = 15;
            // 
            // txtIngresoPesoPromedioEspecie
            // 
            this.txtIngresoPesoPromedioEspecie.Location = new System.Drawing.Point(99, 124);
            this.txtIngresoPesoPromedioEspecie.Name = "txtIngresoPesoPromedioEspecie";
            this.txtIngresoPesoPromedioEspecie.Size = new System.Drawing.Size(100, 20);
            this.txtIngresoPesoPromedioEspecie.TabIndex = 14;
            // 
            // txtIngresoNombreEspecie
            // 
            this.txtIngresoNombreEspecie.Location = new System.Drawing.Point(99, 72);
            this.txtIngresoNombreEspecie.Name = "txtIngresoNombreEspecie";
            this.txtIngresoNombreEspecie.Size = new System.Drawing.Size(100, 20);
            this.txtIngresoNombreEspecie.TabIndex = 13;
            // 
            // AgregarEspeciesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 215);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancelarAgregar);
            this.Controls.Add(this.btnAgregarEspecie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIngresoEdadMadurezEspecie);
            this.Controls.Add(this.txtIngresoPesoPromedioEspecie);
            this.Controls.Add(this.txtIngresoNombreEspecie);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AgregarEspeciesForm";
            this.Text = "Agregar Especie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancelarAgregar;
        private System.Windows.Forms.Button btnAgregarEspecie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIngresoEdadMadurezEspecie;
        private System.Windows.Forms.TextBox txtIngresoPesoPromedioEspecie;
        private System.Windows.Forms.TextBox txtIngresoNombreEspecie;
    }
}