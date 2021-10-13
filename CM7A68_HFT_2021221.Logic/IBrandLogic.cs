using CM7A68_HFT_2021221.Models;
using System.Collections.Generic;

namespace CM7A68_HFT_2021221.Logic
{
    interface IBrandLogic
    {
        void Create(Brand brand);
        void Delete(int id);
        Brand Read(int id);
        IEnumerable<Brand> ReadAll();
        void Update(Brand brand);
    }
}