using System;
using FishGameV2;

using var game = new FishGameV2.myGame();

//Parser 
{
    Console.WriteLine(ParserJeux.ParserPositionJoueurX("./xml/JeuPoisson.xml"));
}

game.Run();

