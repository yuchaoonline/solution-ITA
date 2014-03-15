<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="UI3_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
.STYLE3 {
	font-size: 12px;
	color: #435255;
}
.STYLE4 {font-size: 12px}
.STYLE5 {font-size: 12px; }
.n{TEXT-DECORATION:none}
-->
</style>
</head>
<body height="100%" border="0" align="center" cellpadding="0" cellspacing="0" >
    <form id="form1" runat="server" height="100%" border="0" align="center" cellpadding="0"
        cellspacing="0">
        <table width="147">
            <tr valign="top">
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" height="100%">
                        <asp:Label ID="LB_INDEX" runat="server" Text=""></asp:Label>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="19" background="images/main_69.gif">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="24%">
                                &nbsp;</td>
                            <td width="76%" valign="bottom">
                                <span class="STYLE3">SiteMIP v3.0</span></td>
                        </tr>
                    </table><input id="Hidden_GetPara" type="hidden" value="getpara" style="width: 1px; height: 1px" />
                </td>
            </tr>
        </table>
        <% GetScriptInfo();%>
    </form>



</body>
</html>