namespace Cliente.Veterinaria
{
    partial class LoginForm
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tboxPass = new System.Windows.Forms.TextBox();
            this.tboxName = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblTextoGuia = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(160, 43);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(161, 25);
            this.lblTitulo.TabIndex = 9;
            this.lblTitulo.Text = "Inicio de sesión";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(130, 210);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(61, 13);
            this.lblPass.TabIndex = 8;
            this.lblPass.Text = "Contraseña";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(130, 128);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(43, 13);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "Usuario";
            // 
            // tboxPass
            // 
            this.tboxPass.Location = new System.Drawing.Point(124, 226);
            this.tboxPass.Name = "tboxPass";
            this.tboxPass.PasswordChar = '*';
            this.tboxPass.Size = new System.Drawing.Size(233, 20);
            this.tboxPass.TabIndex = 6;
            // 
            // tboxName
            // 
            this.tboxName.Location = new System.Drawing.Point(124, 144);
            this.tboxName.Name = "tboxName";
            this.tboxName.Size = new System.Drawing.Size(233, 20);
            this.tboxName.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(272, 291);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Ingresar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblTextoGuia
            // 
            this.lblTextoGuia.AutoSize = true;
            this.lblTextoGuia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoGuia.Location = new System.Drawing.Point(109, 82);
            this.lblTextoGuia.Name = "lblTextoGuia";
            this.lblTextoGuia.Size = new System.Drawing.Size(263, 15);
            this.lblTextoGuia.TabIndex = 11;
            this.lblTextoGuia.Text = "A continuación crearas tu usuario y contraseña:";
            this.lblTextoGuia.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 352);
            this.Controls.Add(this.lblTextoGuia);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.tboxPass);
            this.Controls.Add(this.tboxName);
            this.MaximumSize = new System.Drawing.Size(517, 391);
            this.MinimumSize = new System.Drawing.Size(517, 391);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox tboxPass;
        private System.Windows.Forms.TextBox tboxName;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblTextoGuia;
    }
}