using SupplyChain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<SupplyChainContext>
    {
        protected override void Seed(SupplyChainContext context)
        {
            var customers = new List<Customer>();
            customers.Add(new Customer { Name = "Microsoft", Address = new Address { State = "Washington", Street = "Seattle", ZipCode = "192"  } });
            customers.Add(new Customer { Name = "Telerik", Address = new Address { State = "California", Street = "Golden State", ZipCode = "015" } });
            customers.Add(new Customer { Name = "Google", Address = new Address { State = "California", Street = "Mountain View", ZipCode = "010" } });
            customers.Add(new Customer { Name = "Facebook", Address = new Address { State = "California", Street = "Cupertino", ZipCode = "211" } });
            
            var suppliers = new List<Supplier>();
            suppliers.Add(new Supplier { Name = "Intel", Address = new Address { State = "California", Street = "Silicon Valley", ZipCode = "222" } });
            suppliers.Add(new Supplier { Name = "Samsung", Address = new Address { State = "Korea", Street = "Seol", ZipCode = "777" } });
            suppliers.Add(new Supplier { Name = "Sony", Address = new Address { State = "Japan", Street = "Osaka", ZipCode = "999" } });
            suppliers.Add(new Supplier { Name = "Hewlett-Packard", Address = new Address { State = "Washington", Street = "Oregon", ZipCode = "214" } });
            suppliers.Add(new Supplier { Name = "Apple", Address = new Address { State = "Michigan", Street = "Osaka", ZipCode = "999" } });
            suppliers.Add(new Supplier { Name = "Nike", Address = new Address { State = "Taiwan", Street = "Tainan", ZipCode = "434" } });
            suppliers.Add(new Supplier { Name = "Ford", Address = new Address { State = "Florida", Street = "Miami", ZipCode = "679" } });

            var products = new List<Product>();
            products.Add(new Product { Name = "i7", Price = 250, Supplier = suppliers[0] });
            products.Add(new Product { Name = "i3", Price = 150, Supplier = suppliers[0] });
            products.Add(new Product { Name = "i5", Price = 200, Supplier = suppliers[0] });
            products.Add(new Product { Name = "i7 6th gen", Price = 400, Supplier = suppliers[0] });
            products.Add(new Product { Name = "Galaxy S4", Price = 589, Supplier = suppliers[1] });
            products.Add(new Product { Name = "Galaxy S5", Price = 679, Supplier = suppliers[1] });
            products.Add(new Product { Name = "Galaxy S6", Price = 700, Supplier = suppliers[1] });
            products.Add(new Product { Name = "Galaxy S6", Price = 730, Supplier = suppliers[1] });
            products.Add(new Product { Name = "Galaxy Note 5", Price = 250, Supplier = suppliers[1] });
            products.Add(new Product { Name = "Play Station 3", Price = 455, Supplier = suppliers[2] });
            products.Add(new Product { Name = "Play Station 4", Price = 550, Supplier = suppliers[2] });
            products.Add(new Product { Name = "PSP Vita", Price = 326, Supplier = suppliers[2] });
            products.Add(new Product { Name = "HP Envy 17", Price = 999, Supplier = suppliers[3] });
            products.Add(new Product { Name = "HP Pavilion DM4", Price = 250, Supplier = suppliers[3] });
            products.Add(new Product { Name = "iPhone 6", Price = 712, Supplier = suppliers[4] });
            products.Add(new Product { Name = "iPhone 6 Plus", Price = 750, Supplier = suppliers[4] });
            products.Add(new Product { Name = "iPhone 6s", Price = 800, Supplier = suppliers[4] });
            products.Add(new Product { Name = "iPhone 6s Plus", Price = 845, Supplier = suppliers[4] });
            products.Add(new Product { Name = "Mac Book Pro", Price = 1100, Supplier = suppliers[4] });
            products.Add(new Product { Name = "Kobe 10 Elite", Price = 140, Supplier = suppliers[5] });
            products.Add(new Product { Name = "Kyrie 2", Price = 100, Supplier = suppliers[5] });
            products.Add(new Product { Name = "LeBron 10", Price = 130, Supplier = suppliers[5] });
            products.Add(new Product { Name = "HyperLive", Price = 120, Supplier = suppliers[5] });
            products.Add(new Product { Name = "KD 9", Price = 120, Supplier = suppliers[5] });
            products.Add(new Product { Name = "Air Max", Price = 30, Supplier = suppliers[5] });
            products.Add(new Product { Name = "EcoSport", Price = 8000, Supplier = suppliers[6] });
            products.Add(new Product { Name = "Ranger", Price = 22000, Supplier = suppliers[6] });
            products.Add(new Product { Name = "Explorer", Price = 27000, Supplier = suppliers[6] });
            products.Add(new Product { Name = "Focus", Price = 6000, Supplier = suppliers[6] });
            products.Add(new Product { Name = "Everest", Price = 32000, Supplier = suppliers[6] });

            customers.ForEach(c => context.Customers.Add(c));
            suppliers.ForEach(s => context.Suppliers.Add(s));
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();


        }
    }
}
