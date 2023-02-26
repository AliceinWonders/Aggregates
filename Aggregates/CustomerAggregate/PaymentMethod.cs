using System;


public enum PaymentMethodType
{
    Paypal = 1,
    Stripe = 2,
    Card = 3
}
public abstract class PaymentMethod
{
    public string Id { get; private set; }
    public Customer Customer { get; private set; }
    public PaymentMethodType Type { get; private set; }

    protected PaymentMethod(PaymentMethodType type)
    {
        Type = type;
        Id = Guid.NewGuid().ToString();
    }
}