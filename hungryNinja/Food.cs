class Food
{
  public string Name { get; set; }
  public int Calories { get; set; }
  public bool IsSpicy { get; set; }
  public bool IsSweet { get; set; }

  public Food(string name, int cal, bool spicy, bool sweet) {
    Name = name;
    Calories = cal;
    IsSpicy = spicy;
    IsSweet = sweet;
  }
}
