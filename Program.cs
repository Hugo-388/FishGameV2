using System;
using FishGameV2;

using var game = new FishGameV2.myGame();

//Parser 
ParserJeux parserPosition = new ParserJeux("./xml/JeuPoisson.xml");
//parserPosition.ParserInfosJoueur("./xml/JeuPoisson.xml");

foreach (var position in ParserJeux.ParserInfosJoueur("./xml/JeuPoisson.xml"))
{
    Console.WriteLine(position);
}
{
    
}
game.Run();

