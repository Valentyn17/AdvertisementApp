using DataLayer.Context;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly AdvertisementDBContext _advertisementDbContext;
        public AdvertisementRepository(AdvertisementDBContext advertisementDBContext)
        {
            _advertisementDbContext = advertisementDBContext;
        }
        public async Task<int> CreateAsync(Advertisement entity)
        {

            if (entity.PhotoLinks.Count > 3)
                throw new InvalidOperationException("Can maximum be 3 photo links");
            List<PhotoLink> links = new List<PhotoLink>(entity.PhotoLinks.ToList());
            for (int i = 0; i < links.Count; i++)
            {
                _advertisementDbContext.PhotoLinks.Add(links[i]);
            }
            entity.PhotoLinks = links;
            await _advertisementDbContext.Advertisements.AddAsync(entity);
            await _advertisementDbContext.SaveChangesAsync();
            return entity.Id;
        }

        public IEnumerable<Advertisement> GetAll()
        {
            return _advertisementDbContext.Advertisements.Include(x => x.PhotoLinks);
        }

        public async Task<Advertisement> GetByIdAsync(int id)
        {
            return await _advertisementDbContext.Advertisements.Include(x=>x.PhotoLinks).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
