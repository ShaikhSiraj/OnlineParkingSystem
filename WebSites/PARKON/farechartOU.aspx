<%@ Page Title="" Language="C#" MasterPageFile="~/OUhome.master" AutoEventWireup="true" CodeFile="farechartOU.aspx.cs" Inherits="farechartOU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" Runat="Server">
 <html>
    <center><form><fieldset><head><font size="10" face="Calibri">--FareChart--</font></head></center>
    <br />
    <br />
    <br />
    <br />
    <center>
<table border="5" cellspacing="0" cellpadding="30" style="border-collapse:collapse; border-radius:3px 3px 3px 3px;" >
<tr>
<th><b>Type Of Vehicle</b></th>
<th><b>Daily</b></th>
<th><b>Weekly</b></th>
<th><b>Monthly</b></th>
</tr>
<tr>
<td><b>Two Wheeler</b></td>
<td>Rs.30</td><td>Rs.28</td><td>Rs.27</td>
</tr>
<tr>
<td><b>Three Wheeler</b></td>
<td>Rs.35</td><td>Rs.33</td><td>Rs.32</td>
</tr>
<tr>
<td><b>Four Wheeler</b></td>
<td>Rs.40</td><td>Rs.38</td><td>Rs.37</td>
</tr>

</table><br /><br />
    <font size="4" style="font-family:'Josefin Sans';font-weight:900; ">All Costs are on per Hour basis</font><br /><br />
</center>
    </fieldset></form>
    </html>
</asp:Content>

