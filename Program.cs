using System;

namespace TextBasedUI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Console.BufferWidth < 40)
            {
                Console.WriteLine("Please increase width of your console window to 40 columns minimum");
                Environment.Exit(1);
            }

            Console.CursorVisible = false;

            const int margin = 3;
            const int numberOfRows = 20;
            int positionX = Console.BufferWidth / 2;
            int positionY = numberOfRows / 2;

            while (true)
            {
                DrawFrame(numberOfRows, '*', margin, positionX, positionY);
                System.Threading.Thread.Sleep(5);

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            positionX -= 1;
                            break;
                        case ConsoleKey.RightArrow:
                            positionX += 1;
                            break;
                        case ConsoleKey.UpArrow:
                            positionY -= 1;
                            break;
                        case ConsoleKey.DownArrow:
                            positionY += 1;
                            break;
                    }
                }

                Console.SetCursorPosition(0, 0);
            }
        }

        static void DrawFrame(int numberOfRows, char separator, int margin, int positionX, int positionY)
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                if (i == 0 || i == numberOfRows - 1)
                {
                    DrawEdge(separator, margin);
                }
                else
                {
                    DrawBody(separator, margin, positionX, positionY);
                }
            }
        }

        static void DrawEdge(char separator, int margin = 0)
        {
            for(int i = 0; i < Console.BufferWidth; i++)
            {
                if (i >= margin && i <= Console.BufferWidth - 1 - margin)
                {
                    Console.Write(separator);
                }
                else
                {
                    Console.Write(' ');
                }
            }
        }

        static void DrawBody(char separator, int margin, int positionX, int positionY)
        {
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                if (i==margin || i == Console.BufferWidth - 1 - margin)
                {
                    Console.Write(separator);
                }
                else if (Console.CursorLeft == positionX && Console.CursorTop == positionY)
                {
                    var oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('@');
                    Console.ForegroundColor = oldColor;
                }
                else
                {
                    Console.Write(' ');
                }
            }
        }
    }
}
