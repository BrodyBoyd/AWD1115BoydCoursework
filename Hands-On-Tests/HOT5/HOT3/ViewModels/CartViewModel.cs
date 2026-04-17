using HOT5.Models;

namespace HOT5.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> Items { get; set; } = new();
        public decimal SubTotal => Items.Sum(i => i.TotalPrice);
        public decimal Tax => SubTotal * 0.07m;
        public decimal Total => SubTotal + Tax;
        public int ItemCount => Items.Sum(i => i.Quantity);
        public bool IsEmpty => Items.Count == 0;
    }
}
