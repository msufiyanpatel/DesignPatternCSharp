// See https://aka.ms/new-console-template for more information
EnemyCollection enemyCollection = new EnemyCollection();
enemyCollection.AddEnemy(new Enemy("Wolf", 50));
enemyCollection.AddEnemy(new Enemy("Tiger", 80));
enemyCollection.AddEnemy(new Enemy("Dragon", 200));

IIterator<Enemy> enemyIterator = enemyCollection.CreateIterator();

while (enemyIterator.HasNext())
{
    Enemy enemy = enemyIterator.Next();
    enemy.Update();
    enemy.Render();
}


public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

public class Enemy
{
    public string Name { get; private set; }
    public int Health { get; private set; }

    public Enemy(string name, int health)
    {
        Name = name;    
        Health = health;
    }

    public void Update()
    {
        Console.WriteLine("Update Logic");
    }

    public void Render()
    {
        Console.WriteLine($"Rendering {Name} with {Health} health.");
    }
}

public class EnemyIterator : IIterator<Enemy>
{
    private List<Enemy> enemies;
    private int currentIndex;

    public EnemyIterator(List<Enemy> enemies)
    {
        this.enemies = enemies;
        currentIndex = 0;
    }

    public bool HasNext()
    {
        return currentIndex < enemies.Count;
    }

    public Enemy Next()
    {
        Enemy enemy = enemies[currentIndex];
        currentIndex++;
        return enemy;
    }
}

public class EnemyCollection
{
    private List<Enemy> enemies;

    public EnemyCollection()
    {
        enemies = new List<Enemy>();
    }

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public IIterator<Enemy> CreateIterator()
    {
        return new EnemyIterator(enemies);
    }
}
