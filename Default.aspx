﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.User.Master" ViewStateMode="Disabled" EnableViewState="false" EnableViewStateMac="false" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<%@ MasterType virtualpath="~/Site.User.master" %>

<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <asp:Literal ID="HeaderSection" runat="server"></asp:Literal>

    <asp:Literal ID="content" runat="server"></asp:Literal>
   
</asp:Content>

<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
</asp:Content>
