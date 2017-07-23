using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

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



    public static string GenerateSlug(this string phrase)
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

    public static string RemoveAccent(this string txt)
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