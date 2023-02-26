using System;

namespace Aggregates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var customerRepository = new CustomerRepository())
            {
                var customerFactory = new Customer.CustomerFactory();

                var paypalCustomer = customerFactory.Create("Alice", new PaypalPaymentMethod("alice@mail.ru"));
                customerRepository.Add(paypalCustomer);

                var stripeCustomer = customerFactory.Create("Makar", new StripePaymentMethod("88005553535"));
                customerRepository.Add(stripeCustomer);

                var cardCustomer = customerFactory.Create("Andrey",
                    new CardPaymentMethod("111222333", "Andrey Pochitaev", "12/2023", CardType.Mir));
                customerRepository.Add(cardCustomer);

                Console.WriteLine(paypalCustomer);
                Console.WriteLine(stripeCustomer);
                Console.WriteLine(cardCustomer);
                
                using (var orderRepository = new OrderRepository())
                {
                    var orderFactory = new Order.OrderFactory();
                    var order = orderFactory.Create(paypalCustomer);
                    order.AddProduct(new Product("The Sims 4", 2990));
                    order.AddProduct(new Product("The Dark Pictures", 1490));
                    order.SetShippingAddress(new Address("Snezhnaya", "Moscow", "SWAO", "Russia", "170001"));
                    orderRepository.Add(order);
                    order.SetStatus(OrderStatus.Shipped);
                    Console.WriteLine(order);
                    
                    order = orderFactory.Create(stripeCustomer);
                    order.AddProduct(new Product("The Quarry", 1900));
                    order.SetShippingAddress(new Address("Obraztsova", "Moscow", "SAO", "Russia", "00666"));
                    orderRepository.Add(order);
                    order.SetStatus(OrderStatus.Delivered);
                    order.SetStatus(OrderStatus.Shipped);
                    Console.WriteLine(order);
                    
                    order = orderFactory.Create(cardCustomer);
                    order.AddProduct(new Product("League of Legends", 500));
                    order.AddProduct(new Product("God of War", 3490));
                    order.SetShippingAddress(new Address("Stepana-Razina", "Togliatti", "Samarskaya obl", "Russia", "12345"));
                    orderRepository.Add(order);
                    order.SetStatus(OrderStatus.Delivered);
                    Console.WriteLine(order);
                }
            }
        }
    }
}