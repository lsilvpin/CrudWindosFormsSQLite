using LearningWindowsForms.model;
using LearningWindowsForms.services;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LearningWindowsForms.repository
{
  /// <summary>
  /// Esta classe é o ambiente dedicado a se comunicar com o banco de dados
  /// </summary>
  static class Seed
  {
    // Informações básicas, necessários no processo de acessar o banco de dados
    private static readonly string _DataBasePath = Utility.MapPath(@"~\LearningWindowsForms\LearningWindowsForms\bin\Debug\learningwindowsforms.db");
    private static readonly string _ConnectionString = String.Concat("Data Source=", _DataBasePath);

    /// <summary>
    /// Cria o banco de dados, caso ainda não exista
    /// </summary>
    public static void CreateSqliteDataBase()
    {
      if (!File.Exists(_DataBasePath))
      {
        SQLiteConnection.CreateFile(_DataBasePath); // Cria o arquivo
        SQLiteConnection connection = new SQLiteConnection(_ConnectionString);
        StringBuilder sqlQuery = new StringBuilder();
        sqlQuery.AppendLine("CREATE TABLE IF NOT EXISTS Character ([Id] INTEGER PRIMARY KEY AUTOINCREMENT,");
        sqlQuery.AppendLine("[Name] VARCHAR(50), [Race] VARCHAR(50), [Role] VARCHAR(50))");
        try
        {
          connection.Open();
          SQLiteCommand command = new SQLiteCommand(sqlQuery.ToString(), connection);
          command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          Utility.Log(ex.Message);
          MessageBox.Show(ex.Message);
        }
      }
    }

    // O crud é o que manipula o banco de dados
    #region CRUD
    /// <summary>
    /// Cria um registro no banco de dados
    /// </summary>
    /// <param name="character">Insere este personagem no banco</param>
    public static void Create(Character character)
    {
      // Instancio uma conexão
      SQLiteConnection connection = new SQLiteConnection();
      // Crio a string de consulta
      StringBuilder sqlQuery = new StringBuilder();
      sqlQuery.Append(String.Concat("INSERT INTO Character (Name, Race, Role) VALUES ('",
        character.Name, "', '", character.Race, "', '", character.Role, "')"));
      // Prepara o ambiente para fazer a consulta
      try
      {
        // Abre a conexão
        connection.Open();
        // Instancia o comando
        SQLiteCommand command = new SQLiteCommand(sqlQuery.ToString(), connection);
        // Executa o comando
        command.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        Utility.Log(ex.Message);
      }
    }
    /// <summary>
    /// Procuramos registros no banco que batam com um Id, ou com uma string de busca
    /// </summary>
    /// <param name="id">id procurado</param>
    /// <param name="search">string de busca</param>
    /// <returns>Retorna uma lista com os personagens encontrados (seus id's embutidos)</returns>
    public static List<Character> Read(string search = "", int id = 0)
    {
      SQLiteConnection connection = new SQLiteConnection(_ConnectionString);
      StringBuilder sqlQuery = new StringBuilder();
      if (id != 0)
      { // Se id != 0, estamos procurando por um ID, então a string de consulta é a seguinte
        sqlQuery.AppendLine(String.Concat("SELECT * FROM Character WHERE [Id] = '", id, "';"));
      }
      else
      { // Caso id == 0, estamos filtrando o banco por uma string, então a string de consulta é a seguinte
        sqlQuery.AppendLine(String.Concat("SELECT * FROM Character WHERE [Name] LIKE '%", search,
          "%' OR [Race] LIKE '%", search, "%' OR [Role] LIKE '%", search, "%';"));
      }
      // Tenta extrair resultado da consulta do banco
      try
      {
        connection.Open();
        SQLiteCommand command = new SQLiteCommand(sqlQuery.ToString(), connection);
        SQLiteDataReader dr = command.ExecuteReader(); // Executa a leitura, e extrai resultados
        List<Character> characters = new List<Character>();
        while (dr.Read()) // Se retornou algum
        {
          characters.Add(new Character
          {
            Id = Convert.ToInt32(dr["Id"]),
            Name = Convert.ToString(dr["Name"]),
            Race = Convert.ToString(dr["Race"]),
            Role = Convert.ToString(dr["Role"])
          });
        }
        return characters;
      }
      catch (Exception ex)
      {
        Utility.Log(ex.Message);
        MessageBox.Show(ex.Message);
        throw ex;
      }
    }
    /// <summary>
    /// Atualisa um registro no banco de dados
    /// </summary>
    /// <param name="character">objeto Character com informações a serem submetidas no banco</param>
    public static void Update(int id, Character character)
    {
      // Primeiro encontramos as informações faltantes e às resgatamos para não perdê-las
      if (character.Name == null)
      {
        character.Name = Read("", id)[0].Name;
      }
      if (character.Race == null)
      {
        character.Race = Read("", id)[0].Race;
      }
      if (character.Role == null)
      {
        character.Role = Read("", id)[0].Role;
      }
      SQLiteConnection connection = new SQLiteConnection(_ConnectionString);
      StringBuilder sqlQuery = new StringBuilder();
      sqlQuery.AppendLine(String.Concat("UPDATE Character SET [Name] = '", character.Name,
        "', [Race] = '", character.Race, "', [Role] = '", character.Role, "' WHERE [Id] = '", character.Id, "';"));
      // Tenta extrair resultado da consulta do banco
      try
      {
        connection.Open();
        SQLiteCommand command = new SQLiteCommand(sqlQuery.ToString(), connection);
        command.ExecuteNonQuery(); // Executa o comando SQL no banco
      }
      catch (Exception ex)
      {
        Utility.Log(ex.Message);
        MessageBox.Show(ex.Message);
      }
    }
    /// <summary>
    /// Apaga um ou mais registros do banco de dados
    /// </summary>
    /// <param name="character">Entidade associada ao registro que será apagado</param>
    /// <param name="id">Id do registro que será apagado</param>
    public static void Delete(Character character, int id = 0)
    {
      // Instancia a conexão
      SQLiteConnection connection = new SQLiteConnection();
      // Cria a string de comando SQL baseada na entrada
      StringBuilder sqlQuery = new StringBuilder();
      if (id != 0)
      {
        sqlQuery.Append(String.Concat("DELETE FROM Character WHERE [Id] = '", id, "';"));
      }
      else
      {
        sqlQuery.Append(String.Concat("DELETE FROM Character WHERE [Name] = '", character.Name,
          "' AND [Race] = '", character.Race, "' AND [Role] = '", character.Role, "';"));
      }
      // Prepara o ambiente para acessar o banco e executar o comando
      try
      {
        // Abre a conexão
        connection.Open();
        // Instancia o comando
        SQLiteCommand command = new SQLiteCommand(sqlQuery.ToString(), connection);
        // Executa o comando
        command.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        Utility.Log(ex.Message);
      }
    }
    #endregion
  }
}
