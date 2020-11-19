using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sketchpad
{
    //废案 查找时能容忍三像素点的误差，BST只支持精确查找
    public class BST//二叉搜索树用于储存Point(理论上LCT更优，但是在小数据下差异不大)
    {
        public int[] Fa;
        public int[,] Ch;
        public My_Point[] Point_List;
        Stack<int> Point_List_recycle;
        int Point_sum = 1;
        int root = 0,num=0;
        public void init(int x)
        {
            Point_List_recycle = new Stack<int>();
            Point_List = new My_Point[x];
            Ch = new int[x,2];
            Fa = new int[x];
            Point_List_recycle = new Stack<int>();
        }
        private void Insert_Tree(int id)
        {
            Point P = Point_List[id].P;
            if (num == 0) root = id;else
            {
                int x = root,s = (Point_List[x].P.X < P.X || (Point_List[x].P.X == P.X && Point_List[x].P.Y <= P.Y) ? 0 : 1);
                while (Ch[x,s] != 0)
                {
                    x = Ch[x, s];
                    s= (Point_List[x].P.X < P.X || (Point_List[x].P.X == P.X && Point_List[x].P.Y <= P.Y) ? 0 : 1);
                }
                Ch[x, s] = id;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private int find(int x, int y, int n)
        {
            return 0;
        }
        public void Insert(Point _P, int _Kind,bool _Live = true, bool _Act = true)
        {
            if (Point_List_recycle.Count() > 0)
            {
                int lo = Point_List_recycle.Pop();
                Point_List[lo] = new My_Point(_P, _Kind, _Live, _Act);
            }
            else
            { 
                Point_List[++Point_sum]= new My_Point(_P, _Kind, _Live, _Act);
            }
        }
    }
}
