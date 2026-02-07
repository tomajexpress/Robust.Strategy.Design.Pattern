namespace StrategyDesignPattern.Core.TestProject;

[TestClass]
public class SalaryCalculatorTests
{
    private Mock<ITaxCalculatorLocator> _locatorMock = default!;
    private Mock<ITaxCalculatorStrategy> _strategyMock = default!;
    private SalaryCalculator _sut = default!;

    [TestInitialize]
    public void Setup()
    {
        _locatorMock = new Mock<ITaxCalculatorLocator>();
        _strategyMock = new Mock<ITaxCalculatorStrategy>();
        _sut = new SalaryCalculator(_locatorMock.Object);
    }

    [TestMethod]
    public void CalculateSalaryAfterTax_ShouldReturnCorrectNetValue()
    {
        // Arrange
        decimal gross = 1000m;
        decimal taxAmount = 200m;
        decimal expectedNet = 800m;

        _locatorMock.Setup(l => l.GetTaxCalculator(SalaryType.Monthly))
                    .Returns(_strategyMock.Object);

        _strategyMock.Setup(s => s.CalculateTax(gross))
                     .Returns(taxAmount);

        // Act
        var result = _sut.CalculateSalaryAfterTax(gross, SalaryType.Monthly);

        // Assert
        result.Should().Be(expectedNet);
        _locatorMock.Verify(x => x.GetTaxCalculator(SalaryType.Monthly), Times.Once);
        _strategyMock.Verify(x => x.CalculateTax(gross), Times.Once);
    }

    [TestMethod]
    public void CalculateSalary_ShouldSubtractTax_WhenStrategyIsFound()
    {
        // Arrange
        var locatorMock = new Mock<ITaxCalculatorLocator>();
        var strategyMock = new Mock<ITaxCalculatorStrategy>();

        strategyMock.Setup(s => s.CalculateTax(1000m)).Returns(200m);
        locatorMock.Setup(l => l.GetTaxCalculator(SalaryType.Monthly)).Returns(strategyMock.Object);

        var sut = new SalaryCalculator(locatorMock.Object);

        // Act
        var result = sut.CalculateSalaryAfterTax(1000m, SalaryType.Monthly);

        // Assert
        result.Should().Be(800m); // 1000 - 200
    }
}
