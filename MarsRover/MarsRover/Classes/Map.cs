using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Classes
{
    public class Map
    {
        public int x { get; set; }
        public int y { get; set; }
        public int[,] map { get; set; }

        public Map(int x, int y)
        {
            this.x = x;
            this.y = y;
            map = new int[x, y];
        }
        public static void List(Map mapObj)
        {
            Console.WriteLine(Messages.Messages.ListInfo);
            for (int i = 0; i < mapObj.x; i++)
            {
                for (int j = 0; j < mapObj.y; j++)
                {
                    if(mapObj.map[i, j] == 1)
                    {
                        Console.Write(Messages.Messages.RoverIcon);
                    }
                    else
                    {
                        Console.Write(mapObj.map[i, j]);
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
