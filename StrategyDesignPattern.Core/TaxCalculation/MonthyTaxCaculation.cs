using StrategyDesignPattern.Core.Enums;

namespace StrategyDesignPattern.Core.TaxCalculation;

internal class MonthyTaxCaculation : ITaxCalculatorStrategy
{
    public decimal CalculateTax(decimal amount)
    {
        return amount * 0.15m;
    }

    public bool Satisfies(SalaryType salaryType)
    {
        return salaryType == SalaryType.Monthly;
    }
}