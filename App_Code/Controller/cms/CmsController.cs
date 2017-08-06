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
    public static bool UpdateSortMenu(dynamic parameters)
    {
        string MenuGroupID = parameters["GroupID"];
        dynamic[] d = (dynamic[])parameters["arraied"];
        Model_Menu cm = new Model_Menu();
        int x = 0;
        int count = 1;
        string arrId = string.Empty;
        foreach(dynamic i in d)
        {
            if (x > 0)
            {
                string p = (i["parent_id"] == null ?"0" : (string)i["parent_id"]); 
                string ii = (i["id"] == null? "0":(string)i["id"]);


                cm.UpdateSort(int.Parse(ii), int.Parse(p), count);

                    count = count + 1;

                arrId = arrId + "," + ii;
            }

            
            x = x + 1;

        }

        
      cm.DeleteArr(arrId.Substring(1));
        return true;
    }

 

    public static bool InsertMenu(dynamic parameters)
    {

        string cmd = parameters["cmd"];

       // int cmdarg = (int)parameters["cmdarg"];

        string strpost = parameters["strpost"];

        string strarch = parameters["strarch"];

        string strtax = parameters["strtax"];

        string CustomURl = parameters["url"];
        string CustomURlTxt = parameters["txt"];

        string MenuGroupID = parameters["GroupID"];

       
        
        Model_PostType cpt = new Model_PostType();
      


        string Title = string.Empty;

        if (!string.IsNullOrEmpty(cmd))
        {
           

            switch (cmd)
            {
                case "menu_post":

                    if (!string.IsNullOrEmpty(strarch))
                    {
                        byte PostTypeID = byte.Parse(strarch);
                        Model_PostType cPt = new Model_PostType();
                        cpt = cpt.GetPostTypeByID(PostTypeID);

                        Model_Menu cme = new Model_Menu();
                        cme.MGID = int.Parse(MenuGroupID);
                        cme.Title = "All "+  cpt.Title;
                        cme.TitleOrigin = cpt.Slug;
                        cme.Slug = cpt.Slug;
                        cme.CustomUrl = "";
                        cme.Status = true;
                        cme.MenuRefID = 0;
                        cme.Lv = 1;
                        cme.Priority = 1;
                        cme.MCategory = (byte)MenuCategory.Archive;
                        cme.PostTypeID = cpt.PostTypeID;
                        cme.InsertMenuFirst(cme);

                        Model_Archive ma = new Model_Archive();
                        ma.inSertArchiveMap(cpt.PostTypeID, cpt.Slug);
                    }

                    if (!string.IsNullOrEmpty(strpost))
                    {
                       
                        foreach(string post in strpost.Split(','))
                        {
                            int postID = int.Parse(post);
                            Model_Post cP = new Model_Post();
                            cP = cP.GetPostByID(postID);


                            Model_Menu cme = new Model_Menu();
                            cme.MGID = int.Parse(MenuGroupID);
                            cme.Title = cP.Slug;
                            cme.TitleOrigin = cP.Slug;
                            cme.Slug = cP.Slug;
                            cme.CustomUrl = "";
                            cme.Status = true;
                            cme.MenuRefID = 0;
                            cme.Lv = 1;
                            cme.Priority = 1;
                            cme.MCategory = (byte)MenuCategory.Post;
                            cme.PostID = cP.PostID;
                            cme.InsertMenuFirst(cme);
                        }
                    }
                 

                        break;
                case "menu_Tax":

                    if (!string.IsNullOrEmpty(strtax))
                    {

                        foreach (string tax in strtax.Split(','))
                        {
                            int TaxId = int.Parse(tax);
                            Model_PostTaxonomy mp = new Model_PostTaxonomy();
                            mp = mp.GetTaxonomyByID(TaxId);


                            Model_Menu cme = new Model_Menu();
                            cme.MGID = int.Parse(MenuGroupID);
                            cme.Title = mp.Slug;
                            cme.TitleOrigin = mp.Slug;
                            cme.Slug = mp.Slug;
                            cme.CustomUrl = "";
                            cme.Status = true;
                            cme.MenuRefID = 0;
                            cme.Lv = 1;
                            cme.Priority = 1;
                            cme.MCategory = (byte)MenuCategory.Taxonomy;
                            cme.TaxID = mp.TaxID;
                            cme.InsertMenuFirst(cme);
                        }
                    }
                    // mCat = MenuCategory.Taxonomy;
                    break;
                case "menu_custom":

                    if(!string.IsNullOrEmpty(CustomURl) && !string.IsNullOrEmpty(CustomURlTxt))
                    {
                       

                        Model_Menu cme = new Model_Menu();
                        cme.MGID = int.Parse(MenuGroupID);
                        cme.Title = CustomURlTxt;
                        cme.TitleOrigin = CustomURlTxt;
                        cme.Slug = CustomURlTxt;
                        cme.CustomUrl = CustomURl;
                        cme.Status = true;
                        cme.MenuRefID = 0;
                        cme.Lv = 1;
                        cme.Priority = 1;
                        cme.MCategory = (byte)MenuCategory.CustomLink;
                        cme.PostTypeID = cpt.PostTypeID;
                        cme.InsertMenuFirst(cme);
                    }
                   
                    // mCat = MenuCategory.CustomLink;
                    break;
            }
        }


        //Model_Menu cme = new Model_Menu
        //{

        //    Title = "",
        //    TitleOrigin = "",
        //    Slug="",
        //    CustomUrl = "",
        //    Status = true,
        //    MenuRefID= 0,
        //    Lv = 1,
        //    IsCustomUrl = true,
        //    Priority=1,
        //    MCategory = (byte)mCat,
        //    TaxID=1,
        //    PostTypeID=1,
        //    PostID = 1
        //};

        return true;
    }
}