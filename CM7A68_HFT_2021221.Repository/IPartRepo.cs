using CM7A68_HFT_2021221.Models;
using System.Linq;

namespace CM7A68_HFT_2021221.Repository
{
    public interface IPartRepo
    {
        void Create(Part part);
        void Delete(int ID);
        Part Read(int ID);
        IQueryable<Part> ReadAll();
        void Update(Part part);
    }
}