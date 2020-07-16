using LearningWindowsForms.model;
using LearningWindowsForms.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LearningWindowsForms.view
{
  /// <summary>
  /// Classe dedicada ao controle da janela Index
  /// </summary>
  public partial class Index : Form
  {
    // Construtor
    public Index()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Quando a tela inicial é carregada
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnLoad(object sender, EventArgs e)
    {
      SearchButtonClicked(sender, e);
    }
    /// <summary>
    /// Evento disparado quando o usuário clica no botão Adicionar
    /// </summary>
    /// <param name="sender">???</param>
    /// <param name="e">???</param>
    private void AddButtonClicked(object sender, EventArgs e)
    {
      // Fixa o tipo da janela de Edit para EDIT
      Utility.CreateOrEditMode = false; // true = Edit, false = Create
      // Navega para a tela de Create
      Utility.ValidateAndLog(Utility.NavigateTo("Edit"), "NavigateTo(\"Create\")");
    }
    /// <summary>
    /// Quando usuário clica em Edit, captura item selecionado e navega
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void EditButtonClicked(object sender, EventArgs e)
    { // List<String> myOtherList = ListSearch.Items.Cast<String>().ToList(); VALE OURO
      if (!(Utility.SelectedItem is null))
      {
        // Fixa o tipo da janela de Edit para EDIT
        Utility.CreateOrEditMode = true; // true = Edit, false = Create
                                         // Navegamos para a tela de Edit/Create
        Utility.ValidateAndLog(Utility.NavigateTo("Edit"), "NavigateTo(\"Edit\")");
      }
      else
      {
        MessageBox.Show("Você deve selecionar um item da lista primeiro!");
      }
    }
    /// <summary>
    /// Resposta para quando o usuário clica no botão Search
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SearchButtonClicked(object sender, EventArgs e)
    {
      // Captura a string de consulta
      string search = inputSearch.Text;
      // Chama o processo de consulta ao banco de dados, enviando a string
      Utility.ValidateAndLog(Utility.SearchForRecordsInDataBase(search),
        String.Concat("SearchForRecordsInDataBase(\"", search, "\")"));

      try // Tenta Preencher a ListBox com as informações recebidas
      {
        // Coleta o resultado da consulta e armazena neste escopo
        List<Character> characters = new List<Character>();
        characters = Utility.ListBoxItems;
        // Limpa a ListBox
        ListSearch.Items.Clear();
        // Preenche a ListBox com as informações recebidas
        foreach (Character character in characters)
        {
          ListSearch.Items.Add(String.Concat(character.Name, ", ", character.Race, ", ", character.Role));
        }
      }
      catch (Exception ex)
      {
        Utility.Log(ex.Message);
      }
    }
    /// <summary>
    /// Quando o usuário altera o texto do input, dispara o filtro
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void WhenTextChange(object sender, EventArgs e)
    {
      SearchButtonClicked(sender, e);
    }
    /// <summary>
    /// Quando o usuário clica no botão DELETE
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DeleteButtonClicked(object sender, EventArgs e)
    {
      if (!(Utility.SelectedItem is null))
      {
        // Ativa o modo DELETE da janela Details
        Utility.DeleteOrReadMode = true; // true = DELETE, false = ReadOnly
        // Navegamos para a tela de Details
        Utility.ValidateAndLog(Utility.NavigateTo("Details"), "NavigateTo(\"Details \")");
      }
      else
      {
        MessageBox.Show("Você deve selecionar um item da lista primeiro!");
      }
    }
    /// <summary>
    /// Quando o usuário clica em algum item da lista
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ItemSelected(object sender, EventArgs e)
    {
      // Capturamos item selecionado na SearchListBox e o lançamos na gaveta de Utility
      Utility.SelectedItem = new Character(
        ListSearch.SelectedItem.ToString().Split(',')[0].Trim(),
        ListSearch.SelectedItem.ToString().Split(',')[1].Trim(),
        ListSearch.SelectedItem.ToString().Split(',')[2].Trim()
      );
    }
    /// <summary>
    /// Quando usuário clica no botão OrderByName
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OrderByName(object sender, EventArgs e)
    {
      // Coleta os items que estão presentes na ListBox e armazena localmente
      List<Character> listBoxItems = Utility.ListBoxItems;
      // Apaga os itens presentes atualmente na list box
      ListSearch.Items.Clear();
      // Reordena os itens armazenados para reconstruir a listbox
      listBoxItems = Utility.OrderAscendingByColumn("Name", listBoxItems).Values.FirstOrDefault();
      // Reconstrói a list box, com os itens na ordem correta
      foreach (Character character in listBoxItems)
      {
        ListSearch.Items.Add(String.Concat(character.Name, ", ", character.Race, ", ", character.Role));
      }
    }
  }
}
