<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dwindex.aspx.cs" Inherits="infoplatform_orgmanage_dept_dwindex" StylesheetTheme="SkinFile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>

    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ImageButton ID="Imbtn_add" runat="server" ImageUrl="~/Images/image_ch/buttonImages/common/recruit.gif"
            OnClick="Imbtn_add_Click" ToolTip="添加部门" />
        &nbsp; &nbsp;&nbsp;
        <asp:ImageButton ID="imbtn_delete" runat="server" ImageUrl="~/Images/image_ch/buttonImages/common/delete.gif"
            OnClick="imbtn_delete_Click"  OnClientClick = "return confirm('该操作将删除所有选中部门及其下属部门,确定删除吗？');" ToolTip="删除选中部门" /></div>
    <div>
        <asp:TreeView ID="menu" runat="server" Height="100%" Width="220px"  ShowCheckBoxes="All" ImageSet="Arrows" OnSelectedNodeChanged="menu_SelectedNodeChanged" OnTreeNodeCheckChanged="menu_TreeNodeCheckChanged" >
            <ParentNodeStyle Font-Bold="False" />
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                VerticalPadding="0px" />
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                NodeSpacing="0px" VerticalPadding="0px" />
            
        </asp:TreeView>
    </div>
 
    </form>
</body>
</html>
