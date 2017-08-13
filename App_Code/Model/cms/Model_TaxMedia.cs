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

public enum TaxMediaType : byte
{
    CoverImage = 1,
    FeatureImage = 2,
    Feature_Image_full_Width = 3,
    Banner_Upsell = 4

}
public class Model_TaxMedia : BaseModel<Model_TaxMedia>
{
    public int TaxMediaID { get; set; }

    public TaxMediaType TaxMediaTypeID { get; set; }
    public int TaxID { get; set; }
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
            return this.Path + this.FileName;
        }
    }
    public Model_TaxMedia()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int insertMediaPost(Model_TaxMedia mp)
    {
       using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {

            SqlCommand cmddel = new SqlCommand(@"DELETE FROM TaxonomyMedia WHERE TaxMediaTypeID=@TaxMediaTypeID AND 
        TaxID=@TaxID AND MID=@MID", cn);
            cn.Open();

            cmddel.Parameters.Add("@TaxMediaTypeID", SqlDbType.TinyInt).Value = mp.TaxMediaTypeID;
            cmddel.Parameters.Add("@TaxID", SqlDbType.TinyInt).Value = mp.TaxID;
            cmddel.Parameters.Add("@MID", SqlDbType.TinyInt).Value = mp.MID;

            ExecuteNonQuery(cmddel);

            SqlCommand cmd = new SqlCommand(@"INSERT INTO TaxonomyMedia (TaxMediaTypeID,TaxID,MID,Priority,Caption) VALUES(@TaxMediaTypeID,@TaxID,@MID,@Priority,@Caption) ", cn);
            cmd.Parameters.Add("@TaxMediaTypeID", SqlDbType.TinyInt).Value = mp.TaxMediaTypeID;
            cmd.Parameters.Add("@TaxID", SqlDbType.TinyInt).Value = mp.TaxID;
            cmd.Parameters.Add("@MID", SqlDbType.TinyInt).Value = mp.MID;
            cmd.Parameters.Add("@Priority", SqlDbType.TinyInt).Value = mp.Priority;
            cmd.Parameters.Add("@Caption", SqlDbType.NVarChar).Value = mp.Caption;


            return ExecuteNonQuery(cmd);
          
        }
    }
    public bool DeleteTaxMedia(Model_TaxMedia mp)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {

            SqlCommand cmddel = new SqlCommand(@"DELETE FROM TaxonomyMedia WHERE TaxMediaTypeID=@TaxMediaTypeID AND 
        TaxID=@TaxID ", cn);
            cn.Open();

            cmddel.Parameters.Add("@TaxMediaTypeID", SqlDbType.TinyInt).Value = mp.TaxMediaTypeID;
            cmddel.Parameters.Add("@TaxID", SqlDbType.TinyInt).Value = mp.TaxID;
        
       



            return ExecuteNonQuery(cmddel) == 1;

        }
    }

    public List<Model_TaxMedia> getPostMedia(int TaxID, byte TaxMediaTypeID)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT pm.*,m.Title,m.Alt,m.Path,m.FileName FROM TaxonomyMedia pm INNER JOIN Media m ON m.MID=pm.MID WHERE TaxID=@TaxID AND TaxMediaTypeID=@TaxMediaTypeID", cn);
            cmd.Parameters.Add("@TaxID", SqlDbType.TinyInt).Value = TaxID;
            cmd.Parameters.Add("@TaxMediaTypeID", SqlDbType.TinyInt).Value = TaxMediaTypeID;
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }

    public List<Model_TaxMedia> getPostMediaByPostID(int TaxID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT pm.*,m.Title,m.Alt,m.Path,m.FileName FROM TaxonomyMedia pm 
        INNER JOIN Media m ON m.MID=pm.MID WHERE  TaxID=@TaxID", cn);
            cmd.Parameters.Add("@TaxID", SqlDbType.TinyInt).Value = TaxID;
          
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));

        }
    }

}