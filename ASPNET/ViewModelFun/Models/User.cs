#pragma warning disable CS8618
namespace MyApp.Models;

public class User
{
  public string FirstName { get; set; }
  public string LastName { get; set; }

  public User(string firstName, string lastName) 
  {
    FirstName = firstName;
    LastName = lastName;
  }
}