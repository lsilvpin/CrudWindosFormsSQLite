using System.ComponentModel;

namespace LearningWindowsForms.model
{
  /// <summary>
  /// Modelo de dado com o qual estamos trabalhando
  /// </summary>
  class Character
  {
    // Atributos que definem o conceito de Personagem, neste caso
    [DisplayNameAttribute("Id")]
    public int Id { get; set; } // Chave primária
    [DisplayNameAttribute("Name")]
    public string Name { get; set; } // Nome
    [DisplayNameAttribute("Race")]
    public string Race { get; set; } // Raça
    [DisplayNameAttribute("Role")]
    public string Role { get; set; } // Estilo
    // Construtores
    public Character() : base() {}
    public Character(string name, string race, string role)
    {
      Name = name;
      Race = race;
      Role = role;
    }
  }
}
