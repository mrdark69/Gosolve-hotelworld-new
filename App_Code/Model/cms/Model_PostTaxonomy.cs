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


public class Model_TaxSEOMap : BaseModel<Model_TaxSEOMap>
{
    public int TaxID { get; set; }
    public int PSID { get; set; }


    public Model_TaxSEOMap GetSEOID(int PostID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM TaxonomySEOMap WHERE TaxID=@TaxID", cn);
            cmd.Parameters.Add("@TaxID", SqlDbType.Int).Value = PostID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }

    public int InsertMApSeo(Model_TaxSEOMap seomap)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO TaxonomySEOMap (TaxID,PSID) VALUES(@TaxID,@PSID)", cn);
            cmd.Parameters.Add("@TaxID", SqlDbType.Int).Value = seomap.TaxID;
            cmd.Parameters.Add("@PSID", SqlDbType.Int).Value = seomap.PSID;
            cn.Open();
            return ExecuteNonQuery(cmd);
        }
    }
}

/// <summary>
/// Summary description for Model_SiteInfo
/// </summary>
/// 
public enum PostTaxonomyType : byte
{
    Categories = 1,
    Tags = 2,

}


//TaxID tinyint No tinyint Unchecked Checked
//TaxTypeID tinyint No tinyint Unchecked Unchecked
//PostTypeID int No  int Unchecked   Unchecked
//Slug    nvarchar(200)   No nvarchar(200)   Unchecked Unchecked
//Title nvarchar(200)   No nvarchar(200)   Unchecked Unchecked
//RefID int Yes int Checked Unchecked
//Status  bit No  bit Unchecked   Unchecked((1))
public class Model_PostTaxonomy : BaseModel<Model_PostTaxonomy>
{
    public int TaxID { get; set; }
    public byte TaxTypeID { get; set; }
    public byte PostTypeID { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public int RefID { get; set; }
    public bool Status { get; set; }



    public DateTime DateSubmit { get; set; }
    public int UserID { get; set; }
    public DateTime DatePublish { get; set; }
    public byte BannerTypeID { get; set; }
    public bool ShowMasterSlider { get; set; }
    public int ViewCount { get; set; }

    public string DatePublishFormat
    {
        get
        {
            return this.DatePublish.ToThaiDateTime().ToString("dd MMM yyy HH:mm tt");
        }
    }

    public string UserFirstName { get; set; }


    private Model_TaxSEOMap _taxSEOMap = null;
    public Model_TaxSEOMap TaxSEOMap
    {
        get
        {
            if (_taxSEOMap == null)
            {
                Model_TaxSEOMap seo = new Model_TaxSEOMap();
                _taxSEOMap = seo.GetSEOID(this.TaxID);
            }
            return _taxSEOMap;
        }
    }

    private Model_PostSeo _taxSEO = null;
    public Model_PostSeo TaxSEO
    {
        get
        {
            if (_taxSEO == null && this.TaxSEOMap != null )
            {
                Model_PostSeo ps = new Model_PostSeo();
                _taxSEO = ps.GetPostSeoByID(this.TaxSEOMap.PSID);
            }

            return _taxSEO;
        }
    }

    private List<Model_TaxMedia> _taxmedia = null;
    public List<Model_TaxMedia> TaxMedia
    {
        get
        {
            if (_taxmedia == null)
            {
                Model_TaxMedia ps = new Model_TaxMedia();
                _taxmedia = ps.getPostMediaByPostID(this.TaxID);
            }

            return _taxmedia;
        }
    }


    public Model_PostTaxonomy()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool UpdateTaxonomy(Model_PostTaxonomy tax)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE PostTaxonomy SET  Slug=@Slug,Title=@Title,RefID=@RefID,Status=@Status,
                        BannerTypeID=@BannerTypeID,ShowMasterSlider=@ShowMasterSlider,ViewCount=@ViewCount
                WHERE TaxID=@TaxID", cn);


            cmd.Parameters.Add("@Slug", SqlDbType.NVarChar).Value = tax.Slug;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = tax.Title;
            cmd.Parameters.Add("@RefID", SqlDbType.Int).Value = tax.RefID;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = tax.Status;



            //cmd.Parameters.Add("DateSubmit", SqlDbType.SmallDateTime).Value = tax.DateSubmit;
            //cmd.Parameters.Add("UserID", SqlDbType.Int).Value = tax.UserID;
            //cmd.Parameters.Add("DatePublish", SqlDbType.SmallDateTime).Value = tax.DatePublish;
            cmd.Parameters.Add("BannerTypeID", SqlDbType.TinyInt).Value = tax.BannerTypeID;
            cmd.Parameters.Add("ShowMasterSlider", SqlDbType.Int).Value = tax.ShowMasterSlider;
            cmd.Parameters.Add("ViewCount", SqlDbType.Int).Value = tax.ViewCount;


            cmd.Parameters.Add("@TaxID", SqlDbType.Int).Value = tax.TaxID;


            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }

    public int InsertTaxonomy(Model_PostTaxonomy tax)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO PostTaxonomy (TaxTypeID,PostTypeID,Slug,Title,RefID,Status,DateSubmit,UserID,DatePublish,BannerTypeID,ShowMasterSlider,ViewCount) 
VALUES(@TaxTypeID,@PostTypeID,@Slug,@Title,@RefID,@Status,@DateSubmit,@UserID,@DatePublish,@BannerTypeID,@ShowMasterSlider,@ViewCount) SET @TaxID = SCOPE_IDENTITY()", cn);

            cmd.Parameters.Add("@TaxTypeID", SqlDbType.TinyInt).Value = tax.TaxTypeID;
            cmd.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = tax.PostTypeID;
            cmd.Parameters.Add("@Slug", SqlDbType.NVarChar).Value = tax.Slug;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = tax.Title;
            cmd.Parameters.Add("@RefID", SqlDbType.Int).Value = tax.RefID;
            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = tax.Status;



            cmd.Parameters.Add("DateSubmit", SqlDbType.SmallDateTime).Value = tax.DateSubmit;
            cmd.Parameters.Add("UserID", SqlDbType.Int).Value = tax.UserID;
            cmd.Parameters.Add("DatePublish", SqlDbType.SmallDateTime).Value = tax.DatePublish;
            cmd.Parameters.Add("BannerTypeID", SqlDbType.TinyInt).Value = tax.BannerTypeID;
            cmd.Parameters.Add("ShowMasterSlider", SqlDbType.Int).Value = tax.ShowMasterSlider;
            cmd.Parameters.Add("ViewCount", SqlDbType.Int).Value = tax.ViewCount;


            cmd.Parameters.Add("@TaxID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cn.Open();
            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@TaxID"].Value;

            }
        }
        return ret;

    }

    public Model_PostTaxonomy GetTaxonomyByID(int TaxID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PostTaxonomy WHERE TaxID=@TaxID", cn);
            cmd.Parameters.Add("@TaxID", SqlDbType.TinyInt).Value = TaxID;


            cn.Open();

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
            
        }
    }

    public List<Model_PostTaxonomy> GetTaxonomyByIDMain(Model_PostTaxonomy t)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PostTaxonomy WHERE RefID=0 AND PostTypeID=@PostTypeID AND TaxTypeID=@TaxTypeID", cn);
            cmd.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = t.PostTypeID;
            cmd.Parameters.Add("@TaxTypeID", SqlDbType.TinyInt).Value = t.TaxTypeID;
            cn.Open();

            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
   



}