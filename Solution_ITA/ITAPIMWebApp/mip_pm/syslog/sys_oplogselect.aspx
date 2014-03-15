<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sys_oplogselect.aspx.cs"
    Inherits="gtled_sys_oplogselect" %>

<%@ Register Assembly="ZLTextBox" Namespace="BaseText" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>日志管理页面</title>
    <link href="../../base/style/style.css" rel="stylesheet" type="text/css">
    <link href="../../base/style/add.css" rel="stylesheet" type="text/css">
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
                                                                <span class="STYLE_HEAD">日志查询</span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <div align="right">
                                                        <span class="STYLE_HEAD">&nbsp;&nbsp;&nbsp;</span><span class="STYLE_HEAD"> &nbsp;</span></div>
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
                            <asp:Label ID="LB_USERID" runat="server" Text="用户名：" Visible="false"></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_USERID" runat="server" Visible="false"></asp:TextBox></td>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_USERNAME" runat="server" Text="姓名：" Visible="false"></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_USERNAME" runat="server" Visible="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_OPTYPE" runat="server" Text="操作种类：" Visible="false"></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_OPTYPE" runat="server" Visible="false"></asp:TextBox></td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_OPTIME" runat="server" Text="操作时间：" Visible="False"></asp:Label></td>
                        <td colspan="3" class="STYLE_TABLETD" width="35%">
                            <cc1:ZLTextBox ID="TB_OPTIME" runat="server" InputType="date" IsDisplayTime="True"
                                Language="Chinese" ShowMessage="输入的格式不对" Visible="False"></cc1:ZLTextBox>
                            <span style="text-decoration: underline">
                                <asp:Label ID="Label_OPTIME" runat="server" Text="到" Visible="False"></asp:Label></span>
                            <cc1:ZLTextBox ID="TB_endOPTIME" runat="server" InputType="date" IsDisplayTime="True"
                                Language="Chinese" ShowMessage="输入的格式不对" Visible="False"></cc1:ZLTextBox>
                            <asp:Button ID="Bt_select" runat="server" OnClick="Bt_select_Click" Text="查询" Width="46px"
                                Visible="false" /></td>
                    </tr>
                    <tr>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_REMARK" runat="server" Text="备注：" Visible="false"></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_REMARK" runat="server" Visible="false"></asp:TextBox></td>
                        <td class="STYLE_TABLETD" width="15%" align="right">
                            <asp:Label ID="LB_REMARK1" runat="server" Text="备注1：" Visible="false"></asp:Label></td>
                        <td class="STYLE_TABLETD" width="35%">
                            <asp:TextBox ID="TB_REMARK1" runat="server" Visible="false"></asp:TextBox></td>
                    </tr>
                    
                </table>
            </div>
            <div style="text-align: center">
                <asp:GridView ID="dwgridview_sys_oplog" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" Width="100%" OnPageIndexChanging="dwgridview_sys_oplog_PageIndexChanging"
                    OnSorting="dwgridview_sys_oplog_Sorting" AllowPaging="True" AllowSorting="True"
                    OnRowDataBound="dwgridview_sys_oplog_RowDataBound1">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="编号" SortExpression="ID" />
                        <asp:BoundField DataField="USERID" HeaderText="用户名" SortExpression="USERID" />
                        <asp:BoundField DataField="USERNAME" HeaderText="姓名" SortExpression="USERNAME" />
                        <asp:BoundField DataField="OPTYPE" HeaderText="日志信息" SortExpression="OPTYPE" />
                        <asp:BoundField DataField="OPTIME" HeaderText="时间" SortExpression="OPTIME" />
                        <asp:BoundField DataField="REMARK" HeaderText="备注" SortExpression="REMARK" Visible="False" />
                        <asp:BoundField DataField="REMARK1" HeaderText="备注1" SortExpression="REMARK1"  Visible="False" />
                        <asp:TemplateField HeaderText="操作"  Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="update" runat="server" CommandArgument='<%# Eval("id") %>' OnCommand="update_Command">修改</asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="delete" runat="server" CommandArgument='<%# Eval("id") %>'
                                    OnCommand="delete_Command" OnClientClick="return confirm('确定删除吗？')">删除</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="详细"  Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="detail" runat="server" CommandArgument='<%# Eval("id") %>' OnCommand="detail_Command">详细</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="全" Visible="False">
                            <ItemTemplate>
                                <asp:CheckBox ID="inChk" runat="server" Checked="false" Width="20px" OnCheckedChanged="inChk_CheckedChanged" />
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:CheckBox ID="checkAll" Text="全选" runat="server" AutoPostBack="true" Checked="false"
                                    OnCheckedChanged="Ck_checkAll_Click" Width="80px" />
                            </HeaderTemplate>
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
