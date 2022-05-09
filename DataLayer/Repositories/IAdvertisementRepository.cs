using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IAdvertisementRepository
    {
        IEnumerable<Advertisement> GetAll();
        Task<Advertisement> GetByIdAsync(int id);
        Task<int> CreateAsync(Advertisement advertisement);
    }
}
