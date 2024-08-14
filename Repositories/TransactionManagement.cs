using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryMiniProject.Data;
using InventoryMiniProject.Exceptions;
using InventoryMiniProject.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryMiniProject.Repositories
{
    internal class TransactionManagement
    {
        private readonly InventoryContext _context;

        public TransactionManagement(InventoryContext context)
        {
            _context = context;
        }
        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
        public void AddStock(string name,int quantity)
        {
            var product = _context.Products.Where(item=>item.Name==name).FirstOrDefault();

            if (product != null)
            {
                product.Quantity += quantity;
                _context.Entry(product).State = EntityState.Modified;
                Transaction transaction = new Transaction()
                {
                    ProductId = product.Id,
                    Action = "New Stock Added",
                    Quantity = quantity,
                    Date = DateTime.Now,
                    InventoryId = product.InventoryId
                };
                AddTransaction(transaction);
                _context.SaveChanges();
            }
            else
                throw new NoSuchItemExistsException("No such Product Exists...");
        }
        public void RemoveStock(string name,int quantity)
        {
            var product=_context.Products.Where(item=>item.Name==name).FirstOrDefault();
            if (product != null)
            {
                int myQuantity=product.Quantity;
                myQuantity-=quantity;
                _context.Entry(product).State = EntityState.Modified;
                Transaction transaction = new Transaction()
                {
                    ProductId = product.Id,
                    Action = "Stock Deleted Successfully",
                    Quantity = quantity,
                    Date = DateTime.Now,
                    InventoryId = product.InventoryId
                };
                AddTransaction(transaction);
                _context.SaveChanges();
            }
        }
        public List<Transaction> GetAllTransactions()
        {
            return _context.Transactions.ToList();
        }
        public void DisplayTransaction(List<Transaction> transactions)
        {
            if (transactions.Count == 0)
                throw new DatabaseIsEmptyException("Transactions database is empty...");
            else
                transactions.ForEach(transaction=>Console.WriteLine(transaction));
        }
    }
}
