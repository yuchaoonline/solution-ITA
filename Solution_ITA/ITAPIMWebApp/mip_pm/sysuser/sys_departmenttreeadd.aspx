<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sys_departmenttreeadd.aspx.cs" Inherits="mip_pm_sys_departmenttreeadd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>请选择部门：</h3>
        <asp:TreeView ID="TreeView_Obj" runat="server" ImageSet="Arrows" OnSelectedNodeChanged="TreeView_Obj_SelectedNodeChanged">
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
