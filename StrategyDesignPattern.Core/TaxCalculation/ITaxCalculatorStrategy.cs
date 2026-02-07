using StrategyDesignPattern.Core.Enums;

namespace StrategyDesignPattern.Core.TaxCalculation;

public interface ITaxCalculatorStrategy
{
    decimal CalculateTax(decimal amount);
    bool Satisfies(SalaryType salaryType);
}