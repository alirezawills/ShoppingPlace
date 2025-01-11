using Microsoft.EntityFrameworkCore;

namespace ShoppingPlace.Database
{
    public class ShoppingPlaceDbContext : DbContext
    {
        public ShoppingPlaceDbContext(DbContextOptions<ShoppingPlaceDbContext> options) : base(options) { }




    }
}
