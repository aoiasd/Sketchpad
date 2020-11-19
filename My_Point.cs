using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Sketchpad
{
    public class My_Point
    {
        public Point P;
        public bool Live, Act,Hide;//死亡 活跃 隐藏 标记
        public int Kind;//0:自由点  2:中点 3:过某点垂直于某线的点 4:交点 5，6:依附线或圆的点
        public List<int>S;//直接依赖于该点的点
        public List<int>F;//该点直接依赖的点
        public List<int>L;//该点直接依赖的线
        public List<int>C;//该点直接依赖的圆
        public My_Point(Point _P, int _Kind, bool _Live = true, bool _Act = false,bool _Hide = false)
        {
            P = _P;
            Live = _Live;
            Act = _Act;
            Kind = _Kind;
            Hide  = _Hide;
            F = new List<int>();
            S = new List<int>();
            C = new List<int>();
            L = new List<int>();
        }
    }
    public class My_Line
    {
        public int L_Id, R_Id;
        public bool Live,Act,Hide;
        public List<int> S;//依赖于该线的点
        public My_Line(int _L_Id, int _R_Id,bool _Live=true, bool _Act=false, bool _Hide = false)
        {
            S = new List<int>();
            L_Id = _L_Id;
            R_Id = _R_Id;
            Live = _Live;
            Hide = _Hide;
            Act = _Act;
        }
    };
    public class My_Circle
    {
        public int L_Id, R_Id;
        public bool Live, Act;
        public List<int> S;//依赖于该圆的点
        public My_Circle(int _L_Id, int _R_Id, bool _Live = true, bool _Act = false)
        {
            S = new List<int>();
            L_Id = _L_Id;
            R_Id = _R_Id;
            Live = _Live;
            Act = _Act;
        }
    }

    class MyPanel : Panel
    {
        public MyPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
        }

    }
}