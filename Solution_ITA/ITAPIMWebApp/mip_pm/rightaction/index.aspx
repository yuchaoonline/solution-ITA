<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="infodict_infodict_index" StylesheetTheme="SkinFile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="~/base/style/style.css" rel="stylesheet" type="text/css">
    
    <script language='javascript'> 
/*******以下内容可以修改***************/ 
var mname=new Array( 
"首 页", 
"修 改", 
"下 载", 
"删 除", 
"新 建", 
"刷 新" 
); 
//mname是菜单对应的名称，数组的个数必须与下面murl对应 


//murl是菜单对应的操作，可以是任意javascript代码但是要注意不要在里面输入\"，只能用' 
//如果要实现跳转可以这样window.location='url'; 
var ph=18,mwidth=50;//每条选项的高度,菜单的总宽度 
var bgc="#eee",txc="black";//菜单没有选中的背景色和文字色 
var cbgc="darkblue",ctxc="white";//菜单选中的选项背景色和文字色 

/****************以下代码请不要修改******************/ 
var mover="this.style.background='"+cbgc+"';this.style.color='"+ctxc+"';" 
var mout="this.style.background='"+bgc+"';this.style.color='"+txc+"';" 

function showMenu() 
{ 
mlay.style.display=""; 
mlay.style.pixelTop=event.clientY; 
mlay.style.pixelLeft=event.clientX; 
return false; 
} 

function showoff() 
{ 
mlay.style.display="none"; 
} 

function fresh() 
{
    var murl=new Array( 
    "window.open('http://www.cn5.cn','_blank','');", 
    "alert('修改');", 
    "alert('download');", 
    "alert('delete');", 
    "alert('new');", 
    "alert('refresh');" 
    ); 
    mlay.style.background=bgc; 
    mlay.style.color=txc; 
    mlay.style.width=mwidth; 
    mlay.style.height=mname.length*ph; 
    var h="<table width=100% height="+mname.length*ph+"px cellpadding=0 cellspacing=0 border=0>"; 
    var i=0; 
    for(i=0;i<mname.length;i++) 
    { 
    h+="<tr align=center height="+ph+" onclick=\""+murl[i]+"\" onMouseover=\""+mover+"\" onMouseout=\""+mout+"\"><td style='font-size:9pt;'>"+mname[i]+"</td></tr>"; 
    } 
    h+="</table>"; 
    mlay.innerHTML=h; 
} 
</script> 
    <script id="Infragistics" type="text/javascript">
<!--
function menu_NodeClick(treeId, nodeId, button){
    if(button==2)
    {
        fresh();
        showMenu();
    }
    else
    {
        var node=document.getElementById(nodeId);
        window.parent.frames["menuconfig_right"].location.href="edit.aspx?action=edit&node="+node.igTag;
    }
}function menu_KeyDown(treeId, keyCode){
    alert(keyCode);
}function menu_Drop(oTree, oNode, oDataTransfer, oEvent){
	alert(oEvent);
}// -->
</script>
</head>
<body onClick="showoff();"  onContextMenu="return false"> 
    <form id="form1" runat="server">
    
    <div style=" width:332px;text-align:center;">
        <br />
</div>
            <br />
        <div style=" text-align:center;">
    <asp:GridView ID="GridView1" runat="server" 
                Width="332px" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True" AllowSorting="True"  OnRowDataBound="GridView1_RowDataBound" >
                <Columns>
            
                     <asp:BoundField HeaderText="序号" DataField="ID" >
                                </asp:BoundField>
                                <asp:BoundField HeaderText="分类" DataField="parent" Visible="true">
                                </asp:BoundField>
                                <asp:BoundField HeaderText="模块名" DataField="moudlename">
                                </asp:BoundField>
                                 <asp:BoundField HeaderText="所属系统" DataField="sysname">
                                </asp:BoundField>
                               
                               
                                <asp:TemplateField HeaderText="操作">
                                <ItemStyle HorizontalAlign ="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/mip_pm/Ima/menu/find_button.gif"  ID="btn_nextlevel" runat="server"   CssClass="inputedit"  CommandArgument='<%# Eval("ID") %>' OnCommand="btn_nextlevel_Command"   />
                                    </ItemTemplate>
                                </asp:TemplateField>
                </Columns>
            </asp:GridView>
    </div>
    </form>
</body>

</html>