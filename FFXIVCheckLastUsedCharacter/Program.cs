using System;

namespace FFXIVCheckLastUsedCharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            string FFXIVDataPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn", "FFXIV.cfg");
            string[] FFXIVData = System.IO.File.ReadAllLines(FFXIVDataPath);

            Console.WriteLine("FFXIV Check Last Used Character Data");
            Console.WriteLine("By Sebastian Scaini");

            string Line1 = FFXIVData[12].Replace("LastLogin0	", "");
            string Line2 = FFXIVData[13].Replace("LastLogin1	", "");

            int Line1Int = int.Parse(Line1);
            int Line2Int = int.Parse(Line2);

            string chrPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn/" + ("CHR" + Line1Int.ToString("X") + "00" + Line2Int.ToString("X")));
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Last Used Character Data: " + ("CHR" + "00" + Line2Int.ToString("X") + Line1Int.ToString("X")));
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
