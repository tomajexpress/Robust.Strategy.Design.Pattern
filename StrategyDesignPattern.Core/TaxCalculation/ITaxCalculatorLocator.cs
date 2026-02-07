using StrategyDesignPattern.Core.Enums;

namespace StrategyDesignPattern.Core.TaxCalculation;

public interface ITaxCalculatorLocator
{
    ITaxCalculatorStrategy GetTaxCalculator(SalaryType salaryType);
}
