using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CmsController
/// </summary>
public class CmsController
{
    public byte IFID { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Fax { get; set; }
    public string Lat { get; set; }
    public string Long { get; set; }
    public string LogoTopUrl { get; set; }
    public string LogoFootUrl { get; set; }
    public string FavIcon { get; set; }
    public string MainBrochure { get; set; }
    public string Slogan { get; set; }
    public string FooterAbout { get; set; }
    public string GoogleAnalytic { get; set; }

    public string MapScript { get; set; }

    private List<Model_SiteSocialMap> _listSocial = null;
    public List<Model_SiteSocialMap> ListSocial
    {
        get
        {
            if (_listSocial == null)
            {
                Model_SiteSocialMap sm = new Model_SiteSocialMap();
                _listSocial = sm.GetSocialMap(this.IFID);
            }
            return _listSocial;
        }
        set
        {
            _listSocial = value;
        }
    }



    public byte SettingID { get; set; }
    public string WebSiteURL { get; set; }
    public string WebSiteTitle { get; set; }
    public byte UTC { get; set; }
    public string TagLine { get; set; }
    public byte SiteLang { get; set; }


    public CmsController()
    {
        //
        // TODO: Add constructor logic here
        //
    }



}