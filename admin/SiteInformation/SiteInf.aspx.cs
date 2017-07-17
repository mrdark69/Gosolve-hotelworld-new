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


            Model_SiteInfo ms = new Model_SiteInfo();
            ms = ms.GetSiteInfo();
            if (ms != null)
            {
               s_address.Text = ms.Address;
               s_phone.Text = ms.Phone;
                s_Email.Text = ms.Email;
                s_fax.Text = ms.Fax;
                s_lat.Text = ms.Lat;
                s_long.Text = ms.Long;
                lblLogoTop.Value = ms.LogoTopUrl;
                lblLogoFoot.Value = ms.LogoFootUrl;
                lblFavIcon.Value = ms.FavIcon;
                lblBrochure.Value = ms.MainBrochure;
                s_slocan.Text = ms.Slogan;
                s_about.Text = ms.FooterAbout;
                s_googleanlytic.Text = ms.GoogleAnalytic;
                s_MapScript.Text = ms.MapScript;

                Model_SiteSocialMap ss = new Model_SiteSocialMap();
              

                dropSocial_ret.DataSource = ss.GetSocialMap(ms.IFID);
                dropSocial_ret.DataTextField = "Link";
                dropSocial_ret.DataValueField = "SocialID";
                dropSocial_ret.DataBind();
            }

            


        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool ret = false;

        Model_SiteInfo ms = new Model_SiteInfo
        {
            Address = s_address.Text.Trim(),
            Phone = s_phone.Text.Trim(),
            Email = s_Email.Text.Trim(),
            Fax = s_fax.Text.Trim(),
            Lat = s_lat.Text.Trim(),
            Long = s_long.Text.Trim(),
            LogoTopUrl = lblLogoTop.Value.Trim(),
            LogoFootUrl = lblLogoFoot.Value.Trim(),
            FavIcon = lblFavIcon.Value.Trim(),
            MainBrochure = lblBrochure.Value.Trim(),
            Slogan = s_slocan.Text.Trim(),
            FooterAbout = s_about.Text.Trim(),
            GoogleAnalytic = s_googleanlytic.Text,
            MapScript = s_MapScript.Text
           
        };

        ret = ms.InsertSiteInfo(ms) == 1;

        List<Model_SiteSocialMap> ls = new List<Model_SiteSocialMap>();
        if (!string.IsNullOrEmpty(Request.Form["chk_social"]))
        {
            string dd = Request.Form["chk_social"];
            string[] arrs = dd.Split(',');
            if (arrs.Length > 0)
            {
                foreach (string i in arrs)
                {
                    ls.Add(new Model_SiteSocialMap
                    {
                        IFID = 1,
                        Link = Request.Form["link_s_" + i],

                        SocialID = byte.Parse(Request.Form["sel_" + i])

                    });
                }

            }


            Model_SiteSocialMap sm = new Model_SiteSocialMap();
            ret= sm.UpdateSocial(1, ls);
        }


        if (ret)
            Response.Redirect(Request.Url.ToString());
       



    }

}