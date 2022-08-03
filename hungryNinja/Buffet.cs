class Buffet
{
  public List<Food> Menu;

  //constructor
  public Buffet()
  {
    Menu = new List<Food>()
      {
        new Food("Katsudon", 1000, false, false),
        new Food("Fried Chicken", 800, false, false),
        new Food("Chicken Nuggets", 625, false, false),
        new Food("Big Mac", 700, false, false),
        new Food("curry", 400, true, false),
        new Food("sundae", 500, false, true),
        new Food("Ribeye Steak", 800, false, false),
      };
  }

  public Food Serve()
  {
    Random rand = new Random();
    return Menu[rand.Next(Menu.Count)];
  }
}

