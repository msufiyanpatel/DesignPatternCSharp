// See https://aka.ms/new-console-template for more information
Console.WriteLine("Chain Of Responsibility Pattern");

NotificationChannel emailChannel = new EmailNotificationChannel();
NotificationChannel smsChannel = new SmsNotificationChannel();
NotificationChannel pushChannel = new PushNotificationChannel();


emailChannel.NextChannel(smsChannel);
smsChannel.NextChannel(pushChannel);


User user = new User("Sufiyan", false, true, true);


emailChannel.SendNotification(user, "Your account balance is low.");
emailChannel.SendNotification(user, "Meeting reminder at 3 PM.");

Console.ReadLine();

class User
{
    public string Name { get; }
    public bool ReceiveSMS { get; }
    public bool ReceiveEmail { get; }
    public bool ReceiveNotification { get; }

    public User(string name, bool receiveSMS, bool receiveEmail, bool receiveNotification) { 
        Name= name;
        ReceiveSMS= receiveSMS; 
        ReceiveEmail= receiveEmail; 
        ReceiveNotification= receiveNotification;   
    }
}

abstract class NotificationChannel
{
    protected NotificationChannel nextChannel;

    public void NextChannel(NotificationChannel channel)
    {
        nextChannel = channel;
    }

    public abstract void SendNotification(User user, string message);
}
class EmailNotificationChannel : NotificationChannel
{
    public override void SendNotification(User user, string message)
    {
        if (user.ReceiveEmail)
        {
            Console.WriteLine($"Sending email to {user.Name}: {message}");
        }
        else if (nextChannel != null)
        {
            nextChannel.SendNotification(user, message);
        }
    }
}

class SmsNotificationChannel : NotificationChannel
{
    public override void SendNotification(User user, string message)
    {
        if (user.ReceiveSMS)
        {
            Console.WriteLine($"Sending SMS to {user.Name}: {message}");
        }
        else if (nextChannel != null)
        {
            nextChannel.SendNotification(user, message);
        }
    }
}

class PushNotificationChannel : NotificationChannel
{
    public override void SendNotification(User user, string message)
    {
       if (user.ReceiveNotification)
        {
            Console.WriteLine($"Sending push notification to {user.Name}: {message}");
        }
        else
        {
            Console.WriteLine($"No available channel for sending notifications to {user.Name}");
        }
    }
}