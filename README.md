
# MongoDB 

Repository'de Mssql ve MongoDb databaseleri kullanılarak ikisi arasında ki performance farkı
gözlemlenmeye çalışılmıştır. Mssql veri tabanı ile çalışılırken iki farklı ORM aracı kullanılmıştır. 
Bunlar; Dapper ve Entity Framework'tür. Bundan dolayı ikisi arasında ki performance farkı da 
gözlemlenebilmektedir. 

MongoDb ve Mssql databaselere 1.000.000 kayıt eklenilmiştir ve bu kayıtlar üzerinden 
yapılan sorgurlar ile karşılaştırma yapılmıştır. **Daha fazla data sayısında 
veya daha az data sayısında farklılık göstereceği gibi bilgisayarın o zaman ki performansına 
göre de farklılıklar gösterebilir sonuçlar.**

Grafik gösterimine geçmeden önce NoSQL ve MongoDB den kısaca bahsedelim.

**NoSQL** terimi, ilişkisel olmayan veritabanı türlerini ifade eder ve bu veritabanları, verileri ilişkisel tablolardan farklı bir formatta depolar. Bununla birlikte, NoSQL veritabanları deyimsel dil API'leri, bildirime dayalı yapılandırılmış sorgu dilleri ve örneğe göre sorgulamaya göre örnek diller kullanılarak sorgulanabilir; bu nedenle bunlara "NoSQL" veritabanları da denir.

**MongoDB** 2009 yılında geliştirilmiş açık kaynak kodlu bir
NoSQL veritabanıdır. MongoDB’de her kayıt bir doküman olarak ifade edilir. Ve bu dökümanlar 
json formatı şeklinde saklanır. Daha önce ilişkisel veritabanlarıyla ilgilenenlerin
bildiği table yapısını burada collection, row yapısını document, column yapısını ise
field alır.

Grafikler'de ki süreler milisaniye cinsindendir.

Aşağıda ki grafik te bütün dataları çekme sürelerini Entity Framework, Dapper ve de MongoDB
için görebilirsiniz.(1.000.000 data vardır.) Bütün durumlar için toplam on defa deneme yapılmıştır. 


![Getall](https://github.com/guvenbaris/MongoDb/blob/master/image/getall.png?raw=true)


Databaseler de id ye göre kayıt arama sürelerini gösteren grafik 
aşağıda paylaşılmıştır.

![getbyId](https://github.com/guvenbaris/MongoDb/blob/master/image/getbyId.png?raw=true)

Databaseler de UserModelin FirstName'ine göre aramayı gösteren grafik aşağıdaki 
görünmektedir.

![search](https://github.com/guvenbaris/MongoDb/blob/master/image/search.png?raw=true)

