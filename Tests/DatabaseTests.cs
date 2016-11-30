using System;
using BangazonFinancials.Entities;
using Xunit;

namespace BanagzonFinancialUnitTests
{
    public class DatabaseTest
    {
        [Fact]
        public void trueTest()
        {
            bool truthy = true;
            Assert.Equal(truthy, true);

        }

        [Fact]
        public void GenerateWeeklyReport()
        {
            WeeklyReport weeklyreport1 = new WeeklyReport();
            weeklyreport1.getWeeklyReport();
            Assert.True(weeklyreport1.Count >= 0);
            Assert.NotNull(weeklyreport1);
        }

        [Fact]
        public void GenerateMonthlyReport()
        {
            MonthlyReport monthlyreport1 = new MonthlyReport();
            monthlyreport1.getMonthlyReport();
            Assert.True(monthlyreport1.Count >= 0);
            Assert.NotNull(monthlyreport1);
        }

        [Fact]
        public void GenerateQuartlyReport()
        {
            QuarterlyReport quartlyreport1 = new QuarterlyReport();
            quartlyreport1.getQuarterlyReport();
            Assert.True(quartlyreport1.Count >= 0);
            Assert.NotNull(quartlyreport1);
        }

        [Fact]
        public void GenerateCustomerRevenue()
        {
            CustomerReport customerrevenue1 = new CustomerReport();
            customerrevenue1.getCustomerReport();

        }

        [Fact]
        public void GenerateProductRevenue()
        {
            ProductReport productreport1 = new ProductReport();
            productreport1.getProductReport();

        }

    }
}