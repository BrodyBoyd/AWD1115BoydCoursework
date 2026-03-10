using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HOT3.Models
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics" },
                new Category { CategoryId = 2, Name = "Home & Office" },
                new Category { CategoryId = 3, Name = "Gaming" },
                new Category { CategoryId = 4, Name = "Fitness" },
                new Category { CategoryId = 5, Name = "Accessories" }
            );

            builder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Wireless Bluetooth Headphones",
                    Description = "Noise-cancelling over-ear headphones",
                    StockQuantity = 42,
                    Price = 89.99m,
                    CategoryId = 1,
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1678099940967-73fe30680949?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8d2lyZWxlc3MlMjBoZWFkcGhvbmVzfGVufDB8fDB8fHww"
                },
                new Product
                {
                    ProductId = 2,
                    Name = "4K Ultra HD Monitor",
                    Description = "27-inch IPS display",
                    StockQuantity = 15,
                    Price = 279.99m,
                    CategoryId = 3,
                    ImageUrl = "https://images.unsplash.com/photo-1551645120-d70bfe84c826?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8bW9uaXRvcnxlbnwwfHwwfHx8MA%3D%3D"
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Mechanical Gaming Keyboard",
                    Description = "RGB backlit mechanical keyboard",
                    StockQuantity = 60,
                    Price = 74.50m,
                    CategoryId = 3,
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1664194583917-b0ba07c4ce2a?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8Z2FtaW5nJTIwa2V5Ym9hcmR8ZW58MHx8MHx8fDA%3D"
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Ergonomic Office Chair",
                    Description = "Adjustable lumbar support",
                    StockQuantity = 22,
                    Price = 159.00m,
                    CategoryId = 2,
                    ImageUrl = "https://images.unsplash.com/photo-1688578735427-994ecdea3ea4?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8b2ZmaWNlJTIwY2hhaXJ8ZW58MHx8MHx8fDA%3D"
                },
                new Product
                {
                    ProductId = 5,
                    Name = "USB-C Fast Charger",
                    Description = "45W fast charging adapter",
                    StockQuantity = 120,
                    Price = 24.99m,
                    CategoryId = 1,
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1669262667978-5d4aafe29dd5?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8dXNiLWMlMjBjaGFyZ2VyfGVufDB8fDB8fHww"
                },
                new Product
                {
                    ProductId = 6,
                    Name = "Smart LED Light Bulb",
                    Description = "WiFi-enabled color bulb",
                    StockQuantity = 85,
                    Price = 14.99m,
                    CategoryId = 1,
                    ImageUrl = "https://media.istockphoto.com/id/1215074546/photo/controlling-light-bulb-with-mobile-device.webp?a=1&b=1&s=612x612&w=0&k=20&c=n-PD48Q5qUJKY8dVCSU-7OVBiquG557pf7iCwMNGa7M="
                },
                new Product
                {
                    ProductId = 7,
                    Name = "Portable Bluetooth Speaker",
                    Description = "Water-resistant outdoor speaker",
                    StockQuantity = 33,
                    Price = 49.99m,
                    CategoryId = 1,
                    ImageUrl = "https://images.unsplash.com/photo-1589256469067-ea99122bbdc4?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8Ymx1ZXRvb3RoJTIwc3BlYWtlcnxlbnwwfHwwfHx8MA%3D%3D"
                },
                new Product
                {
                    ProductId = 8,
                    Name = "Laptop Backpack",
                    Description = "Fits up to 17-inch laptops",
                    StockQuantity = 50,
                    Price = 39.99m,
                    CategoryId = 5,
                    ImageUrl = "https://images.unsplash.com/photo-1667411424771-cadd97150827?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8bGFwdG9wJTIwYmFja3BhY2t8ZW58MHx8MHx8fDA%3D"
                },
                new Product
                {
                    ProductId = 9,
                    Name = "Stainless Steel Water Bottle",
                    Description = "Insulated 32oz bottle",
                    StockQuantity = 75,
                    Price = 19.99m,
                    CategoryId = 5,
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1681284938505-62efa3494bf2?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c3RhaW5sZXNzJTIwc3RlZWwlMjB3YXRlciUyMGJvdHRsZXxlbnwwfHwwfHx8MA%3D%3D"
                },
                new Product
                {
                    ProductId = 10,
                    Name = "Wireless Mouse",
                    Description = "Silent-click ergonomic mouse",
                    StockQuantity = 95,
                    Price = 17.99m,
                    CategoryId = 1,
                    ImageUrl = "https://images.unsplash.com/photo-1707592691247-5c3a1c7ba0e3?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8d2lyZWxlc3MlMjBtb3VzZXxlbnwwfHwwfHx8MA%3D%3D"
                },
                new Product
                {
                    ProductId = 11,
                    Name = "Smart Fitness Watch",
                    Description = "Tracks heart rate and steps",
                    StockQuantity = 28,
                    Price = 129.99m,
                    CategoryId = 4,
                    ImageUrl = "https://images.unsplash.com/photo-1678356717973-f2177782388a?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8Zml0dG5lc3MlMjB3YXRjaHxlbnwwfHwwfHx8MA%3D%3D"
                },
                new Product
                {
                    ProductId = 12,
                    Name = "HD Webcam",
                    Description = "1080p USB webcam",
                    StockQuantity = 40,
                    Price = 59.99m,
                    CategoryId = 2,
                    ImageUrl = "https://images.unsplash.com/photo-1704364610940-52b509d3951f?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aGQlMjB3ZWJjYW18ZW58MHx8MHx8fDA%3D"
                },
                new Product
                {
                    ProductId = 13,
                    Name = "External Hard Drive 2TB",
                    Description = "Portable USB 3.0 drive",
                    StockQuantity = 34,
                    Price = 69.99m,
                    CategoryId = 1,
                    ImageUrl = "https://media.istockphoto.com/id/1364094222/photo/backup-your-software.webp?a=1&b=1&s=612x612&w=0&k=20&c=JKeYdUxEBpP8tCI80CQXg59Yc0zbmEm_tSI3bQcdGp0="
                },
                new Product
                {
                    ProductId = 14,
                    Name = "LED Desk Lamp",
                    Description = "Adjustable brightness",
                    StockQuantity = 48,
                    Price = 22.99m,
                    CategoryId = 5,
                    ImageUrl = "https://images.unsplash.com/photo-1621177555452-bedbe4c28879?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8ZGVzayUyMGxhbXB8ZW58MHx8MHx8fDA%3D"
                },
                new Product
                {
                    ProductId = 15,
                    Name = "Noise-Isolating Earbuds",
                    Description = "In-ear wired earbuds",
                    StockQuantity = 110,
                    Price = 12.99m,
                    CategoryId = 1,
                    ImageUrl = "https://images.unsplash.com/photo-1733641839465-f9de0c9b9bde?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8bm9pc2UlMjBjYW5jZWxsaW5nJTIwZWFyYnVkc3xlbnwwfHwwfHx8MA%3D%3D"
                },
                new Product
                {
                    ProductId = 16,
                    Name = "Portable Power Bank",
                    Description = "10,000mAh USB power bank",
                    StockQuantity = 70,
                    Price = 29.99m,
                    CategoryId = 1,
                    ImageUrl = "https://images.unsplash.com/photo-1594843665794-446ce915d840?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8cG93ZXIlMjBiYW5rfGVufDB8fDB8fHww"
                },
                new Product
                {
                    ProductId = 17,
                    Name = "Gaming Mouse Pad",
                    Description = "Extended desk-size pad",
                    StockQuantity = 55,
                    Price = 15.99m,
                    CategoryId = 3,
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1679177183775-75c2e0d0d209?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8Z2FtaW5nJTIwbW91c2UlMjBwYWR8ZW58MHx8MHx8fDA%3D"
                },
                new Product
                {
                    ProductId = 18,
                    Name = "Smart Home Hub",
                    Description = "Controls smart devices",
                    StockQuantity = 18,
                    Price = 89.00m,
                    CategoryId = 1,
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1688686804638-fadb460edc4a?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c21hcnQlMjBob21lfGVufDB8fDB8fHww"
                },
                new Product
                {
                    ProductId = 19,
                    Name = "USB-C to HDMI Adapter",
                    Description = "4K output adapter",
                    StockQuantity = 90,
                    Price = 16.99m,
                    CategoryId = 1,
                    ImageUrl = "https://m.media-amazon.com/images/I/61kv7aTqB0L.jpg"
                },
                new Product
                {
                    ProductId = 20,
                    Name = "Electric Standing Desk",
                    Description = "Height-adjustable desk",
                    StockQuantity = 10,
                    Price = 349.99m,
                    CategoryId = 2,
                    ImageUrl = "https://images.unsplash.com/photo-1622126755582-16754165dce8?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8c3RhbmRpbmclMjBkZXNrfGVufDB8fDB8fHww"
                }
            );
        }
    }
}
