<%@ Page Title="" Language="C#" MasterPageFile="~/afterloggedinOU.master" AutoEventWireup="true" CodeFile="aftercancel.aspx.cs" Inherits="aftercancel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" Runat="Server">
<html>
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
<center><font size="7" face="Calibri"><b>--Booking Cancelled For Booking ID==>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label> </b></font>
    <br /><br /><br /><br /><br /><br /><br /><br />
    <asp:Button ID="canhome" runat="server" Text="Home" BackColor="#3399FF" 
        Height="30px" onclick="canhome_Click" Width="140px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
        ID="canbook" runat="server" Text="Book" BackColor="#FFCC00" Height="30px" 
        onclick="canbook_Click" Width="140px" />
    </center>
</body>
</html>
</asp:Content>

