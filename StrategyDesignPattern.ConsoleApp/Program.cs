using Microsoft.Extensions.DependencyInjection;
using StrategyDesignPattern.Core;
using StrategyDesignPattern.Core.Configurations;
using StrategyDesignPattern.Core.Enums;

var services = new ServiceCollection();

// 1. Register Services
DependencyConfigurations.RegisterTaxCaculation(services);

// 2. Build the Provider
using var serviceProvider = services.BuildServiceProvider();

// 3. Resolve Services
var salaryCalculator = serviceProvider.GetRequiredService<ISalaryCalculator>();

decimal grossSalary = 5000m;
decimal netSalary = salaryCalculator.CalculateSalaryAfterTax(grossSalary, SalaryType.Monthly);

Console.WriteLine($"Gross: {grossSalary:C}");
Console.WriteLine($"Net (Monthly Strategy): {netSalary:C}");