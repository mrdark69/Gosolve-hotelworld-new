﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for UserSessionController
/// </summary>
public class UserSessionController
{
    public static int CurrentCookieLog
    {
        get
        {
            return int.Parse(HttpContext.Current.Request.Cookies["SessionKey"]["LogKey"]);
        }
    }
    private string AuthorizeBaseUrl
    {
        get { return ConfigurationManager.AppSettings["AuthorizeBaseURL"].ToString(); }
    }
    public UserSessionController()
    {
      
        //
        // TODO: Add constructor logic here
        //
    }

    public static void SessionCreate(Model_Users Users)
    {
       
        HttpSessionState Hotels2Session = HttpContext.Current.Session;
        Hotels2Session["staff"] = Users.UserCatId;

        Model_Session ms = new Model_Session();
        
        int Key = ms.InsertUserToSesstionRecord(Users);

        //creat Cookie for Reference user Login Life Time
        CreateCookieSession(Key);

        HttpContext.Current.Response.Redirect("~/admin/");
        HttpContext.Current.Response.End();

    }


    public static void CloseOtherCurrentLogin(int UserID)
    {
        Model_Session ms = new Model_Session();

        int Key = ms.CloseOtherCurrentLogin(UserID);
    }

    public static void CreateCookieSession(int intKey)
    {
        HttpCookie cookiesSessionKey = new HttpCookie("SessionKey");
        cookiesSessionKey.Values["LogKey"] = intKey.ToString();
        cookiesSessionKey.Values["LangActive"] = "1";
        cookiesSessionKey.Expires = DateTime.Now.AddMonths(1);
        HttpContext.Current.Response.Cookies.Add(cookiesSessionKey);
    }

    public static void Logout()
    {
        HttpCookie objCookie = HttpContext.Current.Request.Cookies["SessionKey"];
        objCookie.Expires = DateTime.Now.AddDays(-1D);
        HttpContext.Current.Response.Cookies.Add(objCookie);

        HttpSessionState Hotels2Session = HttpContext.Current.Session;

        int intLogKey = int.Parse(HttpContext.Current.Request.Cookies["SessionKey"]["LogKey"]);
        UpdateSessionLogout(intLogKey);

        Hotels2Session.Clear();
       // HttpContext.Current.Response.Redirect("~/admin/accessdenie.aspx?error=logout");

        HttpContext.Current.Response.Redirect("~/admin/login");

    }

    public static bool UpdateSessionLogout(int intSesstionId)
    {
        Model_Session ms = new Model_Session
        {
            UserSessionID = intSesstionId
        };
      
        return ms.UpdateSessionAuthorizeLogOut(ms);
    }



    public static void AdminAppAuthorization(Page p)
    {
        
        HttpSessionState Hotels2Session = HttpContext.Current.Session;
        //object objSession = HttpContext.Current.Session["staff"];
        HttpCookie objCookie = HttpContext.Current.Request.Cookies["SessionKey"];
        Model_Session ms = new Model_Session();
       
        object objSession = Hotels2Session["staff"];
        int intLogKey = 0;


        if (objSession == null && objCookie == null)
        {
            //HttpContext.Current.Response.Redirect("~/admin/accessdenie.aspx?error=requestlogin_111");
            HttpContext.Current.Response.Redirect("~/admin/login");
            HttpContext.Current.Response.End();
        }


        if (objSession != null && objCookie == null)
        {
            //HttpContext.Current.Response.Redirect("~/admin/accessdenie.aspx?error=requestlogin_444");
            HttpContext.Current.Response.Redirect("~/admin/login");
            HttpContext.Current.Response.End();
        }

        if (objCookie != null)
        {
            intLogKey = int.Parse(objCookie["LogKey"]);
            ms = ms.IsHaveSessionRecord(intLogKey);


            if (ms == null)
            {
                //HttpContext.Current.Response.Redirect("~/admin/accessdenie.aspx?error=requestlogin_333");
                HttpContext.Current.Response.Redirect("~/admin/login");
                HttpContext.Current.Response.End();
            }


            Model_Users u = UsersController.GetUserbyID(ms.UserID);
           
            if (!u.Status)
            {
                LogoutStaffNotActivate();
            }

            if (ms.LeaveTime.HasValue)
            {
                //string message = "AccessKey: " + intLogKey + " SessionStaffValue:" + objSession + " LeaveTime: " + (!clStaffSesssion.LeaveTime.HasValue ? "NULL" : ((DateTime)clStaffSesssion.LeaveTime).ToString());
                //try
                //{
                //    Hotels2thailand.Hotels2MAilSender.Sendmail("it@bluehousetravel.com", "Booking2Staff Error", "it@bluehousetravel.com", "StaffLogin Fail:access denided from bht staff with empty leavtime", "", message);
                //}
                //catch { }


                //objLog.WriteLog(EnumCodeLog.ServiceUnavailable, EnumLevelLog.Error, "StaffLogin", message, null);

                //HttpContext.Current.Response.Redirect("~/admin/accessdenie.aspx?error=requestlogin_222");

                

                HttpContext.Current.Response.Redirect("~/admin/login");
                HttpContext.Current.Response.End();
            }


            Hotels2Session["staff"] = u.UserCatId.ToString();
            UpdateSessionStatus(intLogKey);


            if (!IsAuthorizePage(u, ConfigurationManager.AppSettings["AuthorizeBaseURL"].ToString()))
            {
                
                try
                {
                    HttpContext.Current.Response.Redirect(HttpContext.Current.Request.UrlReferrer.ToString() + "#accessdinied");
                }
                catch 
                {
                    HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.ToString() + "#accessdinied");
                }
                
                //HiddenField h = (HiddenField)p.FindControl("hdAlert");
                //HttpContext.Current.Response.Write(p);
                //h.Value = "False";
                HttpContext.Current.Response.End();
                //Page page = HttpContext.Current.Request.pag
                //ScriptManager.RegisterStartupScript(this, Page.GetType(), null, script, false);
                // HttpContext.Current.Response.Redirect("~/admin/accessdenie.aspx?error=accessdenied");
                // 
            }

        }

