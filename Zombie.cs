using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal class Zombie: Enemy
    {
        public Zombie(double x, double y):base("zombie",x,y)
        {
            Health = 60;
            Damage = 5;
            Speed = 0.01;
            DetectRange = 330 ;
        }
    }
}
