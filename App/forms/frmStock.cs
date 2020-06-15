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
    public partial class frmStock : Form
    {
        private int fornecedorId = -1;
        public DataTable Stocks { get; set; }
        private DataRow _sPeca;
        private DataRow SPeca
        {
            get { return _sPeca; }
            set
            {
                _sPeca = value;
                tbIdPeca.Text = value.ItemArray[0].ToString();
                tbPeca.Text = value.ItemArray[1].ToString();
                tbMarcaPeca.Text = value.ItemArray[2].ToString();
                tbModeloPeca.Text = value.ItemArray[3].ToString();
            }
        }

        public frmStock(int id)
        {
            InitializeComponent();
            dgvList.AutoGenerateColumns = false;
            SPeca = Peca.GetPecaById(id);
        }


        private void frmVeiculos_Load(object sender, EventArgs e)
        {

            UpdateGrid();
            if (dgvList.Rows.Count == 0)
            {
                btnEdit.Visible = false;
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
            tbId.Text = Stock.GetNewId().ToString();
            tbQuantidade.Enabled = true;
            tbQuantidade.Text = string.Empty;
            tbQuantidade.Enabled = true;
            tbFornecedores.Text = string.Empty;
            tbPCusto.Text = string.Empty;
            tbPVenda.Text = string.Empty;
            btnFornecedores.Enabled = true;
            //
            btnEdit.Visible = false;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count > 0)
            {
                btnFornecedores.Enabled = false;
                btnEdit.Visible = true;
                btnNew.Visible = true;
                btnClose.Visible = true;
                btnCancelar.Visible = false;
                btnGuardar.Visible = false;
                tbDefault.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Não existem veiculos a serem apresentados.\nEsta janela vai ser fechada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void tbDefault_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!btnGuardar.Visible && !btnCancelar.Visible && tbDefault.SelectedIndex == 0)
                UpdateGrid();
        }

        private void Filter()
        {
            int fornecedores = cbFornecedorSearch.SelectedIndex == 0 ? -1 : Convert.ToInt32(this.cbFornecedorSearch.GetItemText(this.cbFornecedorSearch.SelectedValue));
            var check = Stock.Filter(Convert.ToInt32(SPeca.ItemArray[0]),fornecedores);
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
                    tbQuantidade.Text = dgvList.SelectedRows[0].Cells[1].Value.ToString();
                    tbFornecedores.Text = dgvList.SelectedRows[0].Cells[2].Value.ToString();
                    tbPCusto.Text = dgvList.SelectedRows[0].Cells[3].Value.ToString() + " €";
                    tbPVenda.Text = dgvList.SelectedRows[0].Cells[4].Value.ToString() + " €";
                    //
                    btnEdit.Visible = false;
                    btnNew.Visible = false;
                    btnClose.Visible = false;
                    btnCancelar.Visible = true;
                    btnGuardar.Visible = true;
                    btnFornecedores.Enabled = true;
                    //
                    tbDefault.SelectedIndex = 1;
                }
            }
            else
            {
                btnFornecedores.Enabled = true;
                tbPCusto.Enabled = true;
                tbPVenda.Enabled = true;
                btnEdit.Visible = false;
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
                    id = Convert.ToInt32(tbId.Text);
                }

            if (!check)
            {
                if (Stock.NewStock(Convert.ToInt32(SPeca.ItemArray[0]), Convert.ToInt32(tbQuantidade.Text), fornecedorId, Convert.ToDouble(tbPCusto.Text), Convert.ToDouble(tbPVenda.Text)))
                    MessageBox.Show("Stock adicionado com sucesso.");
                else
                    MessageBox.Show("Não foi possivel adicionar a novo stock.");
            }
            else if (id != -1)
            {
                if (Stock.UpdateStock(id, GetFornecedorIdByStockId(id), tbPVenda.Text.Replace(" €", ""), tbPCusto.Text.Replace(" €", "")))
                    MessageBox.Show("Stock atualizado com sucesso.");
                else
                    MessageBox.Show("Não foi possivel atualizar o stock.");
            }

            tbQuantidade.Enabled = false;
            btnFornecedores.Enabled = false;
            tbPCusto.Enabled = false;
            tbPVenda.Enabled = false;
            btnEdit.Visible = true;
            btnNew.Visible = true;
            btnClose.Visible = true;
            btnCancelar.Visible = false;
            btnGuardar.Visible = false;
            tbDefault.SelectedIndex = 0;
        }

        private void tbDefault_Selected(object sender, TabControlEventArgs e)
        {
            if (tbDefault.SelectedIndex == 1 && btnEdit.Visible)
            {
                tbId.Text = dgvList.SelectedRows[0].Cells[0].Value.ToString();
                tbQuantidade.Text = dgvList.SelectedRows[0].Cells[1].Value.ToString();
                tbFornecedores.Text = dgvList.SelectedRows[0].Cells[2].Value.ToString();
                tbPCusto.Text = dgvList.SelectedRows[0].Cells[3].Value.ToString();
                tbPVenda.Text = dgvList.SelectedRows[0].Cells[4].Value.ToString();
                //
            }

            if (!btnEdit.Visible || !btnNew.Visible)
            {
                tbPCusto.Enabled = true;
                tbPVenda.Enabled = true;
            }
            else
            {
                tbPCusto.Enabled = false;
                tbPVenda.Enabled = false;
            }
        }
        private void UpdateGrid()
        {
            if(SPeca != null)
            {
                Stocks = Stock.GetAllStocks(Convert.ToInt32(SPeca.ItemArray[0]));
                dgvList.DataSource = Stocks;
            }
            if (dgvList.Rows.Count > 0)
            {
                DataTable table = Stock.GetFornecedoresByPecaId(Convert.ToInt32(SPeca.ItemArray[0]));
                DataRow row = table.NewRow();
                row["id"] = "-1";
                row["nome"] = "Todos";
                table.Rows.InsertAt(row, 0);
                cbFornecedorSearch.DataSource = table;
            }
        }

        private void cbFornecedorSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void tbQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&(e.KeyChar != '.'))
                e.Handled = true;

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        public int GetFornecedorIdByStockId(int id)
        {
            foreach (DataRow row in Stocks.Rows)
                if (Convert.ToInt32(row.ItemArray[0]) == id)
                    return Convert.ToInt32(row.ItemArray[5]);

            return -1;
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            frmChooseFornecedor choose = new frmChooseFornecedor();
            choose.ShowDialog();
            if(choose.Fornecedor != null)
            {
                fornecedorId = Convert.ToInt32(choose.Fornecedor.Cells["id"].Value);
                tbFornecedores.Text = choose.Fornecedor.Cells["nome"].Value.ToString();
            }
        }
    }
}
