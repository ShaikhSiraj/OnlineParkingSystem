<%@ Page Title="" Language="C#" MasterPageFile="~/wbcbl.master" AutoEventWireup="true" CodeFile="wlc.aspx.cs" Inherits="wlc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="Server">
    <html>
    <body>
       
                <center><head><font size="7" face="New Times Roman">Welcome</font></head></center>


                <br />
                <fieldset>
                    <legend><font size="5">Login</font></legend>
                    <table border="0" cellspacing="15">
                        <tr>
                            <td align="left"><b>Email&nbsp; ID</b>
                                <asp:TextBox runat="server" ID="loemail" MaxLength="50" autocomplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="loemail" ErrorMessage="*" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>

                            </td>
                            <td align="left"><b>Password   </b>
                                <asp:TextBox runat="server" ID="lopass"
                                    MaxLength="50" TextMode="Password" autocomplete="off"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lopass" ErrorMessage="*" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>

                            </td>
                            <td></td>
                            <td>
                                <asp:Button runat="server" Text="Login" ID="login" OnClick="login_Click"
                                    BackColor="#3399FF" Height="30px" Width="127px" ValidationGroup="login" /></td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="forgot">Forgot Password ?</asp:LinkButton>
                                <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Height="123px" Width="274px" Visible="false">
                                    <br />
                                    <center><b>Email ID</b> 
                                        <asp:TextBox runat="server" id="forgotpasstext" OnTextChanged="forgotpasstext_TextChanged" AutoPostBack="true"></asp:TextBox><asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="forgotpasstext" ForeColor="#FF3300" ></asp:RequiredFieldValidator><br /><asp:RegularExpressionValidator runat="server" ErrorMessage="Email Not Proper" ControlToValidate="forgotpasstext" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br /><br />
                                        <asp:Button runat="server" Text="Send" Width="100px" OnClick="Unnamed2_Click"></asp:Button><br />
                                        <asp:Label ID="ferror" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </center>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="loerror" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="loemail" ErrorMessage="Email ID Not Proper" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="login"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <br />
                <br />
                <center><font size="5" face="Calibri">OR</font> <br /><br /><br /><br /></center>
                <fieldset>
                    <legend><font size="5" face="New Times Roman">Sign UP</font></legend>
                    <table border="0" cellspacing="15">
                        <tr>
                            <td><b>Full Name    </b></td>
                            <td>
                                <asp:TextBox runat="server" ID="rename" MaxLength="50" autocomplete="off" Width="175px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rename" ErrorMessage="*" ForeColor="Red" ValidationGroup="register"></asp:RequiredFieldValidator>
                            </td>
                            <td><b>Email    ID</b></td>
                            <td>
                                <asp:TextBox runat="server" ID="reemail" MaxLength="50"
                                    Width="175px" autocomplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="reemail" ForeColor="Red" ValidationGroup="register"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Email ID Not Proper" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="reemail" ForeColor="Red" ValidationGroup="register"></asp:RegularExpressionValidator>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </td>
                            </td>
                        </tr>

                        <tr>
                            <td><b>Password    </b></td>
                            <td>
                                <asp:TextBox runat="server" ID="repass" MaxLength="50"
                                    TextMode="Password" Width="175px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="repass" ValidationGroup="register"></asp:RequiredFieldValidator>
                            </td>
                            <td><b>Confirm Password   </b></td>
                            <td>
                                <asp:TextBox runat="server" ID="reconpass"
                                    MaxLength="50" TextMode="Password" Width="175px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="reconpass" ErrorMessage="*" ForeColor="Red" ValidationGroup="register"></asp:RequiredFieldValidator></td>

                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Password should be more than 8 charaters" ValidationExpression="^.{8,}$" ForeColor="Red" ControlToValidate="repass" ValidationGroup="register"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password not matched" ControlToValidate="reconpass" ControlToCompare="repass" ForeColor="Red"></asp:CompareValidator>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="reerror" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td>
                                <asp:Button runat="server" Text="Register" ID="register1"
                                    BackColor="#3399FF" TabIndex="1" Width="127px" Height="30px" OnClick="register1_Click" ValidationGroup="register" /></td>
                        </tr>
                    </table>
                </fieldset>
                <br />
                <br />
                <br />
                </fieldset>


    </body>
          
    </html>


</asp:Content>

