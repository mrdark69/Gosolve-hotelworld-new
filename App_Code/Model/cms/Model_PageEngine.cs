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
public class Model_PageEngine : BaseModel<Model_PageEngine>
{
    public Model_SiteInfo SiteInfo { get; set; }

    public Model_MainSetting MainSetting { get; set; }

    public List<Model_Menu> NavMenu { get; set; }

    public List<Model_Menu> FooterMenu { get; set; }

    public Model_PostSeo SEO { get; set; }
}

    