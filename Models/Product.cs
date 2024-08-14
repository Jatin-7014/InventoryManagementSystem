using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Models
{
    internal class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        [ForeignKey("Inventory")]
        public int InventoryId {  get; set; }

        public override string ToString()
        {
            return $"Product Id:{Id}\n" +
                $"Product Name:{Name}\n" +
                $"Product Description:{Description}\n" +
                $"Product Quantity:{Quantity}\n" +
                $"Product Price:{Price}\n" +
                $"Inventory Id:{InventoryId}\n";
        }
    }
}
