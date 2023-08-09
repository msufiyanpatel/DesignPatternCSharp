// See https://aka.ms/new-console-template for more information
Console.WriteLine("Observer Pattern Example \n \n");

Player player = new Player();
HealthDisplay healthDisplay = new HealthDisplay();
SpecialEffect specialEffect = new SpecialEffect();

player.Attach(healthDisplay);
player.Attach(specialEffect);

player.Health = 40;

player.Detach(healthDisplay);

player.Health = 10;

Console.ReadKey();

interface IObserver
{
    void onHealthChanged(int newHealth);
}

interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(int newHealth);
}

class Player : ISubject
{
    private int health;

    private List<IObserver> observers= new List<IObserver>();

    public int Health
    {
        get { return health; }
        set
        {
            if(health != value)
            {
                health = value;
                Notify(health);
            }
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify(int newHealth)
    {
        foreach(var observer in observers)
        {
            observer.onHealthChanged(newHealth);
        }
    }
}


class HealthDisplay : IObserver
{
    public void onHealthChanged(int newHealth)
    {
        Console.WriteLine($"Health: {newHealth}");
    }


}

class SpecialEffect : IObserver
{
    public void onHealthChanged(int newHealth)
    {
        if(newHealth < 30)
        Console.WriteLine($"Low Health: {newHealth}");
    }


}

