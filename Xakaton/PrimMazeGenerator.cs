
using System;
using System.Collections.Generic;

namespace Xakaton
{
    class PrimMazeGenerator : IMazeGenerator
    {
        private List<MazeTile> walls;
        private Maze maze;
        private Random r;
        private bool isValidCords(int x, int y)
        {
            return !(x < 0 || y < 0 || x >= maze.mazeTiles.GetLength(0) || y >= maze.mazeTiles.GetLength(1));
        }
        private void addToWallList(MazeTile tile)
        {
            if(!walls.Contains(tile) && tile.isOcupied)
            {
                walls.Add(tile);
            }       
        }
        private bool checkNeighbors(MazeTile tile)
        {
            for (int i = tile.x - 1; i < tile.x + 2; i++)
            {
                for (int j = tile.y - 1; j < tile.y + 2; j++)
                {
                    if(isValidCords(i,j) && !maze.mazeTiles[i,j].isOcupied)
                    {   
                        return false;
                    }
                }
            }
            return true;
        }
        private void generationIteration(MazeTile tile)
        {
            
            List<MazeTile> neighbors = new List<MazeTile>();
            for (int i = tile.x - 2; i < tile.x + 3; i++)
            {
                for (int j = tile.y - 2; j < tile.y + 3; j++)
                {
                    if(isValidCords(i,j) &&
                    (i == tile.x || j == tile.y) &&
                    Math.Abs(i - tile.x) != 1 && 
                    Math.Abs(j - tile.y) != 1)
                    {
                        addToWallList(maze.mazeTiles[i,j]); 
                        if(!maze.mazeTiles[i,j].isOcupied)
                        {
                            neighbors.Add(maze.mazeTiles[i,j]);
                        }

                    }
                }
            }
            tile.isOcupied = false;
            if(walls.Contains(tile))
            {
                walls.Remove(tile);
            }  

            int index;
            if(neighbors.Count > 0)
            {
                index = r.Next(neighbors.Count);
                MazeTile neighbor = neighbors[index];
                int inBetweenX = neighbor.x == tile.x ? tile.x : neighbor.x > tile.x ? tile.x + 1 : tile.x - 1;
                int inBetweenY = neighbor.y == tile.y ? tile.y : neighbor.y > tile.y ? tile.y + 1 : tile.y - 1;
                maze.mazeTiles[inBetweenX, inBetweenY].isOcupied = false;
            }
            

            index = r.Next(walls.Count);
            while(walls.Count > 0 && !checkNeighbors(walls[index]))
            {
                if(walls.Contains(walls[index]))
                {
                    walls.Remove(walls[index]);
                }       
                index = r.Next(walls.Count);
            }
            if(walls.Count == 0) 
            {
                return;
            }
            generationIteration(walls[index]);
            

        }
        public Maze generate()
        {
            maze = new Maze();
            walls = new List<MazeTile>();
            r = new Random();
            int x = r.Next(maze.mazeTiles.GetLength(0));
            int y = r.Next(maze.mazeTiles.GetLength(1));

            MazeTile currentTile = maze.mazeTiles[x,y];
            generationIteration(currentTile);
            for (int i = 0; i < maze.mazeTiles.GetLongLength(0); i++)
            {
                for (int j = 0; j < maze.mazeTiles.GetLength(1); j++)
                {
                    if (!maze.mazeTiles[i,j].isOcupied)
                    {
                        maze.freeTiles.Add(maze.mazeTiles[i, j]);
                    }
                }
            }
            return maze;
        } 
    }
}