# 🚗✨ Vehicle Management System

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Build](https://img.shields.io/badge/build-passing-brightgreen)
![Platform](https://img.shields.io/badge/platform-.NET%20Core%207.0-blueviolet)
![Status](https://img.shields.io/badge/status-active-success)

---

## 📸 Live Preview

<video src="https://github.com/RahulPatil-Tech/Vehical_Management/releases/download/v1.0/Demo.-.Made.with.Clipchamp.mp4" width="640" controls></video>


---

## 📌 Overview

**Vehicle Management System** is a role-based fleet management web app built using **ASP.NET Core MVC**, **C#**, and **Entity Framework Core**.  
It enables admins to manage vehicles and maintenance schedules, while users can view details and dashboards tailored to their role.

---

## 🎯 Features

✅ Role-based **Registration & Login** (Admin, User)  
✅ Separate **Dashboards** for Admin and User  
✅ **CRUD operations** for Vehicles & Maintenance  
✅ RESTful **Web API** with JSON responses  
✅ Consumes API using **JavaScript/AJAX/HttpClient**  
✅ **Session Management**, TempData/ViewData  
✅ Secure authentication using **ASP.NET Identity**  
✅ Built with **Core C# Concepts**: Classes, Interfaces, Inheritance, LINQ, Exception Handling

---

## 👥 Team Members

| Name | Role |
|------|------|
| **Rahul Patil** | Backend-End Developer|
| **Shruti Patil** | Front Developer |

---

## ⚙️ Tech Stack

- ![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white&style=flat)
- ![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?logo=dotnet&logoColor=white)
- ![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-green)
- ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoft-sql-server&logoColor=white)
- ![Visual Studio](https://img.shields.io/badge/IDE-Visual%20Studio-5C2D91?logo=visual-studio&logoColor=white)
- ![Postman](https://img.shields.io/badge/API%20Testing-Postman-orange?logo=postman)

---

## 🗂️ Project Structure

```
Vehicle_Management/
│
├── Controllers/
│   ├── AccountController.cs
│   ├── AdminController.cs
│   ├── HomeController.cs
│   ├── VehicleApiController.cs
│
├── Data/
│   ├── ApplicationDbContext.cs
│
├── Models/
│   ├── ErrorViewModel.cs
│   ├── LoginViewModel.cs
│   ├── RegisterViewModel.cs
│   ├── User.cs
│   ├── Vehicle.cs
│
├── Views/
│   ├── Account/
│   │   ├── Login.cshtml
│   │   ├── Register.cshtml
│   │
│   ├── Admin/
│   │   ├── AddVehicle.cshtml
│   │   ├── AdminIndex.cshtml
│   │   ├── CreateVehicle.cshtml
│   │   ├── DeleteVehicle.cshtml
│   │   ├── EditVehicle.cshtml
│   │
│   ├── Home/
│   │   ├── Index.cshtml
│   │   ├── Privacy.cshtml
│   │
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   ├── _ValidationScriptsPartial.cshtml
│   │   ├── Error.cshtml
│   │
│   ├── Vehicle/
│       ├── AddMaintenance.cshtml
│       ├── AdminIndex.cshtml
│       ├── Delete.cshtml
│       ├── Details.cshtml
│       ├── Edit.cshtml
│       ├── UserDashboard.cshtml
│
├── appsettings.json
├── MYSQL_COMMANDS.txt
├── Program.cs
```

---

## 🗝️ User Roles

| Role | Description |
|------|--------------|
| **Admin** | Manage vehicles, maintenance, and view all records |
| **User** | View vehicles, check details, and access personalized dashboard |

---

## 🚀 Getting Started

**1️⃣ Clone the Repository**

```
git clone https://github.com/RahulPatil-Tech/Vehicle_Management.git
```

**2️⃣ Open in Visual Studio**
```
Open the `.sln` file.
```

**3️⃣ Configure Database**
- Update `appsettings.json` with your connection string.
- Apply Entity Framework migrations:
```
dotnet ef migrations add InitialCreate  
dotnet ef database update
```

**4️⃣ Run the Application**

```
dotnet run
```

---

## 🔗 REST API Endpoints

| Method | Endpoint | Description |
|--------|-----------|--------------|
| **GET** | `/api/vehicles` | Get all vehicles |
| **POST** | `/api/vehicles` | Add a new vehicle |

---

## 🧩 C# Concepts Implemented

- ✅ Classes & Objects (`User`, `Vehicle`)
- ✅ Inheritance / Interfaces / Abstraction
- ✅ Exception Handling (try-catch)
- ✅ Collections, Generics, LINQ Queries
- ✅ ASP.NET Core Identity for Auth

---

## 📸 Screenshots

Add screenshots or replace the animation above with your real screen recording!

---

## 📝 License

This project is for educational purposes only.

---

## 💙 Special Thanks

- Microsoft Docs  
- ASP.NET Core Community  
- Visual Studio Code Samples

---

🚀 **Happy Coding!**

