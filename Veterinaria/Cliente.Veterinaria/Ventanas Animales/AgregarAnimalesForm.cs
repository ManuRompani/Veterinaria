using Services.Veterinaria.DAOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente.Veterinaria
{
    public partial class AgregarAnimalesForm : Form
    {
        public AgregarAnimalesForm()
        {
            InitializeComponent();
        }

        private void AgregarAnimalesForm_Load(object sender, EventArgs e)
        {
            ClienteDAO clienteDao = new ClienteDAO();
            //EspecieDAO especieDao = new EspecieDAO();

           // cmbCliente.DataSource = clienteDao.getByDNI();
        }
    }
}
