<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="_Menu" %>

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
                    <div class="col-md-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Menu Item <small></small></h5>
                        </div>
                        <div class="ibox-content">
                           
                        Select menu to edit:    <asp:DropDownList ID="MenuIItem" runat="server"></asp:DropDownList>
                          
                        </div>
                    </div>
                </div>
                </div>
              <div class="row">
                  <div class="col-md-4">


                      <%  
                           Model_Post cPost = new Model_Post();
                          Model_PostType cPostType = new Model_PostType();
                          List<Model_PostType> posttpyList = cPostType.GetPostTypeAll();

                           Model_PostTaxonomy cTax = new Model_PostTaxonomy();
                      %>
                        <%  foreach (Model_PostType mm in posttpyList.Where(p => p.PostTypeID != 4)) {  %>

                       <div class="ibox float-e-margins border-bottom" style="margin-bottom:0px;">
                       <div class="ibox-title">
                       <h5><% Response.Write(mm.Title); %></h5>
                       <div class="ibox-tools">
                       <a class="collapse-link">
                       <i class="fa fa-chevron-down"></i>
                       </a>
                       </div>
                       </div>
                        <div class="ibox-content" style="display: none;">
                        <% if(mm.PostTypeID != 1){%>
                        
                           <p><input type="checkbox"  /> All</p>
                         <%  } %>
           
                         <% List<Model_Post> cPostlist = cPost.GetPostListByPostType(mm.PostTypeID);
                        foreach(Model_Post p in cPostlist)
                        { %>
                           <p><input type="checkbox"  /> <% Response.Write(p.Title); %></p>
                         <% } %>
                    
                       <a>Select all</a>
                          
                       <asp:Button ID="btn" runat="server" CssClass="btn btn-sm" style="float:right" Text="Add to Menu" OnClick="btn_Click" />
                       <%--<button  class="btn btn-sm" style="float:right">Add to Menu</button>--%>

                       </div>
                       </div>
                    
                       <% }  %>



                       <%List<Model_PostTaxonomy> cTaxList = null; %>

       <div class="ibox float-e-margins border-bottom" style="margin-bottom:0px;">
       <div class="ibox-title">
       <h5>Product Categories</h5>
       <div class="ibox-tools">
       <a class="collapse-link">
       <i class="fa fa-chevron-down"></i>
       </a>
       </div>
       </div>
       <div class="ibox-content" style="display: none;">
 

        <%  cTaxList = cTax.GetTaxonomyTaxTypeAndPostType(3, 1);
        foreach (Model_PostTaxonomy p in cTaxList)
        { %>
           <p><input type="checkbox"  /><% Response.Write(p.Title); %></p>
        <%  }%>

       <a>Select all</a>
       <asp:Button ID="Button4" runat="server" CssClass="btn btn-sm" style="float:right" Text="Add to Menu" OnClick="btn_Click" />

       </div>
       </div>

       <div class="ibox float-e-margins border-bottom" style="margin-bottom:0px;">
       <div class="ibox-title">
       <h5>Product Tags </h5>
       <div class="ibox-tools">
       <a class="collapse-link">
       <i class="fa fa-chevron-down"></i>
       </a>
       </div>
       </div>
       <div class="ibox-content" style="display: none;">

      
       <% cTaxList = cTax.GetTaxonomyTaxTypeAndPostType(3, 2);
        foreach (Model_PostTaxonomy p in cTaxList)
        {%>
           <p><input type="checkbox"  /><% Response.Write(p.Title); %></p>
          <%}%>

       <a>Select all</a>
      <asp:Button ID="Button3" runat="server" CssClass="btn btn-sm" style="float:right" Text="Add to Menu" OnClick="btn_Click" />

       </div>
       </div>

       <div class="ibox float-e-margins border-bottom" style="margin-bottom:0px;">
       <div class="ibox-title">
       <h5>Blog Categories</h5>
       <div class="ibox-tools">
       <a class="collapse-link">
       <i class="fa fa-chevron-down"></i>
       </a>
       </div>
       </div>
       <div class="ibox-content" style="display: none;">
     
        <% cTaxList = cTax.GetTaxonomyTaxTypeAndPostType(2, 1);
        foreach (Model_PostTaxonomy p in cTaxList)
        {%>
           <p><input type="checkbox"  /> <% Response.Write(p.Title); %></p>
       <%  }%>

       <a>Select all</a>
      <asp:Button ID="Button2" runat="server" CssClass="btn btn-sm" style="float:right" Text="Add to Menu" OnClick="btn_Click" />

       </div>
       </div>


       <div class="ibox float-e-margins border-bottom" style="margin-bottom:0px;">
       <div class="ibox-title">
       <h5>Blog Tags</h5>
       <div class="ibox-tools">
       <a class="collapse-link">
       <i class="fa fa-chevron-down"></i>
       </a>
       </div>
       </div>
       <div class="ibox-content" style="display: none;">
       
         <% cTaxList = cTax.GetTaxonomyTaxTypeAndPostType(2, 2);
        foreach (Model_PostTaxonomy p in cTaxList)
        {%>
           <p><input type="checkbox"  /> <% Response.Write(p.Title); %></p>
         <% }%>

       <a>Select all</a>
       <asp:Button ID="Button1" runat="server" CssClass="btn btn-sm" style="float:right" Text="Add to Menu" OnClick="btn_Click" />
       </div>
       </div>



       <div class="ibox float-e-margins border-bottom" style="margin-bottom:0px;">
       <div class="ibox-title">
       <h5>Custom Link </h5>
       <div class="ibox-tools">
       <a class="collapse-link">
       <i class="fa fa-chevron-down"></i>
       </a>
       </div>
       </div>
       <div class="ibox-content" style="display: none;">





       <div  class="form-horizontal">

       <div class="form-group"  ><label class="col-sm-2 control-label">Url</label>
       <div class="col-sm-10"> 

       <input type="text" class="form-control" />
       </div>

        </div>
       <div class="hr-line-dashed"></div>
       <div class="form-group"  ><label class="col-sm-2 control-label">Link Text</label>
       <div class="col-sm-10"> 
       <input type="text" class="form-control" />
       </div>

       </div>
       </div>


       </div>
       </div>




                  </div>
                <div class="col-md-8">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Menu Name : <asp:TextBox ID="TxtMenuName" runat="server"></asp:TextBox></h5>
                            
                        </div>
                        <div class="ibox-content">
                           
                            <asp:Literal ID="MenuList" runat="server"></asp:Literal>
                          
                        </div>
                    </div>
                </div>
            </div>
    </div>
   
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="/admin/Application/app.media.js?ver=22sss"></script>
    <script type="text/javascript">


     
       
    </script>
    </asp:Content>