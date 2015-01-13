// Diamond.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace SpaceRPG.Source.Util.Shapes
{
    /// <summary>
    /// Diamond represents a diamond geometric shape
    /// </summary>
    public class Diamond
    {        
        private Point _left, _top, _right, _down;
        private Rectangle _rect;

        public Diamond()
        {
            _left = Point.Zero;
            _top = Point.Zero;
            _right = Point.Zero;
            _down = Point.Zero;
            _rect = Rectangle.Empty;
        }

        public Diamond(Rectangle rect)
        {
            
        }

        public Diamond(Point left, int width, int height)
        {

        }
    }
}
