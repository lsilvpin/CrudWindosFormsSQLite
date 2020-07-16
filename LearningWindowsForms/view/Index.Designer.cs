namespace LearningWindowsForms.view
{
  partial class Index
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.BtnCreate = new System.Windows.Forms.ToolStripButton();
      this.BtnUpdate = new System.Windows.Forms.ToolStripButton();
      this.BtnDelete = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.LblSearch = new System.Windows.Forms.ToolStripLabel();
      this.inputSearch = new System.Windows.Forms.ToolStripTextBox();
      this.IconSearch = new System.Windows.Forms.ToolStripButton();
      this.ListSearch = new System.Windows.Forms.ListBox();
      this.ColumTitleName = new System.Windows.Forms.Label();
      this.ColumnTitleRace = new System.Windows.Forms.Label();
      this.ColumnTitleRole = new System.Windows.Forms.Label();
      this.BtnOrderByName = new System.Windows.Forms.Button();
      this.BtnOrderByRace = new System.Windows.Forms.Button();
      this.BtnOrderByRole = new System.Windows.Forms.Button();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnCreate,
            this.BtnUpdate,
            this.BtnDelete,
            this.toolStripSeparator1,
            this.LblSearch,
            this.inputSearch,
            this.IconSearch});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(800, 30);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // BtnCreate
      // 
      this.BtnCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.BtnCreate.Image = ((System.Drawing.Image)(resources.GetObject("BtnCreate.Image")));
      this.BtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.BtnCreate.Name = "BtnCreate";
      this.BtnCreate.Size = new System.Drawing.Size(29, 27);
      this.BtnCreate.Text = "Criar novo personagem";
      this.BtnCreate.Click += new System.EventHandler(this.AddButtonClicked);
      // 
      // BtnUpdate
      // 
      this.BtnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.BtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpdate.Image")));
      this.BtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.BtnUpdate.Name = "BtnUpdate";
      this.BtnUpdate.Size = new System.Drawing.Size(29, 27);
      this.BtnUpdate.Text = "Editar personagem já existente";
      this.BtnUpdate.Click += new System.EventHandler(this.EditButtonClicked);
      // 
      // BtnDelete
      // 
      this.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.BtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelete.Image")));
      this.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.BtnDelete.Name = "BtnDelete";
      this.BtnDelete.Size = new System.Drawing.Size(29, 27);
      this.BtnDelete.Text = "Deletar personagem";
      this.BtnDelete.Click += new System.EventHandler(this.DeleteButtonClicked);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
      // 
      // LblSearch
      // 
      this.LblSearch.Name = "LblSearch";
      this.LblSearch.Size = new System.Drawing.Size(181, 27);
      this.LblSearch.Text = "Pesquisar personagem";
      // 
      // inputSearch
      // 
      this.inputSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F);
      this.inputSearch.Name = "inputSearch";
      this.inputSearch.Size = new System.Drawing.Size(200, 30);
      this.inputSearch.TextChanged += new System.EventHandler(this.WhenTextChange);
      // 
      // IconSearch
      // 
      this.IconSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.IconSearch.Image = ((System.Drawing.Image)(resources.GetObject("IconSearch.Image")));
      this.IconSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.IconSearch.Name = "IconSearch";
      this.IconSearch.Size = new System.Drawing.Size(29, 27);
      this.IconSearch.Text = "Pesquisar";
      this.IconSearch.Click += new System.EventHandler(this.SearchButtonClicked);
      // 
      // ListSearch
      // 
      this.ListSearch.FormattingEnabled = true;
      this.ListSearch.ItemHeight = 16;
      this.ListSearch.Location = new System.Drawing.Point(87, 80);
      this.ListSearch.Name = "ListSearch";
      this.ListSearch.Size = new System.Drawing.Size(620, 292);
      this.ListSearch.TabIndex = 1;
      this.ListSearch.Click += new System.EventHandler(this.ItemSelected);
      this.ListSearch.DoubleClick += new System.EventHandler(this.EditButtonClicked);
      // 
      // ColumTitleName
      // 
      this.ColumTitleName.AutoSize = true;
      this.ColumTitleName.Location = new System.Drawing.Point(87, 57);
      this.ColumTitleName.Name = "ColumTitleName";
      this.ColumTitleName.Size = new System.Drawing.Size(45, 17);
      this.ColumTitleName.TabIndex = 2;
      this.ColumTitleName.Text = "Name";
      // 
      // ColumnTitleRace
      // 
      this.ColumnTitleRace.AutoSize = true;
      this.ColumnTitleRace.Location = new System.Drawing.Point(290, 57);
      this.ColumnTitleRace.Name = "ColumnTitleRace";
      this.ColumnTitleRace.Size = new System.Drawing.Size(41, 17);
      this.ColumnTitleRace.TabIndex = 3;
      this.ColumnTitleRace.Text = "Race";
      // 
      // ColumnTitleRole
      // 
      this.ColumnTitleRole.AutoSize = true;
      this.ColumnTitleRole.Location = new System.Drawing.Point(488, 57);
      this.ColumnTitleRole.Name = "ColumnTitleRole";
      this.ColumnTitleRole.Size = new System.Drawing.Size(37, 17);
      this.ColumnTitleRole.TabIndex = 4;
      this.ColumnTitleRole.Text = "Role";
      // 
      // BtnOrderByName
      // 
      this.BtnOrderByName.Cursor = System.Windows.Forms.Cursors.Hand;
      this.BtnOrderByName.Location = new System.Drawing.Point(138, 54);
      this.BtnOrderByName.Name = "BtnOrderByName";
      this.BtnOrderByName.Size = new System.Drawing.Size(99, 23);
      this.BtnOrderByName.TabIndex = 5;
      this.BtnOrderByName.Text = "Ordenar";
      this.BtnOrderByName.UseVisualStyleBackColor = true;
      this.BtnOrderByName.Click += new System.EventHandler(this.OrderByName);
      // 
      // BtnOrderByRace
      // 
      this.BtnOrderByRace.Cursor = System.Windows.Forms.Cursors.Hand;
      this.BtnOrderByRace.Location = new System.Drawing.Point(337, 54);
      this.BtnOrderByRace.Name = "BtnOrderByRace";
      this.BtnOrderByRace.Size = new System.Drawing.Size(99, 23);
      this.BtnOrderByRace.TabIndex = 6;
      this.BtnOrderByRace.Text = "Ordenar";
      this.BtnOrderByRace.UseVisualStyleBackColor = true;
      this.BtnOrderByRace.Click += new System.EventHandler(this.OrderByRace);
      // 
      // BtnOrderByRole
      // 
      this.BtnOrderByRole.Cursor = System.Windows.Forms.Cursors.Hand;
      this.BtnOrderByRole.Location = new System.Drawing.Point(531, 54);
      this.BtnOrderByRole.Name = "BtnOrderByRole";
      this.BtnOrderByRole.Size = new System.Drawing.Size(99, 23);
      this.BtnOrderByRole.TabIndex = 7;
      this.BtnOrderByRole.Text = "Ordenar";
      this.BtnOrderByRole.UseVisualStyleBackColor = true;
      this.BtnOrderByRole.Click += new System.EventHandler(this.OrderByRole);
      // 
      // Index
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.BtnOrderByRole);
      this.Controls.Add(this.BtnOrderByRace);
      this.Controls.Add(this.BtnOrderByName);
      this.Controls.Add(this.ColumnTitleRole);
      this.Controls.Add(this.ColumnTitleRace);
      this.Controls.Add(this.ColumTitleName);
      this.Controls.Add(this.ListSearch);
      this.Controls.Add(this.toolStrip1);
      this.Name = "Index";
      this.Text = "Aplicação WindowsForms para aprender CRUD com SQLite";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClose);
      this.Load += new System.EventHandler(this.OnLoad);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton BtnCreate;
    private System.Windows.Forms.ToolStripButton BtnUpdate;
    private System.Windows.Forms.ToolStripButton BtnDelete;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripLabel LblSearch;
    private System.Windows.Forms.ToolStripTextBox inputSearch;
    private System.Windows.Forms.ToolStripButton IconSearch;
    private System.Windows.Forms.ListBox ListSearch;
    private System.Windows.Forms.Label ColumTitleName;
    private System.Windows.Forms.Label ColumnTitleRace;
    private System.Windows.Forms.Label ColumnTitleRole;
    private System.Windows.Forms.Button BtnOrderByName;
    private System.Windows.Forms.Button BtnOrderByRace;
    private System.Windows.Forms.Button BtnOrderByRole;
  }
}