class Human
{
  // Properties for Human
  public string Name {get; set;}
  public int Strength {get; set;}
  public int Intelligence {get; set;}
  public int Dexterity {get; set;}
  public int Health {get; set;}

  // Add a constructor that takes a value to set Name, and set the remaining fields to default values
  public Human( string name )
  {
    Name = name;
    Strength = 3;
    Intelligence = 3;
    Dexterity = 3;
    Health = 100;
  }

  // Add a constructor to assign custom values to all fields
  public Human(string name, int str, int intel, int dex, int health)
  {
    Name = name;
    Strength = str;
    Intelligence = intel;
    Dexterity = dex;
    Health = health;
  }

  // Build Attack method
  public virtual int Attack(Human target)
  {
    target.Health -= Strength * 5;
    return target.Health;
  }

  public void printInfo()
  {
    Console.WriteLine($"Name: {Name}");
    Console.WriteLine($"Strength: {Strength}");
    Console.WriteLine($"Intelligence: {Intelligence}");
    Console.WriteLine($"Dexterity: {Dexterity}");
    Console.WriteLine($"Health: {Health}");
    
  }
}

