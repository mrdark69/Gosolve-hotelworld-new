using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _General : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

            
            //Model_Setting c = new Model_Setting();
            Model_MainSetting m = new Model_MainSetting();
            m = m.GetMainSetting();
            //c = c.GetSetting();
            if(m != null)
            {
                tagline.Text = m.TagLine;
                wsurl.Text = m.WebSiteURL;
                wsTitle.Text = m.WebSiteTitle;
                dropStiteLang.SelectedValue = m.SiteLang.ToString();
                timezone_string.Value = m.UTC.ToString();
            }

           


        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Model_MainSetting m = new Model_MainSetting
        {
            SiteLang = byte.Parse(dropStiteLang.SelectedValue),
            UTC = byte.Parse(timezone_string.Value),
            TagLine = tagline.Text.Trim(),
            WebSiteTitle = wsTitle.Text.Trim(),
            WebSiteURL = wsurl.Text.Trim()
        };

        if (m.InsertMainSetting(m) > 0)
            Response.Redirect(Request.Url.ToString());



        //Model_Setting c = new Model_Setting
        //{
        //    ST = byte.Parse(ST.SelectedValue),
        //    APIKEY = APIKEY.Text,
        //    Domain = Domain.Text,
        //    IsSSL = bool.Parse(IsSSL.SelectedValue),
        //    MailAddress = MailAddress.Text,
        //    MailName = MailName.Text,
        //    MailServer = MailServer.Text,
        //    MailServerPass = MailServerPass.Text,
        //    MailServerUser = MailServerUser.Text,
        //    Port = int.Parse(Port.Text)


        //};
        //c.SettingData(c);
    }
}