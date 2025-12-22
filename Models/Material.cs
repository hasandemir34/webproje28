using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stokprojesi1.Models
{
    public class Material
{
    [Key] //yine bir pk kısmı
    public int MaterialId { get; set; }

    [Required(ErrorMessage = "Malzeme adı zorunludur.")]
    [Display(Name = "Malzeme Adı")]
    public string? Name { get; set; } 

    [Required]
    [Display(Name = "Stok Adedi")]
    public int StockQuantity { get; set; }

    [Display(Name = "Birim Fiyat")] //fiyat bilgilerini tutarken decimal kullanmak tavsiye edilirmiş.
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Display(Name = "Kategori")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")] //FK ile burda çoka çok ilişki tanımladım.
    public virtual Category? Category { get; set; } 
}
}