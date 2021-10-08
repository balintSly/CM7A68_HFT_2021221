using CM7A68_HFT_2021221.Models;
using System.Linq;

namespace CM7A68_HFT_2021221.Repository
{
    public interface IBrandRepo
    {
        void Create(Brand brand);
        void Delete(int ID);
        Brand Read(int ID);
        IQueryable<Brand> ReadAll();
        void Update(Brand brand);
    }
}