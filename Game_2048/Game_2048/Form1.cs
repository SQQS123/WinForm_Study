using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_2048
{
    public partial class Form1 : Form
    {
        //试试能不能画出来2048的画板
        private int[,] map = new int[4,4];
        //画板
        private Graphics gp = null;
        //用位图做画板
        private Image image = null;
        //游戏项大小
        private const int ITEMSIZE = 80;
        public Form1()
        {
            InitializeComponent();
            //初始化画板
            image = new Bitmap(ITEMSIZE * 4 + 5 * 8, ITEMSIZE * 4 + 5 * 8);
            gp = Graphics.FromImage(image);
            picMap.Image = DrawMap();
        }

        public Image DrawMap()
        {
            //清空画板原有内容
            gp.Clear(Color.DarkGray);
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    DrawItem(r, c, GetColor(map[r,c]));
                }
            }
            return image;
        }

        public Image GetColor(int num)
        {
            return Properties.Resources.
                      ResourceManager.
                      GetObject("_" + num.ToString()) as Image;
        }

        private void DrawItem(int rowindex, int columnIndex, Image img)
        {
            //画在哪 rowindex columnindex
            int x = (columnIndex + 1) * 8 + columnIndex * ITEMSIZE;

            int y = (rowindex + 1) * 8 + rowindex * ITEMSIZE;

            //绘制内容img                       画多大 itemSize
            gp.DrawImage(img, x, y, ITEMSIZE, ITEMSIZE);
        }

    }
}
