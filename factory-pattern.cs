// See https://aka.ms/new-console-template for more information

int select;

Console.WriteLine("Who you want to play \n Boss (write 1) \n Thief (write 2) ");
select = Convert.ToInt32(Console.ReadLine());

if (select == 1)
{
    Game BossGame = new Game(new BossFactory());
    BossGame.Play();
} else if (select == 2)
{
    Game NormalGame = new Game(new NormalFactory());
    NormalGame.Play();
}
else
{
    Console.WriteLine("Please select right value");
}


public abstract class Enemy
{
    public abstract string Name { get; }
    public abstract int Health { get; }

    public void attack()
    {
        Console.WriteLine($"{Name}, Attack to player causing damage...");
    }
}

public class Normal : Enemy
{
    public override string Name => "Normal Enemy";

    public override int Health => 50; 
}

public class Boss : Enemy
{
    public override string Name => "Boss Enemy";

    public override int Health => 100;
}

public abstract class enemyFactory
{
    public abstract Enemy createEnemy();
}

public class BossFactory : enemyFactory
{
    public override Enemy createEnemy()
    {
        return new Boss();
    }
}

public class NormalFactory : enemyFactory
{
    public override Enemy createEnemy()
    {
        return new Normal();
    }
}

public class Game
{
    private enemyFactory EnemyFactory;

    public Game(enemyFactory factory)
    {
        EnemyFactory = factory;
    }

    public void Play()
    {
        Enemy enemy = EnemyFactory.createEnemy();

        Console.WriteLine($"Encountered {enemy.Name} with {enemy.Health} health.");
        enemy.attack();
    }
}