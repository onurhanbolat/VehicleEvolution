using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMaterial : MonoBehaviour
{
    public static Color GetSaveColor(string key)
    {
        string col = PlayerPrefs.GetString(key);
        Debug.Log(col);
        if (col == "")
        {
            return Color.black;
        }
        string[] strings = col.Split(',');
        Color output = new Color();
        for (int i = 0; i < 4; i++)
        {
            output[i] = System.Single.Parse(strings[i]);
        }
        return output;
    }
    public static bool CheckColor(string key)
    {
        if (PlayerPrefs.HasKey(key))
            return true;
        else
            return false;
    }
    public static void SaveColor(Color color, string key)
    {
        string col = color.ToString();
        col = col.Replace("RGBA(", "");
        col = col.Replace(")", "");
        PlayerPrefs.SetString(key, col);
    }
    public static void SaveColorArray(Color[] col, string key)
    {
        int i = 0;
        PlayerPrefs.SetInt(key, col.Length);
        foreach (Color c in col)
        {
            SaveColor(c, key + i++);
        }
    }
    public static Color[] GetSaveColorArray(string key)
    {
        if (!PlayerPrefs.HasKey(key))
            return null;
        int len = PlayerPrefs.GetInt(key);
        Color[] tem = new Color[len];
        for (int i = 0; i < len; i++)
        {
            tem[i] = GetSaveColor(key + i);
        }
        return tem;
    }
}


