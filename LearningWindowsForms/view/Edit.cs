using LearningWindowsForms.model;
using LearningWindowsForms.services;
using System;
using System.Windows.Forms;

namespace LearningWindowsForms.view
{
  public partial class Edit : Form
  {
    Utility _utility = new Utility();
    public Edit()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Cria um objeto Character com as infos do formulário, e envia os dados para processo de registro
    /// </summary>
    /// <param name="sender">???</param>
    /// <param name="e">???</param>
    private void Save(object sender, EventArgs e)
    {
      Character character = new Character();
      character.Name = InputName.Text;
      character.Race = InputRace.Text;
      character.Role = InputRole.Text;
      try
      {
        Utility.Update(1, character);
      }
      catch(Exception ex)
      {
        Utility.Log(ex.Message);
      }
    }
  }
}
