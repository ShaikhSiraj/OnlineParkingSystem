<%@ Page Title="" Language="C#" MasterPageFile="~/afterloggedinOU.master" AutoEventWireup="true" CodeFile="afterpaymentOU+NU.aspx.cs" Inherits="afterpaymentOU_NU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
    Park On
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="Server">
    <html>
    <center><head><font size="7" face="Calibri"><b>Tansaction Successfull------!</b></font></head></center>
    <body>
        <fieldset>
            <br />
            <br />
            <br />
            <br />
            <font size="5" face="Meiryo UI">Your Booking Number is :</font>&nbsp;&nbsp<font size="7"><asp:Label ID="bookingid"
    runat="server" Font-Bold="True" Height="54px" Width="232px"></asp:Label></font>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <font size="5"><b>NOTE:Please Preserve this BookingNumber </b></font>

            <center>
        <asp:Button ID="afpayhome" runat="server" Text="Home" BackColor="#33CCFF" 
            Height="30px"  Width="140px" OnClick="afpayhome_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="afpaybook" runat="server" Text="Book" BackColor="#FF9900" 
            Height="30px"  Width="140px" OnClick="afpaybook_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="afresendemail" runat="server" Text="Resend Email" Width="140px" Height="30px" BackColor="#E9B6BE" OnClick="afresendemail_Click" />
                <asp:Label ID="emailtext" runat="server" Text=""></asp:Label>
   </center>
        </fieldset>
    </body>
    </html>
</asp:Content>

