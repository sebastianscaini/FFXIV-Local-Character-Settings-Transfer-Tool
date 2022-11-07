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

            string chrPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn/" + ("CHR" + "00" + Line2Int.ToString("X") + Line1Int.ToString("X")));
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Found Chararacter: " + ("CHR" + "00" + Line2Int.ToString("X") + Line1Int.ToString("X")));
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");
            Console.WriteLine("Login with the character that you wish to copy the settings to, then log out and close the game.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("If you wish to copy these settings to all other character, continue without logging in to another character.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            FFXIVDataPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn", "FFXIV.cfg");
            FFXIVData = System.IO.File.ReadAllLines(FFXIVDataPath);

            string Line12 = FFXIVData[12].Replace("LastLogin0	", "");
            string Line22 = FFXIVData[13].Replace("LastLogin1	", "");
            int Line1Int2 = int.Parse(Line12);
            int Line2Int2 = int.Parse(Line22);

            string chrPath2 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn/" + ("CHR" + "00" + Line2Int2.ToString("X")+ Line1Int2.ToString("X")));

            if(chrPath == chrPath2)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The tool is about to overwrite all of your character settings with the selected character's settings.");
                Console.WriteLine("Press any key twice to confirm. Close the tool to cancel.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Found Chararacter: " + ("CHR" + "00" + Line2Int2.ToString("X4") + Line1Int2.ToString("X")));
                Console.ForegroundColor = ConsoleColor.White;
            }

            //Console.WriteLine("");
            /*Console.WriteLine(Line1Int.ToString("X"));
            Console.WriteLine("00" + Line2Int.ToString("X"));*/
            //Console.WriteLine(chrPath2);

            Console.WriteLine("");
            Console.WriteLine("Press any key to exit the tool.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
