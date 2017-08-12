<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" validateRequest="false" AutoEventWireup="true" CodeFile="Post.aspx.cs" Inherits="_Post" %>
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
      .box_media_fucus_block_full_width .box_media_fucus_block{
           width:100% !important;
          background-size: contain !important;
      }
      .btn-media-focus{
      position:absolute;
      right:-10px;
      top:-10px;
      }
      .media_item_box label{
      font-weight:normal;
      }


      .positionIgnored{
          position:static !important;
      }

      .positionAbsolute{
          position:absolute !important;
          width:100% !important;
          height:100%!important;
          top:0;
          left:0;
          z-index:1002;
      }
      .tax_parent{
          position:relative;
          display:block;
      }
      .tax_parent .tax_child{

          padding:5px;
          margin-left:15px;
          border:1px solid #e1e1e1;
          
      }
       .tax_parent .parent_main_item{
           margin-top:10px;
      }

       #lightBoxGallery_post_gal .media_item_box_gall{
           display:inline-block;
               padding: 5px;
       }
       .lightBoxGallery{
           height:auto !important;
       }

      
   </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--fadeInRight--%>
   <div class="wrapper wrapper-content animated ">
      <div class="row">
         <div class="col-md-9" id="ele_custom_gs" style="margin-left:0px; margin-right:0px;padding-left:0px;padding-right:0px;">
            <div class="tabs-container">
               <ul class="nav nav-tabs">
                  <li class="active"><a data-toggle="tab" href="#tab-1" aria-expanded="true"> Information</a></li>
                  <li class=""><a data-toggle="tab" href="#tab-2" aria-expanded="false">SEO</a></li>
                  <li class=""><a data-toggle="tab" href="#tab-3" aria-expanded="false">Facebook</a></li>
                  <li class=""><a data-toggle="tab" href="#tab-4" aria-expanded="false">Twitter</a></li>
               </ul>
               <div class="tab-content">
                  <div id="tab-1" class="tab-pane active">
                     <div class="panel-body" id="tab_custom_gs">
                        <div class="ibox float-e-margins">
                           <div class="ibox-content">
                              <div  class="form">
                                 <div class="form-group">
                                    <label class=" control-label">permarlink</label>
                                    <div >
                                       <asp:Label ID="url" style="display: inline-block;" runat="server"></asp:Label>
                                       <asp:TextBox ID="slug" style="display: inline-block;
                                          width: 30%;" CssClass="form-control" runat="server"></asp:TextBox>
                                       <asp:RequiredFieldValidator runat="server" ControlToValidate="slug"
                                          CssClass="text-danger" ErrorMessage="The slug field is required." />
                                    </div>
                                 </div>
                                 <div class="form-group">
                                    <label class=" control-label">Title</label>
                                    <div >
                                       <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                       <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTitle"
                                          CssClass="text-danger" ErrorMessage="The Title field is required." />
                                    </div>
                                 </div>

                                 <%-- Home Group Custom Panel--%>
                                  <asp:Panel ID="pn_home_custom" runat="server" Visible="false">

                                 
                                 <div class="hr-line-dashed"></div>
                                   <div class="form-group">
                                       <div class="col-md-6">
                                            <label class=" control-label">Banner Announcement</label>
                                           <asp:TextBox ID="banner_home_1"  ClientIDMode="Static" placeholder="Caption" CssClass="form-control"  runat="server"></asp:TextBox>
                                                <div class="media_item_box box_media_fucus_block_full_width" id="media_item_box_6" style="margin-top:5px;">
                                                <label>No Media selected</label>
                                                <button id="addimg6" type="button" class="addmedia btn btn-success btn-xs">Add Media</button>
                                                <asp:HiddenField ID="b1_url"   runat="server" ClientIDMode="Static" />
                                              <asp:HiddenField ID="b1_id"   runat="server" ClientIDMode="Static" />
                                                
                                            </div>
                                       </div>
                                         <div class="col-md-6">
                                            <label class=" control-label">Banner Rigth</label>
                                             <asp:TextBox ID="banner_home_2"  ClientIDMode="Static" placeholder="Caption" CssClass="form-control"   runat="server"></asp:TextBox>
                                            <div class="media_item_box" id="media_item_box_7"  style="margin-top:5px;">
                                                <label>No Media selected</label>
                                                <button id="addimg7" type="button" class="addmedia btn btn-success btn-xs">Add Media</button>
                                                <asp:HiddenField ID="b2_url"   runat="server" ClientIDMode="Static" />
                                              <asp:HiddenField ID="b2_id"   runat="server" ClientIDMode="Static" />
                                                
                                            </div>
                                       </div>
                                    </div>
                                  <div style="clear:both"></div>

                                   <div class="hr-line-dashed"></div>

                            
                                <asp:DropDownList  ID="drop_b_client_ret" ClientIDMode="Static" style="display:none;" runat="server"></asp:DropDownList>
                                        <div class="form-group" runat="server" id="Div3" >
                                            <label class=" control-label">Banner Client</label>
                                    <div> 
                                      <table class="table" id="add-row-social" >
                                          <thead>
                                              <tr>
                                                 <td>Caption</td>
                                                  <td>Media</td>
                                                 <td>Remove Row</td>
                                              </tr>
                                          </thead>
                                          <tbody>
                                               
                                          </tbody>
                                      </table>

                                        <button id="addrow" type="button" class="btn btn-success btn-xs">Add Row</button>
                                    </div>
                                   
                                </div>
                                   <div style="clear:both"></div>

                                       </asp:Panel>
                                       <%-- Home Group Custom Panel--%>


                               <%--   Product PostType panel--%>
                                  <asp:Panel ID="pn_product_default" runat="server" Visible="false">
                                      <div class="hr-line-dashed"></div>
                                      <div class="form-group" style="max-height:400px;overflow-y:scroll;">
                                           <label><i class="fa fa-bookmark" aria-hidden="true"></i>Product Gallery</label>
                                           <button id="btnaddmedia" type="button" data-multiSel="true" class="addmedia-gallery btn btn-success" data-target="txtContent">Add Media</button>
                                          <div class="lightBoxGallery" id="lightBoxGallery_post_gal">
                                              

                                              
                                              <asp:Literal ID="gal_server" runat="server"></asp:Literal>
                                              

                                            </div>

                                          <div style="clear:both"></div>
                                      </div>




                                      <div class="hr-line-dashed"></div>
                                      <div class="form-group">
                                          <div class="col-md-6">
                                              <label><i class="fa fa-bookmark" aria-hidden="true"></i>Product Category</label>
                                                <div style="max-height:400px;overflow-y:scroll;display:block;
