class SpiceHound : Ninja
{
  public override bool IsFull
  {
    get
    {
      return calorieIntake >= 1200;
    }
  }

  public override void Consume(IConsumable item)
  {
    if (!IsFull)
    {
      calorieIntake += item.Calories;
      if (item.IsSpicy)
      {
        calorieIntake -= 5;
      }
      ConsumptionHistory.Add(item);
      Console.WriteLine(item.GetInfo());
    }
    else {
      Console.WriteLine("Spice Hound is full!");
    }
  }
}