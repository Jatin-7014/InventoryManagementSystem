using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryMiniProject.Exceptions;

namespace InventoryMiniProject.Controllers
{
    internal class MainMenu
    {
        public void Welcome()
        {
            while (true)
            {
                Console.WriteLine("===============  WELCOME TO INVENTORY MANAGEMENT SYSTEM....  ===============");
                Console.WriteLine($"1.Product Management\n" +
                    $"2.Supplier Management\n" +
                    $"3.Transaction Management\n" +
                    $"4.Generate Report\n" +
                    $"5.Exit\n");
                Console.WriteLine("Enter your choice\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    SubMenu(choice);
                }
                catch (DatabaseIsEmptyException db)
                {
                    Console.WriteLine(db.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public void SubMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    ProductMenu productMenu = new ProductMenu();
                    productMenu.Welcome();
                    break;
                case 2:
                    SupplierMenu supplierMenu = new SupplierMenu();
                    supplierMenu.Welcome();
                    break;
                case 3:
                    TransactionMenu transactionMenu = new TransactionMenu();
                    transactionMenu.Welcome();
                    break;
                case 4:
                    InventoryReport inventoryReport = new InventoryReport();
                    inventoryReport.Welcome();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Enter a valid number please...");
                    break;
            }
        }
    }
}
