using App.forms_auxiliares;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.forms
{
    public partial class frmVeiculos : Form
    {
        int clienteId;
        public frmVeiculos()
        {
            InitializeComponent();
        }


        private void frmVeiculos_Load(object sender, EventArgs e)
        {
            
            dgvList.DataSource = Veiculos.GetAllVeiculos();
            if(dgvList.Rows.Count> 0)
            {
                cbBrand.DataSource = Veiculos.GetAllBrands();
                cbModelo.DataSource = Veiculos.GetAllModels();
                cbYear.DataSource = Veiculos.GetAllYears();
            }
            else
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnNew.Visible = false;
                btnClose.Visible = false;
                btnCancelar.Visible = true;
                btnGuardar.Visible = true;
                tbDefault.SelectedIndex = 1;
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /* END FORM */

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funciona");
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tbMatriculaEdit.Text = string.Empty;
            tbMatriculaEdit.Enabled = true;
            tbAno.Text = string.Empty;
            tbMarca.Text = string.Empty;
            tbModelo.Text = string.Empty;
            tbClienteEdit.Text = string.Empty;
            btnClientes.Enabled = true;
            //
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnNew.Visible = false;
            btnClose.Visible = false;
            btnCancelar.Visible = true;
            btnGuardar.Visible = true;
            tbDefault.SelectedIndex = 1;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            /*Carregar os dados*/
            Edit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            /*Obter o veiculo*/
            if(dgvList.SelectedRows.Count != 0 && MessageBox.Show(string.Format("Tem certeza que deseja eliminar o veiculo com a matricula {0}?", dgvList.SelectedRows[0].Cells[0].Value.ToString()),"Eliminar",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /*Eliminar o veiculo*/

                if(Veiculos.DeleteVeiculo(dgvList.SelectedRows[0].Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Veiculo Eliminado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvList.DataSource = Veiculos.GetAllVeiculos();
                }
                else
                    MessageBox.Show("Não foi possivel eliminadar o veiculo.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count > 0)
            {
                tbMatriculaEdit.Enabled = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnNew.Visible = true;
                btnClose.Visible = true;
                btnCancelar.Visible = false;
                btnGuardar.Visible = false;
                btnClientes.Enabled = false;
                tbDefault.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Não existem veiculos a serem apresentados.\nEsta janela vai ser fechada.", "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
                
        }

        private void tbDefault_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!btnGuardar.Visible && !btnCancelar.Visible && tbDefault.SelectedIndex == 0)
                dgvList.DataSource = Veiculos.GetAllVeiculos();
        }

        private void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void cbModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void tbMatricula_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void tbClient_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            string modelo = cbModelo.SelectedIndex == 0 ? "" : this.cbModelo.GetItemText(this.cbModelo.SelectedItem);
            string marca = cbBrand.SelectedIndex == 0 ? "" : this.cbBrand.GetItemText(this.cbBrand.SelectedItem);
            string year = cbYear.SelectedIndex == 0 ? "" : this.cbYear.GetItemText(this.cbYear.SelectedItem);
            var check = Veiculos.Filter(tbMatricula.Text, marca, modelo, tbClient.Text, year);
            if (check != null)
                dgvList.DataSource = check;
        }

        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            if(tbDefault.SelectedIndex == 0)
            {
                if (dgvList.SelectedRows.Count != 0)
                {
                    tbMatriculaEdit.Text = dgvList.SelectedRows[0].Cells[0].Value.ToString();
                    tbMatriculaEdit.Enabled = false;
                    tbMarca.Text = dgvList.SelectedRows[0].Cells[1].Value.ToString();
                    tbModelo.Text = dgvList.SelectedRows[0].Cells[2].Value.ToString();
                    tbAno.Text = dgvList.SelectedRows[0].Cells[3].Value.ToString();
                    tbClienteEdit.Text = dgvList.SelectedRows[0].Cells[4].Value.ToString();
                    //
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    btnNew.Visible = false;
                    btnClose.Visible = false;
                    btnCancelar.Visible = true;
                    btnGuardar.Visible = true;
                    btnClientes.Enabled = true;
                    btnClientes.Enabled = true;
                    //
                    tbDefault.SelectedIndex = 1;
                }
            }
            else
            {
                tbMatriculaEdit.Enabled = true;
                tbMarca.Enabled = true;
                tbModelo.Enabled = true;
                tbAno.Enabled = true;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnNew.Visible = false;
                btnClose.Visible = false;
                btnCancelar.Visible = true;
                btnGuardar.Visible = true;
                btnClientes.Enabled = true;
                btnClientes.Enabled = true;
            }
            
        }

        private void tbDefault_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (btnGuardar.Visible && btnCancelar.Visible && tbDefault.SelectedIndex == 1)
            {
                e.Cancel = true;
                MessageBox.Show("Esta no modo de edição.\nConclua o processo e volte a tentar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool check = false;
            string matricula = string.Empty;

            foreach (DataGridViewRow row in dgvList.Rows)
                if (row.Cells[0].Value.ToString().Equals(tbMatriculaEdit.Text.ToUpper()))
                {
                    check = true;
                    matricula = tbMatriculaEdit.Text;
                }

            if (!check)
            {
                if (Veiculos.NewVeiculo(tbMatriculaEdit.Text,tbMarca.Text, tbModelo.Text,Convert.ToInt32(tbAno.Text),clienteId))
                    MessageBox.Show("Veiculo adicionado com sucesso.");
                else
                    MessageBox.Show("Não foi possivel adicionar o novo veiculo.");
            }
            else if (matricula != string.Empty)
            {
                if (Veiculos.UpdateVeiculo(matricula,tbMarca.Text, tbModelo.Text, clienteId, Convert.ToInt32(tbAno.Text)))
                    MessageBox.Show("Veiculo atualizado com sucesso.");
                else
                    MessageBox.Show("Não foi possivel atualizar o veiculo.");
            }

            tbMatriculaEdit.Enabled = false;
            btnClientes.Enabled = false;
            tbAno.Enabled = false;
            tbMarca.Enabled = false;
            tbModelo.Enabled = false;
            btnEdit.Visible = true;
            btnNew.Visible = true;
            btnClose.Visible = true;
            btnCancelar.Visible = false;
            btnGuardar.Visible = false;
            tbDefault.SelectedIndex = 0;
        }

        private void tbDefault_Selected(object sender, TabControlEventArgs e)
        {
            if(tbDefault.SelectedIndex == 1 && btnEdit.Visible)
            {
                tbMatriculaEdit.Text = dgvList.SelectedRows[0].Cells[0].Value.ToString();
                tbMarca.Text = dgvList.SelectedRows[0].Cells[1].Value.ToString();
                tbModelo.Text = dgvList.SelectedRows[0].Cells[2].Value.ToString();
                tbAno.Text = dgvList.SelectedRows[0].Cells[3].Value.ToString();
                tbClienteEdit.Text = dgvList.SelectedRows[0].Cells[4].Value.ToString();
                tbMatriculaEdit.Enabled = false;
                //
            }
            
            if(!btnEdit.Visible || !btnNew.Visible)
            {
                tbAno.Enabled = true;
                tbMarca.Enabled = true;
                tbModelo.Enabled = true;
                btnClientes.Enabled = true;
            }
            else
            {
                tbAno.Enabled = false;
                tbMarca.Enabled = false;
                tbModelo.Enabled = false;
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmChooseCliente choose = new frmChooseCliente();
            choose.ShowDialog();
            if (choose.Cliente != null)
            {
                clienteId = Convert.ToInt32(choose.Cliente.Cells["id"].Value);
                tbClienteEdit.Text = choose.Cliente.Cells["nome"].Value.ToString();
            }
        }

        private void tbAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }
    }
}
