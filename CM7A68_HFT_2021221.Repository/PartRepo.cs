﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM7A68_HFT_2021221.Data;
using CM7A68_HFT_2021221.Models;

namespace CM7A68_HFT_2021221.Repository
{
    public class PartRepo : IPartRepo
    {
        CarDBContext db;
        public PartRepo(CarDBContext db)
        {
            this.db = db;
        }
        public void Create(Part part)
        {
            db.Parts.Add(part);
            db.SaveChanges();
        }
        public Part Read(int ID)
        {
            return db.Parts.FirstOrDefault(x => x.ID == ID);
        }
        public IQueryable<Part> ReadAll()
        {
            return db.Parts;
        }
        public void Delete(int ID)
        {
            var todelete = Read(ID);
            db.Remove(todelete);
            db.SaveChanges();
        }
        public void Update(Part part)
        {
            var oldpart = Read(part.ID);
            oldpart.Brand = part.Brand;
            oldpart.Item_number = part.Item_number;
            oldpart.Name = part.Name;
            oldpart.Price = part.Price;
            oldpart.Weight = part.Weight;
            db.SaveChanges();
        }
    }
}