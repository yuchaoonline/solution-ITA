<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SYS_MENUedit.aspx.cs" Inherits="mip_pm_SYS_MENUedit" %>

<%@ Register Assembly="ZLTextBox" Namespace="BaseText" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>菜单编辑</title>
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
                                                            <td width="3%" height="19" valign="bottom">
                                                                <div align="center">
                                                                    <img src="../../base/images/head_tb.gif" width="14" height="14" /></div>
                                                            </td>
                                                            <td width="97%" valign="bottom">
                                                                <span class="STYLE_HEAD">菜单编辑</span></td>
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
            <table id="Table2" width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table id="Table3" border="0" width="100%" align="center" cellpadding="0" cellspacing="1">
                            <tr>
                                <td class="STYLE_TABLETD" width="15%" align="right">
                                    <asp:Label ID="LB_ID" runat="server" Text="编号：" Visible="false"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="TB_ID" runat="server" ReadOnly="True" Visible="false"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="STYLE_TABLETD" width="15%" align="right">
                                    <asp:Label ID="LB_SYSNAME" runat="server" Text="系统名称："></asp:Label></td>
                                <td class="STYLE_TABLETD" width="35%">
                                    <asp:TextBox ID="TB_SYSNAME" runat="server"></asp:TextBox><asp:Label ID="LB_SYSNAMEunit"
                                        runat="server" Text=""></asp:Label></td>
                                <td class="STYLE_TABLETD" width="15%" align="right">
                                    <asp:Label ID="LB_MOUDLENAME" runat="server" Text="模块名称："></asp:Label></td>
                                <td class="STYLE_TABLETD" width="35%">
                                    <asp:TextBox ID="TB_MOUDLENAME" runat="server"></asp:TextBox><asp:Label ID="LB_MOUDLENAMEunit"
                                        runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="STYLE_TABLETD" width="15%" align="right">
                                    <asp:Label ID="LB_SYSLEVEL" runat="server" Text="级别："></asp:Label></td>
                                <td class="STYLE_TABLETD" width="35%">
                                    <asp:DropDownList ID="DP_SYSLEVEL" runat="server" Width="156px">
                                        <asp:ListItem Value="1">第一级</asp:ListItem>
                                        <asp:ListItem Value="2">第二级</asp:ListItem>
                                    </asp:DropDownList><asp:Label ID="LB_SYSLEVELunit" runat="server" Text=""></asp:Label></td>
                                <td class="STYLE_TABLETD" width="15%" align="right">
                                    <asp:Label ID="LB_PARENT" runat="server" Text="上一级别模块："></asp:Label></td>
                                <td class="STYLE_TABLETD" width="35%">
                                    <asp:TextBox ID="TB_PARENT" runat="server"></asp:TextBox><asp:Label ID="LB_PARENTunit"
                                        runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="STYLE_TABLETD" width="15%" align="right">
                                    <asp:Label ID="LB_URL" runat="server" Text="URL："></asp:Label></td>
                                <td class="STYLE_TABLETD" colspan="3">
                                    <asp:TextBox ID="TB_URL" Width="75%" runat="server"></asp:TextBox><asp:Label ID="LB_URLunit"
                                        runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="STYLE_TABLETD" width="15%" align="right">
                                    <asp:Label ID="LB_DESCRIPTION" runat="server" Text="描述："></asp:Label></td>
                                <td class="STYLE_TABLETD" colspan="3">
                                    <asp:TextBox ID="TB_DESCRIPTION" Width="75%" runat="server"></asp:TextBox><asp:Label
                                        ID="LB_DESCRIPTIONunit" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="STYLE_TABLETD" width="15%" align="right">
                                    <asp:Label ID="LB_IMG" runat="server" Text="菜单图片："></asp:Label></td>
                                <td class="STYLE_TABLETD" colspan="3">
                                    <asp:TextBox ID="TB_IMG" Width="75%" runat="server"></asp:TextBox><asp:Label ID="LB_IMGunit"
                                        runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="STYLE_TABLETD" width="15%" align="right">
                                    <asp:Label ID="LB_VERSION" runat="server" Text="颁本："></asp:Label></td>
                                <td class="STYLE_TABLETD" width="35%">
                                    <asp:DropDownList ID="DP_VERSION" runat="server" Width="156px">
                                        <asp:ListItem Value="1">版本一</asp:ListItem>
                                        <asp:ListItem Value="2">版本二</asp:ListItem>
                                    </asp:DropDownList><asp:Label ID="LB_VERSIONunit" runat="server" Text=""></asp:Label></td>
                                <td class="STYLE_TABLETD">
                                    &nbsp;&nbsp;</td>
                                <td class="STYLE_TABLETD">
                                    &nbsp; &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="STYLE_TABLETD" align="center">
                                    &nbsp; &nbsp;</td>
                                <td class="STYLE_TABLETD">
                                    &nbsp;<asp:Button ID="Bt_commit" runat="server" OnClick="Bt_commit_Click" Text="修改"
                                        Width="46px" />
                                </td>
                                <td class="STYLE_TABLETD" width="80" align="right">
                                    &nbsp; &nbsp;</td>
                                <td class="STYLE_TABLETD" width="200">
                                    <asp:Button ID="Bt_return" runat="server" OnClick="Bt_return_Click" Text="返回" Width="50px" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
