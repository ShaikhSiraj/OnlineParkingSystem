<%@ Page Title="" Language="C#" MasterPageFile="~/OUwithoutanybooking.master" AutoEventWireup="true" CodeFile="paymentOUnobooking.aspx.cs" Inherits="paymentOUnobooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" Runat="Server">
    <html>
<head><center><font size="7" face="Calibri">--Payment Details--</font></head></center><asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <body>
<form><fieldset><legend>Fill Your Payment Details Here--></legend>
<table border="0" cellspacing="25">
<tr>
<td>
    <asp:DropDownList ID="typeofvehicle" runat="server">
        <asp:ListItem>Credit Card</asp:ListItem>
        <asp:ListItem>Debit Card</asp:ListItem>
        <asp:ListItem>ATM Card</asp:ListItem>
        <asp:ListItem>Net Banking</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
<tr>
<td>

<b>Card NO.</b>
<asp:TextBox ID="paycardno" runat="server" Width="180px" AutoPostBack="true" OnTextChanged="notempty" ></asp:TextBox></td>
<td><b>Month</b>
<asp:TextBox ID="paymonth" runat="server" AutoPostBack="true" OnTextChanged="notempty"></asp:TextBox></td>
</tr>
<tr><td></td>

<td><b>Year</b>
    <asp:TextBox ID="payyear" runat="server" AutoPostBack="true" OnTextChanged="notempty"></asp:TextBox></td>
</tr>
<tr><td><b>CVV/Security Code</b>
    <asp:TextBox ID="paycvv" runat="server" AutoPostBack="true" OnTextChanged="notempty"></asp:TextBox></td><td>
        <asp:Label ID="cash" runat="server" Text=""></asp:Label></td></tr>
    <tr><td><b>( Please confirm all Your Details Before Payment!!! )</b></td><td>
        <asp:Button ID="paynow" runat="server" Text="PayNow" BackColor="#66CCFF" 
            Height="30px" Width="127px" OnClientClick="this.disabled=true; this.value='Please Wait...';" UseSubmitBehavior="false" onclick="paynow_Click"  /></td></tr>
</table>
</fieldset>
</form>
</body>
        </ContentTemplate>
    </asp:UpdatePanel>

</html>
</asp:Content>


