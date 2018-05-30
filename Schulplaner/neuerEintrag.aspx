<%@ Page Title="Neuer Eintrag" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="neuerEintrag.aspx.cs" Inherits="Schulplaner.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Neuer Eintrag</h1>
        <div class="form-group">
            <asp:Label runat="server" for="Titel">Titel:</asp:Label>
            <asp:TextBox ID="Titel" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" for="Beschreibung">Beschreibung:</asp:Label>
            <asp:TextBox ID="Beschreibung" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" for="startdatum">Startdatum:</asp:Label>
            <asp:Calendar ID="startdatum" runat="server"></asp:Calendar>
        </div>
        <div class="form-group">
            <asp:Label runat="server" for="startzeit">Startzeit:</asp:Label>
            <asp:TextBox ID="startzeit" runat="server" placeholder="16:30" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label runat="server" for="enddatum">Enddatum:</asp:Label>
            <asp:Calendar ID="enddatum" runat="server"></asp:Calendar>
        </div>
        <div class="form-group">
            <asp:Label runat="server" for="endzeit">Endzeit:</asp:Label>
            <asp:TextBox ID="endzeit" runat="server" placeholder="20:30" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="newEvent" runat="server" OnClick="Button1_Click" Text="Termin hinzufügen" CssClass="btn btn-success" />
        <asp:Button ID="cancel" runat="server" OnClick="goBack" Text="Abbrechen" CssClass="btn btn-warning" />
    </div>

        
        

</asp:Content>
