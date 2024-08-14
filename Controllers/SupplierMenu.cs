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
    internal class SupplierMenu
    {
        SupplierManagement supplierManager = new SupplierManagement(new Data.InventoryContext());
        public void Welcome()
        {
            while (true)
            {
                Console.WriteLine("===============  WELCOME TO SUPPLIER MANAGEMENT ....  ===============");
                Console.WriteLine($"1.Add Supplier\n" +
                    $"2.Update Supplier\n" +
                    $"3.Delete Supplier\n" +
                    $"4.View Supplier Details\n" +
                    $"5.View All Suppliers\n" +
                    $"6.Go back\n");
                Console.WriteLine("Enter your choice\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    SubMenu(choice);
                }
                catch(NoSuchItemExistsException ns)
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
                    Console.WriteLine("Enter Supplier Details:\n");
                    Console.WriteLine("Name of Supplier\n");
                    string name = Console.ReadLine();
                   // Console.WriteLine("Id of the Supplier:\n");
                    //int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Contact Information:\n");
                    string information= Console.ReadLine();
                    InventoryManagement inventoryManager = new InventoryManagement(new Data.InventoryContext());
                    Console.WriteLine("Enter InventoryId: ");
                    int inventoryId = Convert.ToInt32(Console.ReadLine());

                    Supplier supplier = new Supplier()
                    {
                        Name = name,
                        ContactInformation=information,
                        InventoryId=inventoryId
                    };
                    supplierManager.AddSupplier(supplier);
                    Console.WriteLine("Supplier Added successfully...");
                    break;
                case 2:
                    Console.WriteLine("Enter Supplier ID");
                    int supplierId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Supplier Name");
                    string name1 = Console.ReadLine();
                    supplierManager.CheckSupplier(name1);
                    Console.WriteLine("Contact Information");
                    string informations = Console.ReadLine();
                    supplier = new Supplier()
                    {
                        Id = supplierId,
                        Name = name1,
                        ContactInformation=informations
                    };
                    supplierManager.UpdateSupplier(supplier);
                    Console.WriteLine("Supplier Updated Successfully...");
                    break;
                case 3:
                    Console.WriteLine("Enter supplier name");
                    string supplierName = Console.ReadLine();
                    supplierManager.DeleteSupplier(supplierName);
                    Console.WriteLine("Supplier deleted successfully...");
                    break;
                case 4:
                    Console.WriteLine("Enter Product Id:\n");
                    int id1 = Convert.ToInt32(Console.ReadLine());
                    supplierManager.ViewSupplierById(id1);
                    break;
                case 5:
                    supplierManager.ViewSupplier(supplierManager.GetAllSupplier());
                    break;
                case 6:
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
