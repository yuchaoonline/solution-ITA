<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userrole.aspx.cs" Inherits="mip_pm_rightmanage_userrole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                                                            <td width="6%" height="19" valign="bottom">
                                                                <div align="center">
                                                                    <img src="../../base/images/head_tb.gif" width="14" height="14" /></div>
                                                            </td>
                                                            <td width="94%" valign="bottom">
                                                                <span class="STYLE_HEAD">编辑用户拥有的角色</span></td>
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
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
                    <tr>
                        <td class="th" colspan="3">
                            当前用户：<asp:Label ID="Lb_EDITUSERNAME" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>
            </div>
            <div align="center">
                <table>
                    <tr>
                        <td>
                            <table width="100%" class="useradd" border="0" align="center" cellpadding="0" cellspacing="1">
                                <tr>
                                    <th class="th"> 
                                        未选角色</th>
                                </tr>
                                <tr>
                                    <td width="200" height="300" valign="top">
                                        <asp:ListBox ID="Lb_noselet" runat="server" Height="299px" Width="204px"></asp:ListBox></td>
                                </tr>
                            </table>
                        </td>
                        <td width="30">
                            <asp:Button ID="Bt_torightallcommit" runat="server" OnClick="Bt_torightallcommit_Click"
                                Text=">>" Width="49px" /><br />
                            <br />
                            <asp:Button ID="Bt_torightonecommit" runat="server" OnClick="Bt_torightonecommit_Click"
                                Text=">" Width="49px" /><br />
                            <br />
                            <asp:Button ID="Bt_toleftonecommit" runat="server" OnClick="Bt_toleftonecommit_Click"
                                Text="<" Width="49px" /><br />
                            <br />
                            <asp:Button ID="Bt_toleftallcommit" runat="server" OnClick="Bt_toleftallcommit_Click"
                                Text="<<" Width="47px" /><br>
                            <br>
                        </td>
                        <td>
                            <table class="useradd" border="0" align="center" cellpadding="0" cellspacing="1">
                                <tr>
                                    <th class="th">
                                        已选角色</th>
                                </tr>
                                <tr>
                                    <td width="200" height="300" valign="top">
                                        <asp:ListBox ID="Lb_select" runat="server" Height="299px" Width="204px"></asp:ListBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div align="center">
                <table width="500">
                    <tr align="center">
                        <td>
                            <asp:Button ID="Bt_submit" runat="server" Text="提交" OnClick="Bt_submit_Click" Width="72px" />
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Button ID="Bt_return" runat="server" Text="返回" OnClick="Bt_return_Click" Width="71px" /></td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:TextBox ID="Tb_USERNAME" runat="server" Visible="False"></asp:TextBox>
            </div>
        </div>
    </form>
</body>
