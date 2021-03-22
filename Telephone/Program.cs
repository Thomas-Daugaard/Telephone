using System;

namespace Telephone
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo consoleKeyInfo;
            ITelephone telephone = new Telephone();

            do
            {
                consoleKeyInfo = Console.ReadKey(true); // true = do not echo character
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.D1:
                        telephone.PressDigit(1);
                        break;

                    case ConsoleKey.D2:
                        telephone.PressDigit(2);
                        break;

                    case ConsoleKey.D3:
                        telephone.PressDigit(3);
                        break;

                    case ConsoleKey.D4:
                        telephone.PressDigit(4);
                        break;

                    case ConsoleKey.D5:
                        telephone.PressDigit(5);
                        break;

                    case ConsoleKey.D6:
                        telephone.PressDigit(6);
                        break;

                    case ConsoleKey.D7:
                        telephone.PressDigit(7);
                        break;

                    case ConsoleKey.D8:
                        telephone.PressDigit(8);
                        break;

                    case ConsoleKey.D9:
                        telephone.PressDigit(9);
                        break;

                    case ConsoleKey.D0:
                        telephone.PressDigit(0);
                        break;

                    case ConsoleKey.C:
                        telephone.PressCallButton();
                        break;
                }


            } while (consoleKeyInfo.Key != ConsoleKey.Escape);
        }
    }
}
