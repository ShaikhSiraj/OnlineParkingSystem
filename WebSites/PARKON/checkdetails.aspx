<%@ Page Title="" Language="C#" MasterPageFile="~/parkon.master" AutoEventWireup="true" CodeFile="checkdetails.aspx.cs" Inherits="checkdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="Server">
    <html>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center><head><font size="7" face="Calibri"><b>--Check Booking Details--</b></font></head></center>
            <body>
                <form>
                    <fieldset>
                        <legend><font size="5" face="Meiryo UI">Specify your Booking ID provided When Booked--</font></legend>
                        <br />
                        <br />
                        <center><font size="3" ><b>Booking ID  :</b></font>
    <asp:TextBox ID="chebid" runat="server" style="text-transform:uppercase"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="chesubmitbid" runat="server"
        Text="Submit" BackColor="#33CCFF" BorderStyle="Groove" Width="127px" OnClick="button_click" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="chebid" ErrorMessage="Please Enter a valid Booking No" ForeColor="Red"></asp:RequiredFieldValidator>
</center>
                        <br />
                        <br />
                        <br />
                        <center>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"  BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="datasourceofcheckdetails" Width="1000px">
        <Columns>
            <asp:BoundField DataField="booking_no" HeaderText="Booking no" ReadOnly="True" SortExpression="booking_no"  />
            <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
            <asp:BoundField DataField="phone_no" HeaderText="Phone No" SortExpression="phone_no" />
            <asp:BoundField DataField="type_of_vehicle" HeaderText="Type of Vehicle" SortExpression="type_of_vehicle" />
            <asp:BoundField DataField="vehicle_no" HeaderText="Vehicle No" SortExpression="vehicle_no" />
            <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="start_time" HeaderText="Start Time" SortExpression="start_time"  />
            <asp:BoundField DataField="end_time" HeaderText="End Time" SortExpression="end_time"  />
            <asp:BoundField DataField="place" HeaderText="Place" SortExpression="place" />
            <asp:BoundField DataField="location" HeaderText="Location" SortExpression="location" />
            <asp:BoundField DataField="cost" HeaderText="Cost" SortExpression="cost" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"  BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="datasourceforcheckdetailsweekly" Width="1050px">
                    <Columns>
                        <asp:BoundField DataField="booking_no" HeaderText="Booking No" ReadOnly="True" SortExpression="booking_no" />
                        <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                        <asp:BoundField DataField="phone_no" HeaderText="Phone No" SortExpression="phone_no" />
                        <asp:BoundField DataField="type_of_vehicle" HeaderText="Type of Vehicle" SortExpression="type_of_vehicle" />
                        <asp:BoundField DataField="vehicle_no" HeaderText="Vehicle No" SortExpression="vehicle_no" />
                        <asp:BoundField DataField="start_date" HeaderText="Start Date" SortExpression="start_date" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="end_date" HeaderText="End Date" SortExpression="end_date" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="start_time" HeaderText="Start Time" SortExpression="start_time" />
                        <asp:BoundField DataField="end_time" HeaderText="End Time" SortExpression="end_time" />
                        <asp:BoundField DataField="place" HeaderText="Place" SortExpression="place" />
                        <asp:BoundField DataField="location" HeaderText="Location" SortExpression="location" />
                        <asp:BoundField DataField="cost" HeaderText="Cost" SortExpression="cost" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White"  BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="datasourceforcheckdetailsmonthly" Width="1050px">
                    <Columns>
                        <asp:BoundField DataField="booking_no" HeaderText="Booking No" ReadOnly="True" SortExpression="booking_no" />
                        <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                        <asp:BoundField DataField="phone_no" HeaderText="Phone No" SortExpression="phone_no" />
                        <asp:BoundField DataField="type_of_vehicle" HeaderText="Type of Vehicle" SortExpression="type_of_vehicle" />
                        <asp:BoundField DataField="vehicle_no" HeaderText="Vehicle No" SortExpression="vehicle_no" />
                        <asp:BoundField DataField="start_date" HeaderText="Start Date" SortExpression="start_date" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="end_date" HeaderText="End Date" SortExpression="end_date" DataFormatString="{0:dd/MM/yyyy}"/>
                        <asp:BoundField DataField="start_time" HeaderText="Start Time" SortExpression="start_time" />
                        <asp:BoundField DataField="end_time" HeaderText="End Time" SortExpression="end_time" />
                        <asp:BoundField DataField="place" HeaderText="Place" SortExpression="place" />
                        <asp:BoundField DataField="location" HeaderText="Location" SortExpression="location" />
                        <asp:BoundField DataField="cost" HeaderText="Cost" SortExpression="cost" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView><asp:Image ID="norecord" runat="server" ImageUrl="~/Images/no-records1.png" Visible="false"></asp:Image>
                    <asp:SqlDataSource ID="datasourceforcheckdetailsweekly" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [booking_no], [name], [phone_no], [type_of_vehicle], [vehicle_no], [start_date], [end_date], [start_time], [end_time], [place], [location], [cost] FROM [bookingRegistrationWeekly] WHERE ([booking_no] = @booking_no)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="chebid" Name="booking_no" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="datasourceforcheckdetailsmonthly" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [booking_no], [name], [phone_no], [type_of_vehicle], [vehicle_no], [start_date], [end_date], [start_time], [end_time], [place], [location], [cost] FROM [bookingRegistrationMonthly] WHERE ([booking_no] = @booking_no)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="chebid" Name="booking_no" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </center>
                        <br />

                        <asp:SqlDataSource ID="datasourceofcheckdetails" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [booking_no], [name], [phone_no], [type_of_vehicle], [vehicle_no], [date], [start_time], [end_time], [place], [location], [cost] FROM [bookingRegistration] WHERE ([booking_no] = @booking_no)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="chebid" Name="booking_no" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                        <br />


                    </fieldset>
                </form>
        </ContentTemplate>
    </asp:UpdatePanel>

    </body>
    </html>
</asp:Content>

