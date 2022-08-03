class Deck
{
  public List<Card> Cards = new List<Card>();
  private int size = 52;
  private string[] suits = { "Hearts", "Diamonds", "Spades", "Clubs" };
  string[] faces = { "Ace", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
  int[] val = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

  public Deck()
  {
    CreateNormalDeck();
  }

  public void CreateNormalDeck()
  {
    for (int i = 0; i < size; i++)
    {
      Card card = new Card(
        faces[i % 13],
        suits[i % 4],
        val[i % 13]
      );
      Cards.Add(card);
    }
  }

  public void RebuildDeck()
  {
    Cards.Clear();
    CreateNormalDeck();
  }

  public void ShuffleDeck()
  {
    if (Cards.Count < size)
    {
      RebuildDeck();
    }
    for (int i = 0; i < size; i++)
    {
      Random rand = new Random();
      int random = rand.Next(size);
      Card temp = Cards[i];
      Cards[i] = Cards[random];
      Cards[random] = temp;
    }
  }

  public Card DealCard()
  {
    Card deal = Cards[0];
    Cards.RemoveAt(0);
    return deal;
  }

  public void PrintDeck()
  {
    foreach (Card card in Cards)
    {
      Console.WriteLine(card);
    }
  }

  public override string ToString()
  {
    return $"Max Size: {size}, Current Size:{Cards.Count}";
  }



}