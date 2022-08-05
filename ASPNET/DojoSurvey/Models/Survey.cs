public class Survey
{
  public string Name { get; set; }
  public string Location { get; set; }
  public string Language { get; set; }
  public string? Comment { get; set; }

  public Survey (string name, string location, string lang, string comment)
  {
    Name = name;
    Location = location;
    Language = lang;
    Comment = comment;
  }
}