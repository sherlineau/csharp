class Player {
  public string Name {get;set;}
  public List<Card> Hand {get;set;} = new List<Card>(3);

  public Player(string name)
  {
    Name = name;
  }

  public void DrawCard(Deck deck)
  {
    Hand.Add(deck.DealCard());
  }
}