<%@ Page Title="" Language="C#" MasterPageFile="~/afterloggedinOU.master" AutoEventWireup="true" CodeFile="cancelbooking.aspx.cs" Inherits="cancelbooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" Runat="Server">
   <html>
<center><head><font size="7" face="Calibri"><b>Cancel Booking</b></font></head></center>
<body>
<fieldset><legend><font size="5" face="Meiryo UI">Specify your Booking ID provided When Booked--</font></legend>
<br />
<br />
<center><font size="3" ><b>Booking No :&nbsp;&nbsp;&nbsp; </b></font><asp:TextBox ID="cbid" runat="server"  style="text-transform:uppercase;" ></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="submitbid" runat="server" 
        Text="Submit" BackColor="#33CCFF" BorderStyle="Groove" OnClick="submitclick" Width="130px" /><br /><br /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter valid Booking No" ControlToValidate="cbid" ForeColor="Red"></asp:RequiredFieldValidator>
</center>
<br /><br /><center><asp:Image ID="warningimage" ImageUrl="~/Images/warning-sign.png" runat="server" Visible="false" Height="85px" Width="94px"></asp:Image><font size="3"><asp:Label ID="unsuccessfulcancelmsg" runat="server"  Text=""></asp:Label></font><asp:Image ID="cancelledimage" ImageUrl="~/Images/Cancelled-Sign.png" runat="server" Visible="false" Height="95px" Width="290px"></asp:Image><br /><b><font size="5" family="sans-serif " ><asp:Label ID="successfulcancelmsg" runat="server" Text=""></asp:Label></b></font><br />
   <asp:Image ID="norecord" runat="server" ImageUrl="~/Images/no-records1.png" Visible="false"></asp:Image>
     </center>
    <br /><br />
    
<center>
    <asp:SqlDataSource ID="datasourceforcancelbooking" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [booking_no], [name], [phone_no], [type_of_vehicle], [vehicle_no], [date], [start_time], [end_time], [place], [location] FROM [bookingRegistration] WHERE ([booking_no] = @booking_no)">
        <SelectParameters>
            <asp:ControlParameter ControlID="cbid" Name="booking_no" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="dailygridview" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="datasourceforcancelbooking" Width="1000px" >
        <Columns>
            <asp:BoundField DataField="booking_no" HeaderText="Booking No" ReadOnly="True" SortExpression="booking_no" />
            <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
            <asp:BoundField DataField="phone_no" HeaderText="Phone No" SortExpression="phone_no" />
            <asp:BoundField DataField="type_of_vehicle" HeaderText="Type of Vehicle" SortExpression="type_of_vehicle" />
            <asp:BoundField DataField="vehicle_no" HeaderText="Vehicle No" SortExpression="vehicle_no" />
            <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="start_time" HeaderText="Start Time" SortExpression="start_time" />
            <asp:BoundField DataField="end_time" HeaderText="End Time" SortExpression="end_time" />
            <asp:BoundField DataField="place" HeaderText="Place" SortExpression="place" />
            <asp:BoundField DataField="location" HeaderText="Location" SortExpression="location" />
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
    <asp:GridView ID="monthlygridview" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="datasourceforcancelbookingmonthly" Width="1100px">
        <Columns>
            <asp:BoundField DataField="booking_no" HeaderText="Booking No" ReadOnly="True" SortExpression="booking_no" />
            <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
            <asp:BoundField DataField="phone_no" HeaderText="Phone No" SortExpression="phone_no" />
            <asp:BoundField DataField="type_of_vehicle" HeaderText="Type of Vehicle" SortExpression="type_of_vehicle" />
            <asp:BoundField DataField="vehicle_no" HeaderText="Vehicle No" SortExpression="vehicle_no" />
            <asp:BoundField DataField="start_date" HeaderText="Start Date" SortExpression="start_date" DataFormatString="{0:dd/MM/yyyy}"/>
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
    </asp:GridView><br />
    <asp:GridView ID="weeklygridview" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="datasourceforcancelbookingweekly" Width="1100px">
        <Columns>
            <asp:BoundField DataField="booking_no" HeaderText="Booking No" ReadOnly="True" SortExpression="booking_no" />
            <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
            <asp:BoundField DataField="phone_no" HeaderText="Phone No" SortExpression="phone_no" />
            <asp:BoundField DataField="type_of_vehicle" HeaderText="Type of Vehicle" SortExpression="type_of_vehicle" />
            <asp:BoundField DataField="vehicle_no" HeaderText="Vehicle No" SortExpression="vehicle_no" />
            <asp:BoundField DataField="start_date" HeaderText="Start Date" SortExpression="start_date" DataFormatString="{0:dd/MM/yyyy}"/>
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
    </asp:GridView>
<br />
    <asp:Button ID="cbcancel" runat="server" Text="Cancel" OnClientClick="this.disabled=true; this.value='Please Wait...';" UseSubmitBehavior="false" BackColor="LightSkyBlue"
        Height="30px" Width="127px" onclick="cbcancel_click" Visible="false" />
    <asp:SqlDataSource ID="datasourceforcancelbookingmonthly" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [booking_no], [name], [phone_no], [type_of_vehicle], [vehicle_no], [start_date], [end_date], [start_time], [end_time], [place], [location], [cost] FROM [bookingRegistrationMonthly] WHERE ([booking_no] = @booking_no)">
        <SelectParameters>
            <asp:ControlParameter ControlID="cbid" Name="booking_no" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="datasourceforcancelbookingweekly" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [booking_no], [name], [phone_no], [type_of_vehicle], [vehicle_no], [start_date], [end_date], [start_time], [end_time], [place], [location], [cost] FROM [bookingRegistrationWeekly] WHERE ([booking_no] = @booking_no)">
        <SelectParameters>
            <asp:ControlParameter ControlID="cbid" Name="booking_no" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    </center>

   
    </font>

   
</fieldset>
</body>
</html>
</asp:Content>

