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

public enum PostMediaType : byte
{
    CoverImage = 1,
    FeatureImage = 2,
    Gallery = 3,
    Feature_Image_full_Width = 4

}
public class Model_PostMedia : BaseModel<Model_PostMedia>
{
    public int PostMediaID { get; set; }

    public PostMediaType PostMediaTypeID { get; set; }
    public int PostID { get; set; }
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
            if (!string.IsNullOrEmpty(this.Path) && !string.IsNullOrEmpty(this.FileName))
                return s.WebSiteURL + this.Path + this.FileName;
            else
                return s.WebSiteURL + "Content/img/1.jpg";
        }
    }
    public Model_PostMedia()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int insertMediaPostGall(Model_PostMedia mp)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            
            SqlCommand cmd = new SqlCommand(@"INSERT INTO PostMedia (PostMediaTypeID,PostID,MID,Priority,Caption) VALUES(@PostMediaTypeID,@PostID,@MID,@Priority,@Caption) ", cn);
            cmd.Parameters.Add("@PostMediaTypeID", SqlDbType.TinyInt).Value = mp.PostMediaTypeID;
            cmd.Parameters.Add("@PostID", SqlDbType.TinyInt).Value = mp.PostID;
            cmd.Parameters.Add("@MID", SqlDbType.TinyInt).Value = mp.MID;
            cmd.Parameters.Add("@Priority", SqlDbType.TinyInt).Value = mp.Priority;
            cmd.Parameters.Add("@Caption", SqlDbType.NVarChar).Value = mp.Caption;
            cn.Open();
            return ExecuteNonQuery(cmd);

        }
    }
    public int insertMediaPost(Model_PostMedia mp)
    {
       using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {

            SqlCommand cmddel = new SqlCommand(@"DELETE FROM PostMedia WHERE PostMediaTypeID=@PostMediaTypeID AND 
        PostID=@PostID ", cn);
            cn.Open();
           // AND MID = @MID
            cmddel.Parameters.Add("@PostMediaTypeID", SqlDbType.TinyInt).Value = mp.PostMediaTypeID;
            cmddel.Parameters.Add("@PostID", SqlDbType.TinyInt).Value = mp.PostID;
           // cmddel.Parameters.Add("@MID", SqlDbType.TinyInt).Value = mp.MID;

            ExecuteNonQuery(cmddel);

            SqlCommand cmd = new SqlCommand(@"INSERT INTO PostMedia (PostMediaTypeID,PostID,MID,Priority,Caption) VALUES(@PostMediaTypeID,@PostID,@MID,@Priority,@Caption) ", cn);
            cmd.Parameters.Add("@PostMediaTypeID", SqlDbType.TinyInt).Value = mp.PostMediaTypeID;
            cmd.Parameters.Add("@PostID", SqlDbType.TinyInt).Value = mp.PostID;
            cmd.Parameters.Add("@MID", SqlDbType.TinyInt).Value = mp.MID;
            cmd.Parameters.Add("@Priority", SqlDbType.TinyInt).Value = mp.Priority;
            cmd.Parameters.Add("@Caption", SqlDbType.NVarChar).Value = mp.Caption;


            return ExecuteNonQuery(cmd);
          
        }
    }
    public bool DeletePostMedia(Model_PostMedia mp)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {

            SqlCommand cmddel = new SqlCommand(@"DELETE FROM PostMedia WHERE PostMediaTypeID=@PostMediaTypeID AND 
        PostID=@PostID ", cn);
            cn.Open();

            cmddel.Parameters.Add("@PostMediaTypeID", SqlDbType.TinyInt).Value = mp.PostMediaTypeID;
            cmddel.Parameters.Add("@PostID", SqlDbType.TinyInt).Value = mp.PostID;



            


            return ExecuteNonQuery(cmddel) == 1;

        }
    }

    public List<Model_PostMedia> getPostMedia(int PostID, byte PostMediaTypeID)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT pm.*,m.Title,m.Alt,m.Path,m.FileName FROM PostMedia pm INNER JOIN Media m ON m.MID=pm.MID WHERE PostID=@PostID AND PostMediaTypeID=@PostMediaTypeID", cn);
            cmd.Parameters.Add("@PostID", SqlDbType.TinyInt).Value = PostID;
            cmd.Parameters.Add("@PostMediaTypeID", SqlDbType.TinyInt).Value = PostMediaTypeID;
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }

    public List<Model_PostMedia> getPostMediaByPostID(int PostID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT pm.*,m.Title,m.Alt,m.Path,m.FileName FROM PostMedia pm 
        INNER JOIN Media m ON m.MID=pm.MID WHERE  PostID=@PostID", cn);
            cmd.Parameters.Add("@PostID", SqlDbType.TinyInt).Value = PostID;
          
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }

}