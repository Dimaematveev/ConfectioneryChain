using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryChain.DB
{
    public partial class Invoice
    {
        public override string ToString()
        {
            return $"[{OrderID}]";
        }
    }
}
