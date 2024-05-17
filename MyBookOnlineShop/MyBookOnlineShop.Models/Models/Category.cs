using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyBookOnlineShop.Models.Models
{
    public class Category
    {
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [Required]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

    }
}
