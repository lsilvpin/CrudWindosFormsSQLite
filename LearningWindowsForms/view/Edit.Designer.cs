namespace LearningWindowsForms.view
{
  partial class Edit
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit));
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.BtnCancel = new System.Windows.Forms.ToolStripButton();
      this.BtnSave = new System.Windows.Forms.ToolStripButton();
      this.LblNameEdit = new System.Windows.Forms.Label();
      this.InputName = new System.Windows.Forms.TextBox();
      this.InputRace = new System.Windows.Forms.TextBox();
      this.LblRaceEdit = new System.Windows.Forms.Label();
      this.InputRole = new System.Windows.Forms.TextBox();
      this.LblRoleEdit = new System.Windows.Forms.Label();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnCancel,
            this.BtnSave});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(443, 27);
      this.toolStrip1.TabIndex = 0;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // BtnCancel
      // 
      this.BtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.BtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancel.Image")));
      this.BtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.BtnCancel.Name = "BtnCancel";
      this.BtnCancel.Size = new System.Drawing.Size(29, 24);
      this.BtnCancel.Text = "Cancelar";
      this.BtnCancel.Click += new System.EventHandler(this.CloseButtonClicked);
      // 
      // BtnSave
      // 
      this.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
      this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.BtnSave.Name = "BtnSave";
      this.BtnSave.Size = new System.Drawing.Size(29, 24);
      this.BtnSave.Text = "Salvar";
      this.BtnSave.Click += new System.EventHandler(this.ButtonSaveClicked);
      // 
      // LblNameEdit
      // 
      this.LblNameEdit.AutoSize = true;
      this.LblNameEdit.Location = new System.Drawing.Point(42, 65);
      this.LblNameEdit.Name = "LblNameEdit";
      this.LblNameEdit.Size = new System.Drawing.Size(45, 17);
      this.LblNameEdit.TabIndex = 1;
      this.LblNameEdit.Text = "Name";
      // 
      // InputName
      // 
      this.InputName.Location = new System.Drawing.Point(109, 65);
      this.InputName.Name = "InputName";
      this.InputName.Size = new System.Drawing.Size(248, 22);
      this.InputName.TabIndex = 4;
      // 
      // InputRace
      // 
      this.InputRace.Location = new System.Drawing.Point(109, 103);
      this.InputRace.Name = "InputRace";
      this.InputRace.Size = new System.Drawing.Size(248, 22);
      this.InputRace.TabIndex = 6;
      // 
      // LblRaceEdit
      // 
      this.LblRaceEdit.AutoSize = true;
      this.LblRaceEdit.Location = new System.Drawing.Point(42, 103);
      this.LblRaceEdit.Name = "LblRaceEdit";
      this.LblRaceEdit.Size = new System.Drawing.Size(41, 17);
      this.LblRaceEdit.TabIndex = 5;
      this.LblRaceEdit.Text = "Race";
      // 
      // InputRole
      // 
      this.InputRole.Location = new System.Drawing.Point(109, 145);
      this.InputRole.Name = "InputRole";
      this.InputRole.Size = new System.Drawing.Size(248, 22);
      this.InputRole.TabIndex = 8;
      // 
      // LblRoleEdit
      // 
      this.LblRoleEdit.AutoSize = true;
      this.LblRoleEdit.Location = new System.Drawing.Point(42, 145);
      this.LblRoleEdit.Name = "LblRoleEdit";
      this.LblRoleEdit.Size = new System.Drawing.Size(37, 17);
      this.LblRoleEdit.TabIndex = 7;
      this.LblRoleEdit.Text = "Role";
      // 
      // Edit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(443, 229);
      this.Controls.Add(this.InputRole);
      this.Controls.Add(this.LblRoleEdit);
      this.Controls.Add(this.InputRace);
      this.Controls.Add(this.LblRaceEdit);
      this.Controls.Add(this.InputName);
      this.Controls.Add(this.LblNameEdit);
      this.Controls.Add(this.toolStrip1);
      this.Name = "Edit";
      this.Text = "Edit";
      this.Load += new System.EventHandler(this.OnLoad);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton BtnCancel;
    private System.Windows.Forms.ToolStripButton BtnSave;
    private System.Windows.Forms.Label LblNameEdit;
    private System.Windows.Forms.TextBox InputName;
    private System.Windows.Forms.TextBox InputRace;
    private System.Windows.Forms.Label LblRaceEdit;
    private System.Windows.Forms.TextBox InputRole;
    private System.Windows.Forms.Label LblRoleEdit;
  }
}