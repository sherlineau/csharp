class Samurai : Human
{
  public Samurai(string name) : base(name)
  {
    Name = name;
    Health = 200;
  }

  public override int Attack(Human target)
  {
    base.Attack(target);
    Console.WriteLine($"{Name} attacked {target.Name}, {target.Name}'s health is now {target.Health}");
    if (target.Health < 50)
    {
      target.Health = 0;
      Console.WriteLine($"{target.Name} died");
    }
    return target.Health;
  }

  public int Meditate()
  {
    Health = 200;
    Console.WriteLine($"{Name} meditated, health restored to 200");
    return Health;
  }
}