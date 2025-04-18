# 🛠️ NomDuProjet.Backend

Backend développé en **.NET 9** basé sur les principes de **Clean Architecture**.  
Ce projet propose une structure robuste, évolutive et testable pour des applications professionnelles modernes.

---

## 📚 Sommaire

- [🧭 Objectifs du projet](#-objectifs-du-projet)
- [🏗️ Architecture](#-architecture)
- [🚀 Fonctionnalités](#-fonctionnalités)
- [⚙️ Prérequis](#-prérequis)
- [▶️ Démarrage rapide](#️-démarrage-rapide)
- [📂 Structure du projet](#-structure-du-projet)
- [🧪 Tests](#-tests)
- [📦 Technologies](#-technologies)
- [📈 API Documentation](#-api-documentation)
- [🔐 Sécurité](#-sécurité)
- [🛣️ Roadmap](#-roadmap)
- [🙋 Contribution](#-contribution)
- [📄 Licence](#-licence)

---

##  Objectifs du projet

Ce backend a été conçu pour **Pour un test d'un systéme basé sur le demande de congé**.  
Il respecte les bonnes pratiques de développement logiciel, notamment :
- Séparation des responsabilités
- Couplage faible entre les composants
- Maintenabilité à long terme

---

##  Architecture

Ce projet suit les principes de la **Clean Architecture** avec une stricte séparation des responsabilités entre les couches.
j'ai choisi cette architecture car :
- C'est l'architecture que je connais le plus
- C'est parmi les architectures les plus utilisés coté developpement logiciel surtout avec .NET
- Il a deja fais ses preuves sur de nombreux projets
- Et comme cité ci-haut c'est une architecture basé sur des couches ce qui permet de travailler individuellemnt sur chaque projet appart


---

## Fonctionnalités

 Architecture Clean Architecture  
 API REST  
 Mapping  
 Middleware d’erreurs globales  
 Configuration decentralisé(pour chaque couches son propre fichier DependencyInjection)

---

## Prérequis

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- IDE : Visual Studio 2022 / Rider / VS Code
- (Optionnel) Serveur SQL : SQL Server, PostgreSQL, SQLite...
- Git

---

## ▶️ Démarrage rapide

### 🔁 Cloner le projet

git clone https://github.com/Bocar-MG/LeaveManagementSystem.git
cd LeaveManagementSystem
dotnet restore
dotnet run --project .\ManagementSystem.WebApi



