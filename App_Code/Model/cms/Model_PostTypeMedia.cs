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

public enum PostTypeMediaType : byte
{
    CoverImage = 1,
    FeatureImage = 2,
    Gallery = 3,
    Feature_Image_full_Width = 4

}
public class Model_PostTypeMedia : BaseModel<Model_PostTypeMedia>
{
    public int PostTypeMediaID { get; set; }

    public PostTypeMediaType PostTypeMediaTypeID { get; set; }
    public int PostTypeID { get; set; }
    public int MID { get; set; }
    public int Priority { get; set; } = 1;
    public string Caption { get; set; } = string.Empty;


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
    public Model_PostTypeMedia()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int insertMediaPostGall(Model_PostTypeMedia mp)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            
            SqlCommand cmd = new SqlCommand(@"INSERT INTO PostTypeMedia (PostTypeMediaTypeID,PostTypeID,MID,Priority,Caption) VALUES(@PostTypeMediaTypeID,@PostTypeID,@MID,@Priority,@Caption) ", cn);
            cmd.Parameters.Add("@PostTypeMediaTypeID", SqlDbType.TinyInt).Value = mp.PostTypeMediaTypeID;
            cmd.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = mp.PostTypeID;
            cmd.Parameters.Add("@MID", SqlDbType.TinyInt).Value = mp.MID;
            cmd.Parameters.Add("@Priority", SqlDbType.TinyInt).Value = mp.Priority;
            cmd.Parameters.Add("@Caption", SqlDbType.NVarChar).Value = mp.Caption;
            cn.Open();
            return ExecuteNonQuery(cmd);

        }
    }
    public int insertMediaPost(Model_PostTypeMedia mp)
    {
       using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {

            SqlCommand cmddel = new SqlCommand(@"DELETE FROM PostTypeMedia WHERE PostTypeMediaTypeID=@PostTypeMediaTypeID AND 
        PostTypeID=@PostTypeID ", cn);
            cn.Open();
           // AND MID = @MID
            cmddel.Parameters.Add("@PostTypeMediaTypeID", SqlDbType.TinyInt).Value = mp.PostTypeMediaTypeID;
            cmddel.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = mp.PostTypeID;
           // cmddel.Parameters.Add("@MID", SqlDbType.TinyInt).Value = mp.MID;

            ExecuteNonQuery(cmddel);

            SqlCommand cmd = new SqlCommand(@"INSERT INTO PostTypeMedia (PostTypeMediaTypeID,PostTypeID,MID,Priority,Caption) VALUES(@PostTypeMediaTypeID,@PostTypeID,@MID,@Priority,@Caption) ", cn);
            cmd.Parameters.Add("@PostTypeMediaTypeID", SqlDbType.TinyInt).Value = mp.PostTypeMediaTypeID;
            cmd.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = mp.PostTypeID;
            cmd.Parameters.Add("@MID", SqlDbType.TinyInt).Value = mp.MID;
            cmd.Parameters.Add("@Priority", SqlDbType.TinyInt).Value = mp.Priority;
            cmd.Parameters.Add("@Caption", SqlDbType.NVarChar).Value = mp.Caption;


            return ExecuteNonQuery(cmd);
          
        }
    }
    public bool DeletePostTypeMedia(Model_PostTypeMedia mp)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {

            SqlCommand cmddel = new SqlCommand(@"DELETE FROM PostTypeMedia WHERE PostTypeMediaTypeID=@PostTypeMediaTypeID AND 
        PostTypeID=@PostTypeID ", cn);
            cn.Open();

            cmddel.Parameters.Add("@PostTypeMediaTypeID", SqlDbType.TinyInt).Value = mp.PostTypeMediaTypeID;
            cmddel.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = mp.PostTypeID;



            


            return ExecuteNonQuery(cmddel) == 1;

        }
    }

    public List<Model_PostTypeMedia> getPostTypeMedia(int PostTypeID, byte PostTypeMediaTypeID)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT pm.*,m.Title,m.Alt,m.Path,m.FileName FROM PostTypeMedia pm INNER JOIN Media m ON m.MID=pm.MID WHERE PostTypeID=@PostTypeID AND PostTypeMediaTypeID=@PostTypeMediaTypeID", cn);
            cmd.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = PostTypeID;
            cmd.Parameters.Add("@PostTypeMediaTypeID", SqlDbType.TinyInt).Value = PostTypeMediaTypeID;
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }

    public List<Model_PostTypeMedia> getPostTypeMediaByPostTypeID(int PostTypeID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT pm.*,m.Title,m.Alt,m.Path,m.FileName FROM PostTypeMedia pm 
        INNER JOIN Media m ON m.MID=pm.MID WHERE  PostTypeID=@PostTypeID", cn);
            cmd.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = PostTypeID;
          
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }

}