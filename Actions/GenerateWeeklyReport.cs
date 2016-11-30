using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BangazonFinancials.Entities;
using BangazonFinancials.Factory;
using BangazonProductRevenueReports;
using Microsoft.Data.Sqlite;

namespace BangazonFinancials.Actions
{
	public class GenerateWeeklyReportAction
	{
        public static void ReadInput()
        {
            List<KeyValuePair<string, int>> weeklyreport = new List<KeyValuePair<string, int>>();
            RevenueFactory factory = new RevenueFactory();
            weeklyreport = factory.getReport(7);

            var mainHeader = factory.BangazonHeader();
            Console.WriteLine(mainHeader);

            var reportHeader = factory.ReportHeader("WEEKLY REPORT");
            Console.WriteLine(reportHeader);

            foreach (var product in weeklyreport)
                {
                    Console.WriteLine(string.Format("{0,-30}" + "{1:c0}", product.Key, product.Value));
                }

            Console.ReadLine();
        }
    }
}