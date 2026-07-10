using System.Diagnostics;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace SquareCommand
{
    public partial class Form1 : Form
    {
        private const int size = 16;

        Point player = new Point(1,1);

        char[][] level;

        



        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            LoadLevelData();
            KeyDown += Form1_KeyDown;
        }

        private void LoadLevelData()
        {
            level = new char[][] {
            new char[]{'#','#','#','#','z','#','#','#' },
            new char[]{'#','.','#','.','.','.','.','#' },
            new char[]{'#','.','#','.','.','.','.','#' },
            new char[]{'z','.','.','.','.','.','.','z' },
            new char[]{'#','.','.','.','.','.','a','#' },
            new char[]{'#','.','.','.','c','a','a','#' },
            new char[]{'#','#','#','z','#','a','#','#' },


        };
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                player.Y--;
            }
            if (e.KeyCode == Keys.S)
            {
                player.Y++;
            }
            if (e.KeyCode == Keys.A)
            {
                player.X--;
            }
            if (e.KeyCode == Keys.D)
            {
                player.X++;
            }
            Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            

            for (int y = 0; y < level.Length; y++)
            {
                // 1 rij horizontaal;
                char[] rij = level[y];
                DrawLevelRow(rij, y, g);
            }
            g.FillEllipse(Brushes.Blue, player.X * 16, player.Y * 16, size, size);
        }

        internal void DrawLevelRow(char[] rij,int y,Graphics g)
        {
            for (int x = 0; x < rij.Length; x++)
            {
                char tile = rij[x];

                Brush tileCol = GetBrushForTile(tile);

                g.FillRectangle(tileCol, x * 16, y * 16, size, size);
            }
        }
        internal Brush GetBrushForTile(char tile)
        {
            Brush tileCol = Brushes.Red;
            if (tile == '#')
            {
                tileCol = Brushes.Brown;
            }
            if (tile == 'z')
            {
                tileCol = Brushes.Black;
            }
            if (tile == 'a')
            {
                tileCol = Brushes.LightBlue;
            }
            if (tile == 'c')
            {
                tileCol = Brushes.Green;
            }
            return tileCol;
        }
    }
}
