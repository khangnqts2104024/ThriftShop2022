﻿using Microsoft.EntityFrameworkCore;
using ThriftShop.Models;

namespace ThriftShop.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Size_Product>().HasKey(nameof(Size_Product.SizeId), nameof(Size_Product.ProductId));
            modelBuilder.Entity<Color_Product>().HasKey(nameof(Color_Product.ColorId), nameof(Color_Product.ProductId));
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Color_Product> Color_Products { get; set; }
        public DbSet<Size_Product> Size_Products { get; set; }
    }
}