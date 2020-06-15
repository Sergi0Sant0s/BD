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
    public partial class frmChooseVeiculo : Form
    {
        private DataGridViewRow _veiculo;

        public DataGridViewRow Veiculo { get => _veiculo; }

        public frmChooseVeiculo()
        {
            InitializeComponent();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            SelectCliente();
        }

        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectCliente();
        }

        private void SelectCliente()
        {
            if (dgvList.Rows.Count > 0)
                _veiculo = dgvList.SelectedRows[0];
            this.Close();
        }

        private void frmChooseCliente_Load(object sender, EventArgs e)
        {
            dgvList.DataSource = Veiculos.GetAllVeiculos();
            if (dgvList.Rows.Count == 0)
                btnSelecionar.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbCliente_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void tbMatricula_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            dgvList.DataSource = Veiculos.Filter(tbMatricula.Text, "", "", tbCliente.Text, "");
        }
    }
}
