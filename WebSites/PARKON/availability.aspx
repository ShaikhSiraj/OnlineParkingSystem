<%@ Page Title="" Language="C#" MasterPageFile="~/parkon.master" AutoEventWireup="true" CodeFile="availability.aspx.cs" Inherits="availability" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="Server">
    <html>
    <title>Availability</title>
    <body>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <form>
                    <fieldset>
                        <legend><font size="7" face="Calibri"><b>Check Availability---></b></font></legend>
                        <table border="0" cellspacing="15">
                            <tr>
                                <td><b>Date  </b></td>
                                <td>
                                    <asp:TextBox ID="availtext" runat="server" AutoPostBack="true" OnTextChanged="availtext_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="daterf" runat="server" ControlToValidate="availtext" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:RadioButton ID="daily" Text="Daily" runat="server" GroupName="plan" OnCheckedChanged="radiobutton_checked" AutoPostBack="true" /><br />
                                    <br />
                                    <asp:RadioButton ID="monthly" Text="Monthly" runat="server" GroupName="plan" OnCheckedChanged="radiobutton_checked" AutoPostBack="true" /><br />
                                    <br />
                                    <asp:RadioButton ID="weekly" Text="Weekly" runat="server" GroupName="plan" OnCheckedChanged="radiobutton_checked" AutoPostBack="true" /></td>
                                <td>
                                    <asp:Button ID="checkavailability" runat="server" Text="Check"  Width="140px" Height="30px" BackColor="#33CCFF" OnClick="checkavailability_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td><b>Place   </b>
                                    <asp:DropDownList ID="selectplace" runat="server" OnSelectedIndexChanged="selectplace_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="selectplacerf0" runat="server" ControlToValidate="selectplace" ErrorMessage="*" ForeColor="#FF3300" InitialValue="Select Place"></asp:RequiredFieldValidator>
                                    <asp:SqlDataSource ID="placeObjects" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [placeObjects]"></asp:SqlDataSource>
                                    <asp:SqlDataSource ID="placeHoteldatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Hotel] FROM [parkingspaceHotel]"></asp:SqlDataSource>
                                    <asp:SqlDataSource ID="placeMalldatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Mall] FROM [parkingspaceMall]"></asp:SqlDataSource>
                                    <asp:SqlDataSource ID="placeAirportdatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Airport] FROM [parkingspaceAirport]"></asp:SqlDataSource>
                                    <asp:SqlDataSource ID="placeRailwaystationdatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Railway Station] AS Railway_Station FROM [parkingspaceRailwaystation]"></asp:SqlDataSource>

                                    <asp:SqlDataSource ID="placeObjectsfulldatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [placeObjectsMW] FROM [placeObjectsFull]"></asp:SqlDataSource>
                                    <asp:SqlDataSource ID="placeLocaldatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Local Place] AS Local_Place FROM [parkingspaceLocal]"></asp:SqlDataSource>
                                </td>
                                <td>
                                    <asp:DropDownList ID="actualplace" AutoPostBack="true" runat="server" Visible="false" Width="250px" OnSelectedIndexChanged="actualplace_SelectedIndexChanged"></asp:DropDownList>
                                    
                                </td>

                                <td>
                                    <asp:Label ID="availerror" runat="server" ForeColor="Red"></asp:Label></td>

                            </tr>
                        </table>
                    </fieldset>
                    <center>
            <asp:Image ID="bookingfullimage" runat="server" Visible="false" ImageUrl="~/Images/Sorry-We-re-Fully-Booked_300pix.jpg" />
                <asp:Image ID="availableimage" runat="server" Visible="false" ImageUrl="~/Images/available-sign.jpg" Height="109px" Width="404px"></asp:Image><br /><br />
                <font size="5" face="MS Sans Serif"><b><asp:Label ID="acknoledgement" runat="server" Text=""></asp:Label></b></font>
            </center>
                </form>
            </ContentTemplate>
        </asp:UpdatePanel>

    </body>
    </html>
</asp:Content>

