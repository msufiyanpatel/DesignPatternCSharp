// See https://aka.ms/new-console-template for more information
Console.WriteLine("Strategy Pattern Example");

PaymentContext paymentContext = new PaymentContext(new CreditCardPayment());

paymentContext.ProcessPayment(100.0);

paymentContext.SetPaymentStrategy(new PayPalPayment());
paymentContext.ProcessPayment(50.0);

paymentContext.SetPaymentStrategy(new BitcoinPayment());
paymentContext.ProcessPayment(200.0);

Console.ReadKey();


public interface IPaymentStrategy
{
    void ProcessPayment(double amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    public void ProcessPayment(double amount)
    {
        
        Console.WriteLine($"Processing credit card payment of {amount} USD.");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    public void ProcessPayment(double amount)
    {
        
        Console.WriteLine($"Processing PayPal payment of {amount} USD.");
    }
}

public class BitcoinPayment : IPaymentStrategy
{
    public void ProcessPayment(double amount)
    {
        
        Console.WriteLine($"Processing Bitcoin payment of {amount} USD.");
    }
}

public class PaymentContext
{
    private IPaymentStrategy paymentStrategy;

    public PaymentContext(IPaymentStrategy paymentStrategy)
    {
        this.paymentStrategy = paymentStrategy;
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        this.paymentStrategy = paymentStrategy;
    }

    public void ProcessPayment(double amount)
    {
        paymentStrategy.ProcessPayment(amount);
    }
}


