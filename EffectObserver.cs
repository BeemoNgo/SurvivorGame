using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal class EffectObserver
    {
        private Dictionary<Enemy, DateTime> collisions;
        public EffectObserver ()
        {
            collisions = new Dictionary<Enemy, DateTime> ();
        }

        public void AddCollision(Enemy e, Catnip c)
        {
            if (!collisions.ContainsKey(e))
            {
                collisions[e] = DateTime.Now;
                c.Health -= e.Damage;
            }
        }
        public void Update(Catnip c)
        {
            List<Enemy> enemies = new List<Enemy>(collisions.Keys);

            foreach (Enemy enemy in enemies)
            {
                if(enemy.OutMap())
                {
                    collisions.Remove(enemy);
                }
                if (!c.IsCollided(enemy))
                {
                    collisions.Remove(enemy);
                }
                else
                {
                    // If the collision has been ongoing for more than 1 second
                    if ((DateTime.Now - collisions[enemy]).TotalSeconds >= enemy.DurationTouching)
                    {
                        // Decrease the player's health by 1
                        c.Health -= enemy.Damage;
                   
                        // Reset the collision start time to now
                        collisions[enemy] = DateTime.Now;
                    }
                }
            }
        }
    }
}
