<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.User.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<%@ MasterType virtualpath="~/Site.User.master" %>

<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<%--    <!-- BREADCRUMBS -->
<section class="breadcrumb women parallax margbot30">

    <!-- CONTAINER -->
    <div class="container">
        <h2>Women</h2>
    </div><!-- //CONTAINER -->
</section><!-- //BREADCRUMBS -->--%>



     <asp:Literal ID="HeaderSection" runat="server"></asp:Literal>

    <asp:Literal ID="content" runat="server"></asp:Literal>
   
</asp:Content>

<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
</asp:Content>
