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
      this.toolStrip1.Size = new System.Drawing.Size(800, 31);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // BtnCreate
      // 
      this.BtnCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.BtnCreate.Image = ((System.Drawing.Image)(resources.GetObject("BtnCreate.Image")));
      this.BtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.BtnCreate.Name = "BtnCreate";
      this.BtnCreate.Size = new System.Drawing.Size(29, 28);
      this.BtnCreate.Text = "Criar novo personagem";
      // 
      // BtnUpdate
      // 
      this.BtnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.BtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpdate.Image")));
      this.BtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.BtnUpdate.Name = "BtnUpdate";
      this.BtnUpdate.Size = new System.Drawing.Size(29, 27);
      this.BtnUpdate.Text = "Editar personagem já existente";
      // 
      // BtnDelete
      // 
      this.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.BtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelete.Image")));
      this.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.BtnDelete.Name = "BtnDelete";
      this.BtnDelete.Size = new System.Drawing.Size(29, 27);
      this.BtnDelete.Text = "Deletar personagem";
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
      // 
      // IconSearch
      // 
      this.IconSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.IconSearch.Image = ((System.Drawing.Image)(resources.GetObject("IconSearch.Image")));
      this.IconSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.IconSearch.Name = "IconSearch";
      this.IconSearch.Size = new System.Drawing.Size(29, 27);
      this.IconSearch.Text = "Pesquisar";
      // 
      // ListSearch
      // 
      this.ListSearch.FormattingEnabled = true;
      this.ListSearch.ItemHeight = 16;
      this.ListSearch.Items.AddRange(new object[] {
            "Alfa",
            "Beta",
            "Gama"});
      this.ListSearch.Location = new System.Drawing.Point(87, 64);
      this.ListSearch.Name = "ListSearch";
      this.ListSearch.Size = new System.Drawing.Size(620, 308);
      this.ListSearch.TabIndex = 1;
      // 
      // Index
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.ListSearch);
      this.Controls.Add(this.toolStrip1);
      this.Name = "Index";
      this.Text = "Index";
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
  }
}