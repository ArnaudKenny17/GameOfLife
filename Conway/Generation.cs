using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway
{
    internal class Generation:Cell
    {
        public int width;
        public int height;
        public int[,] board;
        public double density;
        public string s;
       
       
        public Generation(double density,int width,int height)
        {
            int[,] board = new int[width, height];

            this.width = width;
            this.height = height;
            this.board = board;
            this.density = density;
        }
    
        public Generation(Generation obj,string s)
        {
            this.s = s;
            this.height = obj.height;
            this.board = obj.board;
            this.width = obj.width;
       
            Console.Clear();
            Console.WriteLine("---");
            int aliveCells = 0;
            for (int y = 0; y < height; y++)
            {
                String line = "|";
                for (int x = 0; x < width; x++)
                {
                    if (board[x, y] == 0)
                    {
                        line += ".";
                    }
                    else
                    {
                        aliveCells++;
                        line += s;
                    }
                }
                line += "|";
                Console.WriteLine(line);
            }
            Console.WriteLine("---\n");
            Console.WriteLine($"Alive cells: {aliveCells}");

           
        }
        public Generation(int width, int height, double density) : this(density, width, height)
        {
            int initialAlive = (int)Math.Round((density * width * height) / 100);
            Console.WriteLine(initialAlive);
            Random gen = new Random();
            int a = -1;
            int b = -2;

            // Console.WriteLine(a);
            for (int i = 0; i < initialAlive; i++)
            {
                int x = gen.Next(width); //1 1
                int y = gen.Next(height); //2 2
                if (i == 0)
                {
                    SetAlive(x, y);
                }
                else
                {
                    for (int j = i; j < i + 1; j++)
                    {
                        if (x == a || y == b)
                        {


                            i--;

                            break;

                        }
                        else
                        {
                            SetAlive(x, y);

                        }

                    }

                }
                a = x;
                b = y;

            }
        }
     
        public override void SetAlive(int x, int y)
        {
            this.board[x,y] = 1;
           
        }
        public void step()
        {
            int[,] newBoard = new int[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int aliveNeighbours = countAliveNeighbours(x, y);

                    if (getState(x, y) == 1)
                    {
                        if (aliveNeighbours < 2)
                        {
                            newBoard[x, y] = 0;
                        }
                        else if (aliveNeighbours == 2 || aliveNeighbours == 3)
                        {
                            newBoard[x, y] = 1;
                        }
                        else if (aliveNeighbours > 3)
                        {
                            newBoard[x, y] = 0;
                        }
                    }
                    else
                    {
                        if (aliveNeighbours == 3)
                        {
                            newBoard[x, y] = 1;
                        }
                    }

                }
            }

            this.board = newBoard;
        }
        public int getState(int x, int y)
        {
            if (x < 0 || x >= width)
            {
                return 0;
            }

            if (y < 0 || y >= height)
            {
                return 0;
            }

            return this.board[x, y];
        }
        public int countAliveNeighbours(int x, int y)
        {
            int count = 0;

            count += getState(x - 1, y - 1);
            count += getState(x, y - 1);
            count += getState(x + 1, y - 1);

            count += getState(x - 1, y);
            count += getState(x + 1, y);

            count += getState(x - 1, y + 1);
            count += getState(x, y + 1);
            count += getState(x + 1, y + 1);

            return count;
        }
        public int AliveCellsinBoard()
        {
            int aliveCells = 0;
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    if (this.board[x, y]==1)
                        aliveCells++;
                }
            }
            return aliveCells;
        }


        public override string ToString()
        {
            string result = "";
            Console.WriteLine("---");
            for (int y=0;y< this.height; y++)
            {
                for(int x=0;x< this.width;x++)
                {
                    if (this.board[x, y] == 0)
                    {
                        result += ".";
                    }
                    else
                    {
                        
                      result += s;
                    }
                }
                result += "\n";
            }
          Console.WriteLine(AliveCellsinBoard());
            return result;
           

        }


    }
}
