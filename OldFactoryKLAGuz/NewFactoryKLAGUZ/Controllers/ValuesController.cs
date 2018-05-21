using InterfacesKLAGUZ;
using LiteDB;
using ModelsKLAGUZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace NewFactoryKLAGUZ.Controllers
{
    public class ValuesController : ApiController
    {
        private ITankRepository tankRepository = new RepsitoriesKLAGUZ.TankReposiory();
        private readonly string _tankConnection = @"C:/tmp/tanks";
        
        public List<Tank> Get()
        {
            return tankRepository.GetAllTanks().ToList();
        }


        [ResponseType(typeof(Tank))]
        public Tank Get(int id)
        {
            using (var db = new LiteDatabase(this._tankConnection))
            {
                var repository = db.GetCollection<Tank>("tanks");
                return repository.FindById(id);
            }
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Tank value)
        {
            return tankRepository.CreateTank(value);
        }
        
        [ResponseType(typeof(Tank))]
        public Tank Put(int id, [FromBody]Tank tank)
        {
            using (var db = new LiteDatabase(this._tankConnection))
            {
                var repository = db.GetCollection<Tank>("tanks");
                if (repository.Update(tank))
                    return tank;
                else
                    return null;
            }
        }
        

        [ResponseType(typeof(bool))]
        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._tankConnection))
            {
                var repository = db.GetCollection<Tank>("tanks");
                return repository.Delete(id);
            }
        }
    }
}
