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

public class Model_PostBannerType : BaseModel<Model_Post>
{
    public int PostID { get; set; }
    public int PostTypeID { get; set; }
    public string Title { get; set; }
    public string Short { get; set; }
    public string Slug { get; set; }
    public DateTime DateSubmit { get; set; }
    public int UserID { get; set; }
    public DateTime DatePublish { get; set; }
    public bool Status { get; set; }
    public bool ShowComment { get; set; }

    public string BodyContent { get; set; }
    public byte BannerTypeID { get; set; }

    public bool ShowMasterSlider { get; set; }

    public int ViewCount { get; set; }
    

    public Model_PostBannerType()
    {
        //
        // TODO: Add constructor logic here
        //
    }

   

}