<%@ Page Title="" Language="C#" MasterPageFile="~/parkon.master" AutoEventWireup="true" CodeFile="example.aspx.cs" Inherits="example" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" Runat="Server">
   <%--<script type="text/javascript">
       function disablebutton() {
           document.getElementById("<%=Button1.ClientID%>").disabled = true;
       } Window.onbeforeunload = disablebutton;
   </script>--%>
    <html>

        <body>hello<asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="this.disabled=true; this.value='Booking...';" UseSubmitBehavior="false" OnClick="butto" /></body>
    </html>
</asp:Content>

