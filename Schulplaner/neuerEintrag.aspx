<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="neuerEintrag.aspx.cs" Inherits="Schulplaner.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 509px">
        <br />
        <br />
        <asp:Label ID="adnkasd" runat="server" Text="Titel"></asp:Label>
        <br />
        <asp:TextBox ID="Titel" runat="server" Width="168px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="dasiudasnd" runat="server" Text="Beschreibung"></asp:Label>
        <br />
        <asp:TextBox ID="Beschreibung" runat="server" Height="114px" Width="165px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Startdatum"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Startzeit"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Enddatum"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Endzeit"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="ErinnerungHinzufuegen" runat="server" OnClick="Button1_Click" Text="Erinnerung hinzufuegen" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ErinnerungHinzufuegen0" runat="server" OnClick="Button1_Click" Text="Abbrechen" Width="177px" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ErinnerungHinzufuegen1" runat="server" OnClick="Button1_Click" Text="Termin hinzufügen" />
        <br />
    </div>
</asp:Content>
