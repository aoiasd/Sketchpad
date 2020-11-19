using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections.Specialized;
using Microsoft.VisualBasic;

namespace Sketchpad
{
    public class Geometry //计算几何
    {
        public int min(int A, int B)
        {
            if (A < B) return A; else return B;
        }
        public Point Vector_sub(Point A,Point B)//向量减法
        {
            return new Point(A.X - B.X, A.Y - B.Y);
        }
        public double Dot(Point A, Point B)//向量点乘
        {
            return A.X * B.X + A.Y * B.Y;
        }
        public double Cross(Point A, Point B)//向量叉乘
        {
            return A.X * B.Y - A.Y * B.X; ;
        }
        public double Length_PTP(Point A, Point B)//点到点的距离
        {
            return System.Math.Abs((double)System.Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y)));
        }
        public double Length_PTL(Point A, Point L, Point R)//点到直线的距离
        {
            return System.Math.Abs((double)Cross(Vector_sub(A, L), Vector_sub(R, L)) / Length_PTP(R, L));
        }
        public Point Get_MidPoint(Point A, Point B)//中点
        {
            return new Point((A.X + B.X) / 2, (A.Y + B.Y) / 2);
        }
        public Point Get_PointToCircle(Point O, Point R, Point P)
        {
            double K = Length_PTP(O, R)/ Length_PTP(O, P);
            int A = O.X + (int)((double)(P.X - O.X) * K), B = O.Y + (int)((double)(P.Y - O.Y) * K);
            return new Point(A, B);
        }
        public Point Get_Int(Point A,Point VA,Point B,Point VB)//求直线交点 一个起始点一个向量
        {
            //直线A的方程式 y1=a1x+b1
            double a1=0, a2=0, b1=0, b2=0;
            if (VA.X != 0)
            {
                a1 = (double)VA.Y / (double)VA.X;
                b1 = (double)A.Y - (double)A.X * a1;
            }
            //直线B的方程式
            if (VB.X != 0)
            {
                a2 = (double)VB.Y / (double)VB.X; 
                b2 = (double)B.Y - (double)B.X * (double)a2;
            }
            int X=-1, Y=-1;
            if (VA.X == 0&&VB.X==0)return new Point(X, Y);
            if (VA.X == 0)
            {
                X = (A.X);
                Y = (int)((double)X * a2 + b2);
            }
            else
            if (VB.X == 0)
            {
                X = (B.X);
                Y = (int)((double)X * a1 + b1);
            }
            else
            if (Math.Abs(a1 - a2)>= 1e-2) 
            {
                X = (int)((b2 - b1) / (a1 - a2));
                Y = (int)((b2 - b1) / (a1 - a2) * a1 + b1); 
            }
            return new Point(X, Y);
        }
        public Point Get_VerticalLine(Point A, Point B, Point C)//求C在直线AB上的垂点
        {
            Point E = new Point(B.Y - A.Y,-(B.X - A.X));//直线B-A的垂向量
            return Get_Int(C,E,A,Vector_sub(B,A));
        }

    }
}
