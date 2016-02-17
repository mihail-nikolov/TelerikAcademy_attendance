<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CachingDataHW.Contact" %>
<%@ Register Src="~/UserControl.ascx" TagPrefix="my" TagName="Kor" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
    <h2>caching</h2>
    <p>===========================================================================================</p>
    <div>
        <my:kor runat="server" />
    </div>
    <h3>current time: <%: DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture) %></h3>
</asp:Content>
