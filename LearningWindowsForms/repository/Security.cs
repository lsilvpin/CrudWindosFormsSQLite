using System;

namespace LearningWindowsForms.repository
{
  /// <summary>
  /// Esta classe se preocupa com a segurança da informação
  /// </summary>
  class Security
  {
    /// <summary>
    /// Criptografar texto
    /// </summary>
    /// <param name="textToEncripty">Texto a ser criptografado</param>
    /// <returns></returns>
    public string Encripty(string textToEncripty)
    {
      try
      {
        string result = string.Empty;
        byte[] encryted = System.Text.Encoding.Unicode.GetBytes(textToEncripty);
        result = Convert.ToBase64String(encryted);
        return result;
      }
      catch (Exception ex)
      {
        Log(ex.Message);
        return string.Empty;
      }
    }
    /// <summary>
    /// Descriptografa texto
    /// </summary>
    /// <param name="encriptedText">Texto a ser descriptografado</param>
    /// <returns></returns>
    public string Decripty(string encriptedText)
    {
      string result = string.Empty;
      byte[] decryted = Convert.FromBase64String(encriptedText);
      result = System.Text.Encoding.Unicode.GetString(decryted);
      return result;
    }
  }
}
