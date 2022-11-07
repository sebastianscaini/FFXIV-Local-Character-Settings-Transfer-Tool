using System;

namespace FFXIVLocalCharacterSettingsTransferTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string FFXIVDataPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn", "FFXIV.cfg");
            string[] FFXIVData = System.IO.File.ReadAllLines(FFXIVDataPath);
            string fileName = "";

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
            Console.WriteLine("Press any key to continue once you have completed this step.");
            Console.ReadKey();

            FFXIVDataPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn", "FFXIV.cfg");
            FFXIVData = System.IO.File.ReadAllLines(FFXIVDataPath);

            string Line1 = FFXIVData[12].Replace("LastLogin0	", "");
            string Line2 = FFXIVData[13].Replace("LastLogin1	", "");

            int Line1Int = int.Parse(Line1);
            int Line2Int = int.Parse(Line2);

            string chrPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn/" + ("FFXIV_CHR" + "00" + Line2Int.ToString("X") + Line1Int.ToString("X")));
            string sourcePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn/" + ("FFXIV_CHR" + "00" + Line2Int.ToString("X") + Line1Int.ToString("X")));

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Found Chararacter: " + ("CHR" + "00" + Line2Int.ToString("X") + Line1Int.ToString("X")));
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");
            Console.WriteLine("Login with the character that you wish to copy the settings to, then log out and close the game.");
            Console.WriteLine("Press any key to continue once you have completed this step.");
            Console.ReadKey();

            FFXIVDataPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn", "FFXIV.cfg");
            FFXIVData = System.IO.File.ReadAllLines(FFXIVDataPath);

            string Line12 = FFXIVData[12].Replace("LastLogin0	", "");
            string Line22 = FFXIVData[13].Replace("LastLogin1	", "");
            int Line1Int2 = int.Parse(Line12);
            int Line2Int2 = int.Parse(Line22);

            string chrPath2 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn/" + ("FFXIV_CHR" + "00" + Line2Int2.ToString("X")+ Line1Int2.ToString("X")));
            string targetPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/FINAL FANTASY XIV - A Realm Reborn/" + ("FFXIV_CHR" + "00" + Line2Int2.ToString("X")+ Line1Int2.ToString("X")));

            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            if (chrPath == chrPath2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The same character is selected. Aborting copy.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Found Chararacter: " + ("CHR" + "00" + Line2Int2.ToString("X4") + Line1Int2.ToString("X")));
                Console.ForegroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The tool is about to overwrite the target character's settings.");
                Console.WriteLine("Press any key twice to confirm. Close the tool to cancel.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.ReadKey();

                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    foreach (string s in files)
                    {
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Copied " + s);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("");
                    Console.WriteLine("Copying complete!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Target invalid. Aborting copy.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to exit the tool.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
