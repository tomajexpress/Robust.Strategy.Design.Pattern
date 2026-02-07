using StrategyDesignPattern.Core.Enums;

namespace StrategyDesignPattern.Core.TaxCalculation;

internal class DailyTaxCaculation : ITaxCalculatorStrategy
{
    public decimal CalculateTax(decimal amount)
    {
        return amount * 0.05m;
    }

    public bool Satisfies(SalaryType salaryType)
    {
        return salaryType == SalaryType.Daily;  
    }
}