// See https://aka.ms/new-console-template for more information
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
        trainer1.throwPokeball();
        trainer1.returnPokemon(trainer1.belt[x].Charmander);
        trainer2.throwPokeball();
        trainer2.returnPokemon(trainer2.belt[x].Charmander);
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
    public object Open()
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
        Console.WriteLine(name+"'s Charmander says: " + belt[teller].Charmander.getName());
        teller = teller + 1;
        return belt[teller-1].Charmander;
    }
    public void returnPokemon(Charmander charmander)
    {
        Console.WriteLine(name + " Returns: " + charmander.getName());
    }
}