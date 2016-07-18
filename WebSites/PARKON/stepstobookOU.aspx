<%@ Page Title="" Language="C#" MasterPageFile="~/OUhome.master" AutoEventWireup="true" CodeFile="stepstobookOU.aspx.cs" Inherits="stepstobookOU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" Runat="Server">
      <html>
    <body>
        <br />
        <div id="steps" style="width: 1000px">
            <h2>
                <img src="Images/hashtag2.png" height="70px" width="70px" />
                <font face="Champagne & Limousines">In Four simple Steps you can book your parking space</font>
            </h2>
            <br />
            <br />

            <img src="Images/step1.png" height="50px" width="50px" />
            <font face="Champagne & Limousines" size="5"><b>Firstly,Login or Sign UP ......</b></font>
            <br />
            <center><a href="wlc.aspx"><img id="stepimg" src="Images/register-icon-blue.png" style="border-style:none" /></a></center>
            <br />
            <img src="Images/step2.png" height="50px" width="50px" />
            <font face="Champagne & Limousines" size="5"><b>Now, Go to booking page and fill your booking details ....</b></font>
            <br />
            <br />
            <center><a href="bookingNU.aspx"><img id="stepimg" src="Images/fill_form.png" height="228px" width="230px" style="border:none"/></a></center>
            <br />
            <img src="Images/step3.png" height="50px" width="50px" />
            <font face="Champagne & Limousines" size="5"><b>Get your Booking No ....</b></font>
            <br />
            <center><img src="Images/tickets-icon-blue.png" height="228px" width="230px" /></center>
            <br />
            <img src="Images/step4.png" height="50px" width="50px" />
            <font face="Champagne & Limousines" size="5"><b>On your booked date Produce Your Booking No and Park on your place ..... </b></font>
            <br />
            <br />
            <center><img id="stepimg" src="Images/ParkReserve.jpg" height="228px" width="270px" style="border:none" </center>
            <br />
            <br />
        </div>
    </body>
    </html>
</asp:Content>

