using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Models
{
    internal class Inventory
    {
        public int InventoryId {  get; set; }
        public string Location {  get; set; }

        List<Product> Products { get; set; }
        List<Supplier> Suppliers { get; set; }
        List<Transaction> Transactions { get; set; }

    }
}
