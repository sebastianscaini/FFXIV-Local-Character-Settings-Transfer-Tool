using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using TMPro;
public class SettingsCopier : MonoBehaviour
{
    public TextMeshPro dialogueText;

    void Start()
    {
        StartCoroutine(CopySettings());
    }

    private IEnumerator CopySettings()
    {
        string FFXIVDataPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\My Games\FINAL FANTASY XIV - A Realm Reborn", "FFXIV.cfg");
        string[] FFXIVData = System.IO.File.ReadAllLines(FFXIVDataPath);
        string fileName = "";

        DisplayText("Welcome to FFXIV Local Character Settings Copy Tool!");
        while (!Input.anyKeyDown)
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);

        DisplayText("I strongly recommend backing up: " + System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\My Games\FINAL FANTASY XIV - A Realm Reborn" + " before using this tool!");
        while (!Input.anyKeyDown)
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);

        DisplayText("Let's get started!");
        while (!Input.anyKeyDown)
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);

        DisplayText("Login with the character that you wish to copy the settings from, then log out and close the game. Progress to the next dialogue once you have done so!");
        while (!Input.anyKeyDown)
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);

        FFXIVDataPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\My Games\FINAL FANTASY XIV - A Realm Reborn", "FFXIV.cfg");
        FFXIVData = System.IO.File.ReadAllLines(FFXIVDataPath);

        string Line1 = FFXIVData[12].Replace("LastLogin0	", "");
        string Line2 = FFXIVData[13].Replace("LastLogin1	", "");

        int Line1Int = int.Parse(Line1);
        int Line2Int = int.Parse(Line2);

        string chrPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\My Games\FINAL FANTASY XIV - A Realm Reborn\" + ("FFXIV_CHR" + "00" + Line2Int.ToString("X") + Line1Int.ToString("X")));
        string sourcePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\My Games\FINAL FANTASY XIV - A Realm Reborn\" + ("FFXIV_CHR" + "00" + Line2Int.ToString("X") + Line1Int.ToString("X")));

        DisplayText("I found the character: " + ("CHR" + "00" + Line2Int.ToString("X") + Line1Int.ToString("X")));
        while (!Input.anyKeyDown)
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        DisplayText("Now login with the new character that you wish to copy the settings to, then log out and close the game. Progress to the next dialogue once you have done so!");
        while (!Input.anyKeyDown)
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);

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
            DisplayText("Oh no! It looks like the same character is selected. I'm stopping the copying process, please reopen the tool to try again!");
            while (!Input.anyKeyDown)
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
        }
        else
        {
            UnityEngine.Debug.Log("");
            DisplayText("I found the character: " + ("CHR" + "00" + Line2Int2.ToString("X4") + Line1Int2.ToString("X")));
            while (!Input.anyKeyDown)
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);

            DisplayText("The tool is about to overwrite the target character's settings. Press any key twice to confirm. Close the tool to cancel.");
            while (!Input.anyKeyDown)
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f); 
            
            while (!Input.anyKeyDown)
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);

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

                DisplayText("The copying completed successfully!");
                while (!Input.anyKeyDown)
                {
                    yield return null;
                }
                yield return new WaitForSeconds(0.1f);

                DisplayText("That's it for me, see you soon!");
                while (!Input.anyKeyDown)
                {
                    yield return null;
                }
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                DisplayText("Oh no something went wrong with the copying process. Aborting the copy!");
                while (!Input.anyKeyDown)
                {
                    yield return null;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }

        Application.Quit();
    }

    private void DisplayText(string dialogue)
    {
        dialogueText.text = dialogue;
    }
}
