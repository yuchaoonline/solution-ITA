<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sys_rolesselect.aspx.cs"
    Inherits="mip_pm_sys_rolesselect" %>

<%@ Register Assembly="ZLTextBox" Namespace="BaseText" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色信息管理页面</title>
    <link href="../../base/style/style.css" rel="stylesheet" type="text/css" />
    <link href="../../base/style/add.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="30">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                                                <span class="STYLE_HEAD">角色信息查询</span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <div align="right">
                                                        <span class="STYLE_HEAD">&nbsp;&nbsp;&nbsp;<img src="../../base/images/head_add.gif"
                                                            width="10" height="10" /><a href="sys_rolesadd.aspx"><span class="STYLE_HEAD">添加</span></a>
                                                            &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;</span><span class="STYLE_HEAD"> &nbsp;</span></div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table id="Table1" width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_ROLENO" runat="server" Text="角色编号：" Visible="false"></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_ROLENO" runat="server" Visible="false"></asp:TextBox></td>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_USERNO" runat="server" Text="角色名称：" Visible="false"></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_USERNO" runat="server" Visible="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_DESCRIPTION" runat="server" Text="描述：" Visible="false"></asp:Label></td>
                        <td colspan="3" class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_DESCRIPTION" Width="81%" runat="server" Visible="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                       
                        <td class="STYLE_TABLETD" align="right" colspan="4">
                            <asp:Button ID="Bt_select" runat="server" OnClick="Bt_select_Click" Text="查询" Width="46px"
                                Visible="false" />&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; 
                        </td>
                        
                    </tr>
                </table>
            </div>
            <div style="text-align: center">
                <asp:GridView ID="dwgridview_sys_roles" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" Width="100%" OnPageIndexChanging="dwgridview_sys_roles_PageIndexChanging"
                    OnSorting="dwgridview_sys_roles_Sorting" AllowPaging="True" AllowSorting="True"
                    OnRowDataBound="dwgridview_sys_roles_RowDataBound1">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="编号" SortExpression="ID" />
                        <asp:BoundField DataField="ROLENO" HeaderText="角色编号" SortExpression="ROLENO" />
                        <asp:BoundField DataField="USERNO" HeaderText="角色名称" SortExpression="USERNO" />
                        <asp:TemplateField HeaderText="数据分类" SortExpression="SYSDATATYPE">
                            <ItemTemplate>
                                <%# GetSYSDATATYPE(Eval("SYSDATATYPE").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DESCRIPTION" HeaderText="描述" SortExpression="DESCRIPTION" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="update" runat="server" CommandArgument='<%# Eval("id") %>' OnCommand="update_Command">修改</asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="delete" runat="server" CommandArgument='<%# Eval("id") %>'
                                    OnCommand="delete_Command" OnClientClick="return confirm('确定删除吗？')">删除</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="详细">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="detail" runat="server" CommandArgument='<%# Eval("id") %>' OnCommand="detail_Command">详细</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="权限分配">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="rightdip" runat="server" CommandArgument='<%# Eval("id") %>'
                                    OnCommand="rightdip_Command">权限分配</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings FirstPageImageUrl="~/base/images/main_table_headpage.gif" LastPageImageUrl="~/base/images/main_table_endpage.gif"
                        NextPageImageUrl="~/base/images/main_table_nextpage.gif" PreviousPageImageUrl="~/base/images/main_table_lastpage.gif"
                        FirstPageText="" Mode="NextPreviousFirstLast" />
                </asp:GridView>
            </div>
            <div>
                <table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="4" style="width: 100%; height: 49px;">
                            <table style="width: 100%">
                                <tr>
                                    <td width="40%" style="text-align: right">
                                        <asp:ImageButton ID="BT_EXCEL" runat="server" ImageUrl="../../Images/toexcel.JPG" OnClick="BT_EXCEL_Click" />
                                    </td>
                                    <td width="25%" style="text-align: right">
                                        分页设置：</td>
                                    <td width="15%">
                                        <asp:DropDownList ID="Dp_paging" runat="server" Width="124px" AutoPostBack="True"
                                            OnSelectedIndexChanged="Dp_paging_SelectedIndexChanged">
                                            <asp:ListItem>不分页</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>50</asp:ListItem>
                                            <asp:ListItem>100</asp:ListItem>
                                            <asp:ListItem>1000</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td width="20%">
                                        <asp:Label ID="Lb_Count" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
