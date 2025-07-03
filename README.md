# 🚗✨ **Vehicle Management System**

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Build](https://img.shields.io/badge/build-passing-brightgreen)
![Platform](https://img.shields.io/badge/platform-.NET%20Core%207.0-blueviolet)
![Status](https://img.shields.io/badge/status-active-success)

---

## 🎥 **Live Preview**

> ✅ **Check out the project in action!**

https://github.com/user-attachments/assets/77455508-00ff-49a8-b54c-95f447b48f18



---

## 📌 **Overview**

**Vehicle Management System** is a **role-based fleet management web application** built with **ASP.NET Core MVC**, **C#**, and **Entity Framework Core**.  
It enables **Admins** to manage vehicles and maintenance tasks, while **Users** can view vehicle details and access dashboards tailored to their roles.

---

## 🎯 **Key Features**

- ✅ **Role-based Registration & Login** (Admin & User)
- ✅ **Dedicated Dashboards** for each role
- ✅ **CRUD Operations** for Vehicles & Maintenance
- ✅ RESTful **Web API** with JSON responses
- ✅ API consumption using **JavaScript**, **AJAX**, and **HttpClient**
- ✅ **Session Management** with TempData & ViewData
- ✅ Secure Authentication with **ASP.NET Identity**
- ✅ Built using **Core C# Concepts**:  
  Classes, Interfaces, Inheritance, LINQ, Exception Handling

---

## 👥 **Team Members**

| 👤 **Name** | 🛠️ **Role** |
|----------------|-----------------|
| **Rahul Patil** | Backend Developer |
| **Shruti Patil** | Frontend Developer |

---

## ⚙️ **Tech Stack**

| Technology | Badge |
|------------|-------|
| **C#** | ![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white&style=flat) |
| **ASP.NET Core** | ![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?logo=dotnet&logoColor=white) |
| **Entity Framework Core** | ![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-green) |
| **SQL Server** | ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoft-sql-server&logoColor=white) |
| **Visual Studio** | ![Visual Studio](https://img.shields.io/badge/IDE-Visual%20Studio-5C2D91?logo=visual-studio&logoColor=white) |
| **Postman** | ![Postman](https://img.shields.io/badge/API%20Testing-Postman-orange?logo=postman) |

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

## 🧩 **C# Concepts Implemented**

- ✅ **Classes & Objects** (`User`, `Vehicle`)
- ✅ **Inheritance**, **Interfaces**, **Abstraction**
- ✅ **Exception Handling** (`try-catch`)
- ✅ **Collections**, **Generics**, **LINQ Queries**
- ✅ **ASP.NET Core Identity** for Secure Auth

---

## 📸 **Screenshots**

| ![](https://github.com/user-attachments/assets/9c914311-4473-498d-94ea-1d1445306269) | ![](https://github.com/user-attachments/assets/4bf2c439-459e-48c3-b466-75bc64973642) |
|:--:|:--:|
| ![](https://github.com/user-attachments/assets/a5ff7680-b070-4c12-9e93-7a87becc17c1) | ![](https://github.com/user-attachments/assets/c9ee51af-4de9-4d63-812f-5bc9cbb7655d) |
| ![](https://github.com/user-attachments/assets/7bb48747-7f86-40a3-b4e5-01eff005d99d) | ![](https://github.com/user-attachments/assets/21504f54-9842-4edf-ac23-649558513303) |
| ![](https://github.com/user-attachments/assets/7da51b29-81be-4a41-92a5-416e6ceb2060) | ![](https://github.com/user-attachments/assets/7b990763-1c42-423b-a2ee-87aaace8f121) |
| ![](https://github.com/user-attachments/assets/1630f5aa-3bf7-4106-bf7d-952bf41f7d33) | |

---

## 📄 **License**

This project is licensed under the **MIT License** —  
> **🔒 For educational purposes only.**

---

## 💙 **Special Thanks**

- 🏆 **Microsoft Docs**
- 🧩 **ASP.NET Core Community**
- 🛠️ **Visual Studio Code Samples**

---

## 🚀 **Happy Coding!**

> ⭐ If you like this project, don’t forget to **star ⭐ the repo** — it motivates us to build more!  

