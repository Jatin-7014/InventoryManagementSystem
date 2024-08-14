using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using InventoryMiniProject.Exceptions;
using InventoryMiniProject.Models;
using InventoryMiniProject.Repositories;

namespace InventoryMiniProject.Controllers
{
    internal class TransactionMenu
    {
        TransactionManagement transactionManager = new TransactionManagement(new Data.InventoryContext());
        public void Welcome()
        {
            while (true)
            {
                Console.WriteLine("===============  WELCOME TO TRANSACTION MANAGEMENT ....  ===============");
                Console.WriteLine($"1.Add Stock\n" +
                    $"2.Remove Stock\n" +
                    $"3.View Transaction History \n" +
                    $"4.Go back\n");
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
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Quantity\n");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    transactionManager.AddStock(name, quantity);
                    Console.WriteLine("Added stock successfully...");
                    break;

                case 2:
                    Console.WriteLine("Product Name");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter Quantity\n");
                    quantity = Convert.ToInt32(Console.ReadLine());
                    transactionManager.RemoveStock(name, quantity);
                    Console.WriteLine("Removed stock successfully...");
                    break;

                case 3:
                    Console.WriteLine("Transaction History");
                    transactionManager.DisplayTransaction(transactionManager.GetAllTransactions());
                    break;

                case 4:
                    var menu = new MainMenu();
                    menu.Welcome();
                    break;

                default:
                    Console.WriteLine("Enter a valid number please...");
                    break;
            }
        }
        
    }
}
