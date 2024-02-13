using System;

public class Player
{
    private Random rnd = new Random();

    public int RollDie() => rnd.Next(1, 19);

    public double GenerateSpellStrength() => rnd.NextDouble() * 100;

}
