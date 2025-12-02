# Goal Grower Savings Tracker

## Summary

Our project is a Savings Tracking App that allows users to create an account and manage multiple savings goals. Users can assign a customer name and description to each goal, set a target amount, and specify a completion date. Goals can be edited or deleted at any time. Each goal tracks associated transactions, including deposits, and withdrawals, which can also be modified or deleted. Every transaction will include a date, amount, type, and description.

If time permits, we also plan to implement reminders and notifications to help users stay on track. Reminders can have customizable frequencies to encourage consistent saving, while notifications will alert users at key milestones, such as reaching 50% of the goal or being within 10% of completion.

The target audience for the application includes anyone who wants a simple, organized way to track their savings goals and gain extra motivation to achieve them.

## Features

- Register New Account
- Sign In/Out
- Add New Savings Goal
- View Goal Details
- Edit Goal
- Delete Goal
- Add New Transaction for a Goal
- Edit Transaction
- Delete Transaction
- _Custom Reminders_
- _Custom Notifications_

_These features will be added time permitting_

Each goal will have a unique ID, name/description, currency, amount, and completion date.

When a goal is viewed, transactions will show.

Each transaction will have a unique ID, name/description, amount, and date.

## Running the Application for Developers

1. Prerequisites

   - Download .NET SDK 9.0 [https://dotnet.microsoft.com/download]
   - Download Git [https://git-scm.com/]
   - (Optional) Visual Studio 2022 or VS Code
     -Visual Studio: Workload → ASP.NET and web development
     -VS Code: Install the C# Dev Kit extension

2. Clone the Repository

   - Open a terminal or Powershell and run:
     - git clone https://github.com/ashesmsmith/GoalGrower
     - cd GoalGrower

3. Restore Dependencies

   - Download required NuGet packages
     - Run: dotnet restore

4. Add local Database

   - Run: dotnet ef database update

5. Build the Application

   - Run: dotnet build

6. Run the Application
   - Run: dotnet run

## Participants

- Ashley Smith
- Ailen Mansilla
- Phillip Mubbala
