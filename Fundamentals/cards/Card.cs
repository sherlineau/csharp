class Card
{
  public string Face { get; set; }
  public string Suit { get; set; }
  public int Val { get; set; }

  public Card(string face, string suit, int val)
  {
    Suit = suit;
    Face = face;
    Val = val;
  }

  public override string ToString()
  {
    return $"{Face} of {Suit}";
  }
}