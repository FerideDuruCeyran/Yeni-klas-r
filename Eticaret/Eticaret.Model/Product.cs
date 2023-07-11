using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Model
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Ürün Adı"), Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Fiyat")]
        public double Price { get; set; }

        // 0 = silindi, 1 = aktif, 3 = pasif
        public int Status { get; set; } = 1;
    }
}
