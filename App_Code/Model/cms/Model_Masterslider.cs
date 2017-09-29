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
public class Model_MasterSlider : BaseModel<Model_MasterSlider>
{

    public int MSID { get; set; }
    public int MID { get; set; }
    public string Text1 { get; set; }
    public string Text2 { get; set; }

    public bool Status { get; set; }
    public string Link { get; set; }
    public int Priority { get; set; }


    public string Title { get; set; }
    public string Alt { get; set; }
    public string Path { get; set; }
    public string FileName { get; set; }
    public string MediaFullPath
    {
        get
        {
            Model_MainSetting s = new Model_MainSetting();
            s = s.GetMainSetting();
            return s.WebSiteURL + this.Path + this.FileName;
        }
    }

    public bool ClearSlider()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM MasterSlider ", cn);
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }

    public List<Model_MasterSlider> GetMasterList()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT ms.*,m.Title,m.Alt,m.Path,m.FileName FROM MasterSlider ms
     INNER JOIN Media m ON m.MID=ms.MID
    WHERE ms.Status = 1 ORDER BY ms.Priority ASC", cn);
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public int Insert(Model_MasterSlider ms)
    {
        int ret = 0;
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO MasterSlider (MID,Text1,Text2,Link,Priority) 
                VALUES(@MID,@Text1,@Text2,@Link,@Priority) ;SET @MSID = SCOPE_IDENTITY();", cn);
            cmd.Parameters.Add("@MID", SqlDbType.Int).Value = ms.MID;
            cmd.Parameters.Add("@Text1", SqlDbType.NVarChar).Value = ms.Text1;
            cmd.Parameters.Add("@Text2", SqlDbType.NVarChar).Value = ms.Text2;
            cmd.Parameters.Add("@Link", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = ms.Priority;

            cmd.Parameters.Add("@MSID", SqlDbType.Int).Direction = ParameterDirection.Output;

            cn.Open();
            if(ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@MSID"].Value;

            }
        }

        return ret;
    }
                       
}

public class Model_MasterSliderItem : BaseModel<Model_MasterSliderItem>
{
    public int MIID { get; set; }
    public int MSID { get; set; }
    public int MID { get; set; }
   
    public bool Status { get; set; }
    public string Link { get; set; }
    public int Priority { get; set; }

    public string Title { get; set; }
    public string Alt { get; set; }
    public string Path { get; set; }
    public string FileName { get; set; }
    public string MediaFullPath
    {
        get
        {
            Model_MainSetting s = new Model_MainSetting();
            s = s.GetMainSetting();
            return s.WebSiteURL + this.Path + this.FileName;
        }
    }

    public bool ClearSlider()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM MasterSliderItem ", cn);
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }
    public List<Model_MasterSliderItem> GetMasterItemList(int intMSID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT mi.*,m.Title,m.Alt,m.Path,m.FileName FROM MasterSliderItem mi 
                    INNER JOIN Media m ON m.MID=mi.MID
                    WHERE mi.Status = 1 AND mi.MSID =@MSID ORDER BY mi.Priority ASC", cn);
            cmd.Parameters.Add("@MSID", SqlDbType.Int).Value = intMSID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public List<Model_MasterSliderItem> GetMasterItemList()
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT mi.*,m.Title,m.Alt,m.Path,m.FileName FROM MasterSliderItem mi 
                    INNER JOIN Media m ON m.MID=mi.MID
                    WHERE mi.Status = 1  ORDER BY mi.Priority ASC", cn);
           // cmd.Parameters.Add("@MSID", SqlDbType.Int).Value = intMSID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public int Insert(Model_MasterSliderItem ms)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO MasterSliderItem (MSID,MID,Link,Priority) 
                VALUES(@MSID,@MID,@Link,@Priority) ", cn);
            cmd.Parameters.Add("@MID", SqlDbType.Int).Value = ms.MID;
            cmd.Parameters.Add("@MSID", SqlDbType.Int).Value = ms.MSID;
            cmd.Parameters.Add("@Link", SqlDbType.NVarChar).Value = ms.Link;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = ms.Priority;

           

            cn.Open();
            ret = ExecuteNonQuery(cmd);
           
        }

        return ret;
    }
}

