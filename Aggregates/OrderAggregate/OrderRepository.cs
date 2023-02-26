using System;
using System.Collections.Generic;
using System.Linq;


public class OrderRepository : IDisposable
{
    private List<Order> _orders;

    public OrderRepository()
    {
        _orders = new List<Order>();
    }

    public void Add(Order order)
    {
        _orders.Add(order);
    }

    public Order GetById(string id)
    {
        return _orders.FirstOrDefault(o => o.Id == id);
    }

    public void Remove(Order order)
    {
        _orders.Remove(order);
    }

    public void Update(Order order)
    {
        var existingOrder = _orders.FirstOrDefault(o => o.Id == order.Id);
        if (existingOrder != null)
        {
            existingOrder = order;
        }
    }

    public void Dispose()
    {
        
    }
}