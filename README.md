# 🧭 C# / .NET Roadmap

Je vindt hier dagelijkse oefeningen, mini-projecten en eindprojecten (API's met ASP.NET Core en Entity Framework Core).

---

## 📚 Inhoud

| Week | Onderwerp | Belangrijkste Projecten |
|------|------------|-------------------------|
| 1 | C# Fundamentals & OOP | Console ToDo App |
| 2 | Intermediate C# & .NET | Weather CLI |
| 3 | ASP.NET Core + EF Core | BookStore API |
| 4 | Testing & Architecture | TaskManager API |

---

## ⚙️ Tools
- .NET 8 SDK  
- Visual Studio 2022 of VS Code  
- Git + GitHub  
- Postman / Swagger  

---

## 🧠 Einddoel
Na deze roadmap kun je:
- REST API’s bouwen met ASP.NET Core  
- Data beheren via Entity Framework Core  
- Unit tests schrijven met xUnit en Moq  
- Clean Architecture toepassen  

---

🗺️ 30-DAGEN ROADMAP – C# / .NET (Medior Niveau)

📅 Richtlijn: 3–4 uur per dag
🎯 Doel: Zelfstandig een REST API kunnen bouwen met ASP.NET Core + EF Core + Testing
⚙️ Tools: Visual Studio 2022 of VS Code + .NET SDK + GitHub account

🧩 WEEK 1 – C# FUNDAMENTALS & OOP
🧠 Doel:

Basis van de taal + OOP-concepten stevig neerzetten.

Dag	Onderwerp	Oefening	Bronnen
1	Intro tot .NET & C#	Installeer .NET SDK & IDE. Bouw “Hello World” console-app.	Microsoft Learn: Get started with C#

2	Types, variabelen, operators	Maak rekenmachine (optellen, aftrekken, vermenigvuldigen, delen) via console.	C# Fundamentals (FreeCodeCamp)

3	Control flow: if, switch, loops	Bouw nummerraadspel (random number, gebruiker raadt).	Microsoft Learn: Control statements

4	Methods & scope	Refactor rekenmachine in losse methods.	—
5	Classes & objects	Bouw class Car met eigenschappen (merk, snelheid) en methoden.	Microsoft Learn: Classes and Objects

6	Inheritance & interfaces	Maak Animal, Dog, Cat met interface ISound.	—
7	Mini-project: ToDo App	Console ToDo (CRUD in memory) met lijst en LINQ.	—
⚙️ WEEK 2 – INTERMEDIATE C# + .NET BASICS
🧠 Doel:

LINQ, async/await, error handling, dependency injection begrijpen.

Dag	Onderwerp	Oefening	Bronnen
8	Collections & Generics	Gebruik List<T>, Dictionary<TKey, TValue> in kleine voorbeelden.	Collections in C#

9	Exceptions & try/catch	Breid ToDo App uit met foutafhandeling (lege invoer, invalid ID).	—
10	LINQ basics	Filter & sorteer ToDo’s via LINQ.	LINQ Tutorial

11	Async & await	Bouw mini “API call simulator” met Task.Delay.	—
12	File I/O	Lees/schrijf ToDo’s naar tekstbestand.	File IO in C#

13	Dependency Injection (DI)	Gebruik DI om services in te pluggen.	Dependency injection basics

14	Projectdag: CLI Weather App	Maak console-app die weer-data ophaalt via API (OpenWeatherMap).	YouTube: “C# HttpClient Tutorial”
🧱 WEEK 3 – ASP.NET CORE + ENTITY FRAMEWORK CORE
🧠 Doel:

REST API leren bouwen met database.

Dag	Onderwerp	Oefening	Bronnen
15	Intro ASP.NET Core	Maak nieuwe Web API project (dotnet new webapi). Test met Swagger.	Microsoft Learn: Build your first web API

16	Controllers & routing	Bouw BooksController met CRUD (in memory).	—
17	Dependency Injection + Services	Voeg BookService class toe en injecteer in controller.	—
18	Entity Framework Core basics	Voeg EF Core toe, maak BookDbContext, gebruik SQLite.	EF Core Docs

19	Migrations & LINQ to Entities	Voeg database aan en gebruik dotnet ef migrations add.	—
20	DTO’s & AutoMapper	Introduceer DTO’s voor nettere API’s.	AutoMapper Docs

21	Projectdag: BookStore API	Volledige CRUD API met EF Core + Swagger.	—
🧩 WEEK 4 – TESTING, ARCHITECTURE & CLEAN CODE
🧠 Doel:

Testen, refactoren, clean architecture toepassen.

Dag	Onderwerp	Oefening	Bronnen
22	Unit testing basics (xUnit)	Test eenvoudige methodes.	xUnit Tutorial

23	Mocking & services	Test je BookService met Moq.	Moq GitHub

24	Logging & configuration	Voeg Serilog toe aan API.	Serilog Docs

25	Clean Architecture principes	Scheid API, Core, Data lagen.	Clean Architecture in .NET

26	Git & GitHub	Maak repo aan, commit BookStore API met readme.	GitHub Guide

27	Validation & middleware	Voeg model validation + custom error handling middleware toe.	—
28–29	Eindproject: TaskManager API	REST API met EF Core, DTO’s, async methods, unit tests.	—
30	Review & showcase	Refactor code, voeg Swagger docs toe, push naar GitHub.	—
🧱 Wat je na 30 dagen kunt

✅ Schone C#-code schrijven met OOP & LINQ
✅ Async programmeren
✅ Werken met dependency injection
✅ Volledige ASP.NET Core Web API bouwen
✅ EF Core gebruiken voor dataopslag
✅ Unit tests schrijven met xUnit & Moq
✅ Clean Architecture toepassen
✅ Projecten hosten op GitHub / Azure

🧠 Bonus Tips

Gebruik ChatGPT als mentor: vraag om code review of uitleg van errors.

Elke 3 dagen herhaal: lees eigen code hardop en refactor.

Maak notities: wat je lastig vond → daar focus je extra op.

Sluit maand af met showcase: publiceer je TaskManager API op GitHub met beschrijving, endpoints en screenshots.
