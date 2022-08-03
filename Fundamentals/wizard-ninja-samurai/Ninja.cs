class Ninja : Human
{
  public Ninja(string name) : base (name)
  {
    Name = name;
    Dexterity = 175;
  }

  public override int Attack(Human target)
  {
    Random random = new Random();
    int rand = random.Next(0,101);
    target.Health -= Dexterity * 5;
    if(rand < 20 ) {
      target.Health -= 10;
      Console.WriteLine("!! dealt 10 extra damage");
    }
    if (target.Health < 0)
    {
      Console.WriteLine($"{Name} killed {target.Name}");
    } else {
      Console.WriteLine($"{Name} Attacked {target.Name}, their health is now {target.Health}");
    }
    
    return target.Health;
  }

  public int Steal(Human target)
  {
    target.Health -= 5;
    Health += 5;
    Console.WriteLine($"{Name} stole 5 health from {target.Name}");
    return target.Health;
  }
}