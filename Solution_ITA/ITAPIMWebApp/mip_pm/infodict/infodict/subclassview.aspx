<%@ Page Language="C#" AutoEventWireup="true" CodeFile="subclassview.aspx.cs" Inherits="infodict_infodict_subclassview" StylesheetTheme="SkinFile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=Application["title"]%></title>
    <link href="~/base/style/style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <br />
            <div style=" text-align:center;">
            <asp:ImageButton ID="Imbtn_add" runat="server" ImageUrl="~/Images/image_ch/buttonImages/common/bt_tj.gif"
                OnClick="Imbtn_add_Click" ToolTip="添加信息标准分类" />
                </div>
                <br />
            <div style=" text-align:center;">
    <asp:GridView ID="GridView1" runat="server"  
                Width="284px" AutoGenerateColumns="False"   OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True"  AllowSorting="True" Height="50%" OnRowDataBound="GridView1_RowDataBound" >       
                <Columns>
                     <asp:BoundField HeaderText="编号" DataField="ID" Visible="False">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="信息标准编号" DataField="infono" >
                                </asp:BoundField>
                                <asp:BoundField HeaderText="信息标准名称" DataField="infoname">
                                </asp:BoundField>
                                 <asp:BoundField HeaderText="级别" DataField="infolevel" Visible="False">
                                </asp:BoundField>
                                 <asp:BoundField HeaderText="描述" DataField="description" Visible="False">
                                </asp:BoundField>
                                 <asp:BoundField HeaderText="修订人" DataField="actionpeople" Visible="False">
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="操作">
                                <ItemStyle HorizontalAlign ="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/mip_pm/Ima/menu/edit.gif" ID="btn_update" runat="server"  CssClass="inputedit" CommandArgument='<%# Eval("ID") %>' OnCommand="btn_update_Command" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
 
    </form>
</body>
</html>