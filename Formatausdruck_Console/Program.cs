using System;
using static System.Console;
using static System.ConsoleColor;

namespace Formatausdruck_Console
{
    class Program
    {
        // static double gesammtPreis = 0;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            int maxWidth = LargestWindowWidth;
            int maxHeight = LargestWindowHeight;
            int topLine = 0;
            double gesamtPreis = 0.0;    //wenn hier genutzt, dann ohne static
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

            SetCursorPosition(2, 9);
            ForegroundColor = White;
            WriteLine("Bezeichnung\tEinzelpreis\tAnzahl\tPreis");

            for (int zeile = 10; zeile < 15; zeile++)
            {
                
                SetCursorPosition(2, zeile);
                ForegroundColor = (ConsoleColor)(zeile % 16);         // modulo hat ein Comeback
                double einzel = (zeile * 10.0 + (zeile % 4) / 100.0);

                Write($"Artikel {zeile - 9}\t{einzel.ToString("0.00")}\t\t");  // Klammersetzung ist wichtig
                //Write erleichtert die Eingabe             //.ToString("0.00") sagt, vor Komma min 1 Stelle, hinter Komma zwei Stellen

                int anzahl = Convert.ToInt32(ReadLine());
                double gesamt = einzel * anzahl;
                SetCursorPosition(40, zeile);
                Write("{0,8:C}", gesamt);         // gesamt.ToString("0.00") wäre auch gegangen
                                                      // :C ist das lokale Währungszeichen 1.000,00
                gesamtPreis += gesamt;
                
            }
            SetCursorPosition(CursorLeft, CursorTop+2);     // bleibt immer mit dem gleichen Abstand
            Write("{0,10:C}", gesamtPreis);
            ReadLine();
            
        }
    }
}
