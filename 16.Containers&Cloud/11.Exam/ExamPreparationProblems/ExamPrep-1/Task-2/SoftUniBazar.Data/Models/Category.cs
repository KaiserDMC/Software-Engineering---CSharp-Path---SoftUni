using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Data.DataConstants;

namespace SoftUniBazar.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(CategoryNameMax)]
        public string Name { get; set; } = null!;

        public virtual IEnumerable<Ad> Ads { get; set; } = new List<Ad>();
    }
}
