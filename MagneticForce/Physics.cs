using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MagneticForce
{
    public class Physics
    {
        public static PointF Add(PointF a, PointF b)
        {
            return new PointF(a.X + b.X, a.Y + b.Y);
        }

        public static PointF Sub(PointF a, PointF b)
        {
            return new PointF(a.X - b.X, a.Y - b.Y);
        }

        public static PointF Mul(PointF a, float k)
        {
            return new PointF(a.X * k, a.Y * k);
        }

        public static PointF Mul(float k, PointF p)
        {
            return Mul(p, k);
        }

        public static PointF Div(PointF p, float k)
        {
            return Mul(p, 1.0f / k);
        }

        public static PointF Div(float k, PointF p)
        {
            return Mul(p, 1.0f / k);
        }

        //長さ
        public static float Length(PointF v)
        {
            return (float)Math.Sqrt(LengthSqr(v));
        }

        public static float LengthSqr(PointF v)
        {
            return v.X * v.X + v.Y * v.Y;
        }

        //2点間の距離
        public static float Distance(PointF p1, PointF p2)
        {
            return Length(Sub(p1, p2));
        }

        public static PointF Normalize(PointF p)
        {
            var len = Length(p);

            return Div(p, len);
        }

        public static float Dot(PointF a, PointF b)
        {
            return a.X * b.X + a.Y * b.Y;
        }
    }
}
