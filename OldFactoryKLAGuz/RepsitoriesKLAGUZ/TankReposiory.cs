using InterfacesKLAGUZ;
using LiteDB;
using ModelsKLAGUZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepsitoriesKLAGUZ
{
    public class TankReposiory : ITankRepository
    {
        private readonly string _tankConnection = @"C:/tmp/tanks";

        public string CreateTank(Tank tank)
        {
            using (var db = new LiteDatabase(this._tankConnection))
            {
                var repository = db.GetCollection<Tank>("tanks");
                if (repository.FindById(tank.Id) != null)
                    repository.Update(tank);
                else
                    repository.Insert(tank);
                return tank.ModelName;
            }
        }

        public Tank GetTank(string name)
        {
            using (var db = new LiteDatabase(this._tankConnection))
            {
                var repository = db.GetCollection<Tank>("tanks").FindAll();
                IEnumerable<Tank> wingsByName = repository.Where(t => t.ModelName.Equals(name));
                return wingsByName.FirstOrDefault();
            }
        }

        public List<Tank> GetAllTanks()
        {
            using (var db = new LiteDatabase(this._tankConnection))
            {
                var repository = db.GetCollection<Tank>("tanks");
                return repository.FindAll().ToList();
            }
            
        }
        
    }
}
