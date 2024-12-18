﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace assignment_3_3d
{
    class Matrix
    {
        static public void Normalise(_3dpoint v)
        {
            float length;

            length = (float)Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
            v.x /= length;
            v.y /= length;
            v.z /= length;
        }

        static public _3dpoint CrossProduct(_3dpoint p1, _3dpoint p2)
        {
            _3dpoint p3;
            p3 = new _3dpoint(0, 0, 0);
            p3.x = p1.y * p2.z - p1.z * p2.y;
            p3.y = p1.z * p2.x - p1.x * p2.z;
            p3.z = p1.x * p2.y - p1.y * p2.x;
            return p3;
        }
    }
}
