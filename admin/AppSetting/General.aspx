<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="General.aspx.cs" Inherits="_General" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
              <div class="row">
                <div class="col-lg-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Server Setting <small></small></h5>
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
                           
                            </div>
                             <div class="hr-line-dashed"></div>
                            <div  class="form-horizontal">
                                <div class="form-group" runat="server" id="Div4" ><label class="col-sm-2 control-label">Hone Page</label>
                                    <div class="col-sm-10"> 
                                        <asp:DropDownList ID="dropPost" runat="server" CssClass="form-control"></asp:DropDownList>
                                      
                                    </div>
                                        
                                </div>

                                 <div class="hr-line-dashed"></div>
                                   <div class="form-group" runat="server" id="Div1" ><label class="col-sm-2 control-label">Site Title</label>
                                    <div class="col-sm-10"> 
                                        <asp:TextBox ID="wsTitle"  runat="server" CssClass="form-control"></asp:TextBox>
                                      
                                    </div>
                                        
                                </div>

                                 <div class="hr-line-dashed"></div>
                                
                                   <div class="form-group" runat="server" id="Div2" ><label class="col-sm-2 control-label">Tagline</label>
                                    <div class="col-sm-10"> 
                                        <asp:TextBox ID="tagline"  runat="server" CssClass="form-control"></asp:TextBox>
                                      
                                    </div>
                                        
                                </div>

                                 <div class="hr-line-dashed"></div>
                                <div class="form-group" runat="server" id="option_1" ><label class="col-sm-2 control-label">Website Address(Url)</label>
                                    <div class="col-sm-10"> 
                                        <asp:TextBox ID="wsurl" placeholder="http://www.xxx.com" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="wsurl" Display="Dynamic" ErrorMessage="*required" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                        
                                </div>

                                 <div class="hr-line-dashed"></div>

                               
                                <div class="form-group"><label class="col-sm-2 control-label">Timezone</label>
                                    <div class="col-sm-10">
                                        <select id="timezone_string" name="timezone_string" runat="server" class="form-control" aria-describedby="timezone-description">
	                                             <option value="UTC-12">UTC-12</option>
                                                        <option value="UTC-11.5">UTC-11:30</option>
                                                        <option value="UTC-11">UTC-11</option>
                                                        <option value="UTC-10.5">UTC-10:30</option>
                                                        <option value="UTC-10">UTC-10</option>
                                                        <option value="UTC-9.5">UTC-9:30</option>
                                                        <option value="UTC-9">UTC-9</option>
                                                        <option value="UTC-8.5">UTC-8:30</option>
                                                        <option value="UTC-8">UTC-8</option>
                                                        <option value="UTC-7.5">UTC-7:30</option>
                                                        <option value="UTC-7">UTC-7</option>
                                                        <option value="UTC-6.5">UTC-6:30</option>
                                                        <option value="UTC-6">UTC-6</option>
                                                        <option value="UTC-5.5">UTC-5:30</option>
                                                        <option value="UTC-5">UTC-5</option>
                                                        <option value="UTC-4.5">UTC-4:30</option>
                                                        <option value="UTC-4">UTC-4</option>
                                                        <option value="UTC-3.5">UTC-3:30</option>
                                                        <option value="UTC-3">UTC-3</option>
                                                        <option value="UTC-2.5">UTC-2:30</option>
                                                        <option value="UTC-2">UTC-2</option>
                                                        <option value="UTC-1.5">UTC-1:30</option>
                                                        <option value="UTC-1">UTC-1</option>
                                                        <option value="UTC-0.5">UTC-0:30</option>
                                                        <option value="UTC+0">UTC+0</option>
                                                        <option value="UTC+0.5">UTC+0:30</option>
                                                        <option value="UTC+1">UTC+1</option>
                                                        <option value="UTC+1.5">UTC+1:30</option>
                                                        <option value="UTC+2">UTC+2</option>
                                                        <option value="UTC+2.5">UTC+2:30</option>
                                                        <option value="UTC+3">UTC+3</option>
                                                        <option value="UTC+3.5">UTC+3:30</option>
                                                        <option value="UTC+4">UTC+4</option>
                                                        <option value="UTC+4.5">UTC+4:30</option>
                                                        <option value="UTC+5">UTC+5</option>
                                                        <option value="UTC+5.5">UTC+5:30</option>
                                                        <option value="UTC+5.75">UTC+5:45</option>
                                                        <option value="UTC+6">UTC+6</option>
                                                        <option value="UTC+6.5">UTC+6:30</option>
                                                        <option selected="selected" value="7">UTC+7</option>
                                                        <option value="UTC+7.5">UTC+7:30</option>
                                                        <option value="UTC+8">UTC+8</option>
                                                        <option value="UTC+8.5">UTC+8:30</option>
                                                        <option value="UTC+8.75">UTC+8:45</option>
                                                        <option value="UTC+9">UTC+9</option>
                                                        <option value="UTC+9.5">UTC+9:30</option>
                                                        <option value="UTC+10">UTC+10</option>
                                                        <option value="UTC+10.5">UTC+10:30</option>
                                                        <option value="UTC+11">UTC+11</option>
                                                        <option value="UTC+11.5">UTC+11:30</option>
                                                        <option value="UTC+12">UTC+12</option>
                                                        <option value="UTC+12.75">UTC+12:45</option>
                                                        <option value="UTC+13">UTC+13</option>
                                                        <option value="UTC+13.75">UTC+13:45</option>
                                                        <option value="UTC+14">UTC+14</option>

                                        </select>
                                      
                                    </div>
                                </div>


                                  <div class="hr-line-dashed"></div>
                                <div class="form-group" runat="server" id="Div3" ><label class="col-sm-2 control-label">Site Language</label>
                                    <div class="col-sm-10"> 
                                       <asp:DropDownList ID="dropStiteLang" runat="server">
                                            <asp:ListItem Text="English (United States)" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="Thai" Value="2"></asp:ListItem>
                                       </asp:DropDownList>
                                       
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
