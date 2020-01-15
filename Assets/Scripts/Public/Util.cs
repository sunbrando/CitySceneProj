using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Util 
{
    public static string passwordPath = UnityEngine.Application.streamingAssetsPath + "/" + "UNITY.txt";

    public static string EncodeBase64( string code)
    {
        string encode = "";
        byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(code);
        try
        {
            encode = Convert.ToBase64String(bytes);
        }
        catch
        {
            encode = code;
        }
        return encode;
    }

    public static string DecodeBase64(string code)
    {
        string decode = "";
        byte[] bytes = Convert.FromBase64String(code);
        try
        {
            decode = Encoding.GetEncoding("utf-8").GetString(bytes);
        }
        catch
        {
            decode = code;
        }
        return decode;
    }

    public static bool IsPass()
    {
        if (File.Exists(passwordPath))
        {
            string text = File.ReadAllText(passwordPath);
            text = DecodeBase64(text);
            DateTime dt = Convert.ToDateTime(text);
            DateTime pastDt = dt.AddDays(30);
            if (DateTime.Compare(pastDt, DateTime.Now) > 0)
                return true;
            else
            {
                File.Delete(passwordPath);
                return false;
            }
        }
        else
            return false;
    }
}
