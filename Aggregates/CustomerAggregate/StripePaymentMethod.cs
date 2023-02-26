

public class StripePaymentMethod : PaymentMethod
{
    public string Token { get; private set; }

    public StripePaymentMethod(string token) : base(PaymentMethodType.Stripe)
    {
        Token = token;
    }
}