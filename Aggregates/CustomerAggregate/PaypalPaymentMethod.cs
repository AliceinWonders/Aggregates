
public class PaypalPaymentMethod : PaymentMethod
{
    public string Email { get; private set; }

    public PaypalPaymentMethod(string email) : base(PaymentMethodType.Paypal)
    {
        Email = email;
    }
}