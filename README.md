# BookStore-Api

Book Store API ; kitap,kitap tür , yazar işlemleri hakkında crud işlemlerini,validasyon kontrollerini ve ilişkisel tabanlı bir modelleme işlenerek oluşturulmuş bir API projesidir.

**PROJEDE KULLANILAN TEKNOLOJİLER **
 - [x] Entity Framework Core
 - [x] AutoMapper
 - [x] Fluent Validation
 - [x] Middleware
 - [x] .NET Core DI Container (Services) / Dependency Injection
 - [x] Test Driven Development
 - [x] Kimlik Doğrulama ve Yetkilendirme Protokolleri (JwtBearer)
 - [x] Entity Framework Core InMemory

**PROJEDE KULLANILAN TEKNOLOJİLER HAKKINDA DETAYLI BİLGİ **
 - Entity Framework Core Nedir ?
 
 Entity Framework Core bir ORM aracıdır. Yazılım geliştirenler için database üzerinde yer alan verilere erişim sağlama, verileri depolama gibi işlemleri 
 yapabilmemizi sağlayan bir ADO.NET mekanizmasıdır.
 
- AutoMapper Nedir ?

Automapper farklı tipteki complex objeleri birbirlerine otomatik olarak dönüştüren kütüphanedir. Kod kirliliğinde bizi kurtarak birden fazla satırda her 
bir obje elemanını tek tek dönüştürmek yerine tek satırda objenin kendisini dönüştürmemize olanak sağlar.

- Fluent Validation Nedir ?

FluentValidation bir veri doğrulama kütüphanesidir. Yani verilerimizi oluştururken doğru bir kontrolün sağlanması için konulan kısıtlanmış kuralları uygulamayı sağlar.

- Middleware(Ara Uygulama) Nedir ?

Uygulamalar veya katmanlar arasındaki tekrar eden görevleri gerçekleştirmek amacıyla kullanılan ara yazılım.Örneğin BookStore projesinde request 
ve response işlemleri sürekli tekrar edilen ve try-catch kontrolü ile sağlanan bir kodlama işlemi yapıldı.

- Dependency Injection Nedir ?

Bağımlılıkları bir sınıf içerisinde yönetmek yerine dışarıdan yönetilmesini sağlamak . Constructor (Yapıcı Method) : Bağımlı olunan nesnelerin yapıcı metotta 
verilir ve dışarıdan beklenir.Setter Method/Property ile : Bu yöntemde bağımlı olunan nesneler bir method/property aracılığı ile dışardan beklenir. 
Metot ile : Bu yöntemde bağımlı olunan nesneler yalnızca kullanıldığı methodlarda dışarıdan beklenir.

- Kimlik Doğrulama ve Yetkilendirme Protokolleri (JwtBearer)

İstemci bir istekte bulunabilmek için kendi bilgilerini kaydeder ve bir token talebi oluşturulur.Token ( json web token) kimlik doğrulama/kimlik yetkilendirme 
için oluşturulan şifreli bir karakter dizinidir.Bu dizin gelen kullanıcıyı temsil eder ve süre bazlı işlem başlar.Refresh token ise verilen tokenın süresinin bitmesi 
fakat kullanıcının hala işlemlerine devam etmesi sürecine bağlı olarak ekstra verilen süreyi ifade eder.Peki bu işlem nasıl gerçekleşiyor ? Kullanıcıya ilk zamanda oluşturulan 
access token ile aynı zamanda refresh tokenda verilir.Kullanıcı bu refresh token ile işlemlerine devam edebilir.Böylelikle yeniden login işlemine gerek kalmaz.


![Ekran Alıntısı](https://user-images.githubusercontent.com/63001162/156026083-4c3efdfc-d36d-4efe-b355-bbaaff33f6f2.PNG)





