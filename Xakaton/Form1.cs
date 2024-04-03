using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xakaton
{
    public partial class Form1 : Form
    {
        private Maze maze;
        MazeImages images;
        Image mazeImage;
        AbstractFactory factory;
        int portalCount = 20;
        public Form1()
        {
            InitializeComponent();
            factory = new Room1();
            PrimMazeGenerator generator = new PrimMazeGenerator();
            maze = generator.generate();


            images = new MazeImages();
            Graphics g;

            images.wall = new Bitmap(20, 20);
            g = Graphics.FromImage(images.wall);
            g.Clear(Color.Black);

            images.passage = new Bitmap(20, 20);
            g = Graphics.FromImage(images.passage);
            g.Clear(Color.White);

            MazeSprite player = new MazeSprite();
            player.image = new Bitmap(20, 20);
            g = Graphics.FromImage(player.image);
            g.Clear(Color.Red);
            player.name = "player";

            for (int i = maze.mazeTiles.GetLength(0) - 1; i > 0 ; i--)
            {
                for (int j = maze.mazeTiles.GetLength(1) - 1; j > 0 ; j--)
                {
                    if (!maze.mazeTiles[i,j].isOcupied)
                    {
                        player.point = new Point(i, j);
                    }
                }
            }
            images.sprites.Add(player);

            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                MazeSprite portal = new MazeSprite();
                portal.image = new Bitmap(20, 20);
                g = Graphics.FromImage(portal.image);
                g.Clear(Color.Purple);
                portal.name = "portal" + i.ToString();
                MazeTile portal1Tile = maze.freeTiles[r.Next(maze.freeTiles.Count)];
                maze.freeTiles.Remove(portal1Tile);
                portal.point = new Point(portal1Tile.x, portal1Tile.y);
                images.sprites.Add(portal);
            }
           

            mazeImage = maze.drawFragment(new Rectangle(player.point.X - 20, player.point.Y - 20, 40, 40), images, 20);
            //mazeImage = maze.drawFragment(new Rectangle(0, 0, maze.mazeTiles.GetLength(0), maze.mazeTiles.GetLength(1)), images, 20);

        }

        private void ReGenerateMaze()
        {
            PrimMazeGenerator generator = new PrimMazeGenerator();
            maze = generator.generate();
            for (int i = maze.mazeTiles.GetLength(0) - 1; i > 0; i--)
            {
                for (int j = maze.mazeTiles.GetLength(1) - 1; j > 0; j--)
                {
                    if (!maze.mazeTiles[i, j].isOcupied)
                    {
                        images.getByName("player").point = new Point(i, j);
                    }
                }
            }
            Random r = new Random();
            MazeTile portal1Tile = maze.freeTiles[r.Next(maze.freeTiles.Count)];
            images.getByName("portal1").point = new Point(portal1Tile.x, portal1Tile.y);


        }

        private void RePaint()
        {
            Point player = images.getByName("player").point;
            mazeImage = maze.drawFragment(new Rectangle(player.X - 20, player.Y - 20, 40, 40), images, 20);
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            g.DrawImage(mazeImage, (Width - mazeImage.Width) / 2, (Height - mazeImage.Height) / 2);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AbstractFactory factory = new Room1();
            factory.play();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            RePaint();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            RePaint();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point curPoint = images.getByName("player").point;
            switch (e.KeyCode)
            {
                case Keys.D:
                    if (curPoint.X < maze.mazeTiles.GetLength(0) - 2 && 
                        !maze.mazeTiles[curPoint.X + 1, curPoint.Y].isOcupied)
                    {
                        images.getByName("player").point.X++;
                    } 
                    break;
                case Keys.A:
                    if (curPoint.X > 0 &&
                        !maze.mazeTiles[curPoint.X - 1, curPoint.Y].isOcupied)
                    {
                        images.getByName("player").point.X--;
                    }
                    break;
                case Keys.S:
                    if (curPoint.Y < maze.mazeTiles.GetLength(1) - 2 &&
                        !maze.mazeTiles[curPoint.X, curPoint.Y + 1].isOcupied)
                    {
                        images.getByName("player").point.Y++;
                    }
                    break;
                case Keys.W:
                    if (curPoint.Y > 0 &&
                        !maze.mazeTiles[curPoint.X, curPoint.Y - 1].isOcupied)
                    {
                        images.getByName("player").point.Y--;
                    }
                    break;
                default:
                    break;
            }
            RePaint();
            for (int i = 0; i < 20; i++)
            {
                if (images.getByName("portal" + i.ToString()).point == images.getByName("player").point)
                {
                    if (!factory.play())
                    {
                        ReGenerateMaze();
                        RePaint();
                    }
                    else
                    {
                        images.getByName("portal" + i.ToString()).point = new Point(-100, -100);
                    }
                    break;
                }
            }
            
        }
    }
}
