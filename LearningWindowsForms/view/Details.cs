using LearningWindowsForms.services;
using System;
using System.Windows.Forms;

namespace LearningWindowsForms.view
{
  public partial class ScreenDetails : Form
  {
    // Construtor
    public ScreenDetails()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Quando a janela de Details carrega
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnLoad(object sender, EventArgs e)
    {
      // Seleciona o título correto para a janela
      if (Utility.DeleteOrReadMode)
      {
        this.Text = "Tela de Deleção";
      }
      else
      {
        this.Text = "Tela de Visualisação";
      }
      // Preenche os campos
      LblNameValue.Text = Utility.SelectedItem.Name;
      LblRaceValue.Text = Utility.SelectedItem.Race;
      LblRoleValue.Text = Utility.SelectedItem.Role;
    }
    /// <summary>
    /// Quando usuário clica no botão EDIT da janela Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void EditButtonClicked(object sender, EventArgs e)
    {
      // Fixa o tipo da janela de Edit para EDIT
      Utility.CreateOrEditMode = true; // true = Edit, false = Create
      // Navegamos para a tela de Edit/Create
      Utility.ValidateAndLog(Utility.NavigateTo("Edit"), "NavigateTo(\"Edit\")");
    }
    /// <summary>
    /// Quando o usuário clica no botâo BACK da janela Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BackButtonClicked(object sender, EventArgs e)
    {
      // Limpa a gaveta que guarda o item selecionado em Utility
      Utility.SelectedItem = null;
      // Fecha a janela de Details
      this.Close();
    }
    /// <summary>
    /// Quando o botão DELETE é clicado na janela de Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DeleteButtonClicked(object sender, EventArgs e)
    {
      // Dispara o processo de deleção do item selecionado
      Utility.ValidateAndLog(Utility.DeleteRecordInDataBase(Utility.SelectedItem),
        String.Concat("DeleteRecordInDataBase(", Utility.SelectedItem.Name, ", ",
        Utility.SelectedItem.Race, ", ", Utility.SelectedItem.Role, ")"));
      // Limpa gaveta de seleção
      Utility.SelectedItem = null;
      // Fecha esta janela (Details)
      this.Close();
    }
  }
}
