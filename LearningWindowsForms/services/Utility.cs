using LearningWindowsForms.model;
using LearningWindowsForms.repository;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LearningWindowsForms.services
{
  /// <summary>
  /// Esta classe possui serviços e ferramentas úteis em toda a aplicação
  /// </summary>
  class Utility
  {
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
        Seed.Read(search, id);
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
    public static bool UpdateRecordInDataBase(Character character)
    {
      if (character.Id == 0)
      { // Se vier sem Id, tem que vir com Nome, e achamos o Id pelo nome
        character.Id = Seed.Read(character.Name)[0].Id;
      }
      try
      {
        Seed.Update(character.Id, character);
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
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Utility.CreateDataBaseIfNecessary();
        return true;
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        return false;
      }

    }

    public static bool NavigateTo(string windowName)
    {
      try
      {

        return true;
      }
      catch(Exception ex)
      {
        Log(ex.Message);
        return false;
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
        Log(String.Concat("A função ", serviceName, "() executou com sucesso!"));
      }
      else
      {
        Log(String.Concat("A função ", serviceName, "() finalizou com erro(s)!"));
      }
    }
    #endregion
  }
}
