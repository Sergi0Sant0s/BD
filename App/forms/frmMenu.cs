using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.forms;

namespace App
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Color colDefault = btnClientes.BackColor;
            int trans = 175;
            btnClientes.BackColor = Color.FromArgb(trans, colDefault.R, colDefault.G, colDefault.B);
            btnExit.BackColor = Color.FromArgb(trans, colDefault.R, colDefault.G, colDefault.B);
            btnFornecedores.BackColor = Color.FromArgb(trans, colDefault.R, colDefault.G, colDefault.B);
            btnPecas.BackColor = Color.FromArgb(trans, colDefault.R, colDefault.G, colDefault.B);
            btnServices.BackColor = Color.FromArgb(trans, colDefault.R, colDefault.G, colDefault.B);
            btnVeiculos.BackColor = Color.FromArgb(trans, colDefault.R, colDefault.G, colDefault.B);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Menu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /* END FORM */

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmClient client = new frmClient();
            client.ShowDialog();
            this.Visible = true;
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmServices services = new frmServices();
            services.ShowDialog();
            this.Visible = true;
        }

        private void btnPecas_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmPart parts = new frmPart();
            parts.ShowDialog();
            this.Visible = true;
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmFornecedores fornecedores = new frmFornecedores();
            fornecedores.ShowDialog();
            this.Visible = true;
        }

        private void btnVeiculos_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmVeiculos veiculos = new frmVeiculos();
            veiculos.ShowDialog();
            this.Visible = true;
        }
    }
}
