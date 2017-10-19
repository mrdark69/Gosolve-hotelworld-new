﻿using System;
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
            SqlCommand cmd = new SqlCommand("INSERT INTO MediaTaxonomy (Title,TaxType,KeyID,KeyRef,Priority,DatePublish)VALUES(@Title,@TaxType,@KeyID,@KeyRef,@Priority,@DatePublish)", cn);

            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = param.Title;
            cmd.Parameters.Add("@TaxType", SqlDbType.NVarChar).Value = param.TaxType;
            cmd.Parameters.Add("@KeyID", SqlDbType.Int).Value = param.KeyID;
            cmd.Parameters.Add("@KeyRef", SqlDbType.Int).Value = param.KeyRef;
            cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = param.Priority;
            cmd.Parameters.Add("@DatePublish", SqlDbType.SmallDateTime).Value = param.DatePublish;
            cn.Open();

            return ExecuteNonQuery(cmd);

           
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

    
}