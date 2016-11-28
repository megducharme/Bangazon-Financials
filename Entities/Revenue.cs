using System;

namespace Bangazon
{
	public class Revenue
	{
		public int id { get; set; }
		public string ProductName { get; set; }
		public string ProductCost { get; set; }
		public string ProductRevenue { get; set; }
		public string ProductSupplierState { get; set; }
		public string CustomerFirstName { get; set; }
		public string CustomerLastName { get; set; }
		public string CustomerAddress { get; set; }
        public string CustomerZipCode { get; set; }
        public string PurchaseDate { get; set; }

        public Revenue () { }
    }
}