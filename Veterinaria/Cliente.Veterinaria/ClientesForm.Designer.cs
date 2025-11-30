namespace Cliente.Veterinaria
{
    partial class ClientesForm
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
            this.tboxBuscarDNI = new System.Windows.Forms.TextBox();
            this.lblBuscarDNI = new System.Windows.Forms.Label();
            this.btnBuscarDNI = new System.Windows.Forms.Button();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // tboxBuscarDNI
            // 
            this.tboxBuscarDNI.Location = new System.Drawing.Point(34, 38);
            this.tboxBuscarDNI.Name = "tboxBuscarDNI";
            this.tboxBuscarDNI.Size = new System.Drawing.Size(142, 20);
            this.tboxBuscarDNI.TabIndex = 0;
            // 
            // lblBuscarDNI
            // 
            this.lblBuscarDNI.AutoSize = true;
            this.lblBuscarDNI.Location = new System.Drawing.Point(31, 22);
            this.lblBuscarDNI.Name = "lblBuscarDNI";
            this.lblBuscarDNI.Size = new System.Drawing.Size(80, 13);
            this.lblBuscarDNI.TabIndex = 1;
            this.lblBuscarDNI.Text = "Buscar por DNI";
            // 
            // btnBuscarDNI
            // 
            this.btnBuscarDNI.Location = new System.Drawing.Point(182, 37);
            this.btnBuscarDNI.Name = "btnBuscarDNI";
            this.btnBuscarDNI.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarDNI.TabIndex = 2;
            this.btnBuscarDNI.Text = "Buscar";
            this.btnBuscarDNI.UseVisualStyleBackColor = true;
            this.btnBuscarDNI.Click += new System.EventHandler(this.btnBuscarDNI_Click);
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(34, 77);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(732, 283);
            this.dgvClientes.TabIndex = 3;
            this.dgvClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentClick);
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarCliente.Location = new System.Drawing.Point(667, 396);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(99, 23);
            this.btnAgregarCliente.TabIndex = 4;
            this.btnAgregarCliente.Text = "Agregar Cliente";
            this.btnAgregarCliente.UseVisualStyleBackColor = true;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // ClientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAgregarCliente);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.btnBuscarDNI);
            this.Controls.Add(this.lblBuscarDNI);
            this.Controls.Add(this.tboxBuscarDNI);
            this.Name = "ClientesForm";
            this.Text = "ClientesForm";
            this.Load += new System.EventHandler(this.ClientesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboxBuscarDNI;
        private System.Windows.Forms.Label lblBuscarDNI;
        private System.Windows.Forms.Button btnBuscarDNI;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnAgregarCliente;
    }
}