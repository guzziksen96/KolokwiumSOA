using ArmClientKLAGUZ.TankServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmClientKLAGUZ
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();

            var tanks = new[]
            {
                new Tank() {Id = 1, ModelName = "Tank1", Power = 1, Shield = 1},
                new Tank() {Id = 2, ModelName = "Tank2", Power = 2, Shield = 2},
                new Tank() {Id = 3, ModelName = "Tank3", Power = 3, Shield = 3},


            };

            foreach (var tank in tanks)
            {
                client.CreateTank(tank);
            }

            var t = client.GetTank("Tank1");

            //Tank t = new Tank
            //{
            //    Id = 1,
            //    ModelName = "Tank1",
            //    Shield = 1,
            //    Power = 1
            //};

            Console.WriteLine("ModelName: {0} Power: {1} Shield: {2}", t.ModelName, t.Power, t.Shield);

            client.Close();
            Console.ReadKey();

        }
    }
}
