// See https://aka.ms/new-console-template for more information
logger Logger = logger.getInstance();

Logger.Log("this is logger message");
Logger.Log("this is another logger message");


List<string> log = Logger.getLogs();

foreach (string message in log)
{
    Console.WriteLine(message);
}


public class logger
{
    private static volatile logger instance;
    private static readonly object lockObject = new object();

    private List<string> log;

    private logger() { 
    this.log = new List<string>();}

    public void Log(string message)
    {
        string timeStamp = DateTime.Now.ToString("F");
        string logMessage = $"{timeStamp} {message}";
        log.Add(logMessage);
        Console.WriteLine(logMessage);
    }

    public static logger getInstance()
    {
        if(instance == null)
        {
            lock (lockObject)
            {
                if(instance == null)
                {
                    instance = new logger();
                }
            }
        }

        return instance;
    }

    public List<string> getLogs()
    {
        return log;
    }
}
