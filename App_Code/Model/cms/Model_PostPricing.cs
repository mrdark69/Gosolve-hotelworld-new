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

public class Model_PostPricingOptionQty : BaseModel<Model_PostPricingOptionQty>
{



    public int QtyID { get; set; }
    public int PriceOptionID { get; set; }
    public int PriceID { get; set; }
    public int UnitFrom { get; set; }
    public int UnitTo { get; set; } = 0;

 
    public decimal PriceOption { get; set; }
    public bool Status { get; set; }

    public string QtyOPtionDrop
    {
        get { return this.UnitFrom + "#" + this.UnitTo + "#" + this.PriceOptionID + "#" + this.PriceOption.ToString("#,##0.00"); }

    }

    public string QtyOPtionDropFront
    {
        get { return this.UnitFrom + "|" + this.UnitTo + "|" + this.PriceOptionID + "|" + this.PriceOption.ToString("#,##0.00"); }

    }
    //public string QtyOPtionDropTitle
    //{
    //    get { return this.Title + " Qty " + this.UnitFrom + (this.UnitTo == 0 ? "+" : "-" + this.UnitTo) + " [" + this.PriceOption.ToString("#,##0.00") + "Bath]"; }

    //}
    //public string QtyOPtionDropFront
    //{
    //    get { return this.UnitFrom + "|" + this.UnitTo + "|" + this.PriceOption.ToString("#,##0.00") + "|" + this.OPtionDropTitle; }

    //}

    public Model_PostPricingOptionQty()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int InsertPriceOPtionQty(Model_PostPricingOptionQty option)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO PricingItemOptionQty (PriceOptionID,PriceID,UnitFrom,UnitTo,PriceOption) 
                VALUES(@PriceOptionID,@PriceID,@UnitFrom,@UnitTo,@PriceOption) SET @QtyID = SCOPE_IDENTITY()", cn);
            cmd.Parameters.Add("@PriceOptionID", SqlDbType.Int).Value = option.PriceOptionID;
            cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = option.PriceID;
            cmd.Parameters.Add("@UnitFrom", SqlDbType.Int).Value = option.UnitFrom;
            cmd.Parameters.Add("@UnitTo", SqlDbType.Int).Value = option.UnitTo;
            cmd.Parameters.Add("@PriceOption", SqlDbType.SmallMoney).Value = option.PriceOption;
            cmd.Parameters.Add("@QtyID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cn.Open();
            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@QtyID"].Value;

            }
        }
        return ret;

    }

    public bool DeleteOPtionPriceQty(int intPriceID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM PricingItemOptionQty WHERE PriceID = @PriceID ", cn);
            cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = intPriceID;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }
    public List<Model_PostPricingOptionQty> GetPostPriceOPtionQtyByPriceOPtionID(int intPriceOptionID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PricingItemOptionQty WHERE PriceOptionID = @PriceOptionID AND Status = 1 ", cn);
            cmd.Parameters.Add("@PriceOptionID", SqlDbType.Int).Value = intPriceOptionID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

    public List<Model_PostPricingOptionQty> GetPostPriceOPtionQtyByPriceID(int intPriceID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PricingItemOptionQty WHERE PriceID = @PriceID AND Status = 1 ", cn);
            cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = intPriceID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

}

public class Model_PostPricingOption : BaseModel<Model_PostPricingOption>
{
   



    public int PriceOptionID { get; set; }
    public int PriceID { get; set; }

 
    public string Title { get; set; }
   
    public bool Status { get; set; }

    //public string OPtionDrop
    //{
    //    get { return this.UnitFrom + "#" + this.UnitTo + "#" + this.Title + "#" + this.PriceOption.ToString("#,##0.00"); }

    //}
    //public string OPtionDropTitle
    //{
    //    get { return this.Title + " Qty " + this.UnitFrom + (this.UnitTo==0?"+": "-" + this.UnitTo )+ " [" + this.PriceOption.ToString("#,##0.00") + "Bath]"; }

    //}
    //public string OPtionDropFront
    //{
    //    get { return this.UnitFrom + "|" + this.UnitTo + "|" + this.PriceOption.ToString("#,##0.00") + "|" + this.OPtionDropTitle; }

    //}

    public Model_PostPricingOption()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int InsertPriceOPtion(Model_PostPricingOption option)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO PostPricingOption (PriceID,Title) 
                VALUES(@PriceID,@Title) SET @PriceOptionID = SCOPE_IDENTITY()", cn);
            cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = option.PriceID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = option.Title;
            cmd.Parameters.Add("@PriceOptionID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cn.Open();
            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@PriceOptionID"].Value;

            }
        }
        return ret;

    }

    public bool DeleteOPtionPrice (int intPriceID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM PostPricingOption WHERE PriceID = @PriceID ", cn);
            cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = intPriceID;
            cn.Open();
            return ExecuteNonQuery(cmd) == 1;
        }
    }
    public List<Model_PostPricingOption> GetPostPriceOPtionByPriceID(int intPriceID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PostPricingOption WHERE PriceID = @PriceID AND Status = 1 ", cn);
            cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = intPriceID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }

}
public class Model_PostPricing : BaseModel<Model_PostPricing>
{
    
