<%@ Page Title="" Language="C#" MasterPageFile="~/afterloggedinOU.master" AutoEventWireup="true" CodeFile="bookingOU.aspx.cs" Inherits="bookingOU" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="Server">

    <html>
    <title>ParkingForm</title>
    <head>
        <center><font size="5" face="Calibri">---Book Here---</font></center>
    </head>
    <body>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <form>
                    <fieldset>
                        <legend><font face="Meiryo UI"><b>Fill Your Details Here....</b></font></legend>
                        <table border="0" cellspacing="15">
                            <tr>
                                <td class="auto-style3"><b>Name  </b></td>
                                <td>
                                    <asp:TextBox ID="bname" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="namerf" runat="server" ControlToValidate="bname" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                                <td><b>Phone No.</b></td>
                                <td>
                                    <asp:TextBox ID="bphone" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="phonerf" runat="server" ErrorMessage="*" ForeColor="#FF3300" ControlToValidate="bphone"></asp:RequiredFieldValidator>
                                </td>
                                <td><b>Select Plan </b>
                                    <br />
                                    <asp:RadioButton ID="monthly" runat="server" Text="Monthly" AutoPostBack="True" GroupName="plan" OnCheckedChanged="radiobutton_checked" />
                                </td>
                                <td>
                                    <br />
                                    <asp:RadioButton ID="weekly" runat="server" Text="Weekly" AutoPostBack="True" GroupName="plan" OnCheckedChanged="radiobutton_checked" /></td>
                                <td>
                                    <br />
                                    <asp:RadioButton ID="daily" runat="server" Text="Daily" AutoPostBack="True" GroupName="plan" OnCheckedChanged="radiobutton_checked" />
                                    <asp:CustomValidator ID="plancv" runat="server" ErrorMessage="*" ForeColor="Red"></asp:CustomValidator>
                                </td>
                            </tr>
                            <caption>
                                <br />
                                <tr>
                                    <td class="auto-style3"><b>Type Of Vehicle </b></td>
                                    <td>
                                        <asp:DropDownList ID="typeofvehicle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="typeofvehicle_SelectedIndexChanged">
                                            <asp:ListItem Value="twowheeler">Two Wheeler</asp:ListItem>
                                            <asp:ListItem Value="threewheeler">Three Wheeler</asp:ListItem>
                                            <asp:ListItem Value="fourwheeler">Four Wheeler</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td><b>Vehicle No.</b></td>
                                    <td>
                                        <asp:TextBox ID="bvhno1" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="vhnorf" runat="server" ControlToValidate="bvhno1" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                        <br />
                                    </td>
                                    <td><b>Select Place</b></td>
                                    <td>
                                        <asp:DropDownList ID="selectplace" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selectplace_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="selectplacerf" runat="server" ControlToValidate="selectplace" ErrorMessage="*" ForeColor="#FF3300" InitialValue="Select Place"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="actualplace" AutoPostBack="true" runat="server" Visible="false" Width="250px" OnSelectedIndexChanged="actualplace_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style3"><b>Date </b></td>
                                    <td>
                                        <asp:TextBox ID="bdate" runat="server" AutoPostBack="true" OnTextChanged="bdate_TextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="daterf" runat="server" ControlToValidate="bdate" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>To</td>
                                    <td>
                                        <asp:TextBox ID="bedate" runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td><b>Start Time
                                <br />
                                        <asp:DropDownList ID="shrs" runat="server" AutoPostBack="true" Height="17px" OnTextChanged="itemselected" Width="77px">
                                            <asp:ListItem Value="0">12 AM</asp:ListItem>
                                            <asp:ListItem Value="1">01 AM</asp:ListItem>
                                            <asp:ListItem Value="2">02 AM</asp:ListItem>
                                            <asp:ListItem Value="3">03 AM</asp:ListItem>
                                            <asp:ListItem Value="4">04 AM</asp:ListItem>
                                            <asp:ListItem Value="5">05 AM</asp:ListItem>
                                            <asp:ListItem Value="6">06 AM</asp:ListItem>
                                            <asp:ListItem Value="7">07 AM</asp:ListItem>
                                            <asp:ListItem Value="8">08 AM</asp:ListItem>
                                            <asp:ListItem Value="9">09 AM</asp:ListItem>
                                            <asp:ListItem Value="10">10 AM</asp:ListItem>
                                            <asp:ListItem Value="11">11 AM</asp:ListItem>
                                            <asp:ListItem Value="12">12 PM</asp:ListItem>
                                            <asp:ListItem Value="13">01 PM</asp:ListItem>
                                            <asp:ListItem Value="14">02 PM</asp:ListItem>
                                            <asp:ListItem Value="15">03 PM</asp:ListItem>
                                            <asp:ListItem Value="16">04 PM</asp:ListItem>
                                            <asp:ListItem Value="17">05 PM</asp:ListItem>
                                            <asp:ListItem Value="18">06 PM</asp:ListItem>
                                            <asp:ListItem Value="19">07 PM</asp:ListItem>
                                            <asp:ListItem Value="20">08 PM</asp:ListItem>
                                            <asp:ListItem Value="21">09 PM</asp:ListItem>
                                            <asp:ListItem Value="22">10 PM</asp:ListItem>
                                            <asp:ListItem Value="23">11 PM</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                <asp:DropDownList ID="smin" runat="server" AutoPostBack="true" Height="16px" OnTextChanged="itemselected" Width="49px">
                                    <asp:ListItem>00</asp:ListItem>
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                    <asp:ListItem>24</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>26</asp:ListItem>
                                    <asp:ListItem>27</asp:ListItem>
                                    <asp:ListItem>28</asp:ListItem>
                                    <asp:ListItem>29</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>31</asp:ListItem>
                                    <asp:ListItem>33</asp:ListItem>
                                    <asp:ListItem>34</asp:ListItem>
                                    <asp:ListItem>35</asp:ListItem>
                                    <asp:ListItem>36</asp:ListItem>
                                    <asp:ListItem>37</asp:ListItem>
                                    <asp:ListItem>38</asp:ListItem>
                                    <asp:ListItem>39</asp:ListItem>
                                    <asp:ListItem>40</asp:ListItem>
                                    <asp:ListItem>41</asp:ListItem>
                                    <asp:ListItem>42</asp:ListItem>
                                    <asp:ListItem>43</asp:ListItem>
                                    <asp:ListItem>44</asp:ListItem>
                                    <asp:ListItem>45</asp:ListItem>
                                    <asp:ListItem>46</asp:ListItem>
                                    <asp:ListItem>47</asp:ListItem>
                                    <asp:ListItem>48</asp:ListItem>
                                    <asp:ListItem>49</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>51</asp:ListItem>
                                    <asp:ListItem>52</asp:ListItem>
                                    <asp:ListItem>53</asp:ListItem>
                                    <asp:ListItem>54</asp:ListItem>
                                    <asp:ListItem>55</asp:ListItem>
                                    <asp:ListItem>56</asp:ListItem>
                                    <asp:ListItem>57</asp:ListItem>
                                    <asp:ListItem>58</asp:ListItem>
                                    <asp:ListItem>59</asp:ListItem>
                                </asp:DropDownList>
                                    </b></td>
                                    <td><b>End Time<br />
                                        <asp:DropDownList ID="ehrs" runat="server" AutoPostBack="true" Height="19px" OnTextChanged="itemselected" Width="77px">
                                            <asp:ListItem Value="0">12 AM</asp:ListItem>
                                            <asp:ListItem Value="1">01 AM</asp:ListItem>
                                            <asp:ListItem Value="2">02 AM</asp:ListItem>
                                            <asp:ListItem Value="3">03 AM</asp:ListItem>
                                            <asp:ListItem Value="4">04 AM</asp:ListItem>
                                            <asp:ListItem Value="5">05 AM</asp:ListItem>
                                            <asp:ListItem Value="6">06 AM</asp:ListItem>
                                            <asp:ListItem Value="7">07 AM</asp:ListItem>
                                            <asp:ListItem Value="8">08 AM</asp:ListItem>
                                            <asp:ListItem Value="9">09 AM</asp:ListItem>
                                            <asp:ListItem Value="10">10 AM</asp:ListItem>
                                            <asp:ListItem Value="11">11 AM</asp:ListItem>
                                            <asp:ListItem Value="12">12 PM</asp:ListItem>
                                            <asp:ListItem Value="13">01 PM</asp:ListItem>
                                            <asp:ListItem Value="14">02 PM</asp:ListItem>
                                            <asp:ListItem Value="15">03 PM</asp:ListItem>
                                            <asp:ListItem Value="16">04 PM</asp:ListItem>
                                            <asp:ListItem Value="17">05 PM</asp:ListItem>
                                            <asp:ListItem Value="18">06 PM</asp:ListItem>
                                            <asp:ListItem Value="19">07 PM</asp:ListItem>
                                            <asp:ListItem Value="20">08 PM</asp:ListItem>
                                            <asp:ListItem Value="21">09 PM</asp:ListItem>
                                            <asp:ListItem Value="22">10 PM</asp:ListItem>
                                            <asp:ListItem Value="23">11 PM</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                <asp:DropDownList ID="emin" runat="server" AutoPostBack="true" Height="16px" OnTextChanged="itemselected" Width="54px">
                                    <asp:ListItem>00</asp:ListItem>
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                    <asp:ListItem>24</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>26</asp:ListItem>
                                    <asp:ListItem>27</asp:ListItem>
                                    <asp:ListItem>28</asp:ListItem>
                                    <asp:ListItem>29</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>31</asp:ListItem>
                                    <asp:ListItem>33</asp:ListItem>
                                    <asp:ListItem>34</asp:ListItem>
                                    <asp:ListItem>35</asp:ListItem>
                                    <asp:ListItem>36</asp:ListItem>
                                    <asp:ListItem>37</asp:ListItem>
                                    <asp:ListItem>38</asp:ListItem>
                                    <asp:ListItem>39</asp:ListItem>
                                    <asp:ListItem>40</asp:ListItem>
                                    <asp:ListItem>41</asp:ListItem>
                                    <asp:ListItem>42</asp:ListItem>
                                    <asp:ListItem>43</asp:ListItem>
                                    <asp:ListItem>44</asp:ListItem>
                                    <asp:ListItem>45</asp:ListItem>
                                    <asp:ListItem>46</asp:ListItem>
                                    <asp:ListItem>47</asp:ListItem>
                                    <asp:ListItem>48</asp:ListItem>
                                    <asp:ListItem>49</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>51</asp:ListItem>
                                    <asp:ListItem>52</asp:ListItem>
                                    <asp:ListItem>53</asp:ListItem>
                                    <asp:ListItem>54</asp:ListItem>
                                    <asp:ListItem>55</asp:ListItem>
                                    <asp:ListItem>56</asp:ListItem>
                                    <asp:ListItem>57</asp:ListItem>
                                    <asp:ListItem>58</asp:ListItem>
                                    <asp:ListItem>59</asp:ListItem>
                                </asp:DropDownList>
                                    </b></td>
                                    <td>
                                        <asp:Label ID="hours" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2"></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td class="auto-style1">
                                        <asp:Label ID="berror" runat="server" ForeColor="Red"></asp:Label>
                                        <asp:Label ID="b2error" runat="server" ForeColor="#FF3300"></asp:Label>
                                        <asp:SqlDataSource ID="placeObjects" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [placeObjects]"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="placeHoteldatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Hotel] FROM [parkingspaceHotel]"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="placeMalldatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Mall] FROM [parkingspaceMall]"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="placeAirportdatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Airport] FROM [parkingspaceAirport]"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="placeRailwaystationdatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Railway Station] AS Railway_Station FROM [parkingspaceRailwaystation]"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="placeLocaldatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Local Place] AS Local_Place FROM [parkingspaceLocal]"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="placeObjectsfulldatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [placeObjectsMW] FROM [placeObjectsFull]"></asp:SqlDataSource>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="auto-style2"></td>
                                    <td align="center">
                                        <asp:Button ID="bbook" runat="server" BackColor="#3399FF" BorderStyle="Groove" Height="30px" OnClick="bbook_Click" Text="Book" Width="127px" /></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="bphone" Display="Dynamic" ErrorMessage="Phone No not Proper" ForeColor="Red" ValidationExpression="^[0-9]\d{9}$"></asp:RegularExpressionValidator>

                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="bvhno1" Display="Dynamic" ErrorMessage="Invalid Vehicle No" ForeColor="Red" ValidationExpression="^[a-zA-z]{2}\d{2}[a-zA-Z]{2}\d{4}"></asp:RegularExpressionValidator></td>
                    </fieldset>
                    </td>
                        </tr>
                    </caption>
                </table>
               
            <center>
            <asp:Image ID="bookingfullimage" Visible="false" ImageUrl="~/Images/Sorry-We-re-Fully-Booked_300pix.jpg" runat="server" /></center>
                    <font size="3" face="Calibri"><b><u>Note :</u>All booking should be done 15 Minutes before from their respective time.</b></font>
                </form>
            </ContentTemplate>
        </asp:UpdatePanel>

    </body>
    </html>
</asp:Content>


