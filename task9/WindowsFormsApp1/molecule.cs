using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Molecule
    {
        public static int maxDistance = 3;
        public static int radius = 3;
        public int X;
        public int Y;
        private int maxWidth;
        private int maxHeight;

        private Random rand;

        public Molecule(int maxWidth, int maxHeight, Random rand)
        {
            this.maxWidth = maxWidth;
            this.maxHeight = maxWidth;
            this.rand = rand;
            X = rand.Next(1, maxWidth - 2*radius - 20);
            Y = rand.Next(1, maxHeight - 2*radius - 40);
        }

        public void move()
        {
            int deltaX = rand.Next(- maxDistance, maxDistance + 1);
            int bound = (int)Math.Floor(Math.Sqrt(Math.Pow(maxDistance, 2) - Math.Pow(deltaX, 2)));
            int deltaY = rand.Next(- bound, bound + 1);

            if (X + deltaX >= maxWidth - 2*radius - 20)
            {
                deltaX = -deltaX;
            }
            if (X + deltaX <= 1)
            {
                deltaX = -deltaX;
            }

            if (Y + deltaY >= maxHeight - 2 * radius - 40)
            {
                deltaY = -deltaY;
            }
            if (Y + deltaY <= 1)
            {
                deltaY = -deltaY;
            }
            X = X + deltaX;
            Y = Y + deltaY;
        }
    }
}
