using S09C132.Entities.Enums;
using System.Text;

namespace S09C132.Entities
{
    internal class Order
    {
        public DateTime Date { get; }
        public Client Client { get; }
        public Status Status { get; }
        public List<OrderItem> Items { get; } = new();

        public Order(Client client)
        {
            Client = client;
            Date = DateTime.Now;
            Status = new(OrderStatus.OPPENED, Date);
        }

        public double Total()
        {
            return Items.Sum(i => i.SubTotal());
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb
                .Append("Order moment: ").AppendLine(Date.ToString(Program.DATE_TIME_FORMAT))
                .Append("Order status: ").Append(Status.OrderStatus).Append(" - ").AppendLine(Status.Date.ToString(Program.DATE_TIME_FORMAT))
                .Append("Client: ").Append(Client.Name).Append(" (").Append(Client.BirthDate.ToString(Program.DATE_FORMAT)).AppendLine(")");

            if (Items.Count > 0)
            {
                sb
                    .AppendLine()
                    .Append("Order items (").Append(Items.Count).AppendLine("):");

                foreach (OrderItem item in Items)
                {
                    sb.Append(" - Item #").Append(Items.IndexOf(item) + 1).Append(" - ").AppendLine(item.ToString());
                }

                sb
                    .AppendLine()
                    .Append("TOTAL PRICE: ").AppendFormat("${0:F2}", Items.Sum(i => i.SubTotal()));
            }
            else
            {
                sb.Append("There aren't products items in this order cart! Add any product!");
            }

            return sb.ToString();
        }
    }
}