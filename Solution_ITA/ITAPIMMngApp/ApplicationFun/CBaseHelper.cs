using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Data.Odbc;

namespace ITAMngApp.ApplicationFun
{
    public class CExcelBaseHelper
    {
        #region 数据表复制
        public void CopyDataTable(DataTable dtDestination, DataTable dtSource)
        {
            dtDestination.Clear();
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {

                dtDestination.Rows.Add(dtSource.Rows[i].ItemArray);
            }
        }
        #endregion

        #region 将DataSet数据集中的数据导出到Excel中
        public static bool ExportDataFromDataSetToExcel(DataSet source, string fileName)
        {
            bool fileSaved = false; //是否保存成功
            int rowIndex = 1;//行起始坐标
            int colIndex = 1;//列起始坐标
            if (source == null) return false;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return false;
            }
            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet;
       
            for (int TabIndex = 0; TabIndex < source.Tables.Count; TabIndex++)
            {
                worksheet = (Excel.Worksheet)workbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);//取得sheet1
                worksheet.Name = source.Tables[TabIndex].TableName;
                //写入字段
                for (int i = 0; i < source.Tables[TabIndex].Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = source.Tables[TabIndex].Columns[i].ColumnName;
                }
                //设置标题格式


                /*range = worksheet.get_Range(worksheet.Cells[1, 1] as Excel.Range, worksheet.Cells[1, source.Tables[TabIndex].Columns.Count] as Excel.Range);
                
                 range.Interior.ColorIndex = 15;
                 range.Font.Bold = true;
                 */
                //写入数值
                rowIndex = 1;
                foreach (DataRow row in source.Tables[TabIndex].Rows)
                {
                    rowIndex++;
                    colIndex = 0;
                    foreach (DataColumn col in source.Tables[TabIndex].Columns)
                    {
                        colIndex++;
                        if (col.DataType == System.Type.GetType("System.String"))//数据是否是字符串
                        {
                            worksheet.Cells[rowIndex, colIndex] = "'" + row[col.ColumnName].ToString();
                        }
                        else if (col.DataType == System.Type.GetType("System.DateTime"))//数据是否是时间日期
                        {
                            worksheet.Cells[rowIndex, colIndex] = (Convert.ToDateTime(row[col.ColumnName].ToString())).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            worksheet.Cells[rowIndex, colIndex] = row[col.ColumnName].ToString();
                        }
                    }
                }
                //设置数据区域格式
                /*range = worksheet.get_Range(worksheet.Cells[1, 1] as Excel.Range, worksheet.Cells[source.Tables[TabIndex].Rows.Count + 1, source.Tables[TabIndex].Columns.Count] as Excel.Range);
                range.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;//设置字符型的字段格式为居中对齐
                range.Borders.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
                range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                range.Borders.Weight = Excel.XlBorderWeight.xlThin;
                range.Select();//自动适应大小
               
               // range.AutoFit();
                 */
            }
            try
            {
                workbook.Saved = true;
                workbook.SaveCopyAs(fileName);
                fileSaved = true;
            }
            catch (Exception ex)
            {
                fileSaved = false;
                MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            return fileSaved;
        }
        #endregion

