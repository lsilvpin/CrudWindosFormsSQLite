using LearningWindowsForms.model;
using LearningWindowsForms.services;
using System;
using System.Windows.Forms;

namespace LearningWindowsForms.view
{
  public partial class Edit : Form
  {
    public Edit()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Quando a tela de Create/Edit é carregada
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnLoad(object sender, EventArgs e)
    {
      if (Utility.CreateOrEditMode)
      {
        // Seleciona o título correto para a janela
        this.Text = "Tela de edição de personagem";
        // Preenche os campos
        InputName.Text = Utility.SelectedItem.Name;
        InputRace.Text = Utility.SelectedItem.Race;
        InputRole.Text = Utility.SelectedItem.Role;
      }
      else
      {
        // Seleciona o nome da janela
        this.Text = "Tela de criação de novo personagem";
      }
    }
    /// <summary>
    /// Quando o usuário clica no botão de salvar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonSaveClicked(object sender, System.EventArgs e)
    {
      if (Utility.CreateOrEditMode)
      { // Significa EDIT
        // Captura o personagem em seu formato antigo, antes da alteração
        Character oldCharacter = Utility.SelectedItem;
        // Instancia e inicializa o personagem em seu formato atualizado
        Character newCharacter = new Character(InputName.Text, InputRace.Text, InputRole.Text);
        // Dispara o processo de atualizar o personagem no banco de dados
        Utility.ValidateAndLog(Utility.UpdateRecordInDataBase(oldCharacter, newCharacter), String.Concat(
          "UpdateRecordInDataBase(De (",oldCharacter.Name,", ",oldCharacter.Race,", ",oldCharacter.Role,") para (",
          newCharacter.Name,", ",newCharacter.Race,", ",newCharacter.Role,"))"));
        // Limpa a gaveta que guarda o item selecionado em Utility
        Utility.SelectedItem = null;
        // Fecha a janela de edit
        this.Close();
      }
      else
      {
        // Instancia o personagem que será inserido no banco de dados
        Character character = new Character(InputName.Text, InputRace.Text, InputRole.Text);
        // Dispara o processo de salvar o personagem no banco de dados
        Utility.ValidateAndLog(Utility.CreateRecordInDataBase(character), String.Concat(
          "CreateRecordInDataBase(", character.Name, ", ", character.Race, ", ", character.Role, ")"));
        // Fecha a janela de edit
        this.Close();
      }
    }
    /// <summary>
    /// Quando usuário clica no botão CLOSE da janela EDIT
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CloseButtonClicked(object sender, EventArgs e)
    {
      // Limpa a gaveta que guarda o item selecionado em Utility se for preciso
      if (Utility.SelectedItem != null)
      {
        Utility.SelectedItem = null;
      }
      // Fecha a janela de Details
      this.Close();
    }
  }
}
