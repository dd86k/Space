using System;
using System.Drawing;

namespace Space
{
    class Program
    {
        /* Settings */
        static char[] chars = { '*', '°' };
        static int density = 3;

        static Random ran = new Random(DateTime.Now.Millisecond);
        static void Main(string[] args)
        {
            if (args.Length > 0)
                return;

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "":

                        break;
                }
            }

            int charsmax = chars.Length;
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            int colorsmax = colors.Length;

            Console.Clear();

            int Width = Console.WindowWidth;
            int Height = Console.WindowHeight;
            int rannum;
            for (int w = 0; w < Width; w++)
            {
                for (int h = 0; h < Height; h++)
                {
                    rannum = ran.Next(0, 100);
                    if (rannum < density)
                    {
                        Console.ForegroundColor = colors[ran.Next(0, colorsmax)];
                        Console.Write(chars[ran.Next(0, charsmax)]);
                    }
                    else
                        Console.Write(" ");
                }
            }

            Console.ReadKey(true);
        }
    }
} 
