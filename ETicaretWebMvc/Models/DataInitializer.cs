using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ETicaretWebMvc.Models
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var categories = new List<Category>()
            {
                new Category(){Name="Kanepe ve Koltuklar", Description="Kanepe ve Koltuk Ürünleri"},
                new Category(){Name="TV Sehpaları", Description="TV Sehpa Ürünleri"},
                new Category(){Name="Sehpalar", Description="Sehpa Ürünleri"}
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            var products = new List<Product>()
            {
                new Product(){ Name="Home Konfor Köşe Koltuk Takımı", Description="Oturma odası, ailenizle zaman geçirdiğiniz, arkadaşlarınızla sosyalleştiğiniz, günün yorgunluğunu attığınız evin en işlevsel odasıdır.Kanepe, uzanma koltuğu bir aradadır. Odanızın şekline göre, uzanma koltuğunu kanepenin yanına yerleştirerek köşe kanepe yapabilirsiniz. ", Price=899.90, Stock=10, IsApproved=true, IsHome=true, Image="seedc1p1.jpg", CategoryId=1},
                new Product(){ Name="Wood House Star Köşe Takımı", Description="52 dns. 1. Sınıf çökme garantili Gri sünger kullanılmıştır.Sırt bölümünde Çelik konstrüksyon kullanılmıştır.Kullanılan kumaş 1. sınıf olup kesinlikle polyester ve kanserojen madde içermez.Kırlentlerde kar tanesi elyaf kırpık sünger kullanılmıştır.Yastık kılıfları fermuarlı olup yıkanabilme özelliğine sahiptir.Sırt metali 1mm profil den imal edilmiştir.Mikrofiber Kumaş kullanılmıştır. ", Price=749.90, Stock=10, IsApproved=true, IsHome=true, Image="seedc1p2.jpg", CategoryId=1},

                new Product(){ Name="Home Paris TV Ünitesi", Description="18 mm kalınlığında A Kalite yonga levha ve 1. sınıf pvc bant kullanılmıştır. Çevre ve çocuk sağlığına uygun malzemeler ile üretilmiştir.", Price=249.90, Stock=10, IsApproved=true, IsHome=true, Image="seedc2p1.jpg", CategoryId=2},
                new Product(){ Name="HomeRomeo TV Ünitesi", Description="18 mm kalınlığında A Kalite yonga levha ve 1. sınıf pvc bant kullanılmıştır. Çevre ve çocuk sağlığına uygun malzemeler ile üretilmiştir. Kullanılan tüm aksesuarlar 1. Sınıf olup, TSE'ye uygundur. ", Price=209.90, Stock=10, IsApproved=true, IsHome=true, Image="seedc2p2.jpg", CategoryId=2},
                 new Product(){ Name="Tutta La Vita Orta Sehpa Tekerlekli Ahşap", Description="Ürünümüz ahşaptan (çam ağacı) üretilmektedir.Mdf ve suntalam ürünler ile kıyaslamayınız.", Price=299.90, Stock=10, IsApproved=true, IsHome=true, Image="seedc3p1.jpg", CategoryId=3},
                new Product(){ Name="Bianca Dekoratif Laptop Sehpası Highgloss Ceviz", Description="Bianca Dekoratif Laptop Sehpası Highgloss Ceviz ", Price=219.90, Stock=10, IsApproved=true, IsHome=true, Image="seedc3p2.jpg", CategoryId=3}
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}