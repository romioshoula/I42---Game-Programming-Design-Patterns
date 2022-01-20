using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            ParticlePool bullet = new ParticlePool();
            bullet.create(50, 50, 2, 5, 1000);
            int i = 2000;
            while (i > 0)
            {
                bullet._is_moving();
                Console.WriteLine(bullet.ToString());
                i--;
            }

            Console.ReadLine();
        }
    }
}
