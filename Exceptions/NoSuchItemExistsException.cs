using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMiniProject.Exceptions
{
    internal class NoSuchItemExistsException:Exception
    {
        public NoSuchItemExistsException(string message) : base(message)
        {

        }
    }
}
