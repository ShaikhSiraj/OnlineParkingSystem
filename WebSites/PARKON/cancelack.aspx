<%@ Page Title="" Language="C#" MasterPageFile="~/OUwithoutanybooking.master" AutoEventWireup="true" CodeFile="cancelack.aspx.cs" Inherits="historyack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" Runat="Server">
<html><head><center><font size="7" face="Calibri"><b>Cancel Booking</b></font></center></head>
    <body>
        <br /><br /><center> <asp:Image ID="cancelledimage" ImageUrl="~/Images/Cancelled-Sign.png" runat="server" Height="69px" Width="263px" /></center>
       
        <br />
       <center><font size="3" ><asp:Label ID="Label1" runat="server" Text="" ></asp:Label></font>&nbsp;&nbsp<font size="5"><asp:Label ID="Label2" runat="server" Text="" Font-Bold="true" style="text-transform:uppercase"></asp:Label></font>
           <br /><br /><br /><br /><br /><br /><br />
         <table border="0"><tr><td> <asp:Button ID="home" runat="server" Text="Home" BackColor="#0099FF" Height="30px" Width="140px" OnClick="home_Click"></asp:Button></td>
             <td></td>
             <td><asp:Button ID="book" runat="server" Text="Book" Height="30px" Width="140px" BackColor="#DCC83D" OnClick="book_Click"></asp:Button></td>
                           </tr>
            

         
           </table>
       </center><br />
    </body> 
    
</html>
</asp:Content>

