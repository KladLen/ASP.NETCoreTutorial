using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage = "Value must be betwen 1 and 100")]
        public string DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
