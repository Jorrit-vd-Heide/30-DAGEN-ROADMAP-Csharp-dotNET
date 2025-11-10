# 🗺️ 30-DAGEN ROADMAP – C# / .NET 

![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-Intermediate-green?logo=csharp)
![Visual Studio_Code](https://img.shields.io/badge/Visual%20Studio%20Code-007ACC?logo=visualstudiocode&logoColor=fff&style=plastic)
![GitHub](https://img.shields.io/badge/Version%20Control-GitHub-black?logo=github)

---

📅 **Richtlijn:** 3–4 uur per dag  
🎯 **Doel:** Zelfstandig een REST API kunnen bouwen met ASP.NET Core + EF Core + Testing  
⚙️ **Tools:** Visual Studio 2022 of VS Code · .NET SDK · GitHub account  

---

## 📚 Inhoud

| Week | Onderwerp | Belangrijkste Projecten |
|------|------------|-------------------------|
| 1 | C# Fundamentals & OOP | Console ToDo App |
| 2 | Intermediate C# & .NET | Weather CLI |
| 3 | ASP.NET Core + EF Core | BookStore API |
| 4 | Testing & Architecture | TaskManager API |

---

## 🧠 Einddoel

Na deze roadmap kun je:

- REST API’s bouwen met **ASP.NET Core**  
- Data beheren via **Entity Framework Core**  
- Unit tests schrijven met **xUnit** en **Moq**  
- **Clean Architecture** toepassen in echte projecten  

---

# 🧩 WEEK 1 – C# FUNDAMENTALS & OOP  
🧠 **Doel:** Basis van de taal + OOP-concepten stevig neerzetten  

| Dag | Onderwerp | Oefening | Bronnen |
|-----|------------|-----------|----------|
| 1 | Intro tot .NET & C# | Installeer .NET SDK & IDE. Bouw “Hello World” console-app. | [Microsoft Learn: Get started with C#](https://learn.microsoft.com/en-us/dotnet/csharp/) |
| 2 | Types, variabelen, operators | Maak rekenmachine (optellen, aftrekken, vermenigvuldigen, delen). | [C# Fundamentals – freeCodeCamp](https://www.youtube.com/watch?v=GhQdlIFylQ8) |
| 3 | Control flow: if, switch, loops | Bouw nummerraadspel (random number, gebruiker raadt). | [Microsoft Learn: Control statements](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements) |
| 4 | Methods & scope | Refactor rekenmachine in losse methods. | — |
| 5 | Classes & objects | Bouw class `Car` met eigenschappen (merk, snelheid) en methoden. | [Microsoft Learn: Classes and Objects](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/) |
| 6 | Inheritance & interfaces | Maak `Animal`, `Dog`, `Cat` met interface `ISound`. | [W3Schools C# Interface](https://www.w3schools.com/cs/cs_interface.php) [Microsoft Learn: Inheritance](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance) |
| 7 | Mini-project: ToDo App | Console ToDo (CRUD in memory) met lijst en LINQ. | — |

---

# ⚙️ WEEK 2 – INTERMEDIATE C# + .NET BASICS  
🧠 **Doel:** LINQ, async/await, error handling, dependency injection begrijpen  

| Dag | Onderwerp | Oefening | Bronnen |
|-----|------------|-----------|----------|
| 8 | Collections & Generics | Gebruik `List<T>`, `Dictionary<TKey, TValue>` in kleine voorbeelden. | [Collections in C#](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/list-collection) |
| 9 | Exceptions & try/catch | Breid ToDo App uit met foutafhandeling (lege invoer, invalid ID). |[Error handling in C#](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/)|
| 10 | LINQ basics | Filter & sorteer ToDo’s via LINQ. | [LINQ Tutorial](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/) |
| 11 | Async & await | Bouw mini “API call simulator” met `Task.Delay`. | — |
| 12 | File I/O | Lees/schrijf ToDo’s naar tekstbestand. | [File IO in C#](https://learn.microsoft.com/en-us/dotnet/standard/io/) |
| 13 | Dependency Injection (DI) | Gebruik DI om services in te pluggen. | [Dependency Injection basics](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) |
| 14 | Projectdag: CLI Weather App | Console-app die weer-data ophaalt via API. | [Tutorial: Create a controller-based web API with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-9.0&tabs=visual-studio) |

---

# 🧱 WEEK 3 – ASP.NET CORE + ENTITY FRAMEWORK CORE  
🧠 **Doel:** REST API leren bouwen met database  

| Dag | Onderwerp | Oefening | Bronnen |
|-----|------------|-----------|----------|
| 15 | Intro ASP.NET Core | Maak nieuw Web API project (`dotnet new webapi`) en test met Swagger. | [Build your first web API](https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/) |
| 16 | Controllers & routing | Bouw `BooksController` met CRUD (in memory). | — |
| 17 | Dependency Injection + Services | Voeg `BookService` toe en injecteer in controller. | — |
| 18 | Entity Framework Core basics | Voeg EF Core toe, maak `BookDbContext`, gebruik SQLite. | [EF Core Docs](https://learn.microsoft.com/en-us/ef/core/) |
| 19 | Migrations & LINQ to Entities | Voeg database aan en gebruik `dotnet ef migrations add`. | — |
| 20 | DTO’s & AutoMapper | Introduceer DTO’s voor nettere API’s. | [AutoMapper Docs](https://docs.automapper.org/) |
| 21 | Projectdag: BookStore API | Volledige CRUD API met EF Core + Swagger. | — |

---

# 🧩 WEEK 4 – TESTING, ARCHITECTURE & CLEAN CODE  
🧠 **Doel:** Testen, refactoren, clean architecture toepassen  

| Dag | Onderwerp | Oefening | Bronnen |
|-----|------------|-----------|----------|
| 22 | Unit testing basics (xUnit) | Test eenvoudige methodes. | [xUnit Tutorial](https://xunit.net/docs/getting-started/netcore/cmdline) |
| 23 | Mocking & services | Test je `BookService` met Moq. | [Moq GitHub](https://github.com/moq/moq4) |
| 24 | Logging & configuration | Voeg Serilog toe aan API. | [Serilog Docs](https://serilog.net/) |
| 25 | Clean Architecture principes | Scheid API, Core, Data lagen. | [Clean Architecture in .NET (Jason Taylor)](https://github.com/jasontaylordev/CleanArchitecture) |
| 26 | Git & GitHub | Maak repo aan, commit BookStore API met readme. | [GitHub Guide](https://guides.github.com/) |
| 27 | Validation & middleware | Voeg model validation + custom error handling middleware toe. | — |
| 28–29 | Eindproject: TaskManager API | REST API met EF Core, DTO’s, async methods, unit tests. | — |
| 30 | Review & showcase | Refactor code, voeg Swagger docs toe, push naar GitHub. | — |

---

# ✅ Wat je na 30 dagen kunt

- Schone C#-code schrijven met **OOP** & **LINQ**  
- Async programmeren  
- Werken met **Dependency Injection**  
- Volledige **ASP.NET Core Web API** bouwen  
- Data beheren via **Entity Framework Core**  
- Unit tests schrijven met **xUnit** & **Moq**  
- **Clean Architecture** toepassen  
- Projecten hosten op **GitHub** of **Azure**  

---

# 🧠 Bonus Tips

💡 Gebruik **ChatGPT** als mentor: vraag om code review of uitleg van errors.  
🔁 Elke 3 dagen: lees je eigen code hardop en **refactor**.  
📝 Maak notities van wat je lastig vond — focus daar extra op.  
🚀 Sluit de maand af met een **showcase**: publiceer je TaskManager API op GitHub met beschrijving, endpoints en screenshots.

---
