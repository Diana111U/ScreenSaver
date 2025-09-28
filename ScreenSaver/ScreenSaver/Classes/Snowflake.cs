using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaver.Classes
{
    public class Snowflake
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public int Speed { get; set; }

        public Snowflake(int x, int y, int size, int speed)
        {
            X = x;
            Y = y;
            Size = size;
            Speed = speed;
        }
    }
}
