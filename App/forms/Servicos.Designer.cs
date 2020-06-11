namespace App
{
    partial class Servicos
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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.alterarEstadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.Lista = new System.Windows.Forms.TabPage();
      this.Ficha = new System.Windows.Forms.TabPage();
      this.label1 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.textBox4 = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.Listar = new System.Windows.Forms.Button();
      this.menuStrip1.SuspendLayout();
      this.tabControl.SuspendLayout();
      this.Lista.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.alterarEstadoToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(800, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // novoToolStripMenuItem
      // 
      this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
      this.novoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
      this.novoToolStripMenuItem.Text = "Novo";
      // 
      // editarToolStripMenuItem
      // 
      this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
      this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
      this.editarToolStripMenuItem.Text = "Editar";
      // 
      // alterarEstadoToolStripMenuItem
      // 
      this.alterarEstadoToolStripMenuItem.Name = "alterarEstadoToolStripMenuItem";
      this.alterarEstadoToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
      this.alterarEstadoToolStripMenuItem.Text = "Alterar Estado";
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.Lista);
      this.tabControl.Controls.Add(this.Ficha);
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl.Location = new System.Drawing.Point(0, 24);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(800, 430);
      this.tabControl.TabIndex = 1;
      // 
      // Lista
      // 
      this.Lista.Controls.Add(this.Listar);
      this.Lista.Controls.Add(this.textBox4);
      this.Lista.Controls.Add(this.label4);
      this.Lista.Controls.Add(this.textBox3);
      this.Lista.Controls.Add(this.label3);
      this.Lista.Controls.Add(this.textBox2);
      this.Lista.Controls.Add(this.label2);
      this.Lista.Controls.Add(this.dataGridView1);
      this.Lista.Controls.Add(this.textBox1);
      this.Lista.Controls.Add(this.label1);
      this.Lista.Location = new System.Drawing.Point(4, 22);
      this.Lista.Name = "Lista";
      this.Lista.Padding = new System.Windows.Forms.Padding(3);
      this.Lista.Size = new System.Drawing.Size(792, 404);
      this.Lista.TabIndex = 0;
      this.Lista.Text = "Lista";
      this.Lista.UseVisualStyleBackColor = true;
      // 
      // Ficha
      // 
      this.Ficha.Location = new System.Drawing.Point(4, 22);
      this.Ficha.Name = "Ficha";
      this.Ficha.Padding = new System.Windows.Forms.Padding(3);
      this.Ficha.Size = new System.Drawing.Size(792, 404);
      this.Ficha.TabIndex = 1;
      this.Ficha.Text = "Ficha";
      this.Ficha.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(43, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(98, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Número de Serviço";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(46, 34);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(103, 20);
      this.textBox1.TabIndex = 1;
      // 
      // dataGridView1
      // 
      this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
      this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new System.Drawing.Point(205, 1);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(586, 402);
      this.dataGridView1.TabIndex = 2;
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(46, 88);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(103, 20);
      this.textBox2.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(43, 72);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(50, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Matricula";
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(46, 146);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(103, 20);
      this.textBox3.TabIndex = 6;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(43, 130);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(44, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Secção";
      // 
      // textBox4
      // 
      this.textBox4.Location = new System.Drawing.Point(46, 207);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new System.Drawing.Size(103, 20);
      this.textBox4.TabIndex = 8;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(43, 191);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(62, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Funcionário";
      // 
      // Listar
      // 
      this.Listar.Location = new System.Drawing.Point(46, 308);
      this.Listar.Name = "Listar";
      this.Listar.Size = new System.Drawing.Size(103, 39);
      this.Listar.TabIndex = 9;
      this.Listar.Text = "Listar";
      this.Listar.UseVisualStyleBackColor = true;
      // 
      // Servicos
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 454);
      this.Controls.Add(this.tabControl);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Servicos";
      this.Text = "Serviços";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.tabControl.ResumeLayout(false);
      this.Lista.ResumeLayout(false);
      this.Lista.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }
    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem alterarEstadoToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Lista;
        private System.Windows.Forms.TabPage Ficha;
        private System.Windows.Forms.Button Listar;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}