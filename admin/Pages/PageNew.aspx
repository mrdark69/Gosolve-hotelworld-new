<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="PageNew.aspx.cs" Inherits="_PageNew" %>

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
          </style>
    
     
    </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
             <div class="row">
                 <div class="col-md-9" style="margin-left:0px; margin-right:0px;padding-left:0px;padding-right:0px;">

                     <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>All form elements <small>With custom checbox and radion elements.</small></h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                    <i class="fa fa-wrench"></i>
                                </a>
                                <ul class="dropdown-menu dropdown-user">
                                    <li><a href="#">Config option 1</a>
                                    </li>
                                    <li><a href="#">Config option 2</a>
                                    </li>
                                </ul>
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <div  class="form">
                                <div class="form-group"><label class=" control-label">Title</label>

                                    <div >
                                  
                                        <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTitle"
                    CssClass="text-danger" ErrorMessage="The Title field is required." />
                                    </div>
                                </div>
                                <div class="hr-line-dashed"></div>
                                <div class="form-group"><label class=" control-label">Content</label>
                                    <div>
                                      <%--<span class="help-block m-b-none">A block of help text that breaks onto a new line and may extend beyond one line.</span>--%>
                                        <button id="btnaddmedia" type="button"  class="addmedia-wysiwyg btn btn-success" data-target="txtContent">Add Media</button>
                                        <asp:TextBox ID="txtContent" ClientIDMode="Static" CssClass="form-control" Rows="20" TextMode="MultiLine" runat="server"></asp:TextBox>
                                       
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
                                        <div class="form-group" style="margin-bottom:0px;"><label class="col-lg-6 control-label">Status</label>

                                    <div class="col-lg-6"><p class="form-control-static">Draft</p></div>
                                </div>

                                        <div class="form-group" style="margin-bottom:0px;"><label class="col-lg-6 control-label">Date Published</label>

                                            <div class="col-lg-6"><p class="form-control-static">---</p></div>
                                        </div>
                                        <div class="form-group" style="margin-bottom:0px;"><label class="col-lg-6 control-label">View Count</label>

                                            <div class="col-lg-6"><p class="form-control-static">0</p></div>
                                        </div>
                                    </div>
                                   
                                    <div class="form-group" style="text-align:right">
                                        <div >
                                           
                                            <button class="btn btn-primary" type="submit">Publish</button>
                                        </div>
                                    </div>
                                    </div>
                     </div>

                      <div class="ibox float-e-margins">
                                <div class="ibox-title">
                                    <h5>Pages Cover</h5> 
                                    <div class="ibox-tools">
                                       
                                    </div>
                                </div>
                                <div class="ibox-content">
                                   
                                   <div class="form-group"><label class=" control-label">Cover Type</label>

                                    <div ><select class="form-control m-b" name="account">
                                        <option>option 1</option>
                                        <option>option 2</option>
                                        <option>option 3</option>
                                        <option>option 4</option>
                                    </select>

                                    </div>
                                </div>

                                    <div class="hr-line-dashed"></div>
                                    <div class="form-group"><label class=" control-label">Master Slider <br>
                                    <small class="text-navy">Override the cover</small></label>

                                    <div class="">
                                      
                                        <div><label> <input type="radio" checked="" value="option1" id="optionsRadios1" name="optionsRadios"> Yes.
                                       </label></div>
                                        <div><label> <input type="radio" value="option2" id="optionsRadios2" name="optionsRadios"> NO.</label></div>
                                    </div>
                                </div>


                               </div>
                     </div>

                 </div>
             </div>
    </div>
   
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
     <script src="/admin/Application/app.media.js?ver=22ssssssuuiiss"></script>

    <%--<script src="//cdn.ckeditor.com/4.7.1/standard/ckeditor.js"></script>--%>
    <script src="../../Scripts/theme/plugins/ckeditor/ckeditor.js"></script>
    <%--<script src="/admin/Application/bower_components/tinymce/tinymce.min.js"></script>--%>
      
    <script type="text/javascript">
     
        $(document).ready(function () {

           
            CKEDITOR.replace('txtContent');



        });

        function addimg() {
           
        }

    </script>
</asp:Content>