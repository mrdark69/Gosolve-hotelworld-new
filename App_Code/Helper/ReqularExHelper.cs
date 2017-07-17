using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;


/// <summary>
/// Summary description for ReqularExHelper
/// </summary>
/// 
namespace Interface_API
{
    public static class ReqularExHelper
    {
        public static string RegMiniJson(this string myJSON)
        {
            return Regex.Replace(myJSON, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
        }


        public static string SPClear(this string txt)
        {
            return   Regex.Replace(txt, "[^0-9a-zA-Z-_]+", "");
        }
    }

 
    
}
  