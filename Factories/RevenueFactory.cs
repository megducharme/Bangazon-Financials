using System;
using System.Collections.Generic;
using System.Text;
using Bangazon;
using Microsoft.Data.Sqlite;

namespace BangazonFinancials.Factory
{
	public class RevenueFactory
    {
		public StringBuilder BangazonHeader()
		{
			string border = "===========================";
			StringBuilder header = new StringBuilder ();
			header.AppendLine ("\n");
			header.AppendLine (border);
			header.AppendLine ("BANGAZON FINANCIAL REPORTS");
			header.AppendLine (border);

			return header;

		}

		public StringBuilder ReportHeader(string headerTitle)
		{
			StringBuilder reportHeader = new StringBuilder ();
            reportHeader.AppendLine (headerTitle);
            reportHeader.AppendLine ("\n");
            reportHeader.AppendLine (string.Format("{0,-30}" + "{1:c0}", "Product", "Amount"));
            reportHeader.AppendLine ("-------------------------------------");

			return reportHeader;

		}

		public List<KeyValuePair<string, int>> getReportBasedOnDays(int numberOfDays)
		{
			var specificDays = (-numberOfDays);

			string sqlQuery = $@"SELECT 
			ProductName, 
			ProductCost 
			FROM Revenue 
			WHERE PurchaseDate > DateTime ('now', '{specificDays} days') 
			ORDER by ProductCost";

			BangazonConnection conn = new BangazonConnection ();

			List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();

			conn.execute (sqlQuery, 
				(SqliteDataReader reader) => {
					
					while (reader.Read ())
					{
							var ProductName = reader[0];
							var StringProductName = ProductName.ToString();
							var ProductCost = reader[1];
							var StringProductCost = ProductCost.ToString();
							var IntProductCost = int.Parse(StringProductCost);
							var FinalReport = new KeyValuePair<string, int>(StringProductName, IntProductCost);

						list.Add(FinalReport);	
					};
			});

			return list;

		}

		public List<KeyValuePair<string, int>> getCustomerReport()
		{

			string sqlQuery = @"SELECT
			CustomerFirstName || ' ' || CustomerLastName as FullName,
			ProductCost
			FROM Revenue
			GROUP by FullName";
			Console.WriteLine(sqlQuery);

			BangazonConnection conn = new BangazonConnection ();

			List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();

			conn.execute (sqlQuery, 
				(SqliteDataReader reader) => {
					
					while (reader.Read ())
					{
							var CustomerName = reader[0];
							var StringCustomerName = CustomerName.ToString();
							var ProductCost = reader[1];
							var StringProductCost = ProductCost.ToString();
							var IntProductCost = int.Parse(StringProductCost);
							var FinalReport = new KeyValuePair<string, int>(StringCustomerName, IntProductCost);

						list.Add(FinalReport);	
					};
			});

			return list;
		
		}

		public List<KeyValuePair<string, int>> getProductReport()
		{

			string sqlQuery = @"SELECT
			ProductName,
			ProductCost
			FROM Revenue
			GROUP by ProductName";
			Console.WriteLine(sqlQuery);

			BangazonConnection conn = new BangazonConnection ();

			List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();

			conn.execute (sqlQuery, 
				(SqliteDataReader reader) => {
					
					while (reader.Read ())
					{
							var CustomerName = reader[0];
							var StringCustomerName = CustomerName.ToString();
							var ProductCost = reader[1];
							var StringProductCost = ProductCost.ToString();
							var IntProductCost = int.Parse(StringProductCost);
							var FinalReport = new KeyValuePair<string, int>(StringCustomerName, IntProductCost);

						list.Add(FinalReport);	
					};
			});

			return list;
		
		}
	}
}
