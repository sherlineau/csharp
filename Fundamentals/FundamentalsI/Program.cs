int i = 1;
while ( i <= 255) {
  Console.WriteLine($"{i}");
  i++;
}

for (int j = 1; j <=255; j++) {
  Console.WriteLine($"{j}");

}

for (int k = 1; k <= 100; k++) {
  bool isDivisble3 = k % 3 == 0;
  bool isDivisble5 = k % 5 == 0;

  if (isDivisble3 && isDivisble5) {
    Console.WriteLine("FizzBuzz");
  }
  else if (isDivisble3 ) {
    Console.WriteLine("Fizz");
  }
  else if (isDivisble5 ) {
    Console.WriteLine("Buzz");
  }
  else {
    Console.WriteLine($"{k}");

  }
}

int l = 1;
while (l <= 100)
{
  if (l % 3 == 0 && l % 5 == 0)
  {
    Console.WriteLine("FizzBuzz");
  }
  else if ( l % 3 == 0)
  {
    Console.WriteLine("Fizz");
    
  }
  else if ( l % 5 == 0)
  {
    Console.WriteLine("Buzz");
  }
  else 
  {
    Console.WriteLine(l);
  }
  l++;
}

