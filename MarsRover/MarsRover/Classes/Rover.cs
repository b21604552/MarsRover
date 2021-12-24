using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Classes
{
    public class Rover
    {
        public int x {get; set;}
        public int y {get; set;}
        public char d {get; set;}
        public Rover(int x, int y, char d)
        {
            this.x = x;
            this.y = y;
            this.d = d;
        }
    }
}
