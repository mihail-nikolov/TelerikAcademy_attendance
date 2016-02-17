<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CachingDataHW.About" %>
<%@ OutputCache Duration="3600" VaryByParam="none"  %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <p>time: <%: DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture) %></p>
</asp:Content>
