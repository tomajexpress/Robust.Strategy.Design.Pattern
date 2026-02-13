using StrategyDesignPattern.Core.Enums;

namespace StrategyDesignPattern.Core.TaxCalculation;

internal class TaxCalculatorLocator(IEnumerable<ITaxCalculatorStrategy> taxCalculators) : ITaxCalculatorLocator
{
    public ITaxCalculatorStrategy GetTaxCalculator(SalaryType salaryType)
    {
        var taxCalculator = taxCalculators.FirstOrDefault(tc => tc.Satisfies(salaryType));

        if (taxCalculator == null)
        {
            // Fail-Fast: It is better to crash than to calculate wrong taxes.
            throw new InvalidOperationException($"No tax calculator found for the given salary type: {salaryType}");
        }

        return taxCalculator;
    }   
}