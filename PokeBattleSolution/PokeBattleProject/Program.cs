// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;
while (true)
{
    Console.WriteLine("Pokemon battle simulator");
    Console.WriteLine("Name for trainer 1: ");
    string name1 = Console.ReadLine();
    Console.WriteLine("Name for trainer 2: ");
    string name2 = Console.ReadLine();

    Trainer trainer1 = new Trainer(name1);
    Trainer trainer2 = new Trainer(name2);


    trainer1.takePokeball(new Pokeball(new Charmander("Charmander")));
    trainer1.takePokeball(new Pokeball(new Charmander("Charmander")));
    trainer2.takePokeball(new Pokeball(new Charmander("Charmander2")));
    trainer2.takePokeball(new Pokeball(new Charmander("Charmander2")));
    trainer1.takePokeball(new Pokeball(new Bulbasaur("Bulbasaur")));
    trainer2.takePokeball(new Pokeball(new Bulbasaur("Bulbasaur2")));
    trainer1.takePokeball(new Pokeball(new Bulbasaur("Bulbasaur")));
    trainer2.takePokeball(new Pokeball(new Bulbasaur("Bulbasaur2")));
    trainer1.takePokeball(new Pokeball(new Squirtle("Squirtle")));
    trainer2.takePokeball(new Pokeball(new Squirtle("Squirtle2")));
    trainer1.takePokeball(new Pokeball(new Squirtle("Squirtle")));
    trainer2.takePokeball(new Pokeball(new Squirtle("Squirtle2")));

    Battle battle = new Battle(trainer1, trainer2);
    battle.randomizer();

    int[] winners = battle.pokemonChecker();
    battle.winnerChecker(winners);

    

    Console.WriteLine("Do you wish to play again?");
    string answer = Console.ReadLine();
    if (answer == "No" || answer == "no")
    {
        break;
    }
}
public abstract class Pokemon
{
    public string? nickname;
    public string strenght;
    public string weakness;

    public Pokemon(string newNickname)
    {
        this.nickname = newNickname;
        this.strenght = strenght;
        this.weakness = weakness;
    }

    public abstract void BattleCry();
}

public class Charmander : Pokemon
{
    public Charmander(string newNickname) : base(newNickname)
    {
        this.strenght = "Fire";
        this.weakness = "Water";
    }
    public override void BattleCry()
    {
        Console.WriteLine(getName() + " says: Charmander!");
    }

    public string getName()
    {
        return this.nickname;
    }
}
public class Bulbasaur : Pokemon
{
    public Bulbasaur(string newNickname) : base(newNickname)
    {
        this.strenght = "Grass";
        this.weakness = "Fire";
    }
    public override void BattleCry()
    {
        Console.WriteLine(getName() + " Says: Bulbasaur!");
    }

    public string getName()
    {
        return this.nickname;
    }
}
public class Squirtle : Pokemon
{
    public Squirtle(string newNickname) : base(newNickname)
    {
        this.strenght = "Water";
        this.weakness = "Grass";
    }
    public override void BattleCry()
    {
        Console.WriteLine(getName()+ " Says: Squirtle!");
    }

    public string getName()
    {
        return this.nickname;
    }
}

public class Pokeball
{
    public bool hasPokemonInside = false;
    public Pokemon? currentPokemon;

    public Pokeball(Pokemon currentPokemon)
    {
        this.currentPokemon = currentPokemon;
        if(this.currentPokemon != null)
        {
            hasPokemonInside = true;
        }
    }

    public Pokemon Open()
    {
        Pokemon pokemon = currentPokemon;
        currentPokemon.BattleCry();
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
    public string name;
    public List<Pokeball> belt;
    public int teller = 0;


    public Trainer(string name)
    {
        this.name = name;
        this.belt = new List<Pokeball>();
    }

    public void takePokeball(Pokeball pokeball)
    {
        if (belt.Count >= 6) { Console.WriteLine(belt.Count); throw new Exception("Kan niet meer dan 6 Pokemons hebben op uw belt!"); }
        else { belt.Add(pokeball); }
    }

    public Pokemon throwPokeball()
    {
        Pokemon poke = belt[teller].Open();
        return poke;

    }

    public void returnPokemon(Pokemon pokemon)
    {
        belt[teller].Close(pokemon);
    }
}
public class Battle
{
    public static int trainer1wins;
    public static int trainer2wins;
    public Trainer? trainer1;
    public Trainer? trainer2;
    public static int round;

    public Battle (Trainer trainer1, Trainer trainer2)
    {
        this.trainer1 = trainer1;
        this.trainer2 = trainer2;
        trainer1wins = 0;
        trainer2wins = 0;
        round = 0;

        
    }
    public void randomizer()
    {
        Console.WriteLine("Randomizing belts...");
        Random rand = new Random();
        Random rand2 = new Random();
        trainer1.belt = trainer1.belt.OrderBy(_ => rand.Next()).ToList();
        trainer2.belt = trainer2.belt.OrderBy(_ => rand.Next()).ToList();

       
    }
    public int[] pokemonChecker()
    {
        
        while (true)
        {
            if (trainer1wins > 5 || trainer2wins > 5)
            {
                break;
            }
            
            Console.WriteLine("Round: " + round+1);
            trainer1.teller = trainer2wins;
            trainer2.teller = trainer1wins;
            Pokemon pokemon1 = trainer1.throwPokeball();
            Pokemon pokemon2 = trainer2.throwPokeball();
            
            
            if (pokemon1.strenght == pokemon2.weakness)
            {
                trainer1wins++;
                Console.WriteLine(trainer1.name+ "'s "+ pokemon1.nickname + " Defeats " + trainer2.name +"'s " +pokemon2.nickname);
            }
            else if (pokemon1.strenght == pokemon2.strenght)
            {
                trainer1wins++;
                trainer2wins++;
                Console.WriteLine(trainer1.name + "'s " + pokemon1.nickname + " Draws against " + trainer2.name + "'s " + pokemon2.nickname);
            }
            else if (pokemon1.weakness == pokemon2.strenght)
            {
                trainer2wins++;
                Console.WriteLine(trainer1.name + "'s " + pokemon1.nickname + " Loses against " + trainer2.name + "'s " + pokemon2.nickname);
            }
            Console.WriteLine(trainer1.name + ": " + trainer1wins + " " + trainer2.name + ": " + trainer2wins);
            round++;
            trainer1.returnPokemon(pokemon1);
            trainer2.returnPokemon(pokemon2);
            
        }
        int[] winners = { trainer1wins, trainer2wins };
        return winners;
    }
    public void winnerChecker(int[] winner)
    {
        if (winner[0] > winner[1])
        {
            Console.WriteLine(trainer1.name + " Wins!");
        }
        else if (winner[1] > winner[0])
        {
            Console.WriteLine(trainer2.name + " Wins!");
        }
        else if (winner[0] == winner[1])
        {
            Console.WriteLine(trainer1.name +" and "+trainer2.name+ " Draw!");
        }
    }
}
