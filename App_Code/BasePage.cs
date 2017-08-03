using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for BasePage
/// </summary>
/// 

public class BasePage : System.Web.UI.Page
{

    public Model_Users UserActive { get; set; }
    public Model_MainSetting MainSetting { get; set; }



    public string PostTypeID
    {
        get
        {
            return Request.QueryString["PostTypeID"];
        }
    }
    public string TaxTypeID
    {
        get
        {
            return Request.QueryString["TaxTypeID"];
        }
    }

    public string Mode
    {
        get
        {
            return Request.QueryString["Mode"];
        }
    }

    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    protected override void OnLoad(EventArgs e)
    {

        // StaffSessionAuthorize.CheckCooikie();
        Model_MainSetting s = new Model_MainSetting();
        this.MainSetting = s.GetMainSetting();
        Model_Users u = UserSessionController.AdminAppAuthorization(this);

        if (u != null)
            this.UserActive = u;

        base.OnLoad(e);
    }

    public static void RequestLogin()
    {
        HttpContext.Current.Response.Redirect("accessdenie.aspx?error=loginfailed");
    }


    //protected override void Render(HtmlTextWriter writer)
    //{
    //    using (HtmlTextWriter htmlwriter = new HtmlTextWriter(new System.IO.StringWriter()))
    //    {
    //        base.Render(htmlwriter);
    //        string html = htmlwriter.InnerWriter.ToString();
    //        html = html.RemoveWhitespaceFromHtmlPage();
    //        writer.Write(html);
    //    }
    //}
}