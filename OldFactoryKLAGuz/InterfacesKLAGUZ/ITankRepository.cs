using ModelsKLAGUZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesKLAGUZ
{
    public interface ITankRepository
    {
        Tank GetTank(string name);
        String CreateTank(Tank tank);
        List<Tank> GetAllTanks();
    }
}
