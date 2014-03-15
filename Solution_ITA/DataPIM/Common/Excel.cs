using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using Microsoft.Office.Interop.Excel;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;

namespace CommonMethod
{
    public class Excel
    {
        public static void ExportExcel(GridView gv, System.Web.UI.Page page)
        {
            //一个Excel 工作表数个对象所构成的阶层架构
            //从Application 到Workbook 再到 Worksheet 
            //Application excelApp = new ApplicationClass();
            //Workbook excelBook = excelApp.Workbooks.Add();
            //Worksheet excelWorksheet = (WorksheetClass)excelBook.Worksheets[1];
            //取得当前激活的窗体 

            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            //System.IO.TextWriter oTextWriter
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
            gv.RenderControl(oHtmlTextWriter);
            HttpResponse hr = page.Response;
            hr.Clear();
            hr.Buffer = true;
            hr.Charset = "GB2312";
            hr.AppendHeader("Content-Disposition", "attachment;filename=FileName.xls");
            hr.ContentEncoding = System.Text.Encoding.UTF7;
            hr.ContentType = "application/ms-excel";
            hr.Output.Write(oHtmlTextWriter.ToString());
            hr.Flush();
            hr.End();
        }


        /// <summary>
        /// 将gridview表格的内容导出为excel表格
        /// </summary>
        /// <param name="page">page对象</param>
        /// <param name="gv">gridview对象</param>
        /// <param name="FileType">导出文档类型</param>
        /// <param name="FileName">文件名称</param>
        public static void ExportExcel(Page page, GridView gv, string FileType, string FileName)
        {
            page.Response.Charset = "GB2312";
            page.Response.ContentEncoding = System.Text.Encoding.UTF7;
            page.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
            page.Response.ContentType = FileType;
            page.EnableViewState = false;

            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            gv.RenderControl(hw);

            page.Response.Write(tw.ToString());
            page.Response.End();
        }

        /// <summary>
        /// 将gridview表格的内容导出为excel表格
        /// </summary>
        /// <param name="page">Page对象</param>
        /// <param name="hgc">HtmlGenericControl对象</param>
        /// <param name="FileType">导出文档类型</param>
        /// <param name="FileName">文件名称</param>
        public static void ExportExcel(Page page, HtmlGenericControl hgc, string FileType, string FileName)
        {
            page.Response.Charset = "GB2312";
            page.Response.ContentEncoding = System.Text.Encoding.UTF7;
            page.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
            page.Response.ContentType = FileType;
            page.EnableViewState = false;

            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            hgc.RenderControl(hw);

            page.Response.Write(tw.ToString());
            page.Response.End();
        }

        //// <summary>
　　　　/// 把DataTable内容导出伟excel并返回客户端
　　　　/// </summary>
        /// <param name="dgData">待导出的DataTable</param>
        /// <param name="excelfilename">导出的excel的文件名</param>
　　　　public static void DataTable2Excel(System.Data.DataTable dtData,string excelfilename)
　　　　{
　　　　　　System.Web.UI.WebControls.DataGrid dgExport = null;
　　　　　　// 当前对话
　　　　　　System.Web.HttpContext curContext = System.Web.HttpContext.Current;
　　　　　　// IO用于导出并返回excel文件
　　　　　　System.IO.StringWriter strWriter = null;
　　　　　　System.Web.UI.HtmlTextWriter htmlWriter = null;

　　　　　　if (dtData != null)
　　　　　　{
　　　　　　　　// 设置编码和附件格式
		        curContext.Response.Buffer = true;
　　　　　　　　curContext.Response.ContentType = "application/vnd.ms-excel";
　　　　　　　　curContext.Response.ContentEncoding =System.Text.Encoding.UTF8;
        
　　　　　　　　curContext.Response.Charset = "UTF-8";
                curContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(excelfilename, System.Text.Encoding.UTF8));
　　　　　　　　
　　　　　　　　// 导出excel文件
　　　　　　　　strWriter = new System.IO.StringWriter();
　　　　　　　　htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);

　　　　　　　　// 为了解决dgData中可能进行了分页的情况，需要重新定义一个无分页的DataGrid
　　　　　　　　dgExport = new System.Web.UI.WebControls.DataGrid();
　　　　　　　　dgExport.DataSource = dtData.DefaultView;
　　　　　　　　dgExport.AllowPaging = false;
　　　　　　　　dgExport.DataBind();

　　　　　　　　// 返回客户端
　　　　　　　　dgExport.RenderControl(htmlWriter);　　
　　　　　　　　curContext.Response.Write(strWriter.ToString());
　　　　　　　　curContext.Response.End();
　　　　　　}
　　　　}
    }
}
