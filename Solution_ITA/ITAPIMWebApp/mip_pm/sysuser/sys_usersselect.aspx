<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sys_usersselect.aspx.cs"
    Inherits="mip_pm_sys_usersselect" %>

<%@ Register Assembly="ZLTextBox" Namespace="BaseText" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>人员信息管理页面</title>
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
                                                                <span class="STYLE_HEAD">人员信息查询</span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <div align="right">
                                                        <span class="STYLE_HEAD">&nbsp; &nbsp;&nbsp;<img src="../../base/images/head_add.gif" width="10" height="10" /><a
                                                                href="sys_usersadd.aspx"><span class="STYLE_HEAD">添加</span></a> &nbsp;
                                                            
                                                            &nbsp;&nbsp;
                                                            &nbsp;&nbsp;</span><span class="STYLE_HEAD"> &nbsp;</span></div>
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
                            <asp:Label ID="LB_DEPTID" runat="server" Text="部门ID：" Visible="false"></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_DEPTID" runat="server" Visible="false" Width="32px"></asp:TextBox><asp:TextBox
                                ID="TB_DEPTNAME" runat="server" Width="113px"></asp:TextBox><asp:Button ID="Bt_DEPARTMENT" runat="server"
                                    OnClick="Bt_DEPARTMENT_Click" Text="选择部门" /></td>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_USERNO" runat="server" Text="人员工号：" Visible="false"></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_USERNO" runat="server" Visible="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_USERREALNAME" runat="server" Text="人员真实名称：" Visible="false"></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_USERREALNAME" runat="server" Visible="false"></asp:TextBox></td>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_USERNAME" runat="server" Text="用户名：" Visible="false"></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_USERNAME" runat="server" Visible="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_SEX" runat="server" Text="性别：" Visible="false"></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:DropDownList ID="DP_SEX" runat="server" Width="156px" Visible="false">
                                <asp:ListItem Value="0">请选择</asp:ListItem>
                                <asp:ListItem Value="1">男</asp:ListItem>
                                <asp:ListItem Value="2">女</asp:ListItem>
                            </asp:DropDownList></td>
                        <td class="STYLE_TABLETD" width="15%" align="right" visible="false">
                            &nbsp; &nbsp;</td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:Button ID="Bt_select" runat="server" OnClick="Bt_select_Click" Text="查询" Width="46px"
                                Visible="false" /></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_AGE" runat="server" Text="年龄：" Visible="false"></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_AGE" runat="server" Visible="false"></asp:TextBox></td>
                        <td>
                            <asp:Label ID="LB_PASSWORD" runat="server" Text="人员密码：" Visible="false"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="TB_PASSWORD" runat="server" Visible="false"></asp:TextBox></td>
                    </tr>
                    
                </table>
            </div>
            <div style="text-align: center">
                <asp:GridView ID="dwgridview_sys_users" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" Width="100%" OnPageIndexChanging="dwgridview_sys_users_PageIndexChanging"
                    OnSorting="dwgridview_sys_users_Sorting" AllowPaging="True" AllowSorting="True"
                    OnRowDataBound="dwgridview_sys_users_RowDataBound1">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="编号" SortExpression="ID" />
                        <asp:BoundField DataField="DEPTID" HeaderText="部门id" SortExpression="DEPTID" Visible="false" />
                        <asp:TemplateField HeaderText="所在部门" SortExpression="DEPTID" >
                            <ItemTemplate>
                                <%# GetDeptName(Eval("DEPTID").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="USERNO" HeaderText="工号" SortExpression="USERNO" />
                        <asp:BoundField DataField="USERREALNAME" HeaderText="姓名" SortExpression="USERREALNAME" />
                        <asp:BoundField DataField="USERNAME" HeaderText="用户名" SortExpression="USERNAME" />
                        <asp:BoundField DataField="PASSWORD" HeaderText="密码" SortExpression="PASSWORD"  Visible="false"/>
                        <asp:TemplateField HeaderText="性别" SortExpression="SEX" Visible="false">
                            <ItemTemplate>
                                <%# GetSEX(Eval("SEX").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AGE" HeaderText="年龄" SortExpression="AGE" Visible="false" />
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
                         <asp:TemplateField HeaderText="角色速配">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="pzrole" runat="server" CommandArgument='<%# Eval("id") %>' OnCommand="pzrole_Command">角色速配</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                           <asp:TemplateField HeaderText="数据权限">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="cityproright" runat="server" CommandArgument='<%# Eval("id") %>' OnCommand="cityproright_Command">设置</asp:LinkButton>
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
