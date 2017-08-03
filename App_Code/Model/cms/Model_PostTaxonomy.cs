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
    public byte TaxID { get; set; }
    public byte TaxTypeID { get; set; }
    public int PostTypeID { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public int RefID { get; set; }
    public bool Status { get; set; }

   
    

    public Model_PostTaxonomy()
    {
        //
        // TODO: Add constructor logic here
        //
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