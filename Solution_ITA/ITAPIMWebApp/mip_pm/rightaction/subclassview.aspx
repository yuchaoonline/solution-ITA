<%@ Page Language="C#" AutoEventWireup="true" CodeFile="subclassview.aspx.cs" Inherits="sys_moudleaction_subclassview"
    StylesheetTheme="SkinFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=Application["title"]%>
    </title>
    <link href="~/base/style/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div style="text-align: center;">
            <asp:ImageButton ID="Imbtn_add" runat="server" ImageUrl="~/Images/image_ch/buttonImages/common/bt_tj.gif"
                OnClick="Imbtn_add_Click" ToolTip="添加菜单动作" />
        </div>
        <br />
        <div style="text-align: center;">
            <asp:GridView ID="GridView1" runat="server" Width="454px" AutoGenerateColumns="False"
                OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True" AllowSorting="false"
                Height="50%" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="编号" DataField="ID" Visible="False"></asp:BoundField>
                    <asp:TemplateField HeaderText="模块名称" SortExpression="MOUDLENAME" Visible="true">
                            <ItemTemplate>
                                <%# GetMOUDLENAME(Eval("MOUDLENAME").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:BoundField DataField="DESCRIPTION" HeaderText="编号" SortExpression="DESCRIPTION" />
                    <asp:BoundField DataField="ACTION" HeaderText="权限名称" SortExpression="ACTION" />
                    <asp:TemplateField HeaderText="数据筛选" Visible="true">
                            <ItemTemplate>
                                <%# GetISOFDATAFILTER(Eval("ISOFDATAFILTER").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/mip_pm/Ima/menu/edit.gif" ID="btn_update" runat="server"
                                CssClass="inputedit" CommandArgument='<%# Eval("ID") %>' OnCommand="btn_update_Command" />
                                <asp:ImageButton ImageUrl="~/mip_pm/Ima/menu/delete.gif" ID="btn_delete" runat="server"
                                CssClass="inputedit" CommandArgument='<%# Eval("ID") %>' OnCommand="btn_delete_Command" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
