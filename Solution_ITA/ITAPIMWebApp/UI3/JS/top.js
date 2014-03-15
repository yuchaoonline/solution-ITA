// JScript 文件

function refreshPage()
{
    window.parent.frames["mainFrame"].frames["rightframe"].location.reload();
}


function forwardPage()
{

    history.forward();
}

function backPage()
{
    history.back();
}

function firstPage()
{
    window.parent.frames["mainFrame"].frames["rightframe"].location.href='Sysinfo.aspx';
}

function helpPage()
{
    window.parent.frames["mainFrame"].frames["rightframe"].location.href='help.htm'; 
}

function passPage()
{
    window.parent.frames["mainFrame"].frames["rightframe"].location.href='../mip_pm/rightmanage/UserPass.aspx'; 
}

function userPage()
{
    window.parent.frames["mainFrame"].frames["rightframe"].location.href='../mip_pm/rightmanage/UserInfo.aspx'; 
}

function quitPage()
{
    if (confirm('确认要离开本系统?'))
    {
        window.parent.location.href='../UI3/Quit.aspx';
    }
}

function LeftRightControl()
{
    var menuleftobj = document.getElementById("menuleft")
    if(menuleftobj.style.width=='147px')
    {
        menuleftobj.style.width='1px';
    }
    else
    {
        menuleftobj.style.width='147px';
    }
}