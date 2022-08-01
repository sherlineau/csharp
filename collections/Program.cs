// Three Basic Arrays
// int[] values 0-9
int[] nums;
nums = new int[] {0,1,2,3,4,5,6,7,8,9};
Console.WriteLine($"Length of num array: {nums.Length}" );

string[] names = {"Tim","Martin","Nikki","Sora"};
Console.WriteLine($"Length of names array: {names.Length}" );

bool[] alt = {true, false, true, false, true, false, true, false, true, false};
Console.WriteLine($"Length of boolean array: {alt.Length}" );

//List of flavors
List<string> flavors = new List<string>() {
  "chocolate",
  "vanilla",
  "mint chocolate chip",
  "oreo",
  "strawberry"
};

Console.WriteLine($"Count of Flavors List: {flavors.Count}");
Console.WriteLine($"Removing Flavor: {flavors[2]}");
flavors.RemoveAt(2);
Console.WriteLine($"Length of Flavors List: {flavors.Count}");

// User Info Dictionary
Random rand = new Random();
Dictionary<string,string> userInfo = new Dictionary<string,string>();

// iterates through names array and creates a new Dictionary keyValue pair using the name and flavor at a random index [0-4] 
foreach ( string name in names ) 
{
  userInfo.Add($"{name}", flavors[rand.Next(0,5)]);
}

foreach (KeyValuePair<string,string> entry in userInfo)
{
  Console.WriteLine(entry.Key + " - " + entry.Value);
}