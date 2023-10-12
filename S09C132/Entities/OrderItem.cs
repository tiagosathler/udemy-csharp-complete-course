namespace S09C132.Entities;

internal class OrderItem
{
    public int Quantity { get; set; }
    public double Price { get; }
    public Product Product { get; }

    public OrderItem(Product product, int quantity)
    {
        Quantity = quantity;
        Product = product;
        Price = product.Price;
    }

    public double SubTotal()
    {
        return Quantity * Price;
    }

    public override string ToString()
    {
        return $"{Product.Name}, ${Price:F2}, {Quantity}, Subtotal: ${SubTotal():F2}";
    }
}