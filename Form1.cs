using Sketchpad.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Specialized;

namespace Sketchpad
{
    public partial class Form1 : Form
    {
        My_Point[] Point_List;
        My_Circle[] Circle_List;
        My_Line[] Line_List;//手动list
        Stack<int> Point_List_recycle,Line_List_recycle, Circle_List_recycle;
        Stack<int> Chosed_Point, Chosed_Line;
        int mouse_state = 0;
        int Line_Sum = 0, Point_Sum = 0, Circle_Sum = 0;//队列尾指针
        int mouse_Point = -1,mouse_Line = -1,mouse_Circle=-1,Move_now =-1,Delete_One;
        Graphics Gra;
        Geometry Math;
        Image Image_point, Image_point_L;
        public Pen Pen_Black = new Pen(Color.Black, 1);
        public Pen Pen_Red = new Pen(Color.Red, 2);
        // 删除操作
        void Point_Delete(int X)
        {
            for (int i = 0; i < Point_List[X].F.Count; i++)//从父亲点中删去该点
                Point_List[Point_List[X].F[i]].S.Remove(X);
            for (int i = 0; i < Point_List[X].L.Count; i++)
                Line_List[Point_List[X].L[i]].S.Remove(X);//同时从该点依赖的线中删除他
            for (int i = 0; i < Point_List[X].C.Count; i++)
                Circle_List[Point_List[X].L[i]].S.Remove(X);
            Point_List[X].Live = false;Point_List_recycle.Push(X);
            for (int i = 0; i < Point_List[X].S.Count; i++)
                Point_Delete(Point_List[X].S[i]);
        }
        void Line_Delete(int X)
        {
            Line_List[X].Live = false;Line_List_recycle.Push(X);//删除线
        }
        void Circle_Delete(int X)
        {
            Circle_List[X].Live = false; Circle_List_recycle.Push(X);//删除线
        }
        //点更新
        void Point_refresh(int X)
        {
            if (Point_List[X].Kind == 2)
            {
                Point_List[X].P = Math.Get_MidPoint(Point_List[Point_List[X].F[0]].P, Point_List[Point_List[X].F[1]].P);
            }
            else
            if (Point_List[X].Kind == 3)
            {
                Point A = Point_List[Point_List[X].F[0]].P, B = Point_List[Point_List[X].F[1]].P;
                Point C = Point_List[Point_List[X].F[2]].P;
                Point_List[X].P = Math.Get_VerticalLine(A, B, C);
            }
            else
            if (Point_List[X].Kind == 4)
            {
                Point A = Point_List[Point_List[X].F[0]].P, B = Point_List[Point_List[X].F[1]].P;
                Point C = Point_List[Point_List[X].F[2]].P, D = Point_List[Point_List[X].F[3]].P;
                Point_List[X].P = Math.Get_Int(A, Math.Vector_sub(B, A), C, Math.Vector_sub(D, C));
            }
            else
            if (Point_List[X].Kind == 5)
            {
                Point A = Point_List[Point_List[X].F[0]].P, B = Point_List[Point_List[X].F[1]].P;
                Point C = Point_List[X].P;
                Point_List[X].P = Math.Get_VerticalLine(A, B, C);
            }else 
            if (Point_List[X].Kind == 6)
            {
                Point O = Point_List[Point_List[X].F[0]].P, R = Point_List[Point_List[X].F[1]].P;
                Point C = Point_List[X].P;
                Point_List[X].P = Math.Get_PointToCircle(O, R, C);
            }

            for (int i=0;i<Point_List[X].S.Count;i++)
                Point_refresh(Point_List[X].S[i]);
        }
        //添加操作
        int Insert_Point(Point _P, int _Kind, int _l = 0, int _r = 0, bool _Live = true, bool _Act = false,bool _Arrow= false)//添加点
        {
            int lo;
            if (Point_List_recycle.Count() > 0)
            {
                lo = Point_List_recycle.Pop();
                Point_List[lo] = new My_Point(_P, _Kind, _Live, _Act);
            }
            else
            {
                Point_List[Point_Sum++] = new My_Point(_P, _Kind, _Live, _Act);
                lo = Point_Sum - 1;
            }
            if (_Kind == 2)//中点
            {
                int F1 = Line_List[_l].L_Id, F2 = Line_List[_l].R_Id;
                Point_List[lo].F.Add(F1); Point_List[lo].F.Add(F2);
                Point_List[F1].S.Add(lo); Point_List[F2].S.Add(lo);
                Point_List[lo].L.Add(_l); Line_List[_l].S.Add(lo);
            }
            else
            if (_Kind == 3)//垂线
            {
                int F1 = Line_List[_l].L_Id, F2 = Line_List[_l].R_Id;
                Point_List[lo].F.Add(F1); Point_List[lo].F.Add(F2); Point_List[lo].F.Add(_r);
                Point_List[F1].S.Add(lo); Point_List[F2].S.Add(lo); Point_List[_r].S.Add(lo);
                Point_List[lo].L.Add(_l); Line_List[_l].S.Add(lo);
            }
            else
            if (_Kind == 4)//交点
            {
                int F1 = Line_List[_l].L_Id, F2 = Line_List[_l].R_Id;
                int F3 = Line_List[_r].L_Id, F4 = Line_List[_r].R_Id;
                Point_List[lo].F.Add(F1); Point_List[lo].F.Add(F2); Point_List[lo].F.Add(F3); Point_List[lo].F.Add(F4);
                Point_List[F1].S.Add(lo); Point_List[F2].S.Add(lo); Point_List[F3].S.Add(lo); Point_List[F4].S.Add(lo);
                Point_List[lo].L.Add(_l); Point_List[lo].L.Add(_r);
                Line_List[_l].S.Add(lo); Line_List[_r].S.Add(lo);
            }
            else
            if (_Kind == 5)//依附于直线
            {
                int F1 = Line_List[_l].L_Id, F2 = Line_List[_l].R_Id;
                Point_List[lo].F.Add(F1); Point_List[lo].F.Add(F2);
                Point_List[F1].S.Add(lo); Point_List[F2].S.Add(lo);
                Point_List[lo].L.Add(_l); Line_List[_l].S.Add(lo);
            }
            else
            if (_Kind == 6)//依附于圆
            {
                int F1 = Circle_List[_l].L_Id, F2 = Circle_List[_l].R_Id;
                Point_List[lo].F.Add(F1); Point_List[lo].F.Add(F2);
                Point_List[F1].S.Add(lo); Point_List[F2].S.Add(lo);
                Point_List[lo].C.Add(_l); Circle_List[_l].S.Add(lo);
            }
            return lo;
        }
        int Insert_Line(int l, int r)//添加线
        {
            if (Line_List_recycle.Count() > 0)
            {
                int lo = Line_List_recycle.Pop();
                Line_List[lo] = new My_Line(l, r);
                return lo;
            }
            else
            {
                Line_List[Line_Sum++] = new My_Line(l,r);
                return Line_Sum - 1;
            }
        }
        int Insert_Circle(int l, int r)//添加圆
        {
            if (Circle_List_recycle.Count() > 0)
            {
                int lo = Circle_List_recycle.Pop();
                Circle_List[lo] = new My_Circle(l, r);
                return lo;
            }
            else
            {
                Circle_List[Circle_Sum++] = new My_Circle(l, r);
                return Circle_Sum - 1;
            }
        }
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            Point_List_recycle = new Stack<int>();
            Line_List_recycle = new Stack<int>();
            Circle_List_recycle = new Stack<int>();
            Chosed_Line = new Stack<int>();
            Chosed_Point = new Stack<int>();
            Math = new Geometry();
            Image_point = Resources.point;
            Image_point_L = Resources.pointL;
            Point_List = new My_Point[10000];
            Line_List = new My_Line[10000];
            Circle_List = new My_Circle[10000];
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.DoubleBuffer, true);
        }
        //界面刷新
        private void panel1_Paint(object sender, PaintEventArgs e)//界面刷新
        {
            Gra = e.Graphics;
            Gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int i = 0; i < Line_Sum; i++)
            {
                if (Line_List[i].Live)
                {
                    if (!Point_List[Line_List[i].L_Id].Live || !Point_List[Line_List[i].R_Id].Live) Line_Delete(i);//如果端点已删除则删除线;
                    if(!Line_List[i].Act&&i!=mouse_Line)
                    Gra.DrawLine(Pen_Black, Point_List[Line_List[i].L_Id].P, Point_List[Line_List[i].R_Id].P);//未选中的线
                    else
                    Gra.DrawLine(Pen_Red, Point_List[Line_List[i].L_Id].P, Point_List[Line_List[i].R_Id].P);//选中的线
                }
            }
            for (int i = 0; i < Circle_Sum; i++)
            {
                if (Circle_List[i].Live)
                {
                    Point P1 = Point_List[Circle_List[i].L_Id].P, P2 = Point_List[Circle_List[i].R_Id].P;
                    int Len = (int)((Math.Length_PTP(P1,P2)));
                    if (!Point_List[Circle_List[i].L_Id].Live || !Point_List[Circle_List[i].R_Id].Live) Circle_Delete(i);//如果端点已删除则删除线;
                    if (!Circle_List[i].Act&&i!=mouse_Circle)Gra.DrawEllipse(Pen_Black,P1.X-Len,P1.Y-Len,Len*2, Len*2);//未选中的线
                    else Gra.DrawEllipse(Pen_Red, P1.X - Len, P1.Y - Len, Len * 2, Len * 2);
                }
            }
            for (int i = 0; i < Point_Sum; i++)
            {
                if (Point_List[i].Live&&!Point_List[i].Hide)
                {
                    if (!Point_List[i].Act && i != mouse_Point)
                        Gra.DrawImage(Image_point, Point_List[i].P.X - 2, Point_List[i].P.Y - 2);
                    else
                        Gra.DrawImage(Image_point_L, Point_List[i].P.X - 4, Point_List[i].P.Y - 4);
                }
            }
            //DeBug
        }
        //查找操作
        int Find_Point(Point P,int excpt =-1)
        {
            for (int i = 0; i < Point_Sum; i++)
            if(i!=excpt && Point_List[i].Live && !Point_List[i].Hide)
            {
                if (Math.Length_PTP(P, Point_List[i].P) < 3) return i;
            }
            return -1;
        }
        int Find_Circle(Point P)
        {
            for (int i = 0; i < Circle_Sum; i++)
                if (Circle_List[i].Live)
                    if (System.Math.Abs(Math.Length_PTP(P, Point_List[Circle_List[i].L_Id].P)- Math.Length_PTP(Point_List[Circle_List[i].L_Id].P, Point_List[Circle_List[i].R_Id].P)) < 2.0) return i;
            return -1;
        }

        int Find_Line(Point P)
        {
            for (int i = 0; i < Line_Sum; i++)
                if (Line_List[i].Live && !Line_List[i].Hide)
                {
                    if (Math.Length_PTL(P, Point_List[Line_List[i].L_Id].P, Point_List[Line_List[i].R_Id].P) < 2) return i;
                }
            return -1;
        }
        //功能
        private void 中点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             int F = Chosed_Line.Peek();
             My_Line X = Line_List[F];
             Point A = Point_List[X.L_Id].P, B = Point_List[X.R_Id].P;
             Point L = Math.Get_MidPoint(A,B);
             Insert_Point(L, 2, F);
        }

        private void 垂线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My_Line X = Line_List[Chosed_Line.Peek()];
            Point A = Point_List[X.L_Id].P, B = Point_List[X.R_Id].P;
            Point C = Point_List[Chosed_Point.Peek()].P;
            Point L = Math.Get_VerticalLine(A, B, C);
            int l = Insert_Point(L, 3, Chosed_Line.Peek(), Chosed_Point.Peek()) ;
            Insert_Line(l, Chosed_Point.Peek());
        }

        private void 交点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int l = Chosed_Line.Pop(),r = Chosed_Line.Peek();Chosed_Line.Push(l);
            Point A = Point_List[Line_List[l].L_Id].P, B = Point_List[Line_List[l].R_Id].P;
            Point C = Point_List[Line_List[r].L_Id].P, D = Point_List[Line_List[r].R_Id].P;
            Point L = Math.Get_Int(A, Math.Vector_sub(B, A), C, Math.Vector_sub(D, C));
            int p=Insert_Point(L, 4, l, r);
            if (L.X == -1 && L.Y == -1) Point_List[p].Hide=true;

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                while (Chosed_Point.Count != 0)
                {
                    int V = Chosed_Point.Pop();
                    Point_Delete(V);
                }
                while (Chosed_Line.Count != 0)
                {
                    int V = Chosed_Line.Pop();
                    Line_Delete(V);
                }
                panel1.Refresh();
            }
        }
        //按钮
        private void button_Point_Click(object sender, EventArgs e)
        {
            mouse_state = 1;
        }
        private void button_Line_Click(object sender, EventArgs e)
        {
            mouse_state = 2;
        }

        private void button_Arrow_Click(object sender, EventArgs e)
        {
            mouse_state = 0;
        }
        private void button_Circle_Click(object sender, EventArgs e)
        {
            mouse_state = 3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        //鼠标动作
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
                contextMenuStrip1.Show(new Point(e.X + this.Location.X, e.Y + this.Location.Y));
                //
            }
            if (e.Button == MouseButtons.Left)
            {
                if (mouse_state == 0)
                {
                    if (mouse_Point != -1)
                    {
                        Point_List[mouse_Point].Act = true;
                        Chosed_Point.Push(mouse_Point);
                    }
                    else 
                    if (mouse_Line != -1)
                    {
                        Line_List[mouse_Line].Act = true;
                        Chosed_Line.Push(mouse_Line);
                    }
                    else
                    {
                        while (Chosed_Line.Count != 0) Line_List[Chosed_Line.Pop()].Act=false;
                        while (Chosed_Point.Count != 0) Point_List[Chosed_Point.Pop()].Act = false;
                    }
                    if (Chosed_Line.Count == 1 && Chosed_Point.Count == 0) 中点ToolStripMenuItem.Visible = true; else 中点ToolStripMenuItem.Visible = false;
                    if (Chosed_Line.Count == 2 && Chosed_Point.Count == 0) 交点ToolStripMenuItem.Visible = true; else 交点ToolStripMenuItem.Visible = false;
                    if (Chosed_Line.Count == 1 && Chosed_Point.Count == 1) 垂线ToolStripMenuItem.Visible = true; else 垂线ToolStripMenuItem.Visible = false;
                }
                else if (mouse_state == 1)
                {
                    Gra = this.panel1.CreateGraphics();
                    Point L = new Point(); L.X = e.X; L.Y = e.Y;
                   // Gra.DrawImage(Image_point, L.X-2,L.Y-2);
                    int F=Find_Line(L);
                    if (F != -1) Insert_Point(L, 5, F);
                    else
                    {
                        F = Find_Circle(L);
                        if (F != -1) Insert_Point(L, 6, F);else Insert_Point(L, 0);
                    }
                    panel1.Refresh();

                }else if (mouse_state == 2)
                {
                    Gra = this.panel1.CreateGraphics();
                    Point L = new Point(); L.X = e.X; L.Y = e.Y;
                    int l = Find_Point(L), r = Insert_Point(L, 0);
                    if (l == -1)l = Insert_Point(L, 0);
                    Move_now=Insert_Line(l, r);
                    mouse_Point = r;
                } else if (mouse_state == 3)
                {
                    Gra = this.panel1.CreateGraphics();
                    Point L = new Point(); L.X = e.X; L.Y = e.Y;
                    int l = Find_Point(L), r = Insert_Point(L, 0);
                    if (l == -1) l = Insert_Point(L, 0);
                    Move_now = Insert_Circle(l, r);
                    mouse_Point = r;
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (mouse_Point != -1)
                {
                    Point_List[mouse_Point].P.X = e.X;
                    Point_List[mouse_Point].P.Y = e.Y;
                    if (mouse_state == 2)
                    {
                        int r = Find_Point(Point_List[mouse_Point].P, mouse_Point);
                        if (r != -1){
                            Line_List[Move_now].R_Id = r;
                            Point_List[mouse_Point].Hide = true;
                            Delete_One = mouse_Point;
                        }
                        else { 
                            Line_List[Move_now].R_Id = mouse_Point;
                            Point_List[mouse_Point].Hide = false;
                            Delete_One = -1;
                        }
                    }
                    else if(mouse_state == 3)
                    {
                        int r = Find_Point(Point_List[mouse_Point].P, mouse_Point);
                        if (r != -1)
                        {
                            Circle_List[Move_now].R_Id = r;
                            Point_List[mouse_Point].Hide = true;
                            Delete_One = mouse_Point;
                        }
                        else
                        {
                            Circle_List[Move_now].R_Id = mouse_Point;
                            Point_List[mouse_Point].Hide = false;
                            Delete_One = -1;
                        }
                    }
                    Point_refresh(mouse_Point);
                    panel1.Refresh();
                }
            }
            else 
            {
                int lo = Find_Point(new Point(e.X, e.Y));
                mouse_Point = lo;
                if (lo != -1) { mouse_Line = -1; mouse_Circle = -1; }
                else
                {
                    lo = Find_Line(new Point(e.X, e.Y));
                    mouse_Line = lo;
                    if (lo != -1) { mouse_Point = -1; mouse_Circle = -1; }
                    else
                    {
                        lo = Find_Circle(new Point(e.X, e.Y));
                        mouse_Circle = lo;
                    }
                }
                panel1.Refresh();
            }
         }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//连线时尾点和其他点重合，删除多余的点
            {
                if (mouse_state == 2&&Delete_One!=-1)
                {
                    Point_Delete(Delete_One);
                    Delete_One = -1;
                }
                if (mouse_state == 3 && Delete_One != -1)
                {
                    Point_Delete(Delete_One);
                    Delete_One = -1;
                }
            }
        }
    }
}
