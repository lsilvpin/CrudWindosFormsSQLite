namespace LearningWindowsForms.view
{
  partial class Details
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Details));
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.BtnBack = new System.Windows.Forms.ToolStripButton();
      this.BtnEdit = new System.Windows.Forms.ToolStripButton();
      this.LblNameDetail = new System.Windows.Forms.Label();
      this.LblNameValue = new System.Windows.Forms.Label();
      this.LblRaceValue = new System.Windows.Forms.Label();
      this.LblRaceDetail = new System.Windows.Forms.Label();
      this.LblRoleValue = new System.Windows.Forms.Label();
      this.LblRoleDetail = new System.Windows.Forms.Label();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnBack,
            this.BtnEdit});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(385, 27);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // BtnBack
      // 
      this.BtnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.BtnBack.Image = ((System.Drawing.Image)(resources.GetObject("BtnBack.Image")));
      this.BtnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.BtnBack.Name = "BtnBack";
      this.BtnBack.Size = new System.Drawing.Size(29, 24);
      this.BtnBack.Text = "Voltar";
      // 
      // BtnEdit
      // 
      this.BtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.BtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("BtnEdit.Image")));
      this.BtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.BtnEdit.Name = "BtnEdit";
      this.BtnEdit.Size = new System.Drawing.Size(29, 24);
      this.BtnEdit.Text = "Editar";
      // 
      // LblNameDetail
      // 
      this.LblNameDetail.AutoSize = true;
      this.LblNameDetail.Location = new System.Drawing.Point(52, 62);
      this.LblNameDetail.Name = "LblNameDetail";
      this.LblNameDetail.Size = new System.Drawing.Size(45, 17);
      this.LblNameDetail.TabIndex = 1;
      this.LblNameDetail.Text = "Nome";
      // 
      // LblNameValue
      // 
      this.LblNameValue.AutoSize = true;
      this.LblNameValue.Location = new System.Drawing.Point(119, 62);
      this.LblNameValue.Name = "LblNameValue";
      this.LblNameValue.Size = new System.Drawing.Size(51, 17);
      this.LblNameValue.TabIndex = 2;
      this.LblNameValue.Text = "função";
      // 
      // LblRaceValue
      // 
      this.LblRaceValue.AutoSize = true;
      this.LblRaceValue.Location = new System.Drawing.Point(119, 93);
      this.LblRaceValue.Name = "LblRaceValue";
      this.LblRaceValue.Size = new System.Drawing.Size(51, 17);
      this.LblRaceValue.TabIndex = 4;
      this.LblRaceValue.Text = "função";
      // 
      // LblRaceDetail
      // 
      this.LblRaceDetail.AutoSize = true;
      this.LblRaceDetail.Location = new System.Drawing.Point(52, 93);
      this.LblRaceDetail.Name = "LblRaceDetail";
      this.LblRaceDetail.Size = new System.Drawing.Size(41, 17);
      this.LblRaceDetail.TabIndex = 3;
      this.LblRaceDetail.Text = "Raça";
      // 
      // LblRoleValue
      // 
      this.LblRoleValue.AutoSize = true;
      this.LblRoleValue.Location = new System.Drawing.Point(119, 127);
      this.LblRoleValue.Name = "LblRoleValue";
      this.LblRoleValue.Size = new System.Drawing.Size(51, 17);
      this.LblRoleValue.TabIndex = 6;
      this.LblRoleValue.Text = "função";
      // 
      // LblRoleDetail
      // 
      this.LblRoleDetail.AutoSize = true;
      this.LblRoleDetail.Location = new System.Drawing.Point(52, 127);
      this.LblRoleDetail.Name = "LblRoleDetail";
      this.LblRoleDetail.Size = new System.Drawing.Size(50, 17);
      this.LblRoleDetail.TabIndex = 5;
      this.LblRoleDetail.Text = "Classe";
      // 
      // Details
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(385, 201);
      this.Controls.Add(this.LblRoleValue);
      this.Controls.Add(this.LblRoleDetail);
      this.Controls.Add(this.LblRaceValue);
      this.Controls.Add(this.LblRaceDetail);
      this.Controls.Add(this.LblNameValue);
      this.Controls.Add(this.LblNameDetail);
      this.Controls.Add(this.toolStrip1);
      this.Name = "Details";
      this.Text = "Details";
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton BtnBack;
    private System.Windows.Forms.ToolStripButton BtnEdit;
    private System.Windows.Forms.Label LblNameDetail;
    private System.Windows.Forms.Label LblNameValue;
    private System.Windows.Forms.Label LblRaceValue;
    private System.Windows.Forms.Label LblRaceDetail;
    private System.Windows.Forms.Label LblRoleValue;
    private System.Windows.Forms.Label LblRoleDetail;
  }
}