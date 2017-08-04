using gs_newsletter;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class SiteMaster : MasterPage
{
  
    public string UserStatus()
    {
        StringBuilder ret = new StringBuilder();
        if (Session["staff"] != null)
        {
           
            Model_Session ms = new Model_Session();
            ms = ms.IsHaveSessionRecord(UserSessionController.CurrentCookieLog);


            ret.Append("<span class=\"clear\"> <span class=\"block m-t-xs\"> <strong class=\"font-bold\">Welcome "+ms.FirstName+" </strong>");
            ret.Append("</span> <span class=\"text-muted text-xs block\">" + ms.UserRoleName + " <b class=\"caret\"></b></span> </span> </a>");
           
        }

        return ret.ToString();
    }

    
    

    protected string MenuActive(string file, string ischild = "")
    {
        string ret = string.Empty;


        string[] arrcurrentFile = Request.PhysicalPath.Split('\\');
        string currentFile = arrcurrentFile[arrcurrentFile.Length - 1];

        string[] child = ischild.Split(',');

        if (file.IndexOf(currentFile) >= 0) { ret = "class=\"active\""; } 
        if (child.Length > 0 && !string.IsNullOrEmpty(ischild))
        {
            for(int i = 0;i < child.Length; i++)
            {
                if (child[i].IndexOf(currentFile) >= 0)
                {
                    ret = "class=\"active\"";
                    break;
                }
                   
            }
         
        }
        //child[i].IndexOf(currentFile) >= 0
        //file.IndexOf(currentFile) >= 0

        return ret;
    }

    protected string GetSideMenu()
    {
        StringBuilder ret = new StringBuilder();
        Model_AppModule m = new Model_AppModule();

        Model_AppAction a = new Model_AppAction();
        List<Model_AppModule> cmf = m.getListAppFeature(1);

        string MainAdminSlug = "~/admin/";

        List<Model_AppAction> cmf_child = a.getListAppFeatureAll();

        foreach (Model_AppModule item in cmf)
        {
            List<Model_AppAction> cmf_s = cmf_child.Where(c => c.ModuleID == item.ModuleID).ToList();

            string slug = Page.ResolveClientUrl(MainAdminSlug + item.Slug);
            bool IsChild = false;
            string arrow = string.Empty;
            string child = string.Empty;
            if (cmf_s.Count() > 0)
            {
                slug = "#";
                IsChild = true;
                arrow = "<span class=\"fa arrow\"></span>";

                child = String.Join(",", cmf_s.Select(r => r.Slug).ToArray());
            }

            //" + MenuActive(item.Slug, child) + "
            ret.Append("<li >");
            ret.Append("<a href=\"" + slug + "\"><i class=\""+item.Icon+"\"></i> <span class=\"nav-label\">" + item.Title + "</span>" + arrow + "</a>");


            //" + MenuActive(i.Slug) + "
            if (IsChild)
            {
                ret.Append("<ul class=\"nav nav-second-level\">");
                foreach (Model_AppAction i in cmf_s)
                {
                    string slug_child = Page.ResolveClientUrl(MainAdminSlug + item.Slug + "/" +i.Slug + (!string.IsNullOrEmpty(i.QueryString)? "?"+ i.QueryString.Trim(): "" ));
                    ret.Append("<li ><a href=\"" + slug_child + "\"><i class=\"fa fa-th-large\"></i> <span class=\"nav-label\">" + i.Title + "</span></a></li>");
                }
                ret.Append("</ul>");
            }

            ret.Append("</li>");


        }


        return ret.ToString();
    }
}