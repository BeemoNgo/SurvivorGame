﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace ShapeDrawer
{

    public class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;

        public Shape(Color color, float x, float y)
        {
            _color = color;
            _x = x;
            _y = y;
            _width = 100;
            _height = 100;
        }
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }
        public Boolean IsAt(Point2D pt)
        {
            if(pt.X >= _x && pt.X <= (_width+_x ) && pt.Y >= _y && pt.Y <= (_height + _y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }
}
