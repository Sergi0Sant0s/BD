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
    public partial class frmPeca : Form
    {
        public frmPeca()
        {
            InitializeComponent();
        }


        private void frmVeiculos_Load(object sender, EventArgs e)
        {

            UpdateGrid();
            if(dgvList.Rows.Count == 0)
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
            tbNome.Text = string.Empty;
            tbNome.Enabled = true;
            tbMarca.Text = string.Empty;
            tbModelo.Text = string.Empty;
            tbDescricao.Text = string.Empty;
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
            if(dgvList.SelectedRows.Count != 0 && MessageBox.Show(string.Format("Peça: {0}\n\nTem certeza que deseja eliminar esta peça?", dgvList.SelectedRows[0].Cells[0].Value.ToString()),"Eliminar",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /*Eliminar o veiculo*/

                if(Peca.DeletePeca(Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value.ToString())))
                {
                    MessageBox.Show("Peça eliminada com sucesso.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateGrid();
                }
                else
                    MessageBox.Show("Não foi possivel eliminadar a peça.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count > 0)
            {
                tbNome.Enabled = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnNew.Visible = true;
                btnClose.Visible = true;
                btnCancelar.Visible = false;
                btnGuardar.Visible = false;
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
                UpdateGrid();
        }

        private void Filter()
        {
            string modelo = cbModeloSearch.SelectedIndex == 0 ? "" : this.cbModeloSearch.GetItemText(this.cbModeloSearch.SelectedItem);
            string marca = cbMarcaSearch.SelectedIndex == 0 ? "" : this.cbMarcaSearch.GetItemText(this.cbMarcaSearch.SelectedItem);
            var check = Peca.Filter(tbNomeSearch.Text, marca, modelo);
            if (check != null)
                dgvList.DataSource = check;
        }

        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            if (tbDefault.SelectedIndex == 0)
            {
                if (dgvList.SelectedRows.Count != 0)
                {
                    tbId.Text = dgvList.SelectedRows[0].Cells[0].Value.ToString();
                    tbNome.Text = dgvList.SelectedRows[0].Cells[1].Value.ToString();
                    tbMarca.Text = dgvList.SelectedRows[0].Cells[2].Value.ToString();
                    tbModelo.Text = dgvList.SelectedRows[0].Cells[3].Value.ToString();
                    tbDescricao.Text = dgvList.SelectedRows[0].Cells[4].Value.ToString();
                    //
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    btnNew.Visible = false;
                    btnClose.Visible = false;
                    btnCancelar.Visible = true;
                    btnGuardar.Visible = true;
                    //
                    tbDefault.SelectedIndex = 1;
                }
            }
            else
            {
                tbNome.Enabled = true;
                tbMarca.Enabled = true;
                tbModelo.Enabled = true;
                tbDescricao.Enabled = true;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnNew.Visible = false;
                btnClose.Visible = false;
                btnCancelar.Visible = true;
                btnGuardar.Visible = true;
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
            int id = -1;

            foreach (DataGridViewRow row in dgvList.Rows)
                if (row.Cells[0].Value.ToString().Equals(tbId.Text))
                {
                    check = true;
                    id = Convert.ToInt32(row.Cells[0].Value);
                }

            if (!check)
            {
                if (Peca.NewPeca(tbNome.Text, tbMarca.Text,tbModelo.Text,tbDescricao.Text))
                    MessageBox.Show("Peça adicionada com sucesso.");
                else
                    MessageBox.Show("Não foi possivel adicionar a nova peça.");
            }
            else if (id != -1)
            {
                if (Peca.UpdatePeca(id, tbNome.Text, tbMarca.Text,tbModelo.Text,tbDescricao.Text))
                    MessageBox.Show("Peça atualizada com sucesso.");
                else
                    MessageBox.Show("Não foi possivel atualizar a peça.");
            }

            tbNome.Enabled = false;
            tbMarca.Enabled = false;
            tbModelo.Enabled = false;
            tbDescricao.Enabled = false;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
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
                tbId.Text = dgvList.SelectedRows[0].Cells[0].Value.ToString();
                tbNome.Text = dgvList.SelectedRows[0].Cells[1].Value.ToString();
                tbMarca.Text = dgvList.SelectedRows[0].Cells[2].Value.ToString();
                tbModelo.Text = dgvList.SelectedRows[0].Cells[3].Value.ToString();
                tbDescricao.Text = dgvList.SelectedRows[0].Cells[4].Value.ToString();
                tbNome.Enabled = false;
                //
            }
            
            if(!btnEdit.Visible || !btnNew.Visible)
            {
                tbNome.Enabled = true;
                tbMarca.Enabled = true;
                tbModelo.Enabled = true;
                tbDescricao.Enabled = true;
            }
            else
            {
                tbNome.Enabled = false;
                tbMarca.Enabled = false;
                tbModelo.Enabled = false;
                tbDescricao.Enabled = false;
            }
        }
        private void UpdateGrid()
        {
            dgvList.DataSource = Peca.GetAllPecas();
            if (dgvList.Rows.Count > 0)
            {
                cbMarcaSearch.DataSource = Peca.GetAllBrands();
                cbModeloSearch.DataSource = Peca.GetAllModels();
            }
        }

        private void tbNomeSearch_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void cbMarcaSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void cbModeloSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            if(dgvList.Rows.Count> 0)
            {
                this.Visible = false;
                frmStock stock = new frmStock(Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value));
                stock.ShowDialog();
                this.Visible = true;
            }
            
        }
    }
}
