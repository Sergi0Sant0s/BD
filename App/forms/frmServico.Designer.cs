namespace App.forms
{
    partial class frmServico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServico));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFinalizar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFServico = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIService = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPecas = new System.Windows.Forms.ToolStripMenuItem();
            this.tabProcess = new System.Windows.Forms.TabPage();
            this.tbDescReparacao = new System.Windows.Forms.RichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbDescAvaria = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbEstadoReparacao = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbFService = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbIService = new System.Windows.Forms.TextBox();
            this.cbFuncionario = new System.Windows.Forms.ComboBox();
            this.cbTService = new System.Windows.Forms.ComboBox();
            this.btnVeiculos = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tbCreatedAt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMatricula = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabList = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.cbFuncionarioSearch = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTServicoSearch = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbStateSearch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMatriculaSearch = new System.Windows.Forms.TextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Func = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Criado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbDefault = new System.Windows.Forms.TabControl();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabProcess.SuspendLayout();
            this.tabList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.tbDefault.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnGuardar,
            this.btnFinalizar,
            this.btnCancelar,
            this.btnClose,
            this.btnFServico,
            this.btnIService,
            this.btnPecas});
            this.menuStrip1.Location = new System.Drawing.Point(0, 37);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(933, 37);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // btnNew
            // 
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(48, 33);
            this.btnNew.Text = "Novo";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(49, 33);
            this.btnEdit.Text = "Editar";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(61, 33);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(62, 33);
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.Visible = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(65, 33);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnClose
            // 
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 33);
            this.btnClose.Text = "Fechar";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFServico
            // 
            this.btnFServico.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFServico.Name = "btnFServico";
            this.btnFServico.Size = new System.Drawing.Size(103, 33);
            this.btnFServico.Text = "Finalizar Serviço";
            this.btnFServico.Click += new System.EventHandler(this.btnFServico_Click);
            // 
            // btnIService
            // 
            this.btnIService.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnIService.Name = "btnIService";
            this.btnIService.Size = new System.Drawing.Size(92, 33);
            this.btnIService.Text = "Iniciar Serviço";
            this.btnIService.Click += new System.EventHandler(this.btnIService_Click);
            // 
            // btnPecas
            // 
            this.btnPecas.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPecas.Name = "btnPecas";
            this.btnPecas.Size = new System.Drawing.Size(49, 33);
            this.btnPecas.Text = "Peças";
            this.btnPecas.Click += new System.EventHandler(this.btnPecas_Click);
            // 
            // tabProcess
            // 
            this.tabProcess.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabProcess.Controls.Add(this.tbDescReparacao);
            this.tabProcess.Controls.Add(this.label15);
            this.tabProcess.Controls.Add(this.tbDescAvaria);
            this.tabProcess.Controls.Add(this.label14);
            this.tabProcess.Controls.Add(this.tbEstadoReparacao);
            this.tabProcess.Controls.Add(this.label12);
            this.tabProcess.Controls.Add(this.tbFService);
            this.tabProcess.Controls.Add(this.label7);
            this.tabProcess.Controls.Add(this.tbIService);
            this.tabProcess.Controls.Add(this.cbFuncionario);
            this.tabProcess.Controls.Add(this.cbTService);
            this.tabProcess.Controls.Add(this.btnVeiculos);
            this.tabProcess.Controls.Add(this.label11);
            this.tabProcess.Controls.Add(this.tbCreatedAt);
            this.tabProcess.Controls.Add(this.label6);
            this.tabProcess.Controls.Add(this.label5);
            this.tabProcess.Controls.Add(this.tbMatricula);
            this.tabProcess.Controls.Add(this.tbId);
            this.tabProcess.Controls.Add(this.label4);
            this.tabProcess.Controls.Add(this.label3);
            this.tabProcess.Controls.Add(this.label2);
            this.tabProcess.Location = new System.Drawing.Point(4, 25);
            this.tabProcess.Name = "tabProcess";
            this.tabProcess.Size = new System.Drawing.Size(925, 351);
            this.tabProcess.TabIndex = 1;
            this.tabProcess.Text = "Processo";
            // 
            // tbDescReparacao
            // 
            this.tbDescReparacao.Enabled = false;
            this.tbDescReparacao.Location = new System.Drawing.Point(324, 208);
            this.tbDescReparacao.Name = "tbDescReparacao";
            this.tbDescReparacao.Size = new System.Drawing.Size(282, 72);
            this.tbDescReparacao.TabIndex = 23;
            this.tbDescReparacao.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(321, 192);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(121, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Descrição da reparação";
            // 
            // tbDescAvaria
            // 
            this.tbDescAvaria.Enabled = false;
            this.tbDescAvaria.Location = new System.Drawing.Point(30, 208);
            this.tbDescAvaria.Name = "tbDescAvaria";
            this.tbDescAvaria.Size = new System.Drawing.Size(282, 72);
            this.tbDescAvaria.TabIndex = 21;
            this.tbDescAvaria.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(649, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Estado da Reparação";
            // 
            // tbEstadoReparacao
            // 
            this.tbEstadoReparacao.Enabled = false;
            this.tbEstadoReparacao.Location = new System.Drawing.Point(765, 44);
            this.tbEstadoReparacao.Name = "tbEstadoReparacao";
            this.tbEstadoReparacao.Size = new System.Drawing.Size(114, 20);
            this.tbEstadoReparacao.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(639, 263);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Fim de Serviço";
            // 
            // tbFService
            // 
            this.tbFService.Enabled = false;
            this.tbFService.Location = new System.Drawing.Point(755, 260);
            this.tbFService.Name = "tbFService";
            this.tbFService.Size = new System.Drawing.Size(114, 20);
            this.tbFService.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(639, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Inicio de Serviço";
            // 
            // tbIService
            // 
            this.tbIService.Enabled = false;
            this.tbIService.Location = new System.Drawing.Point(755, 234);
            this.tbIService.Name = "tbIService";
            this.tbIService.Size = new System.Drawing.Size(114, 20);
            this.tbIService.TabIndex = 15;
            // 
            // cbFuncionario
            // 
            this.cbFuncionario.DisplayMember = "nome";
            this.cbFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuncionario.Enabled = false;
            this.cbFuncionario.FormattingEnabled = true;
            this.cbFuncionario.Location = new System.Drawing.Point(100, 93);
            this.cbFuncionario.Name = "cbFuncionario";
            this.cbFuncionario.Size = new System.Drawing.Size(135, 21);
            this.cbFuncionario.TabIndex = 14;
            this.cbFuncionario.ValueMember = "id";
            // 
            // cbTService
            // 
            this.cbTService.DisplayMember = "nome";
            this.cbTService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTService.Enabled = false;
            this.cbTService.FormattingEnabled = true;
            this.cbTService.Location = new System.Drawing.Point(100, 67);
            this.cbTService.Name = "cbTService";
            this.cbTService.Size = new System.Drawing.Size(135, 21);
            this.cbTService.TabIndex = 13;
            this.cbTService.ValueMember = "id";
            // 
            // btnVeiculos
            // 
            this.btnVeiculos.Enabled = false;
            this.btnVeiculos.Location = new System.Drawing.Point(239, 120);
            this.btnVeiculos.Name = "btnVeiculos";
            this.btnVeiculos.Size = new System.Drawing.Size(94, 23);
            this.btnVeiculos.TabIndex = 12;
            this.btnVeiculos.Text = "Veiculos";
            this.btnVeiculos.UseVisualStyleBackColor = true;
            this.btnVeiculos.Click += new System.EventHandler(this.btnVeiculos_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(639, 211);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Criado em";
            // 
            // tbCreatedAt
            // 
            this.tbCreatedAt.Enabled = false;
            this.tbCreatedAt.Location = new System.Drawing.Point(755, 208);
            this.tbCreatedAt.Name = "tbCreatedAt";
            this.tbCreatedAt.Size = new System.Drawing.Size(114, 20);
            this.tbCreatedAt.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Descrição da avaria";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Matricula";
            // 
            // tbMatricula
            // 
            this.tbMatricula.Enabled = false;
            this.tbMatricula.Location = new System.Drawing.Point(100, 122);
            this.tbMatricula.Name = "tbMatricula";
            this.tbMatricula.Size = new System.Drawing.Size(133, 20);
            this.tbMatricula.TabIndex = 6;
            // 
            // tbId
            // 
            this.tbId.Enabled = false;
            this.tbId.Location = new System.Drawing.Point(100, 44);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(135, 20);
            this.tbId.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Funcionario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tipo Serviço";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Id";
            // 
            // tabList
            // 
            this.tabList.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabList.Controls.Add(this.label13);
            this.tabList.Controls.Add(this.cbFuncionarioSearch);
            this.tabList.Controls.Add(this.label8);
            this.tabList.Controls.Add(this.cbTServicoSearch);
            this.tabList.Controls.Add(this.label9);
            this.tabList.Controls.Add(this.cbStateSearch);
            this.tabList.Controls.Add(this.label1);
            this.tabList.Controls.Add(this.tbMatriculaSearch);
            this.tabList.Controls.Add(this.dgvList);
            this.tabList.Location = new System.Drawing.Point(4, 25);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(925, 351);
            this.tabList.TabIndex = 0;
            this.tabList.Text = "Lista";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(658, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Funcionario";
            // 
            // cbFuncionarioSearch
            // 
            this.cbFuncionarioSearch.DisplayMember = "nome";
            this.cbFuncionarioSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuncionarioSearch.FormattingEnabled = true;
            this.cbFuncionarioSearch.Location = new System.Drawing.Point(783, 62);
            this.cbFuncionarioSearch.Name = "cbFuncionarioSearch";
            this.cbFuncionarioSearch.Size = new System.Drawing.Size(121, 21);
            this.cbFuncionarioSearch.TabIndex = 18;
            this.cbFuncionarioSearch.ValueMember = "id";
            this.cbFuncionarioSearch.SelectedIndexChanged += new System.EventHandler(this.cbFuncionarioSearch_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(658, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Tipo de Serviço";
            // 
            // cbTServicoSearch
            // 
            this.cbTServicoSearch.DisplayMember = "nome";
            this.cbTServicoSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTServicoSearch.FormattingEnabled = true;
            this.cbTServicoSearch.Location = new System.Drawing.Point(783, 37);
            this.cbTServicoSearch.Name = "cbTServicoSearch";
            this.cbTServicoSearch.Size = new System.Drawing.Size(121, 21);
            this.cbTServicoSearch.TabIndex = 16;
            this.cbTServicoSearch.ValueMember = "id";
            this.cbTServicoSearch.SelectedIndexChanged += new System.EventHandler(this.cbTServicoSearch_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(658, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Estado de reparação";
            // 
            // cbStateSearch
            // 
            this.cbStateSearch.DisplayMember = "nome";
            this.cbStateSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStateSearch.FormattingEnabled = true;
            this.cbStateSearch.Location = new System.Drawing.Point(783, 10);
            this.cbStateSearch.Name = "cbStateSearch";
            this.cbStateSearch.Size = new System.Drawing.Size(121, 21);
            this.cbStateSearch.TabIndex = 11;
            this.cbStateSearch.ValueMember = "id";
            this.cbStateSearch.SelectedIndexChanged += new System.EventHandler(this.cbStateSearch_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Matricula";
            // 
            // tbMatriculaSearch
            // 
            this.tbMatriculaSearch.Location = new System.Drawing.Point(98, 10);
            this.tbMatriculaSearch.Name = "tbMatriculaSearch";
            this.tbMatriculaSearch.Size = new System.Drawing.Size(126, 20);
            this.tbMatriculaSearch.TabIndex = 5;
            this.tbMatriculaSearch.TextChanged += new System.EventHandler(this.tbMatriculaSearch_TextChanged);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvList.ColumnHeadersHeight = 45;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TService,
            this.Func,
            this.Matricula,
            this.Estado,
            this.Criado});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvList.Location = new System.Drawing.Point(-2, 89);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvList.RowTemplate.ReadOnly = true;
            this.dgvList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.ShowCellErrors = false;
            this.dgvList.ShowCellToolTips = false;
            this.dgvList.ShowEditingIcon = false;
            this.dgvList.ShowRowErrors = false;
            this.dgvList.Size = new System.Drawing.Size(928, 262);
            this.dgvList.TabIndex = 2;
            this.dgvList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvList_CellMouseClick);
            this.dgvList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvList_CellMouseDoubleClick);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Id.DataPropertyName = "id";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Id.DefaultCellStyle = dataGridViewCellStyle10;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // TService
            // 
            this.TService.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TService.DataPropertyName = "tservice";
            this.TService.HeaderText = "Tipo Serviço";
            this.TService.Name = "TService";
            this.TService.ReadOnly = true;
            this.TService.Width = 200;
            // 
            // Func
            // 
            this.Func.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Func.DataPropertyName = "funcionario";
            this.Func.HeaderText = "Funcionario";
            this.Func.Name = "Func";
            this.Func.ReadOnly = true;
            this.Func.Width = 200;
            // 
            // Matricula
            // 
            this.Matricula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Matricula.DataPropertyName = "matricula";
            this.Matricula.HeaderText = "Matricula";
            this.Matricula.Name = "Matricula";
            this.Matricula.ReadOnly = true;
            this.Matricula.Width = 150;
            // 
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Estado.DataPropertyName = "estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Criado
            // 
            this.Criado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Criado.DataPropertyName = "created_at";
            this.Criado.HeaderText = "Criado";
            this.Criado.Name = "Criado";
            this.Criado.ReadOnly = true;
            // 
            // tbDefault
            // 
            this.tbDefault.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbDefault.Controls.Add(this.tabList);
            this.tbDefault.Controls.Add(this.tabProcess);
            this.tbDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDefault.Location = new System.Drawing.Point(0, 74);
            this.tbDefault.Margin = new System.Windows.Forms.Padding(0);
            this.tbDefault.Name = "tbDefault";
            this.tbDefault.Padding = new System.Drawing.Point(0, 0);
            this.tbDefault.SelectedIndex = 0;
            this.tbDefault.Size = new System.Drawing.Size(933, 380);
            this.tbDefault.TabIndex = 1;
            this.tbDefault.SelectedIndexChanged += new System.EventHandler(this.tbDefault_SelectedIndexChanged);
            this.tbDefault.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbDefault_Selected);
            this.tbDefault.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbDefault_Deselecting);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(892, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(37, 35);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(933, 37);
            this.menuStrip2.TabIndex = 4;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(393, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 25);
            this.label10.TabIndex = 5;
            this.label10.Text = "Serviços";
            // 
            // frmServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(933, 454);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.tbDefault);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVeiculos";
            this.Load += new System.EventHandler(this.frmVeiculos_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabProcess.ResumeLayout(false);
            this.tabProcess.PerformLayout();
            this.tabList.ResumeLayout(false);
            this.tabList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.tbDefault.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnNew;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private System.Windows.Forms.ToolStripMenuItem btnClose;
        private System.Windows.Forms.TabPage tabProcess;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.TabControl tbDefault;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMatriculaSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMatricula;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem btnGuardar;
        private System.Windows.Forms.ToolStripMenuItem btnCancelar;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbCreatedAt;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbStateSearch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbFuncionarioSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTServicoSearch;
        private System.Windows.Forms.ToolStripMenuItem btnFServico;
        private System.Windows.Forms.ToolStripMenuItem btnPecas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TService;
        private System.Windows.Forms.DataGridViewTextBoxColumn Func;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Criado;
        private System.Windows.Forms.Button btnVeiculos;
        private System.Windows.Forms.ComboBox cbFuncionario;
        private System.Windows.Forms.ComboBox cbTService;
        private System.Windows.Forms.ToolStripMenuItem btnIService;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbFService;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbIService;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbEstadoReparacao;
        private System.Windows.Forms.RichTextBox tbDescReparacao;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox tbDescAvaria;
        private System.Windows.Forms.ToolStripMenuItem btnFinalizar;
    }
}