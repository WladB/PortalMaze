using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Xakaton
{

    class MazeSprite
    {
        public Image image;
        public Point point;
        public string name;
    }

    class MazeImages
    {
        public Image wall;
        public Image passage;
        public List<MazeSprite> sprites = new List<MazeSprite>();
        public MazeSprite getByName(string name)
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                if(sprites[i].name.Equals(name))
                {
                    return sprites[i];
                }
            }
            return null;
        }
    }
    class MazeTile
    {
        public bool isOcupied;
        public int x;
        public int y;
        public MazeTile()
        {
            isOcupied = true;
            x = y = 0;
        }
    }
    class Maze
    {
        public MazeTile[,] mazeTiles;
        public List<MazeTile> freeTiles;
        public Maze()
        {
            mazeTiles = new MazeTile[50,50];
            for(int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    mazeTiles[i,j] = new MazeTile();
                    mazeTiles[i,j].x = i;
                    mazeTiles[i,j].y = j;
                }
            }
            freeTiles = new List<MazeTile>();
        }  

        private Point toImageCords(Point p, Rectangle area, int cellSize)
        {
            Point result = new Point();
            result.X = (p.X - area.Left)*cellSize;
            result.Y = (p.Y - area.Top)*cellSize;
            return result;
        }

        public Image drawFragment(Rectangle area, MazeImages images, int cellSize)
        {
            images.wall = new Bitmap(images.wall, new Size(cellSize, cellSize));
            images.passage = new Bitmap(images.passage, new Size(cellSize, cellSize));
            for (int i = 0; i < images.sprites.Count; i++)
            {
                images.sprites[i].image = new Bitmap(images.sprites[i].image, new Size(cellSize, cellSize)); 
            }

            Image result = new Bitmap((area.Width + 1) * cellSize, (area.Height + 1) * cellSize);
            Graphics g = Graphics.FromImage(result);
            if(area.Left < 0)
            {
                for (int i = area.Left; i < 0; i++)
                {
                    for (int j = area.Top; j <= area.Bottom; j++)
                    {
                        g.DrawImage(images.wall, toImageCords(new Point(i,j), area, cellSize));
                    }
                }
            }

            if (area.Top < 0)
            {
                for (int i = area.Left; i <= area.Right; i++)
                {
                    for (int j = area.Top; j < 0; j++)
                    {
                        g.DrawImage(images.wall, toImageCords(new Point(i,j), area, cellSize));
                    }
                }
            }

            if (area.Right >= mazeTiles.GetLength(0))
            {
                for (int i = mazeTiles.GetLength(0); i < area.Right + 1; i++)
                {
                    for (int j = area.Top; j <= area.Bottom; j++)
                    {
                        g.DrawImage(images.wall, toImageCords(new Point(i,j), area, cellSize));
                    }
                }  
            }

            if (area.Bottom >= mazeTiles.GetLength(1))
            {
                for (int i = area.Left; i <= area.Right; i++)
                {
                    for (int j = mazeTiles.GetLength(1); j < area.Bottom + 1; j++)
                    {
                        g.DrawImage(images.wall, toImageCords(new Point(i,j), area, cellSize));
                    }
                }
            }

            for (int i = area.Left; i < area.Right + 1; i++)
            {
                for (int j = area.Top; j < area.Bottom + 1; j++)
                {
                    if(i >=0 && j >= 0 && i < mazeTiles.GetLength(0) && j < mazeTiles.GetLength(1))
                    {

                        if(mazeTiles[i,j].isOcupied)
                        {
                            g.DrawImage(images.wall, toImageCords(new Point(i,j), area, cellSize));   
                        }   
                        else
                        {
                            g.DrawImage(images.passage, toImageCords(new Point(i,j), area, cellSize));       
                        }    
                        
                    } 
                }
            }

            for (int i = 0; i < images.sprites.Count; i++)
            {
                if( images.sprites[i].point.X >= area.Left && 
                    images.sprites[i].point.X <= area.Right && 
                    images.sprites[i].point.Y >= area.Top && 
                    images.sprites[i].point.Y <= area.Bottom)
                {
                    g.DrawImage(images.sprites[i].image, toImageCords(images.sprites[i].point, area, cellSize));   
                } 
            }

            
            return result;  

        }
    } 

    

    interface IMazeGenerator
    {
        Maze generate(); 
    }
}