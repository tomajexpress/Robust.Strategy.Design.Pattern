# Robust.Strategy.Design.Pattern

[![.NET](https://img.shields.io/badge/.NET-10.0-purple.svg)](https://dotnet.microsoft.com/)
[![Architecture](https://img.shields.io/badge/Architecture-Clean%20%26%20DDD-green.svg)]
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

> **Companion Repository for the Medium Article:** > [Robust Strategy Pattern in .NET 10: Building a Fail-Safe Tax Engine](https://medium.com/@aman.toumaj/robust-strategy-pattern-in-net-10-building-a-fail-safe-tax-calculation-engine-5ecb3003f2dd)

## 📖 Overview
Robust Strategy Pattern in .NET 10: Building a Fail-Safe Tax Engine
This repository demonstrates a production-grade implementation of the Strategy Design Pattern using .NET 10. The project focuses on high encapsulation, fail-safe logic, and Clean Architecture principles to build a maintainable Tax Calculation Engine. This codebase is part of a technical deep-dive. For a full explanation of the theory and implementation details, check out the article: "Robust Strategy Pattern in .NET 10: Building a Fail-Safe Tax Engine."

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
    
## 📂 Project Structure
    Solution 'Robust.Strategy.Design.Pattern'
    ├── 🖥️ StrategyDesignPattern.ConsoleApp (Entry Point)
    │   └── Program.cs
    ├── 🛡️ StrategyDesignPattern.Core (The "Engine Room")
    │   ├── ⚙️ Configurations
    │   │   └── DependencyConfigurations.cs (DI Registry)
    │   ├── 🏷️ Enums
    │   │   └── SalaryType.cs
    │   ├── 🧮 TaxCalculation
    │   │   ├── ITaxCalculatorStrategy.cs (Internal)
    │   │   ├── TaxCalculatorLocator.cs (Internal)
    │   │   ├── DailyTaxCalculation.cs (Internal)
    │   │   ├── MonthlyTaxCalculation.cs (Internal)
    │   │   └── YearlyTaxCalculation.cs (Internal)
    │   ├── 📄 ISalaryCalculator.cs (Public Interface)
    │   └── 📄 SalaryCalculator.cs (Internal Implementation)
    └── 🧪 StrategyDesignPattern.TestProject (Unit Tests)
        └── StrategyTests.cs

## 🛠️ Getting Started

Prerequisites

.NET 10 SDK ### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/Robust.Strategy.Design.Pattern.git

2. Navigate to the solution folder:
   ```bash
   cd Robust.Strategy.Design.Pattern

3. Restore dependencies:
   ```bash
   dotnet restore

4. Running the App:
   ```bash
   dotnet run --project StrategyDesignPattern.ConsoleApp

5. Running Tests:
   ```bash
   dotnet test
   

## 🤝 Contributing
Contributions are welcome! Please ensure that any PR maintains the "Green" status of the Architecture Tests.
