<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginDJ.aspx.cs" Inherits="Login_Dj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
       <title>管理登陆 - 网络规划控制系统基础平台层管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=GB2312">
    <link href="base/style/main.css" type="text/css" rel="stylesheet">
    <style type="text/css">BODY {
	MARGIN: 0px
}
.bd {
	BORDER-RIGHT: #9db2d6 1px solid; BORDER-TOP: #9db2d6 1px solid; BORDER-LEFT: #9db2d6 1px solid; WIDTH: 185px; BORDER-BOTTOM: #9db2d6 1px solid; HEIGHT: 21px; BACKGROUND-COLOR: #ecf6ff
}
</style>

    <script language="Javascript">

function chklogin()
{
	df=document.loginfrm
	if(df.loginname.value==""){
		alert("用户名不能为空!");
		df.loginname.focus();
		return false;
	}	
	if(df.loginpass.value==""){
		alert("密码不能为空!");
		df.loginpass.focus();
		return false;
	}	
return true;
}
    </script>

    <meta content="MSHTML 6.00.2900.5969" name="GENERATOR">
    <style type="text/css" charset="utf-8">.firebugCanvas {
	BORDER-RIGHT: 0px; PADDING-RIGHT: 0px; BORDER-TOP: 0px; DISPLAY: none; PADDING-LEFT: 0px; LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: 0px; PADDING-TOP: 0px; BORDER-BOTTOM: 0px; POSITION: fixed; TOP: 0px; outline: 0
}
.firebugCanvas:unknown {
	content: ""
}
.firebugCanvas:unknown {
	content: ""
}
.firebugHighlight {
	BORDER-RIGHT: 0px; PADDING-RIGHT: 0px; BORDER-TOP: 0px; PADDING-LEFT: 0px; Z-INDEX: 2147483646; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: 0px; PADDING-TOP: 0px; BORDER-BOTTOM: 0px; POSITION: fixed; BACKGROUND-COLOR: #3875d7; outline: 0
}
.firebugHighlight:unknown {
	content: ""
}
.firebugHighlight:unknown {
	content: ""
}
.firebugLayoutBoxParent {
	BORDER-RIGHT: #e00 1px dashed; PADDING-RIGHT: 0px; BORDER-TOP: 0px; PADDING-LEFT: 0px; Z-INDEX: 2147483646; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: 0px; PADDING-TOP: 0px; BORDER-BOTTOM: #e00 1px dashed; POSITION: fixed; BACKGROUND-COLOR: transparent; outline: 0
}
.firebugRuler {
	BORDER-RIGHT: 0px; PADDING-RIGHT: 0px; BORDER-TOP: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: 0px; PADDING-TOP: 0px; BORDER-BOTTOM: 0px; POSITION: absolute; outline: 0
}
.firebugRuler:unknown {
	content: ""
}
.firebugRuler:unknown {
	content: ""
}
.firebugRulerH {
	BORDER-RIGHT: #bbbbbb 1px dashed; BORDER-TOP: #bbbbbb 1px solid; BACKGROUND: url(data:image/png,%89PNG%0D%0A%1A%0A%00%00%00%0DIHDR%00%00%13%88%00%00%00%0E%08%02%00%00%00L%25a%0A%00%00%00%04gAMA%00%00%D6%D8%D4OX2%00%00%00%19tEXtSoftware%00Adobe%20ImageReadyq%C9e%3C%00%00%04%F8IDATx%DA%EC%DD%D1n%E2%3A%00E%D1%80%F8%FF%EF%E2%AF2%95%D0D4%0E%C1%14%B0%8Fa-%E9%3E%CC%9C%87n%B9%81%A6W0%1C%A6i%9A%E7y%0As8%1CT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AATE9%FE%FCw%3E%9F%AF%2B%2F%BA%97%FDT%1D~K(%5C%9D%D5%EA%1B%5C%86%B5%A9%BDU%B5y%80%ED%AB*%03%FAV9%AB%E1%CEj%E7%82%EF%FB%18%BC%AEJ8%AB%FA'%D2%BEU9%D7U%ECc0%E1%A2r%5DynwVi%CFW%7F%BB%17%7Dy%EACU%CD%0E%F0%FA%3BX%FEbV%FEM%9B%2B%AD%BE%AA%E5%95v%AB%AA%E3E5%DCu%15rV9%07%B5%7F%B5w%FCm%BA%BE%AA%FBY%3D%14%F0%EE%C7%60%0EU%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5JU%88%D3%F5%1F%AE%DF%3B%1B%F2%3E%DAUCNa%F92%D02%AC%7Dm%F9%3A%D4%F2%8B6%AE*%BF%5C%C2Ym~9g5%D0Y%95%17%7C%C8c%B0%7C%18%26%9CU%CD%13i%F7%AA%90%B3Z%7D%95%B4%C7%60%E6E%B5%BC%05%B4%FBY%95U%9E%DB%FD%1C%FC%E0%9F%83%7F%BE%17%7DkjMU%E3%03%AC%7CWj%DF%83%9An%BCG%AE%F1%95%96yQ%0Dq%5Dy%00%3Et%B5'%FC6%5DS%95pV%95%01%81%FF'%07%00%00%00%00%00%00%00%00%00%F8x%C7%F0%BE%9COp%5D%C9%7C%AD%E7%E6%EBV%FB%1E%E0(%07%E5%AC%C6%3A%ABi%9C%8F%C6%0E9%AB%C0'%D2%8E%9F%F99%D0E%B5%99%14%F5%0D%CD%7F%24%C6%DEH%B8%E9rV%DFs%DB%D0%F7%00k%FE%1D%84%84%83J%B8%E3%BA%FB%EF%20%84%1C%D7%AD%B0%8E%D7U%C8Y%05%1E%D4t%EF%AD%95Q%BF8w%BF%E9%0A%BF%EB%03%00%00%00%00%00%00%00%00%00%B8vJ%8E%BB%F5%B1u%8Cx%80%E1o%5E%CA9%AB%CB%CB%8E%03%DF%1D%B7T%25%9C%D5(%EFJM8%AB%CC'%D2%B2*%A4s%E7c6%FB%3E%FA%A2%1E%80~%0E%3E%DA%10x%5D%95Uig%15u%15%ED%7C%14%B6%87%A1%3B%FCo8%A8%D8o%D3%ADO%01%EDx%83%1A~%1B%9FpP%A3%DC%C6'%9C%95gK%00%00%00%00%00%00%00%00%00%20%D9%C9%11%D0%C0%40%AF%3F%EE%EE%92%94%D6%16X%B5%BCMH%15%2F%BF%D4%A7%C87%F1%8E%F2%81%AE%AAvzr%DA2%ABV%17%7C%E63%83%E7I%DC%C6%0Bs%1B%EF6%1E%00%00%00%00%00%00%00%00%00%80cr%9CW%FF%7F%C6%01%0E%F1%CE%A5%84%B3%CA%BC%E0%CB%AA%84%CE%F9%BF)%EC%13%08WU%AE%AB%B1%AE%2BO%EC%8E%CBYe%FE%8CN%ABr%5Dy%60~%CFA%0D%F4%AE%D4%BE%C75%CA%EDVB%EA(%B7%F1%09g%E5%D9%12%00%00%00%00%00%00%00%00%00H%F6%EB%13S%E7y%5E%5E%FB%98%F0%22%D1%B2'%A7%F0%92%B1%BC%24z3%AC%7Dm%60%D5%92%B4%7CEUO%5E%F0%AA*%3BU%B9%AE%3E%A0j%94%07%A0%C7%A0%AB%FD%B5%3F%A0%F7%03T%3Dy%D7%F7%D6%D4%C0%AAU%D2%E6%DFt%3F%A8%CC%AA%F2%86%B9%D7%F5%1F%18%E6%01%F8%CC%D5%9E%F0%F3z%88%AA%90%EF%20%00%00%00%00%00%00%00%00%00%C0%A6%D3%EA%CFi%AFb%2C%7BB%0A%2B%C3%1A%D7%06V%D5%07%A8r%5D%3D%D9%A6%CAu%F5%25%CF%A2%99%97zNX%60%95%AB%5DUZ%D5%FBR%03%AB%1C%D4k%9F%3F%BB%5C%FF%81a%AE%AB'%7F%F3%EA%FE%F3z%94%AA%D8%DF%5B%01%00%00%00%00%00%00%00%00%00%8E%FB%F3%F2%B1%1B%8DWU%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*UiU%C7%BBe%E7%F3%B9%CB%AAJ%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5J%95*U%AAT%A9R%A5*%AAj%FD%C6%D4%5Eo%90%B5Z%ADV%AB%D5j%B5Z%ADV%AB%D5j%B5Z%ADV%AB%D5j%B5Z%ADV%AB%D5j%B5Z%ADV%AB%D5j%B5Z%ADV%AB%D5j%B5Z%ADV%AB%D5j%B5%86%AF%1B%9F%98%DA%EBm%BBV%AB%D5j%B5Z%ADV%AB%D5j%B5Z%ADV%AB%D5j%B5Z%ADV%AB%D5j%B5Z%ADV%AB%D5j%B5Z%ADV%AB%D5j%B5Z%ADV%AB%D5j%B5Z%AD%D6%E4%F58%01%00%00%00%00%00%00%00%00%00%00%00%00%00%40%85%7F%02%0C%008%C2%D0H%16j%8FX%00%00%00%00IEND%AEB%60%82) repeat-x; LEFT: 0px; WIDTH: 100%; BORDER-BOTTOM: #000000 1px solid; TOP: -15px; HEIGHT: 14px
}

