<%@ Page Title="" Language="C#" MasterPageFile="~/wbcbl.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" Runat="Server">
     <html><body><center>
        <head><font size="7" face="New Times Roman">Sign UP</font></head></center>
        <br /><br /><br />
        <form><fieldset>
<table border="0" cellspacing="15">
<tr>
<td class="auto-style1"><b>Name    </b><asp:TextBox runat="server"  ID="rename" MaxLength="20" autocomplete="off"></asp:TextBox></td>
<td><b>Email    </b><asp:TextBox runat="server"  ID="reemail"  MaxLength="20" 
        Width="179px" autocomplete="off"></asp:TextBox></td></tr>

<tr>
<td class="auto-style1"><b>Password    <asp:TextBox runat="server"  ID="repass"  MaxLength="15" 
        TextMode="Password"></asp:TextBox></td>
<td><b>Confirm Password    </b><asp:TextBox runat="server"  ID="recompass" 
       MaxLength="15" TextMode="Password"></asp:TextBox></td></tr>
    <tr><td>
        <asp:Label ID="reerror" runat="server" ForeColor="Red"></asp:Label>
        </td>
<td>
    <asp:Button runat="server" Text="Register" ID="register1"
        OnClick="register1_Click" OnClientClick="afterloggedinNU.aspx"
        BackColor="#3399FF" TabIndex="1" Width="127px" Height="30px" /></td>
</tr>
</table></fieldset></form>
        </body></html>
</asp:Content>

