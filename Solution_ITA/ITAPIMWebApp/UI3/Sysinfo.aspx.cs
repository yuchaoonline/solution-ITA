using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UI3_Sysinfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            GetSysInf();
        }
    }

    //获取系统信息的方法
    protected void GetSysInf()
    {
        //获取操作系统类型
        string qDrives = Environment.OSVersion.ToString();
        this.TB_qDrives.Text = qDrives;
        //获取系统文件夹
        string qSystemDir = Environment.SystemDirectory.ToString();
        this.TB_qSystemDir.Text = qSystemDir;
        /*获取映射到进程上下文的物理内存量，通过这一内存映射量可以了解ASP.NET程序在运行时需要多少系统物理内存，有助于更好的规划我们的整个应用,因为物理内存量是以Byte为单位的，所以我们将此数值除以1024，可以得到单位为KB的物理内存量*/
        string qMo = (Environment.WorkingSet / 1024).ToString();
        this.TB_qMo.Text = qMo;
        //获取当前目录（即该进程从中启动的目录）的完全限定路径
        string qCurDir = Environment.CurrentDirectory.ToString();
        this.TB_qCurDir.Text = qCurDir;
        //获取主机的网络域名
        string qDomName = Environment.UserDomainName.ToString();
        this.TB_qDomName.Text = qDomName;
        //获取系统启动后经过的毫秒数
        int qTick = Environment.TickCount;
        this.TB_qTick.Text = qTick.ToString();
        //计算得到系统启动后经过的分钟数
        qTick = qTick/60000;
        //获取机器名
        string qMachine = Environment.MachineName;
        this.TB_qMachine.Text = qMachine;
        //获取运行当前进程的用户名
        string qUser = Environment.UserName;
        this.TB_qUser.Text = qUser;
        /*检索此计算机上格式为"＜驱动器号＞:\"的逻辑驱动器的名称，返回字符串数组，这是下一步操作的关键所在*/
        string[]  achDrives = System.IO.Directory.GetLogicalDrives();
        //获取此字符串数组的维数，确定有多少个逻辑驱动器
        int nNumOfDrives = achDrives.Length;
        string TB_achDrives_info="";
        for(int i = 0; i<achDrives.Length ; i++)
        {
            TB_achDrives_info+=achDrives[i]+"磁盘--";
        }
        TB_achDrives.Text = TB_achDrives_info;
        TB_achDrives_num.Text = nNumOfDrives.ToString();
    }


}
