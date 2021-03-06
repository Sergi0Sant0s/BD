﻿using Service;
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
    public partial class frmFornecedores : Form
    {
        public frmFornecedores()
        {
            InitializeComponent();
        }


        private void frmVeiculos_Load(object sender, EventArgs e)
        {

            UpdateGrid();
            if (dgvList.Rows.Count> 0)
            {
                //cbBrand.DataSource = Veiculos.GetAllBrands();
                //cbModelo.DataSource = Veiculos.GetAllModels();
                //cbYear.DataSource = Veiculos.GetAllYears();
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
            tbId.Text = Fornecedores.GetNewId().ToString();
            tbId.Enabled = true;
            tbNome.Text = string.Empty;
            tbTelefone.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbMorada.Text = string.Empty;
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
            if(dgvList.SelectedRows.Count != 0 && MessageBox.Show(string.Format("Fornecedor: {0}\n\nTem certeza que deseja eliminar o veiculo com a matricula {0}?", dgvList.SelectedRows[0].Cells[1].Value.ToString()),"Eliminar",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /*Eliminar o veiculo*/

                if(Fornecedores.DeleteFornecedor(Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value.ToString())))
                {
                    MessageBox.Show("Fornecedor eliminado com sucesso.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateGrid();
                }
                else
                    MessageBox.Show("Não foi possivel eliminadar o fornecedor.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count > 0)
            {
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
                MessageBox.Show("Não existem fornecedores a serem apresentados.\nEsta janela vai ser fechada.", "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
                
        }

        private void tbDefault_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!btnGuardar.Visible && !btnCancelar.Visible && tbDefault.SelectedIndex == 0)
                UpdateGrid();
        }

        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            if (dgvList.SelectedRows.Count != 0)
            {
                tbId.Text = dgvList.SelectedRows[0].Cells[0].Value.ToString();
                tbNome.Text = dgvList.SelectedRows[0].Cells[1].Value.ToString();
                tbTelefone.Text = dgvList.SelectedRows[0].Cells[2].Value.ToString();
                tbEmail.Text = dgvList.SelectedRows[0].Cells[3].Value.ToString();
                tbMorada.Text = dgvList.SelectedRows[0].Cells[4].Value.ToString();
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
                if (Fornecedores.NewFornecedor(tbNome.Text, tbTelefone.Text, tbEmail.Text, tbMorada.Text))
                    MessageBox.Show("Fornecedor adicionado com sucesso.");
                else
                    MessageBox.Show("Não foi possivel adicionar o novo fornecedor.");
            }
            else if (id != -1)
            {
                if (Fornecedores.UpdateFornecedor(id, tbNome.Text, tbTelefone.Text, tbEmail.Text, tbMorada.Text))
                    MessageBox.Show("Fornecedor atualizado com sucesso.");
                else
                    MessageBox.Show("Não foi possivel atualizar o fornecedor.");
            }

            //TextBox's
            tbNome.Enabled = false;
            tbTelefone.Enabled = false;
            tbMorada.Enabled = false;
            tbEmail.Enabled = false;
            //Buttons
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
                tbTelefone.Text = dgvList.SelectedRows[0].Cells[2].Value.ToString();
                tbEmail.Text = dgvList.SelectedRows[0].Cells[3].Value.ToString();
                tbMorada.Text = dgvList.SelectedRows[0].Cells[4].Value.ToString();
                tbId.Enabled = false;
                //
            }
            
            if(!btnEdit.Visible || !btnNew.Visible)
            {
                tbNome.Enabled = true;
                tbTelefone.Enabled = true;
                tbEmail.Enabled = true;
                tbMorada.Enabled = true;
            }
            else
            {
                tbNome.Enabled = false;
                tbTelefone.Enabled = false;
                tbEmail.Enabled = false;
                tbMorada.Enabled = false;
            }
        }

        private void UpdateGrid()
        {
            dgvList.DataSource = Fornecedores.GetAllFornecedores();
        }

        private void tbNomeSearch_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void tbMoradaSearch_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            var check = Fornecedores.Filter(tbNomeSearch.Text,tbMoradaSearch.Text);
            if (check != null)
                dgvList.DataSource = check;
        }
    }
}
