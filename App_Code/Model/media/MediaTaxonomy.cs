using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MVCDatatableApp;

/// <summary>
/// Summary description for MediaTaxonomy
/// </summary>
public class MediaTaxonomy : BaseModel<MediaTaxonomy>
{
    public int TaxID { get; set; }
    public string Title { get; set; }
    public string TaxType { get; set; } = "child";
    public int KeyID { get; set; } = 0;
    public int KeyRef { get; set; } = 1;
    public bool Status { get; set; }
    public int Priority { get; set; }
    public DateTime DatePublish { get; set; }
    public string DatePublishFormat
    {
        get
        {
            return this.DatePublish.ToThaiDateTime().ToString("dd MMM yyy HH:mm tt");
        }
    }

    public MediaTaxonomy()
    {
        
        //
       
        //
        // TODO: Add constructor logic here
        //
    }

    public int model_InsertChildTaxonomy(MediaTaxonomy param)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO MediaTaxonomy (Title,TaxType,KeyID,KeyRef,Priority,DatePublish)VALUES(@Title,@TaxType,@KeyID,@KeyRef,@Priority,@DatePublish);SET @TaxID = SCOPE_IDENTITY();", cn);

            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = param.Title;
            cmd.Parameters.Add("@TaxType", SqlDbType.NVarChar).Value = param.TaxType;
            cmd.Parameters.Add("@KeyID", SqlDbType.Int).Value = param.KeyID;
            cmd.Parameters.Add("@KeyRef", SqlDbType.Int).Value = param.KeyRef;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = param.Priority;
            cmd.Parameters.Add("@DatePublish", SqlDbType.SmallDateTime).Value = param.DatePublish;

            cmd.Parameters.Add("@TaxID", SqlDbType.Int).Direction = ParameterDirection.Output;

            cn.Open();

            if (ExecuteNonQuery(cmd) > 0)
                return (int)cmd.Parameters["@TaxID"].Value;
            else
                return 0;

           
        }
    }

    public bool model_updateMediaTaxonomy(MediaTaxonomy param)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE MediaTaxonomy SET Title=@Title WHERE TaxID=@TaxID ", cn);

            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = param.Title;
        
            cmd.Parameters.Add("@TaxID", SqlDbType.Int).Value = param.TaxID;
          
            cn.Open();

            return ExecuteNonQuery(cmd) == 1;


        }
    }
    public bool model_updateMediaTaxonomyTrash(int intTaxID, bool bolStatus)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE MediaTaxonomy SET Status=@Status WHERE TaxID=@TaxID ", cn);

            cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = bolStatus;

            cmd.Parameters.Add("@TaxID", SqlDbType.Int).Value = intTaxID;

            cn.Open();

            return ExecuteNonQuery(cmd) == 1;


        }
    }

    public IList<MediaTaxonomy> model_GetTaxonomyList(MediaTaxonomy param)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM MediaTaxonomy WHERE KeyRef=@KeyRef", cn);

           
            cmd.Parameters.Add("@KeyRef", SqlDbType.Int).Value = param.KeyRef;

            cn.Open();

            return MappingObjectCollectionFromDataReader(ExecuteReader(cmd));


        }
    }


    public bool UpdateTaxonomyPri(int taxid, int Pri)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE MediaTaxonomy SET  Priority=@Priority 
                WHERE TaxID=@TaxID", cn);


            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = Pri;

            cmd.Parameters.Add("@TaxID", SqlDbType.Int).Value = taxid;


            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }
    public MediaTaxonomy model_GetTaxonomyById(int intTaxID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM MediaTaxonomy WHERE TaxID=@TaxID", cn);


            cmd.Parameters.Add("@TaxID", SqlDbType.Int).Value = intTaxID;

            cn.Open();

            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;

            


        }
    }


}