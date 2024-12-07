using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment_3_3d
{
    public partial class Form1 : Form
    {
        Camera cam = new Camera();

        int speed = 5;
        Bitmap tmp;
        Timer t = new Timer();
        Color[] c = new Color[8];
        List<_3DModel> cubes = new List<_3DModel>();
        _3DModel Big = new _3DModel();
        _3DModel Big2 = new _3DModel();
        int flag1 = 0;
        int flag2 = 0;
        int fr = 0;
        int fl = 0;
        int movez = -5;
        int movez2 = -5;
        int ct = 0;
        int ct2 = 0;
        int movep = 5;
        int ctp = -280;
        int flag_arrived = 0;
        public Form1()
        {
            WindowState = FormWindowState.Maximized;
            KeyDown += Form1_KeyDown;
            t.Tick += T_Tick;
            t.Start();
            Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            tmp = new Bitmap(ClientSize.Width, ClientSize.Height);


            cam.ceneterX = 500;
            cam.ceneterY = 500;
            cam.cxScreen = 200;
            cam.cyScreen = 200;



            CreateCuboid(Big, 500, 700, 500, 500, 500, 500, Color.Black);
            CreateCuboid(Big2, 1200, 1500, 500, 500, 500, 500, Color.Green);


            c[0] = Color.Red;
            c[7] = Color.Gray;
            Big.cam = cam;
            Big2.cam = cam;

            cam.BuildNewSystem();

            DrawDBuff(CreateGraphics());
        }

        private void T_Tick(object sender, EventArgs e)
        {
            DrawDBuff(CreateGraphics());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    cam.cop.z += speed;
                    break;
                case Keys.Down:
                    cam.cop.z -= speed;
                    break;

                case Keys.Right:
                    cam.cop.x += speed;
                    break;
                case Keys.Left:
                    cam.cop.x -= speed;
                    break;

                case Keys.Y:
                    cam.cop.y += speed;
                    break;
                case Keys.H:
                    cam.cop.y -= speed;
                    break;
                case Keys.A:
                    Transform.Translate(cubes[cubes.Count - 1], cubes[cubes.Count - 1].XB - 5, 0, 0);
                    break;
                case Keys.D:
                    Transform.Translate(cubes[cubes.Count - 1], cubes[cubes.Count - 1].XB + 5, 0, 0);
                    break;


            }
            cam.BuildNewSystem();
        }
        void CreateCuboid(_3DModel M,
                         float XLeft, float wWidth,
                         float YBottom, float hHight,
                         float ZS, float Depth,
                         Color vvv)
        {
            float[] vert =
                            {
                                    XLeft+wWidth            ,YBottom + hHight       ,ZS, //0
                                    XLeft+wWidth            ,YBottom + hHight       ,ZS+Depth,//1
                                    XLeft                   ,YBottom + hHight       ,ZS+Depth,//2
                                    XLeft                   ,YBottom + hHight       ,ZS,//3
                                    XLeft+wWidth            ,YBottom                ,ZS,//4
                                    XLeft+wWidth            ,YBottom                ,ZS+Depth,//5
                                    XLeft                   ,YBottom                ,ZS+Depth,//6
                                    XLeft                   ,YBottom                ,ZS,//7
                                    XLeft+200                 ,YBottom                ,ZS,//8
                                    XLeft+200            ,YBottom                ,ZS+Depth,//9
                                    XLeft+400             ,YBottom                ,ZS,//10
                                    XLeft+400             ,YBottom                ,ZS+Depth//11

                            };


            _3dpoint pnn;
            int j = 0;
            for (int i = 0; i < (vert.Length / 3); i++)
            {
                pnn = new _3dpoint(vert[j], vert[j + 1], vert[j + 2]);
                j += 3;
                M.points.Add(pnn);
            }


            int[] Edges = {
                                0,1,
                                1,2,
                                2,3,
                                3,0,
                                4,5,
                                9,6,
                                8,10,//6
                                9,11,//7
                                11,5,
                                6,7,
                                8,9,
                                10,11,
                                10,4,
                                7,8,
                                0,4,
                                3,7,
                                2,6,
                                1,5
                          };
            j = 0;
            //Color[] cl = { Color.Red, Color.Yellow, Color.Black, Color.Blue };
            for (int i = 0; i < Edges.Length; i++)
            {
                M.Edges.Add(new edge(Edges[i], Edges[i + 1])); //cl[i % 4]);

                i++;
            }
        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.LightGray);
            int j = 0;
            for (int i = 0; i < cubes.Count; i++)
            {
                cubes[i].Draw(g, c[0]);

            }


            Big2.Draw(g, c[7]);
            Big.Draw(g, c[7]);


        }
        void DrawDBuff(Graphics G)
        {
            Graphics G2 = Graphics.FromImage(tmp);
            DrawScene(G2);
            G.DrawImage(tmp, 0, 0);
        }
    }
}
