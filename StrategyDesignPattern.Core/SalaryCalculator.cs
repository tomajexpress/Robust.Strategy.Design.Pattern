using StrategyDesignPattern.Core.Enums;
using StrategyDesignPattern.Core.TaxCalculation;

namespace StrategyDesignPattern.Core;

internal class SalaryCalculator(ITaxCalculatorLocator taxCalculatorLocator) : ISalaryCalculator
{
    private readonly ITaxCalculatorLocator _taxCalculatorLocator = taxCalculatorLocator;

    public decimal CalculateSalaryAfterTax(decimal amount, SalaryType salaryType)
    {
        var taxCalculator = _taxCalculatorLocator.GetTaxCalculator(salaryType);
        var tax = taxCalculator.CalculateTax(amount);
        return amount - tax;
    }
}
