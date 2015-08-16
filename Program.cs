using System;
using System.Timers;

namespace Space
{
    class Program
    {
        /* Settings */
        static char[] chars = { '*', '.' };
        static int density = 3;
        static int stars = 0;
        static int time = 2500;
        static bool animated = false;
        static int remchars = 25;
        /* Not settings */
        static readonly ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
        static readonly int Width = Console.WindowWidth;
        static readonly int Height = Console.WindowHeight;
        /* Project properties */
        static readonly string ProjectVersion =
            string.Format("{0}",
            System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);

        static int Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-d":
                        if (!int.TryParse(args[i + 1], out density))
                        {
                            Console.WriteLine("Invalid -d parameter, aborting.");
                            return 2;
                        }
                        break;

                    case "-s":
                        if (!int.TryParse(args[i + 1], out stars))
                        {
                            Console.WriteLine("Invalid -s parameter, aborting.");
                            return 2;
                        }
                        break;

                    case "-A":
                    case "--animated":
                        animated = true;
                        break;

                    case "-t":
                        if (!int.TryParse(args[i + 1], out time))
                        {
                            Console.WriteLine("Invalid -t parameter, aborting.");
                            return 2;
                        }
                        break;

                    case "-r":
                        if (!int.TryParse(args[i + 1], out remchars))
                        {
                            Console.WriteLine("Invalid -r parameter, aborting.");
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

            try // to set the cursor invisible
            {
                Console.CursorVisible = false;
            }
            catch (Exception)
            {

            }

            Console.Clear();

            if (stars > 0)
            {
                if (stars > Console.WindowHeight * Console.WindowWidth)
                {
                    Console.WriteLine("Number of stars higher than screen capacity, aborting.");
                    return 2;
                }

                for (int i = 0; i < stars; i++)
                {
                    PlaceStarRandom();
                }
            }
            else
            {
                int rannum;
                for (int w = 0; w < Width; w++)
                {
                    for (int h = 0; h < Height; h++)
                    {
                        rannum = Extension.GetRandomPourcentage();

                        if (rannum < density)
                        {
                            Console.ForegroundColor = colors.PickRandom();
                            Console.Write(chars.PickRandom());
                        }
                        else
                            Console.Write(' ');
                    }
                }
            }

            // In case of "Cursor at the end of line? Newline for you!"
            // Scroll back to the top
            Console.SetCursorPosition(0, 0);

            if (animated)
            {
                Timer timer = new Timer(time);
                timer.Elapsed += timer_Elapsed;
                timer.Start();
            }

            Console.ReadKey(true);

            Console.ResetColor();
            Console.Clear();

            return 0;
        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int x = Extension.GetRandomX(Width);
            int y = Extension.GetRandomY(Height);

            for (int i = 0; i < remchars; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(' ');

                x = Extension.GetRandomX(Width);
                y = Extension.GetRandomY(Height);
            }

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = colors.PickRandom();
            Console.Write(chars.PickRandom());
        }

        static void PlaceStarRandom()
        {
            int x = Extension.GetRandomX(Width);
            int y = Extension.GetRandomY(Height);

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = colors.PickRandom();
            Console.Write(chars.PickRandom());
        }

        static void ShowHelp()
        {
            Console.WriteLine(" Usage:");
            Console.WriteLine("  Space [options]");
            Console.WriteLine();
            Console.WriteLine("  -d              Density, 0 to 100. Default is 3.");
            Console.WriteLine("  -s              Number of stars, 1 to Width*Height. Overrides -d. No defaults.");
            Console.WriteLine("  -A, --animated  Animate, adds and remove stars. Disabled by default.");
            Console.WriteLine("  -t              [-A] Timer interval in ms. Default is 2500.");
            Console.WriteLine("  -r              [-A] Number of chars to remove on screen. Default is 25.");
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
