// RightTriangle.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace SpaceRPG.Source.Util.Shapes
{
    public class RightTriangle
    {
        private Point _a, _b, _c; // a is the right angle point
        private float _angleA, _angleB, _angleC; // a is the right angle
        private float _distAB, _distBC, _distCA; // bc is the hypotenuse

        #region Accessors
        // Points
        public Point A
        {
            get { return _a; }
            set { _a = value; }
        }
        public Point B
        {
            get { return _b; }
            set { _b = value; }
        }
        public Point C
        {
            get { return _c; }
            set { _c = value; }
        }
        // Angles
        public float AngleA
        {
            get { return _angleA; }
            set { _angleA = value; }
        }
        public float AngleB
        {
            get { return _angleB; }
            set { _angleB = value; }
        }
        public float AngleC
        {
            get { return _angleC; }
            set { _angleC = value; }
        }
        // Distances
        public float DistAB
        {
            get { return _distAB; }
            set { _distAB = value; }
        }
        public float DistBC
        {
            get { return _distBC; }
            set { _distBC = value; }
        }
        public float DistCA
        {
            get { return _distCA; }
            set { _distCA = value; }
        }
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public RightTriangle()
        {
            _a = Point.Zero;
            _b = Point.Zero;
            _c = Point.Zero;
        }

        /// <summary>
        /// Constructor for creating a new triangle at a given set of points
        /// </summary>
        /// <param name="a">Right angle point</param>
        /// <param name="b">Second point</param>
        /// <param name="c">Third point</param>
        public RightTriangle(Point a, Point b, Point c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        /// <summary>
        /// Initializes all of the values in the triangle
        /// </summary>
        public void Initialize()
        {
            _distAB = (float)Math.Sqrt(Math.Pow(b.Y - a.Y, 2) + Math.Pow(b.X - a.X, 2));
            _distBC = (float)Math.Sqrt(Math.Pow(c.Y - b.Y, 2) + Math.Pow(c.X - b.X, 2));
            _distCA = (float)Math.Sqrt(Math.Pow(a.Y - c.Y, 2) + Math.Pow(a.X - c.X, 2));

            _angleA = 90;
            _angleB = (float)Math.Sin(_distCA / _distBC);
            _angleC = 90 - _angleB;
        }

        /// <summary>
        /// Copies the values of an existing triangle to a new triangle, but updates the location.
        /// </summary>
        /// <param name="a">New right angle point</param>
        /// <param name="b">New second point</param>
        /// <param name="c">New third point</param>
        /// <returns>Copies triangle at a new location</returns>
        public RightTriangle CopyTo(Point a, Point b, Point c)
        {
            RightTriangle newTriangle = new RightTriangle();

            newTriangle.A = a;
            newTriangle.B = b;
            newTriangle.C = c;

            newTriangle.AngleA = _angleA;
            newTriangle.AngleB = _angleB;
            newTriangle.AngleC = _angleC;

            newTriangle.DistAB = _distAB;
            newTriangle.DistBC = _distBC;
            newTriangle.DistCA = _distCA;

            return newTriangle;
        }

        /// <summary>
        /// Checks whether or not a triangle contains a point, includes on lines
        /// </summary>
        /// <param name="loc">Point to check</param>
        /// <returns>True if the Triangle containts the given point</returns>
        public bool Contains(Point loc)
        {
            bool b1, b2, b3;

            b1 = Sign(loc, _a, _b) < 0.0f;
            b2 = Sign(loc, _b, _c) < 0.0f;
            b3 = Sign(loc, _c, _a) < 0.0f;

            return ((b1 == b2) && (b2 == b3));
        }
        // Source http://www.gamedev.net/topic/295943-is-this-a-better-point-in-triangle-test-2d/
        private float Sign(Point loc, Point p1, Point p2)
        {
            return (loc.X - p2.X) * (p1.Y - p2.Y) - (p1.X - p2.Y) * (loc.Y - p2.y);
        }
    }
}
