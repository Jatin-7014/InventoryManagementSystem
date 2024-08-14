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
    internal class SupplierManagement
    {
        private readonly InventoryContext _context;
        public SupplierManagement(InventoryContext context)
        {
            _context = context;
        }
        public bool CheckSupplier(string supplierName)
        {
            return _context.Suppliers.Any(item => item.Name == supplierName);
        }
        public void AddSupplier(Supplier supplier)
        {
            if (CheckSupplier(supplier.Name))
            {
                Console.WriteLine("SupplierName already exists!");
            }
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }
        public void UpdateSupplier(Supplier supplier)
        {
            var existingSupplier = _context.Suppliers.Find(supplier.Id);
            if (existingSupplier != null)
            {
                existingSupplier.Name = supplier.Name;
                existingSupplier.Id= supplier.Id;
                existingSupplier.ContactInformation = supplier.ContactInformation;

                _context.Entry(existingSupplier).State = EntityState.Modified;
            }
            else
            {
               throw new NoSuchItemExistsException("Supplier doest not exists....");
            }
            if (CheckSupplier(supplier.Name))
            {
                Console.WriteLine("SupplierName already exists!");
            }
            _context.SaveChanges();
        }
        public void DeleteSupplier(string name)
        {
            var supplier = _context.Suppliers.Where(item => item.Name == name).FirstOrDefault();
            if (supplier != null)
            {
                Console.WriteLine(supplier);
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
            else
                throw new NoSuchItemExistsException("supplier doest not exists....");
        }
        public void ViewSupplierById(int id)
        {
            var supplier = _context.Suppliers.Where(item => item.Id == id).FirstOrDefault();
            if (supplier != null)
            {
                Console.WriteLine(supplier);
            }
            else
                throw new NoSuchItemExistsException("Supplier doest not exists....");
        }
        public List<Supplier> GetAllSupplier()
        {
            return _context.Suppliers.ToList();
        }
        public void ViewSupplier(List<Supplier> suppliers)
        {
            if (suppliers.Count == 0)
                throw new DatabaseIsEmptyException("Database is empty....");
            suppliers.ForEach(supplier => Console.WriteLine(supplier));
        }
    }
}
