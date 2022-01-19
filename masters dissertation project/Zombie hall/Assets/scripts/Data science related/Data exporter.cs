using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public static  class Dataexporter
{
    private static string filePath;

    private static List<String> exportList = new List<string>();

    public static void SendToExport(string exportString)
    {
        exportList.Add(exportString);

        //Debug.Log(exportList.Count.ToString());
    }

    /// <summary>
    /// Not to be used. Use SendToExport instead.
    /// This is a one-time public to be called OnApplicationQuit because this is NOT a monobehaviour therefore
    /// cannot determine by itself when the application quits. That is handle by PlayerStats.cs
    /// </summary>
    /// <returns></returns>
    public static string ExportData()
    {

        //gross string addition. May clean if close down performance is bad, but shouldn't matter?

        // get unique appExitTime as a string and without punctuation
        String appExitTime = DateTime.Now.ToString();

        StringBuilder sb = new StringBuilder();
        foreach (char c in appExitTime)
        {
            if (!char.IsPunctuation(c) || char.IsWhiteSpace(c))
                sb.Append(c);
        }

        appExitTime = sb.ToString();

        // generate filePath
        string filePath = "";
        filePath += "Assets/Data";
        filePath += "/";
        filePath += appExitTime;

        // create new text file
        System.IO.File.WriteAllText(filePath, "");

        // write all data to file
        using (System.IO.StreamWriter file = new StreamWriter(filePath))
        {
            file.WriteLine("Zombie Hall data file " + appExitTime);
            foreach (string line in exportList)
            {
                Debug.Log(line);
                file.WriteLine(line);
            }
        }

        return filePath;
    }
}
