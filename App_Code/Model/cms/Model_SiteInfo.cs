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
public class Model_SiteSocialMap : BaseModel<Model_SiteSocialMap>
{

    public byte SocialID { get; set; }
    public byte IFID { get; set; }
    public string Link { get; set; }

    public string  STitle { get; set; }

    public Model_SiteSocialMap()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool UpdateSocial(byte IFID,List<Model_SiteSocialMap> ListAdd)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM WebSiteSocialMap WHERE IFID=@IFID", cn);
            cmd.Parameters.Add("@IFID", SqlDbType.TinyInt).Value = IFID;
            cn.Open();

            ret = ExecuteNonQuery(cmd);

            foreach(Model_SiteSocialMap i in ListAdd)
            {
                SqlCommand cmd1 = new SqlCommand("INSERT INTO  WebSiteSocialMap (SocialID,IFID,Link) VALUES(@SocialID,@IFID,@Link)", cn);
                cmd1.Parameters.Add("@IFID", SqlDbType.TinyInt).Value = i.IFID;
                cmd1.Parameters.Add("@SocialID", SqlDbType.TinyInt).Value = i.SocialID;
                cmd1.Parameters.Add("@Link", SqlDbType.NVarChar).Value = i.Link;

               ret = ExecuteNonQuery(cmd1);
            }
            
        }

        if(ret >0)
            PurgeCacheItems("cache_site_social_s");
        return ret == 1;
    }

    public List<Model_SiteSocialMap> GetSocialMap(byte IFID)
    {
        //BaseModel<Model_Setting>.PurgeCacheItems("mail_setting");
        List<Model_SiteSocialMap> r = null;
        string key = "cache_site_social_s";

        if (BaseModel<Model_SiteSocialMap>.Cache[key] != null)
        {
            r = (List<Model_SiteSocialMap>)BaseModel<Model_SiteSocialMap>.Cache[key];
        }
        else
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT sm.*,s.Title As STitle FROM WebSiteSocialMap sm
                    INNER JOIN Social s ON s.SocialID= sm.SocialID  WHERE sm.IFID=@IFID", cn);
                cmd.Parameters.Add("@IFID", SqlDbType.TinyInt).Value = IFID;
                cn.Open();
                r = MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));


            }
            BaseModel<Model_SiteSocialMap>.CacheData(key, r);
        }



        return r;
    }
}

public class Social : BaseModel<Social>
{
    public byte SocialID { get; set; }
    public string Title { get; set; }
    public bool Status { get; set; }

    public Social()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public List<Social> GetSocialList()
    {
        //BaseModel<Model_Setting>.PurgeCacheItems("mail_setting");
        List<Social> r = null;
        string key = "cache_site_social";

        if (BaseModel<Social>.Cache[key] != null)
        {
            r = (List<Social>)BaseModel<Social>.Cache[key];
        }
        else
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Social WHERE Status=1", cn);
                cn.Open();
                r = MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));


            }
            BaseModel<Social>.CacheData(key, r);
        }



        return r;
    }
}
public class Model_SiteInfo : BaseModel<Model_SiteInfo>
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
    public List<Model_SiteSocialMap> ListSocial {
        get
        {
            if(_listSocial == null)
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

    public Model_SiteInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Model_SiteInfo GetSiteInfo()
    {
        //BaseModel<Model_Setting>.PurgeCacheItems("mail_setting");
        Model_SiteInfo r = null;
        string key = "cache_site_info";

        if (BaseModel<Model_SiteInfo>.Cache[key] != null)
        {
            r = (Model_SiteInfo)BaseModel<Model_SiteInfo>.Cache[key];
        }
        else
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM WebsiteInformation WHERE IFID=1", cn);
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    r = MappingObjectFromDataReaderByName(reader);

            }
            BaseModel<Model_SiteInfo>.CacheData(key, r);
        }



        return r;
    }



    public int InsertSiteInfo(Model_SiteInfo s)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE WebsiteInformation SET Address=@Address,Phone=@Phone,Email=@Email,Fax=@Fax,Lat=@Lat,
        Long=@Long,LogoTopUrl=@LogoTopUrl,LogoFootUrl=@LogoFootUrl,FavIcon=@FavIcon,MainBrochure=@MainBrochure,Slogan=@Slogan,
