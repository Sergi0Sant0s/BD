namespace App.forms
{
    partial class frmSeccao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeccao));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tabProcess = new System.Windows.Forms.TabPage();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabList = new System.Windows.Forms.TabPage();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnDelete,
            this.btnGuardar,
            this.btnCancelar,
            this.btnClose});
            this.menuStrip1.Location = new System.Drawing.Point(0, 37);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(571, 37);
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
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 33);
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(61, 33);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            // tabProcess
            // 
            this.tabProcess.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabProcess.Controls.Add(this.tbNome);
            this.tabProcess.Controls.Add(this.tbId);
            this.tabProcess.Controls.Add(this.label3);
            this.tabProcess.Controls.Add(this.label2);
            this.tabProcess.Location = new System.Drawing.Point(4, 25);
            this.tabProcess.Name = "tabProcess";
            this.tabProcess.Size = new System.Drawing.Size(563, 234);
            this.tabProcess.TabIndex = 1;
            this.tabProcess.Text = "Processo";
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(100, 70);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(112, 20);
            this.tbNome.TabIndex = 4;
            // 
            // tbId
            // 
            this.tbId.Enabled = false;
            this.tbId.Location = new System.Drawing.Point(100, 44);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(112, 20);
            this.tbId.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nome";
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
            this.tabList.Controls.Add(this.dgvList);
            this.tabList.Location = new System.Drawing.Point(4, 25);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(563, 221);
            this.tabList.TabIndex = 0;
            this.tabList.Text = "Lista";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeight = 45;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nome});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvList.Location = new System.Drawing.Point(-2, 0);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            this.dgvList.Size = new System.Drawing.Size(569, 221);
            this.dgvList.TabIndex = 2;
            this.dgvList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvList_CellMouseDoubleClick);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Id.DataPropertyName = "id";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Id.DefaultCellStyle = dataGridViewCellStyle2;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nome.DataPropertyName = "nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
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
            this.tbDefault.Size = new System.Drawing.Size(571, 250);
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
            this.btnMinimize.Location = new System.Drawing.Point(530, 0);
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
            this.menuStrip2.Size = new System.Drawing.Size(571, 37);
            this.menuStrip2.TabIndex = 4;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(238, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 25);
            this.label10.TabIndex = 5;
            this.label10.Text = "Secções";
            // 
            // frmSeccao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(571, 324);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.tbDefault);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSeccao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVeiculos";
            this.Load += new System.EventHandler(this.frmVeiculos_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabProcess.ResumeLayout(false);
            this.tabProcess.PerformLayout();
            this.tabList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.tbDefault.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnNew;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.ToolStripMenuItem btnClose;
        private System.Windows.Forms.TabPage tabProcess;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.TabControl tbDefault;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem btnGuardar;
        private System.Windows.Forms.ToolStripMenuItem btnCancelar;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Label label10;
    }
}