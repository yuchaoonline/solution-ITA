<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sysinfo.aspx.cs" Inherits="UI3_Sysinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../base/style/add.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
                <tr>
                    <td style="height: 19px; background-color: #99ccff" align="center">
                        服务器基本信息
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td class="STYLE_TABLETD" width="15%" align="right">
                        操作系统：</td>
                    <td class="STYLE_TABLETD" width="35%">
                        <asp:Label ID="TB_qDrives" runat="server"></asp:Label></td>
                    <td class="STYLE_TABLETD" width="15%" align="right">
                        系统文件夹：
                    </td>
                    <td class="STYLE_TABLETD" width="35%">
                        <asp:Label ID="TB_qSystemDir" runat="server" Visible="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="STYLE_TABLETD" width="15%" align="right">
                        物理内存：</td>
                    <td class="STYLE_TABLETD" width="35%">
                        <asp:Label ID="TB_qMo" runat="server" Visible="true"></asp:Label></td>
                    <td class="STYLE_TABLETD" width="15%" align="right">
                        当前目录：
                    </td>
                    <td class="STYLE_TABLETD" width="35%">
                        <asp:Label ID="TB_qCurDir" runat="server" Visible="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="STYLE_TABLETD" width="15%" align="right">
                        主机网络域名：</td>
                    <td class="STYLE_TABLETD" width="35%">
                        <asp:Label ID="TB_qDomName" runat="server" Visible="true"></asp:Label></td>
                    <td class="STYLE_TABLETD" width="15%" align="right">
                        启动耗时(毫秒)：
                    </td>
                    <td class="STYLE_TABLETD" width="35%">
                        <asp:Label ID="TB_qTick" runat="server" Visible="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="STYLE_TABLETD" width="15%" align="right">
                        机器名：</td>
                    <td class="STYLE_TABLETD" width="35%">
                        <asp:Label ID="TB_qMachine" runat="server" Visible="true"></asp:Label></td>
                    <td class="STYLE_TABLETD" width="15%" align="right">
                        当前进程用户名：
                    </td>
                    <td class="STYLE_TABLETD" width="35%">
                        <asp:Label ID="TB_qUser" runat="server" Visible="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="STYLE_TABLETD" width="15%" align="right">
                        磁盘信息：</td>
                    <td class="STYLE_TABLETD" width="35%">
                        <asp:Label ID="TB_achDrives" runat="server" Visible="true"></asp:Label></td>
                    <td class="STYLE_TABLETD" width="15%" align="right">
                        磁盘数：
                    </td>
                    <td class="STYLE_TABLETD" width="35%">
                        <asp:Label ID="TB_achDrives_num" runat="server" Visible="true"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
        </div>
        
       <div>
            <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
                <tr>
                    <td style="height: 19px; background-color: #99ccff" align="center">
                        
                    </td>
                </tr>
            </table>
        </div>
        <div style="font-weight: bold; font-size: 45px; color: #ff0000;" align="center">
            欢迎使用<br />
            网络规划控制基础管理平台<br />
            </div>
    </form>
</body>
</html>
