using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns_Task3
{
    class Particle
    {
        public int limit;
        public double x, y, Xvelocity, Yvelocity;
        public void start(double x, double y, double xvol, double yvol, int wall)
        {
            this.x = x;
            this.y = y;
            Xvelocity = xvol;
            Yvelocity = yvol;
            limit = wall;
        }

        public void move()
        {
            if (!inUse()) return;

            limit -= 1;
            this.x += Xvelocity;
            this.y += Yvelocity;
        }

        public bool inUse()
        {
            return limit > 0;
        }
    }


    class ParticlePool
    {
        public Particle[] particles = new Particle[200];
        public void create(double x, double y, double xvol, double yvol, int wall)
        {
            for (int i = 0; i < 200; i++)
            {
                particles[i] = new Particle();
                if (!particles[i].inUse())
                {
                    particles[i].start(x, y, xvol, yvol, wall);
                    return;
                }
            }
        }

        public void _is_moving()
        {
            particles[0].move();

        }

        public override string ToString()
        {
            return ($"Bullet position X is: {particles[0].x} , while Bullet position Y is: {particles[0].y}");

        }
    }
}
