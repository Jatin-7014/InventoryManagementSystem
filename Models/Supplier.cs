using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Models
{
    internal class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }

        [ForeignKey("Inventory")]
        public int InventoryId {  get; set; }

        public override string ToString()
        {
            return $"Supplier Id:{Id}\n" +
                $"Supplier Name:{Name}\n" +
                $"Supplier ContactInfo:{ContactInformation}\n" +
                $"Inventory Id:{InventoryId}";
        }
    }
}
