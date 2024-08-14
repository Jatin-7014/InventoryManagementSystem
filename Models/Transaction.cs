using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Models
{
    internal class Transaction
    {
     [Key]
     public int TransactionId {  get; set; }
     public int ProductId {  get; set; }
     public string Action {  get; set; }
     public int Quantity {  get; set; }
     public DateTime Date { get; set; }

        [ForeignKey("Inventory")]
        public int InventoryId {  get; set; }
        public override string ToString()
        {
            return $" Id:{TransactionId}\n" +
                $"ProductId:{ProductId}\n" +
                $"Action:{Action}\n" +
                $"Quantity:{Quantity}\n" +
                $"Date:{Date}\n" +
                $"Inventory Id:{InventoryId}";
        }
    }
}
