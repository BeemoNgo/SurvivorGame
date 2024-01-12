using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal class Boss: Enemy
    {
        public Boss(double x, double y) : base("boss", x, y)
        {
            Health = 1000;
            Damage = 30;
            DetectRange = 200;
        }
    }
}
