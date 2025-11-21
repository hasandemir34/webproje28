using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stokprojesi1.Models
{
    public class Material
{
    [Key]
    public int MaterialId { get; set; }

    [Required(ErrorMessage = "Malzeme adı girmeyi unuttun.")]
    [Display(Name = "Malzeme Adı")]
    public string? Name { get; set; } // <--- Soru işareti

    [Required]
    [Display(Name = "Stok Adedi")]
    public int StockQuantity { get; set; }

    [Display(Name = "Birim Fiyat")]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Display(Name = "Kategori")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public virtual Category? Category { get; set; } // <--- Soru işareti
}
}