using System;
using System.Collections.Generic;
using System.Linq;
/*
public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Pokemon battle simulator");
            Console.WriteLine("Name for trainer 1: ");
            string name1 = Console.ReadLine();
            Console.WriteLine("Name for trainer 2: ");
            string name2 = Console.ReadLine();

            Trainer trainer1 = new Trainer(name1);
            Trainer trainer2 = new Trainer(name2);

            trainer1.TakePokeball(new Pokeball(new Charmander("Charmander")));
            trainer1.TakePokeball(new Pokeball(new Charmander("Charmander")));
            trainer2.TakePokeball(new Pokeball(new Charmander("Charmander2")));
            trainer2.TakePokeball(new Pokeball(new Charmander("Charmander2")));
            trainer1.TakePokeball(new Pokeball(new Bulbasaur("Bulbasaur")));
            trainer2.TakePokeball(new Pokeball(new Bulbasaur("Bulbasaur2")));
            trainer1.TakePokeball(new Pokeball(new Bulbasaur("Bulbasaur")));
            trainer2.TakePokeball(new Pokeball(new Bulbasaur("Bulbasaur2")));
            trainer1.TakePokeball(new Pokeball(new Squirtle("Squirtle")));
            trainer2.TakePokeball(new Pokeball(new Squirtle("Squirtle2")));
            trainer1.TakePokeball(new Pokeball(new Squirtle("Squirtle")));
            trainer2.TakePokeball(new Pokeball(new Squirtle("Squirtle2")));

            Battle battle = new Battle(trainer1, trainer2);
            battle.Randomizer();

            BattleResult result = battle.PokemonChecker();
            battle.WinnerChecker(result);

            Console.WriteLine($"Current Score: {trainer1.GetName()} - {Battle.GetTrainer1Wins()} | {trainer2.GetName()} - {Battle.GetTrainer2Wins()}");

            Console.WriteLine("Do you wish to play again?");
            string answer = Console.ReadLine();
            if (answer.Equals("No", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
        }
    }
}

public abstract class Pokemon
{
    private string? nickname;
    private PokemonType strength;
    private PokemonType weakness;

    public Pokemon(string newNickname, PokemonType strength, PokemonType weakness)
    {
        this.nickname = newNickname;
        this.strength = strength;
        this.weakness = weakness;
    }

    public abstract void BattleCry();

    public string GetNickname() => nickname!;
    public PokemonType GetStrength() => strength;
    public PokemonType GetWeakness() => weakness;
}

public class Charmander : Pokemon
{
    public Charmander(string newNickname) : base(newNickname, PokemonType.Fire, PokemonType.Water) { }

    public override void BattleCry()
    {
        Console.WriteLine(GetName() + " says: Charmander!");
    }

    public string GetName()
    {
        return GetNickname();
    }
}

public class Bulbasaur : Pokemon
{
    public Bulbasaur(string newNickname) : base(newNickname, PokemonType.Grass, PokemonType.Fire) { }

    public override void BattleCry()
    {
        Console.WriteLine(GetName() + " Says: Bulbasaur!");
    }

    public string GetName()
    {
        return GetNickname();
    }
}

public class Squirtle : Pokemon
{
    public Squirtle(string newNickname) : base(newNickname, PokemonType.Water, PokemonType.Grass) { }

    public override void BattleCry()
    {
        Console.WriteLine(GetName() + " Says: Squirtle!");
    }

    public string GetName()
    {
        return GetNickname();
    }
}

public enum PokemonType
{
    Fire,
    Water,
    Grass
}

public class Pokeball
{
    private bool hasPokemonInside = false;
    private Pokemon? currentPokemon;

    public Pokeball(Pokemon currentPokemon)
    {
        this.currentPokemon = currentPokemon;
        if (this.currentPokemon != null)
        {
            hasPokemonInside = true;
        }
    }

    public Pokemon Open()
    {
        Pokemon pokemon = currentPokemon!;
        currentPokemon!.BattleCry();
        hasPokemonInside = false;
        currentPokemon = null;
        return pokemon;
    }

    public void Close(Pokemon pokemon)
    {
        hasPokemonInside = true;
        currentPokemon = pokemon;
    }
}

public class Trainer
{
    private string name;
    private List<Pokeball> belt;
    public int teller = 0;
    private int maxBalls = 6;

    public Trainer(string name)
    {
        this.name = name;
        this.belt = new List<Pokeball>();
    }

    public void TakePokeball(Pokeball pokeball)
    {
        if (belt.Count >= maxBalls) throw new Exception("Cannot have more than 6 Pokemons on your belt!");
        else belt.Add(pokeball);
    }

    public Pokemon ThrowPokeball()
    {
        Pokemon poke = belt[teller].Open();
        return poke;
    }

    public void ReturnPokemon(Pokemon pokemon)
    {
        belt[teller].Close(pokemon);
    }

    public string GetName() => name;
    public List<Pokeball> GetBelt() => belt;
    public void SetBelt(List<Pokeball> belt1)
    {
        this.belt = belt1;
    }

    public int GetTeller()
    {
        return teller;
    }

}

public class Battle
{
    private static int trainer1wins;
    private static int trainer2wins;
    private Trainer? trainer1;
    private Trainer? trainer2;
    private static int round;

    public Battle(Trainer trainer1, Trainer trainer2)
    {
        this.trainer1 = trainer1;
        this.trainer2 = trainer2;
        trainer1wins = 0;
        trainer2wins = 0;
        round = 0;
    }

    public void Randomizer()
    {
        Console.WriteLine("Randomizing belts...");
        Random rand1 = new Random();
        Random rand2 = new Random();
        trainer1.SetBelt(trainer1!.GetBelt().OrderBy(_ => rand1.Next()).ToList());
        trainer2.SetBelt(trainer2!.GetBelt().OrderBy(_ => rand2.Next()).ToList());
    }




    private BattleResult ComparePokemon(Pokemon pokemon1, Pokemon pokemon2)
    {
        if (pokemon1.GetStrength() == pokemon2.GetWeakness())
        {
            trainer1wins++;
            return BattleResult.Win;
        }
        else if (pokemon1.GetStrength() == pokemon2.GetStrength())
        {
            trainer1wins++;
            trainer2wins++;
            return BattleResult.Draw;
        }
        else if (pokemon1.GetWeakness() == pokemon2.GetStrength())
        {
            trainer2wins++;
            return BattleResult.Lose;
        }
        return BattleResult.Win;  // Default to trainer1 win (for demonstration purposes)
    }

    public BattleResult PokemonChecker()
    {
        while (true)
        {
            if (trainer1wins > 5 || trainer2wins > 5)
            {
                break;
            }

            Console.WriteLine("Round: " + (round + 1));
            trainer1!.teller = trainer2wins;
            trainer2!.teller = trainer1wins;
            Pokemon pokemon1 = trainer1!.ThrowPokeball();
            Pokemon pokemon2 = trainer2!.ThrowPokeball();

            BattleResult result = ComparePokemon(pokemon1, pokemon2);
            Console.WriteLine(GetBattleMessage(trainer1, trainer2, pokemon1, pokemon2, result));
            round++;
            trainer1!.ReturnPokemon(pokemon1);
            trainer2!.ReturnPokemon(pokemon2);
        }

        return DetermineWinner();
    }

    private BattleResult DetermineWinner()
    {
        if (trainer1wins > trainer2wins)
            return BattleResult.Win;
        else if (trainer2wins > trainer1wins)
            return BattleResult.Lose;
        else
            return BattleResult.Draw;
    }

    public void WinnerChecker(BattleResult result)
    {
        switch (result)
        {
            case BattleResult.Win:
                Console.WriteLine(trainer1!.GetName() + " Wins!");
                break;
            case BattleResult.Lose:
                Console.WriteLine(trainer2!.GetName() + " Wins!");
                break;
            case BattleResult.Draw:
                Console.WriteLine(trainer1!.GetName() + " and " + trainer2!.GetName() + " Draw!");
                break;
        }
    }

    private string GetBattleMessage(Trainer trainer1, Trainer trainer2, Pokemon pokemon1, Pokemon pokemon2, BattleResult result)
    {
        string battleOutcome = result switch
        {
            BattleResult.Win => $"{trainer1.GetName()}'s {pokemon1.GetNickname()} defeats {trainer2.GetName()}'s {pokemon2.GetNickname()}",
            BattleResult.Draw => $"{trainer1.GetName()}'s {pokemon1.GetNickname()} draws against {trainer2.GetName()}'s {pokemon2.GetNickname()}",
            BattleResult.Lose => $"{trainer1.GetName()}'s {pokemon1.GetNickname()} loses against {trainer2.GetName()}'s {pokemon2.GetNickname()}",
            _ => "Unknown outcome"
        };

        return $"{battleOutcome} - Current Score: {trainer1.GetName()} - {GetTrainer1Wins()} | {trainer2.GetName()} - {GetTrainer2Wins()}";
    }

    public static int GetTrainer1Wins() => trainer1wins;
    public static int GetTrainer2Wins() => trainer2wins;
}

public enum BattleResult
{
    Win,
    Draw,
    Lose
}
*/




using System;

class MathOperations
{
    private static int result;

    public static void Add(int a, int b)
    {
        result = a + b;
    }

    // Incorrect use of static member - accessing private static member directly
    public static int GetResultDirectly()
    {
        return result;
    }
}

class Program
{
    static void Main()
    {
        // Performing addition using the Add method
        MathOperations.Add(5, 7);

        // Incorrect use of static member - accessing the private static member directly should now cause a compilation error
        Console.WriteLine("Result: " + MathOperations.GetResultDirectly());
    }
}
