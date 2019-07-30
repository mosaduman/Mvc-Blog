# Özet
Asp.Net Mvc ve Entity Framework kullanılarak yapılan bir blog sitesidir.<br>
Blog sitesinde yapılabilen işlemler:<br>
 - Kullanıcı girişi
 - Üye olma
 - Yayınlanan makaleye yorum ve beğeni yapma
 - Yazar takip etme
 - Sadece takip ettiğin yazarların makalelerini görebilme
 - Kategorilere göre makale listeleme
 - Popüler Makaleler listesi
Blog Sitesinde üye,yazar ve admin kullanıcı rolleri vardır.
kullanıcı rollerini sırayla açıklayalım.<br>
1. Üye
    - Yazar takip eder.
    - Makale beğenir.
    - Makaleye yorum yapar.
2. Yazar
    - Makale Ekleme,Silme,Güncelleme işlemlerini yapar
    - Üyenin sahip olduğu tüm özelliklere sahiptir.
3. Admin
    - üyenin,yazarın hesabını pasif edebilme(silme).
    - Kategori Ekleme,Silme,Güncelleme işlemlerini yapar.
    - Yazar ve üyenin sahip olduğu tüm özelliklere sahiptir.
    
# Veritabanı Diagramı
![Veritabanı Diyagram](https://github.com/mosaduman/Mvc-Blog/blob/master/g%C3%B6r%C3%BCnt%C3%BCler/veritabaniDiyagram.png?raw=true)
# Blog Sitesinden Görüntüler
![Anasayfa](https://github.com/mosaduman/Mvc-Blog/blob/master/g%C3%B6r%C3%BCnt%C3%BCler/yakin.PNG)

![Anasayfa](https://github.com/mosaduman/Mvc-Blog/blob/master/g%C3%B6r%C3%BCnt%C3%BCler/anasayfa.png?raw=true)
![Makale Detay](https://github.com/mosaduman/Mvc-Blog/blob/master/g%C3%B6r%C3%BCnt%C3%BCler/makaledetay.PNG)
# Projeyi Çalıştırma
1. Projeyi indirip microsoft visual studio 2012 ve üzeri bir sürümle açın.
2. Web.Config dosyasındaki ConnectionString alanından kendi veritabanı yolunuzu verin.
3. MvcBlogSitem projesini publish ettiğinizde ConnectionString alanında belirttiğiniz kodlara göre bir veritabanı oluşturulacaktır.
veritabanındaki tablolara birkaç kayıt ekledikten sonra projeyi tekrar çalıştırın.Blog sitesinin giiriş yap bölümünden veritanında oluşturduğunuz kullanıcı tabloasundaki kayıtlara göre kullanıcı adı ve şifrenizi girerek blog sitesini istediğiniz gibi kullanın.
