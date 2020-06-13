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
using App.forms_auxiliares;

namespace App
{
    public partial class frmSubmenu : Form
    {
        public frmSubmenu()
        {
            InitializeComponent();
        }

        private void frmSubmenu_Load(object sender, EventArgs e)
        {
            Color colDefault = btnClientes.BackColor;
            int trans = 175;
            btnClientes.BackColor = Color.FromArgb(trans, colDefault.R, colDefault.G, colDefault.B);
            btnExit.BackColor = Color.FromArgb(trans, colDefault.R, colDefault.G, colDefault.B);
            btnSeccao.BackColor = Color.FromArgb(trans, colDefault.R, colDefault.G, colDefault.B);
            btnFornecedores.BackColor = Color.FromArgb(trans, colDefault.R, colDefault.G, colDefault.B);
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
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmFuncionario cli = new frmFuncionario();
            cli.ShowDialog();
            this.Visible = true;
        }

        private void btnSeccao_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmSeccao sec = new frmSeccao();
            sec.ShowDialog();
            this.Visible = true;
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmFornecedores forn = new frmFornecedores();
            forn.ShowDialog();
            this.Visible = true;
        }

        private void btnTService_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmTService tService = new frmTService();
            tService.ShowDialog();
            this.Visible = true;
        }
    }
}
