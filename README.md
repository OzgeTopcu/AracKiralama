# 🚗 Araç Kiralama Backend Projesi

Bu proje, N-Tier mimarisi kullanılarak geliştirilmiş bir **Araç Kiralama (Car Rental)** uygulamasının sadece **backend** kısmını içerir. Amaç; kullanıcıların araçları görüntüleyip kiralayabileceği, yöneticilerin ise araç ve kiralama işlemlerini yönetebileceği bir sistem geliştirmektir.

## 🏗️ Proje Mimarisi

Proje, klasik **N-Tier Architecture (Katmanlı Mimari)** yapısına göre yapılandırılmıştır:

- **Entities (Core Layer)**: Veri modelleri (Car, Customer, Rental vb.)
- **DataAccess (DAL)**: Veritabanı işlemleri (Entity Framework, LINQ, SQL)
- **Business (BLL)**: İş kuralları ve servisler
- **WebAPI (Presentation)**: Dış dünya ile iletişimi sağlayan API uç noktaları

## 🛠️ Kullanılan Teknolojiler

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- AutoMapper 
- FluentValidation 
- Swagger (API dokümantasyonu için)
