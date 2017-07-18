using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MVCDatatableApp;
using gs_newsletter;
using System.Web.Providers.Entities;

/// <summary>
/// Summary description for Model_SiteInfo
/// </summary>
/// 

public class Model_PostSeo : BaseModel<Model_Post>
{
    public int PSID { get; set; }

    public int PostID { get; set; }
    public string SEOTitle { get; set; }
    public string MetaDescription { get; set; }
    public string CanonicalUrl { get; set; }
    public string Metarobotsfollow { get; set; }
    public string FaceBookTitle { get; set; }
    public string FacebookDescription { get; set; }
    public string FacebookImage { get; set; }
    public string TwitterTitle { get; set; }

    public string TwitterDescription { get; set; }
    public string TwitterImages { get; set; }
    public string GoogleAnalytic { get; set; }
   


    public Model_PostSeo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

   

}