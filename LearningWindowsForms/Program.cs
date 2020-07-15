using LearningWindowsForms.repository;
using LearningWindowsForms.view;
using System;
using System.Windows.Forms;

namespace LearningWindowsForms
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Seed.CreateSqliteDataBase();
      Seed.Read("k");
    }
  }
}
