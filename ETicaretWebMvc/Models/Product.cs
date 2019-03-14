using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretWebMvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        [StringLength(maximumLength: 50, ErrorMessage = "En fazla 50 karakter girebilirsiniz!")]
        public string Name { get; set; }
        [StringLength(maximumLength: 400, ErrorMessage = "En fazla 400 karakter girebilirsiniz!")]
        [DisplayName("Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Fiyatı")]
        public double Price { get; set; }
        [DisplayName("Stok Adedi")]
        public int Stock { get; set; }
        [StringLength(maximumLength: 50)]
        [DisplayName("Resmi")]
        public string Image { get; set; }
        [DisplayName("Anasayfa")]
        public bool IsHome { get; set; }
        [DisplayName("Onaylı")]
        public bool IsApproved { get; set; }
        [DisplayName("Kategorisi")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}