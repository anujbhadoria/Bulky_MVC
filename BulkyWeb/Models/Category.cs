using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key] // Data annotation for making this prop primary key
        public int Id { get; set; }
        [Required] // To making this column required
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
 