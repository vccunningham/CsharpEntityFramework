using CSharpEF_Practice;
using CSharpEF_Practice.Models;
using PrsEfTutorialLibrary;
using PrsEfTutorialLibraryModels;
using System;
using System.Linq;

// recreate the customer with the fluid syntax

namespace CsharpEntityFramework {
    class Program {
        static void Main(string[] args) {
            var context = new AppDbContext();

            Console.WriteLine($"Avg price is {context.Products.Average(x => x.Price)}");

            var top2 = context.Products.Where(x => x.Id > 7).ToList();
            var actcust = context.Customers.Where(x => x.Active == true).ToList();

            //UpdateCustomerSales(context);
            //AddCustomer(context);
            //AddOrders(context);
            //GetCustomerByPk(context);
            //UpdateCustomer(context);
            //DeleteCustomer(context);
            //GetAllCustomers(context);
            //AddProducts(context);
        }
        static void UpdateCustomerSales(AppDbContext context) {
            var CustOrderJoin = from c in context.Customers
                                join o in context.Orders
                                on c.Id equals o.CustomerId
                                where c.Id == 3
                                select new { Amount = o.Amount, Customer = c.Name, Order = o.Description };
            var orderTotal = CustOrderJoin.Sum(c => c.Amount);
            var cust = context.Customers.Find(3);
            context.SaveChanges();

        }
        static void AddOrders(AppDbContext context) {
            var order1 = new Order { Id = 0, Description = "Order1", Amount = 200, Customer = "Nike" };
            var order2 = new Order { Id = 0, Description = "Order2", Amount = 600, Customer = "Yahoo" };
            var order3 = new Order { Id = 0, Description = "Order3", Amount = 100, Customer = "Footlocker" };
            var order4 = new Order { Id = 0, Description = "Order4", Amount = 400, Customer = "DollarGeneral" };
            var order5 = new Order { Id = 0, Description = "Order5", Amount = 500, Customer = "BestBuy" };

            context.AddRange(order1, order2, order3, order4, order5);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 5) throw new Exception("Five orders added");
            Console.WriteLine("Added 5 orders");


        }
        static void DeleteCustomer(AppDbContext context) {
            var keyToDelete = 1;
            var cust = context.Customers.Find(keyToDelete);
            if (cust == null) throw new Exception("Customer not found");
            context.Customers.Remove(cust);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) throw new Exception("Delete failed!");

        }
        static void UpdateCustomer(AppDbContext context) {
            var custPk = 3;
            var cust = context.Customers.Find(custPk);
            if(cust == null) throw new Exception("Customer not found");
            cust.Name = "Amazon Inc,";
            var rowsAffected = context.SaveChanges();
            if(rowsAffected != 1) throw new Exception("Failed to update customer");
            Console.WriteLine("Update Successful!");
        }
        static void GetCustomerByPk(AppDbContext context) {
            var custPk = 3;
            var cust = context.Customers.Find(custPk);
            if (cust == null) throw new Exception("Customer not found");
            Console.WriteLine(cust);
        }
        static void GetAllCustomers(AppDbContext context) {
            var custs = context.Customers.ToList();
            foreach(var c in custs) {
                Console.WriteLine(c);
            }
        }
        static void AddProducts(AppDbContext context) {
            var product1 = new Product { Id = 0, Code = "Product1", Name = "Echo", Price = 50.00 };
            var product2 = new Product { Id = 0, Code = "Product2", Name = "AppleWatch", Price = 300.00 };
            var product3 = new Product { Id = 0, Code = "Product3", Name = "Big Echo", Price = 60.00 };
            var product4 = new Product { Id = 0, Code = "Product4", Name = "Small Echo", Price = 40.00 };
            var product5 = new Product { Id = 0, Code = "Product5", Name = "Airpods", Price = 149.00 };

            context.AddRange(product1, product2, product3, product4, product5);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 5) throw new Exception("Five products added");
            Console.WriteLine("Added 5 products");
        }


        static void AddCustomer(AppDbContext context) {
            var cust = new Customer {
                Id = 0,
                Name = "MAX Technical Training",
                Sales = 0,
                Active = true
            };
            context.Customers.Add(cust);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected == 0) throw new Exception("Add failed!");
            return;
        }
    }
}
