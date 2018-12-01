/* Original Author: Ethan Uong */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarShiftCipher
{
    // This s a very simple Caesar cipher app.
    // For future work, implement a custom character table and verify inputted char is within range
    // Note that this app does not consider if string contains numbers..

    class Program
    {
        private const int SHIFT = 3;
        private const int LOWERBOUND = 32;
        private const int UPPERBOUND = 126 ;

        private static int key = 0;

        //private static char[] charDictionary;

        //private static Func<int, string> CharToString = c => ((char)c).ToString();

        static void Main(string[] args)
        {
            // Decimal 32 to 126 in ASCII table
            //string table = @" !22#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
            //charDictionary = table.ToCharArray();

            Console.WriteLine("Simple Caesar's Shift Encryption Program");
            Console.WriteLine("INSTRUCTIONS");
            Console.WriteLine("To establish or change key: key ###");
            Console.WriteLine("To encrypt: --> string");
            Console.WriteLine("To decrypt: <-- string");
            Console.WriteLine("'quit' to close the app\r\n");

            while (true)
            {
                string str = Console.ReadLine();

                if (str.Length >= 4)
                {
                    if (str.Substring(0, 4).ToLower().Equals("key "))
                        if (!int.TryParse(str.Substring(4), out key))
                            Console.WriteLine("Key is not valid!\r\n");
                    if (str.Substring(0, 4).Equals("--> "))
                        Encrypt(str.Substring(4));
                    else if (str.Substring(0, 4).Equals("<-- "))
                        Decrypt(str.Substring(4));
                    else if (str.ToLower().Equals("quit"))
                        break;
                }
            }

        }

        private static void Encrypt(string str)
        {
            if (key == 0)
            {
                Console.WriteLine("Key is not entered!\r\n");
                return;
            }

            int index = 0;
            char[] buffer = new char[str.Length];
            foreach (char c in str)
            {
                char letter = (char)(c + key);

                if (letter > UPPERBOUND)
                    letter = (char)(letter - UPPERBOUND + LOWERBOUND);
                else if (letter < LOWERBOUND)
                    letter = (char)(letter + LOWERBOUND);

                buffer[index++] = letter;
            }

            Console.WriteLine(new string(buffer) + "\r\n");
        }

        private static void Decrypt(string str)
        {
            if (key == 0)
            {
                Console.WriteLine("Key is not entered!\r\n");
                return;
            }

            char[] buffer = new char[str.Length];
            int index = 0;
            foreach (char c in str)
            {
                char letter = (char)(c - key);

                if (letter > UPPERBOUND)
                    letter = (char)(letter + UPPERBOUND - LOWERBOUND);
                else if (letter < LOWERBOUND)
                    letter = (char)(letter - LOWERBOUND + UPPERBOUND);

                buffer[index++] = letter;
            }

            Console.WriteLine(new string(buffer) + "\r\n");
        }        
    }
}
