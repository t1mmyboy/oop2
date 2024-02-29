// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;
/*
Console.WriteLine("Pokemon Battle Simulator");
var trainer1 = new Trainer("Henk");
var trainer2 = new Trainer("Bob");
trainer1.takePokeball(new Pokeball(new Charmander("blaze1")));
trainer1.takePokeball(new Pokeball(new Charmander("blaze2")));
trainer1.takePokeball(new Pokeball(new Charmander("blaze3")));
trainer1.takePokeball(new Pokeball(new Charmander("blaze4")));
trainer1.takePokeball(new Pokeball(new Charmander("blaze5")));
trainer1.takePokeball(new Pokeball(new Charmander("blaze6")));

trainer2.takePokeball(new Pokeball(new Charmander("steve1")));
trainer2.takePokeball(new Pokeball(new Charmander("steve2")));
trainer2.takePokeball(new Pokeball(new Charmander("steve3")));
trainer2.takePokeball(new Pokeball(new Charmander("steve4")));
trainer2.takePokeball(new Pokeball(new Charmander("steve5")));
trainer2.takePokeball(new Pokeball(new Charmander("steve6")));
while (true)
{
    for (int x = 0; x < trainer1.belt.Count; x++)
    {
        var charm2 = trainer1.throwPokeball();
        trainer1.returnPokemon(charm2);

        var charm3 = trainer2.throwPokeball();
        trainer2.returnPokemon(charm3);
    }
    Console.WriteLine("Do you want to play again?");
    string answer = Console.ReadLine();
    if (answer == "no" || answer == "No")
    {
        break;
    }
    else { trainer1.teller = 0;
        trainer2.teller = 0;
    }
}


public class Charmander
{
    public string? nickname;
    public string strenght;
    public string weakness;
    public Charmander(string newNickname)
    {
        this.nickname = newNickname;
        this.strenght = "fire";
        this.weakness = "water";
    }

    public void battleCry()
    {
        Console.WriteLine(getName().ToUpper());
    }
    public string getName()
    {
        return this.nickname;
    }
}


public class Pokeball
{
    public Charmander? Charmander;
    public bool hasCharmanderInside;

    public Pokeball(Charmander Charmander)
    {
        this.Charmander = Charmander;
        this.hasCharmanderInside = true;

    }
    public Charmander Open()
    {
        hasCharmanderInside = false;
        return Charmander;
    }
    public void Close()
    {
        hasCharmanderInside = true;
    }


}

public class Trainer
{
    public List<Pokeball> belt;
    public string? name;
    public int teller = 0;

    public Trainer(string name)
    {
        this.belt = new List<Pokeball>();
        this.name = name;
    }

    public void takePokeball(Pokeball pokeball)
    {
        // check for maximum amount of pokeballs
        if (belt.Count >= 6) { Console.WriteLine(belt.Count); throw new Exception("Kan niet meer dan 6 Pokemons hebben op uw belt!");}
        else { belt.Add(pokeball); }
    }
    public Charmander throwPokeball()
    {
        Charmander charm1 = belt[teller].Open();
        Console.WriteLine(name+"'s Charmander says: " + charm1.getName());
        teller = teller + 1;
        return charm1;
    }
    public void returnPokemon(Charmander charmander)
    {
        
        Console.WriteLine(name + " Returns: " + charmander.getName());
    }
}
*/




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

    for (int i = 0; i < 6; i++)
    {
        trainer1.teller = i;
        Pokemon pokemon = trainer1.throwPokeball();
        trainer1.returnPokemon(pokemon);

        trainer2.teller = i;
        Pokemon pokemon2 = trainer2.throwPokeball();
        trainer2.returnPokemon(pokemon2);

    }

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
    