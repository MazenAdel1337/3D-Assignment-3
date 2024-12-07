using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
namespace assignment_3_3d
{
     class _3DModel
    {
        public List<_3dpoint> points;
        public List<_2dpoint> points2d;
        public List<edge> Edges;
        public int XB = 0;
        public int YB = 0;
        public PolarCircle circ;
        public Camera cam;
        public _3DModel()
        {
            points = new List<_3dpoint>();
            points2d = new List<_2dpoint>();
            Edges = new List<edge>();
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.ShowDialog();
            /*
            StreamReader sr = new StreamReader("Cube.txt");
            string strPt;
            while ((strPt = sr.ReadLine()) != null)
            {
                if (strPt[0] == 'L')
                    break;

                string[] s = strPt.Split(',');
                float[] v = new float[3];
                for (int i = 0; i < 3; i++)
                { v[i] = int.Parse(s[i]); }
                points.Add(new _3dpoint(v[0], v[1], v[2]));

            }
            while ((strPt = sr.ReadLine()) != null)
            {
                string[] s1 = strPt.Split(',');
                int[] indx = new int[2];
                indx[0] = int.Parse(s1[0]);
                indx[1] = int.Parse(s1[1]);
                Edges.Add(new edge(indx[0], indx[1]));
            }
            sr.Close();
            points2d=Parallel.Get(points);
            */
        }
        public void Draw(Graphics g,Color c)
        {
            int j;
            Pen PP = new Pen(c,2);
            for (int i = 0; i < Edges.Count; i++)
            {
                if (i == 6 || i == 7)
                {
                   
                    edge ptrv = (edge)Edges[i];

                    PointF s = cam.TransformToOrigin_And_Rotate_And_Project((_3dpoint)points[ptrv.e1]);
                    PointF e = cam.TransformToOrigin_And_Rotate_And_Project((_3dpoint)points[ptrv.e2]);
                    circ = new PolarCircle ((int)s.X+XB+16, (int)s.Y+YB , 20);
                    circ.Drawcirc(g, 1, 180, 360);


                }
                else
                {
                    edge ptrv = (edge)Edges[i];

                    PointF s = cam.TransformToOrigin_And_Rotate_And_Project((_3dpoint)points[ptrv.e1]);
                    PointF e = cam.TransformToOrigin_And_Rotate_And_Project((_3dpoint)points[ptrv.e2]);

                    g.DrawLine(PP, s.X + XB, s.Y + YB, e.X + XB, e.Y + YB);
                    g.DrawString(ptrv.e1.ToString(), new Font("Times New Roman", 10), Brushes.Blue, s.X + XB, s.Y + YB);
                }


            }

        }
        
    }
}
