using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Advertisement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }

        [MaxLength(3)]
        public ICollection<PhotoLink> PhotoLinks { get; set; }

        public Advertisement()
        {
            PhotoLinks = new List<PhotoLink>();
        }

    }
}
