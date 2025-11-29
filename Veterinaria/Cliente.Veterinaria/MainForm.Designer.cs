namespace Cliente.Veterinaria
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verAnimalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarAnimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarAnimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarAnimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPesosDeAnimalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.especiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.animalesToolStripMenuItem,
            this.especiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // animalesToolStripMenuItem
            // 
            this.animalesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verAnimalesToolStripMenuItem,
            this.agregarAnimalToolStripMenuItem,
            this.modificarAnimalToolStripMenuItem,
            this.eliminarAnimalToolStripMenuItem,
            this.verPesosDeAnimalesToolStripMenuItem});
            this.animalesToolStripMenuItem.Name = "animalesToolStripMenuItem";
            this.animalesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.animalesToolStripMenuItem.Text = "Animales";
            // 
            // verAnimalesToolStripMenuItem
            // 
            this.verAnimalesToolStripMenuItem.Name = "verAnimalesToolStripMenuItem";
            this.verAnimalesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verAnimalesToolStripMenuItem.Text = "Ver todos animales";
            // 
            // agregarAnimalToolStripMenuItem
            // 
            this.agregarAnimalToolStripMenuItem.Name = "agregarAnimalToolStripMenuItem";
            this.agregarAnimalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarAnimalToolStripMenuItem.Text = "Agregar animal";
            // 
            // modificarAnimalToolStripMenuItem
            // 
            this.modificarAnimalToolStripMenuItem.Name = "modificarAnimalToolStripMenuItem";
            this.modificarAnimalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modificarAnimalToolStripMenuItem.Text = "Modificar animal";
            // 
            // eliminarAnimalToolStripMenuItem
            // 
            this.eliminarAnimalToolStripMenuItem.Name = "eliminarAnimalToolStripMenuItem";
            this.eliminarAnimalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eliminarAnimalToolStripMenuItem.Text = "Eliminar animal";
            // 
            // verPesosDeAnimalesToolStripMenuItem
            // 
            this.verPesosDeAnimalesToolStripMenuItem.Name = "verPesosDeAnimalesToolStripMenuItem";
            this.verPesosDeAnimalesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verPesosDeAnimalesToolStripMenuItem.Text = "Ver reporte de pesos";
            // 
            // especiesToolStripMenuItem
            // 
            this.especiesToolStripMenuItem.Name = "especiesToolStripMenuItem";
            this.especiesToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.especiesToolStripMenuItem.Text = "Especies";
            this.especiesToolStripMenuItem.Click += new System.EventHandler(this.especiesToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verAnimalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarAnimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarAnimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarAnimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPesosDeAnimalesToolStripMenuItem;
    }
}

