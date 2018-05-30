<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="event.aspx.cs" Inherits="Schulplaner._event" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 runat="server" id="title"></h1>

        <div class="form-group">
            <asp:Label runat="server" for="id">ID</asp:Label>
            <asp:TextBox runat="server" id="ID" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" for="beschreibung">Beschreibung:</asp:Label>
            <asp:TextBox runat="server" ID="beschreibung" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" for="starttime">Startzeit</asp:Label>
            <asp:TextBox runat="server" id="starttime" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" for="endtime">Endzeit</asp:Label>
            <asp:TextBox runat="server" id="endtime" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button runat="server" id="save" Text="Speichern" OnClick="update" CssClass="btn btn-success" />
        <asp:Button runat="server" id="löschen" Text="Löschen" OnClick="delete" CssClass="btn btn-danger" />
        <asp:Button runat="server" ID="back" Text="Zurück" OnClick="goBack" CssClass="btn btn-warning" />

    </div>

</asp:Content>
