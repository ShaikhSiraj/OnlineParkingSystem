<%@ Page Title="" Language="C#" MasterPageFile="~/OUwithoutanybooking.master" AutoEventWireup="true" CodeFile="historynobooking.aspx.cs" Inherits="historynobooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" Runat="Server">
       <html>
    <center><head><font size="7" face="Calibri"><b>--Know your booking History--</b></font></head></center>
    <body>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <br />
                <br />
                <br />
                <fieldset>
                    <legend><font size="5">Active Bookings</font></legend>
                    <br />
                    <asp:SqlDataSource ID="datasourceforactivemonthly" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [booking_no], [name], [phone_no], [type_of_vehicle], [vehicle_no], [start_date], [end_date], [start_time], [end_time], [place], [location], [cost] FROM [bookingRegistrationMonthly] WHERE ([email] = @email)">
                        <SelectParameters>
                            <asp:SessionParameter Name="email" SessionField="email" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="datasourceforactiveweekly" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [booking_no], [name], [phone_no], [type_of_vehicle], [vehicle_no], [start_date], [end_date], [start_time], [end_time], [place], [location], [cost] FROM [bookingRegistrationWeekly] WHERE ([email] = @email)">
                        <SelectParameters>
                            <asp:SessionParameter Name="email" SessionField="email" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:SqlDataSource ID="datasourceforactivehistory" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [booking_no], [name], [phone_no], [type_of_vehicle], [vehicle_no], [date], [start_time], [end_time], [place], [location], [cost] FROM [bookingRegistration] WHERE ([email] = @email)">
                        <SelectParameters>
                            <asp:SessionParameter Name="email" SessionField="email" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <center><br />
            <asp:GridView ID="dailygridview" runat="server" Caption="Daily"   AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  CellPadding="5" DataSourceID="datasourceforactivehistory" Width="1000px" >
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
            </asp:GridView><br />
            <asp:GridView ID="monthlygridview" runat="server" Caption="Monthly" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="5" DataSourceID="datasourceforactivemonthly" Width="1100px">
                <Columns>
                    <asp:BoundField DataField="booking_no" HeaderText="Booking No" ReadOnly="True" SortExpression="booking_no" />
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="phone_no" HeaderText="Phone No" SortExpression="phone_no" />
                    <asp:BoundField DataField="type_of_vehicle" HeaderText="Type of Vehicle" SortExpression="type_of_vehicle" />
                    <asp:BoundField DataField="vehicle_no" HeaderText="vehicle_no" SortExpression="vehicle_no" />
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
            </asp:GridView><br />
            <asp:GridView ID="weeklygridview" runat="server" Caption="Weekly"  AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="5" DataSourceID="datasourceforactiveweekly" Width="1100px">
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
            </asp:GridView></center>
                    <br />
                    <br />
                    <br />

                </fieldset>
                <fieldset>
                    <legend><font size="5"> Cancelled Bookings</font></legend>
                    <br />
                    <br />
                    <asp:SqlDataSource ID="datasourceforcancelledbookings" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [booking_no], [name], [type_of_vehicle], [vehicle_no], [date], [start_time], [end_time], [place], [location], [cost] FROM [bookingCancelled] WHERE ([email] = @email)">
                        <SelectParameters>
                            <asp:SessionParameter Name="email" SessionField="email" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="datasourceforcancelmonthly" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [booking_no], [name], [phone_no], [type_of_vehicle], [vehicle_no], [start_date], [end_date], [start_time], [end_time], [place], [location], [cost] FROM [bookingCancelledMonthly] WHERE ([email] = @email)">
                        <SelectParameters>
                            <asp:SessionParameter Name="email" SessionField="email" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="datasourceforcancelweekly" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [booking_no], [name], [phone_no], [type_of_vehicle], [vehicle_no], [start_date], [end_date], [start_time], [end_time], [place], [location], [cost] FROM [bookingCancelledWeekly] WHERE ([email] = @email)">
                        <SelectParameters>
                            <asp:SessionParameter Name="email" SessionField="email" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <center>
            <asp:GridView ID="dailycancelgridview" runat="server" Caption="Daily" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="5" DataSourceID="datasourceforcancelledbookings" Width="1000px">
                <Columns>
                    <asp:BoundField DataField="booking_no" HeaderText="Booking No" SortExpression="booking_no" />
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                    <asp:BoundField DataField="type_of_vehicle" HeaderText="Type of Vehicle" SortExpression="type_of_vehicle" />
                    <asp:BoundField DataField="vehicle_no" HeaderText="Vehicle No" SortExpression="vehicle_no" />
                    <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:BoundField DataField="start_time" HeaderText="Start Time" SortExpression="start_time" />
                    <asp:BoundField DataField="end_time" HeaderText="End Time" SortExpression="end_time" />
                    <asp:BoundField DataField="place" HeaderText="PLace" SortExpression="place" />
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
            <asp:GridView ID="monthlycancelgridview" runat="server" Caption="Monthly" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="5" DataSourceID="datasourceforcancelmonthly" Width="1100px">
                <Columns>
                    <asp:BoundField DataField="booking_no" HeaderText="Booking No" SortExpression="booking_no" />
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
            </asp:GridView><br />
            <asp:GridView ID="weeklycancelgridview" runat="server" Caption="Weekly" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="5" DataSourceID="datasourceforcancelweekly" Width="1100px">
                <Columns>
                    <asp:BoundField DataField="booking_no" HeaderText="Booking No" SortExpression="booking_no" />
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
            </asp:GridView></center>
                    <br />
                    <br />
                    <br />
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </body>
    </html>
</asp:Content>

