# LetsMeetApp

**LetsMeetApp** is a web application built with **ASP.NET Core MVC** that allows users to create, discover, and join events.  
The goal of the platform is to help people organize activities and connect with others who share similar interests.

Users can create events, join events created by others, and browse upcoming activities filtered by city.

---

## 🔑 Demo Admin Credentials

You can log in with the pre-seeded admin account:

**Email:** admin@letsmeet.com  
**Password:** Admin123!

> **Note:** The admin account comes with **two demo events** that are dynamically seeded in the system.  
> These events appear in the **Events I'm Attending** section for the admin user.

---

## 📦 Application Overview

LetsMeetApp provides an easy way to organize and participate in events.

### Key Features

- **Create Events** – Users can create events with a title, description, date, location, and category  
- **Join Events** – Users can join events created by others  
- **Leave Events** – Participants can leave events they previously joined  
- **Event Participation** – Event creators are automatically added as participants  
- **City Filtering** – Users can filter events in their city  
- **Past Events Section** – Expired events are automatically moved to a separate section  
- **Soft Delete** – Events are marked as deleted instead of being permanently removed  
- **Event Ownership Rules** – Only the creator of an event can edit or delete it  

---

## 🗂 Event Sections

The application separates events into two main sections:

### **Events I'm Attending**

This section contains:

- Events the user has **created**
- Events the user has **joined**

Event creators are automatically added as participants, so their own events appear in this section as well.

### **Discover Events**

This section displays:

- Events created by **other users**
- Events the current user **is not participating in**

This allows users to easily find new events they can join.

---

## ⏱ Date Handling

All event dates are stored in **UTC** to ensure consistent behavior across different environments.  
Currently, dates are displayed based on the **server's local timezone**, not the user's local timezone.

---

## 🧰 Tech Stack

- **ASP.NET Core MVC** – Web application framework  
- **Entity Framework Core** – ORM for database access  
- **SQL Server** – Database  
- **ASP.NET Identity** – Authentication and user management  
- **Razor Views** – Server-side rendering  
- **Bootstrap 5** – Responsive UI styling  

---

## 🧱 Application Structure

The application follows a **service-based architecture** to separate concerns:

- **Controllers** – Handle HTTP requests  
- **Services** – Contain business logic  
- **Data Layer** – Entity Framework Core models and configurations  
- **ViewModels** – Used for data transfer between controllers and views  

---

## ⚙ Database Setup

The application uses **SQL Server**.

Before running the project, update the connection string in:

appsettings.json

Modify the `DefaultConnection` value so it points to your local SQL Server instance.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=LetsMeetAppDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

## 🔄 Database Migrations

- Database migrations are **applied automatically** when the application starts.  
- If the database does not exist, it will be **created automatically**, and all migrations will be applied.  
- This ensures the database schema is always **up to date** without requiring manual migration commands.  