UNKNOWN {
	LEFT: 0px
}
UNKNOWN {
	TOP: 0px
}
.firebugLayoutBox {
	BORDER-RIGHT: 0px; PADDING-RIGHT: 0px; BORDER-TOP: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: 0px; PADDING-TOP: 0px; BORDER-BOTTOM: 0px; outline: 0
}
.firebugLayoutBox:unknown {
	content: ""
}
.firebugLayoutBox:unknown {
	content: ""
}
.firebugLayoutBoxOffset {
	Z-INDEX: 2147483646; POSITION: fixed; opacity: 0.8
}
.firebugLayoutBoxMargin {
	BACKGROUND-COLOR: #edff64
}
.firebugLayoutBoxBorder {
	BACKGROUND-COLOR: #666666
}
.firebugLayoutBoxPadding {
	BACKGROUND-COLOR: slateblue
}
.firebugLayoutBoxContent {
	BACKGROUND-COLOR: skyblue
}
.firebugLayoutLine {
	BORDER-RIGHT: 0px; PADDING-RIGHT: 0px; BORDER-TOP: 0px; PADDING-LEFT: 0px; Z-INDEX: 2147483646; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: 0px; PADDING-TOP: 0px; BORDER-BOTTOM: 0px; BACKGROUND-COLOR: #000000; outline: 0; opacity: 0.4
}
.firebugLayoutLine:unknown {
	content: ""
}
.firebugLayoutLine:unknown {
	content: ""
}
.firebugLayoutLineLeft {
	WIDTH: 1px; POSITION: fixed; HEIGHT: 100%
}
.firebugLayoutLineRight {
	WIDTH: 1px; POSITION: fixed; HEIGHT: 100%
}
.firebugLayoutLineTop {
	WIDTH: 100%; POSITION: fixed; HEIGHT: 1px
}
.firebugLayoutLineBottom {
	WIDTH: 100%; POSITION: fixed; HEIGHT: 1px
}
.firebugLayoutLineTop {
	BORDER-TOP: #999999 1px solid; MARGIN-TOP: -1px
}
.firebugLayoutLineRight {
	BORDER-RIGHT: #999999 1px solid
}
.firebugLayoutLineBottom {
	BORDER-BOTTOM: #999999 1px solid
}
.firebugLayoutLineLeft {
	MARGIN-LEFT: -1px; BORDER-LEFT: #999999 1px solid
}
.fbProxyElement {
	BORDER-RIGHT: 0px; PADDING-RIGHT: 0px; BORDER-TOP: 0px; PADDING-LEFT: 0px; Z-INDEX: 2147483646; PADDING-BOTTOM: 0px; MARGIN: 0px; BORDER-LEFT: 0px; PADDING-TOP: 0px; BORDER-BOTTOM: 0px; POSITION: absolute; BACKGROUND-COLOR: transparent; outline: 0
}
</style>
</head>
<body bgcolor="#334599" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
      <br>
    <br>
    <br>
    <br>
    <table cellspacing="0" cellpadding="0" width="780" align="center" border="0">
        <tbody>
            <tr>
                <td width="452" height="60">
                    </td>
                <td width="328" height="60">
                    &nbsp;</td>
            </tr>
        </tbody>
    </table>
    <table cellspacing="0" cellpadding="0" width="780" align="center" border="0">
        <tbody>
            <tr>
                <td align="middle" width="511" background="Images/login/pic_09.gif" height="253">
                    <table cellspacing="0" cellpadding="0" width="100" border="0">
                        <tbody>
                            <tr>
                                <td>
                                    <img height="231" src="Images/login/img_1.jpg" width="442"></td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td width="269">
                    <table cellspacing="0" cellpadding="0" width="200" border="0">
                        <tbody>
                            <tr>
                                <td>
                                    <img height="5" src="Images/login/pic_04.gif" width="328"></td>
                            </tr>
                            <tr>
                                <td align="middle" background="Images/login/pic_05.gif" height="243">
                                    <table cellspacing="0" cellpadding="0" width="300" border="0">
                                        <tbody>
                                            <tr>
                                                <td align="middle">
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="middle">
                                                    <img height="18" src="Images/login/pic_07.gif" width="288"></td>
                                            </tr>
                                            <tr>
                                                <td align="middle" height="144">
                                                    
                                                        <table cellspacing="0" cellpadding="0" width="270" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="middle" width="59" height="40">
                                                                        账 号</td>
                                                                    <td width="211" height="40">
                                                                        <asp:TextBox ID="UserName" runat="server" Height="17px" name="UserName" Style="border-right: #153966 1px solid;
                                                                            border-top: #153966 1px solid; font-size: 12px; border-left: #153966 1px solid;
                                                                            color: #283439; border-bottom: #153966 1px solid;"
                                                                            TabIndex="1" Width="157px"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="middle" height="40">
                                                                        密 码</td>
                                                                    <td height="40">
                                                                        <asp:TextBox ID="Password" runat="server" Height="17px" name="Password" Style="border-right: #153966 1px solid;
                                                                            border-top: #153966 1px solid; font-size: 12px; border-left: #153966 1px solid;
                                                                            color: #283439; border-bottom: #153966 1px solid; "
                                                                            TabIndex="2" TextMode="Password" Width="157px"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="middle" height="40">
                                                                        &nbsp;</td>
                                                                    <td height="40">
                                                                        <asp:ImageButton ID="BT_SUBMIT" runat="server" ImageUrl="Images/login/login.gif"
                                                                            OnClick="BT_SUBMIT_Click" /></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                   
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img height="5" src="Images/login/pic_06.gif" width="328"></td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    <table cellspacing="0" cellpadding="0" width="780" align="center" border="0">
        <tbody>
            <tr>
                <td width="5" height="53">
                    <img height="116" src="Images/login/pic_01.gif" width="5"></td>
                <td background="Images/login/pic_02.gif">
                    <table cellspacing="0" cellpadding="0" width="758" border="0">
                        <tbody>
                            <tr>
                                <td align="middle" width="418" height="65">
                                    </td>
                                <td align="middle" width="16">
                                    &nbsp;</td>
                                <td align="left" width="324">
                                    </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td width="5">
                    <img height="116" src="Images/login/pic_03.gif" width="5"></td>
            </tr>
        </tbody>
    </table>
    <p>
        &nbsp;</p>
    </div>
    </form>
</body>
</html>
