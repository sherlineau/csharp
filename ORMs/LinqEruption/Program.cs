List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano"),
    new Eruption("Zaozan", 1867, "Honshu-Japan", 1841, "Complex volcano")
};

// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
  Console.WriteLine("\n" + msg);
  foreach (var item in items)
  {
    Console.WriteLine(item.ToString());
  }
}

static void PrintEachName(IEnumerable<dynamic> items, string msg = "")
{
  Console.WriteLine("\n" + msg);
  foreach (var item in items)
  {
    Console.WriteLine(item.Volcano);
  }
}

static void PrintNames(IEnumerable<dynamic> items, string msg = "")
{
  Console.WriteLine("\n" + msg);
  foreach (string name in items)
  {
    Console.WriteLine(name);
  }
}

Eruption? chile = eruptions.FirstOrDefault( e => e.Location == "Chile");
Console.WriteLine(chile.ToString());

Eruption? hawaii = eruptions.FirstOrDefault( e => e.Location == "Hawaiian Is");
if (hawaii == null) 
{
  Console.WriteLine($"No Hawaiian Is Eruption found.");
} else {
  Console.WriteLine(hawaii.ToString());
}

Eruption? newZealand = eruptions.FirstOrDefault( e => e.Location == "New Zealand" && e.Year > 1900);
if(newZealand != null) Console.WriteLine(newZealand.ToString());


IEnumerable<Eruption> over2000 = eruptions.Where( e => e.ElevationInMeters > 2000).ToList();
PrintEach(over2000,"Eruptions at elevations over 2000:");

IEnumerable<Eruption> zEruptions = eruptions.Where( e => e.Volcano.ToLower().StartsWith("z")).ToList();
PrintEachName(zEruptions, "Eruptions for volcanoes starting with Z");
Console.WriteLine($"Number of Volcanoes starting with Z: {zEruptions.Count()}");

int? maxElevation = eruptions.Max(e => e.ElevationInMeters);
Eruption? VolcanoAtMax = eruptions.FirstOrDefault(e => e.ElevationInMeters == maxElevation);
if(VolcanoAtMax != null) 
{
  Console.WriteLine(VolcanoAtMax.ToString());
  Console.WriteLine($"Name of Volcano at highest elevation: {VolcanoAtMax.Volcano}");
}

IEnumerable<Eruption> alpha = eruptions.OrderBy(e => e.Volcano);
IEnumerable<string> alphaNames = eruptions.OrderBy(e => e.Volcano).Select(e => e.Volcano);
PrintNames(alphaNames, "Volcano Names printed alphabetically:");

// IEnumerable<Eruption> before1000 = eruptions.Where( e => e.Year < 1000).OrderBy(e => e.Volcano);
// PrintEach(before1000, "Eruptions before 1000 CE in alphabetical order:");

IEnumerable<string> before1000names = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano);

PrintNames(before1000names, "Eruptions before 1000 CE in alphabetical order:");