using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_3_3d
{
    class Transform
    {
        public Transform()
        {
        }
        public static void Scale(_3DModel a, float sx, float sy, float sz)
        {
            for (int i = 0; i < a.points.Count; i++)
            {
                a.points[i].x *=sx;
                a.points[i].y *= sy;
                a.points[i].z *= sz;

            }
        }
        public static void Translate(_3DModel a,float xr,float yr,float zr)
        {
            for (int i = 0; i < a.points.Count; i++)
            {
                a.points[i].x += xr;
                a.points[i].y += yr;
                a.points[i].z += zr;

            }
        }
        public static void Rotatex(_3DModel a,double theta)
        {
            //theta = (float)(theta * Math.PI / 180.0);
            for (int i = 0; i < a.points.Count; i++)
            {
                double y1=((a.points[i].y)*Math.Cos(theta));
                double z1=((a.points[i].z)* Math.Sin(theta));

                double z2 = ((a.points[i].z) * Math.Cos(theta));
                double y2 = ((a.points[i].y) * Math.Sin(theta));
                a.points[i].y = (float)(y1 - z1);
                a.points[i].z = (float)(y2 + z2);
            }
        }
        public static void Rotatey(_3DModel a, double theta)
        {
            //theta = (float)(theta * Math.PI / 180.0);
            for (int i = 0; i < a.points.Count; i++)
            {
                double z1 = ((a.points[i].z) * Math.Cos(theta));
                double x1 = ((a.points[i].x) * Math.Sin(theta));

                double x2 = ((a.points[i].x) * Math.Cos(theta));
                double z2 = ((a.points[i].z) * Math.Sin(theta));
                a.points[i].z = (float)(z1 - x1);
                a.points[i].x = (float)(x2 + z2);
            }
        }
        public static void Rotatez(_3DModel a, double theta)
        {
            //theta = (float)(theta * Math.PI / 180.0);

            for (int i = 0; i < a.points.Count; i++)
            {
                double x1 = ((a.points[i].x) * Math.Cos(theta));
                double y1 = ((a.points[i].y) * Math.Sin(theta));

                double y2 = ((a.points[i].y) * Math.Cos(theta));
                double x2 = ((a.points[i].x) * Math.Sin(theta));
                a.points[i].x = (float)(x1 - y1);
                a.points[i].y = (float)(x2 + y2);
            }
        }
        public static void Rotateall(_3DModel a, _3dpoint p1, _3dpoint p2, int sign)
        {
            double oldx = p1.x;
            double oldy = p1.y;
            double oldz = p1.z;
            Translate(a, (float)-(p1.x), (float)-(p1.y), (float)-(p1.z));

            double v1 = p1.x - p2.x;
            double v2 = p1.y - p2.y;
            double v3 = p1.z - p2.z;
            double theta=Math.Atan2(v2, v1);
            //theta = (float)(theta * Math.PI / 180.0);
            double sq= Math.Sqrt((v2*v2)+(v1*v1));
            double phi = Math.Atan2(sq, v3);
            //phi = (float)(phi * Math.PI / 180.0);
            Rotatez(a, -theta);
            Rotatey(a, -phi);
            Rotatez(a, (sign*0.1));
            Rotatey(a, phi);
            Rotatez(a, theta);
            Translate(a, (float)oldx, (float)oldy, (float)oldz);
        }
    }
}
