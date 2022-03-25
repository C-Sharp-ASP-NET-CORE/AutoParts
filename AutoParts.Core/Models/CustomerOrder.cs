namespace AutoParts.Core.Models
{
    /// <summary>
    /// Order
    /// </summary>
    public class CustomerOrder
    {
        /// <summary>
        /// Customer's number
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// List of parts
        /// </summary>
        public List<PartOrder> Parts { get; set; } = new List<PartOrder>();
    }
}
