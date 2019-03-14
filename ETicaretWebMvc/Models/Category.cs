using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretWebMvc.Models
{
    public class Category
    {
        public int Id { get; set; }
        [DisplayName("Kategori Adı")]
        [StringLength(maximumLength:50,ErrorMessage ="En fazla 50 karakter girebilirsiniz!")]
        public string Name { get; set; }
        [DisplayName("Açıklaması")]
        [StringLength(maximumLength: 250, ErrorMessage = "En fazla 250 karakter girebilirsiniz!")]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}