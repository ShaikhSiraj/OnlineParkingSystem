<%@ Page Title="" Language="C#" MasterPageFile="~/afterloggedinNU.master" EnableEventValidation="true" AutoEventWireup="true" CodeFile="usersettingsNU.aspx.cs" Inherits="usersettingsNU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" Runat="Server">
     <html>
    <body>

        <fieldset>
            <legend><font size="5" face="Calibri">Change Your Password--></font></legend>
            <table border="0" cellspacing="25">
                <tr>
                    <td>
                        <b>Old Password</b></td>
                    <td>
                        <asp:TextBox ID="usoldpass" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="usoldpass" ErrorMessage="*" ForeColor="Red" ValidationGroup="password"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><b>New Password</b></td>
                    <td>
                        <asp:TextBox ID="usnewpass" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="usnewpass" ErrorMessage="*" ForeColor="Red" ValidationGroup="password"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td><b>Confirm Password</b></td>
                    <td>
                        <asp:TextBox ID="usconnewpass" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="usconnewpass" ForeColor="Red" ValidationGroup="password"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="usnewpass" ControlToValidate="usconnewpass" ErrorMessage="Password Not Matching" ForeColor="Red" ValidationGroup="password"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="uspass" runat="server" Text="Change Password"
                            BackColor="#66CCFF" BorderStyle="Groove" ValidationGroup="password" OnClick="uspass_Click" Style="margin-top: 0px" />

                    </td>
                    <td>
                        <asp:Label ID="usperror" runat="server" Text="" ForeColor="Red"></asp:Label></td>

                </tr>
            </table>


        </fieldset>
        <br />
        <br />
        <br />
        <br />
        <fieldset>
            <legend><font size="5" face="Calibri">Change Your Name--></font></legend>
            <table border="0" cellspacing="25">
                <tr>
                    <td>
                        <b>Current Name</b></td>
                    <td>
                        <asp:TextBox ID="usemailold" runat="server" autocomplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="name" ControlToValidate="usemailold"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><b>New Name </b></td>
                    <td>
                        <asp:TextBox ID="usemailnew" runat="server" autocomplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="name" ControlToValidate="usemailnew"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="usemail" runat="server" Text="Change Name" BackColor="#66CCFF"
                            BorderStyle="Groove" ValidationGroup="name" UseSubmitBehavior="True" OnClick="usemail_Click" /></td>
                    <td>
                        <asp:Label ID="useerror" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>


    </body>
    </html>
</asp:Content>

