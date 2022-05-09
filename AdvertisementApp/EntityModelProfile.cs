using AdvertisementApp.Models;
using AutoMapper;
using DataLayer.Entities;
using System.Linq;

namespace AdvertisementApp
{
    public class EntityModelProfile : Profile
    {
        public EntityModelProfile()
        {
            CreateMap<Advertisement, AdvertisementModel>()
                .ForMember(a => a.PhotoLinksNames,
                opt => opt.MapFrom(am => am.PhotoLinks.Select(x => x.Name)));
            CreateMap<AdvertisementModel, Advertisement>()
                .ForMember(a => a.PhotoLinks,
                opt => opt.MapFrom(am => am.PhotoLinksNames.Where(x=>x!=null).Select(x =>
                new PhotoLink
                {
                    Id=0,
                    Name = x
                }
                ))) ;
            CreateMap<Advertisement, ShortAdvertisementModel>()
                .ForMember(a => a.PhotoLink,
                opt => opt.MapFrom(am => am.PhotoLinks.Count!=0 ? am.PhotoLinks.Select(x=>x.Name).ToArray()[0] : ""));

        }
    }
}
