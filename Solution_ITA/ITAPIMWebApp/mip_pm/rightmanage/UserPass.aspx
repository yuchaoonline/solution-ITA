<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserPass.aspx.cs" Inherits="rightmanage_UserPass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../base/style/add.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
           <div>
            <div>
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="30">
                            <table width="100%" border="0" cellspacing="0" align="left" cellpadding="0" bgcolor="#a8c7ce">
                                <tr>
                                    <td height="24" bgcolor="#353c44">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="6%" height="19" valign="bottom">
                                                                <div align="center">
                                                                    <img src="../../base/images/head_tb.gif" width="14" height="14" /></div>
                                                            </td>
                                                            <td width="94%" valign="bottom">
                                                                <span class="STYLE_HEAD">修改密码</span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <div align="right">
                                                        <span class="STYLE_HEAD"></span>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            
            
            <div>
                <table width="100%" border="0" align="center" cellpadding="1" cellspacing="1">
                                    <tr>
                        <td class="STYLE_TABLETD" align="right" width="50%">
                            用户名：</td>
                        <td class="STYLE_TABLETD" width="50%">
                            <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Width="136px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" align="right" width="50%">
                            原来密码：</td>
                        <td class="STYLE_TABLETD" width="50%">
                            <asp:TextBox ID="TB_LASTPWD" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" align="right">
                            现在密码：</td>
                        <td class="STYLE_TABLETD">
                            <asp:TextBox ID="TB_NOWPWD" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" align="right">
                            确认密码：</td>
                        <td class="STYLE_TABLETD">
                            <asp:TextBox ID="TB_QRNOWPWD" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td class="STYLE_TABLETD" align="right">
                            &nbsp;&nbsp; 
                            </td>
                        <td class="STYLE_TABLETD">
                            <asp:Button ID="BT_Submit" runat="server" Text="确认" OnClick="BT_Submit_Click" /></td>
                    </tr>
                    
                </table>
            </div>
        </div>
    </form>
</body>
</html>
