<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editsub.aspx.cs" Inherits="mip_pm_sys_moudleactionedit" %>

<%@ Register Assembly="ZLTextBox" Namespace="BaseText" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>系统模块操作编辑</title>
    <link href="../../base/style/add.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <table id="Table2" width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table id="Table3" border="0" width="100%" align="center" cellpadding="0" cellspacing="1">
                            <tr>
                                <td class="STYLE_TABLETD" width="15%" align="right">
                                    <asp:Label ID="LB_ID" runat="server" Text="id：" Visible="false"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="TB_ID" runat="server" ReadOnly="True" Visible="false"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="STYLE_TABLETD" width="15%" align="right">
                                    <asp:Label ID="LB_MOUDLENAME" runat="server" Text="模块名称："></asp:Label></td>
                                <td class="STYLE_TABLETD"  width="75%" colspan="3">
                                    <asp:TextBox ID="TB_MOUDLENAME" runat="server"></asp:TextBox><asp:Label ID="LB_MOUDLENAMEunit"
                                        runat="server" Text=""></asp:Label></td>
                              
                            </tr>
                            <tr>
                                <td class="STYLE_TABLETD" width="15%" align="right">
                                    <asp:Label ID="Label1" runat="server" Text="模块名称："></asp:Label></td>
                                <td class="STYLE_TABLETD"  width="75%" colspan="3">
                                    <asp:TextBox ID="TB_MOUDLENAME_INFO" runat="server"></asp:TextBox><asp:Label ID="Label2"
                                        runat="server" Text=""></asp:Label></td>
                              
                            </tr>
                            <tr>
                                <td class="STYLE_TABLETD" width="15%" align="right">
                                    <asp:Label ID="LB_DESCRIPTION" runat="server" Text="编号："></asp:Label></td>
                                <td class="STYLE_TABLETD"  width="75%" colspan="3">
                                    <asp:TextBox ID="TB_DESCRIPTION" Width="75%" runat="server"></asp:TextBox><asp:Label
                                        ID="LB_DESCRIPTIONunit" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                              <td class="STYLE_TABLETD" width="15%" align="right">
                                    <asp:Label ID="LB_ACTION" runat="server" Text="动作名称："></asp:Label></td>
                                <td class="STYLE_TABLETD" width="75%" colspan="3">
                                    <asp:TextBox ID="TB_ACTION" runat="server"></asp:TextBox><asp:Label ID="LB_ACTIONunit"
                                        runat="server" Text=""></asp:Label></td>
                            </tr>
                               <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="Label3" runat="server" Text="数据筛选："></asp:Label></td>
                        <td class="STYLE_TABLETD"  Width="75%" colspan="3">
                            <asp:DropDownList ID="DP_ISOFDATAFILTER" runat="server">
                            </asp:DropDownList>
                            </td>
                    </tr>
                            <tr>
                                <td class="STYLE_TABLETD" align="center">
                                    &nbsp; &nbsp;</td>
                                <td class="STYLE_TABLETD">
                                    <asp:Button ID="Bt_commit" runat="server" OnClick="Bt_commit_Click" Text="修改" Width="46px" />
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
