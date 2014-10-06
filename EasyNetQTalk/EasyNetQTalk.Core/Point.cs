using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNetQTalk.Core
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public readonly int X;
        public readonly int Y;
    }

    public static class PointExtensions
    {
        public static string GetQuadrant(this Point point)
        {
            /*
             *        x,y 
             * 0,0     |   250,0
             *         |
             *    II   |     I
             * --------|--------
             *   III   |    IV
             *         |     
             * 0,250   | 250,250
             */
            if (point.X >= 250)
            {
                return point.Y >= 250 ? "IV" : "I";
            }

            return point.Y >= 250 ? "III" : "II";
        }
    }
}