background-color:#f3f3f4;border:1px solid #e1e1e1;padding:20px;">

                                                    <asp:Literal ID="CategoryTax" runat="server"></asp:Literal>
                                                    <%--<asp:CheckBoxList ID="CategoryTax" runat="server" RepeatLayout="Table" RepeatDirection="Vertical" />--%>
                                                </div>
                                          </div>
                                           <div class="col-md-6">
                                               <label><i class="fa fa-tags" aria-hidden="true"></i>Product Tags</label>
                                               <div style="max-height:400px;overflow-y:scroll;display:block;background-color:#f3f3f4;
                                border:1px solid #e1e1e1;padding:20px;">
                                                   <asp:Literal ID="TagsTax" runat="server"></asp:Literal>
                                                   
                                               </div>
                                     

                                           </div>
                                      </div>
                                        <div style="clear:both"></div>
                                      </asp:Panel>
                                    <%--   Product PostType panel--%>


                                 <%-- Product Group Custom Panel--%>
                                  <asp:Panel ID="pn_product_custom" runat="server" Visible="false">
                                      


                                       <div class="hr-line-dashed"></div>
                                       <div class="form-group">
                                            <label class=" control-label">Product Detail</label>
                                           <asp:TextBox ID="ProductDetail"  ClientIDMode="Static" CssClass="form-control" Rows="20" TextMode="MultiLine" runat="server"></asp:TextBox>
                                       </div>
                                       <div class="hr-line-dashed"></div>
                                       <div class="form-group">
                                            <label class=" control-label">Product Information</label>
                                           <asp:TextBox ID="ProductInformation"  ClientIDMode="Static" CssClass="form-control" Rows="20" TextMode="MultiLine" runat="server"></asp:TextBox>
                                       </div>

                                      <div class="form-group">
                                       <div class="col-md-6">
                                            <label class=" control-label">Banner Announcement</label>
                                           <asp:TextBox ID="p_banner_ann_caption"  ClientIDMode="Static" placeholder="Caption" CssClass="form-control"  runat="server"></asp:TextBox>
                                                <div class="media_item_box" id="media_item_box_8" style="margin-top:5px;">
                                                <label>No Media selected</label>
                                                <button id="addimg8" type="button" class="addmedia btn btn-success btn-xs">Add Media</button>
                                                <asp:HiddenField ID="p_banner_ann_8"   runat="server" ClientIDMode="Static" />
                                              <asp:HiddenField ID="p_banner_ann_mid_8"   runat="server" ClientIDMode="Static" />
                                                
                                            </div>
                                       </div>
                                         <div class="col-md-6">
                                            <label class=" control-label">Banner Rigth</label>
                                             <asp:TextBox ID="p_banner_rigth"  ClientIDMode="Static" placeholder="Caption" CssClass="form-control"   runat="server"></asp:TextBox>
                                            <div class="media_item_box" id="media_item_box_9"  style="margin-top:5px;">
                                                <label>No Media selected</label>
                                                <button id="addimg9" type="button" class="addmedia btn btn-success btn-xs">Add Media</button>
                                                <asp:HiddenField ID="p_banner_9"   runat="server" ClientIDMode="Static" />
                                              <asp:HiddenField ID="p_banner_mid_9"   runat="server" ClientIDMode="Static" />
                                                
                                            </div>
                                       </div>
                                    </div>
                                  <div style="clear:both"></div>

                                  

                                  </asp:Panel>
                                    <%-- Product Group Custom Panel--%>

                                 <div class="hr-line-dashed"></div>


                                 <div class="form-group" id="main_post_content" runat="server">
                                    <label class=" control-label">Content</label>
                                    <div>
                                       <%--<span class="help-block m-b-none">A block of help text that breaks onto a new line and may extend beyond one line.</span>--%>
                                      
                                        <%--<a href="#" id="btnfullcontent" class=" btn btn-success" >Full Screen</a>--%>
                                       <%-- <asp:Literal ID="txtContent" runat="server"></asp:Literal>--%>
                                        
                                       <asp:TextBox ID="txtContent" style="display:none;" ClientIDMode="Static" CssClass="form-control" Rows="20" TextMode="MultiLine" runat="server"></asp:TextBox>

                                        <asp:TextBox ID="txtContentBuilder" style="display:none;" ClientIDMode="Static" CssClass="form-control" Rows="20" TextMode="MultiLine" runat="server"></asp:TextBox>

                                        <iframe id="iframcontent" style="width:100%;height:600px;border:1px solid #e7eaec;" src="/admin/Post/Contentbuilder?ve=00ssssss"></iframe>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div id="tab-2" class="tab-pane ">
                     <div class="panel-body">
                        <div class="ibox float-e-margins">
                           <div class="ibox-content">
                              <div  class="form">
                                 <div class="hr-line-dashed"></div>
                                 <div class="form-group">
                                    <label class=" control-label">Seo Title</label>
                                    <div >
                                       <asp:TextBox ID="seotitle" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                 </div>
                                 <div class="hr-line-dashed"></div>
                                 <div class="form-group">
                                    <label class=" control-label">Meta description</label>
                                    <div >
                                       <asp:TextBox ID="metades" TextMode="MultiLine" Rows="5" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                 </div>
                                 <div class="hr-line-dashed"></div>
                                 <div class="form-group">
                                    <label class=" control-label">Canonical URL</label>
                                    <div >
                                       <asp:TextBox ID="Canonical" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                 </div>
                                 <div class="hr-line-dashed"></div>
                                 <div class="form-group">
                                    <label class=" control-label">Meta robots follow</label>
                                    <div >
                                       <asp:DropDownList ID="droprebot" runat="server">
                                          <asp:ListItem Text="Follow" Value="True"></asp:ListItem>
                                          <asp:ListItem Text="Nofollow" Value="False"></asp:ListItem>
                                       </asp:DropDownList>
                                       <%-- <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                    </div>
                                 </div>
                                 <div class="hr-line-dashed"></div>
                                 <div class="form-group">
                                    <label class=" control-label">Analytic</label>
                                    <div >
                                       <asp:TextBox ID="analytic" TextMode="MultiLine" Rows="6" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div id="tab-3" class="tab-pane ">
                     <div class="panel-body">
                        <div class="ibox float-e-margins">
                           <div class="ibox-content">
                              <div  class="form">
                                 <div class="hr-line-dashed"></div>
                                 <div class="form-group">
                                    <label class=" control-label">Facebook Title</label>
                                    <div >
                                       <asp:TextBox ID="facebookTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                 </div>
                                 <div class="hr-line-dashed"></div>
                                 <div class="form-group">
                                    <label class=" control-label">Facebook Description</label>
                                    <div >
                                       <asp:TextBox ID="facebookDes" CssClass="form-control" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                                    </div>
                                 </div>
                                 <div class="hr-line-dashed"></div>
                                 <div class="form-group">
                                    <label class=" control-label">Facebook Image</label>
                                    <div class="media_item_box" id="media_item_box_2">
                                       <label>No Media selected</label>
                                       <button id="addimg2" type="button" class="addmedia btn btn-success btn-xs">Add Media</button>
                                       <asp:HiddenField ID="facebookImg" runat="server" ClientIDMode="Static" />
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div id="tab-4" class="tab-pane">
                     <div class="panel-body">
                        <div class="ibox float-e-margins">
                           <div class="ibox-content">
                              <div  class="form">
                                 <div class="hr-line-dashed"></div>
                                 <div class="form-group">
                                    <label class=" control-label">Twitter Title</label>
                                    <div >
                                       <asp:TextBox ID="twTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                 </div>
                                 <div class="hr-line-dashed"></div>
                                 <div class="form-group">
                                    <label class=" control-label">Twitter Description</label>
                                    <div >
                                       <asp:TextBox ID="twDes" CssClass="form-control" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                                    </div>
                                 </div>
                                 <div class="hr-line-dashed"></div>
                                 <div class="form-group">
                                    <label class=" control-label">Twitter Image</label>
                                    <div class="media_item_box" id="media_item_box_3">
                                       <label>No Media selected</label>
                                       <button id="addimg3" type="button" class="addmedia btn btn-success btn-xs">Add Media</button>
                                       <asp:HiddenField ID="twimg" runat="server" ClientIDMode="Static" />
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
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
                     <div class="form-group" style="margin-bottom:0px;">
                        <label class="col-lg-6 control-label">Status: </label>
                        <div class="col-lg-6">
                           <p class="form-control-static">
                              <asp:DropDownList ID="dropStatus" runat="server" CssClass="form-control">
                                 <asp:ListItem Text="Publish" Value="True"></asp:ListItem>
                                 <asp:ListItem Text="Draft" Value="False"></asp:ListItem>
                             </asp:DropDownList>
                           </p>
                        </div>
                     </div>
                     <div class="form-group" style="margin-bottom:0px;">
                        <label class="col-lg-6 control-label"> Published on:  </label>
                        <div class="col-lg-6">
                           <p class="form-control-static">
                              <asp:Literal ID="lbldatepublish" runat="server"></asp:Literal>
                           </p>
                        </div>
                     </div>
                     <div class="form-group" style="margin-bottom:0px;">
                        <label class="col-lg-6 control-label">View Count: </label>
                        <div class="col-lg-6">
                           <p class="form-control-static">
                              <asp:Literal ID="viewcount" runat="server"></asp:Literal>
                           </p>
                        </div>
                     </div>
                  </div>
                  <div class="form-group" style="text-align:right">
                     <div >
                         <asp:LinkButton ID="linktrash" runat="server" CausesValidation="false" OnClick="linktrash_Click" style="float:left;margin-left:10px;text-decoration:underline;margin-top:10px;" Text="Move to trash"></asp:LinkButton>
                         <asp:LinkButton ID="linkrestore" runat="server" CausesValidation="false" Visible="false" OnClick="linkrestore_Click" style="float:left;margin-left:10px;text-decoration:underline;margin-top:10px;" Text="Restore"></asp:LinkButton>
                        <asp:Button ID="btnPubish" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="btnPubish_Click" />
                     </div>
                  </div>
               </div>
            </div>


             <div class="ibox float-e-margins">
               <div class="ibox-title">
                  <h5>Feature Image</h5>
                  <div class="ibox-tools">
                  </div>
               </div>
               <div class="ibox-content">

                   <div class="form-group">
                    <label class=" control-label">Cover Image</label>
                    <div class="media_item_box" id="media_item_box_10">
                        <label>No Media selected</label>
                        <button id="addimg10" type="button" class="addmedia btn btn-success btn-xs">Add Media</button>
                        <asp:HiddenField ID="feature_image_url"   runat="server" ClientIDMode="Static" />
                      <asp:HiddenField ID="feature_image_mid"   runat="server" ClientIDMode="Static" />
                        <%--<asp:HiddenField ID="hd_postMeidaID"   runat="server" ClientIDMode="Static" />--%>
                    </div>
                    </div>
                  
                  <div class="hr-line-dashed"></div>
                  
               </div>
            </div>

            <div class="ibox float-e-margins">
               <div class="ibox-title">
                  <h5>Pages Cover</h5>
                  <div class="ibox-tools">
                  </div>
               </div>
               <div class="ibox-content">

                   <div class="form-group">
                    <label class=" control-label">Cover Image</label>
                    <div class="media_item_box" id="media_item_box_5">
                        <label>No Media selected</label>
                        <button id="addimg5" type="button" class="addmedia btn btn-success btn-xs">Add Media</button>
                        <asp:HiddenField ID="CoverImage1"   runat="server" ClientIDMode="Static" />
                      <asp:HiddenField ID="hd_MID"   runat="server" ClientIDMode="Static" />
                        <%--<asp:HiddenField ID="hd_postMeidaID"   runat="server" ClientIDMode="Static" />--%>
                    </div>
                    </div>
                  <div class="form-group">
                     <label class=" control-label">Cover Type</label>
                     <div >
                        <select class="form-control m-b" name="CoverType" id="CoverType" runat="server">
                           <option value="1">Show Banner</option>
                           <option value="2">Banner Backgound Header</option>
                        </select>
                     </div>
                  </div>
                  <div class="hr-line-dashed"></div>
                  <div class="form-group">
                     <label class=" control-label">Master Slider <br>
                     <small class="text-navy">Override the cover</small></label>
                     <div class="">
                        <asp:RadioButtonList ID="radioshowmMS" runat="server">
                           <asp:ListItem  Text="Yes" Value="True"></asp:ListItem>
                           <asp:ListItem  Text="No" Selected="True" Value="False"></asp:ListItem>
                        </asp:RadioButtonList>
                        <%--<div><label> <input type="radio" checked="" value="option1" id="optionsRadios1" name="optionsRadios"> Yes.
                           </label></div>
                            <div><label> <input type="radio" value="option2" id="optionsRadios2" name="optionsRadios"> NO.</label></div>--%>
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
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.min.js"   integrity="sha256-eGE6blurk5sHj+rmkfsGYeKyZx3M4bG+ZlFyA7Kns7E="   crossorigin="anonymous"></script>

  
   <%--<script src="/admin/Application/bower_components/tinymce/tinymce.min.js"></script>--%>
   <script type="text/javascript">
       $(document).ready(function () {
           

          
        
               
          
           
           //position:absolute;

           $('#btnfullcontent').on('click', function () {
               $("#iframcontent").contents().find("#full_exit").toggleClass('class-hidden-full');
               //$('#full_exit', children.document).toggleClass('class-hidden-full');

               $('#iframcontent').toggleClass('positionAbsolute');
               $('#tab_custom_gs').toggleClass('positionIgnored');
               $('#ele_custom_gs').toggleClass('positionIgnored');
               
           });


                       
                                      


           var option = $('#drop_b_client_ret option');
           if (option.length > 0) {
               $.each(option, function () {
                   var uuid = guid();
                   var mid = $(this).html();
                   var dropsocial = $('#dropSocial').html();
                   var val = $(this).attr('value');

                   var caption = val.split('#')[0];
                   var url = val.split('#')[1];

                   var chk = '<input type="checkbox" name="chk_banner_client" checked="checked" value="' + uuid + '" style="display:none;" />';

                   var media = '<div class="media_item_box" id="media_item_box_' + uuid + '"   style="margin-top:5px;"><label> No Media selected</label>';
                   media += '<button id="addimg_' + uuid + '" type="button" class="btn btn-success btn-xs" onclick="BindMediaBoxList(this);"> Add Banner</button>';
                   media += '<input type="hidden" id="b3_url_' + uuid + '"  name="b3_url_' + uuid + '" value="' + url+'" />';
                   media += '<input type="hidden" id="b3_id_' + uuid + '" name="b3_id_' + uuid + '" value="' + mid+'" />';
                   media += '</div >';    

                   var txtbox = '<input class="form-control" type="textbox"  id="caption_s_' + uuid + '" name="caption_s_' + uuid + '" value="' + caption + '" />';
                   var html = '<tr id="row_s_' + uuid + '">';
                   html += '<td>' + chk + txtbox + '</td>';
                   html += '<td>' + media + '</td>';
                   html += '<td><button data-idrow="' + uuid + '"  onclick="removeRow(this);" class="btn btn-warning btn-circle" type="button"><i class="fa fa-times"></i></button ></td>';
                   html += '</tr>';


                   $('#add-row-social tbody').append(html);


                   $('#sel_' + uuid).val(val);
               });
           }


           $("#addrow").on('click', function () {
               var uuid = guid();

               //var dropsocial = $('#dropSocial').html();


               var media = '<div class="media_item_box" id="media_item_box_' + uuid+'"   style="margin-top:5px;"><label> No Media selected</label>';
               media += '<button id="addimg_' + uuid +'" type="button" class="btn btn-success btn-xs" onclick="BindMediaBoxList(this);"> Add Banner</button>';
               media += '<input type="hidden" id="b3_url_' + uuid + '"  name="b3_url_' + uuid +'" />';
               media += '<input type="hidden" id="b3_id_' + uuid + '" name="b3_id_' + uuid +'" />';
               media += '</div >';    

               var chk = '<input type="checkbox" name="chk_banner_client" checked="checked" value="' + uuid + '" style="display:none;" />';
          
               var txtbox = '<input class="form-control" type="textbox"  id="caption_s_' + uuid + '" name="caption_s_' + uuid + '" />'

               var html = '<tr id="row_s_' + uuid + '">';
               html += '<td>' + chk + txtbox + '</td>';
               html += '<td>' + media + '</td>';
               html += '<td><button data-idrow="' + uuid + '"  onclick="removeRow(this);" class="btn btn-warning btn-circle" type="button"><i class="fa fa-times"></i></button ></td>';
               html += '</tr>';

               $('#add-row-social tbody').append(html);
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

    <script>
        $(document).ready(function () {

            $('#lightBoxGallery_post_gal').sortable({
                start: function (event, ui) {
                    var start_pos = ui.item.index();
                    ui.item.data('start_pos', start_pos);
                },
                change: function (event, ui) {
                    var start_pos = ui.item.data('start_pos');
                    var index = ui.placeholder.index();
                    if (start_pos < index) {
                        $('#lightBoxGallery_post_gal .media_item_box_gall:nth-child(' + index + ')').addClass('list-group-item-success');
                    } else {
                        $('#sortable .media_item_box_gall:eq(' + (index + 1) + ')').addClass('list-group-item-success');
                    }
                },
                update: function (event, ui) {
                    $('#lightBoxGallery_post_gal .media_item_box_gall').removeClass('list-group-item-success');
                    //ui.item.find('input[name^="p_gall_pri"]').val(ui.item.index() + 1);
                    var datai = $('.media_item_box_gall');
                    $.each(datai, function (index,data) {
                        $(data).find('input[name^="p_gall_pri"]').val(index+1);
                    });
                }
            });



            if ($("#ProductDetail").length > 0) {
                CKEDITOR.replace('ProductDetail');
            }
            if ($("#ProductInformation").length > 0) {
                CKEDITOR.replace('ProductInformation');
            }

        });
    </script>
</asp:Content>