        //Action Method

        
        //else
        //{
        //    HttpSessionState Hotels2SessionMethod = HttpContext.Current.Session;
        //    Hotels2SessionMethod["Method"] = clStaffSesssion.HotelsSessionItem + ";null";
        //}




    }

    public static bool UpdateSessionStatus(int intSesstionId)
    {
        Model_Session clStaffSession = new Model_Session
        {
            UserSessionID = intSesstionId,
        };
        return clStaffSession.UpdateSessionAuthorize(clStaffSession);
    }
    public static void LogoutStaffNotActivate()
    {
        HttpCookie objCookie = HttpContext.Current.Request.Cookies["SessionKey"];
        objCookie.Expires = DateTime.Now.ToThaiDateTime().AddDays(-1D);
        HttpContext.Current.Response.Cookies.Add(objCookie);

        HttpSessionState Hotels2Session = HttpContext.Current.Session;

        int intLogKey = int.Parse(HttpContext.Current.Request.Cookies["SessionKey"]["LogKey"]);
        UpdateSessionLogout(intLogKey);

        Hotels2Session.Clear();
        HttpContext.Current.Response.Redirect("~/admin/accessdenie.aspx?error=noactivate");
        HttpContext.Current.Response.End();
    }

    private static bool IsAuthorizePage(Model_Users u, string AuthorizeBaseUrl)
    {

        bool condition = false;
        //Loop in record in URL in case Detected!!
        if (AuthorizeBaseUrl == "*")
        {
            condition = true;
        }
        else
        {
            
            List<Model_AppFeatureRole> ar = UsersController.GetAppFeatureAuthen(u.UsersRoleId);
            if (ar.Count > 0)
            {
                string url = HttpContext.Current.Request.Url.ToString();

                string BaseApp = ConfigurationManager.AppSettings["AuthorizeBaseURL"].ToString();
                url = url.Split('?')[0];
                //string[] arrurl = url.Split('/');
                //url = arrurl[arrurl.Length - 1];


                foreach(Model_AppFeatureRole a in ar)
                {
                    string maincompare = BaseApp + a.SlugModule + "/" + a.SlugAction;

                    if(url.ToLower() == maincompare.ToLower() || url.ToLower() == (BaseApp + "Default").ToLower() || url.ToLower() == (BaseApp + "Default.aspx").ToLower()  || url.ToLower() == BaseApp.ToLower())
                    {
                        condition = true;
                        break;
                    }
                }
                
            }
           
            //StaffPageAuthorize staffPage = new StaffPageAuthorize();
            //ArrayList dicPage = staffPage.getListPageByCatId(byte.Parse(this.HotelsSessionItem));

            //if (dicPage.Count > 0)
            //{
            //    if (this.CurrentURL.Replace("http://", " ").Trim().Split('/').Count() >= 4)
            //    {

            //        foreach (string page in dicPage)
            //        {
            //            string Pattern = this.AuthorizeBaseUrl + page.Split('!')[0] + "/" + page.Split('!')[1];

            //            string PatternExtra = this.AuthorizeBaseURL_Extra_BlueHouse_Staff + page.Split('!')[0] + "/" + page.Split('!')[1];


            //            if (this.CurrentURL.Split('?')[0] == Pattern || !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["t"]))
            //            {
            //                condition = true;
            //                break;
            //            }


            //            if (this.CurrentURL.Split('?')[0] == PatternExtra || !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["t"]))
            //            {
            //                condition = true;
            //                break;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        condition = true;
            //    }

            //}
        }

        return condition;

    }
}