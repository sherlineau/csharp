List<object> casting = new List<object>();

casting.Add(7);
casting.Add(28);
casting.Add(-1);
casting.Add(true);
casting.Add("chair");
int sum = 0;

foreach ( Object item in casting) {
  Console.WriteLine($"{item}");
}

foreach (var item in casting) {
  if (item is int) 
  {
    sum += (int)item;
  }
}
Console.WriteLine($"Sum: {sum}");
