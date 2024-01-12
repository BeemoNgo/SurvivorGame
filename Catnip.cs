using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal class Catnip:PhysicalObject
    {
        private int _health;
        private DateTime _lastShoot;
        private double _coolDownTime;
        private int _magazine;
        private int _originalHealth;
        public Catnip():base("catnip", 400, 400)
        {
            _originalHealth = 50;
            Health = _originalHealth;
            Speed = 0.3;
            CoolDownTime = 0.5;
            DetectRange = 300;
            _lastShoot = DateTime.Now;
            _magazine = 3;
            ShootAtATime = _magazine;
        }
        public int OriginalHealth
        {
            get
            {
                return _originalHealth;
            }
        }
        public int Health
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
        public int ShootAtATime { get; set; }
        public double CoolDownTime
        {
            get
            {
                return _coolDownTime;
            }
            set
            {
                _coolDownTime = value;
            }
        }

        public bool CanShoot()
        {
            if(ShootAtATime > 0)
            {
                return true;
            }
            if((DateTime.Now - _lastShoot).TotalSeconds >= CoolDownTime)
            {
                ShootAtATime = _magazine;
                return true;
            }
            return false;
        }

        public Projectile Shoot()
        {
           
            Projectile result;
            Random random = new Random();
            double randomNumber = random.NextDouble();
            if (randomNumber > 0.6) //chance for bullet
            {
                result = new Bullet(Location.X, Location.Y);
            }
            else //kunai
            {
                result = new Kunai(Location.X, Location.Y);
            }
            _lastShoot = DateTime.Now; //reset cool down time
            ShootAtATime -= 1;
            return result;
        }

        public override void MoveUp()
        {

            if (Location.Y >= Height / 2)
            {
                Point2D pt = Location;
                pt.Y -= Speed;
                if (pt.Y < Height / 2)
                {
                    pt.Y = Height / 2;
                }
                Location = pt;
            }
        }

        public override void MoveDown()
        {
            if (Location.Y + Height / 2 <= 700)
            {
                Point2D pt = Location;
                pt.Y += Speed;
                if (pt.Y > 700 - Height / 2)
                {
                    pt.Y = 700 - Height / 2;
                }
                Location = pt;
            }
        }

        public override void MoveLeft()
        {
            if (Location.X - Width / 2 >= 0)
            {
                Point2D pt = Location;
                pt.X -= Speed;
                if (pt.X < Width / 2)
                {
                    pt.X = Width / 2;
                }
                Location = pt;
            }
        }

        public override void MoveRight()
        {
            if (Location.X + Width / 2 <= 800)
            {
                Point2D pt = Location;
                pt.X += Speed;
                if (pt.X > 800 - Width / 2)
                {
                    pt.X = 800 - Width / 2;
                }
                Location = pt;
            }
        }

        public int DetectRange { get; set; }
        public void Update(List<Enemy> enemies)
        {
            foreach(Enemy e in enemies)
            {
                if(Distance(e) < DetectRange)
                {

                }
            }
        }
       

    }
}
