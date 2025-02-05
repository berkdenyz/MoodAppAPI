Ruh Hali Haritası Uygulaması - Proje Detayları
Projenin Amacı:
Kullanıcıların günlük ruh hallerini bir harita üzerinde paylaşmalarını sağlamak, aynı zamanda bölgesel ya da genel duygu durumlarını görselleştirmek. Kullanıcıların kendilerini ifade etmelerine yardımcı olurken, toplulukla etkileşimlerini artırmayı hedefler.

Ana Özellikler
Ruh Hali Girişi:

Kullanıcılar günün farklı saatlerinde ruh hallerini seçip haritada işaretler.
Ruh hali kategorileri (mutlu, üzgün, stresli, enerjik, vb.) ikonlar ve renklerle temsil edilir.
Kendi ruh hallerine not ekleyebilirler.
Harita Görselleştirmesi:

Haritada belirli bir bölgedeki insanların ruh hali durumları (örneğin: çoğunlukla “mutlu” veya “stresli”) görselleştirilir.
Renk tonları ve yoğunluk haritası ile ruh hali analizi.
Ruh Hali Analitiği:

Kullanıcıların geçmişteki ruh hallerini analiz edebilecekleri bir alan.
Günlük, haftalık, aylık grafikler.
Topluluk Özellikleri:

İnsanların ortak ruh halleri için öneriler (örneğin: stresli bir bölgedeki kişilere meditasyon önerisi).
Pozitif ruh halleri için teşekkür veya destek mesajları.

Sayfa Tasarımı ve Akışı
1. Ana Sayfa
Giriş: Kullanıcıları ruh hali bildirmeye teşvik eden bir açıklama ve başlatma düğmesi.
Güncel Harita Görünümü:
Bölgesel ruh halleri renk kodlarıyla görselleştirilmiş bir dünya haritası.
Üzerine tıklanan bölgede detaylı ruh hali oranları (örneğin: %60 mutlu, %20 üzgün).
Kendi Ruh Halini Paylaş Düğmesi:
Kullanıcıyı ruh hali giriş sayfasına yönlendirir.

2. Ruh Hali Girişi Sayfası
Kategori Seçimi:
İkonlar ve renklerle sunulan ruh hali seçenekleri (mutlu, üzgün, sinirli, enerjik, yorgun vb.).
Not Alanı:
Kullanıcının ruh haline dair kısa bir not ekleyebileceği alan (örneğin: “Bugün iş yoğunluğu çok fazla”).
Konum Seçimi:
Harita üzerinde otomatik konum belirleme veya manuel seçim.
Paylaş Butonu:
Kullanıcı ruh halini paylaşır ve ana haritada işaretlenir.
3. Harita ve Analitik Sayfası
Harita Görünümü:
Gerçek zamanlı ruh hali haritası.
Yoğunluk haritası (bir bölgede hangi ruh hali daha baskınsa o gösterilir).
Bölge filtreleri (şehir, ülke, dünya).
Analitik Panel:
Kullanıcının kendi ruh hali geçmişi (grafik ve tablo formatında).
Ruh hali trendleri (örneğin: “Pazartesi günleri daha stresli, hafta sonları mutlu”).
4. Topluluk Sayfası (Opsiyonel)
Destek Mesajları:
Kullanıcılar bir bölgedeki insanlara pozitif mesajlar gönderebilir.
Pozitif Paylaşımlar:
En çok mutlu ruh hali bildiren bölgelerden fotoğraf veya öneriler.
Öneriler:
Belirli ruh hallerine göre otomatik öneriler (örneğin: “Stresliyseniz şu meditasyon rehberini deneyin”).
5. Profil Sayfası (Opsiyonel)
Kullanıcının geçmiş ruh halleri, yorumları ve haritada yaptığı işaretlemeler.
Profil fotoğrafı ve kişisel hedefler ekleme alanı.

Kullanıcı Deneyimi İpuçları
Renk Psikolojisi Kullanımı:
Ruh halleri için etkileyici renkler (örneğin, mutlu için sarı, üzgün için mavi).
Basit ve Akıcı Arayüz:
Mobil cihazlarda kolay kullanımı hedefleyen bir tasarım.
Gizlilik:
Kullanıcıların haritadaki konumları anonimleştirilir, bireysel takip yapılmaz.


Teknik Detaylar:

Frontend (React Native Expo):
- UI Kütüphaneleri:
  - React Native Paper veya Native Base (UI component framework)
  - React Native Maps (harita entegrasyonu)
  - Victory Native (grafik ve analitik görselleştirme)
  - React Native Reanimated (animasyonlar)
  - Async Storage (yerel depolama)

- State Yönetimi:
  - Redux Toolkit veya Zustand
  - React Query (sunucu state yönetimi)

- Navigasyon:
  - React Navigation v6

Backend (.NET Core):
- .NET 8.0
- Entity Framework Core (Code First yaklaşımı)
- MsSql veritabanı
- Identity Framework (kimlik doğrulama)
- AutoMapper (nesne eşleştirme)
- Fluent Validation (veri doğrulama)
- Swagger/OpenAPI (API dokümantasyonu)

API Mimarisi:
- RESTful API
- Repository Pattern
- Unit of Work Pattern
- CQRS (isteğe bağlı)
- Clean Architecture

Veritabanı Şeması:
- Users
  - Id (PK)
  - Username
  - Email
  - PasswordHash
  - CreatedAt
  - LastLoginAt

- MoodEntries
  - Id (PK)
  - UserId (FK)
  - MoodType
  - Note
  - Latitude
  - Longitude
  - CreatedAt
  - UpdatedAt

- Regions
  - Id (PK)
  - Name
  - Boundaries
  - ParentRegionId (FK)

- RegionMoodStats
  - Id (PK)
  - RegionId (FK)
  - MoodType
  - Count
  - LastUpdatedAt

Güvenlik:
- JWT tabanlı kimlik doğrulama
- HTTPS/SSL
- API rate limiting
- CORS politikaları
- Veri şifreleme

Deployment:
- Frontend: 
  - App Store ve Google Play Store
  - Expo EAS Build

- Backend:
  - Azure App Service
  - Azure SQL Database
  - Azure Key Vault (hassas bilgiler için)

Monitoring ve Logging:
- Application Insights
- Serilog
- Error tracking (Sentry veya Raygun)

Performans Optimizasyonu:
- API caching (Redis)
- Image optimization
- Lazy loading
- Query optimization

CI/CD:
- GitHub Actions veya Azure DevOps
- Automated testing
- Deployment automation

Ölçeklenebilirlik:
- Horizontal scaling
- Load balancing
- Microservices (gelecek planı)

3rd Party Servisler:
- Push Notification servisi
- Geocoding API
- Weather API (opsiyonel)
- Analytics (Firebase/Google Analytics)

Test Stratejisi:
- Unit Tests (xUnit)
- Integration Tests
- E2E Tests (Detox)
- UI Tests
- Load Testing

