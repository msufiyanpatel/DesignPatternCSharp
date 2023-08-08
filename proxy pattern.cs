// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

List<string> allowed = new List<string> { "192.168.1.100", "10.0.0.1", "172.16.0.5" };

FirewallProxy firewall = new FirewallProxy(allowed);

Packet packet1 = new Packet { source = "192.168.1.100", destination = "10.0.0.1", data = "Excel file" };
Packet packet2 = new Packet { source = "10.0.0.2", destination = "192.168.1.100", data = "Word file" };
Packet packet3 = new Packet { source = "192.168.1.100", destination = "8.8.8.8", data = "PPT file" };

firewall.Send(packet1);
firewall.Receive(packet1);
firewall.Send(packet2);
firewall.Receive(packet2);
firewall.Send(packet3);
firewall.Receive(packet3);

public class Packet
{
    public string source { get; set; }
    public string destination { get; set; }
    public string data { get; set; }

}

public class FirewallProxy
{
    private List<string> allowed;

    public FirewallProxy(List<string> allowed)
    {
        this.allowed = allowed;
    }

    private bool isAllowed(string ip)
    {
        return allowed.Contains(ip);
    }

    public void Send(Packet packet)
    {
        if(isAllowed(packet.source))
        {
            Console.WriteLine("Sending packets");
        }
        else
        {
            Console.WriteLine("Can't send packet");

        }
    }

    public void Receive(Packet packet) {
        
        if (isAllowed(packet.source))
        {
            if (isAllowed(packet.destination))
            {
                Console.WriteLine("Receiving packet");
            }
            else
            {
                Console.WriteLine("Can't receive on this destination");
            }
        }
        else
        {
            Console.WriteLine("Source is not safe");
        }

    }
}