    public int PriceID { get; set; }
    public int PostID { get; set; }
    public byte PostTypeID { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public bool Isvat { get; set; }
    
    public bool  Status { get; set; }

    private List<Model_PostPricingOption> _priceoption = null;
    public List<Model_PostPricingOption> PriceOPtion {
        get
        {
            if(this._priceoption == null)
            {
                Model_PostPricingOption po = new Model_PostPricingOption();
                this._priceoption = po.GetPostPriceOPtionByPriceID(this.PriceID);
            }
            return this._priceoption;
        }
    }

    private List<Model_PostPricingOptionQty> _priceoptionQty = null;
    public List<Model_PostPricingOptionQty> PriceOPtionQty
    {
        get
        {
            if (this._priceoptionQty == null)
            {
                Model_PostPricingOptionQty po = new Model_PostPricingOptionQty();
                this._priceoptionQty = po.GetPostPriceOPtionQtyByPriceID(this.PriceID);
            }
            return this._priceoptionQty;
        }
    }

    public Model_PostPricing()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int InsertPrice(Model_PostPricing option)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO PostPricing (PostID,PostTypeID,Title,Price,Isvat) 
                VALUES(@PostID,@PostTypeID,@Title,@Price,@Isvat) SET @PriceID = SCOPE_IDENTITY()", cn);
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = option.PostID;
            cmd.Parameters.Add("@PostTypeID", SqlDbType.TinyInt).Value = option.PostTypeID;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = option.Title;
            cmd.Parameters.Add("@Price", SqlDbType.SmallMoney).Value = option.Price;

            cmd.Parameters.Add("@Isvat", SqlDbType.Bit).Value = option.Isvat;


            cmd.Parameters.Add("@PriceID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cn.Open();
            if (ExecuteNonQuery(cmd) > 0)
            {
                ret = (int)cmd.Parameters["@PriceID"].Value;

            }
        }
        return ret;

    }
    public int UpdataPostPrice(Model_PostPricing option)
    {
        int ret = 0;
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE PostPricing  SET Title=@Title,Price=@Price,Isvat=@Isvat WHERE PriceID=@PriceID", cn);
            cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = option.PriceID;
           
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = option.Title;
            cmd.Parameters.Add("@Price", SqlDbType.SmallMoney).Value = option.Price;

            cmd.Parameters.Add("@Isvat", SqlDbType.Bit).Value = option.Isvat;

            cn.Open();
            ret = ExecuteNonQuery(cmd);
        }
        return ret;

    }


    public Model_PostPricing GetPostPriceAllByID(int intPriceID)
    {
        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PostPricing WHERE PriceID = @PriceID AND Status = 1 ", cn);
            cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = intPriceID;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
                return MappingObjectFromDataReaderByName(reader);
            else
                return null;
        }
    }
    public List<Model_PostPricing> GetPostPriceAllByPostID(int intPostID)
    {
        using(SqlConnection cn = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PostPricing WHERE PostID = @PostID AND Status = 1 ", cn);
            cmd.Parameters.Add("@PostID", SqlDbType.Int).Value = intPostID;
            cn.Open();
            return MappingObjectCollectionFromDataReaderByName(ExecuteReader(cmd));
        }
    }
   
  


}