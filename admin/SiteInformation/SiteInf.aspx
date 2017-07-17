<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SiteInf.aspx.cs" Inherits="_SiteInf" %>

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
           
          </style>
    </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
              <div class="row">
                <div class="col-lg-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Global Information <small></small></h5>
                            <div class="ibox-tools">
                                <%--<a class="collapse-link">
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
                                </a>--%>
                            </div>
                        </div>
                        <div class="ibox-content">
                           
                            <div  class="form-horizontal">

                                   <div class="form-group" runat="server" id="Div1" ><label class="col-sm-2 control-label">Slocan</label>
                                    <div class="col-sm-10"> 
                                        <asp:TextBox ID="s_slocan"  runat="server" CssClass="form-control"></asp:TextBox>
                                      
                                    </div>
                                        
                                </div>

                                 <div class="hr-line-dashed"></div>
                                
                                   <div class="form-group" runat="server" id="Div2" ><label class="col-sm-2 control-label">Address</label>
                                    <div class="col-sm-10"> 
                                        <asp:TextBox ID="s_address" TextMode="MultiLine"  Rows="5" runat="server" CssClass="form-control"></asp:TextBox>
                                      
                                    </div>
                                        
                                </div>

                                 <div class="hr-line-dashed"></div>
                                <div class="form-group" runat="server" id="option_1" ><label class="col-sm-2 control-label">Phone</label>
                                    <div class="col-sm-10"> 
                                        <asp:TextBox ID="s_phone"  TextMode="MultiLine"  Rows="3"  runat="server" CssClass="form-control"></asp:TextBox>
                                     
                                    </div>
                                        
                                </div>

                                  <div class="hr-line-dashed"></div>
                                <div class="form-group" runat="server" id="Div4" ><label class="col-sm-2 control-label">Fax</label>
                                    <div class="col-sm-10"> 
                                        <asp:TextBox ID="s_fax"  TextMode="MultiLine"  Rows="3"  runat="server" CssClass="form-control"></asp:TextBox>
                                     
                                    </div>
                                        
                                </div>
                                <div class="hr-line-dashed"></div>
                                <div class="form-group" runat="server" id="Div5" ><label class="col-sm-2 control-label">Latitude</label>
                                    <div class="col-sm-10"> 
                                        <asp:TextBox ID="s_lat"   runat="server" CssClass="form-control"></asp:TextBox>
                                     
                                    </div>
                                        
                                </div>
                                <div class="hr-line-dashed"></div>
                                <div class="form-group" runat="server" id="Div6" ><label class="col-sm-2 control-label">Longitude</label>
                                    <div class="col-sm-10"> 
                                        <asp:TextBox ID="s_long"   runat="server" CssClass="form-control"></asp:TextBox>
                                     
                                    </div>
                                        
                                </div>

                                <div class="hr-line-dashed"></div>
                                <div class="form-group" runat="server" id="Div7" ><label class="col-sm-2 control-label">About Short</label>
                                    <div class="col-sm-10"> 
                                        <asp:TextBox ID="s_about"  TextMode="MultiLine"  Rows="7"  runat="server" CssClass="form-control"></asp:TextBox>
                                     
                                    </div>
                                        
                                </div>


                                 <div class="hr-line-dashed"></div>
                                <div class="form-group" runat="server" id="Div8" ><label class="col-sm-2 control-label">Google Map</label>
                                    <div class="col-sm-10"> 
                                        <asp:TextBox ID="s_googlemap"  TextMode="MultiLine"  Rows="7"  runat="server" CssClass="form-control"></asp:TextBox>
                                     
                                    </div>
                                        
                                </div>

                                 <div class="hr-line-dashed"></div>
                                <div class="form-group" runat="server" id="Div9" ><label class="col-sm-2 control-label">Google Analytic</label>
                                    <div class="col-sm-10"> 
                                        <asp:TextBox ID="s_googleanlytic"  TextMode="MultiLine"  Rows="7"  runat="server" CssClass="form-control"></asp:TextBox>
                                     
                                    </div>
                                        
                                </div>

                            



                                  <div class="hr-line-dashed"></div>

                              <asp:DropDownList  ID="dropSocial" ClientIDMode="Static" style="display:none;" runat="server"></asp:DropDownList>
                                        <div class="form-group" runat="server" id="Div3" ><label class="col-sm-2 control-label">Social Link</label>
                                    <div class="col-sm-10"> 
                                      <table class="table" id="add-row-social" >
                                          <thead>
                                              <tr>
                                                 <td>Socail Name</td>
                                                  <td>Link</td>
                                                 <td></td>
                                              </tr>
                                          </thead>
                                          <tbody>
                                              
                                          </tbody>
                                      </table>

                                        <button id="addrow" type="button" class="btn btn-success btn-xs">Add Row</button>
                                    </div>
                                   
                                </div>
                                    
                                


                                 <div class="hr-line-dashed"></div>
                                <div class="form-group" runat="server" id="Div10" ><label class="col-sm-2 control-label">Logo Top</label>
                                    <div class="col-sm-10"> 
                                      
                                       <label>No image selected</label>
                                         <button id="addimg1" class="addmedia btn btn-success btn-xs" type="button">Add Image</button>
                                    </div> 
                                </div>

                                 <div class="hr-line-dashed"></div>
                                <div class="form-group" runat="server" id="Div11" ><label class="col-sm-2 control-label">Logo Foot</label>
                                    <div class="col-sm-10"> 
                                      
                                       <label>No image selected</label>
                                         <button id="addimg2" type="button" class="addmedia btn btn-success btn-xs">Add Image</button>
                                    </div>
                                        
                                </div>

                                <div class="hr-line-dashed"></div>
                                <div class="form-group" runat="server" id="Div12" ><label class="col-sm-2 control-label">Fav Icon</label>
                                    <div class="col-sm-10"> 
                                      
                                       <label>No image selected</label>
                                         <button id="addimg3" type="button" class="addmedia btn btn-success btn-xs">Add Image</button>
                                    </div>
                                        
                                </div>

                                <div class="hr-line-dashed"></div>
                                <div class="form-group" runat="server" id="Div13" ><label class="col-sm-2 control-label">Main Brochure</label>
                                    <div class="col-sm-10"> 
                                      <label>No file selected</label>
                                         <button id="addfile" type="button" class="addmedia btn btn-success btn-xs">Add File</button>
                                       
                                    </div>
                                        
                                </div>

                                 <div class="hr-line-dashed"></div>



                                <div class="form-group">
                                    <div class="col-sm-4 col-sm-offset-2">
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save changes" CssClass="btn btn-primary" />
                                        <%--<button class="btn btn-white" type="submit">Cancel</button>
                                        <button class="btn btn-primary" type="submit">Save changes</button>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </div>
   
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="/admin/Application/app.media.js?ver=22sss"></script>
    <script type="text/javascript">
        $(document).ready(function () {
          



            $("#addrow").on('click', function () {
                var uuid = guid();

                var dropsocial = $('#dropSocial').html();

                var chk = '<input type="checkbox" name="chk_social" checked="checked" value="' + uuid + '" style="display:none;" />';
                var drop = '<select id="sel_' + uuid + '" name="sel_' + uuid + '" class="form-control">' + dropsocial+'</select>'
                var txtbox = '<input class="form-control" type="textbox"  id="link_s_' + uuid + '" name="link_s_' + uuid +'" />'
                var html = '<tr id="row_s_' + uuid + '"><td>' + chk + drop + '</td><td>' + txtbox + '</td><td><button data-idrow="' + uuid+'"  onclick="removeRow(this);" class="btn btn-warning btn-circle" type="button"><i class="fa fa-times"></i></button ></td></tr>'
                $('#add-row-social tbody').append(html);
                return false;
            });

            


        });

        function removeRow(e) {
            var id = $(e).data('idrow');
            
           $("#row_s_" + id).remove(); return false;
        }
       
    </script>
    </asp:Content>