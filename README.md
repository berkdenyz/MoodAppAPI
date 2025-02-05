# 🌍 Mood Map API - Backend Project  

## 📌 Project Overview  
Mood Map API is a **.NET Core-based backend service** that enables users to share their daily moods on a map, analyze regional and global emotional trends, and interact with a community. The API provides secure authentication, real-time mood tracking, and analytics.  

---

## 🎯 Features  

### 📝 Mood Entry  
- Users can submit their **mood type** (e.g., Happy, Sad, Stressed, Energetic) with **notes**.  
- Each mood entry is stored with **geolocation (latitude & longitude)**.  
- Users can edit or delete their past entries.  

### 🗺️ Map Visualization  
- Aggregates mood entries into **regional statistics**.  
- Provides **real-time data** for mood heatmaps.  
- Supports **geographical filtering** by country, city, or region.  

### 📊 Mood Analytics  
- Tracks **historical mood trends** for individual users and global data.  
- Generates **daily, weekly, and monthly** mood reports.  
- API endpoints for **chart visualization** in frontend applications.  

### 👥 Community Features  
- Users can send **positive messages** to encourage others.  
- System provides **personalized mood-based recommendations** (e.g., meditation tips for stressed users).  
- Users receive **support messages** based on collective moods in a region.  

---

## ⚙️ Tech Stack  

### **Backend (.NET Core 8.0)**  
🔹 **Core Technologies:**  
- **ASP.NET Core Web API**  
- **Entity Framework Core (Code First Approach)**  
- **Microsoft SQL Server**  

🔹 **Authentication & Security:**  
- **Identity Framework** (JWT-based authentication)  
- **HTTPS & SSL encryption**  
- **API Rate Limiting & CORS Policies**  
- **Data Encryption (Sensitive User Data)**  

🔹 **API Design Patterns:**  
- **RESTful API**  
- **Repository Pattern**  
- **Unit of Work Pattern**  
- **CQRS (optional)**  
- **Clean Architecture**  

🔹 **Documentation & Monitoring:**  
- **Swagger / OpenAPI** (API documentation)  
- **Serilog & Application Insights** (logging & monitoring)  
- **Error tracking (Sentry or Raygun)**  

🔹 **Performance Optimization:**  
- **Caching (Redis)**  
- **Lazy Loading & Query Optimization**  
- **Load Balancing & Horizontal Scaling**  

🔹 **Deployment & DevOps:**  
- **Azure App Service** (Backend hosting)  
- **Azure SQL Database** (Database storage)  
- **Azure Key Vault** (Sensitive data management)  
- **CI/CD Pipelines** (GitHub Actions or Azure DevOps)  

---

## 📂 Database Schema  

### **Users Table**  
| Column        | Type         | Description |
|--------------|------------|-------------|
| Id           | GUID (PK)  | Unique identifier |
| Username     | String     | User's name |
| Email        | String     | Email (unique) |
| PasswordHash | String     | Encrypted password |
| CreatedAt    | DateTime   | Account creation date |
| LastLoginAt  | DateTime   | Last login timestamp |

### **MoodEntries Table**  
| Column       | Type         | Description |
|-------------|------------|-------------|
| Id          | GUID (PK)  | Unique entry identifier |
| UserId      | GUID (FK)  | References Users table |
| MoodType    | Enum       | Mood category (Happy, Sad, etc.) |
| Note        | String     | User's personal note |
| Latitude    | Float      | Geolocation (lat) |
| Longitude   | Float      | Geolocation (long) |
| CreatedAt   | DateTime   | Entry timestamp |
| UpdatedAt   | DateTime   | Last update timestamp |

### **Regions Table**  
| Column        | Type         | Description |
|--------------|------------|-------------|
| Id           | GUID (PK)  | Unique identifier |
| Name         | String     | Region name |
| Boundaries   | Geometry   | Geographical area |
| ParentRegionId | GUID (FK) | Reference to a larger region |

### **RegionMoodStats Table**  
| Column        | Type         | Description |
|--------------|------------|-------------|
| Id           | GUID (PK)  | Unique identifier |
| RegionId     | GUID (FK)  | References Regions table |
| MoodType     | Enum       | Mood category |
| Count        | Int        | Total count of mood entries |
| LastUpdatedAt | DateTime   | Timestamp of last update |

---

## 🔒 Security Features  

✅ **JWT-based authentication** for secure user login.  
✅ **Role-based access control (RBAC)** to limit user permissions.  
✅ **Data encryption** for sensitive user information.  
✅ **Rate limiting** to prevent API abuse.  
✅ **CORS policies** for controlled API access.  
