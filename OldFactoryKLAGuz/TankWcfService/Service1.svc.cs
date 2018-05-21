using InterfacesKLAGUZ;
using ModelsKLAGUZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TankWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private readonly ITankRepository _tankRep;

        public string CreateTank(Tank tank)
        {
            return _tankRep.CreateTank(tank);
        }

        public List<Tank> GetAllTanks()
        {
            return _tankRep.GetAllTanks();
        }

        public Tank GetTank(string name)
        {
            return _tankRep.GetTank(name);
        }
    }
}
