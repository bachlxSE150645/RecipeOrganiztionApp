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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.RoleID, "IX_Accounts_RoleID");

                entity.Property(e => e.AccountID)
                    .ValueGeneratedNever()
                    .HasColumnName("AccountID");
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(15);
                entity.Property(e => e.RoleID).HasColumnName("RoleID");
                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Role).WithMany(p => p.Accounts).HasForeignKey(d => d.RoleID);
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.IngredientID)
                    .ValueGeneratedNever()
                    .HasColumnName("IngredientID");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.HasIndex(e => e.AccountID, "IX_Meals_AccountID");

                entity.HasIndex(e => e.RecipeID, "IX_Meals_RecipeID");

                entity.Property(e => e.MealID)
                    .ValueGeneratedNever()
                    .HasColumnName("MealID");
                entity.Property(e => e.AccountID).HasColumnName("AccountID");
                entity.Property(e => e.Price).HasColumnType("money");
                entity.Property(e => e.RecipeID).HasColumnName("RecipeID");
                entity.Property(e => e.Status).HasMaxLength(10);

                entity.HasOne(d => d.Account).WithMany(p => p.Meals).HasForeignKey(d => d.AccountID);

                entity.HasOne(d => d.Recipe).WithMany(p => p.Meals)
                    .HasForeignKey(d => d.RecipeID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.AccountID, "IX_Orders_AccountID");

                entity.HasIndex(e => e.MealID, "IX_Orders_MealID");

                entity.Property(e => e.OrderID)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");
                entity.Property(e => e.AccountID).HasColumnName("AccountID");
                entity.Property(e => e.MealID).HasColumnName("MealID");
                entity.Property(e => e.Status).HasMaxLength(10);
                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.HasOne(d => d.Account).WithMany(p => p.Orders).HasForeignKey(d => d.AccountID);

                entity.HasOne(d => d.Meal).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MealID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasIndex(e => e.AccountID, "IX_Recipes_AccountID");

                entity.Property(e => e.RecipeID)
                    .ValueGeneratedNever()
                    .HasColumnName("RecipeID");
                entity.Property(e => e.AccountID).HasColumnName("AccountID");
                entity.Property(e => e.Status).HasMaxLength(10);

                entity.HasOne(d => d.Account).WithMany(p => p.Recipes).HasForeignKey(d => d.AccountID);

            });

            modelBuilder.Entity<RecipeDetail>(entity =>
            {
                //entity.HasNoKey();

                entity.HasIndex(e => e.IngredientID, "IX_RecipeDetails_IngredientID");

                entity.HasIndex(e => e.RecipeID, "IX_RecipeDetails_RecipeID");

                entity.Property(e => e.IngredientID).HasColumnName("IngredientID");
                entity.Property(e => e.RecipeID).HasColumnName("RecipeID");
                entity.Property(e => e.Unit).HasMaxLength(20);

                entity.HasOne(d => d.Ingredient).WithMany().HasForeignKey(d => d.IngredientID);

                entity.HasOne(d => d.Recipe).WithMany().HasForeignKey(d => d.RecipeID);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasIndex(e => e.AccountID, "IX_Reviews_AccountID");

                entity.HasIndex(e => e.RecipeID, "IX_Reviews_RecipeID");

                entity.Property(e => e.ReviewID)
                    .ValueGeneratedNever()
                    .HasColumnName("ReviewID");
                entity.Property(e => e.AccountID).HasColumnName("AccountID");
                entity.Property(e => e.RecipeID).HasColumnName("RecipeID");

                entity.HasOne(d => d.Account).WithMany(p => p.Reviews).HasForeignKey(d => d.AccountID);

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleID)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");
                entity.Property(e => e.RoleName).HasMaxLength(10);
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.HasIndex(e => e.AccountID, "IX_WishLists_AccountID");

                entity.Property(e => e.WishListID)
                    .ValueGeneratedNever()
                    .HasColumnName("WishListID");
                entity.Property(e => e.AccountID).HasColumnName("AccountID");

                entity.HasOne(d => d.Account).WithMany(p => p.WishLists).HasForeignKey(d => d.AccountID);
            });

            modelBuilder.Entity<WishListItem>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.RecipeID, "IX_WishListItems_RecipeID");

                entity.HasIndex(e => e.WishListID, "IX_WishListItems_WishListID");

                entity.Property(e => e.RecipeID).HasColumnName("RecipeID");
                entity.Property(e => e.WishListID).HasColumnName("WishListID");

                entity.HasOne(d => d.Recipe).WithMany().HasForeignKey(d => d.RecipeID);

                entity.HasOne(d => d.WishList).WithMany()
                    .HasForeignKey(d => d.WishListID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

        }

    }
}
