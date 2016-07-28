using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dejkstra
{
    public class Vector
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector Subtract(Vector v)
        {
            return new Vector((X - v.X), Y - v.Y);
        }
        public Vector Add(Vector v)
        {
            return new Vector(X + v.X, Y + v.Y);
        }
        public Vector Multiply(int a)
        {
            return new Vector(X * a, Y * a);
        }
        public double Len()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
        public double LenTwoVectors(Vector vector)
        {
            return Math.Sqrt(Math.Pow(X - vector.X, 2) + Math.Pow(Y - vector.Y, 2));
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Vector))
                return false;
            Vector vector = (Vector)obj;
            return X == vector.X && Y == vector.Y;
        }
        public override string ToString()
        {
            return " X=" + X + ", Y=" + Y;
        }
        public override int GetHashCode()
        {
            return Tuple.Create(X, Y).GetHashCode();
        }
    }
}
