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
    public partial class frmServico : Form
    {
        public DataTable Serv { get; set; }
        public frmServico()
        {
            InitializeComponent();
            dgvList.AutoGenerateColumns = false;
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
            //Reset Text
            tbId.Text = Services.GetNewId().ToString();
            tbMatricula.Text = string.Empty;
            tbCreatedAt.Text = string.Empty;
            cbFuncionario.SelectedIndex = 0;
            cbTService.SelectedIndex = 0;
            tbEstadoReparacao.Text = string.Empty;
            tbDescReparacao.Text = string.Empty;
            tbDescAvaria.Text = string.Empty;

            //Enable
            tbDescAvaria.Enabled = true;
            cbFuncionario.Enabled = true;
            cbTService.Enabled = true;
            btnVeiculos.Enabled = true;
            //Options Buttons
            btnIService.Enabled = false;
            btnFServico.Enabled = false;
            btnPecas.Enabled = false;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            /*Obter o veiculo*/
            if (dgvList.SelectedRows.Count != 0 && MessageBox.Show(string.Format("Cliente: {0}\n\nTem certeza que deseja eliminar o cliente?", dgvList.SelectedRows[0].Cells[1].Value.ToString()), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /*Eliminar o veiculo*/

                if (Clients.DeleteCliente(Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value.ToString())))
                {
                    MessageBox.Show("Cliente eliminado com sucesso.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateGrid();
                }
                else
                    MessageBox.Show("Não foi possivel eliminadar o cliente.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count > 0)
            {
                btnPecas.Enabled = true;
                btnFinalizar.Visible = false;
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
                    UpdateProcess(Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value));
                    //
                    cbFuncionario.Enabled = true;
                    cbTService.Enabled = true;
                    tbDescAvaria.Enabled = true;
                    //
                    btnVeiculos.Enabled = true;
                    btnIService.Enabled = false;
                    btnFServico.Enabled = false;
                    btnPecas.Enabled = false;
                    btnEdit.Visible = false;
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
                btnVeiculos.Enabled = true;
                cbTService.Enabled = true;
                cbFuncionario.Enabled = true;
                tbDescAvaria.Enabled = true;
                //
                btnEdit.Visible = false;
                btnNew.Visible = false;
                btnClose.Visible = false;
                btnCancelar.Visible = true;
                btnGuardar.Visible = true;
            }
        }

        private void tbDefault_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (btnCancelar.Visible && tbDefault.SelectedIndex == 1 && (btnFinalizar.Visible || btnGuardar.Visible))
            {
                e.Cancel = true;
                MessageBox.Show("Esta no modo de edição.\nConclua o processo e volte a tentar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int func = Convert.ToInt32(cbFuncionario.GetItemText(this.cbFuncionario.SelectedValue));
            int tServ = Convert.ToInt32(cbTService.GetItemText(this.cbTService.SelectedValue));
                      

            if (tbId.Text.Equals(Services.GetNewId().ToString()))
            {
                if (Services.NewServico(tServ, func, tbMatricula.Text, tbDescAvaria.Text,1, DateTime.Now))
                  MessageBox.Show("Serviço adicionado com sucesso.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                  MessageBox.Show("Não foi possivel adicionar o novo serviço.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Services.UpdateServico(Convert.ToInt32(tbId.Text),tServ,func,tbMatricula.Text,tbDescAvaria.Text))
                  MessageBox.Show("Serviço atualizado com sucesso.","Resultado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                else
                  MessageBox.Show("Não foi possivel atualizar o serviço.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnEdit.Visible = true;
            btnNew.Visible = true;
            btnClose.Visible = true;
            btnCancelar.Visible = false;
            btnGuardar.Visible = false;
            UpdateGrid();
            tbDefault.SelectedIndex = 0;
        }

        private void tbDefault_Selected(object sender, TabControlEventArgs e)
        {
            if (tbDefault.SelectedIndex == 1 && btnEdit.Visible)
            {
                UpdateProcess(Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value));
                //
            }

            if (!btnEdit.Visible || !btnNew.Visible)
            {
                btnVeiculos.Enabled = true;
                cbTService.Enabled = true;
                cbFuncionario.Enabled = true;
                tbDescAvaria.Enabled = true;
            }
            else
            {
                btnVeiculos.Enabled = false;
                cbTService.Enabled = false;
                cbFuncionario.Enabled = false;
                tbDescAvaria.Enabled = false;
            }
        }

        private void UpdateGrid()
        {
            Serv = Services.GetAllServicos();
            dgvList.DataSource = Serv;
            if (dgvList.Rows.Count > 0)
            {
                //Reset Button
                btnPecas.Enabled = true;
                //State
                DataTable state = EstadoReparacao.GetAllStates();
                DataRow rState = state.NewRow();
                rState["id"] = "-1";
                rState["nome"] = "Todos";
                state.Rows.InsertAt(rState, 0);
                cbStateSearch.DataSource = state;

                //Tipo de Servico
                DataTable tservice = TipoServico.GetAllServicos();
                DataRow rtService = tservice.NewRow();
                rtService["id"] = "-1";
                rtService["nome"] = "Todos";
                tservice.Rows.InsertAt(rtService, 0);
                cbTService.DataSource = TipoServico.GetAllServicos();
                cbTServicoSearch.DataSource = tservice;

                //Funcionario
                DataTable func = Funcionario.GetAllFuncionarios();
                DataRow rfunc = func.NewRow();
                rfunc["id"] = "-1";
                rfunc["nome"] = "Todos";
                func.Rows.InsertAt(rfunc, 0);
                cbFuncionario.DataSource = Funcionario.GetAllFuncionarios();
                cbFuncionarioSearch.DataSource = func;
            }

            if (dgvList.SelectedRows[0].Cells[4].Value.ToString() == "Finalizado")
            {
                btnFServico.Enabled = false;
                btnIService.Enabled = false;
            }
            //
            if (dgvList.SelectedRows[0].Cells[4].Value.ToString() == "Em reparacao")
                btnIService.Enabled = false;

            if (dgvList.SelectedRows[0].Cells[4].Value.ToString() != "Em reparacao" && dgvList.SelectedRows[0].Cells[4].Value.ToString() != "Finalizado")
            {
                btnFServico.Enabled = false;
                btnIService.Enabled = true;
            }

            if (dgvList.SelectedRows[0].Cells[4].Value.ToString() == "Em reparacao" && dgvList.SelectedRows[0].Cells[4].Value.ToString() != "Finalizado")
            {
                btnFServico.Enabled = true;
                btnIService.Enabled = false;
            }
        }

        private void btnFServico_Click(object sender, EventArgs e)
        {
            UpdateProcess(Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value));
            tbDefault.SelectedIndex = 1;
            tbDescReparacao.Enabled = true;
            btnFinalizar.Visible = true;
            btnCancelar.Visible = true;
            //
            btnNew.Visible = false;
            btnEdit.Visible = false;
            btnNew.Visible = false;
            btnClose.Visible = false;
            btnGuardar.Visible = false;
            btnFServico.Enabled = false;
            btnVeiculos.Enabled = false;
            cbTService.Enabled = false;
            cbFuncionario.Enabled = false;
            tbDescAvaria.Enabled = false;
            btnPecas.Enabled = false;
        }

        private void btnPecas_Click(object sender, EventArgs e)
        {

        }

        private void btnIService_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Matricula: {0}\n\nTem certeza que deseja iniciar serviço neste carro?", dgvList.SelectedRows[0].Cells[3].Value.ToString()), "Verificação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Services.IniciarServico(Convert.ToInt32(dgvList.SelectedRows[0].Cells[0].Value)))
                {
                    MessageBox.Show("Serviço iniciado com sucesso.");
                    UpdateGrid();
                }
                else
                    MessageBox.Show("Não foi possivel iniciar o serviço.");
            }

        }

        private void UpdateProcess(int id)
        {
            tbId.Text = id.ToString();
            foreach (DataRow row in Serv.Rows)
            {
                if (Convert.ToInt32(row["id"]) == id)
                {
                    cbTService.SelectedIndex = cbTService.FindStringExact(row["tservice"].ToString());
                    cbFuncionario.SelectedIndex = cbFuncionario.FindStringExact(row["funcionario"].ToString());
                    tbMatricula.Text = dgvList.SelectedRows[0].Cells[3].Value.ToString();
                    tbCreatedAt.Text = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(row["created_at"].ToString()));
                    tbDescAvaria.Text = row["descricao"].ToString();
                    tbEstadoReparacao.Text = row["estado"].ToString();
                    if (row["data_inicio"].ToString() != string.Empty) tbIService.Text = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(row["data_inicio"].ToString()));
                    else tbIService.Text = "";
                    if (row["data_fim"].ToString() != string.Empty) tbFService.Text = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(row["data_fim"].ToString()));
                    else tbFService.Text = "";
                }
            }

        }

        private void btnVeiculos_Click(object sender, EventArgs e)
        {
            frmChooseVeiculo choose = new frmChooseVeiculo();
            choose.ShowDialog();
            if (choose.Veiculo != null)
                tbMatricula.Text = choose.Veiculo.Cells[0].Value.ToString();
        }

        private void dgvList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvList.SelectedRows[0].Cells[4].Value.ToString() == "Finalizado")
            {
                btnFServico.Enabled = false;
                btnIService.Enabled = false;
            }
            //
            if (dgvList.SelectedRows[0].Cells[4].Value.ToString() == "Em reparacao")
                btnIService.Enabled = false;

            if (dgvList.SelectedRows[0].Cells[4].Value.ToString() != "Em reparacao" && dgvList.SelectedRows[0].Cells[4].Value.ToString() != "Finalizado")
            {
                btnFServico.Enabled = false;
                btnIService.Enabled = true;
            }

            if (dgvList.SelectedRows[0].Cells[4].Value.ToString() == "Em reparacao" && dgvList.SelectedRows[0].Cells[4].Value.ToString() != "Finalizado")
            {
                btnFServico.Enabled = true;
                btnIService.Enabled = false;
            }
        }

        private void cbStateSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void cbTServicoSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void cbFuncionarioSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void tbMatriculaSearch_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            string tipoServico = cbTServicoSearch.SelectedIndex == 0 ? "" : this.cbTServicoSearch.GetItemText(this.cbTServicoSearch.SelectedValue);
            string estado = cbStateSearch.SelectedIndex == 0 ? "" : this.cbStateSearch.GetItemText(this.cbStateSearch.SelectedValue);
            string funcionario = cbFuncionarioSearch.SelectedIndex == 0 ? "" : this.cbFuncionarioSearch.GetItemText(this.cbFuncionarioSearch.SelectedValue);
            var check = Services.Filter(tbMatriculaSearch.Text, tipoServico, estado, funcionario);
            if (check != null)
                dgvList.DataSource = check;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (Services.FinalizarServico(Convert.ToInt32(tbId.Text),tbDescReparacao.Text))
                MessageBox.Show("Serviço finalizado com sucesso.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Não foi possivel finalizar o serviço.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error);

            btnCancelar.PerformClick();
        }
    }
}
