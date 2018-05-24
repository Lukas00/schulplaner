<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="event.aspx.cs" Inherits="Schulplaner._event" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server" ID="test"></asp:Label>
    <asp:Button runat="server" ID="button1" OnClick="doSomething" />

    ID <asp:TextBox runat="server" Enabled="false" ID="id_tb"></asp:TextBox>

</asp:Content>
