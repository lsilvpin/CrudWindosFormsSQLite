using LearningWindowsForms.services;
using System;

namespace LearningWindowsForms
{
  /// <summary>
  /// Uma aplicação simples, para estudar o conceito de CRUD com WindowsForms
  /// </summary>
  static class Program
  {
    /// <summary>
    /// O ponto de entrada do aplicativo
    /// </summary>
    [STAThread]
    static void Main()
    {
      Utility.Log("Programa iniciou --------------------------------------------------");
      Utility.ValidateAndLog(Utility.PrepareEnvironmentForWindowsForms(), "PrepareEnvironmentForWindowsForms()");
    }
  }
}
