// See https://aka.ms/new-console-template for more information
Console.WriteLine("Pokemon Battle Simulator");

var char1 = new Charmander("Char1");
var pokeball1 = new Pokeball(char1);

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
        this.hasCharmanderInside = false;

    }
    public object Open()
    {
        hasCharmanderInside = true;
        return Charmander;
    }
    public void Close()
    {
        hasCharmanderInside = false;
    }

    
}

public class Trainer
{
    public List<Pokeball> belt;
    public string? name;

    Trainer(List<Pokeball> belt)
    {
        this.belt = belt;
    }
}