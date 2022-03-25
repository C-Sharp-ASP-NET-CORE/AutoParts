using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.Core.Models
{
    public class PartOrder
    {
        /// <summary>
        /// SerialNumber of the product
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Ordered products count
        /// </summary>
        public int Count { get; set; }
    }
}
