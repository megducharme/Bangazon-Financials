using System;

namespace BangazonFinancials.Entities
{
	public class Revenue
	{
		public int id { get; set; }
		public string ProductName { get; set; }
		public string ProductCost { get; set; }
		public string ProductRevenue { get; set; }
        public string PurchaseDate { get; set; }
    }
}