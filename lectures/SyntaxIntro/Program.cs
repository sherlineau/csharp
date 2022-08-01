// C# functions need to have return type -> void returns nothing sinc we are just console.logging

/* bool FizzBuzz () {
  return true;
}
*/
void FizzBuzz(int range = 100)
{
  for (int i = 1; i <= range; i++)
  {
    bool divisibleByThree = i % 3 == 0;
    bool divisibleByFive = i % 5 == 0;
    if (divisibleByFive && divisibleByThree)
    {
      Console.WriteLine("FizzBuzz");
    }
    else if (divisibleByThree)
    {
      Console.WriteLine("Fizz");
    }
    else if (divisibleByFive)
    {
      Console.WriteLine("Buzz");
    }
    else
    {
      Console.WriteLine(i);
    }
  }
}

// we need to call the function for the program to run through fizzbuzz
FizzBuzz(0);

// creating a new EMPTY list
List<string> emptyFlavors = new List<string>();

List<string> flavors = new List<string>() {
  "cherry garcia",
  "mint chocolate chip",
  "chocolate",
  "chocolate chip"
};

// add a new flavor to end of list
flavors.Add("caramel");
// insert at a specific index location
flavors.Insert(2, "caramel");

// remove a flavor from list
flavors.RemoveAt(0);

// Console.WriteLine($"count of flavors list: {flavors.Count}");
// // Console.WriteLine(flavors[1]);

// foreach (string flavor in flavors)
// {
//   Console.WriteLine(flavor);
// }

List<int> orderedNums = new List<int>() {
  1, 2, 3, 4, 5, 6, 7, 8, 9, 10
};

List<int> shuffledNums = new List<int>();

Random rand = new Random();

// Console.WriteLine(rand.Next(0,15));

while (orderedNums.Count > 0) 
{
  int randIdx = rand.Next(0, orderedNums.Count);
  Console.WriteLine($"Removing {orderedNums[randIdx]} from ordered nums");
  shuffledNums.Add(orderedNums[randIdx]);
  orderedNums.RemoveAt(randIdx);
}

foreach (int num in shuffledNums)
{
  Console.WriteLine($"{num}");
}


// creating dictionarys 
// need to declare the data types for key and value
// key is strings, values are strings
Dictionary<string, string> someDictionary = new Dictionary<string, string>() {
  {"name", "Lenddy"},
  {"fav_color", "purple"},
  {"age", "23"}
};

Console.WriteLine($"{someDictionary["name"]}");
