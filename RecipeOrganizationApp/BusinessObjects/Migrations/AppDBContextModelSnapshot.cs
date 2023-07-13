﻿// <auto-generated />
using System;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObjects.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObjects.Account", b =>
                {
                    b.Property<Guid>("AccountID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AccountID");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("RoleID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RoleID");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AccountID");

                    b.HasIndex(new[] { "RoleID" }, "IX_Accounts_RoleID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BusinessObjects.Ingredient", b =>
                {
                    b.Property<Guid>("IngredientID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IngredientID");

                    b.Property<string>("IngredientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("IngredientID");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("BusinessObjects.Meal", b =>
                {
                    b.Property<Guid>("MealID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("MealID");

                    b.Property<Guid>("AccountID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AccountID");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.Property<Guid>("RecipeID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RecipeID");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("MealID");

                    b.HasIndex(new[] { "AccountID" }, "IX_Meals_AccountID");

                    b.HasIndex(new[] { "RecipeID" }, "IX_Meals_RecipeID");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("BusinessObjects.Order", b =>
                {
                    b.Property<Guid>("OrderID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrderID");

                    b.Property<Guid>("AccountID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AccountID");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MealID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("MealID");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("money");

                    b.HasKey("OrderID");

                    b.HasIndex(new[] { "AccountID" }, "IX_Orders_AccountID");

                    b.HasIndex(new[] { "MealID" }, "IX_Orders_MealID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BusinessObjects.Recipe", b =>
                {
                    b.Property<Guid>("RecipeID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RecipeID");

                    b.Property<Guid>("AccountID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AccountID");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipeImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("RecipeID");

                    b.HasIndex(new[] { "AccountID" }, "IX_Recipes_AccountID");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("BusinessObjects.RecipeDetail", b =>
                {
                    b.Property<Guid>("RecipeID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RecipeID");

                    b.Property<Guid>("IngredientID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IngredientID");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RecipeID", "IngredientID");

                    b.HasIndex(new[] { "IngredientID" }, "IX_RecipeDetails_IngredientID");

                    b.HasIndex(new[] { "RecipeID" }, "IX_RecipeDetails_RecipeID");

                    b.ToTable("RecipeDetails");
                });

            modelBuilder.Entity("BusinessObjects.Review", b =>
                {
                    b.Property<Guid>("ReviewID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ReviewID");

                    b.Property<Guid>("AccountID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AccountID");

                    b.Property<float?>("Rating")
                        .HasColumnType("real");

                    b.Property<Guid>("RecipeID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RecipeID");

                    b.Property<string>("ReviewContent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewID");

                    b.HasIndex(new[] { "AccountID" }, "IX_Reviews_AccountID");

                    b.HasIndex(new[] { "RecipeID" }, "IX_Reviews_RecipeID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BusinessObjects.Role", b =>
                {
                    b.Property<Guid>("RoleID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RoleID");

                    b.Property<string>("RoleName")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BusinessObjects.WishList", b =>
                {
                    b.Property<Guid>("WishListID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("WishListID");

                    b.Property<Guid>("AccountID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AccountID");

                    b.HasKey("WishListID");

                    b.HasIndex(new[] { "AccountID" }, "IX_WishLists_AccountID");

                    b.ToTable("WishLists");
                });

            modelBuilder.Entity("BusinessObjects.WishListItem", b =>
                {
                    b.Property<Guid>("RecipeID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RecipeID");

                    b.Property<Guid>("WishListID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("WishListID");

                    b.HasIndex(new[] { "RecipeID" }, "IX_WishListItems_RecipeID");

                    b.HasIndex(new[] { "WishListID" }, "IX_WishListItems_WishListID");

                    b.ToTable("WishListItems");
                });

            modelBuilder.Entity("BusinessObjects.Account", b =>
                {
                    b.HasOne("BusinessObjects.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BusinessObjects.Meal", b =>
                {
                    b.HasOne("BusinessObjects.Account", "Account")
                        .WithMany("Meals")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObjects.Recipe", "Recipe")
                        .WithMany("Meals")
                        .HasForeignKey("RecipeID")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("BusinessObjects.Order", b =>
                {
                    b.HasOne("BusinessObjects.Account", "Account")
                        .WithMany("Orders")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObjects.Meal", "Meal")
                        .WithMany("Orders")
                        .HasForeignKey("MealID")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("BusinessObjects.Recipe", b =>
                {
                    b.HasOne("BusinessObjects.Account", "Account")
                        .WithMany("Recipes")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BusinessObjects.RecipeDetail", b =>
                {
                    b.HasOne("BusinessObjects.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObjects.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("BusinessObjects.Review", b =>
                {
                    b.HasOne("BusinessObjects.Account", "Account")
                        .WithMany("Reviews")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObjects.Recipe", "Recipe")
                        .WithMany("Reviews")
                        .HasForeignKey("RecipeID")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("BusinessObjects.WishList", b =>
                {
                    b.HasOne("BusinessObjects.Account", "Account")
                        .WithMany("WishLists")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BusinessObjects.WishListItem", b =>
                {
                    b.HasOne("BusinessObjects.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObjects.WishList", "WishList")
                        .WithMany()
                        .HasForeignKey("WishListID")
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("WishList");
                });

            modelBuilder.Entity("BusinessObjects.Account", b =>
                {
                    b.Navigation("Meals");

                    b.Navigation("Orders");

                    b.Navigation("Recipes");

                    b.Navigation("Reviews");

                    b.Navigation("WishLists");
                });

            modelBuilder.Entity("BusinessObjects.Meal", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BusinessObjects.Recipe", b =>
                {
                    b.Navigation("Meals");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BusinessObjects.Role", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
