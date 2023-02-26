using System;
using System.Collections.Generic;


public class Customer
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public List<PaymentMethod> PaymentMethods { get; private set; }
    
    private Customer()
    {
        Id = Guid.NewGuid().ToString();
        PaymentMethods = new List<PaymentMethod>();
    }
    
    private Customer(string name): this()
    {
        Name = name;
    }

    public void AddPaymentMethod(PaymentMethod paymentMethod)
    {
        PaymentMethods.Add(paymentMethod);
    }
    
    public override string ToString()
    {
        return $"Customer ID: {Id}, Name: {Name}";
    }
    
    public class CustomerFactory
    {
        public Customer Create(string name, PaymentMethod paymentMethod)
        {
            var customer = new Customer(name);
            customer.AddPaymentMethod(paymentMethod);
            return customer;
        }
    }
}