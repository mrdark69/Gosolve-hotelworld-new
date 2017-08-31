using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _MasterSlide : BasePage
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

            Model_MasterSlider ms = new Model_MasterSlider();
            Model_MasterSliderItem mi = new Model_MasterSliderItem();

            List<Model_MasterSlider> mslist = ms.GetMasterList();
            string media = string.Empty;
            foreach (Model_MasterSlider m in mslist)
            {
                int uuid = m.MSID;
               media += "<input type=\"checkbox\" name=\"chk_master_slider\" checked=\"checked\" value=\"" + uuid + "\" style=\"display:none;\" />";
                media += "<div class=\"media_item_box\"  style=\"border-top:2px solid #eee;margin-top:20px;padding-top:20px;\" id=\"media_item_box_" + uuid + "\"   style=\"margin-top:5px;\"><label> No Media selected</label>";

                media += " <button id=\"addimg_" + uuid + "\" type=\"button\" class=\"addmedia btn btn-success btn-xs\" onclick=\"BindMediaBoxList(this);\"> Add main picture</button>";
                media += "<input type=\"hidden\" id=\"b3_url_" + uuid + "\"  name=\"b3_url_" + uuid + "\" value=\""+ m.MediaFullPath + "\" />";
                media += "<input type=\"hidden\" id=\"b3_id_" + uuid + "\" name=\"b3_id_" + uuid + "\" value=\""+m.MID+"\" />";

                media += "<h1><input type=\"textbox\" placeholder=\"TEXT HERE\" name=\"b3_text_big_" + uuid + "\" style=\"width:100%;\" value=\""+m.Text1+"\" /><h2>";
                media += "<h2><input type=\"textbox\" placeholder=\"TEXT HERE\" name=\"b3_text_normal_" + uuid + "\" style=\"width:100%;\" value=\""+m.Text2+"\" /></h2>";

                media += "</div >";

                List<Model_MasterSliderItem> milist = mi.GetMasterItemList(m.MSID);
                int itemcount = milist.Count;
                //item list
                media += "<div class=\"master_item_block\">";
                //  ---------
                //List 1 
                media += "<div class=\"media_item_master media_item_box\" id=\"media_item_box_item_1_" + uuid + "\"   style=\"margin-top:5px;\"><label> No Media selected</label>";
                media += " <button id=\"addimg_item_1_" + uuid + "\" type=\"button\" class=\"addmedia btn btn-success btn-xs\" onclick=\"BindMediaBoxList(this);\"> Add Banner</button>";
                media += "<input type=\"hidden\" id=\"b3_url_item_1" + uuid + "\"  name=\"b3_url_item_1" + uuid + "\" value=\"" + (itemcount >0? milist[0].MediaFullPath : "" ) + "\"  />";
                media += "<input type=\"hidden\" id=\"b3_id_item_1" + uuid + "\" name=\"b3_id_item_1" + uuid + "\" value=\"" + (itemcount > 0 ? milist[0].MID.ToString() : "") + "\" />";
                media += "<input type=\"textbox\" id=\"b3_link_item_1" + uuid + "\" name=\"b3_link_item_1" + uuid + "\" value=\"" + (itemcount > 0 ? milist[0].Link : "") + "\"  class=\"form-control\" placeholder=\"Link\" />";
                media += "</div>";
                //List 1 
                //  ---------
                //List 2
                media += "<div class=\"media_item_master media_item_box\" id=\"media_item_box_item_2_" + uuid + "\"   style=\"margin-top:5px;\"><label> No Media selected</label>";
                media += " <button id=\"addimg_item_2_" + uuid + "\" type=\"button\" class=\"addmedia btn btn-success btn-xs\" onclick=\"BindMediaBoxList(this);\"> Add Banner</button>";
                media += "<input type=\"hidden\" id=\"b3_url_item_2" + uuid + "\"  name=\"b3_url_item_2" + uuid + "\" value=\"" + (itemcount > 1 ? milist[1].MediaFullPath : "") + "\"  />";
                media += "<input type=\"hidden\" id=\"b3_id_item_2" + uuid + "\" name=\"b3_id_item_2" + uuid + "\" value=\"" + (itemcount > 1 ? milist[1].MID.ToString() : "") + "\" />";
                media += "<input type=\"textbox\" id=\"b3_link_item_2" + uuid + "\" name=\"b3_link_item_2" + uuid + "\" value=\"" + (itemcount > 1? milist[1].Link : "") + "\" class=\"form-control\" placeholder=\"Link\" />";
                media += "</div>";
                //List 2
                //  ---------
                //List 3
                media += "<div class=\"media_item_master media_item_box\" id=\"media_item_box_item_3_" + uuid + "\"   style=\"margin-top:5px;\"><label> No Media selected</label>";
                media += " <button id=\"addimg_item_3_" + uuid + "\" type=\"button\" class=\"addmedia btn btn-success btn-xs\" onclick=\"BindMediaBoxList(this);\"> Add Banner</button>";
                media += "<input type=\"hidden\" id=\"b3_url_item_3" + uuid + "\"  name=\"b3_url_item_3" + uuid + "\" value=\"" + (itemcount > 2 ? milist[2].MediaFullPath : "") + "\"  />";
                media += "<input type=\"hidden\" id=\"b3_id_item_3" + uuid + "\" name=\"b3_id_item_3" + uuid + "\" value=\"" + (itemcount > 2? milist[2].MID.ToString() : "") + "\" />";

                media += "<input type=\"textbox\" id=\"b3_link_item_3" + uuid + "\" name=\"b3_link_item_3" + uuid + "\" value=\"" + (itemcount > 2 ? milist[2].Link : "") + "\" class=\"form-control\" placeholder=\"Link\" />";
                media += "</div>";
                //List 3
                //  ---------
                media += "<div style=\"clear:both\"></div>";

                media += "</div>";

                //item list

                media += "<div style=\"clear:both;height:70px;border-bottom:2px solid #eee;padding-top:20px;margin-top:20px\"></div>";
            }


            master_body.InnerHtml = media;
        }
    }






    protected void btnPubish_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Form["chk_master_slider"]))
        {
            Model_MasterSlider ms = new Model_MasterSlider();
            Model_MasterSliderItem mi = new Model_MasterSliderItem();

            string chk = Request.Form["chk_master_slider"];

            string[] arrchk = chk.Split(',');
            mi.ClearSlider();
            ms.ClearSlider();
            int count = 1;
            foreach (string m in arrchk)
            {
                string txt1 = Request.Form["b3_text_big_"+ m];
                string txt2 = Request.Form["b3_text_normal_"+ m];
                string mid = Request.Form["b3_id_"+ m];

                int msid = ms.Insert(new Model_MasterSlider
                {
                    Text1 = txt1,
                    Text2 = txt2,
                    MID = int.Parse(mid),
                    Priority = count
                });


                string mid_1 = Request.Form["b3_id_item_1" + m];
                string link_1 = Request.Form["b3_link_item_1" + m];

                string mid_2 = Request.Form["b3_id_item_2" + m];
                string link_2 = Request.Form["b3_link_item_2" + m];

                string mid_3 = Request.Form["b3_id_item_3" + m];
                string link_3 = Request.Form["b3_link_item_3" + m];

                if(!string.IsNullOrEmpty(mid_1) )
                {
                    mi.Insert(new Model_MasterSliderItem
                    {
                         MSID = msid,
                         MID = int.Parse(mid_1),
                         Link = link_1,
                         Priority = 1
                    });
                }

                if (!string.IsNullOrEmpty(mid_2) )
                {
                    mi.Insert(new Model_MasterSliderItem
                    {
                        MSID = msid,
                        MID = int.Parse(mid_2),
                        Link = link_2,
                        Priority = 2
                    });
                }


                if (!string.IsNullOrEmpty(mid_3) )
                {
                    mi.Insert(new Model_MasterSliderItem
                    {
                        MSID = msid,
                        MID = int.Parse(mid_3),
                        Link = link_3,
                        Priority = 3
                    });
                }



                count = count + 1;
            }

        }

        Response.Redirect(Request.Url.ToString());
    }

    protected void addslider_Click(object sender, EventArgs e)
    {
        Guid id = Guid.NewGuid();
        string uuid = id.ToString();
        string media = "<div class=\"media_item_box\" id=\"media_item_box_" + uuid + "\"   style=\"margin-top:5px;\"><label> No Media selected</label>";
        media += "<button id=\"addimg_" + uuid + "\" type=\"button\" class=\"addmedia btn btn-success btn-xs\" onclick=\"BindMediaBoxList(this);\"> Add Banner</button>";
        media += "<input type=\"hidden\" id=\"b3_url_" + uuid + "\"  name=\"b3_url_" + uuid + "\" />";
        media += "<input type=\"hidden\" id=\"b3_id_" + uuid + "\" name=\"b3_id_" + uuid + "\" />";

        media += "<h1><input type=\"dd\" /><h2>";
        media += "<h2><input type=\"dd\" /></h2>";
        media += "</div >";


      


       // lblret.Text = lblret.Text + media;
    }
}