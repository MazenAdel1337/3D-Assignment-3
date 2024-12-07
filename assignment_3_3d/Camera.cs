using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace assignment_3_3d
{
    class Camera
    {
        public _3dpoint cop;
        public _3dpoint lookAt;
        public _3dpoint up;
        public double  front, back;

        public float focal = 2;


        // vectors
        public _3dpoint basisa, lookDir, basisc;

        public int ceneterX, ceneterY;
        public int cxScreen, cyScreen;

        public Camera()
        {
            cop = new _3dpoint(0, 0, -550); // new Point3D(0, -50, 0);
            lookAt = new _3dpoint(0, 0, 50);     //new Point3D(0, 50, 0);
            up = new _3dpoint(0, 1, 0);
            front = 10; // 70.0;
            back = 300.0;
        }

        public void BuildNewSystem()
        {
            lookDir = new _3dpoint(0, 0, 0);
            basisa = new _3dpoint(0, 0, 0);
            basisc = new _3dpoint(0, 0, 0);

            lookDir.x = lookAt.x - cop.x;
            lookDir.y = lookAt.y - cop.y;
            lookDir.z = lookAt.z - cop.z;
            Matrix.Normalise(lookDir);

            basisa = Matrix.CrossProduct(up, lookDir);
            Matrix.Normalise(basisa);

            basisc = Matrix.CrossProduct(lookDir, basisa);
            Matrix.Normalise(basisc);
        }

        public void TransformToOrigin_And_Rotate(_3dpoint a, _3dpoint e)
        {
            _3dpoint w = new _3dpoint(a.x , a.y , a.z);
            w.x -= cop.x;
            w.y -= cop.y;
            w.z -= cop.z;

            e.x = w.x * basisa.x + w.y * basisa.y + w.z * basisa.z;
            e.y = w.x * basisc.x + w.y * basisc.y + w.z * basisc.z;
            e.z = w.x * lookDir.x + w.y * lookDir.y + w.z * lookDir.z;            
        }
       
        public PointF TransformToOrigin_And_Rotate_And_Project(_3dpoint w1)
        {
            _3dpoint e1, n1;
            e1 = new _3dpoint(0, 0, 0);
            n1 = new _3dpoint(0, 0, 0);

            TransformToOrigin_And_Rotate(w1, e1);
            Parallel.DoPrespectiveProjection(e1, n1, focal);

            // view mapping
            n1.x = (int)(ceneterX + cxScreen * n1.x / 2);
            n1.y = (int)(ceneterY - cyScreen * n1.y / 2);

            return new PointF((float)n1.x, (float)n1.y);
        }
    }
}
