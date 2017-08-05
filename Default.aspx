<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.User.Master" ViewStateMode="Disabled" EnableViewState="false" EnableViewStateMac="false" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<%@ MasterType virtualpath="~/Site.User.master" %>

<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <asp:Literal ID="HeaderSection" runat="server"></asp:Literal>


 
         <!-- PAGE HEADER -->
		<section class="page_header" id="page_header" runat="server"  visible="false">
			
			<!-- CONTAINER -->
			<div class="container">
				<h3 class="pull-left"><b> <% Response.Write(this.PageContentTitle); %></b></h3>
				
				<div class="pull-right">
					<a href="women.html" >Back to shop<i class="fa fa-angle-right"></i></a>
				</div>
			</div><!-- //CONTAINER -->
		</section>
        <!-- //PAGE HEADER -->
            <!-- PAGE TEMPLATE-->
		<section  style="padding-top:9px;padding-bottom: 20px;" id="page_content"  class="page_content" runat="server" visible="false">
			
			<!-- CONTAINER -->
			<div class="container" >

			  <% Response.Write(this.ContentBody); %>

			</div><!-- //CONTAINER -->
		</section>
            <!--  PAGE TEMPLATE -->

   
  
   
</asp:Content>

<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
</asp:Content>
