﻿using System;
using static System.Console;
using static System.ConsoleColor;

namespace Formatausdruck_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxWidth = LargestWindowWidth;
            int maxHeight = LargestWindowHeight;
            int topLine = 0;
            SetWindowSize(maxWidth / 2, maxHeight / 2);
            BackgroundColor = Black;
            Clear();
            string dateString = $"Heute: {DateTime.Now.ToLongDateString()}";
            string zeitString = $"Jetzt: {DateTime.Now.ToShortTimeString()}";    // ToLongTimeString, zeigt bis zur Sekunde
            int lengthDateTimeNow = dateString.Length;
            int lengthzeitString = zeitString.Length;

            SetCursorPosition(maxWidth / 2 - lengthDateTimeNow - 1, topLine);
            ForegroundColor = Red;
            WriteLine(dateString);

            ForegroundColor = Green;
            SetCursorPosition(maxWidth / 2 - lengthzeitString - 1, ++topLine);
            WriteLine(zeitString);


            for (int zeile = 10; zeile < 16; zeile++)
            {
                SetCursorPosition(2, zeile);
                ForegroundColor = (ConsoleColor)(zeile%16);     // modulo hat ein Comeback
                WriteLine($"Artikel {zeile - 9}");              // Klammersetzung ist wichtig
                
            }

            ReadLine();
        }
    }
}
