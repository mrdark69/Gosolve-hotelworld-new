<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" validateRequest="false" AutoEventWireup="true" CodeFile="MasterSlide.aspx.cs" Inherits="_MasterSlide" %>
<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
   <style type="text/css">
      .modal-dialog {
      width: 97%;
      height: 97%;
      margin: 0 auto;
      padding: 0;
      }
      .modal-content {
      height: auto;
      min-height: 100%;
      border-radius: 0;
      }
      .box_media_fucus_block{
      position:relative;
      display:block;
      width:120px;
      height:120px;
      background-position:center;
      background-repeat:no-repeat;
      background-size:cover;
      }
      .btn-media-focus{
      position:absolute;
      right:-10px;
      top:-10px;
      }
      .media_item_box label{
      font-weight:normal;
      }
        .gs-panel-body{
           background-color:#f3f3f4 !important;
           outline: 14px solid #fff; 
            outline-offset: -15px; 
       }
      
        .box_media_fucus_block{
            width:100%;
            height:400px;
        }
        .media_item_box{
            position:relative;
        }
         .media_item_box h1{
             position:absolute;
             top:100px;
             left:50px;
         }
         .media_item_box h2{
             position:absolute;
             top:170px;
             left:50px;
         }
         .media_item_box h1 input {
             background-color:transparent;
             border:0;
             color:#000 !important;
             font-size:54px !important;
             font-weight:400;
         }
          .media_item_box h2 input {
              
             background-color:transparent;
             border:0;
             color:#000 !important;
                font-size:24px !important;
                 font-weight:400;
         }
          .media_item_master{
             float:left;
             width:30%;
             height:100px;
                 margin-right: 20px;
          }

          .media_item_master .box_media_fucus_block{
                width:100%;
             height:100px;
          }
          .master_item_block {
              width:100%;
          }
   </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated ">
         
      <div class="row">

         <div class="col-md-9" style="margin-left:0px; margin-right:0px;padding-left:0px;padding-right:0px;">
            <div class="tabs-container">
                 <div class="ibox float-e-margins">
                           <div class="ibox-content">

                                    <div class="form">
                                        <input type="button" id="addrow" class="btn btn-success" value="Add Slider" />
                                           <%-- <asp:Button ID="addrow" ClientIDMode="Static" runat="server" CssClass="btn btn-success" Text="Add Slider" />--%>
                                            <div id="master_body" class="master_body" runat="server" >


                                            </div>
                                       <div style="clear:both"></div>
                                   
                                    </div>
                           </div>
                     </div>
               
               
            </div>
         </div>
         <div class="col-md-3">
            <div class="ibox float-e-margins">
               <div class="ibox-title">
                  <h5>Publish</h5>
                  <div class="ibox-tools">
                  </div>
               </div>
               <div class="ibox-content">
                  <div class="form-horizontal">
                     
                     <div class="form-group" style="margin-bottom:0px;" id="form_viewcount" runat="server" >
                        <label class="col-lg-6 control-label">View Count: </label>
                       
                     </div>
                  </div>
                  <div class="form-group" style="text-align:right">
                     <div >
                   
                        <asp:Button ID="btnPubish" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="btnPubish_Click" />
                     </div>
                  </div>
               </div>
            </div>



         </div>
      </div>
   </div>
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
  
   <%--<script src="//cdn.ckeditor.com/4.7.1/standard/ckeditor.js"></script>--%>
   <script src="/Scripts/theme/plugins/ckeditor/ckeditor.js"></script>
  
   <%--<script src="/admin/Application/bower_components/tinymce/tinymce.min.js"></script>--%>
   <script type="text/javascript">
       $(document).ready(function () {

           $("#addrow").on('click', function () {
               var uuid = guid();

               //var dropsocial = $('#dropSocial').html();


               //var media = '<div class="media_item_box" id="media_item_box_' + uuid + '"   style="margin-top:5px;"><label> No Media selected</label>';
               //media += '<button id="addimg_' + uuid + '" type="button" class="btn btn-success btn-xs" onclick="BindMediaBoxList(this);"> Add Banner</button>';
               //media += '<input type="hidden" id="b3_url_' + uuid + '"  name="b3_url_' + uuid + '" />';
               //media += '<input type="hidden" id="b3_id_' + uuid + '" name="b3_id_' + uuid + '" />';
               //media += '</div >';

               //var chk = '<input type="checkbox" name="chk_banner_client" checked="checked" value="' + uuid + '" style="display:none;" />';

               //var txtbox = '<input class="form-control" type="textbox"  id="caption_s_' + uuid + '" name="caption_s_' + uuid + '" />'

               //var html = '<tr id="row_s_' + uuid + '">';
               //html += '<td>' + chk + txtbox + '</td>';
               //html += '<td>' + media + '</td>';
               //html += '<td><button data-idrow="' + uuid + '"  onclick="removeRow(this);" class="btn btn-warning btn-circle" type="button"><i class="fa fa-times"></i></button ></td>';
               //html += '</tr>';
               var media = '<input type="checkbox" name="chk_master_slider" checked="checked" value="' + uuid + '" style="display:none;" />';
               media +="<div class=\"media_item_box\"  style=\"border-top:2px solid #eee;margin-top:20px;padding-top:20px;\" id=\"media_item_box_" + uuid + "\"   style=\"margin-top:5px;\"><label> No Media selected</label>";
             
               media += " <button id=\"addimg_" + uuid + "\" type=\"button\" class=\"addmedia btn btn-success btn-xs\" onclick=\"BindMediaBoxList(this);\"> Add main picture</button>";
               media += "<input type=\"hidden\" id=\"b3_url_" + uuid + "\"  name=\"b3_url_" + uuid + "\" />";
               media += "<input type=\"hidden\" id=\"b3_id_" + uuid + "\" name=\"b3_id_" + uuid + "\" />";

               media += "<h1><input type=\"textbox\" placeholder=\"TEXT HERE\" name=\"b3_text_big_" + uuid + "\" style=\"width:100%;\" /><h2>";
               media += "<h2><input type=\"textbox\" placeholder=\"TEXT HERE\" name=\"b3_text_normal_" + uuid + "\" style=\"width:100%;\"  /></h2>";
              
               media += "</div >";

               media += "<div class=\"master_item_block\">";
               media += "<div class=\"media_item_master media_item_box\" id=\"media_item_box_item_1_" + uuid + "\"   style=\"margin-top:5px;\"><label> No Media selected</label>";
               media += " <button id=\"addimg_item_1_" + uuid + "\" type=\"button\" class=\"addmedia btn btn-success btn-xs\" onclick=\"BindMediaBoxList(this);\"> Add Banner</button>";
               media += "<input type=\"hidden\" id=\"b3_url_item_1" + uuid + "\"  name=\"b3_url_item_1" + uuid + "\" />";
               media += "<input type=\"hidden\" id=\"b3_id_item_1" + uuid + "\" name=\"b3_id_item_1" + uuid + "\" />";
               media += "<input type=\"textbox\" id=\"b3_link_item_1" + uuid + "\" name=\"b3_link_item_1" + uuid + "\" class=\"form-control\" placeholder=\"Link\" />";
               media += "</div>";
               media += "<div class=\"media_item_master media_item_box\" id=\"media_item_box_item_2_" + uuid + "\"   style=\"margin-top:5px;\"><label> No Media selected</label>";
               media += " <button id=\"addimg_item_2_" + uuid + "\" type=\"button\" class=\"addmedia btn btn-success btn-xs\" onclick=\"BindMediaBoxList(this);\"> Add Banner</button>";
               media += "<input type=\"hidden\" id=\"b3_url_item_2" + uuid + "\"  name=\"b3_url_item_2" + uuid + "\" />";
               media += "<input type=\"hidden\" id=\"b3_id_item_2" + uuid + "\" name=\"b3_id_item_2" + uuid + "\" />";
               media += "<input type=\"textbox\" id=\"b3_link_item_2" + uuid + "\" name=\"b3_link_item_2" + uuid + "\" class=\"form-control\" placeholder=\"Link\" />";
               media += "</div>";
               media += "<div class=\"media_item_master media_item_box\" id=\"media_item_box_item_3_" + uuid + "\"   style=\"margin-top:5px;\"><label> No Media selected</label>";
               media += " <button id=\"addimg_item_3_" + uuid + "\" type=\"button\" class=\"addmedia btn btn-success btn-xs\" onclick=\"BindMediaBoxList(this);\"> Add Banner</button>";
               media += "<input type=\"hidden\" id=\"b3_url_item_3" + uuid + "\"  name=\"b3_url_item_3" + uuid + "\" />";
               media += "<input type=\"hidden\" id=\"b3_id_item_3" + uuid + "\" name=\"b3_id_item_3" + uuid + "\" />";

               media += "<input type=\"textbox\" id=\"b3_link_item_3" + uuid + "\" name=\"b3_link_item_3" + uuid + "\" class=\"form-control\" placeholder=\"Link\" />";
               media += "</div>";
               media += "<div style=\"clear:both\"></div>";
               media += "</div>";
               media += "<div style=\"clear:both;height:70px;border-bottom:2px solid #eee;padding-top:20px;margin-top:20px\"></div>";
               $('.master_body').append(media);
               return false;
           });

       });
       function removeRow(e) {
           var id = $(e).data('idrow');

           $("#row_s_" + id).remove(); return false;
       }
       function addimg() {

       }

   </script>

      <script src="/admin/Application/app.media.js?ver=22ssssssuuiiss"></script>
</asp:Content>