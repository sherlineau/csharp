class Wizard : Human
{

  // constructor
  public Wizard(string name) : base(name)
  {
    Name = name;
    Intelligence = 25;
    Health = 50;
  }

  public override int Attack(Human target)
  {
    target.Health -= Intelligence * 5;
    Health += Intelligence * 5;
    if (target.Health > 0)
    {
      Console.WriteLine($"Attacking {target.Name}, {target.Name} has {target.Health} remaining. Healed self for {Intelligence * 5}, {Name}'s health is now {Health}");
    }
    else
    {
      Console.WriteLine($"{Name} killed {target.Name} and healed for {Intelligence * 5}");
    }
    return target.Health;
  }

  public int Heal(Human target)
  {
    target.Health += Intelligence * 10;
    return target.Health;
  }

  public int Heal()
  {
    Health += Intelligence * 5;
    return Health;
  }

}