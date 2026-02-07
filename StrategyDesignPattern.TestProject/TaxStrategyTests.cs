namespace StrategyDesignPattern.TestProject;

[TestClass]
public class TaxStrategyTests
{
    [TestMethod]
    [DataRow(1000, 50)] // 5% of 1000
    public void DailyTax_ShouldCalculateCorrectly(double amount, double expectedTax)
    {
        var sut = new DailyTaxCaculation();
        sut.CalculateTax((decimal)amount).Should().Be((decimal)expectedTax);
        sut.Satisfies(SalaryType.Daily).Should().BeTrue();
    }

    [TestMethod]
    [DataRow(1000, 150)] // 15% of 1000
    public void MonthlyTax_ShouldCalculateCorrectly(double amount, double expectedTax)
    {
        var sut = new MonthyTaxCaculation();
        sut.CalculateTax((decimal)amount).Should().Be((decimal)expectedTax);
        sut.Satisfies(SalaryType.Monthly).Should().BeTrue();
    }

    [TestMethod]
    [DataRow(1000, 250)] // 25% of 1000
    public void YearlyTax_ShouldCalculateCorrectly(double amount, double expectedTax)
    {
        var sut = new YearlyTaxCaculation();
        sut.CalculateTax((decimal)amount).Should().Be((decimal)expectedTax);
        sut.Satisfies(SalaryType.Yearly).Should().BeTrue();
    }
}