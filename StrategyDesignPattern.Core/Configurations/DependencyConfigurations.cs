using Microsoft.Extensions.DependencyInjection;
using StrategyDesignPattern.Core.TaxCalculation;

namespace StrategyDesignPattern.Core.Configurations;

public class DependencyConfigurations
{
    public static void RegisterTaxCaculation(ServiceCollection services)
    {
        services.AddSingleton<ITaxCalculatorStrategy, DailyTaxCaculation>();
        services.AddSingleton<ITaxCalculatorStrategy, MonthyTaxCaculation>();
        services.AddSingleton<ITaxCalculatorStrategy, YearlyTaxCaculation>();

        services.AddSingleton<ITaxCalculatorLocator, TaxCalculatorLocator>();
        services.AddSingleton<ISalaryCalculator, SalaryCalculator>();
    }
}
