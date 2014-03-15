<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sys_usersadd.aspx.cs" Inherits="mip_pm_sys_usersadd" %>

<%@ Register Assembly="ZLTextBox" Namespace="BaseText" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人员信息管理页面添加页面</title>
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
                                                                <span class="STYLE_HEAD">增加人员信息</span></td>
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
                <table id="Table1" width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right" style="height: 43px">
                            <asp:Label ID="LB_DEPTID" runat="server" Text="部门ID："></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%" style="height: 43px">
                            <asp:TextBox ID="TB_DEPTID" runat="server" Width="35px"></asp:TextBox><asp:TextBox
                                ID="TB_DEPTNAME" runat="server" Width="105px"></asp:TextBox><asp:Button ID="Bt_DEPARTMENT" runat="server" Text="选择部门" OnClick="Bt_DEPARTMENT_Click" />
                            <asp:Label ID="LB_DEPTIDunit" runat="server" Text=""></asp:Label></td>
                        <td class="STYLE_TABLETD" width="15%" align="right" style="height: 43px">
                            <asp:Label ID="LB_USERNO" runat="server" Text="工号："></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%" style="height: 43px">
                            <asp:TextBox ID="TB_USERNO" runat="server"></asp:TextBox><asp:Label ID="LB_USERNOunit"
                                runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_USERREALNAME" runat="server" Text="姓名："></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_USERREALNAME" runat="server" Width="153px"></asp:TextBox><asp:Label
                                ID="LB_USERREALNAMEunit" runat="server" Text=""></asp:Label></td>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_USERNAME" runat="server" Text="用户名："></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_USERNAME" runat="server"></asp:TextBox><asp:Label ID="LB_USERNAMEunit"
                                runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_PASSWORD" runat="server" Text="密码："></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_PASSWORD" runat="server" TextMode="Password" Width="151px"></asp:TextBox><asp:Label
                                ID="LB_PASSWORDunit" runat="server" Text=""></asp:Label>（长度6到16位）</td>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_SEX" runat="server" Text="性别："></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:DropDownList ID="DP_SEX" runat="server" Width="156px">
                                <asp:ListItem Value="1">男</asp:ListItem>
                                <asp:ListItem Value="2">女</asp:ListItem>
                            </asp:DropDownList><asp:Label ID="LB_SEXunit" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_AGE" runat="server" Text="年龄："></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_AGE" runat="server"></asp:TextBox><asp:Label ID="LB_AGEunit"
                                runat="server" Text=""></asp:Label></td>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_PHONENO" runat="server" Text="联系电话："></asp:Label></td>
                        <td class="STYLE_TABLETD"  width="35%">
                            <asp:TextBox ID="TB_PHONENO" runat="server"></asp:TextBox>
                            <asp:Label ID="LB_PHONENOunit" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_MOBILEPHONE" runat="server" Text="移动电话："></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_MOBILEPHONE" runat="server"></asp:TextBox><asp:Label ID="LB_MOBILEPHONEunit"
                                runat="server" Text=""></asp:Label></td>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_REMARK1" runat="server" Text="备注1："></asp:Label></td>
                        <td class="STYLE_TABLETD"  width="35%">
                            <asp:TextBox ID="TB_REMARK1" runat="server"></asp:TextBox>
                            <asp:Label ID="LB_REMARK1unit" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_REMARK2" runat="server" Text="备注2："></asp:Label></td>
                        <td class="STYLE_TABLETD"  width="35%">
                            <asp:TextBox ID="TB_REMARK2" runat="server"></asp:TextBox>
                            <asp:Label ID="LB_REMARK2unit" runat="server" Text=""></asp:Label></td>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_REMARK3" runat="server" Text="备注3："></asp:Label></td>
                        <td class="STYLE_TABLETD"  width="35%">
                            <asp:TextBox ID="TB_REMARK3" runat="server"></asp:TextBox>
                            <asp:Label ID="LB_REMARK3unit" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_REMARK4" runat="server" Text="备注4："></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_REMARK4" runat="server"></asp:TextBox><asp:Label ID="LB_REMARK4unit"
                                runat="server" Text=""></asp:Label></td>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_REMARK5" runat="server" Text="备注5："></asp:Label></td>
                        <td class="STYLE_TABLETD"  width="35%">
                            <asp:TextBox ID="TB_REMARK5" runat="server"></asp:TextBox>
                            <asp:Label ID="LB_REMARK5unit" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" align="center">
                            &nbsp; &nbsp;</td>
                        <td class="STYLE_TABLETD">
                            <asp:Button ID="Bt_commit" runat="server" OnClick="Bt_commit_Click" Text="添加" Width="46px" />
                            <asp:Button ID="Bt_clear" runat="server" OnClick="Bt_clear_Click" Text="清空" Width="50px" /></td>
                        <td class="STYLE_TABLETD" width="80" align="right">
                            &nbsp;&nbsp; &nbsp;</td>
                        <td class="STYLE_TABLETD" width="200">
                            <asp:Button ID="Bt_return" runat="server" OnClick="Bt_return_Click" Text="返回" Width="50px" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
