<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sys_modulerun.aspx.cs" Inherits="mip_pm_sys_modulerun" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>菜单管理页面</title>
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
                                                                <span class="STYLE_HEAD">系统服务运行状态查询</span></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <div align="right">
                                                        <span class="STYLE_HEAD">&nbsp;&nbsp;&nbsp;<a
                                                                href="SYS_MENUadd.aspx"><span class="STYLE_HEAD"></span></a> &nbsp;&nbsp;
                                                            &nbsp; &nbsp; &nbsp;</span><span class="STYLE_HEAD"> &nbsp;</span></div>
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
                   <div style="text-align: center">
                <asp:GridView ID="dwgridview_sys_modulerun" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="编号"  />
                        <asp:BoundField DataField="modulename" HeaderText="模块名称"  />
                        <asp:BoundField DataField="lastruntime" HeaderText="上次运行时间"  />
                   
                        <asp:BoundField DataField="runtimespan" HeaderText="运行时间间隔（分钟）"  />
                       <asp:TemplateField HeaderText="超时（分钟）" Visible="true">
                            <ItemTemplate>
                                <%# GetTimeOverInfo(Eval("ID").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                      
                    </Columns>
                   
                </asp:GridView>
            </div>
    </div>
    </form>
</body>
</html>
