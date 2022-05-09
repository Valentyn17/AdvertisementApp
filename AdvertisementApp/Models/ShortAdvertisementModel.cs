using System.ComponentModel.DataAnnotations;

namespace AdvertisementApp.Models
{
    public class ShortAdvertisementModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public string PhotoLink { get; set; }

    }
}
