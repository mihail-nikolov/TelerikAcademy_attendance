<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl.ascx.cs" Inherits="CachingDataHW.UserControl" %>
<%@ OutputCache Duration="10" VaryByParam="none" Shared="true" %>
<div>
    <h1>I am the user control</h1>
    <p>time: <%: DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture) %></p>
</div>
