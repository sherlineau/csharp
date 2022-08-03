Buffet buffet = new Buffet();
Ninja sherline = new SweetTooth();
Ninja linda = new SpiceHound();

Console.WriteLine("--- sweet tooth ---");
while (!sherline.IsFull) {
  sherline.Consume(buffet.Serve());
}

Console.WriteLine("--- spice hound ---");
while(!linda.IsFull)
{
  linda.Consume(buffet.Serve());
}

if (sherline.ConsumptionHistory.Count > linda.ConsumptionHistory.Count) 
{
  Console.WriteLine($"Sweet Tooth ate the most items: {sherline.ConsumptionHistory.Count} . ");
}
else
{
  Console.WriteLine($"Spice Hound ate most items: {linda.ConsumptionHistory.Count}.");
}