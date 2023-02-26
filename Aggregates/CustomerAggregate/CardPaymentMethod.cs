
public enum CardType
{
    Mir = 1,
    Visa = 2,
    Mastercard = 3,
    AmericanExpress = 4
}

public class CardPaymentMethod : PaymentMethod
{
    public string CardNumber { get; private set; }
    public string CardHolderName { get; private set; }
    public string ExpiryDate { get; private set; }
    public CardType CardType { get; private set; }

    public CardPaymentMethod(string cardNumber, string cardHolderName, string expiryDate, CardType cardType) : base(PaymentMethodType.Card)
    {
        CardNumber = cardNumber;
        CardHolderName = cardHolderName;
        ExpiryDate = expiryDate;
        CardType = cardType;
    }
}