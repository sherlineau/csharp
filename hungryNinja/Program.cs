Buffet buffet = new Buffet();
Ninja sherline = new Ninja();
while (sherline.IsFull == false) {
  sherline.Eat(buffet.Serve());
}
Console.WriteLine($"Warning! Calorie intake is {sherline.CalorieAmount}. The ninja is full and cannot eat anymore!");

