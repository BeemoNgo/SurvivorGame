using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal class Projectile : PhysicalObject
    {
        private Vector2D _direction;
        public Projectile(string image,double x, double y) : base(image, x, y)
        {
            Speed = 0.1;
            RotationAngle = 0;
            Damage = 10;
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(SplashKit.BitmapNamed(Image), BoundingBox.X, BoundingBox.Y);
        }
        public double Damage { get; set; }
        public double RotationAngle { get; set; }
        public void RotateToPoint(Point2D pt)
        {
            _direction = new Vector2D(pt.X - Location.X, pt.Y - Location.Y);
            double mag = SplashKit.VectorMagnitude(_direction);
            _direction = new Vector2D(_direction.X / mag, _direction.Y / mag);
            RotationAngle = SplashKit.VectorAngle(SplashKit.VectorInvert(
                SplashKit.VectorFromPointToRect(pt, BoundingBox))
            );
           
        }
        public void Update()
        {
            Point2D pt = Location;
            double mag = SplashKit.VectorMagnitude(_direction);
            Vector2D temp = new Vector2D(_direction.X / mag, _direction.Y / mag);
            pt.X += Speed * temp.X;
            pt.Y += Speed * temp.Y;
            Location = pt;
        }
    }
}
