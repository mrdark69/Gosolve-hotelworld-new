<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" validateRequest="false" AutoEventWireup="true" CodeFile="MediaTax.aspx.cs" Inherits="_MediaTax" %>
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
      
   </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated ">
         
      <div class="row">

         <div class="col-md-9" id="ele_custom_gs" style="margin-left:0px; margin-right:0px;padding-left:0px;padding-right:0px;">
            <div class="tabs-container">
               <ul class="nav nav-tabs">
                  <li class="active"><a data-toggle="tab" href="#tab-1" aria-expanded="true"> Information</a></li>
        
               </ul>
               <div class="tab-content">
                  <div id="tab-1" class="tab-pane active">
                     <div class="panel-body gs-panel-body" id="tab_custom_gs">
                        <div class="ibox float-e-margins">
                           <div class="ibox-content">
                              <div  class="form">
                                 
                                 <div class="form-group">
                                    <label class=" control-label">Title</label>
                                    <div >
                                       <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                       <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTitle"
                                          CssClass="text-danger" ErrorMessage="The Title field is required." />
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
                     <div class="form-group" style="margin-bottom:0px;" id="form_status" runat="server">
                       <%-- <label class="col-lg-6 control-label">Status: </label>
                        <div class="col-lg-6">
                           <p class="form-control-static">
                             <asp:DropDownList ID="dropStatus" runat="server" CssClass="form-control">
                                 <asp:ListItem Text="Publish" Value="True"></asp:ListItem>
                                 <asp:ListItem Text="Draft" Value="False"></asp:ListItem>
                             </asp:DropDownList>
                           </p>
                        </div>--%>
                     </div>
                     <div class="form-group" style="margin-bottom:0px;" id="form_publish" runat="server">
                        <label class="col-lg-6 control-label"> Published on:  </label>
                        <div class="col-lg-6">
                           <p class="form-control-static">
                              <asp:Literal ID="lbldatepublish" runat="server"></asp:Literal>
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

            


         </div>
      </div>
   </div>
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
  
   <%--<script src="//cdn.ckeditor.com/4.7.1/standard/ckeditor.js"></script>--%>
  <%-- <script src="/Scripts/theme/plugins/ckeditor/ckeditor.js"></script>--%>
  
   <%--<script src="/admin/Application/bower_components/tinymce/tinymce.min.js"></script>--%>
   <script type="text/javascript">
       $(document).ready(function () {


         

       });

       function addimg() {

       }

   </script>

     <%-- <script src="/admin/Application/app.media.js?ver=22ssssssuuiiss"></script>--%>
</asp:Content>