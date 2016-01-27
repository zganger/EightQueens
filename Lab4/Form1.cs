using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private ArrayList coordinates = new ArrayList();
        private int totalQueens = 0;
        private bool hints = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int y = (50 * i + 100);
                    int x = (50 * j + 100);
                    space boardSpace = new space(x, y, i, j);
                    coordinates.Add(boardSpace);
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.DrawString("Queen Count: " + totalQueens, Font, Brushes.Black, 140, 17);
            for(int i = 0; i < 64; i++)
            {
                space drawSpace = ((space)coordinates[i]);
                Rectangle rect = drawSpace.getRect();
                int X = drawSpace.getX();
                int Y = drawSpace.getY();
                if ((i / 8) % 2 == 0)
                {
                    if (i % 2 == 0)
                    {
                        if (!hints)
                        {
                            g.FillRectangle(Brushes.Black, rect);
                            g.DrawRectangle(Pens.Black, rect);
                            if (drawSpace.isOccupied())
                            {
                                Font useThis = new Font("Arial", 32);
                                g.DrawString("Q", useThis, Brushes.White, X, Y);
                            }
                        }
                        else
                        {
                            if (!drawSpace.isValid(coordinates))
                            {
                                g.FillRectangle(Brushes.Red, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    Font useThis = new Font("Arial", 32);
                                    g.DrawString("Q", useThis, Brushes.White, X, Y);
                                }
                            }
                            else
                            {
                                g.FillRectangle(Brushes.Black, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    Font useThis = new Font("Arial", 32);
                                    g.DrawString("Q", useThis, Brushes.White, X, Y);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!hints)
                        {
                            g.FillRectangle(Brushes.White, rect);
                            g.DrawRectangle(Pens.Black, rect);
                            if (drawSpace.isOccupied())
                            {
                                Font useThis = new Font("Arial", 32);
                                g.DrawString("Q", useThis, Brushes.Black, X, Y);
                            }
                        }
                        else
                        {
                            if (!drawSpace.isValid(coordinates))
                            {
                                g.FillRectangle(Brushes.Red, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    Font useThis = new Font("Arial", 32);
                                    g.DrawString("Q", useThis, Brushes.White, X, Y);
                                }
                            }
                            else
                            {
                                g.FillRectangle(Brushes.White, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    Font useThis = new Font("Arial", 32);
                                    g.DrawString("Q", useThis, Brushes.Black, X, Y);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (i % 2 == 1)
                    {
                        if (!hints)
                        {
                            g.FillRectangle(Brushes.Black, rect);
                            g.DrawRectangle(Pens.Black, rect);
                            if (drawSpace.isOccupied())
                            {
                                Font useThis = new Font("Arial", 32);
                                g.DrawString("Q", useThis, Brushes.White, X, Y);
                            }
                        }
                        else
                        {
                            if (!drawSpace.isValid(coordinates))
                            {
                                g.FillRectangle(Brushes.Red, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    Font useThis = new Font("Arial", 32);
                                    g.DrawString("Q", useThis, Brushes.White, X, Y);
                                }
                            }
                            else
                            {
                                g.FillRectangle(Brushes.Black, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    Font useThis = new Font("Arial", 32);
                                    g.DrawString("Q", useThis, Brushes.White, X, Y);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!hints)
                        {
                            g.FillRectangle(Brushes.White, rect);
                            g.DrawRectangle(Pens.Black, rect);
                            if (drawSpace.isOccupied())
                            {
                                Font useThis = new Font("Arial", 32);
                                g.DrawString("Q", useThis, Brushes.Black, X, Y);
                            }
                        }
                        else
                        {
                            if (!drawSpace.isValid(coordinates))
                            {
                                g.FillRectangle(Brushes.Red, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    Font useThis = new Font("Arial", 32);
                                    g.DrawString("Q", useThis, Brushes.White, X, Y);
                                }
                            }
                            else
                            {
                                g.FillRectangle(Brushes.White, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    Font useThis = new Font("Arial", 32);
                                    g.DrawString("Q", useThis, Brushes.Black, X, Y);
                                }
                            }
                        }
                    }
                }
            }
            if (totalQueens == 8)
            {
                for (int i = 0; i < 64; i++)
                {
                    space drawSpace = ((space)coordinates[i]);
                    drawSpace.setOccupied(false);
                    totalQueens = 0;
                }
                MessageBox.Show("You win!");
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                for(int i = 0; i < 64; i++)
                {
                    space drawSpace = ((space)coordinates[i]);
                    if(drawSpace.isClicked(e.X, e.Y))
                    {
                        if(drawSpace.isValid(coordinates))
                        {
                            drawSpace.setOccupied(true);
                            totalQueens++;
                        }
                        else
                        {
                            System.Media.SystemSounds.Beep.Play();
                        }
                    }
                }
            }
            if(e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < 64; i++)
                {
                    space drawSpace = ((space)coordinates[i]);
                    if (drawSpace.isClicked(e.X, e.Y))
                    {
                        if (drawSpace.isOccupied())
                        {
                            drawSpace.setOccupied(false);
                            totalQueens--;
                        }
                    }
                }
            }
            Invalidate();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 64; i++)
            {
                space drawSpace = ((space)coordinates[i]);
                drawSpace.setOccupied(false);
                totalQueens = 0;
            }
            Invalidate();
        }

        private void Hint_CheckedChanged(object sender, EventArgs e)
        {
            hints = !hints;
            Invalidate();
        }
    }
    public partial class space
    {
        private int x;
        private int y;
        private int row;
        private int col;
        public Rectangle getRect()
        {
            return rect;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public bool isOccupied()
        {
            return occupied;
        }
        public bool setOccupied(bool inset)
        {
            occupied = inset;
            return inset;
        }
        public int getRow()
        {
            return row;
        }
        public int getCol()
        {
            return col;
        }
        public Rectangle rect;
        public bool occupied;
        public space(int iny, int inx, int i, int j)
        {
            x = inx;
            y = iny;
            row = i;
            col = j;
            rect = new Rectangle(x, y, 50, 50);
            occupied = false;
        }
        public bool isValid(ArrayList spaces)
        {
            for (int i = 0; i < 64; i++)
            {
                if ((((space)spaces[i]).getX() == x) && ((space)spaces[i]).isOccupied())
                {
                    return false;
                }
                else if ((((space)spaces[i]).getY() == y) && ((space)spaces[i]).isOccupied())
                {
                    return false;
                }
                else if(Math.Abs(((space)spaces[i]).getCol() - col) == Math.Abs(((space)spaces[i]).getRow() - row))
                {
                    if (((space)spaces[i]).isOccupied())
                    {
                        return false;
                    }
                }
            }
            if (occupied)
            {
                    return false;
            }
            else { return true; }
        }
        public bool isClicked(int inX, int inY)
        {
            if((inX >= x) && (inX <= x + 50))
            {
                if((inY >= y) && (inY <= y + 50))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
