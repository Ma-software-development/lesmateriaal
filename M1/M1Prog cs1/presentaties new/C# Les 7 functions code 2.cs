using System.Diagnostics;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace SquareCommand
{
    public partial class Form1 : Form
    {
        private const int size = 16;
        Point player;



        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            KeyDown += Form1_KeyDown;
        }


        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            for (int i = 0; i < size; i++)
            {
                DrawTriangle(g, 0 + (i * 50), 10);
            }
        }

        internal bool HasCollision(Point gameObject, Rectangle wall)
        {

            bool collisionDetected = wall.Contains(gameObject);
            return collisionDetected;
        }
        internal void DrawTriangle(Graphics g, int x, int y)
        {

            g.DrawLine(Pens.Black, x + 0, y + 0, x + 100, y + 0);
            g.DrawLine(Pens.Black, x + 100, y + 0, x + 100, y + 100);
            g.DrawLine(Pens.Black, x + 100, y + 100, x + 0, y + 0);
        }
    }
}
