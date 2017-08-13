using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for StringUtility
/// </summary>
public static class StringUtility
{
    //public StringUtility()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    public static string GetTemplate(string name)
    {
        string text = File.ReadAllText(HttpContext.Current.Server.MapPath("/Theme/maintheme/inc/"+ name + ".html"), Encoding.UTF8);
        return text;
    }

    public static string GetKeywordReplace(this string Content, string tagStart, string tagEnd)
    {
        int startIndex = Content.IndexOf(tagStart);
        int endIndex = Content.LastIndexOf(tagEnd) + tagEnd.Length;
        endIndex = endIndex - startIndex;
        return Content.Substring(startIndex, endIndex);
    }

    // EnCode String 
    public static string EncryptedData(this string EncryptedData)
    {
        byte[] data = Encoding.ASCII.GetBytes(EncryptedData);
        string encodeString = Convert.ToBase64String(data);
        return encodeString;
    }

    //Decode String 
    public static string DecryptedData(this string DecryptedData)
    {
        byte[] decodeString = Convert.FromBase64String(DecryptedData);
        string data = Encoding.ASCII.GetString(decodeString);
        return data;
    }


    public static string removehtmlTag(this string str)
    {
        //string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");
        return Regex.Replace(str, "<.*?>", String.Empty);
    }

    public static string getShortContent(this string content)
    {
        string ret = string.Empty;
        int cL = content.Length;
        if (cL > 0)
        {
             ret = content.removehtmlTag();
            if(cL > 300)
            ret = ret.Substring(0, 300 );

        }
        return ret;
    }
}