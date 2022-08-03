Player sherline = new Player("Sherline");
Player linda = new Player("Linda");

// Console.WriteLine($"____ new deck ____");
Deck deck = new Deck();
// deck.PrintDeck();
Console.WriteLine(deck);

// Console.WriteLine($"____ shuffled deck ____");
deck.ShuffleDeck();
// deck.PrintDeck();

sherline.DrawCard(deck);
sherline.DrawCard(deck);
sherline.DrawCard(deck);
sherline.DrawCard(deck);
sherline.DrawCard(deck);
linda.DrawCard(deck);
linda.DrawCard(deck);
linda.DrawCard(deck);
linda.DrawCard(deck);
linda.DrawCard(deck);

Console.WriteLine(sherline.Hand[0]);
Console.WriteLine(linda.Hand[3]);
Console.WriteLine(deck);

deck.RebuildDeck();
Console.WriteLine("Rebuilding deck "+ deck);
