namespace StrategyDesignPattern.TestProject;

[TestClass]
public class TaxCalculatorLocatorTests
{
    [TestMethod]
    public void GetTaxCalculator_ShouldReturnCorrectType_WhenStrategyExists()
    {
        // Arrange
        var dailyMock = new Mock<ITaxCalculatorStrategy>();
        dailyMock.Setup(x => x.Satisfies(SalaryType.Daily)).Returns(true);

        var monthlyMock = new Mock<ITaxCalculatorStrategy>();
        monthlyMock.Setup(x => x.Satisfies(SalaryType.Monthly)).Returns(true);

        var calculators = new List<ITaxCalculatorStrategy> { dailyMock.Object, monthlyMock.Object };
        var sut = new TaxCalculatorLocator(calculators);

        // Act
        var result = sut.GetTaxCalculator(SalaryType.Daily);

        // Assert
        result.Should().Be(dailyMock.Object);
    }

    [TestMethod]
    public void GetTaxCalculator_ShouldThrowException_WhenStrategyIsMissing()
    {
        // Arrange
        var sut = new TaxCalculatorLocator(new List<ITaxCalculatorStrategy>());

        // Act
        Action act = () => sut.GetTaxCalculator(SalaryType.Yearly);

        // Assert
        act.Should().Throw<InvalidOperationException>()
           .WithMessage("No tax calculator found for the given salary type.");
    }

    [TestMethod]
    public void AllSalaryTypes_ShouldHaveAValidStrategy()
    {
        // Arrange
        var strategies = new List<ITaxCalculatorStrategy>
        {
            new DailyTaxCaculation(),
            new MonthyTaxCaculation(),
            new YearlyTaxCaculation()
        };

        var locator = new TaxCalculatorLocator(strategies);

        // Act & Assert
        foreach (SalaryType type in Enum.GetValues(typeof(SalaryType)))
        {
            Action act = () => locator.GetTaxCalculator(type);
            act.Should().NotThrow<InvalidOperationException>(
                $"because the enum value {type} must have a registered strategy.");
        }
    }
}
