using System.ComponentModel.DataAnnotations; // Validation için gerekli kütüphane

namespace stokprojesi1.Models
{
    public class Category
{
    [Key] //PK olarak düşünülebilir ve 1er 1er artar bu sayı.
    public int CategoryId { get; set; } //ayarlama

    [Required(ErrorMessage = "Kategori adı boş bırakılamaz!")] //bu alanın zorunlu olduğunu anlıyorum buradan
    [Display(Name = "Kategori Adı")] //ekranda görünecek hali
    public string? Name { get; set; } //null olabilir

    
    public virtual ICollection<Material>? Materials { get; set; } //material adı altında birden fazla şey 
}                                                       //olabileceğini söylüyor.
}