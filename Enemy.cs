using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal abstract class Enemy: PhysicalObject
    {
        private double _health;
        private int _damage;
        private double _durationTouching;
        private int _detectRange;
        private Vector2D _direction;
        private EffectObserver _damageObserver;
       
        public Enemy(string image, double x, double y) : base(image, x,y)
        {
            Random random = new Random();
            DurationTouching = 1.5;
            _direction = new Vector2D(random.Next(1, 800), random.Next(1, 700));
        }
        public double DurationTouching
        {
            get { return _durationTouching; }
            set { _durationTouching = value; }
        }
       
        public int DetectRange
        {
            get { return _detectRange; }
            set { _detectRange = value; }
        }
        
        public double Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        public EffectObserver DamageObserver
        {
            get { return _damageObserver; }
            set { _damageObserver = value; }
        }
        public void UpdateMove(Catnip c)
        {
            _direction = new Vector2D(c.Location.X - Location.X, c.Location.Y - Location.Y);
            double mag = SplashKit.VectorMagnitude(_direction);
            _direction = new Vector2D(_direction.X/mag, _direction.Y / mag);
            Point2D pt = Location;
            pt.X += Speed * _direction.X ;
            pt.Y += Speed * _direction.Y ;
            Location = pt;
        }
        public void RandomMove()
        {
            Point2D pt = Location;
            double mag = SplashKit.VectorMagnitude(_direction);
            Vector2D temp = new Vector2D(_direction.X / mag, _direction.Y / mag);
            pt.X += Speed * temp.X ;
            pt.Y += Speed * temp.Y ;
            Location = pt;
        }
       
        public void Update(Catnip c, List<Projectile> projectiles)
        {
            if(Distance(c) < DetectRange)
            {
                UpdateMove(c);
                if(c.IsCollided(this))
                {
                    DamageObserver.AddCollision(this, c); //notify the observer to keep track
                }
            }
            else
            {
                
                RandomMove();
            }
            foreach(Projectile p in projectiles)
            {
                if(p.IsCollided(this))
                {
                    double temp = Health;
                    Health -= p.Damage;
                    projectiles.Remove(p);
                    break;
                }
            }
        }
    }
}
