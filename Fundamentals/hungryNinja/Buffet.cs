class Buffet
{
  public List<IConsumable> Menu;

  //constructor
  public Buffet()
  {
    Menu = new List<IConsumable>()
      {
        new Food("Katsudon", 678, false, false),
        new Food("Fried Chicken", 320, false, false),
        new Drink("Dr Pepper", 150, false, true),
        new Food("Big Mac", 563, false, false),
        new Food("curry", 700, true, false),
        new Food("sundae", 500, false, true),
        new Food("buffalo wings", 260, true, false),
        new Drink("sweet tea", 75, false, true),
        new Drink("vodka",64,true,false)
      };
  }

  public IConsumable Serve()
  {
    Random rand = new Random();
    return Menu[rand.Next(Menu.Count)];
  }
}

