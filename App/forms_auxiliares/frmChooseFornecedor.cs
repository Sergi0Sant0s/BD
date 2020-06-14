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

namespace App.forms_auxiliares
{
    public partial class frmChooseFornecedor : Form
    {
        private DataGridViewRow _fornecedor;

        public DataGridViewRow Fornecedor { get => _fornecedor; }

        public frmChooseFornecedor()
        {
            InitializeComponent();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            SelectFornecedor();
        }

        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectFornecedor();
        }

        private void SelectFornecedor()
        {
            if (dgvList.Rows.Count > 0)
                _fornecedor = dgvList.SelectedRows[0];
            this.Close();
        }

        private void frmChooseCliente_Load(object sender, EventArgs e)
        {
            dgvList.DataSource = Fornecedores.GetAllFornecedores();
            if (dgvList.Rows.Count == 0)
                btnSelecionar.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
