using S09C132.Entities;
using S09C132.Entities.Enums;

namespace S09C132.Services;

internal class OrderService

{
    private readonly Order _order;

    public OrderService(Order order)
    {
        _order = order;
    }

    private void ChangeStatusDate()
    {
        _order.Status.Date = DateTime.Now;
    }

    private void ResetStatus()
    {
        _order.Status.OrderStatus = OrderStatus.OPPENED;
        ChangeStatusDate();
    }

    public void AddItem(OrderItem item)
    {
        if (_order.Status.OrderStatus == OrderStatus.OPPENED || _order.Status.OrderStatus == OrderStatus.PENDING_PAYMENT)
        {
            _order.Items.Add(item);
            if (_order.Status.OrderStatus == OrderStatus.OPPENED) ChangeStatus();
            else ChangeStatusDate();
        }
        else
        {
            Console.WriteLine("It is no longer possible to add items to this cart!");
        }
    }

    public void RemoveItem(OrderItem item)
    {
        if (_order.Status.OrderStatus == OrderStatus.PENDING_PAYMENT)
        {
            _order.Items.Remove(item);
            if (_order.Items.Count == 0) ResetStatus();
            else ChangeStatusDate();
        }
        else
        {
            Console.WriteLine("It is no longer possible to remove items from this cart!");
        }
    }

    public void ChangeStatus()
    {
        switch (_order.Status.OrderStatus)
        {
            case OrderStatus.OPPENED:
                {
                    if (_order.Items.Count > 0)
                    {
                        _order.Status.OrderStatus = OrderStatus.PENDING_PAYMENT;
                        ChangeStatusDate();
                    }
                    break;
                }
            case OrderStatus.PENDING_PAYMENT:
                {
                    _order.Status.OrderStatus = OrderStatus.PROCESSING;
                    ChangeStatusDate();
                    break;
                }
            case OrderStatus.PROCESSING:
                {
                    _order.Status.OrderStatus = OrderStatus.SHIPPED;
                    ChangeStatusDate();
                    break;
                }
            case OrderStatus.SHIPPED:
                {
                    _order.Status.OrderStatus = OrderStatus.DELIVERED;
                    ChangeStatusDate();
                    break;
                }
        }
    }
}