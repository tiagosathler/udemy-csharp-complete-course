using S09C132.Entities.Enums;

namespace S09C132.Entities;

internal class Status
{
    public OrderStatus OrderStatus { get; set; }
    public DateTime Date { get; set; }

    public Status(OrderStatus orderStatus, DateTime date)
    {
        OrderStatus = orderStatus;
        Date = date;
    }

    public override string ToString()
    {
        return $"{OrderStatus} - {Date.ToString(Program.DATE_TIME_FORMAT)}";
    }
}