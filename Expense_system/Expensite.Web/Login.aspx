<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Expensite.Web.login1" %>
<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Expensite</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="style.css" rel="stylesheet" type="text/css" />
    <script src="js/cufon-yui.js" type="text/javascript"></script>
    <script src="js/cufon-replace.js" type="text/javascript"></script>
    <script src="js/Myriad_Pro_300.font.js" type="text/javascript"></script>
    <%-- jquery slider --%>
    <link href="themes/generic.css" rel="stylesheet" type="text/css" />
    <link href="themes/3/slider.css" rel="stylesheet" type="text/css" />
    <script src="themes/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="themes/3/jquery-slider.js" type="text/javascript"></script>
    <%-- jquery slider --%>
<style type="text/css">
    .login1 {
        float: right;
        height: 300px;
        width: 400px;
    }
    .auto-style5 {
        width: 84px;
    }
    .auto-style7 {
        height: 113px;
        width: 400px;
    }
    .auto-style8 {
        width: 163px;
    }
</style>
    <!--[if lt IE 7]>
<script type="text/javascript" src="js/ie_png.js"></script>
<script type="text/javascript">ie_png.fix('.png, #header .row-2 ul li a, #content, .list li');</script>
<![endif]-->
</head>


<body id="page1">
    <form id="form1" runat="server">
        <div class="tail-top">
            <div class="tail-bottom">
                <div class="body-bg">
                    <!-- HEADER -->
                    <div id="header">
                        <div class="row-1">
                            <div class="fleft">
                                <img src="images/logo.jpg" alt="" style="height:50px;width:50px;"/>
                                <label id="lblName" style="font-size: 35px; color: #20B7C9;">Expensite</label>&nbsp;
                                 <br/> 
                                
                                <label id="lblSlogan" style="font-size:15px;color:#20B7C9">Expenses ,That are Efficeint to Manage</label>
                            </div>
                            <div class="login1">
                            <table class="auto-style7" >
                            <tr>
                                <td class="auto-style5" style="color:white">E-Mail:</td>
                                <td class="auto-style8">
                                    <asp:TextBox ID="txtEmail" runat="server" Width="160px"></asp:TextBox></td>
                                <td style="color:red">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="E-Mail should not be Empty" ControlToValidate="txtEmail" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid E-Mail Id" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ValidationGroup="g1"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5" style="color:white">Password:</td>
                                <td class="auto-style8">
                                    <asp:TextBox ID="txtPassword" runat="server" Width="160px" TextMode="Password"></asp:TextBox></td>
                                <td style="color:red"> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password should not be Empty" ControlToValidate="txtPassword" ValidationGroup="g1"></asp:RequiredFieldValidator></td>
                            </tr>
                                <tr>
                                    <td class="auto-style5" style="border-radius:10px">
                                       
                                         <asp:Button ID="btnSignIn" runat="server" Text="Sign In" Height="26px" Width="65px" ValidationGroup="g1" OnClick="btnSignIn_Click" /></td>

                                    <td class="auto-style8">
                                        <asp:LinkButton ID="lnkForgot" runat="server" OnClick="lnkForgot_Click">Forgot Password?</asp:LinkButton></td>
                                    <td>
                                        <asp:HiddenField ID="hdf" runat="server" />
                                    </td>
                                </tr>
                        </table>
                                </div>

                        </div>
                       
                        <div class="slider">
                            <%-- jquery slider --%>
            <div id="mcts1">
                <div class="each">
                    <img src="images/img1.jpg" width="93.5%"height="100%"/>
                </div>
                <div class="each">
                    <img src="images/img2.jpg" width="93.5%" height="100%" />
                </div>
                <div class="each">
                    <img src="images/img3.jpg"  width="93.5%" height="100%"/>
                </div>
                <div class="each">
                    <img src="images/img4.jpg" width="93.5%" height="100%"/>
                </div>
                <div class="each">
                    <img src="images/img5.jpg"  width="93.5%"height="100%"/>
                </div>
                <div class="each">
                    <img src="images/img6.jpg"  width="93.5%" height="100%"/>
                </div>
                <div class="each">
                    <img src="images/img7.jpg" width="93.5%"  height="100%"/>
                </div>
                <div class="each">
                    <img src="images/img8.jpg" width="93.5%" height="100%"/>
                </div>
                <div class="each">
                    <img src="images/img9.jpg"  width="93.5%"height="100%" />
                </div>
                <div class="each">
                    <img src="images/img10.jpg"  width="93.5%" height="100%"/>
                </div>
                <div class="each">
                    <img src="images/img11.jpg"  width="93.5%" height="100%"/>
                </div>
                <div class="each">
                    <img src="images/img12.jpg"  width="93.5%" height="100%"/>
                </div>
                <div class="each">
                    <img src="images/img13.jpg"  width="93.5%" height="100%"/>
                </div>
                <div class="each">
                    <img src="images/img14.jpg"  width="93.5%" height="100%"/>
                </div>
                <div class="each">
                    <img src="images/img15.jpg"  width="93.5%" height="100%"/>
                </div>
                
            </div>
            <%-- jquery slider --%>
</div>
                    </div>
                    <!-- CONTENT -->
                    <div id="content" style="height:250px">
                        <div class="tail-right">
                           
                            <div class="wrapper">
                           
                            </div>
                        </div>
                        
                        </div>
                    <!-- FOOTER -->
                   <div id="footer">
                        <div class="indent">
                            <div class="fleft">
                                Designed by: 
                                    Vaibhavi and Dolly&nbsp;
                            </div>
                            <div class="fright">Copyright - Vaibhavi and Dolly</div>
                        </div>
                    </div>
                </div>
            </div>
        
        <script type="text/javascript"> Cufon.now(); </script>
        <div align="center"></div>
    </form>
</body>
</html>



