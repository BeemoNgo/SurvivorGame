using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal class Bullet: Projectile
    {
        public Bullet(double x, double y):base("bullet",x,y)
        {
            Speed = 0.5;
            Damage = 20;
        }
    }
}
