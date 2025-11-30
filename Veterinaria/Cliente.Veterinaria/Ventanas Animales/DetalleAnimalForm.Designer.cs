namespace Cliente.Veterinaria.Ventanas_Animales
{
    partial class DetalleAnimalForm
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
            this.cboxAnimales = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxID = new System.Windows.Forms.TextBox();
            this.tboxNombre = new System.Windows.Forms.TextBox();
            this.tboxPeso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tboxEdad = new System.Windows.Forms.TextBox();
            this.tboxEspecie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tboxMadurez = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tboxPromedio = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboxAnimales
            // 
            this.cboxAnimales.FormattingEnabled = true;
            this.cboxAnimales.Location = new System.Drawing.Point(33, 89);
            this.cboxAnimales.Name = "cboxAnimales";
            this.cboxAnimales.Size = new System.Drawing.Size(250, 21);
            this.cboxAnimales.TabIndex = 0;
            this.cboxAnimales.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccionar animal";
            // 
            // tboxID
            // 
            this.tboxID.Location = new System.Drawing.Point(33, 141);
            this.tboxID.Name = "tboxID";
            this.tboxID.Size = new System.Drawing.Size(250, 20);
            this.tboxID.TabIndex = 2;
            // 
            // tboxNombre
            // 
            this.tboxNombre.Location = new System.Drawing.Point(33, 192);
            this.tboxNombre.Name = "tboxNombre";
            this.tboxNombre.Size = new System.Drawing.Size(250, 20);
            this.tboxNombre.TabIndex = 3;
            // 
            // tboxPeso
            // 
            this.tboxPeso.Location = new System.Drawing.Point(33, 243);
            this.tboxPeso.Name = "tboxPeso";
            this.tboxPeso.Size = new System.Drawing.Size(250, 20);
            this.tboxPeso.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Detalle Animal";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 493);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tboxEdad
            // 
            this.tboxEdad.Location = new System.Drawing.Point(33, 294);
            this.tboxEdad.Name = "tboxEdad";
            this.tboxEdad.Size = new System.Drawing.Size(250, 20);
            this.tboxEdad.TabIndex = 7;
            // 
            // tboxEspecie
            // 
            this.tboxEspecie.Location = new System.Drawing.Point(33, 345);
            this.tboxEspecie.Name = "tboxEspecie";
            this.tboxEspecie.Size = new System.Drawing.Size(250, 20);
            this.tboxEspecie.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Peso";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Edad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Especie";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 378);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Edad Madurez";
            // 
            // tboxMadurez
            // 
            this.tboxMadurez.Location = new System.Drawing.Point(33, 396);
            this.tboxMadurez.Name = "tboxMadurez";
            this.tboxMadurez.Size = new System.Drawing.Size(250, 20);
            this.tboxMadurez.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 429);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Peso Promedio";
            // 
            // tboxPromedio
            // 
            this.tboxPromedio.Location = new System.Drawing.Point(33, 447);
            this.tboxPromedio.Name = "tboxPromedio";
            this.tboxPromedio.Size = new System.Drawing.Size(250, 20);
            this.tboxPromedio.TabIndex = 16;
            // 
            // DetalleAnimalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 528);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tboxPromedio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tboxMadurez);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tboxEspecie);
            this.Controls.Add(this.tboxEdad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tboxPeso);
            this.Controls.Add(this.tboxNombre);
            this.Controls.Add(this.tboxID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxAnimales);
            this.Name = "DetalleAnimalForm";
            this.Text = "DetalleAnimalForm";
            this.Load += new System.EventHandler(this.DetalleAnimalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxAnimales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxID;
        private System.Windows.Forms.TextBox tboxNombre;
        private System.Windows.Forms.TextBox tboxPeso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tboxEdad;
        private System.Windows.Forms.TextBox tboxEspecie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tboxMadurez;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tboxPromedio;
    }
}