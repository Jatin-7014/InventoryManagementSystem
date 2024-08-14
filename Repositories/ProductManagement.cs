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
    internal class ProductManagement
    {
        private readonly InventoryContext _context;
        public ProductManagement(InventoryContext context)
        {
            _context = context;
        }

        public bool CheckProduct(string productName)
        {
            return _context.Products.Any(item=>item.Name==productName);
        }
        public void AddProduct(Product product)
        {
            if (CheckProduct(product.Name))
            {
                Console.WriteLine("ProductName already exists!");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;

                _context.Entry(existingProduct).State = EntityState.Modified;
            }
            else
            {
                throw new NoSuchItemExistsException("Product doest not exists....");
            }
            if (CheckProduct(product.Name))
            {
                Console.WriteLine("ProductName already exists!");
            }
            _context.SaveChanges();
        }
        public void DeleteProduct(string name)
        {
            var product = _context.Products.Where(item => item.Name == name).FirstOrDefault();
            if (product != null)
            {
                Console.WriteLine(product);
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            else
                throw new NoSuchItemExistsException("Product doest not exists....");
        }
        public void ViewProductById(int id)
        {
            var product = _context.Products.Where(item => item.Id == id).FirstOrDefault();
            if (product != null)
            {
                Console.WriteLine(product);
            }
            else
                throw new NoSuchItemExistsException("Product doest not exists....");
        }
        public List<Product> GetAllProduct()
        {
            return _context.Products.ToList();
        }
        public void ViewProduct(List<Product> products)
        {
            if(products.Count==0)
                throw new DatabaseIsEmptyException("Database is empty....");
            products.ForEach(product => Console.WriteLine(product));
        }
    }
}
