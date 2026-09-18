<div align="center">

# Inventory Management System
### Desktop Inventory & Invoicing App

*Solo-built WPF application for tracking suppliers, stock, and invoices.*

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-0078D4?style=for-the-badge)
![EF Core](https://img.shields.io/badge/EF_Core-512BD4?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

</div>

---

## 📋 About

A desktop inventory and invoicing system built with WPF and C# — covering suppliers, stock supply, items, customers, and invoices. Built independently, with a relational data model connecting 9 entities.

## 🏗️ What I Built

- Relational schema with 9 interconnected entities (Items, Suppliers, Supplies, SupplyDetails, Stock, Customers, Invoices, InvoiceItems, Users)
- Full invoicing flow (Invoice + InvoiceItem)
- Supplier and stock-supply tracking
- Customer management
- Permission-level login system

## 🧩 Core Models

| Model | Purpose |
|---|---|
| `Item` | Products/items tracked in inventory |
| `Supplier` / `Supply` / `SupplyDetail` | Stock supply chain from suppliers |
| `Stock` | Current inventory levels |
| `Customer` | Customer records |
| `Invoice` / `InvoiceItem` | Sales invoicing |
| `User` | Login with permission levels |

## ⚙️ Tech Stack

| Layer | Technology |
|---|---|
| UI | WPF (C#) |
| ORM | Entity Framework |
| Database | SQL Server |

## 🚀 Running Locally

```bash
git clone https://github.com/HadeelZaqout/Inventory-Management-System.git
```

1. Open the solution in Visual Studio
2. Update the connection string
3. Run migrations / update database
4. Run the project

---

<div align="center">

Built solo by [Hadeel Zaqout](https://github.com/HadeelZaqout)

</div>
