using System.Windows.Forms.ComponentModel.Com2Interop;

namespace SquareCommand
{
    public partial class Form1 : Form
    {
        private const int size = 16;

        char[][] level = new char[][] {
            new char[] { '#', '#', '#', '#', '.', '.', '#' },
            new char[] { '#', '.', '.', '#', '.', '.', '#' },
            new char[] { '#', '.', '.', '#', '.', '#', '#' },
            new char[] { '#', '.', '.', '#', '.', '.', '#' },
            new char[] { '#', '.', '.', '#', '.', '.', '#' },
            new char[] { '#', '.', '.', '.', '.', '.', '#' },
            new char[] { '#', '.', '.', '.', '.', '.', '#' }

    };
            
            

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            string testString = "hier";
            int length = testString.Length;

            char[] testStringAsArray = new char[] { 'h', 'i', 'e', 'r' };

            double cijfer = 6.5;
            double[] cijferlijst = { 6.5, 8.5, 5.5 };

            string[] enemyNames = new string[10];

            double gemiddeld = 0;

            for (int i = 0; i < cijferlijst.Length; i++)
            {
                gemiddeld += cijferlijst[i];
            }
            gemiddeld /= cijferlijst.Length;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            for (int y = 0; y < level.Length; y++)
            {
                char[] lijstjeErin = level[y];


                for (int x = 0; x < lijstjeErin.Length; x++)
                {
                    char tile = lijstjeErin[x];
                    if (tile == '#')
                    {
                        e.Graphics.FillRectangle(Brushes.Red, x * size,y*size, size, size);

                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, x * size, y * size, size, size);

                    }
                }
            }
        }
    }
}
