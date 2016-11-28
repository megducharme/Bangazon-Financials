using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Bangazon
{
	public class RevenueFactory
    {
		public List<Revenue> getAll()
		{
			BangazonConnection conn = new BangazonConnection ();
			List<Revenue> list = new List<Revenue> ();

			// Execute the query to retrieve all customers
			conn.execute (@"select 
				Id,
				ProductName,  
				ProductCost, 
				ProductRevenue, 
				ProductSupplierState, 
				CustomerFirstName, 
				CustomerLastName, 
				CustomerAddress,
                CustomerZipCode,
                PurchaseDate 
				from customer", 
				(SqliteDataReader reader) => {
					while (reader.Read ())
					{
						list.Add(new Revenue {
							id = reader.GetInt32(0),
							ProductName = reader [1].ToString(),
							ProductCost = reader [2].ToString(),
							ProductRevenue = reader [3].ToString(),
							ProductSupplierState = reader [4].ToString(),
							CustomerFirstName = reader [5].ToString(),
							CustomerLastName = reader [6].ToString(),
                            CustomerAddress = reader [7].ToString(),
                            CustomerZipCode = reader [8].ToString(),
							PurchaseDate = reader [9].ToString(),
						});
					}
				}
			);

			return list;
		}
	}
}