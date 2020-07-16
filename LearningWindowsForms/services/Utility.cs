using LearningWindowsForms.model;
using LearningWindowsForms.repository;
using LearningWindowsForms.view;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace LearningWindowsForms.services
{
  /// <summary>
  /// Esta classe possui serviços e ferramentas úteis em toda a aplicação
  /// </summary>
  class Utility
  {
    // Gaveta para guardar coisas importantes
    public static List<Character> ListBoxItems { get; set; } // Items da list box
    public static Character SelectedItem { get; set; } // Guarda item selecionado na ListBox
    public static bool CreateOrEditMode { get; set; } // Armazena tipo da janela Edit
    public static bool DeleteOrReadMode { get; set; } // Tipo da janela Details
    public static List<bool> OrderingKeys { get; set; } // Chaves de ordenação
    public static bool GenericKey { get; set; } // Guarda temporariamente resultados úteis

    // Informações necessárias na definição dos métodos abaixo
    private static string _LocalRepository = @"C:\Users\lsilvpin\source\repos"; // MapPath()
    private static string _LogPath = @"~\LearningWindowsForms\LearningWindowsForms\data\Log.txt"; // Log()

    // Os serviços são as funções que conectam as camadas, e fazem a aplicação funcionar
    #region Data base services
    /// <summary>
    /// Chama a camada de repositório para criar o banco, caso não exista
    /// </summary>
    /// <summary>
    /// Este método valida o funcionamento dos demais métodos e registra os resultados no LOG
    /// </summary>
    /// <param name="stepResult">Resultado dos outros métodos</param>
    /// <param name="functionName">Nome do métedo sendo analisado</param>
    public static bool CreateDataBaseIfNecessary()
    {
      try
      {
        Seed.CreateSqliteDataBase();
        return true;
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        return false;
      }
    }
    /// <summary>
    /// Chama a camada de repositório para que ela crie um novo registro no banco
    /// </summary>
    /// <param name="character">Entidade que define o registro que será criado</param>
    public static bool CreateRecordInDataBase(Character character)
    {
      try
      {
        Seed.Create(character); // Chamamos o C do CRUD
        MessageBox.Show(String.Concat(character.Name, ", ", character.Race,
           ", ", character.Role, " foi salvo com sucesso! =]"));
        return true;
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        return false;
      }
    }
    /// <summary>
    /// Chama a camada de repositório para que ela procure registros no banco que batam com uma String ou Id
    /// </summary>
    /// <param name="search">String a ser procurada no banco</param>
    /// <param name="id">Id a ser procurado no banco</param>
    public static bool SearchForRecordsInDataBase(string search, int id = 0)
    {
      try
      {
        ListBoxItems = Seed.Read(search, id);
        return true;
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        return false;
      }
    }

    /// <summary>
    /// Chama a camada de repositório para atualizar o banco
    /// </summary>
    /// <param name="id">id do registro que será atualisado</param>
    /// <param name="character">objeto Character com infos a serem submetidos ao banco</param>
    public static bool UpdateRecordInDataBase(Character oldCharacter, Character newCharacter)
    {
      if (oldCharacter.Id == 0)
      { // Se vier sem Id, tem que vir com Nome, e achamos o Id pelo nome
        oldCharacter.Id = Seed.Read(oldCharacter.Name)[0].Id;
      }
      try
      {
        Seed.Update(oldCharacter.Id, newCharacter);
        MessageBox.Show(String.Concat("O registro (", oldCharacter.Name, ", ",
          oldCharacter.Race, ", ", oldCharacter.Role, ") foi atualizado para (",
          newCharacter.Name, ", ", newCharacter.Race, ", ", newCharacter.Role,
          ") com sucesso! =]"));
        return true;
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        return false;
      }
    }
    /// <summary>
    /// Chama a camada de repositório para que delete um ou mais registros no banco de dados
    /// </summary>
    /// <param name="character">Entidade que determina o(s) registro(s) a ser(em) deletado(s)</param>
    public static bool DeleteRecordInDataBase(Character character)
    {
      try
      {
        Seed.Delete(character);
        MessageBox.Show(String.Concat(character.Name, ", ", character.Race,
           ", ", character.Role, " foi deletado com sucesso! =]"));
        return true;
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        return false;
      }
    }
    #endregion

    // Serviços de controle de reações da View
    #region View services
    /// <summary>
    /// Método que prepara o ambiente para execução correta da aplicação
    /// </summary>
    public static bool PrepareEnvironmentForWindowsForms()
    {
      try
      {
        Utility.CreateDataBaseIfNecessary();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Index());
        return true;
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        return false;
      }

    }
    /// <summary>
    /// Método que navega para a janela escolhida
    /// </summary>
    /// <param name="windowName">Nome da janela escolhida</param>
    /// <returns>Instancia uma janela nova, e constrói ela na tela</returns>
    public static bool NavigateTo(string windowName)
    {
      try
      {
        if (windowName == "Index")
        {
          Index index = new Index();
          index.ShowDialog();
          return true;
        }
        else if (windowName == "Create" || windowName == "Edit")
        {
          Edit edit = new Edit();
          edit.ShowDialog();
          return true;
        }
        else if (windowName == "Details")
        {
          ScreenDetails details = new ScreenDetails();
          details.ShowDialog();
          return true;
        }
        else
        {
          throw new Exception(String.Concat("A suposta janela ", windowName, "não foi encontrada, e portanto o prosseço parou!"));
        }
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        return false;
      }
    }
    /// <summary>
    /// Encontra a palavra da lista, que vem primeiro na ordem lexicográfica
    /// </summary>
    /// <param name="inputList">Lista desordenada</param>
    /// <returns>Palavra mínima na ordem</returns>
    public static Dictionary<bool, string> FindMinimalWordInLexicOrder(List<String> inputList)
    {
      try
      {
        // Reservamos um lugar na memória para receber a menor das palavras
        string word = String.Empty;
        // Pegamos a primeira palavra na lista dada
        word = inputList[0];
        // Iniciamos o processo de procura pela menor das palavras
        while (true)
        {
          // Comparamos a palavra com todas da lista dada
          for (int i = 0; i < inputList.Count; i++)
          {
            if (!IsFirstStringLessThanSecond(word, inputList[i]))
            {
              word = inputList[i];
              break;
            }
            if (i == inputList.Count-1)
            {
              // Prepara a saída
              Dictionary<bool, string> output = new Dictionary<bool, string>();
              output.Add(true, word);
              // Salva o resultado em Generica Key
              Utility.GenericKey = true;
              // E retorna a saída
              return output;
            }
          }
        }
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        MessageBox.Show(ex.Message);
        // Prepara a saída
        Dictionary<bool, string> output = new Dictionary<bool, string>();
        output.Add(false, String.Empty);
        // Salva o resultado em Generica Key
        Utility.GenericKey = false;
        // E retorna a saída
        return output;
      }
    }
    /// <summary>
    /// Reordena uma lista seguindo a ordem lexicográfica crescente
    /// </summary>
    /// <param name="inputList">Lista desordenada</param>
    /// <returns>Lista ordenada</returns>
    public static Dictionary<bool, List<string>> OrderAscending(List<string> inputList)
    {
      try
      {
        // Instanciamos a lista que receberá a ordem correta
        List<string> outputList = new List<string>();
        // Iniciamos o processo de reordenação
        while (inputList.Count > 0)
        {
          // Encontramos a menor das palavras na lista de entrada, na ordem lexicográfica
          string min = FindMinimalWordInLexicOrder(inputList).Values.FirstOrDefault();
          // Retiramos ela da lista de entrada
          inputList.Remove(min);
          // Inserimos ela na lista de saída, como sendo a primeira
          outputList.Add(min);
        }
        // Retornamos a lista com a ordem correta
        Dictionary<bool, List<string>> output = new Dictionary<bool, List<string>>();
        output.Add(true, outputList);
        // Salva o resultado em Generica Key
        Utility.GenericKey = true;
        // E retorna a saída
        return output;
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        MessageBox.Show(ex.Message);
        // Retornamos a lista com a ordem correta
        Dictionary<bool, List<string>> output = new Dictionary<bool, List<string>>();
        output.Add(false, new List<string>());
        // Salva o resultado em Generica Key
        Utility.GenericKey = false;
        // E retorna a saída
        return output;
      }
    }
    /// <summary>
    /// Método que ordena lista pela coluna escolhida
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    public static Dictionary<bool, List<Character>> OrderAscendingByColumn(string column, List<Character> inputList)
    {
      try
      {
        // Instanciamos a lista que receberá a ordem de saída
        List<Character> outputList = new List<Character>();
        // Montamos a lista de saída ordenando pela coluna pedida
        if (column == "Name")
        {
          // Coletamos as palavras a serem ordenadas
          List<string> words = new List<string>();
          words = inputList.Select(character => character.Name).ToList();
          // Eliminamos as palavras repetidas
          words = words.ToHashSet().ToList();
          // Ordenamos a lista de palavras
          words = OrderAscending(words).Values.FirstOrDefault();
          // Montamos a lista de saída na ordem requerida
          foreach (string word in words)
          {
            outputList.AddRange(inputList.Where(character => character.Name == word));
          }
          // Retornamos a lista de personagens ordenada
          Dictionary<bool, List<Character>> output = new Dictionary<bool, List<Character>>();
          output.Add(true, outputList);
          // Salva o resultado em Generica Key
          Utility.GenericKey = true;
          // E retorna a saída
          return output;
        }
        else if (column == "Race")
        {
          // Coletamos as palavras a serem ordenadas
          List<string> words = inputList.Select(character => character.Race).ToList();
          // Eliminamos as palavras repetidas
          words = words.ToHashSet().ToList();
          // Ordenamos a lista de palavras
          words = OrderAscending(words).Values.FirstOrDefault();
          // Montamos a lista de saída na ordem requerida
          foreach (string word in words)
          {
            outputList.AddRange(inputList.Where(character => character.Name == word));
          }
          // Retornamos a lista de personagens ordenada
          Dictionary<bool, List<Character>> output = new Dictionary<bool, List<Character>>();
          output.Add(true, outputList);
          // Salva o resultado em Generica Key
          Utility.GenericKey = true;
          // E retorna a saída
          return output;
        }
        else
        {
          // Coletamos as palavras a serem ordenadas
          List<string> words = inputList.Select(character => character.Role).ToList();
          // Eliminamos as palavras repetidas
          words = words.ToHashSet().ToList();
          // Ordenamos a lista de palavras
          words = OrderAscending(words).Values.FirstOrDefault();
          // Montamos a lista de saída na ordem requerida
          foreach (string word in words)
          {
            outputList.AddRange(inputList.Where(character => character.Name == word));
          }
          // Retornamos a lista de personagens ordenada
          Dictionary<bool, List<Character>> output = new Dictionary<bool, List<Character>>();
          output.Add(true, outputList);
          // Salva o resultado em Generica Key
          Utility.GenericKey = true;
          // E retorna a saída
          return output;
        }
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        MessageBox.Show(ex.Message);
        // Retornamos a lista de personagens ordenada
        Dictionary<bool, List<Character>> output = new Dictionary<bool, List<Character>>();
        output.Add(false, new List<Character>());
        // Salva o resultado em Generica Key
        Utility.GenericKey = false;
        // E retorna a saída
        return output;
      }
    }
    #endregion

    // Caixa de ferramentas úteis em toda a aplicação
    #region Tools
    /// <summary>
    /// Registra os resultados de cada passo do programa em um arquivo txt
    /// </summary>
    /// <param name="feedback">Mensagem a ser registrada no Log</param>
    public static void Log(string feedback)
    {
      try
      {
        string path = MapPath(_LogPath);
        if (!File.Exists(path))
        {
          // Cria um arquivo e escreve nele
          using (FileStream fileStream = new FileStream(path, FileMode.Create))
          {
            String message = String.Concat(DateTime.Now, ": ", feedback);
            byte[] byteMessage = new UTF8Encoding(true).GetBytes(message);
            fileStream.Write(byteMessage, 0, byteMessage.Length);
          }
        }
        else
        {
          // Acrescenta registro no final do arquivo já existente
          using (StreamWriter streamWriter = File.AppendText(path))
          {
            streamWriter.WriteLine(String.Concat(DateTime.Now, ": ", feedback));
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    /// <summary>
    /// Converte um Virtual Root no Phisical Root da máquina
    /// </summary>
    /// <param name="path">Vitrual path</param>
    /// <returns></returns>
    public static string MapPath(string virtualPath)
    {
      try
      {
        return virtualPath.Replace("~", _LocalRepository);
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        return string.Empty;
      }
    }
    /// <summary>
    /// Valida um serviço e registra o resultado com LOG
    /// </summary>
    /// <param name="serviceResult">Resultado do serviço</param>
    /// <param name="serviceName">Nome do serviço sendo analisado</param>
    public static void ValidateAndLog(bool serviceResult, string serviceName)
    {
      if (serviceResult)
      {
        Log(String.Concat("A função ", serviceName, " executou com sucesso!"));
      }
      else
      {
        Log(String.Concat("A função ", serviceName, " finalizou com erro(s)!"));
      }
    }
    #endregion

    // Definindo a ordem Lexicográfica
    #region Ordem Lexicográfica
    // Ordem entre letras, de forma crescente
    public static Dictionary<int, string> OrderedAlphabet()
    {
      try
      {
        // Instancio um dicionário
        Dictionary<int, string> orderedAlphabet = new Dictionary<int, string>();
        // Crio manualmente a função de ordenar as letras
        orderedAlphabet.Add(0, "a");
        orderedAlphabet.Add(1, "b");
        orderedAlphabet.Add(2, "c");
        orderedAlphabet.Add(3, "d");
        orderedAlphabet.Add(4, "e");
        orderedAlphabet.Add(5, "f");
        orderedAlphabet.Add(6, "g");
        orderedAlphabet.Add(7, "h");
        orderedAlphabet.Add(8, "i");
        orderedAlphabet.Add(9, "j");
        orderedAlphabet.Add(10, "k");
        orderedAlphabet.Add(11, "l");
        orderedAlphabet.Add(12, "m");
        orderedAlphabet.Add(13, "n");
        orderedAlphabet.Add(14, "o");
        orderedAlphabet.Add(15, "p");
        orderedAlphabet.Add(16, "q");
        orderedAlphabet.Add(17, "r");
        orderedAlphabet.Add(18, "s");
        orderedAlphabet.Add(19, "t");
        orderedAlphabet.Add(20, "u");
        orderedAlphabet.Add(21, "v");
        orderedAlphabet.Add(22, "w");
        orderedAlphabet.Add(23, "x");
        orderedAlphabet.Add(24, "y");
        orderedAlphabet.Add(25, "z");
        return orderedAlphabet;
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        MessageBox.Show(ex.Message);
        throw new Exception(ex.Message);
      }
    }
    // Define a relação de ordem entre caracteres <=
    public static bool IsFirstCharLessThanSecond(char first, char second)
    {
      try
      {
        // Pego a chave numérica dos caracteres de entrada
        // Tal inversão ocorre tranquilamente pois a função é bijetora
        int keyOfFirst = OrderedAlphabet().Where(pair => pair.Value == first.ToString().ToLower()).FirstOrDefault().Key;
        int keyOfSecond = OrderedAlphabet().Where(pair => pair.Value == second.ToString().ToLower()).FirstOrDefault().Key;
        // Comparo-as pela ordem usual dos números naturais
        return keyOfFirst <= keyOfSecond;
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        MessageBox.Show(ex.Message);
        throw new Exception(ex.Message);
      }
    }
    // Define a relação de Igual nesta ordem
    public static bool IsCharIqualInThisOrder(char first, char second)
    {
      try
      {
        return IsFirstCharLessThanSecond(first, second) &&
        IsFirstCharLessThanSecond(second, first);
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        MessageBox.Show(ex.Message);
        throw new Exception(ex.Message);
      }
    }
    // Generalizando para cadeias de caracteres
    public static bool IsFirstStringLessThanSecond(string first, string second)
    {
      try
      {
        // Coletamos o tamanho da menor das strings
        int min = Math.Min(first.Length, second.Length);
        // Transformamos as strings em vetores de caracteres, cortando em min
        char[] firstStringList = first.Substring(0, min).ToCharArray();
        char[] secondStringList = second.Substring(0, min).ToCharArray();
        // Agora zipamos as duas listas, obtendo uma lista de pares ordenados
        List<List<char>> zipedLists = new List<List<char>>();
        for (int i = 0; i < min; i++)
        {
          zipedLists.Add(new List<char> { firstStringList[i], secondStringList[i] });
        }
        // Vamos desempatando uma a uma
        foreach (List<char> pair in zipedLists)
        {
          if (!IsCharIqualInThisOrder(pair[0], pair[1]))
          {
            return IsFirstCharLessThanSecond(pair[0], pair[1]);
          }
        }
        // Caso tenham empatado em todas as letras
        return true; // Pois é ordem parcial
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        MessageBox.Show(ex.Message);
        throw new Exception(ex.Message);
      }
    }
    #endregion
  }
}
