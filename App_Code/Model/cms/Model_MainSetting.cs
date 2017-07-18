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

public class Model_MainSetting : BaseModel<Model_MainSetting>
{
    public byte SettingID { get; set; }
    public string WebSiteURL { get; set; }
    public string WebSiteTitle { get; set; }
    public byte UTC { get; set; }
    public string TagLine { get; set; }
    public byte SiteLang { get; set; }
  

    public Model_MainSetting()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Model_MainSetting GetMainSetting()
    {
        //BaseModel<Model_Setting>.PurgeCacheItems("mail_setting");
        Model_MainSetting r = null;
        string key = "cache_site_main_setting";

        if (BaseModel<Model_MainSetting>.Cache[key] != null)
        {
            r = (Model_MainSetting)BaseModel<Model_MainSetting>.Cache[key];
        }
        else
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM MainSetting WHERE SettingID=1", cn);
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    r = MappingObjectFromDataReaderByName(reader);

            }
            BaseModel<Model_MainSetting>.CacheData(key, r);
        }



        return r;
    }



    public int InsertMainSetting(Model_MainSetting s)
    { 
         int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE MainSetting SET WebSiteURL=@WebSiteURL,WebSiteTitle=@WebSiteTitle,UTC=@UTC,TagLine=@TagLine,
        SiteLang=@SiteLang WHERE SettingID=1", cn);
            cmd.Parameters.Add("@WebSiteURL", SqlDbType.NVarChar).Value = s.WebSiteURL;
            cmd.Parameters.Add("@WebSiteTitle", SqlDbType.NVarChar).Value = s.WebSiteTitle;
            cmd.Parameters.Add("@UTC", SqlDbType.TinyInt).Value = s.UTC;
            cmd.Parameters.Add("@TagLine", SqlDbType.NVarChar).Value = s.TagLine;
            cmd.Parameters.Add("@SiteLang", SqlDbType.TinyInt).Value = s.SiteLang;
          
            cmd.Parameters.Add("@SettingID", SqlDbType.TinyInt).Value = s.SettingID;
            cn.Open();
            if (ExecuteNonQuery(cmd) < 1)
            {
                SqlCommand cmd1 = new SqlCommand("INSERT INTO MainSetting (WebSiteURL,WebSiteTitle,UTC,TagLine,SiteLang)" +
                    " VALUES(@WebSiteURL,@WebSiteTitle,@UTC,@TagLine,@SiteLang)", cn);
                cmd1.Parameters.Add("@WebSiteURL", SqlDbType.NVarChar).Value = s.WebSiteURL;
                cmd1.Parameters.Add("@WebSiteTitle", SqlDbType.NVarChar).Value = s.WebSiteTitle;
                cmd1.Parameters.Add("@UTC", SqlDbType.TinyInt).Value = s.UTC;
                cmd1.Parameters.Add("@TagLine", SqlDbType.NVarChar).Value = s.TagLine;
                cmd1.Parameters.Add("@SiteLang", SqlDbType.TinyInt).Value = s.SiteLang;
                ret = ExecuteNonQuery(cmd1);
            }
            else
                ret = 1;
        }


        if(ret > 0)
            PurgeCacheItems("cache_site_main_setting");
        return ret;
    }


}