<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="rightmanage_UserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
                                                                <span class="STYLE_HEAD">用户信息</span></td>
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
                            <asp:Label ID="LB_USERNAME" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" align="right">
                            人员真实姓名：</td>
                        <td class="STYLE_TABLETD">
                            <asp:Label ID="LB_REALNAME" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" align="right">
                            人员工号：</td>
                        <td class="STYLE_TABLETD">
                            <asp:Label ID="LB_JOBNUM" runat="server"></asp:Label></td>
                    </tr>
                 
                    
                    <tr>
                        <td class="STYLE_TABLETD" align="right" style="height: 19px">
                            </td>
                        <td class="STYLE_TABLETD" style="height: 19px">
                            </td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" align="right">
                            </td>
                        <td class="STYLE_TABLETD">
                            </td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" align="right">
                            </td>
                        <td class="STYLE_TABLETD">
                           </td>
                    </tr>
                  
                    <tr>
                        <td class="STYLE_TABLETD" align="right">
                            </td>
                        <td class="STYLE_TABLETD">
                            </td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" align="right">
                            </td>
                        <td class="STYLE_TABLETD">
                            </td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" align="right">
                            </td>
                        <td class="STYLE_TABLETD">
                            </td>
                    </tr>
                
                </table>
            </div>
        </div>
    </form>
</body>
</html>
