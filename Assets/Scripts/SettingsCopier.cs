using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class SettingsCopier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CopySettings());
    }

    private IEnumerator CopySettings()
    {
        string FFXIVDataPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\My Games\FINAL FANTASY XIV - A Realm Reborn", "FFXIV.cfg");
        string[] FFXIVData = System.IO.File.ReadAllLines(FFXIVDataPath);
        string fileName = "";

        UnityEngine.Debug.Log("FFXIV Local Character Settings Transfer Tool");
        UnityEngine.Debug.Log("By Sebastian Scaini");
        UnityEngine.Debug.Log("");
        UnityEngine.Debug.Log("This tool will help you transfer your character settings from one character to another locally!");
        UnityEngine.Debug.Log("");

        UnityEngine.Debug.Log("It is strongly recommended that you make a backup of the folder: ");
        UnityEngine.Debug.Log(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\My Games\FINAL FANTASY XIV - A Realm Reborn");
        UnityEngine.Debug.Log("before using this tool!");

        UnityEngine.Debug.Log("");
        UnityEngine.Debug.Log("Login with the character that you wish to copy the settings from, then log out and close the game.");
        UnityEngine.Debug.Log("Press any key to continue once you have completed this step.");

        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        FFXIVDataPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\My Games\FINAL FANTASY XIV - A Realm Reborn", "FFXIV.cfg");
        FFXIVData = System.IO.File.ReadAllLines(FFXIVDataPath);

        string Line1 = FFXIVData[12].Replace("LastLogin0	", "");
        string Line2 = FFXIVData[13].Replace("LastLogin1	", "");

        int Line1Int = int.Parse(Line1);
        int Line2Int = int.Parse(Line2);

        string chrPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\My Games\FINAL FANTASY XIV - A Realm Reborn\" + ("FFXIV_CHR" + "00" + Line2Int.ToString("X") + Line1Int.ToString("X")));
        string sourcePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\My Games\FINAL FANTASY XIV - A Realm Reborn\" + ("FFXIV_CHR" + "00" + Line2Int.ToString("X") + Line1Int.ToString("X")));

        UnityEngine.Debug.Log("");

        UnityEngine.Debug.Log("Found Chararacter: " + ("CHR" + "00" + Line2Int.ToString("X") + Line1Int.ToString("X")));

        UnityEngine.Debug.Log("");
        UnityEngine.Debug.Log("Login with the character that you wish to copy the settings to, then log out and close the game.");
        UnityEngine.Debug.Log("Press any key to continue once you have completed this step.");
        
        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        FFXIVDataPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\My Games\FINAL FANTASY XIV - A Realm Reborn", "FFXIV.cfg");
        FFXIVData = System.IO.File.ReadAllLines(FFXIVDataPath);

        string Line12 = FFXIVData[12].Replace("LastLogin0	", "");
        string Line22 = FFXIVData[13].Replace("LastLogin1	", "");
        int Line1Int2 = int.Parse(Line12);
        int Line2Int2 = int.Parse(Line22);

        string chrPath2 = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\My Games\FINAL FANTASY XIV - A Realm Reborn\" + ("FFXIV_CHR" + "00" + Line2Int2.ToString("X") + Line1Int2.ToString("X")));
        string targetPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\My Games\FINAL FANTASY XIV - A Realm Reborn\" + ("FFXIV_CHR" + "00" + Line2Int2.ToString("X") + Line1Int2.ToString("X")));

        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile = System.IO.Path.Combine(targetPath, fileName);

        if (chrPath == chrPath2)
        {
            UnityEngine.Debug.Log("The same character is selected. Aborting copy.");
        }
        else
        {
            UnityEngine.Debug.Log("");
            UnityEngine.Debug.Log("Found Chararacter: " + ("CHR" + "00" + Line2Int2.ToString("X4") + Line1Int2.ToString("X")));

            UnityEngine.Debug.Log("The tool is about to overwrite the target character's settings.");
            UnityEngine.Debug.Log("Press any key twice to confirm. Close the tool to cancel.");

            
            while (!Input.anyKeyDown)
            {
                yield return null;
            }

            while (!Input.anyKeyDown)
            {
                yield return null;
            }

            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                    UnityEngine.Debug.Log("Copied " + s);
                }

                UnityEngine.Debug.Log("");
                UnityEngine.Debug.Log("Copying complete!");
            }
            else
            {
                UnityEngine.Debug.Log("Target invalid. Aborting copy.");
            }
        }

        UnityEngine.Debug.Log("");
        UnityEngine.Debug.Log("Press any key to exit the tool.");

        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        Application.Quit();
    }
}
