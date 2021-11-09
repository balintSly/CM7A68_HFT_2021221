using CM7A68_HFT_2021221.Models;
using System.Collections.Generic;

namespace CM7A68_HFT_2021221.Logic
{
    public interface IPartLogic
    {
        void Create(Part part);
        void Delete(int id);
        Part Read(int id);
        IEnumerable<Part> ReadAll();
        void Update(Part part);
    }
}