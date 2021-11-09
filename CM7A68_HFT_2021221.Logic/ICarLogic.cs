using CM7A68_HFT_2021221.Models;
using System.Collections.Generic;

namespace CM7A68_HFT_2021221.Logic
{
    public interface ICarLogic
    {
        void Create(Car car);
        void Delete(int id);
        Car Read(int id);
        IEnumerable<Car> ReadAll();
        void Update(Car car);
        IEnumerable<KeyValuePair<string, List<KeyValuePair<string, string>>>> Top3CarsWithTheMostCompatibleParts();
        IEnumerable<KeyValuePair<string, KeyValuePair<string, KeyValuePair<string, double>>>> AvgCylinderCapBrands();
    }
}