        #region 将DataTable数据表中的数据导出到Excel中
        public static bool ExportDataFromDataTableToExcel(DataTable source, string fileName)
        {
            bool fileSaved = false; //是否保存成功
            int rowIndex = 1;//行起始坐标
            int colIndex = 1;//列起始坐标
            if (source == null) return false;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return false;
            }
            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet;
            worksheet = (Excel.Worksheet)workbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);//取得sheet1
            worksheet.Name = source.TableName;
            for (int i = 0; i < source.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = source.Columns[i].ColumnName;
            }
            foreach (DataRow row in source.Rows)
            {
                rowIndex++;
                colIndex = 0;
                foreach (DataColumn col in source.Columns)
                {
                    colIndex++;
                    if (col.DataType == System.Type.GetType("System.String"))//数据是否是字符串
                    {
                        worksheet.Cells[rowIndex, colIndex] = "'" + row[col.ColumnName].ToString();
                    }
                    else if (col.DataType == System.Type.GetType("System.DateTime"))//数据是否是时间日期
                    {
                        worksheet.Cells[rowIndex, colIndex] = (Convert.ToDateTime(row[col.ColumnName].ToString())).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        worksheet.Cells[rowIndex, colIndex] = row[col.ColumnName].ToString();
                    }
                }
            }
            try
            {
                workbook.Saved = true;
                workbook.SaveCopyAs(fileName);
                fileSaved = true;
            }
            catch (Exception ex)
            {
                fileSaved = false;
                MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            return fileSaved;
        }
        #endregion

        #region 将Excel中的数据导入到DataTable中

        public static bool ImportDataFromExcelToDataTable(DataTable dt_des, string fileName, string workSheetName)
        {
            try
            {
                //string con = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + fileName + ";Extended properties=\"Excel 12.0;Imex=1;HDR=Yes;\"";

                string con = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + fileName + ";Extended Properties=Excel 8.0";///建立连接,地址为p_excelfilename传递的地址
            
                OleDbConnection oledbconnection1 = new OleDbConnection(con);
                oledbconnection1.Open();
                DataTable dt1 = new DataTable();
                bool exist = false;
                dt1 = oledbconnection1.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                foreach (DataRow dr in dt1.Rows)
                {

                    if (dr["TABLE_NAME"].ToString() == "" + workSheetName + "$")
                    {
                        exist = true;
                        break;
                    }
                }
                dt1.Dispose();
                if (exist)
                {
                    string str = "Select * from [" + workSheetName + "$]";
                    OleDbDataAdapter oda = new OleDbDataAdapter(str, con);
                    dt_des.Clear();
                    oda.FillSchema(dt_des, SchemaType.Mapped);
                    oda.Fill(dt_des);
                    oledbconnection1.Close();
                    return true;
                }
                else
                {
                    oledbconnection1.Close();
                    MessageBox.Show("不存在相应的数据表");
                    return false;
                }


            }
            catch
            {
                return false;
            }
            finally
            {

            }
        }

        public static DataSet GetImportExcelDataSet(string p_excelfilename, string p_sheetname)
        {
            DataSet dataset = new DataSet();
            string strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + p_excelfilename + ";Extended Properties=Excel 8.0";///建立连接,地址为p_excelfilename传递的地址
            OleDbConnection Conn = new OleDbConnection(strCon);
            string command = " SELECT * FROM [" + p_sheetname + "$]";   //SQL操作语句,就是说:取得所有数据从Sheet1
            Conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(command, Conn);
            //建立新的数据集
            adapter.Fill(dataset, "[" + p_sheetname + "$]");            //填充数据集
            Conn.Close();
            adapter.Dispose();
            return dataset;
        }

        #endregion

        #region  CSV的导入导出
        public static DataTable ImportLoadCSV(string filename)
        {
            DataTable dtcsv = new DataTable();
            string strConn = @"Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=";
            strConn += ";Extensions=asc,csv,tab,txt;";
            OdbcConnection objConn = new OdbcConnection(strConn);
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from " + filename, strConn);

            if (filename != "")
            {
                try
                {
                    dtcsv.Clear();
                    dtcsv.Columns.Clear();
                    adapter.Fill(dtcsv);
                    return dtcsv;
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
                finally
                {

                }
            }
            else
                return null;

        }

        public static bool ExputSaveCSV(DataTable dt, string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                FileStream fs = new FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                string data = "";

                //写出列名称
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data += dt.Columns[i].ColumnName.ToString();
                    if (i < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);

                //写出各行数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        data += dt.Rows[i][j].ToString();
                        if (j < dt.Columns.Count - 1)
                        {
                            data += ",";
                        }
                    }
                    sw.WriteLine(data);
                }

                sw.Close();
                fs.Close();
                return true;
            }
            catch (Exception e1)
            {
                return false;
            }
            finally
            {
 
            }
        }

        #endregion


    }
}
