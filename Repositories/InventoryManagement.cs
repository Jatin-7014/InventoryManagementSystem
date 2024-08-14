using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryMiniProject.Data;
using InventoryMiniProject.Exceptions;
using InventoryMiniProject.Models;

namespace InventoryMiniProject.Repositories
{
    internal class InventoryManagement
    {
        List<Product> Products { get; set; }
        List<Supplier> Suppliers { get; set; }
        List<Transaction> Transactions { get; set; }

        public readonly InventoryContext _context;

        public InventoryManagement(InventoryContext context)
        {
            _context = context;
        }

        public bool CheckInventoryId(int inventoryId)
        {
            return _context.Inventories.Any(item => item.InventoryId == inventoryId);
        }

        public void InventoryIdExists(int inventoryId)
        {
            if (CheckInventoryId(inventoryId))
            {
                throw new NoSuchItemExistsException("Invalid Inventory Id. Inventory doesn't exist.");
            }
        }

        public List<Product> GetProducts(int inventoryId)
        {
            return _context.Products.Where(product => product.InventoryId == inventoryId).ToList();
        }

        public List<Supplier> GetSuppliers(int inventoryId)
        {
            return _context.Suppliers.Where(supplier => supplier.InventoryId == inventoryId).ToList();
        }

        public List<Transaction> GetTransactions(int inventoryId)
        {
            return _context.Transactions.Where(transaction => transaction.InventoryId == inventoryId).ToList();
        }

        public void GenerateReport(int inventoryId)
        {
            InventoryIdExists(inventoryId);

            Products = GetProducts(inventoryId);
            Suppliers = GetSuppliers(inventoryId);
            Transactions = GetTransactions(inventoryId);

            Console.WriteLine($"Report for Inventory ID: {inventoryId}");

            Console.WriteLine("Products:");
            Products.ForEach(product => Console.WriteLine(product));

            Console.WriteLine("Suppliers:");
            Suppliers.ForEach(supplier => Console.WriteLine(supplier));

            Console.WriteLine("Transactions:");
            Transactions.ForEach(transaction => Console.WriteLine(transaction));
        }
    }
}
