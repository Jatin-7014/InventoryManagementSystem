using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryMiniProject.Data;
using InventoryMiniProject.Exceptions;
using InventoryMiniProject.Repositories;

namespace InventoryMiniProject.Controllers
{
    internal class InventoryReport
    {
        InventoryManagement inventoryManager = new InventoryManagement(new Data.InventoryContext());
        public void Welcome()
        {
            while (true)
            {
                Console.WriteLine("===============  WELCOME TO REPORT MANAGEMENT SYSTEM....  ===============");
                Console.WriteLine($"1.Generate Report\n" +
                    $"2.Exit\n");
                Console.WriteLine("Enter your choice\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    SubMenu(choice);
                }
                catch (NoSuchItemExistsException nb)
                {
                    Console.WriteLine(nb.Message);
                }
            }  
        }
        public void SubMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Inventory Id:");
                    int inventoryId = Convert.ToInt32(Console.ReadLine());
                    inventoryManager.GenerateReport(inventoryId);
                    break;
                case 2:
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
