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
using PageBaseFun;

public partial class UI3_Left : System.Web.UI.Page
{
    protected void GetScriptInfo()
    {
        string sql_str="<script language=\"JavaScript\"> ";
        sql_str+="function showmenu(strID){ ";
        sql_str+="    var i; ";
        sql_str+="    for(i=1;i<=3;i++){ ";
        sql_str+="        var lay; ";
        sql_str+="            lay = eval('lay' + i); ";
        sql_str+="            if (lay.style.display==\"block\" && lay!=eval(strID)){ ";
        sql_str+="                   lay.style.display = \"none\"; ";
        sql_str+="               } ";
        sql_str+="            } ";
        sql_str+="        if (strID.style.display==\"none\"){ ";
        sql_str+="              strID.style.display = \"block\"; ";
        sql_str+="            }else{ ";
        sql_str+="                 strID.style.display = \"none\"; ";
        sql_str+="                 }  ";
        sql_str+="         }  ";
        sql_str += "         </script>";

        Response.Write(sql_str);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LB_INDEX.Text = this.BindData();
    }

    private string GetHeadData(string p_headstr,int p_index)
    {
        string ret_str="";
        ret_str +="<tr>"
                +"<td height=\"23\" background=\"images/main_34.gif\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">"
                +"<tr>"
                +"<td width=\"9%\">&nbsp;</td>"
                +"<td width=\"83%\"  onclick=showmenu(lay"+p_index.ToString()+")><div align=\"center\" class=\"STYLE5\">"+p_headstr+"</div></td>"
                +"<td width=\"8%\">&nbsp;</td>"
                +"</tr>"
                +"</table></td>"
                +"</tr>";
        return ret_str;
    }

    private string GetSubHeadData(int p_index)
    {
        string ret_str="";
              ret_str+="<tr  id='lay"+p_index.ToString()+"' style=\"display:block;\">";
              ret_str+="<td valign=\"top\">";
              ret_str+="<div align=\"center\">"
                     +"<table width=\"82%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">";
        return ret_str;
    }

    private string GetSubItemData(string p_url,string p_name,string p_img)
    {
        string ret_str="";
        ret_str+="<tr>"
          +"<td height=\"38\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">"
          +"  <tr>"
          + "    <td width=\"33\" height=\"28\"><img src=\"" + p_img + "\" width=\"28\" height=\"28\"></td>"
          +"    <td width=\"99\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">"
          +"        <tr>"
          +"          <td height=\"23\" class=\"STYLE4\" style=\"cursor:hand\" onMouseOver=\"this.style.backgroundImage='url(images/tab_bg.gif)';this.style.borderStyle='solid';this.style.borderWidth='1';borderColor='#adb9c2'; \"onmouseout=\"this.style.backgroundImage='url()';this.style.borderStyle='none'\"><a target=\"rightframe\" class=\"n\" href=\""+p_url+"\">"+p_name+"</a></td>"
          +"        </tr>"
          +"    </table></td>"
          +"  </tr>"
          +"</table></td>"
          +"</tr>";
        return ret_str;
    }

    private string GetSubEndData()
    {
         string ret_str="";
            ret_str+="</table>"
                   +"</div></td>"
                   +"</tr>";
         return ret_str; 
    }



    private string BindData()
    {
        if (Session["userobj"] == null)
        {
            return "请先登陆";
        }
        user userobj = (user)Session["userobj"];

        ///////////////////////////////////
        string sql_str = "select id,moudlename from sys_menu t where syslevel=1 and version=2 order by id";
        DataSet ds = GetDataSetBySql(sql_str);
        string allinfos = "";
        if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string p_headstr = ds.Tables[0].Rows[i]["moudlename"].ToString();
                int p_index  = i;
                string p_moudleidstr = ds.Tables[0].Rows[i]["id"].ToString();
                string sub_allinfos = "";
                sub_allinfos += GetHeadData(p_headstr, p_index);
                sub_allinfos += GetSubHeadData(p_index);
                string isof_sub_allinfos = GetIndexInfo(p_moudleidstr, userobj.rolemenulist);
                sub_allinfos += isof_sub_allinfos;
                sub_allinfos += GetSubEndData();

                if (isof_sub_allinfos != "")
                {
                    allinfos += sub_allinfos;
                }
            }
        }
        return allinfos;
    }

    private string GetIndexInfo(string index_str, ArrayList p_rolemenulist)
    {
        string sql_str = "select id,moudlename,url,img from sys_menu t where syslevel=2  and version=2  and parent='" + index_str + "' order by id";
        DataSet ds = GetDataSetBySql(sql_str);
        string allinfos = "";
        if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string id_str = ds.Tables[0].Rows[i]["id"].ToString();
                if (Isinlist(p_rolemenulist, id_str) == true)
                {
                    string moudlename = ds.Tables[0].Rows[i]["moudlename"].ToString();
                    string url = ds.Tables[0].Rows[i]["url"].ToString();
                    string img = ds.Tables[0].Rows[i]["img"].ToString();
                    allinfos += GetSubItemData(url, moudlename, img);
                }
            }
        }
        return allinfos;
    }

    private bool Isinlist(ArrayList p_rolemenulist, string p_menuid)
    {
        for (int i = 0; i < p_rolemenulist.Count; i++)
        {
            if (p_rolemenulist[i].ToString().CompareTo(p_menuid) == 0)
                return true;
        }
        return false;
    }

    private DataSet GetDataSetBySql(string p_sql)
    {
        return PageDBHelper.GetDataSetBySql(p_sql);
    }


}
