class Ninja
{
  private int calorieIntake;
  public int CalorieAmount {
    get {
      return calorieIntake;
    }
  }

  public List<Food> FoodHistory;

  // add a constructor
  public Ninja()
  {
    calorieIntake = 0;
    FoodHistory = new List<Food>() {};
  }
  // add a public "getter" property called "IsFull"
  public bool IsFull
  {
    get{
      bool full = false;
      if (calorieIntake > 1200)
      {
        full = true;
      }
      return full;
    }
  }

  // build out the Eat method
  public void Eat(Food item)
  {
    calorieIntake += item.Calories;
    FoodHistory.Add(item);
    Console.WriteLine($"Food name: {item.Name}, Spicy: {item.IsSpicy}, Sweet: {item.IsSweet}");
  }
}

