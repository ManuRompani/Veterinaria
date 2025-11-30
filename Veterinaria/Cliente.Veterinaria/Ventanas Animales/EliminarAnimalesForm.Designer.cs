namespace Cliente.Veterinaria.Ventanas_Animales
{
    partial class EliminarAnimalesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EliminarAnimalesForm));
            this.dgvListaAnimales = new System.Windows.Forms.DataGridView();
            this.btnEliminarAnimal = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaAnimales)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaAnimales
            // 
            this.dgvListaAnimales.AllowUserToAddRows = false;
            this.dgvListaAnimales.AllowUserToDeleteRows = false;
            this.dgvListaAnimales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaAnimales.Location = new System.Drawing.Point(12, 69);
            this.dgvListaAnimales.Name = "dgvListaAnimales";
            this.dgvListaAnimales.ReadOnly = true;
            this.dgvListaAnimales.Size = new System.Drawing.Size(587, 272);
            this.dgvListaAnimales.TabIndex = 0;
            // 
            // btnEliminarAnimal
            // 
            this.btnEliminarAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarAnimal.Location = new System.Drawing.Point(451, 361);
            this.btnEliminarAnimal.Name = "btnEliminarAnimal";
            this.btnEliminarAnimal.Size = new System.Drawing.Size(148, 55);
            this.btnEliminarAnimal.TabIndex = 1;
            this.btnEliminarAnimal.Text = "Eliminar";
            this.btnEliminarAnimal.UseVisualStyleBackColor = true;
            this.btnEliminarAnimal.Click += new System.EventHandler(this.btnEliminarAnimal_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(486, 25);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(113, 38);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Eliminar Animales";
            // 
            // EliminarAnimalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 427);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminarAnimal);
            this.Controls.Add(this.dgvListaAnimales);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EliminarAnimalesForm";
            this.Text = "Eliminar Animales";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaAnimales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaAnimales;
        private System.Windows.Forms.Button btnEliminarAnimal;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label1;
    }
}