namespace Puzzles
{
  class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("[{0}]", string.Join(", ", RandomArray()));
      Console.WriteLine($"Tossing a coin:... {TossCoin()}");
      Names();
      
    }

    static int[] RandomArray()
    {
      Random rand = new Random();
      int[] randomNums = new int[10];
      int sum = 0;
      for (int i = 0; i < randomNums.Length; i++)
      {
        randomNums[i] = rand.Next(5, 25);
      }

      foreach (int num in randomNums)
      {
        sum += num;
      }
      Console.WriteLine($"Min: {randomNums.Min()}");
      Console.WriteLine($"Max: {randomNums.Max()}");
      Console.WriteLine($"Sum: {sum}");
      return randomNums;
    }

    static string TossCoin()
    {
      Random rand = new Random();
      string[] coin = {"Heads", "Tails"};
      return coin[rand.Next(2)];
    }

    static List<string> Names()
    {
      List<string> names = new List<string>()
      {
        "Todd",
        "Tiffany",
        "Charlie",
        "Geneva",
        "Sydney"
      };
      List<string> filtered = new List<string>();
      foreach ( var name in names)
      {
        if (name.Length > 5) {
          filtered.Add(name);
        }
      }
      Random rand = new Random();
      var shuffled = filtered.OrderBy(item => rand.Next());
      Console.WriteLine($"Shuffled & Longer than 5 characters: " + "[{0}]", string.Join(", ", shuffled));
      
      return filtered;
    }
  }
}