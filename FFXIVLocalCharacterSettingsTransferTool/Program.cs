using System;

namespace FFXIVLocalCharacterSettingsTransferTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string FFXIVDataPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn", "FFXIV.cfg");
            string[] FFXIVData = System.IO.File.ReadAllLines(FFXIVDataPath);

            Console.WriteLine("FFXIV Local Character Settings Transfer Tool");
            Console.WriteLine("By Sebastian Scaini");
            Console.WriteLine("");
            Console.WriteLine("This tool will help you transfer your character settings from one character to another locally!");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("It is strongly recommended that you make a backup of the folder: ");
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn");
            Console.WriteLine("before using this tool!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("Login with the character that you wish to copy the settings from, then log out and close the game.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            string Line1 = FFXIVData[12].Replace("LastLogin0	", "");
            string Line2 = FFXIVData[13].Replace("LastLogin1	", "");

            int Line1Int = int.Parse(Line1);
            int Line2Int = int.Parse(Line2);

            string chrPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn/" + ("CHR" + Line1Int.ToString("X") + "00" + Line2Int.ToString("X")));
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Found Chararacter: " + ("CHR" + Line1Int.ToString("X") + "00" + Line2Int.ToString("X")));
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");
            Console.WriteLine("Login with the character that you wish to copy the settings to, then log out and close the game.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            Line1 = FFXIVData[12].Replace("LastLogin0	", "");
            Line2 = FFXIVData[13].Replace("LastLogin1	", "");
            Line1Int = int.Parse(Line1);
            Line2Int = int.Parse(Line2);

            string chrPath2 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn/" + ("CHR" + Line1Int.ToString("X") + "00" + Line2Int.ToString("X")));
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Found Chararacter: " + ("CHR" + Line1Int.ToString("X") + "00" + Line2Int.ToString("X")));
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");
            /*Console.WriteLine(Line1Int.ToString("X"));
            Console.WriteLine("00" + Line2Int.ToString("X"));*/
            Console.WriteLine(chrPath2);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
