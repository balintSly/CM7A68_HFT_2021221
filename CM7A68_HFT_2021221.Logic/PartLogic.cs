using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM7A68_HFT_2021221.Models;
using CM7A68_HFT_2021221.Repository;

namespace CM7A68_HFT_2021221.Logic
{
    public class PartLogic
    {
        IPartRepo partRepo;
        public PartLogic(IPartRepo partRepo)
        {
            this.partRepo = partRepo;
        }
        public void Create(Part part)
        {
            if (part.Brand.Length == 0)
            {
                throw new ArgumentException("Invalid part brand name.");
            }
            if (part.Item_number.Length == 0)
            {
                throw new ArgumentException("Invalid item number.");
            }
            if (part.Name.Length == 0)
            {
                throw new ArgumentException("Invalid part name.");
            }
            if (part.Price <= 0)
            {
                throw new ArgumentException("Invalid price.");
            }
            if (part.Weight <= 0)
            {
                throw new ArgumentException("Invalid weight.");
            }
            partRepo.Create(part);

        }
        public void Delete(int id)
        {
            try
            {
                partRepo.Delete(id);
            }
            catch (Exception)
            {

                throw new ArgumentException("There is no part with the following ID: " + id);
            }

        }
        public Part Read(int id)
        {
            try
            {
                return partRepo.Read(id);
            }
            catch (Exception)
            {

                throw new ArgumentException("There is no part with the following ID: " + id);
            }
        }
        public void Update(Part part)
        {
            try
            {
                Read(part.ID);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            partRepo.Update(part);
        }
        public IEnumerable<Part> ReadAll()
        {
            return partRepo.ReadAll();
        }
    }
}
