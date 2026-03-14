# LetsMeetApp# LetsMeetApp

**LetsMeetApp** is a web application built with **ASP.NET Core MVC** that allows users to create, discover, and join events.  
The goal of the platform is to help people organize activities and connect with others who share similar interests.

Users can create events, join events created by others, and browse upcoming activities filtered by city.

---

## 🔑 Demo Admin Credentials

You can log in with the pre-seeded admin account:

**Email:** admin@letsmeet.com  
**Password:** Admin123!

---

## 📦 Application Overview

LetsMeetApp provides an easy way to organize and participate in events.

### Key Features

- **Create Events** – Users can create events with a title, description, date, location, and category  
- **Join Events** – Users can join events created by others  
- **Leave Events** – Participants can leave events they previously joined  
- **Event Participation** – Event creators are automatically added as participants  
- **City Filtering** – Users can filter events based on the city  
- **Past Events Section** – Expired events are automatically moved to a separate section  
- **Soft Delete** – Events are marked as deleted instead of being permanently removed  
- **Event Ownership Rules** – Only the creator of an event can edit or delete it  

---

## ⏱ Date Handling

All event dates are stored in **UTC** to ensure consistent behavior across different environments.  
Dates are converted to **local time in the UI** so users see the correct time for their location.

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

## 🚀 Main Functionalities

Users can:

- Register and log in  
- Create and manage their own events  
- Join or leave events  
- View events they are attending  
- Browse past events  
- Filter events by city  