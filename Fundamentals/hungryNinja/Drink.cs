class Drink : IConsumable
{
  public string Name { get; set; }
  public int Calories { get; set; }
  public bool IsSpicy { get; set; }
  public bool IsSweet { get; set; }

  public string GetInfo() 
  {
     return $"{Name} (Drink). Calries: {Calories}. Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
  }

  public Drink(string name, int cal, bool spicy, bool sweet)
  {
    Name = name;
    Calories = cal;
    IsSpicy = spicy;
    IsSweet = sweet;
  }
}