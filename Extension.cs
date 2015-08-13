using System;

namespace Space
{
    static class Extension
    {
        static Random ran = new Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// Pick a random character in the array.
        /// </summary>
        /// <param name="pArray">Char array</param>
        /// <returns>Char</returns>
        internal static char PickRandom(this char[] pArray)
        {
            return pArray[ran.Next(0, pArray.Length)];
        }

        /// <summary>
        /// Pick a random ConsoleColor in the array.
        /// </summary>
        /// <param name="pArray">ConsoleColor array</param>
        /// <returns>ConsoleColor</returns>
        internal static ConsoleColor PickRandom(this ConsoleColor[] pArray)
        {
            return pArray[ran.Next(0, pArray.Length)];
        }

        /// <summary>
        /// Get a number from 0 to 100 inclusively.
        /// </summary>
        /// <returns>Int32</returns>
        internal static int GetRandomPourcentage()
        {
            return ran.Next(0, 101);
        }

        /// <summary>
        /// Get random X position.
        /// </summary>
        /// <param name="pWidth">Width of console</param>
        /// <returns>Left position</returns>
        internal static int GetRandomX(int pWidth)
        {
            return ran.Next(0, pWidth);
        }

        /// <summary>
        /// Get random Y position.
        /// </summary>
        /// <param name="pHeight">Height of console</param>
        /// <returns>Top position</returns>
        internal static int GetRandomY(int pHeight)
        {
            return ran.Next(0, pHeight);
        }
    }
}
