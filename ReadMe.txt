Özet Proje Geliþtirme Aþamalarý:

1) Record'dan miras alan Entity ve DbContext'ten miras alan sýnýflarýn oluþturulmasý.
2) Service'ten miras alan abstract (soyut) ve concrete (somut) Service sýnýflarýnýn oluþturulmasý,
somut sýnýf içerisinde projenin DbContext'ten miras alan sýnýfýnýn constructor'da enjekte edilmesi 
ve ihtiyaca göre base Service abstract class'ýndaki methodlarýn override edilmesi.
3) appsettings.json ve appsetting.Development.json dosyalarýna connection string yazýlmasý.
4) Program.cs IoC Container'da builder'ýn Services'larýna AddDbContext methodu ile projenin DbContext'ten miras
alan sýnýfýnýn connection string'i builder'ýn Configuration özelliðinin GetConnectionString methodu
üzerinden appsettings.json ve appsettings.Development.json dosyalarýnda tanýmlanan ad ile dönülerek eklenmesi.
5) Program.cs IoC Container'da builder'ýn Services'larýna AddScoped methodu ile proje ile ilgili servislerin
sol tarafta base abstract tipleri (soyut), sað tarafta da base abstract tiplerinden miras alan 
concrete tipleri (somut) belirtilerek eklenmesi.
6) Ýlgili servislerin ilgili controller'lara base abstract tipleri kullanýlarak constructor üzerinden enjekte edilmesi 
ve controller action'larýnýn CRUD iþlemleri için ilgili entity'ler kullanýlarak oluþturulmasý.
7) Her bir action için içerisindeki model (entity) üzerinden view oluþturulmasý.
8) _Layout.cshtml'deki menüye oluþturulan controller'larýn Index (listeleme) action'larý için link eklenmesi.

NuGet Paketleri:
1) AppCore -> Microsoft.EntityFrameworkCore.SqlServer
2) Bussiness -> Microsoft.EntityFrameworkCore.Tools

Bu Projenin Katmanlarý:
3) Uygulama Katmaný (MVC, WebApi)
2) Business Katmaný (Service (Repository), Entity (Model entity üzerinden geniþletilerek oluþturulacak), DbContext)
1) AppCore Katmaný

Diðer Örnek Proje Katmanlarý:
4) Uygulama Katmaný (MVC, WebApi)
3) Business Katmaný (Service (Entity <-> Model dönüþümleri için), Model)
2) DataAccess Katmaný (Repository, Entity, DbContext)
1) AppCore Katmaný