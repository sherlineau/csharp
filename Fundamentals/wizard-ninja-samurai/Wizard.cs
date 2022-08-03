class Wizard : Human {

// constructor
  public Wizard(string name, int str, int dex) : base(name) 
  {
    Name = name;
    Strength = str;
    Dexterity = dex;
    Intelligence = 25;
    Health = 50;
  }

  public override int Attack(Human target) {
    target.Health -= Intelligence * 5;
    Heal();
    return target.Health;
  }

  public int Heal(Human target) {
    target.Health += Intelligence * 10;
    return target.Health;
  }

  public int Heal() {
    Health += Intelligence * 5;
    return Health;
  }

}