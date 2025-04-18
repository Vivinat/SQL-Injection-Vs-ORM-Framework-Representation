# SQL Injection Vs ORM Framework Representation

This repository demonstrates the concepts of SQL Injection vulnerabilities and how ORM (Object-Relational Mapping) frameworks can mitigate such risks. It provides a comparative representation of raw SQL queries versus ORM-based approaches, showcasing their differences in terms of security, maintainability, and performance.

## Features

- **SQL Injection Demonstration**: 
  - Examples of how SQL Injection vulnerabilities can occur when using raw SQL queries.
  - Simulated attack scenarios to highlight potential risks.

- **ORM Framework Representation**: 
  - Implementation of secure database operations using an ORM framework.
  - Demonstrates how ORM frameworks prevent SQL Injection vulnerabilities by using parameterized queries and abstractions.

- **Web Application Interface**: 
  - Built with a combination of C#, HTML, CSS, and JavaScript to provide a user-friendly interface for interacting with the database.
  - Includes forms and inputs for simulating database queries.

- **Docker Support**: 
  - Includes a `Dockerfile` for easy containerization and deployment of the application.

## Technology Stack

- **Backend**: C# (ASP.NET Core)
- **Frontend**: HTML, CSS, JavaScript
- **Database**: SQL Server
- **Containerization**: Docker

## How It Works

### Raw SQL Queries
- Demonstrates the use of raw SQL queries in a database interaction scenario.
- Highlights how improper input handling can lead to SQL Injection attacks.

### ORM Framework
- Uses an ORM (e.g., Entity Framework) to perform the same operations as raw SQL queries.
- Ensures security by using parameterized queries and escaping input automatically.

### User Interface
- A web-based interface allows users to interact with the application.
- Users can input data, which is processed either through raw SQL or an ORM framework, to observe the differences in behavior.

### Comparative Analysis
- Provides logs and visual feedback to show the risks and benefits of each approach.
- Helps developers understand the importance of secure coding practices.

### Prerequisites
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://www.docker.com/) (optional, for containerized deployment)
- SQL Server instance
