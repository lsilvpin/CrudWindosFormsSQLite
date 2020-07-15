using LearningWindowsForms.model;
using LearningWindowsForms.services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LearningWindowsForms.repository
{
  static class Seed
  {
    private static readonly string _ConnectionString = @"Data Source=learningwindowsforms.db";
    private static readonly string _DataBaseName = @"learningwindowsforms.db";
    /// <summary>
    /// Cria o banco de dados, caso ainda não exista
    /// </summary>
    public static void CreateSqliteDataBase()
    {
      if (!File.Exists(_DataBaseName))
      {
        SQLiteConnection.CreateFile(_DataBaseName); // Cria o arquivo
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
    /// <summary>
    /// Procura no banco de dados registros contendo uma dada string em qualquer de seus dados
    /// </summary>
    /// <param name="search">String a ser procurada</param>
    /// <returns></returns>
    public static bool Read(string search)
    {
      SQLiteConnection connection = new SQLiteConnection(_ConnectionString);
      StringBuilder sqlQuery = new StringBuilder();
      sqlQuery.AppendLine(String.Concat("SELECT (Name, Race, Role) FROM Character WHERE Name = '%",
        search, "%'"));
      // Tenta extrair resultado da consulta do banco
      try
      {
        connection.Open();
        SQLiteCommand command = new SQLiteCommand(sqlQuery.ToString(), connection);
        SQLiteDataReader SqliteDataReader = command.ExecuteReader(); // Executa a leitura, e extrai resultados
        if (SqliteDataReader.HasRows)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        Utility.Log(ex.Message);
        MessageBox.Show(ex.Message);
        return false;
      }
    }
    /// <summary>
    /// Atualisa um registro no banco de dados
    /// </summary>
    /// <param name="id">id do registro a ser atualisado</param>
    /// <param name="character">objeto Character com informações a serem submetidas no banco</param>
    public static void Update(int id, Character character)
    {
      SQLiteConnection.CreateFile(_DataBaseName); // Cria o arquivo
      SQLiteConnection connection = new SQLiteConnection(_ConnectionString);
      StringBuilder sqlQuery = new StringBuilder();
      sqlQuery.AppendLine("update Character set Name = @Name, Race = @Race, Role = @Role where Id = @Id");
      // Tenta extrair resultado da consulta do banco
      try
      {
        connection.Open();
        SQLiteCommand command = new SQLiteCommand(sqlQuery.ToString(), connection);
        // As linhas abaixo fazem a interpolação na string strSql
        command.Parameters.Add("Name", DbType.String).Value = character.Name;
        command.Parameters.Add("Race", DbType.String).Value = character.Race;
        command.Parameters.Add("Role", DbType.String).Value = character.Role;
        command.Parameters.Add("Id", DbType.String).Value = id;
        SQLiteDataReader SqliteDataReader = command.ExecuteReader(); // Executa a leitura, e extrai resultados
        command.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        Utility.Log(ex.Message);
        MessageBox.Show(ex.Message);
      }
    }



    //private void Get()
    //{
    //  DataTable dt = new DataTable();
    //  SQLiteConnection conn = null;
    //  String sql = "select * from Character";
    //  String strConn = @"Data Source=C:\Users\lsilvpin\source\repos\LearningWindowsForms\LearningWindowsForms\data\learningwindowsforms.db";
    //  try
    //  {
    //    conn = new SQLiteConnection(strConn);
    //    SQLiteDataAdapter da = new SQLiteDataAdapter(sql, strConn);
    //    da.Fill(dt);
    //    DataView defaultView = dt.DefaultView;
    //    Index = defaultView;
    //  }
    //  catch (Exception ex)
    //  {
    //    MessageBox.Show("Erro :" + ex.Message);
    //  }
    //  finally
    //  {
    //    if (conn.State == ConnectionState.Open)
    //    {
    //      conn.Close();
    //    }
    //  }
    //}
  }
}
