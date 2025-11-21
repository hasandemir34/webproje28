using System.ComponentModel.DataAnnotations; // Validation için gerekli kütüphane

namespace stokprojesi1.Models
{
    public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Kategori adı boş bırakılamaz aga!")]
    [Display(Name = "Kategori Adı")]
    public string? Name { get; set; } // <--- Soru işareti ekledik

    // Bunu da nullable yaptık
    public virtual ICollection<Material>? Materials { get; set; }
}
}