FooterAbout=@FooterAbout,GoogleAnalytic=@GoogleAnalytic,MapScript=@MapScript WHERE IFID=1", cn);
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = s.Address;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = s.Phone;
            cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = s.Fax;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = s.Email;
            cmd.Parameters.Add("@Lat", SqlDbType.NVarChar).Value = s.Lat;
            cmd.Parameters.Add("@Long", SqlDbType.NVarChar).Value = s.Long;
            cmd.Parameters.Add("@LogoTopUrl", SqlDbType.NVarChar).Value = s.LogoTopUrl;
            cmd.Parameters.Add("@LogoFootUrl", SqlDbType.NVarChar).Value = s.LogoFootUrl;
            cmd.Parameters.Add("@FavIcon", SqlDbType.NVarChar).Value = s.FavIcon;
            cmd.Parameters.Add("@MainBrochure", SqlDbType.NVarChar).Value = s.MainBrochure;
            cmd.Parameters.Add("@Slogan", SqlDbType.NVarChar).Value = s.Slogan;
            cmd.Parameters.Add("@FooterAbout", SqlDbType.NVarChar).Value = s.FooterAbout;
            cmd.Parameters.Add("@GoogleAnalytic", SqlDbType.NVarChar).Value = s.GoogleAnalytic;
            cmd.Parameters.Add("@MapScript", SqlDbType.NVarChar).Value = s.MapScript;
            cn.Open();
            if (ExecuteNonQuery(cmd) < 1)
            {
                SqlCommand cmd1 = new SqlCommand("INSERT INTO WebsiteInformation (Address,Phone,Email,Fax,Lat,Long,LogoTopUrl,LogoFootUrl,FavIcon,MainBrochure,Slogan,FooterAbout,GoogleAnalytic,MapScript)" +
                    " VALUES(@Address,@Phone,@Email,@Fax,@Lat,@Long,@LogoTopUrl,@LogoFootUrl,@FavIcon,@MainBrochure,@Slogan,@FooterAbout,@GoogleAnalytic,@MapScript)", cn);
                cmd1.Parameters.Add("@Address", SqlDbType.NVarChar).Value = s.Address;
                cmd1.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = s.Phone;
                cmd1.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = s.Fax;
                cmd1.Parameters.Add("@Email", SqlDbType.NVarChar).Value = s.Email;
                cmd1.Parameters.Add("@Lat", SqlDbType.NVarChar).Value = s.Lat;
                cmd1.Parameters.Add("@Long", SqlDbType.NVarChar).Value = s.Long;
                cmd1.Parameters.Add("@LogoTopUrl", SqlDbType.NVarChar).Value = s.LogoTopUrl;
                cmd1.Parameters.Add("@LogoFootUrl", SqlDbType.NVarChar).Value = s.LogoFootUrl;
                cmd1.Parameters.Add("@FavIcon", SqlDbType.NVarChar).Value = s.FavIcon;
                cmd1.Parameters.Add("@MainBrochure", SqlDbType.NVarChar).Value = s.MainBrochure;
                cmd1.Parameters.Add("@Slogan", SqlDbType.NVarChar).Value = s.Slogan;
                cmd1.Parameters.Add("@FooterAbout", SqlDbType.NVarChar).Value = s.FooterAbout;
                cmd1.Parameters.Add("@GoogleAnalytic", SqlDbType.NVarChar).Value = s.GoogleAnalytic;
                cmd1.Parameters.Add("@MapScript", SqlDbType.NVarChar).Value = s.MapScript;
                ret = ExecuteNonQuery(cmd1);
            }
            else
                ret = 1;
        }


        if(ret > 0)
            PurgeCacheItems("cache_site_info");
        return ret;
    }


}