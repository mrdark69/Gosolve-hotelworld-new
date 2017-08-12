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

    <style type="text/css">
		
		
		/*a,a:visited {
			color: #4183C4;
			text-decoration: none;
		}
		
		a:hover {
			text-decoration: underline;
		}
		
		pre,code {
			font-size: 12px;
		}
		
		pre {
			width: 100%;
			overflow: auto;
		}
		
		small {
			font-size: 90%;
		}
		
		small code {
			font-size: 11px;
		}*/
		
		/*.placeholder {
			outline: 1px dashed #4183C4;
		}
		
		.mjs-nestedSortable-error {
			background: #fbe3e4;
			border-color: transparent;
		}*/
		
		#tree {
			width: 550px;
			margin: 0;
		}
		
		ol {
			max-width: 450px;
			padding-left: 25px;
		}
		
		ol.sortable,ol.sortable ol {
			list-style-type: none;
		}
		
		.sortable li div {
            /*background-color:#fafafa;
            color:#000;*/
			/*border: 1px solid #d4d4d4;
			-webkit-border-radius: 3px;
			-moz-border-radius: 3px;
			border-radius: 3px;*/
			cursor: move;
			/*border-color: #D4D4D4 #D4D4D4 #BCBCBC;*/
			margin: 0;
			padding: 3px;
		}
		
		li.mjs-nestedSortable-collapsed.mjs-nestedSortable-hovering div {
			border-color: #999;
		}
		
		.disclose, .expandEditor {
			cursor: pointer;
			width: 20px;
			display: none;
		}
		
		.sortable li.mjs-nestedSortable-collapsed > ol {
			display: none;
		}
		
		.sortable li.mjs-nestedSortable-branch > div > .disclose {
			display: inline-block;
		}
		
		.sortable span.ui-icon {
			display: inline-block;
			margin: 0;
			padding: 0;
		}
		
		
	
		
		p,ol,ul,pre,form {
			margin-top: 0;
			margin-bottom: 1em;
		}
		
		dl {
			margin: 0;
		}
		
		dd {
			margin: 0;
			padding: 0 0 0 1.5em;
		}
		
		code {
			background: #e5e5e5;
		}
		
		input {
			vertical-align: text-bottom;
		}
		
		.notice {
			color: #c33;
		}

        .box_menu_custom{
           
            /*border:0!important;*/
         border: 1px solid #ddd !important;
         background:#fafafa;
         padding:0 !important;
        }
        .box_menu_custom_content{
            border-bottom:1px solid #ddd !important;
            border-right:1px solid #ddd !important;
            border-left:1px solid #ddd !important;
            border-top:0;
           font-size: 11px;
        }
            .box_menu_custom_content .btn_delete {
                margin-left:20px;
                color:darkred;
            }
        
        .box_menu_custom h5{
            padding:0px!important;
            margin: 15px 0 0 20px;
        }
         .box_menu_custom .ibox-tools{
            padding:0px!important;
            margin: 15px 5px 0 20px;
        }
        
        .box_menu_custom .ibox-tools span{
            color:#676a6c;
            margin-right:10px;
            font-size:11px;
        }
        .box_menu_custom_main{
             border-bottom:0 !important;
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
                           
                      <span style="display:inline-block">Select menu to edit: </span>     <asp:DropDownList ClientIDMode="Static" Width="200px"  style="display:inline-block" ID="MenuIItem" CssClass="form-control" runat="server"></asp:DropDownList>
                          <asp:Button ID="btndropSel" runat="server" CssClass="btn btn-success" Text="Select" OnClick="btndropSel_Click" />
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
                        <%  foreach (Model_PostType mm in posttpyList.Where(p => p.PostTypeID != 4)) {
                                this.ArgProp = mm.PostTypeID; %>

                      
                       
                       <div class="ibox float-e-margins border-bottom" style="margin-bottom:0px;" >
                            <input type="checkbox" style="display:none" checked="checked" name="postType" value="<% Response.Write(mm.PostTypeID); %>" />
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
                        
                           <p><input type="checkbox" name="PostID_Archive_<% Response.Write(mm.PostTypeID); %>" value="<% Response.Write(mm.PostTypeID);%>"  /> All</p>
                         <%  } %>
           
                         <% List<Model_Post> cPostlist = cPost.GetPostListByPostType(mm.PostTypeID);
                        foreach(Model_Post p in cPostlist)
                        { %>
                           <p><input type="checkbox" name="PostID_<% Response.Write(p.PostTypeID); %>"  value="<% Response.Write(p.PostID); %>"   /> <% Response.Write(p.Title); %></p>


                         <% } %>
                    
                       <a>Select all</a>
                          

                            <input type="button" class="btn btn-sm btn-success btn_add_menu" value="Add to Menu"  style="float:right" data-cmd="menu_post" data-arg="<% Response.Write(mm.PostTypeID);%>" />
                        
                       <%--<asp:Button ID="btn" runat="server" ClientIDMode="Static"  CssClass="btn btn-sm" style="float:right" CommandName="menu_post" 
                           Text="Add to Menu" OnClick="btn_Click"   CommandArgument="<% mm.PostTypeID %>"    />--%>
                        
                            
                         
                       </div>
                       </div>
                    
                       <% }  %>

                      <%--menu_Tax--%>

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
                                Response.Write(getCatProduct(cTaxList)); %>
                      
                                <div style="clear:both"></div>
                       

                          <input type="button" class="btn btn-sm btn-success btn_add_menu" value="Add to Menu"  style="float:right" data-cmd="menu_Tax" data-arg="3_1" />
                           <div style="clear:both"></div>

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

                                <div class='tax_parent' style='max-height:300px;overflow:scroll;'>
                           <% cTaxList = cTax.GetTaxonomyTaxTypeAndPostType(3, 2);
                            foreach (Model_PostTaxonomy p in cTaxList)
                            {%>
                               <p <% Response.Write((p.RefID > 0 ? "style=\"margin-left:15px;\"" : "")); %>><input type="checkbox" name="TaxID_<% Response.Write(p.PostTypeID); %>_<% Response.Write(p.TaxTypeID); %>"  value="<% Response.Write(p.TaxID); %>"   /><% Response.Write(p.Title); %></p>
                              <%}%>
                                    </div>
                          <div style="clear:both"></div>
                       <input type="button" class="btn btn-sm btn-success btn_add_menu" value="Add to Menu"  style="float:right" data-cmd="menu_Tax" data-arg="3_2" />
                           
                                <div style="clear:both"></div>
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

                                 Response.Write(getCatProduct(cTaxList));
                           %>
                             

                          <div style="clear:both"></div>
                         <input type="button" class="btn btn-sm btn-success btn_add_menu" value="Add to Menu"  style="float:right" data-cmd="menu_Tax" data-arg="2_1" />
                            <div style="clear:both"></div>

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
                                <div class='tax_parent' style='max-height:300px;overflow:scroll;'>

                             <% cTaxList = cTax.GetTaxonomyTaxTypeAndPostType(2, 2);
                            foreach (Model_PostTaxonomy p in cTaxList)
                            {%>
                               <p <% Response.Write((p.RefID > 0 ? "style=\"margin-left:15px;\"" : "")); %>><input type="checkbox" name="TaxID_<% Response.Write(p.PostTypeID); %>_<% Response.Write(p.TaxTypeID); %>"  value="<% Response.Write(p.TaxID); %>"  /> <% Response.Write(p.Title); %></p>
                             <% }%>

                         <div style="clear:both"></div>
                           <input type="button" class="btn btn-sm btn-success btn_add_menu" value="Add to Menu"  style="float:right" data-cmd="menu_Tax" data-arg="2_2" />
                            <div style="clear:both"></div>
                                </div>
                           </div>
                           </div>


                      <%--menu_Tax--%>



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
                                 <div class="form-group"  >
                                    <label class="col-sm-2 control-label">Url</label>
                                    <div class="col-sm-10"> 
                                       <input type="text" class="form-control" id="custome_add_url" name="custome_add_url" />
                                    </div>
                                 </div>
                                 <div class="hr-line-dashed"></div>
                                 <div class="form-group"  >
                                    <label class="col-sm-2 control-label">Link Text</label>
                                    <div class="col-sm-10"> 
                                       <input type="text" class="form-control"  id="custome_add_linktxt" name="custome_add_linktxt" />
                                    </div>
                                 </div>
                              </div>

                                <input type="button" class="btn btn-sm btn-success btn_add_menu" value="Add to Menu"  style="float:right" data-cmd="menu_custom" data-arg="2_2" />
                                <div style="clear:both"></div>
                           </div>
                           <div style="clear:both"></div>
                        </div>




                  </div>
                <div class="col-md-8">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5  style="line-height:30px;margin-right:5px;">Menu Name : </h5>
                             <asp:TextBox ID="TxtMenuName" style="width:250px;"  runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" OnClientClick="return UpdateSortMenu();" Text="Update" OnClick="btnUpdate_Click" style=" float: right;margin-top: -35px;" />
                        </div>
                        <div class="ibox-content">
                           
                            


                             <section id="demo">

                                <%-- ui-sortable mjs-nestedSortable-branch mjs-nestedSortable-expanded--%>

                               <ol class="sortable">

                                   <%  Model_Menu cm = new Model_Menu();
                                       int Group = (string.IsNullOrEmpty(Request.QueryString["menu"])?int.Parse(MenuIItem.SelectedValue): int.Parse(Request.QueryString["menu"]) )   ;
                                       List<Model_Menu> cml = cm.GetMenuAll(Group);

                                       foreach (Model_Menu m in cml.Where(r=>r.MenuRefID == 0).ToList())
                                       {%>
                                            
                                        
                                         <li style="display: list-item;"  id="menuItem_<% Response.Write(m.MID); %>" >
                                             <input type="checkbox" style="display:none" checked="checked" name="menu_checked" value="<% Response.Write(m.MID); %>_<% Response.Write(m.MCategory); %>" />
                                             <div class="ibox float-e-margins  box_menu_custom_main" >
                                                   <div class="ibox-title box_menu_custom">
                                                      <h5><% Response.Write(m.Title); %></h5>
                                                      <div class="ibox-tools">
                                                         <a class="collapse-link">
                                                              <% switch (m.MCategory) { %>
                                                                                <% case 1:  %>
                                                                            <span> <% Response.Write(m.PostPostTypeTitle); %></span>
                                                                                    <%break; %>
                                                                              <% case 2:  %>
                                                                             <span> <% Response.Write(m.PostTypeTitle); %></span>
                                                                                    <%break; %>
                                                                              <% case 3:  %>
                                                                            <span> <% Response.Write(m.TagTypeTitle); %></span>
                                                                                    <%break; %>
                                                                        <% case 4:  %>
                                                               <span> Custom Link</span>
                                                                      <%break; %>       
                                                                            <%} %>

                                                            
                                                         <i class="fa fa-chevron-down"></i>
                                                         </a>
                                                      </div>
                                                   </div>
                                                   <div class="ibox-content box_menu_custom_content" style="display: none;">
                                                      <div  class="form-horizontal">
                                                           <%if (m.MCategory == 4) { %>
                                                                 <div class="form-group"  >
                                                                    <label class="col-sm-2 control-label">Url</label>
                                                                    <div class="col-sm-10"> 
                                                                       <input type="text" class="form-control" name="custom_url_<% Response.Write(m.MID); %>_<% Response.Write(m.MCategory); %>" value="<% Response.Write(m.CustomUrl); %>" />
                                                                    </div>
                                                                 </div>
                                                                  <%} %>
                                                         <div class="form-group"  >
                                                            <label class="col-sm-2 control-label">Label</label>
                                                            <div class="col-sm-9"> 
                                                               <input type="text" class="form-control" name="label_<% Response.Write(m.MID); %>_<% Response.Write(m.MCategory); %>" value="<% Response.Write(m.Title); %>" />
                                                            </div>
                                                         </div>
                                                         <div class="hr-line-dashed"></div>
                                                         <div class="form-group"  >
                                                            <label class="col-sm-2 control-label">Title Tag</label>
                                                            <div class="col-sm-9"> 
                                                               <input type="text" class="form-control" name="TagTitle_<% Response.Write(m.MID); %>_<% Response.Write(m.MCategory); %>" value="<% Response.Write(m.TitleTag); %>" />
                                                            </div>
                                                         </div>

                                                          <% if(m.MCategory != 4){ %>
                                                         <div class="hr-line-dashed"></div>
                                                         <div class="form-group"  >
                                                            <label class="col-sm-11 control-label"><small> Original:</small>
                                                                <% switch (m.MCategory) { %>
                                                                                <% case 1:  %>
                                                                             <% Response.Write(m.PostSlug); %>
                                                                                    <%break; %>
                                                                              <% case 2:  %>
                                                                             <% Response.Write(m.PostTypeSlug); %>
                                                                                    <%break; %>
                                                                              <% case 3:  %>
                                                                             <% Response.Write(m.TaxSlug); %>
                                                                                    <%break; %>
                                                                            
                                                                            <%} %>

                                                            </label>
                                                            
                                                         </div>
                                                          <%} %>

                                                            <div class="hr-line-dashed"></div>
                                                          <div class="form-group">
                                                              <div class="col-md-11">
                                                                  <a href="#" data-id="<% Response.Write(m.MID); %>"  class="btn_delete">Delete</a>
                                                              </div>

                                                          </div>
                                                      </div>
                                                   </div>
                                                </div>
                                     

                                 <%List<Model_Menu> cml_c = cml.Where(i => i.MenuRefID == m.MID).ToList();

                                     if (cml_c.Count > 0) {  %>

                                              <ol>
                                                  <%foreach (Model_Menu mc in cml_c) { %>
                                                  <li style="display: list-item;"  id="menuItem_<% Response.Write(mc.MID); %>">
                                                       <input type="checkbox" style="display:none" checked="checked" name="menu_checked" value="<% Response.Write(mc.MID); %>_<% Response.Write(mc.MCategory); %>" />
                                                    <div class="ibox float-e-margins box_menu_custom_main">
                                                           <div class="ibox-title box_menu_custom">
                                                              <h5><% Response.Write(mc.Title); %></h5>
                                                              <div class="ibox-tools">
                                                                 <a class="collapse-link">

                                                                     <% switch (mc.MCategory) { %>
                                                                                <% case 1:  %>
                                                                            <span> <% Response.Write(mc.PostPostTypeTitle); %></span>
                                                                                    <%break; %>
                                                                              <% case 2:  %>
                                                                             <span> <% Response.Write(mc.PostTypeTitle); %></span>
                                                                                    <%break; %>
                                                                              <% case 3:  %>
                                                                            <span> <% Response.Write(mc.TagTypeTitle); %></span>
                                                                                    <%break; %>
                                                                        <% case 4:  %>
                                                               <span> Custom Link</span>
                                                                      <%break; %>       
                                                                            <%} %>

                                                                 <i class="fa fa-chevron-down"></i>
                                                                 </a>
                                                              </div>
                                                           </div>
                                                           <div class="ibox-content box_menu_custom_content" style="display: none;">
                                                              <div  class="form-horizontal">

                                                                  <%if (mc.MCategory == 4) { %>
                                                                 <div class="form-group"  >
                                                                    <label class="col-sm-2 control-label">Url</label>
                                                                    <div class="col-sm-10"> 
                                                                       <input type="text" class="form-control" name="custom_url_<% Response.Write(mc.MID); %>_<% Response.Write(mc.MCategory); %>"  value="<% Response.Write(mc.CustomUrl); %>" />
                                                                    </div>
                                                                 </div>
                                                                  <%} %>

                                                                 <div class="hr-line-dashed"></div>
                                                                 <div class="form-group"  >
                                                                    <label class="col-sm-2 control-label">Label</label>
                                                                    <div class="col-sm-10"> 
                                                                       <input type="text" class="form-control"  name="label_<% Response.Write(mc.MID); %>_<% Response.Write(mc.MCategory); %>" value="<% Response.Write(mc.Title); %>" />
                                                                    </div>
                                                                 </div>
                                                                   <div class="hr-line-dashed"></div>
                                                                     <div class="form-group"  >
                                                                        <label class="col-sm-2 control-label">Title Tag</label>
                                                                        <div class="col-sm-9"> 
                                                                           <input type="text" class="form-control" name="TagTitle_<% Response.Write(mc.MID); %>_<% Response.Write(mc.MCategory); %>" value="<% Response.Write(mc.TitleTag); %>"  />
                                                                        </div>
                                                                     </div>

<%--    Post = 1,
    Archive = 2,
    Taxonomy = 3,
    CustomLink = 4--%>
                                                                    <% if(mc.MCategory != 4){ %>
                                                                  <div class="hr-line-dashed"></div>
                                                                     <div class="form-group"  >
                                                                        <label class="col-sm-11 control-label"><small> Original:</small>
                                                                            <% switch (mc.MCategory) { %>
                                                                                <% case 1:  %>
                                                                             <% Response.Write(mc.PostSlug); %>
                                                                                    <%break; %>
                                                                              <% case 2:  %>
                                                                             <% Response.Write(mc.PostTypeSlug); %>
                                                                                    <%break; %>
                                                                              <% case 3:  %>
                                                                             <% Response.Write(mc.TaxSlug); %>
                                                                                    <%break; %>
                                                                            
                                                                            <%} %>

                                                                        </label>
                                                            
                                                                     </div>
                                                                   <%} %>

                                                                  <div class="hr-line-dashed"></div>
                                                                      <div class="form-group">
                                                                          <div class="col-sm-11">
                                                                              <a href="#" data-id="<% Response.Write(mc.MID); %>" class="btn_delete">Delete</a>
                                                                          </div>

                                                                      </div>
                                                              </div>
                                                           </div>
                                                        </div>
                                                  </li>

                                                   <%} %>
                                            </ol>
                                             

                                    <%} %>
                                  

                                        </li>

                                        

                                   <%} %>
                                 
                                 
                                  
                               </ol>

                                 <input type="hidden" id="Nest_ret" name="Nest_ret" />
                               <%--<h3>Try the custom methods:</h3>
                               <p><br>
                                  <input id="serialize" name="serialize" type="submit" value=
                                     "Serialize">
                               </p>
                               <pre id="serializeOutput">
		                                                            </pre>
                               <p><input id="toArray" name="toArray" type="submit" value=
                                  "To array"></p>
                               <pre id="toArrayOutput">
		                                                            </pre>
                               <p><input id="toHierarchy" name="toHierarchy" type="submit" value=
                                  "To hierarchy"></p>
                               <pre id="toHierarchyOutput">
		                                                            </pre>
                               <p><em>Note: This demo has the <code>maxLevels</code> option set to '4'.</em></p>--%>
                            </section>      


                          
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

            $('.btn_add_menu').on('click', function () {

                
                var url = "<%= ResolveUrl("/admin/Post/ajax_webmethod_post.aspx/AddMenu") %>";


               
                var cmd = $(this).data('cmd');
                var cmdarg = $(this).data('arg');

                var arch = $('input[name="PostID_Archive_' + cmdarg + '"]:checked');
                var post = $('input[name="PostID_' + cmdarg + '"]:checked');
                var tax = $('input[name="TaxID_' + cmdarg + '"]:checked');

                var urlCustom = $('#custome_add_url').val();
                var txt = $('#custome_add_linktxt').val();
                var strpost = $.map(post, function (obj) {
                    return obj.value
                }).join(',');

                var strarch = $.map(arch, function (obj) {
                    return obj.value
                }).join(',');

                var strtax = $.map(tax, function (obj) {
                    return obj.value
                }).join(',');

                var pr = {
                    cmd: cmd,
                    cmdarg: cmdarg,
                    strpost:strpost,
                    strarch: strarch,
                    strtax: strtax,
                    url: urlCustom,
                    txt: txt,
                    GroupID :$('#MenuIItem').val()
                }
                

                //var url = "/Application/ajax/mailbox/ajax_webmethod_mailbox.aspx/Trash";
                var param = JSON.stringify({ parameters: pr });
                AjaxPost(url, param, null, function (data) {
                    if (data.success) {

                        var qm = getParameterByName('menu');
                        if (qm) {
                            window.location.href = "Menu?menu=" + qm;
                        } else {
                            window.location.href = "Menu";
                        }
                       
                    }

                });

                return false;
            });



            var ns = $('ol.sortable').nestedSortable({
                forcePlaceholderSize: true,
                handle: 'div',
                helper: 'clone',
                items: 'li',
                opacity: .6,
                placeholder: 'placeholder',
                revert: 250,
                tabSize: 25,
                tolerance: 'pointer',
                toleranceElement: '> div',
                maxLevels: 2,
                isTree: true,
                expandOnHover: 700,
                startCollapsed: false,
                change: function () {

                    serialized = $('ol.sortable').nestedSortable('serialize');
                    $('#Nest_ret').val(serialized);

                    console.log(serialized);
                    //$('#serializeOutput').text(serialized + '\n\n');
                   
                    console.log('Relocated item');
                },
                sort: function () {
                   
                }
            });

            //$('.expandEditor').attr('title', 'Click to show/hide item editor');
            //$('.disclose').attr('title', 'Click to show/hide children');
            //$('.deleteMenu').attr('title', 'Click to delete item.');

            //$('.disclose').on('click', function () {
            //    $(this).closest('li').toggleClass('mjs-nestedSortable-collapsed').toggleClass('mjs-nestedSortable-expanded');
            //    $(this).toggleClass('ui-icon-plusthick').toggleClass('ui-icon-minusthick');
            //});

            //$('.expandEditor, .itemTitle').click(function () {
            //    var id = $(this).attr('data-id');
            //    $('#menuEdit' + id).toggle();
            //    $(this).toggleClass('ui-icon-triangle-1-n').toggleClass('ui-icon-triangle-1-s');
            //});

            $('.btn_delete').click(function () {
                var id = $(this).attr('data-id');
                $('#menuItem_' + id).remove();

                var url = "<%= ResolveUrl("/admin/Post/ajax_webmethod_post.aspx/DeleteMenu") %>";
                var param = JSON.stringify({ parameters: id });
                AjaxPost(url, param, null, function (data) {
                    if (data.success) {

                        var qm = getParameterByName('menu');
                        if (qm) {
                            window.location.href = "Menu?menu=" + qm;
                        } else {
                            window.location.href = "Menu";
                        }
                    }

                });


                return false;
            });

            //$('#serialize').click(function () {
            //    serialized = $('ol.sortable').nestedSortable('serialize');
            //    $('#serializeOutput').text(serialized + '\n\n');
            //    return false;
            //})

            //$('#toHierarchy').click(function (e) {
            //    hiered = $('ol.sortable').nestedSortable('toHierarchy', { startDepthCount: 0 });
            //    hiered = dump(hiered);
            //    (typeof ($('#toHierarchyOutput')[0].textContent) != 'undefined') ?
            //        $('#toHierarchyOutput')[0].textContent = hiered : $('#toHierarchyOutput')[0].innerText = hiered;

            //    return false;
            //})

            //$('#toArray').click(function (e) {
            //    arraied = $('ol.sortable').nestedSortable('toArray', { startDepthCount: 0 });
            //    arraied = dump(arraied);
            //    (typeof ($('#toArrayOutput')[0].textContent) != 'undefined') ?
            //        $('#toArrayOutput')[0].textContent = arraied : $('#toArrayOutput')[0].innerText = arraied;

            //    return false;
            //});


        });

        function UpdateSortMenu() {
            var url = "<%= ResolveUrl("/admin/Post/ajax_webmethod_post.aspx/UpdateSortMenu") %>";
            
            

            var arraied  = $('ol.sortable').nestedSortable('toArray', { startDepthCount: 1 });
            


            var pr = {
                GroupID: $('#MenuIItem').val(),
                arraied: arraied
            }
            //var url = "/Application/ajax/mailbox/ajax_webmethod_mailbox.aspx/Trash";
            var param = JSON.stringify({ parameters: pr });
            AjaxPost(url, param, null, function (data) {
                if (data.success) {

                }

            });

            return true;
        }

        function dump(arr, level) {
            var dumped_text = "";
            if (!level) level = 0;

            //The padding given at the beginning of the line.
            var level_padding = "";
            for (var j = 0; j < level + 1; j++) level_padding += "    ";

            if (typeof (arr) == 'object') { //Array/Hashes/Objects
                for (var item in arr) {
                    var value = arr[item];

                    if (typeof (value) == 'object') { //If it is an array,
                        dumped_text += level_padding + "'" + item + "' ...\n";
                        dumped_text += dump(value, level + 1);
                    } else {
                        dumped_text += level_padding + "'" + item + "' => \"" + value + "\"\n";
                    }
                }
            } else { //Strings/Chars/Numbers etc.
                dumped_text = "===>" + arr + "<===(" + typeof (arr) + ")";
            }
            return dumped_text;
        }
       
    </script>
    </asp:Content>