using StrategyDesignPattern.Core.Enums;

namespace StrategyDesignPattern.Core;

public interface ISalaryCalculator
{
    decimal CalculateSalaryAfterTax(decimal amount, SalaryType salaryType);
}
