using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal class EnemyFactory
    {
        private double _chanceZombie = 0.6;
        private static EnemyFactory _instance = null;
        public static EnemyFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EnemyFactory();
                }
                return _instance;
            }
        }
        public EffectObserver EffectObserver { get; set; }
        public Enemy createRandomEnemy()
        {
            Enemy e;
            Random random = new Random();
            double randomNumber = random.NextDouble();
            if(randomNumber > _chanceZombie) //chance for dog
            {
                e = new Dog(random.Next(1, 800), random.Next(1, 700));
            }
            else
            {
                e = new Zombie(random.Next(1, 800), random.Next(1, 700));
            }
            e.DamageObserver = EffectObserver;
            return e;
        }
        public Enemy createEnemy(string id, double x, double y)
        {
            if (id == "dog")
            {
                return new Dog(x, y);
            }
            else if (id == "zombie")
            {
                return new Zombie(x, y);
            }
            else if(id == "boss")
            {
                return new Boss(x, y);
            }
            return null;
        }
    }
}
