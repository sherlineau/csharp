Human froilan = new Human ("Froilan", 5, 100, 10, 200);

Human aaron = new Human("Aaron");

// Console.WriteLine(froilan.Attack(aaron));

Wizard sherline = new Wizard("Sherline");
// sherline.printInfo();
// sherline.Attack(aaron);

Ninja lily = new Ninja("Lily");
// lily.printInfo();
// lily.Attack(froilan);

lily.Steal(aaron);
// lily.printInfo();

Samurai luna = new Samurai("Luna");
luna.Attack(aaron);
luna.Attack(aaron);
luna.Attack(aaron);
luna.Attack(aaron);

aaron.Attack(luna);
// luna.printInfo();
luna.Meditate();
// luna.printInfo();