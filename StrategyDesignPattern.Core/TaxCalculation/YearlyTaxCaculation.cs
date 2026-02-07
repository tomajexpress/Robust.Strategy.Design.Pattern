using StrategyDesignPattern.Core.Enums;

namespace StrategyDesignPattern.Core.TaxCalculation;

internal class YearlyTaxCaculation : ITaxCalculatorStrategy
{
    public decimal CalculateTax(decimal amount)
    {
        return amount * 0.25m;
    }

    public bool Satisfies(SalaryType salaryType)
    {
        return salaryType == SalaryType.Yearly;
    }
}