using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models.Models
{
    public class Category
    {
        [Key] // Data annotation for making this prop primary key
        public int Id { get; set; }
        [Required] // To making this column required
        [DisplayName("Category Name")]
        [MaxLength(30,ErrorMessage ="Make it short bro less than 30")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
 