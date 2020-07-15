using LearningWindowsForms.model;
using LearningWindowsForms.repository;
using System;
using System.IO;
using System.Text;

namespace LearningWindowsForms.services
{
  class Utility
  {
    private static string _LocalRepository = @"C:\Users\lsilvpin\source\repos";
    private static string _LogPath = @"~\LearningWindowsForms\LearningWindowsForms\data\Log.txt";
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
      catch(Exception ex)
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
      catch(Exception ex)
      {
        Log(ex.Message);
        return string.Empty;
      }
    }
    /// <summary>
    /// Chama a camada de repositório para atualizar o banco
    /// </summary>
    /// <param name="id">id do registro que será atualisado</param>
    /// <param name="character">objeto Character com infos a serem submetidos ao banco</param>
    public static void Update(int id, Character character)
    {
      try
      {
        Seed.Update(id, character);
      }
      catch (Exception ex)
      {
        Log(ex.Message);
      }
    }
  }
}
