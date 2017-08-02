using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using SlugityLib;

/// <summary>
/// Summary description for AppTool
/// </summary>
public static class AppTools
{

    //private static readonly Regex RegexBetweenTags = new Regex(@"&gt;(?! )\s+", RegexOptions.Compiled);
    //private static readonly Regex RegexLineBreaks = new Regex(@"([\n\s])+?(?&lt;= {2,})&lt;&quot;", RegexOptions.Compiled);

    public static string ImportPath()
    {
        return ConfigurationManager.AppSettings["ImportPath"];
    }

    public static string UploadMediaPath()
    {
        return ConfigurationManager.AppSettings["UploadMediaPath"];
    }

    public static string TemplateMockPath()
    {
        return ConfigurationManager.AppSettings["TemplateMockPath"];
    }

    


    public static void SendResponse(HttpResponse response, object result)
    {
        response.Clear();
        response.Headers.Add("X-Content-Type-Options", "nosniff");
        response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
        response.ContentType = "application/json; charset=utf-8";
        response.Write(result);
        response.Flush();
        response.End();
    }

    public static string GenerateSlug_2(this string phrase)
    {
        string str = phrase.RemoveAccent().ToLower();
        // invalid chars           
        str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
        // convert multiple spaces into one space   
        str = Regex.Replace(str, @"\s+", " ").Trim();
        // cut and trim 
        str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
        str = Regex.Replace(str, @"\s", "-"); // hyphens   
        return str;
    }
    public static string GenerateSlug(this string title, int maxLength = 60)
    {
        var match = Regex.Match(title.ToLower(), "[\\w]+");
        StringBuilder result = new StringBuilder("");
        bool maxLengthHit = false;
        while (match.Success && !maxLengthHit)
        {
            if (result.Length + match.Value.Length <= maxLength)
            {
                result.Append(match.Value + "-");
            }
            else
            {
                maxLengthHit = true;
                // Handle a situation where there is only one word and it is greater than the max length.
                if (result.Length == 0) result.Append(match.Value.Substring(0, maxLength));
            }
            match = match.NextMatch();
        }
        // Remove trailing '-'
        if (result[result.Length - 1] == '-') result.Remove(result.Length - 1, 1);
        return result.ToString();
    }
    public static string GenerateSlug_3(this string phrase)
    {



        var slugity = new Slugity();
        string slug = slugity.GenerateSlug(phrase);
        return slug;
    }


    public static string GenerateSlug_1(this string value)
    {

        //First to lower case 
        value = value.ToLowerInvariant();

        //Remove all accents
        var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);

        value = Encoding.ASCII.GetString(bytes);

        //Replace spaces 
        value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

        //Remove invalid chars 
        value = Regex.Replace(value, @"[^\w\s\p{Pd}]", "", RegexOptions.Compiled);

        //Trim dashes from end 
        value = value.Trim('-', '_');

        //Replace double occurences of - or \_ 
        value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

        return value;
    }


    public static string RemoveAccent(this string txt)
    {
        byte[]  tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(txt);
        string asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);

        return asciiStr;
        //byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
        //return System.Text.Encoding.ASCII.GetString(bytes);
    }

    public static string RemoveAccentThai(this string txt)
    {
        byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
        return System.Text.Encoding.ASCII.GetString(bytes);
    }
        //public static string RemoveWhitespaceFromHtmlPage(this string html)
        //{
        //    html = RegexBetweenTags.Replace(html, "&gt;");
        //    html = RegexLineBreaks.Replace(html, "&lt;&quot;");
        //      return html.Trim();
        //}
        //protected override void Render(HtmlTextWriter writer)
        //{
        //    using (HtmlTextWriter htmlwriter = new HtmlTextWriter(new System.IO.StringWriter()))
        //    {
        //        base.Render(htmlwriter);
        //        string html = htmlwriter.InnerWriter.ToString();
        //        html = RemoveWhitespaceFromHtmlPage(html);
        //        writer.Write(html);
        //    }
        //}

}