namespace LearningWindowsForms.model
{
  class Character
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Race { get; set; }
    public string Role { get; set; }

    public Character() : base() {}
    public Character(int id, string name, string race, string role)
    {
      Id = id;
      Name = name;
      Race = race;
      Role = role;
    }
  }
}
