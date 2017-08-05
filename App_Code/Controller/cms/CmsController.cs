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
    public static Model_Post GetPostByID(int PostID)
    {
        Model_Post post = new Model_Post();
        return post.GetPostByID(PostID);
    }

    public static Model_Post GetPostSlug(string Slug)
    {
        Model_Post post = new Model_Post();
        return post.GetPostBySlug(Slug);
    }

    public static List<Model_Post> GetPostArchive(byte PostTypeID)
    {
        Model_Post post = new Model_Post();
        return post.GetPostArchiveByPostType(PostTypeID);
    }

    public static bool InsertMenu(dynamic parameters)
    {

        string cmd = parameters["cmd"];

        string cmdarg = parameters["cmdarg"];

        string strpost = parameters["strpost"];

        string strarch = parameters["strarch"];

        MenuCategory mCat = 0;

        if (!string.IsNullOrEmpty(cmd))
        {
            switch (cmd)
            {
                case "menu_post":

                    if (!string.IsNullOrEmpty(strarch))
                    {
                        mCat = MenuCategory.Archive;

                    }

                    if (!string.IsNullOrEmpty(strpost))
                    {
                        mCat = MenuCategory.Post;

                    }


                        break;
                case "menu_Tax":
                    mCat = MenuCategory.Taxonomy;
                    break;
                case "menu_custom":
                    mCat = MenuCategory.CustomLink;
                    break;
            }
        }


        Model_Menu cme = new Model_Menu
        {
            MGID = 0,
            Title = "",
            TitleOrigin = "",
            Slug="",
            MenuTypeID= 2,
            CustomUrl = "",
            Status = true,
            MenuRefID= 0,
            Lv = 1,
            IsCustomUrl = true,
            Priority=1,
            MCategory = 1,
            TaxID=1,
            PostTypeID=1,
            PostID = 1
        };

        return true;
    }
}