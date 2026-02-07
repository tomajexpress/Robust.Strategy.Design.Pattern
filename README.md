# Robust.Strategy.Design.Pattern
Robust Strategy Pattern in .NET 10: Building a Fail-Safe Tax Engine
This repository demonstrates a production-grade implementation of the Strategy Design Pattern using .NET 10. The project focuses on high encapsulation, fail-safe logic, and Clean Architecture principles to build a maintainable Tax Calculation Engine.

## 🚀 The Vision
Most implementations of the Strategy Pattern suffer from "Leaky Abstractions," where the consuming layer knows too much about the implementation details. This project introduces the "Internal Shield"—a design where concrete strategies are hidden from the outer layers, enforcing a strict dependency on interfaces.

## 🏗️ Core Architecture
The solution is divided into three distinct projects to ensure a clean separation of concerns:

  1. StrategyDesignPattern.Core: The "Engine Room." Contains all business logic, interfaces, and the Strategy Locator.

  2. StrategyDesignPattern.ConsoleApp: The "Presentation Layer." A lightweight client that interacts only with public interfaces.

  3. StrategyDesignPattern.TestProject: The "Quality Control." Unit tests that verify the mathematical correctness of each strategy.

## 🛡️ Key Features

1. The Internal Shield
All concrete tax strategies (Daily, Monthly, Yearly) are marked as internal. This prevents the Console Application from manually instantiating them, ensuring that the Dependency Inversion Principle is strictly followed.

2. Strategic Locator (Fail-Safe)
Instead of a giant switch statement in the business logic, we use a TaxCalculatorLocator. It acts as a smart factory that picks the correct strategy at runtime. If an invalid strategy is requested, the system is designed to handle it gracefully without crashing.

3. Centralized Configuration
We use a public configuration gateway to wire up our internal dependencies:

    ```csharp
    public static void RegisterTaxCalculation(ServiceCollection services)
    {
        services.AddSingleton<ITaxCalculatorStrategy, DailyTaxCalculation>();
        services.AddSingleton<ITaxCalculatorStrategy, MonthlyTaxCalculation>();
        // ...
        services.AddSingleton<ISalaryCalculator, SalaryCalculator>();
    }
