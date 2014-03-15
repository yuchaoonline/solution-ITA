<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dwedit.aspx.cs" Inherits="infoplatform_orgmanage_dept_dwedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../../base/style/add.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table>
                <tr>
                    <td class="STYLE_TABLETD"  style="width: 146px">
                        <asp:Label ID="Label4" runat="server">部门编号</asp:Label></td>
                    <%--部门编号--%>
                    <td class="STYLE_TABLETD"  style="width: 100px">
                        <asp:TextBox ID="departid" runat="server"></asp:TextBox></td>
                    <td class="STYLE_TABLETD"  colspan="2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="departid"
                            ErrorMessage="不可为空"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="STYLE_TABLETD"  style="width: 146px">
                        <asp:Label ID="Label8" runat="server">部门名称</asp:Label></td>
                    <%--部门名称--%>
                    <td class="STYLE_TABLETD"  style="width: 96px">
                        <asp:TextBox ID="departname" runat="server"></asp:TextBox></td>
                    <td class="STYLE_TABLETD"  colspan="2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="departname"
                            ErrorMessage="不可为空"></asp:RequiredFieldValidator>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="STYLE_TABLETD"  style="width: 146px">
                        <asp:Label ID="Label5" runat="server">级别</asp:Label></td>
                    <%--级别--%>
                    <td class="STYLE_TABLETD"  style="width: 96px">
                        <asp:DropDownList ID="syslevel" runat="server">
                        </asp:DropDownList></td>
                    <td class="STYLE_TABLETD" >
                        <asp:TextBox ID="id" runat="server" ReadOnly="True" Visible="False"></asp:TextBox></td>
                    <td class="STYLE_TABLETD"  colspan="2">
                        <asp:Label ID="lb_action" runat="server" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <td class="STYLE_TABLETD"  style="width: 146px">
                        <asp:Label ID="Label6" runat="server">详细名称</asp:Label><%--详细名称--%>
                    </td>
                    <td class="STYLE_TABLETD"  style="width: 100px" colspan="3">
                        <asp:TextBox ID="description" runat="server" Height="176px" TextMode="MultiLine"
                            Width="390px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="STYLE_TABLETD"  style="width: 146px; height: 28px">
                    &nbsp;
                        <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label></td>
                    <td class="STYLE_TABLETD"  style="width: 96px; height: 28px; text-align: center;">
                    
                        <asp:ImageButton ID="submit" runat="server" ImageUrl="~/Images/image_ch/buttonImages/common/state2.gif"
                            OnClick="submit_Click" />
                    </td>
                    <td class="STYLE_TABLETD"  style="width: 63px; height: 28px; text-align: center;">
                        &nbsp;<asp:TextBox ID="parent" runat="server" ReadOnly="True" Visible="False"></asp:TextBox></td>
                    <td class="STYLE_TABLETD"  style="width: 100px; height: 28px">
                        &nbsp;&nbsp;
                        <img id="img_cancle" name="img_cancle" runat="server" onclick="history.back();" src="~/Images/image_ch/buttonImages/common/back.gif" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
