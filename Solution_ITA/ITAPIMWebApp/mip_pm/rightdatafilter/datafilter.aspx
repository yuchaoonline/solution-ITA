<%@ Page Language="C#" AutoEventWireup="true" CodeFile="datafilter.aspx.cs" Inherits="mip_pm_rightdatafilter_datafilter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../../base/style/add.css" rel="stylesheet" type="text/css">
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
                                                                <span class="STYLE_HEAD">用户数据集控制设置</span></td>
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
                <table id="Table1" width="100%" border="0" align="center" valign="top" cellpadding="0" cellspacing="1">
                    <tr>
                        <td class="STYLE_TABLETD" width="25%" align="left">
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            选择数据集控制点：
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:TreeView ID="_Datafilternodemenu" runat="server" Height="100%" Width="220px"
                                                ImageSet="Arrows" OnSelectedNodeChanged="_Datafilternodemenu_SelectedNodeChanged">
                                                <ParentNodeStyle Font-Bold="False" />
                                                <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                                <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                                                    VerticalPadding="0px" />
                                                <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                            </asp:TreeView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td class="STYLE_TABLETD" width="75%" valign="top">
                            <div>
                                <table id="Table2" width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
                                    <tr>
                                        <td class="STYLE_TABLETD" width="15%" align="left">
                                            用户名：
                                        </td>
                                        <td class="STYLE_TABLETD" width="35%" align="left">
                                            <asp:TextBox ID="TB_USERNAME" runat="server"></asp:TextBox>
                                        </td>
                                        <td class="STYLE_TABLETD" width="15%" align="left">
                                            数据集控制点：
                                        </td>
                                        <td class="STYLE_TABLETD" width="35%" align="left">
                                            <asp:TextBox ID="TB_DATAFILTERNAME" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="STYLE_TABLETD" width="15%" align="left">
                                            权限范围：
                                        </td>
                                        <td class="STYLE_TABLETD" width="85%" align="left" colspan="3">
                                            <asp:RadioButtonList ID="RB_DATAFILTERTYPE" runat="server" RepeatDirection="Horizontal">
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="STYLE_TABLETD" width="100%" align="left" colspan="4">
                                            <asp:TreeView ID="TV_DEPTUSER" runat="server" Height="100%" Width="220px" ShowCheckBoxes="All" OnTreeNodeCheckChanged="TV_DEPTUSER_TreeNodeCheckChanged">
                                                <ParentNodeStyle Font-Bold="False" />
                                                <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                                <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                                                    VerticalPadding="0px" />
                                                <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                                                    NodeSpacing="0px" VerticalPadding="0px" />
                                            </asp:TreeView>
                                        </td>
                                        
                                    </tr>
                                     <tr>
                                        <td class="STYLE_TABLETD" width="50%" align="center" colspan="2" >
                                            <asp:Button ID="Bt_commit" runat="server" OnClick="Bt_commit_Click" Text="添加" Width="46px" /></td>
                                        <td class="STYLE_TABLETD" width="50%" align="center" colspan="2" >
                                            <asp:Button ID="Bt_return" runat="server" OnClick="Bt_return_Click" Text="返回" Width="50px" /></td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
