using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ShapeDrawer
{
    internal class Dog: Enemy
    {
        public Dog(double x, double y) : base("dog", x, y)
        {
            Health = 40;
            Damage = 3;
            Speed = 0.02;
            DetectRange = 200;
        }
    }
}
