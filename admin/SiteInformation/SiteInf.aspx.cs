using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _SiteInf : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            Social s = new Social();
            dropSocial.DataSource = s.GetSocialList();
            dropSocial.DataTextField = "Title";
            dropSocial.DataValueField = "SocialID";
            dropSocial.DataBind();

            ListItem l = new ListItem("Select", "0");
            dropSocial.Items.Insert(0, l);
            //Model_Setting c = new Model_Setting();
            //Model_MainSetting m = new Model_MainSetting();
            //m = m.GetMainSetting();
            ////c = c.GetSetting();
            //if(m != null)
            //{
            //    tagline.Text = m.TagLine;
            //    wsurl.Text = m.WebSiteURL;
            //    wsTitle.Text = m.WebSiteTitle;
            //    dropStiteLang.SelectedValue = m.SiteLang.ToString();
            //    timezone_string.Value = m.UTC.ToString();
            //}


        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {


        string dd = Request.Form["chk_social"];
        Response.Write(dd);
        Response.End();
        //Model_MainSetting m = new Model_MainSetting
        //{
        //    SiteLang = byte.Parse(dropStiteLang.SelectedValue),
        //    UTC = byte.Parse(timezone_string.Value),
        //    TagLine = tagline.Text.Trim(),
        //    WebSiteTitle = wsTitle.Text.Trim(),
        //    WebSiteURL = wsurl.Text.Trim()
        //};

        //if (m.InsertMainSetting(m) > 0)
        //    Response.Redirect(Request.Url.ToString());



    }

}