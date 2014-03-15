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
        #region ���ݱ���
        public void CopyDataTable(DataTable dtDestination, DataTable dtSource)
        {
            dtDestination.Clear();
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {

                dtDestination.Rows.Add(dtSource.Rows[i].ItemArray);
            }
        }
        #endregion

        #region ��DataSet���ݼ��е����ݵ�����Excel��
        public static bool ExportDataFromDataSetToExcel(DataSet source, string fileName)
        {
            bool fileSaved = false; //�Ƿ񱣴�ɹ�
            int rowIndex = 1;//����ʼ����
            int colIndex = 1;//����ʼ����
            if (source == null) return false;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("�޷�����Excel���󣬿������Ļ���δ��װExcel");
                return false;
            }
            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet;
       
            for (int TabIndex = 0; TabIndex < source.Tables.Count; TabIndex++)
            {
                worksheet = (Excel.Worksheet)workbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);//ȡ��sheet1
                worksheet.Name = source.Tables[TabIndex].TableName;
                //д���ֶ�
                for (int i = 0; i < source.Tables[TabIndex].Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = source.Tables[TabIndex].Columns[i].ColumnName;
                }
                //���ñ����ʽ


                /*range = worksheet.get_Range(worksheet.Cells[1, 1] as Excel.Range, worksheet.Cells[1, source.Tables[TabIndex].Columns.Count] as Excel.Range);
                
                 range.Interior.ColorIndex = 15;
                 range.Font.Bold = true;
                 */
                //д����ֵ
                rowIndex = 1;
                foreach (DataRow row in source.Tables[TabIndex].Rows)
                {
                    rowIndex++;
                    colIndex = 0;
                    foreach (DataColumn col in source.Tables[TabIndex].Columns)
                    {
                        colIndex++;
                        if (col.DataType == System.Type.GetType("System.String"))//�����Ƿ����ַ���
                        {
                            worksheet.Cells[rowIndex, colIndex] = "'" + row[col.ColumnName].ToString();
                        }
                        else if (col.DataType == System.Type.GetType("System.DateTime"))//�����Ƿ���ʱ������
                        {
                            worksheet.Cells[rowIndex, colIndex] = (Convert.ToDateTime(row[col.ColumnName].ToString())).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            worksheet.Cells[rowIndex, colIndex] = row[col.ColumnName].ToString();
                        }
                    }
                }
                //�������������ʽ
                /*range = worksheet.get_Range(worksheet.Cells[1, 1] as Excel.Range, worksheet.Cells[source.Tables[TabIndex].Rows.Count + 1, source.Tables[TabIndex].Columns.Count] as Excel.Range);
                range.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;//�����ַ��͵��ֶθ�ʽΪ���ж���
                range.Borders.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
                range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                range.Borders.Weight = Excel.XlBorderWeight.xlThin;
                range.Select();//�Զ���Ӧ��С
               
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
                MessageBox.Show("�����ļ�ʱ����,�ļ����������򿪣�\n" + ex.Message);
            }
            xlApp.Quit();
            GC.Collect();//ǿ������
            return fileSaved;
        }
        #endregion

        #region ��DataTable���ݱ��е����ݵ�����Excel��
        public static bool ExportDataFromDataTableToExcel(DataTable source, string fileName)
        {
            bool fileSaved = false; //�Ƿ񱣴�ɹ�
            int rowIndex = 1;//����ʼ����
            int colIndex = 1;//����ʼ����
            if (source == null) return false;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("�޷�����Excel���󣬿������Ļ���δ��װExcel");
                return false;
            }
            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet;
            worksheet = (Excel.Worksheet)workbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);//ȡ��sheet1
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
                    if (col.DataType == System.Type.GetType("System.String"))//�����Ƿ����ַ���
                    {
                        worksheet.Cells[rowIndex, colIndex] = "'" + row[col.ColumnName].ToString();
                    }
                    else if (col.DataType == System.Type.GetType("System.DateTime"))//�����Ƿ���ʱ������
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
                MessageBox.Show("�����ļ�ʱ����,�ļ����������򿪣�\n" + ex.Message);
            }
            xlApp.Quit();
            GC.Collect();//ǿ������
            return fileSaved;
        }
        #endregion

        #region ��Excel�е����ݵ��뵽DataTable��

        public static bool ImportDataFromExcelToDataTable(DataTable dt_des, string fileName, string workSheetName)
        {
            try
            {
                //string con = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + fileName + ";Extended properties=\"Excel 12.0;Imex=1;HDR=Yes;\"";

                string con = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + fileName + ";Extended Properties=Excel 8.0";///��������,��ַΪp_excelfilename���ݵĵ�ַ
            
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
                    MessageBox.Show("��������Ӧ�����ݱ�");
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
            string strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + p_excelfilename + ";Extended Properties=Excel 8.0";///��������,��ַΪp_excelfilename���ݵĵ�ַ
            OleDbConnection Conn = new OleDbConnection(strCon);
            string command = " SELECT * FROM [" + p_sheetname + "$]";   //SQL�������,����˵:ȡ���������ݴ�Sheet1
            Conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(command, Conn);
            //�����µ����ݼ�
            adapter.Fill(dataset, "[" + p_sheetname + "$]");            //������ݼ�
            Conn.Close();
            adapter.Dispose();
            return dataset;
        }

        #endregion

        #region  CSV�ĵ��뵼��
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

                //д��������
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data += dt.Columns[i].ColumnName.ToString();
                    if (i < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);

                //д����������
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
