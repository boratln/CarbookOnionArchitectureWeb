**CARBOOK ONION ARCHITECTURE WEB PROJESI**
___
Carbook projesi,81 farklı şehirden kullanıcıların istediği yerlere gidebilmek için araç kiralama işlemlerini yapmak için uygulanan Gerçek dünya simülasyon projesidir.Bu Web Projesinin Ana Sayfa,Hakkımızda,Blog,
İletişim vb. sayfalar mevcuttur. Bu sayfaların hepsi dinamiktir. Ve Admin panel üzerinden işlemler yaparak sayfanın verileriyle oynanabilir.  &nbsp;

**Ana Sayfa** 
![Layout1](https://github.com/user-attachments/assets/e5b99e8c-0393-4223-bf94-2b6f4c9235fb)
![Layout2](https://github.com/user-attachments/assets/a7588538-048d-460c-86f2-dd5672c15aaa)
![Layout3](https://github.com/user-attachments/assets/4fea9bac-76dd-4267-84f9-857ca8c3e173)
![Layout4](https://github.com/user-attachments/assets/5dba36c6-0745-4f99-a43a-94029b40e9b5)
![Layout5](https://github.com/user-attachments/assets/ab6d6001-40b6-461b-8654-0e3333558216)
![Layout6](https://github.com/user-attachments/assets/1a547e2e-fdd3-4d5c-821a-2995cd9ab621)
&nbsp;
**Hakkımızda Sayfası**
![About](https://github.com/user-attachments/assets/f384b121-8110-47f0-b484-10a03da8fcee)
&nbsp; **Hizmetler Sayfası**
![Services](https://github.com/user-attachments/assets/140f4324-638f-4bfb-ac85-8d06ac1b140d)
&nbsp; **Araç Fiyatları Sayfası**
![Araç Fiyatlarrı](https://github.com/user-attachments/assets/2c4d1994-3cff-44c2-af56-c4aeec6be5ed)
&nbsp; **Araçlar Sayfası**
![Car](https://github.com/user-attachments/assets/5a2d2ea9-be8a-4f90-b201-89d372fdd53e)
&nbsp; **Blog Detay Sayfası**
![BlogDetail](https://github.com/user-attachments/assets/6e5bf79f-b909-47cd-b762-64053cbd32d5)
![BlogDetail2](https://github.com/user-attachments/assets/8739a409-e136-460a-8393-388a918db4a0)
&nbsp; **İletişim Sayfası**
![Contact](https://github.com/user-attachments/assets/ada339dc-87f7-41f1-b4e7-180c49cb48f8)
&nbsp; **Admin Dashboard Sayfası** 
![Dashboard](https://github.com/user-attachments/assets/d6c5be9a-8e02-41ac-a16b-5bddb68191d3)
&nbsp; **Admin Yazar Sayfası** 
![AdminAuthor](https://github.com/user-attachments/assets/714e7faa-b245-4c7b-86f2-dab56e9faf1e)
&nbsp; **Web Api**
![Apis](https://github.com/user-attachments/assets/041e9447-004b-4beb-8cee-5c802a2e86bc)
&nbsp; **Kullanılan Teknolojiler**
___
**Backend**
___
- **C#:** Backend tarafı C# dili ile yazılmıştır.
- **MSSQL:** Veritabanı olarak Microsoft SQL Server kullanılmıştır.
- **Swagger:** API dökümantasyonu için Swagger kullanılmıştır.
- **Onion Architecture Mimarisi:** Backend tarafında Onion Architecture mimarisi kullanılmıştır.
- **CQRS:** Onion Architecture'da statik tablolar için CQRS tasarım deseni kullanılmıştır.
- **Mediator:** Onion Architecture'da işlemlerin olduğu tablolar için Mediator tasarım deseni kullanılmıştır.
- **Fluent Validation:** Validasyon işlemleri için Fluent Validation kullanılmıştır.
- **JSON Web Token:** Kullanıcının yetki işlemleri için JSON Web Token kullanılmıştır.
- **Code First Yaklaşımı:** Veritabanı tabloları Code First yaklaşımı ile oluşturulmuştur.

**Frontend**
___
- **HTML:** Sitenin temel yapısı için HTML kullanılmıştır.
- **CSS:** Sitenin stil işlemleri için CSS kullanılmıştır.
- **Bootstrap:** Hoş bir arayüz için Bootstrap kullanılmıştır.
- **JavaScript:** Sayfa etkileşimleri için JavaScript kullanılmıştır.

&nbsp;

**Proje Yapısı ve Katmanlı Mimarisi**
___
Proje aşağıdaki katmanlı mimarisi takip eder:
- **Core:** Bu katmanda Application ve Domain alt katmanları bulunur.
- **Domain:** Bu katmanda veritabanı tablosundaki Entity'ler yer alır.
- **Application:** Bu katman iş katmanıdır. Tasarım desenleri olan CQRS ve Mediator temel yapıları yer alır.
- **Infrastructure:** Bu katmanda veritabanı dosyası ve Repository'ler bulunur.
- **Presentation:** Bu katman sunum katmanıdır. Bu katmanda Web API bulunur.

