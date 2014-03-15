<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editsub.aspx.cs" Inherits="infodict_infodict_editsub" %>

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
            <br />
            <br />
            <table>
                <tr>
                    <td class="STYLE_TABLETD" style="width: 100px">
                        <asp:Label ID="Label5" runat="server" Width="119px">系统信息标准</asp:Label></td>
                    <%--系统信息标准--%>
                    <td class="STYLE_TABLETD" style="width: 180px" colspan="3">
                        <asp:DropDownList ID="listinfoname" runat="server" Width="154px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="STYLE_TABLETD" style="width: 100px; height: 25px">
                        <asp:Label ID="Label1" runat="server" Width="119px">信息标准编号</asp:Label></td>
                    <%--信息标准编号--%>
                    <td class="STYLE_TABLETD" style="width: 180px; height: 25px" colspan="3">
                        <asp:TextBox ID="infono" runat="server" Width="144px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="STYLE_TABLETD" style="width: 100px; height: 16px">
                        <asp:Label ID="Label2" runat="server" Width="121px">信息标准名称</asp:Label></td>
                    <%--信息标准名称--%>
                    <td class="STYLE_TABLETD" style="width: 144px; height: 16px">
                        <asp:TextBox ID="infoname" runat="server" Width="144px"></asp:TextBox></td>
                    <td class="STYLE_TABLETD" colspan="2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="infoname"
                            ErrorMessage="不可为空"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="STYLE_TABLETD" style="width: 100px">
                        <asp:Label ID="Label3" runat="server" Width="118px">修订人</asp:Label></td>
                    <%--修订人--%>
                    <td class="STYLE_TABLETD" style="width: 180px" colspan="3">
                        <asp:TextBox ID="actionpeople" runat="server" Width="144px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="STYLE_TABLETD" style="width: 100px; height: 38px">
                        <asp:Label ID="Label4" runat="server" Width="118px">描述</asp:Label></td>
                    <%--描述--%>
                    <td class="STYLE_TABLETD" style="width: 180px; height: 38px" colspan="3">
                        <asp:TextBox ID="description" runat="server" TextMode="MultiLine" Width="271px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="STYLE_TABLETD" style="width: 100px; height: 38px">
                    &nbsp;
                    </td>
                    <td class="STYLE_TABLETD" style="width: 144px; height: 38px" align="center">
                        <asp:ImageButton ID="submit" runat="server" OnClick="submit_Click" ImageUrl="~/Images/image_ch/buttonImages/common/state2.gif" /></td>
                    <td class="STYLE_TABLETD" style="width: 100px; height: 38px">
                        <asp:ImageButton ID="cancle" runat="server" OnClick="cancle_Click" CausesValidation="False"
                            ImageUrl="~/Images/image_ch/buttonImages/common/back.gif" /></td>
                    <td class="STYLE_TABLETD" style="width: 180px; height: 38px">
                        &nbsp; &nbsp;&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
