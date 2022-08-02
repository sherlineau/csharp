namespace Basic13
{
  class Program
  {
    public static void Main(string[] args)
    {
      //PrintNumbers();
      // PrintOdds();
      // PrintSum();
      int[] nums = { -2, 5, 1, 6, 7, 8 };
      // LoopArray(nums);
      // FindMax(nums);
      // GetAverage(nums);
      // OddArray();
      // int y = 1;
      // Console.WriteLine($"Number of values greater than {y}: {GreaterThanY(nums, y)}");
      // SquareArrayValues(nums);
      // EliminateNegatives(nums);
      // MinMaxAverage(nums);
      // ShiftValues(nums);
      Console.WriteLine("[{0}]", string.Join(", ",NumToString(nums)));
    }

    static void PrintNumbers()
    {
      for (int i = 1; i <= 255; i++)
      {
        Console.WriteLine($"{i}");
      }
    }

    static void PrintOdds()
    {
      for (int i = 1; i <= 255; i++)
      {
        if (i % 2 != 0)
        {
          Console.WriteLine($"{i}");
        }
      }
    }

    static void PrintSum()
    {
      int sum = 0;
      for (int i = 0; i <= 255; i++)
      {
        sum += i;
        Console.WriteLine($"New Number: {i} Sum: {sum}");
      }
    }

    static void LoopArray(int[] numbers)
    {
      foreach (int num in numbers)
      {
        Console.WriteLine($"{num}");
      }
    }

    static void FindMax(int[] numbers)
    {
      int max = numbers.Max();
      Console.WriteLine($"Max number is: {max}");
    }

    static void GetAverage(int[] numbers)
    {
      int sum = 0;
      foreach (int num in numbers)
      {
        sum += num;
      }
      double average = sum / numbers.Length;
      Console.WriteLine($"Average of numbers array is: {average}");
    }

    static int[] OddArray()
    {
      List<int> nums = new List<int>();
      for (int i = 1; i <= 255; i++)
      {
        if (i % 2 != 0)
        {
          nums.Add(i);
        }
      }
      int[] output = nums.ToArray();
      return output;
    }

    static int GreaterThanY(int[] numbers, int y)
    {
      int count = 0;
      foreach (int number in numbers)
      {
        if (number > y)
        {
          count++;
        }
      }
      return count;
    }

    static void SquareArrayValues(int[] numbers)
    {
      List<int> output = new List<int>();
      for (int i = 0; i < numbers.Length; i++)
      {
        output.Add(numbers[i] * numbers[i]);
      }
      foreach (int num in output)
      {
        Console.WriteLine($"{num}");
      }
    }

    static void EliminateNegatives(int[] numbers)
    {
      for (int i = 0; i < numbers.Length; i++)
      {
        if (numbers[i] < 0)
        {
          Console.WriteLine($"{numbers[i]} was replaced by 0");
          numbers[i] = 0;
        }
        else
        {
          Console.WriteLine(numbers[i]);
        }
      }
    }

    static void MinMaxAverage(int[] numbers)
    {
      int sum = 0;
      foreach (int num in numbers)
      {
        sum += num;
      }

      int max = numbers.Max();
      Console.WriteLine($"Max in Array: {max}");

      int min = numbers.Min();
      Console.WriteLine($"Min in Array: {min}");

      int avg = sum / numbers.Length;
      Console.WriteLine($"Array's average: {avg}");

    }

    static void ShiftValues(int[] numbers)
    {
      for (int i = 0; i < numbers.Length; i++)
      {
        if (i == numbers.Length - 1)
        {
          numbers[numbers.Length - 1] = 0;
        }
        else
        {
          numbers[i] = numbers[i + 1];
        }
      }
      foreach (int num in numbers)
      {
        Console.WriteLine($"{num}");
      }
    }

    static object[] NumToString(int[] numbers)
    {
      List<object> output = new List<object>();
      for ( var i = 0; i < numbers.Length; i++)
      {
        if ( numbers[i] < 0 )
        {
          output.Add("Dojo");
        }
        else 
        {
          output.Add(numbers[i]);
        }
      }
      return output.ToArray();
    }
  }
}
