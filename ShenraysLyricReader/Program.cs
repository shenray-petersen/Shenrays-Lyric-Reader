using System.Reflection;
using System.Runtime.CompilerServices;

namespace ShenraysLyricReader
{
    internal class Program
    {
        private static bool running = true;
        static List<double> delays = new List<double> { 0.2, 0.2, 0.2, 1.0, 0.2,1.2 };
        static void Main(string[] args)
        {

            Thread threadLyrics = new Thread(ReadLyrics);
            threadLyrics.Start();
            Console.ReadKey();

        }
        static void ReadLyrics()
        {
            string filePath = "Lyrics.txt";
            // Read all lines
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i];


                Typewrite(currentLine+"\n");  
                

                // Delay between full lyric lines
                if (i < delays.Count)
                {
                    
                    int millisecondsTimeout = (int)(delays[i] * 5000);
                    Thread.Sleep(millisecondsTimeout);

                }
                else
                {
                    Console.WriteLine("Lyrics.txt not found. ");
                }



            }


            static void Typewrite(string currentLine)
            {
                for(int i =0; i<currentLine.Length;i++)
                {
                    Console.Write(currentLine[i]);
                    System.Threading.Thread.Sleep(60);

                }

            }

            


        

        }
    }
}