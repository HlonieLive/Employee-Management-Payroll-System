# Employee Management & Payroll System

A full-stack employee management system built with **ASP.NET Core MVC, C#, SQL Server, and Dapper**.
This project is being developed as a practical learning project to strengthen my understanding of **Dapper, SQL Server, stored procedures, database design, MVC architecture, and data access patterns**.
The goal is to build the system from the ground up rather than relying heavily on Entity Framework, allowing me to better understand what happens between the application and the database.

## Overview

The purpose of this project is to manage core employee operations while intentionally managing data access at a low level. By working directly with raw SQL queries and stored procedures via Dapper, the application focuses on predictable database performance, explicit mapping, and clean architectural boundaries.

## Key Features

* **Employee CRUD Operations:** Full management lifecycle for staff records, including creation, editing, viewing, and deletion with confirmation safeguards.
* **Direct Database Communication:** Uses Dapper to map plain C# objects to SQL queries and stored procedure results efficiently.
* **Stored Procedures & Relational Design:** Data operations run through organized database procedures to reinforce safe querying and parameter handling.
* **Clean UI:** Responsive, straightforward Razor views built with modern HTML and clean CSS layout practices.

## Tech Stack

* **Backend:** ASP.NET Core MVC (.NET 10 / C#)
* **Data Access:** Dapper (Micro-ORM), ADO.NET
* **Database:** Microsoft SQL Server, T-SQL (Stored Procedures)
* **Frontend:** Razor Views (CSHTML), Bootstrap

## Project Structure

* `EmployeeManagementPayrollSystemUI/`: Handles presentation logic, Razor views, and MVC controllers.
* `EmployeeManagementSystem.Data/`: Manages database connections, Dapper query executions, and data access repositories.
* `Models/`: Contains domain models representing core business entities such as Employee records.

## Getting Started

### Prerequisites

* .NET SDK installed on your machine
* SQL Server (LocalDB, Express, or standard instance)
* SQL Server Management Studio (SSMS) or Azure Data Studio
