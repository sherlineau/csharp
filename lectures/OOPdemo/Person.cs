namespace OOPDemo;

// Parent class
// public allows other files to use this class
public class Person 
{
  // getters / setters  -> allows you to write custom get and set method get; set; calls "default" get and set methods
  public string FirstName { get; set; }
  public string LastName { get; set; }

  // constructor
  public Person( string firstName, string lastName ) {
    FirstName = firstName;
    LastName = lastName;
  }

  public string FullName(){
    return $"{FirstName} {LastName}"; 
  }
}