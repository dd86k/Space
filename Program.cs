using System;

namespace Space
{
    class Program
    {
        /* Settings */
        static char[] chars = { '*', '°' };
        static int density = 3;
        /* Not settings */
        static Random ran = new Random(DateTime.Now.Millisecond);
        static readonly string ProjectVersion =
            string.Format("{0}",
            System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);

        static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                ShowHelp();
                return 0;
            }

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-d":
                        if (!int.TryParse(args[i + 1], out density))
                        {
                            Console.WriteLine("Invalid density number, aborting.");
                            return 2;
                        }
                        break;

                    case "/?":
                    case "--help":
                        ShowHelp();
                        return 0;

                    case "--version":
                        ShowVersion();
                        return 0;
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

            return 0;
        }

        static void ShowHelp()
        {
            Console.WriteLine(" Usage:");
            Console.WriteLine("  Space [options]");
            Console.WriteLine();
            Console.WriteLine("  -d     Density, 0-100. Default is 3.");
            Console.WriteLine();
            Console.WriteLine("  --help, /?      Shows this screen");
            Console.WriteLine("  --version       Shows version");
        }

        static void ShowVersion()
        {
            Console.WriteLine("Space - " + ProjectVersion);
            Console.WriteLine("Copyright (c) 2015 DD~!/guitarxhero");
            Console.WriteLine("License: MIT License <http://opensource.org/licenses/MIT>");
            Console.WriteLine("Project page: <https://github.com/guitarxhero/Space>");
            Console.WriteLine();
            Console.WriteLine(" -- Credits --");
            Console.WriteLine("DD~! (guitarxhero) - Original author");
        }
    }
} 
