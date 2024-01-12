using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace ShapeDrawer
{
    internal abstract class PhysicalObject
    {
        private Rectangle _boundingBox;
        private double _speed;
        public PhysicalObject(string image, double x, double y)
        {
            Image = image;
            isRemoved = false;
            Speed = 0.1;
            Bitmap bitmap = SplashKit.BitmapNamed(Image);
            _boundingBox = bitmap.BoundingRectangle(x, y);
            SplashKit.RectangleOffsetBy(
                _boundingBox,
                SplashKit.VectorPointToPoint(
                    SplashKit.RectangleCenter(_boundingBox),
                    SplashKit.PointAt(x, y)
                )
            );

        }
        public string Image { get; set; }
        public bool isRemoved { get; set; }
        public Point2D Location
        {
            get
            {
                return SplashKit.RectangleCenter(_boundingBox);
            }
            set
            {
                _boundingBox.X = value.X - _boundingBox.Width / 2.0;
                _boundingBox.Y = value.Y - _boundingBox.Height / 2.0;
            }
        }

        public double Width
        {
            get
            {
                return _boundingBox.Width;
            }
        }

        public double Height
        {
            get
            {
                return _boundingBox.Height;
            }
        }
        public virtual void Draw()
        {
            SplashKit.DrawBitmap( SplashKit.BitmapNamed(Image), _boundingBox.X, _boundingBox.Y);
        }

        public Rectangle BoundingBox
        {
            get
            {
                return _boundingBox;
            }
        }
        
        public double Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }
        public bool OutMap()
        {
            if (Location.X > 800 || Location.Y > 700 || Location.X < 0 || Location.Y < 0)
            {
                return true;
            }
            return false;
        }

        public bool IsCollided(PhysicalObject obj)
        {
            return SplashKit.RectanglesIntersect(BoundingBox, obj.BoundingBox);
        }

        public double Distance(PhysicalObject obj)
        {
            return SplashKit.PointPointDistance(Location, obj.Location);
        }

        public virtual void MoveUp()
        {
                Point2D pt = Location;
                pt.Y -= Speed;        
                Location = pt;
        }

        public virtual void MoveDown()
        {
            Point2D pt = Location;
            pt.Y += Speed;
            Location = pt;
            
        }

        public virtual void MoveLeft()
        {
            Point2D pt = Location;
            pt.X -= _speed;
            Location = pt;
        }

        public virtual void MoveRight()
        {
            Point2D pt = Location;
            pt.X += _speed;
            Location = pt;
        }
    }
}
