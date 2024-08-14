using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryMiniProject.Exceptions;
using InventoryMiniProject.Models;
using InventoryMiniProject.Repositories;

namespace InventoryMiniProject.Controllers
{
    internal class ProductMenu
    {
        ProductManagement productManager = new ProductManagement(new Data.InventoryContext());
        public void Welcome()
        {
            while (true)
            {

                Console.WriteLine("===============  WELCOME TO PRODUCT MANAGEMENT ....  ===============");
                Console.WriteLine($"1.Add Product\n" +
                    $"2.Update Product\n" +
                    $"3.Delete Product\n" +
                    $"4.View Product Details\n" +
                    $"5.View All Products\n" +
                    $"6.Go back\n");
                Console.WriteLine("Enter your choice\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    SubMenu(choice);
                }
                catch (NoSuchItemExistsException ns)
                {
                    Console.WriteLine(ns.Message);
                }
            } 
        }
        public void SubMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Product Details:\n");
                    Console.WriteLine("Name of Product\n");
                    string name= Console.ReadLine();
                    //Console.WriteLine("Id of the Product:\n");
                    //int id=Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Provide description:\n");
                    string description= Console.ReadLine();
                    Console.WriteLine("Enter Quantity\n");
                    int quantity= Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter price of product\n");
                    int price= Convert.ToInt32(Console.ReadLine());
                    InventoryManagement inventoryManager=new InventoryManagement(new Data.InventoryContext());
                    Console.WriteLine("Enter InventoryId: ");
                    int inventoryId = Convert.ToInt32(Console.ReadLine());

                    Product product = new Product()
                    {
                        Name=name,
                        Quantity=quantity,
                        Price=price,
                        Description=description,
                        InventoryId=inventoryId
                    };
                    productManager.AddProduct(product);
                    Console.WriteLine("Product added successfully...");
                    break;

                case 2:
                    Console.WriteLine("Enter Product ID");
                    int productId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Product Name");
                    name = Console.ReadLine();
                    productManager.CheckProduct(name);
                    Console.WriteLine("Product Description");
                    description = Console.ReadLine();
                    Console.WriteLine("Product Price");
                    price = Convert.ToInt32(Console.ReadLine());
                    product = new Product()
                    {
                        Id = productId,
                        Name = name,
                        Description = description,
                        Price = price
                    };
                    productManager.UpdateProduct(product);
                    Console.WriteLine("Product updated successfully...");
                    break;

                case 3:
                    Console.WriteLine("Enter product name");
                    string productName= Console.ReadLine();
                    productManager.DeleteProduct(productName);
                    Console.WriteLine("Product deleted successfully...");
                    break;

                case 4:
                    Console.WriteLine("Enter Product Id:\n");
                    int id1= Convert.ToInt32(Console.ReadLine());
                    productManager.ViewProductById(id1);
                    break;

                case 5:
                    productManager.ViewProduct(productManager.GetAllProduct());
                    break;

                case 6:
                    var menu=new MainMenu();
                    menu.Welcome();
                    break;

                default:
                    Console.WriteLine("Enter a valid number please...");
                    break;
            }
        }
    }
}
