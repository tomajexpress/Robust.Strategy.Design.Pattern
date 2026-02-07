using StrategyDesignPattern.Core.Enums;

namespace StrategyDesignPattern.Core.TaxCalculation;

public interface ITaxCalculatorLocator
{
    ITaxCalculatorStrategy GetTaxCalculator(SalaryType salaryType);
}

internal class TaxCalculatorLocator(IEnumerable<ITaxCalculatorStrategy> taxCalculators) : ITaxCalculatorLocator
{
    public ITaxCalculatorStrategy GetTaxCalculator(SalaryType salaryType)
    {
        var taxCalculator = taxCalculators.FirstOrDefault(tc => tc.Satisfies(salaryType));

        if (taxCalculator == null)
        {
            throw new InvalidOperationException("No tax calculator found for the given salary type.");
        }

        return taxCalculator;
    }   
}