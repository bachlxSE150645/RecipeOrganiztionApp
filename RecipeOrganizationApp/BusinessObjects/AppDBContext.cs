using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BusinessObjects
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }

        public AppDBContext(string connectionString)
        {
            Database.SetConnectionString(connectionString);
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("RecipeOrgApp"));
        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set;}
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeDetail> RecipeDetails { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
        public virtual DbSet<WishListItem> WishListItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<RecipeDetail>().HasNoKey();
            modelBuilder.Entity<WishListItem>().HasNoKey();
            modelBuilder.Entity<Meal>().Property(c => c.Price).HasColumnType("money");
            modelBuilder.Entity<Order>().Property(c => c.TotalPrice).HasColumnType("money");
        }
    }
}
