using Microsoft.EntityFrameworkCore;

namespace MyApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }

    public class UserPreferences
    {
        public Guid Id { get; set; }

        public int UserId { get; set; }

        public int MaxDistanceMiles { get; set; }
        public Boolean AllowSplitCart { get; set; }

        public TextReader FavoriteStore { get; set; }
    }

    public class Stores
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
    }

    public class StoreProducts
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public string StoreProductName { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    public class Prices
    {
        public int PriceId { get; set; }
        public int StoreProductId { get; set; }
        public int Price { get; set; }
        public Boolean IsOnSale { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class PriceHistory
    {
        public int PriceId { get; set; }
        public int StoreProductId { get; set; }
        public int Price { get; set; }
        public DateTime RecordedAt { get; set; }
    }

    public class ShoppingLists
    {
        public int ListId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    public class ShoppingListItems
    {
        public int ListItemId { get; set; }
        public int ListId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}