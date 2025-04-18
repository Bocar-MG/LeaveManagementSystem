# ManagementLeaveSystem

Backend developed with **.NET 9**, following the principles of **Clean Architecture**.  
This project provides a robust, scalable, and testable structure for modern professional applications.

---

## Table of Contents

- [Project Objectives](#project-objectives)
- [Architecture](#architecture)
- [Features](#features)
- [Project Structrues](#project-structures)
- [Prerequisites](#prerequisites)
- [Quick Start](#quick-start)
- [Docker Usage](#docker-usage)
- [API Documentation](#api-Documentation)

---

## Project Objectives

This backend was developed as a **test project for a leave request management system**.  
It follows software development best practices, including:

- Separation of concerns  
- Low coupling between components  
- Long-term maintainability

---

## Architecture

This project is based on **Clean Architecture**, with strict separation of responsibilities across layers.  
Reasons for choosing this architecture:

- It is the one I am most familiar with  
- It is one of the most widely used architectures in .NET application development  
- It has proven its effectiveness in many real-world projects  
- Its layered structure allows for independent work on each part of the application

---

## Features

- Clean Architecture implementation  
- RESTful API  
- Object mapping with AutoMapper  
- Global error handling via middleware  
- Decentralized configuration (each layer has its own `DependencyInjection` file)

---

## Project Structures
The project is divided into 5 parts
- Application
- Contracts
- Domain
- Infrastructure
- WebApi



---

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- IDE: Visual Studio 2022 / Rider / VS Code
- (Optional) SQL Server, PostgreSQL, or SQLite
- Git

---

## Quick Start

### Clone the repository
```bash
git clone https://github.com/Bocar-MG/LeaveManagementSystem.git
cd LeaveManagementSystem
dotnet restore
dotnet run --project .\ManagementSystem.WebApi

```

## Docker Usage

### Pull and run the Docker image
```bash
docker pull bocarmg/managementsystem
docker run -d -p 7001:5001 bocarmg/managementsystem

```
---

## API Documentation

This project uses **[Scalar](https://scalar.com)** for modern, interactive API documentation.

### 📘 Scalar UI (Interactive Explorer)
You can explore and test the API directly in your browser:

http://localhost:7001/scalar/v1
Scalar provides a modern, developer-friendly interface — a great alternative to Swagger.

### 🔌 REST API Base Endpoint
To interact with the API using tools like Postman or cURL:

http://localhost:7001/api/leaverequest





