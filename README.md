# OData Challenge

OData servislerinde birden fazla resource kullanımını amaçlayan örnek uygulama. Senaryoda Kategoriler, Ürünler ve Siparişlerin tutulduğu ilkel bir senaryo söz konusu. Bu senaryoda amaç aşağıdaki gibi sorguların OData hizmeti olarak REST tabanlı bir servis üzerinden sunulabileceğini göstermektir.

- Elektronik kategorisindeki ürünlerin listelenmesi /Products?$filter=Category eq 'Elektronik'
- 1001 numaralı ürüne ait kategori bilgisinin çekilmesi /Products(1001)/Category
- 1 Numaralı kategoriye bağlı ürünler /Categories(1)/Products
- ...

## Ön Hazırlıklar

Bu örnekte SQL Server veritabanı kullanılmakta. Onu bir docker imaj olarak kullanabiliriz. Diğer yandan kod tarafından veritabanı nesnelerinin oluşturulması (migration) için de Entity Framework komut satırı aracından yararlanılmakta. Gerekli hazırlıkları aşağıdaki gibi yapabiliriz.

```bash
# SQL docker örneğini başlatmak için (Şifreyi siz istediğiniz gibi verebilir veya aynısını kullanabilirsiniz)
sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=tig@r76!" -p 1434:1433 --name sql-south --hostname sql-south -d mcr.microsoft.com/mssql/server:2022-latest

# Migration için EF tool'a ihtiyacımız olacaktır
dotnet tool install -g dotnet-ef

# Bu komutları MusicLibrary.Data klasörü içerisindeyken çalıştırabiliriz.
dotnet ef migrations add Intial --startup-project ../SouthWind.Service
dotnet ef database update --startup-project ..//SouthWind.Service
```
