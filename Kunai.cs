using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ShapeDrawer
{
    internal class Kunai:Projectile
    {
        public Kunai(double x, double y) : base("kunai", x, y)
        {
            Speed = 0.3;
            Damage = 10;
        }
    }
}
