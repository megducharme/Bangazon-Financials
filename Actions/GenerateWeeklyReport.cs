using System;
using System.Collections.Generic;
using BangazonFinancials.Factory;

namespace BangazonFinancials.Actions
{
	public class GenerateDateRangeReportAction
	{
        public static void GenerateReport(string reportTitle, int numberOfDays)
        {
            List<KeyValuePair<string, int>> newReport = new List<KeyValuePair<string, int>>();
            RevenueFactory factory = new RevenueFactory();
            newReport = factory.getReport(numberOfDays);

            var mainHeader = factory.BangazonHeader();
            Console.WriteLine(mainHeader);

            var reportHeader = factory.ReportHeader(reportTitle);
            Console.WriteLine(reportHeader);

            foreach (var product in newReport)
                {
                    Console.WriteLine(string.Format("{0,-30}" + "{1:c0}", product.Key, product.Value));
                }

            Console.ReadLine();
        }
    }
}