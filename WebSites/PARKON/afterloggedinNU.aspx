﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NUhome.master" AutoEventWireup="true" CodeFile="afterloggedinNU.aspx.cs" Inherits="afterloggedinNU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" Runat="Server">
    <html>
    <body >
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate><div id="welcometext">Welcome <asp:Label ID="name" runat="server" Text=""></asp:Label></div>
                    <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick"></asp:Timer>
                    <asp:Image ID="Image1" runat="server" CssClass="slideshow" />
                    <div id="hometext">
                        <font size="9" color="white" style="font-family: 'Global Sans Serif';font-weight:bold">Y</font><font size="6" color="white">ou are </font><font color="black" size="6"> at a place where you </font> <font size="6" color="white"><br />are stress free for</font><font color="black" size="6"> getting a<br /> good </font><font color="white" size="6">parking lot .</font><br />
<br /><p><font size="5" color="white" style="font-family:'MV Boli'">Get your valueable vehicle be Safe and <<br />Secure from our Services provided at<br /> your favourite Parking Place</font> </p>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </body>
    </html>
</asp:Content>

