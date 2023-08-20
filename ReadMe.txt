�zet Proje Geli�tirme A�amalar�:

1) Record'dan miras alan Entity ve DbContext'ten miras alan s�n�flar�n olu�turulmas�.
2) Service'ten miras alan abstract (soyut) ve concrete (somut) Service s�n�flar�n�n olu�turulmas�,
somut s�n�f i�erisinde projenin DbContext'ten miras alan s�n�f�n�n constructor'da enjekte edilmesi 
ve ihtiyaca g�re base Service abstract class'�ndaki methodlar�n override edilmesi.
3) appsettings.json ve appsetting.Development.json dosyalar�na connection string yaz�lmas�.
4) Program.cs IoC Container'da builder'�n Services'lar�na AddDbContext methodu ile projenin DbContext'ten miras
alan s�n�f�n�n connection string'i builder'�n Configuration �zelli�inin GetConnectionString methodu
�zerinden appsettings.json ve appsettings.Development.json dosyalar�nda tan�mlanan ad ile d�n�lerek eklenmesi.
5) Program.cs IoC Container'da builder'�n Services'lar�na AddScoped methodu ile proje ile ilgili servislerin
sol tarafta base abstract tipleri (soyut), sa� tarafta da base abstract tiplerinden miras alan 
concrete tipleri (somut) belirtilerek eklenmesi.
6) �lgili servislerin ilgili controller'lara base abstract tipleri kullan�larak constructor �zerinden enjekte edilmesi 
ve controller action'lar�n�n CRUD i�lemleri i�in ilgili entity'ler kullan�larak olu�turulmas�.
7) Her bir action i�in i�erisindeki model (entity) �zerinden view olu�turulmas�.
8) _Layout.cshtml'deki men�ye olu�turulan controller'lar�n Index (listeleme) action'lar� i�in link eklenmesi.

NuGet Paketleri:
1) AppCore -> Microsoft.EntityFrameworkCore.SqlServer
2) Bussiness -> Microsoft.EntityFrameworkCore.Tools

Bu Projenin Katmanlar�:
3) Uygulama Katman� (MVC, WebApi)
2) Business Katman� (Service (Repository), Entity (Model entity �zerinden geni�letilerek olu�turulacak), DbContext)
1) AppCore Katman�

Di�er �rnek Proje Katmanlar�:
4) Uygulama Katman� (MVC, WebApi)
3) Business Katman� (Service (Entity <-> Model d�n���mleri i�in), Model)
2) DataAccess Katman� (Repository, Entity, DbContext)
1) AppCore Katman