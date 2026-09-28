# College Library Book Issue System 📚

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-10.0-purple.svg)](https://dotnet.microsoft.com/)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-blue.svg)](https://getbootstrap.com/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

An **ASP.NET Core MVC** web application developed for managing the issuance of books to students in a college library. This project demonstrates core MVC architecture, C# extension methods, nullable types, Razor views with Tag Helpers, Bootstrap styling, and input data validation.

---

## 🚀 Key Features

- **MVC Architecture**: Clean separation of Model data, Controller logic, and Razor Views.
- **Model Classes**:
  - `Book`: Contains `BookId`, `Title`, `Author`, `Category`, `Price`, and `AvailableCopies`.
  - `LibraryMember`: Contains `MemberId`, `MemberName`, `Department`, `Email`, `BookId`, `IssueDate`, and a **nullable** `ReturnDate?`.
- **C# Extension Methods (`LibraryExtensions.cs`)**:
  - `GetDueStatus()`: Evaluates return date and flags status as **Returned**, **Due Soon**, **Overdue**, or **Issued**.
  - `CalculateFine()`: Calculates overdue fines automatically at **₹10 per overdue day**.
- **Book Issue Form (`IssueBook.cshtml`)**:
  - Interactive Bootstrap form powered by ASP.NET Core Tag Helpers (`asp-for`, `asp-action`, `asp-controller`).
  - Input field validation using Data Annotations (`[Required]`, `[EmailAddress]`).
- **Issued Books Directory (`Index.cshtml`)**:
  - Bootstrap HTML table rendering issued books, return dates, status badges, and calculated fine amounts.
  - Quick action links for **Book Details** and marking books as **Returned**.
- **Detailed View & Conditional Alerts (`BookDetails.cshtml`)**:
  - Displays complete information for selected student issue records.
  - Renders conditional Bootstrap messages:
    - 🟢 **Success alert** when a book is returned.
    - 🟡 **Warning alert** when a book is due soon.
    - 🔴 **Danger alert** with calculated fine when a book is overdue.
- **Library Information (`About.cshtml`)**:
  - Overview of the system, library catalog metrics, and quick navigation links.

---

## 📁 Project Structure

```text
LibraryManagementMVC
│
├── Controllers
│   └── LibraryController.cs        # Handles routing, book issuance, & details
│
├── Models
│   ├── Book.cs                     # Book entity model
│   └── LibraryMember.cs            # Library Member / Book Issue record model
│
├── Extensions
│   └── LibraryExtensions.cs        # GetDueStatus() & CalculateFine() extension methods
│
├── Views
│   ├── Library
│   │   ├── Index.cshtml            # Table of issued books
│   │   ├── IssueBook.cshtml        # Form to issue new books
│   │   ├── BookDetails.cshtml      # Detailed view with conditional alerts
│   │   └── About.cshtml            # System information page
│   └── Shared
│       └── _Layout.cshtml          # Navigation header & main template layout
│
├── wwwroot                         # Static assets (Bootstrap, CSS, JS)
├── GlobalUsings.cs                 # Global using directives
├── Program.cs                      # App entry point & route configuration
├── Properties
│   └── launchSettings.json         # Configured for HTTP:5000 & HTTPS:5001
└── .gitignore                      # Git version control ignore rules
```

---

## ⚙️ Prerequisites & Installation

### Requirements
- [.NET SDK 8.0 / 9.0 / 10.0](https://dotnet.microsoft.com/download)

### Getting Started

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/nikhilesh-927/Library-Management-System-DotNet-Project
   cd College-Library-Book-Issue-System-Project-using-ASP.NET-Core-MVC-web-application
   ```

2. **Build the Application**:
   ```bash
   dotnet build
   ```

3. **Run the Application**:
   ```bash
   dotnet run
   ```

4. **Access in Browser**:
   - **HTTP**: [http://localhost:5000](http://localhost:5000)
   - **HTTPS**: [https://localhost:5001](https://localhost:5001)

---

## 🛠️ Built With

- **Framework**: ASP.NET Core MVC (.NET 10)
- **Language**: C# 13
- **Frontend**: HTML5, Razor, Bootstrap 5, Bootstrap Icons
- **Version Control**: Git & GitHub

---

