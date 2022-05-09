using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvertisementApp.Models
{
    public class AdvertisementModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }

        [MaxLength(3)]
        public ICollection<string> PhotoLinksNames { get; set; }

        public AdvertisementModel()
        {
            PhotoLinksNames = new List<string>();
        }
    }
}
