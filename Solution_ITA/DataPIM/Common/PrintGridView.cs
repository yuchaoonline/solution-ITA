/*
 * 
 * 
 * Function:GridView控件打印类
 * Author:Mr Chou
 * Data:2008-01-19
 * 
 * 
 * */
using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;

/***********************
 * 
 * GridView控件通用打印类 
 * 
 ***********************/
namespace CommonMethod
{
    public class PrintGridView
    {
        private Font printFont = new Font("宋体", 10);//当前要打印文本的字体及字号
        private int printLines = 50; //当前页共要分成多少行. 
        private int printRecordNumber = 45;//当前页共要打印的记录的行数

        private System.Web.UI.WebControls.GridView gridviewSource;
        private PrintPageEventArgs ev;
        private PrintDocument printGridView;
        private PrintPreviewDialog printPriview;
        private PageSetupDialog pageSetup;
        private double printScale = 1;//当前要打印的数据与GridView控件内数据的比例 

        private DataColumn gridviewColumn;
        private DataRow gridviewRow;
        private DataTable gridviewTable;

        private int Cols;//当前要打印的列
        private int Rows;//当前要打印的行   

        private int ColsCount;//当前GridView共有多少列

        private int printingLineNumber = 0;//当前正要打印的行号
        private int pageRecordNumber;//当前要所要打印的记录行数,由计算得到.

        private int x_unit;//表的基本单位
        private int y_unit;

        private int printingPageNumber = 0;//正要打印的页号 
        private int pageNumber;//共需要打印的页数 
        private int printRecordLeave;//当前还有多少页没有打印
        private int printRecordComplete = 0;//已经打印完的记录数

        public PrintGridView()
        {
 
        }

        public PrintGridView(System.Web.UI.WebControls.GridView TableSource)
        {
            this.gridviewSource = TableSource;
            this.gridviewTable = new DataTable();
            this.gridviewTable = (DataTable)this.gridviewSource.DataSource;
            this.ColsCount = this.gridviewSource.Columns.Count;
        }

        //用户自定义字体及字号
        public Font PrintFont
        {
            set { this.printFont = value; }
            get { return this.printFont; }
        }
        public int PrintRecordNumber
        {
            set { this.printRecordNumber = value; }
            get { return this.printRecordNumber; }
        }
        public void Print()
        {
            try
            {
                this.printGridView = new System.Drawing.Printing.PrintDocument();
                this.printGridView.PrintPage += new PrintPageEventHandler(PrintGridView_PrintPage);
                // 'PrintDataTable.Print() 
                //'打印机设置对话框 
                this.pageSetup = new PageSetupDialog();
                this.pageSetup.PageSettings = this.printGridView.DefaultPageSettings;
                if (this.pageSetup.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // '当前页是横向还是纵向打印 
                //'计算当前页总共可以打印的行数 
                if (this.printGridView.DefaultPageSettings.Landscape == false)
                {
                    this.printLines = this.printGridView.DefaultPageSettings.PaperSize.Height / (this.printFont.Height + 5);
                }
                else
                {
                    this.printLines = this.printGridView.DefaultPageSettings.PaperSize.Width / (this.printFont.Height + 5);
                }

                //如果用户选择自定义纸张大小打印,则按B5纸打印,不管实际纸张大小 
                if (this.printGridView.DefaultPageSettings.PaperSize.PaperName.ToString() == "custom")
                { }

                this.printPriview = new PrintPreviewDialog();
                this.printPriview.Document = this.printGridView;
                this.printPriview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex.ToString());
            }
        }


        public void PrintGridView_PrintPage(object sender, PrintPageEventArgs ev)
        {
             //'A4纸 A4 纸，210 x 297 毫米。 
             //'B5纸 B5 纸，182 x 257 毫米。 
            string strPrint;//当前要打印的文本 
            SolidBrush drawBrush = new SolidBrush(Color.Blue);//当前画笔颜色
            int x=0;//当前要打印的文本的横坐标 
            int y=0;//当前要打印的文本的列坐标 
            PointF drawPoint = new PointF(x, y);

            int rowCount;//当前要打印的行
            this.printRecordLeave = this.gridviewTable.Rows.Count - this.printRecordComplete;//还有多少条记录没有打印
            this.pageNumber = this.printRecordLeave / this.printRecordNumber;//共需要打印的页数
            this.printingPageNumber = 0;//因为每打印一个新页都要计算还有多少页没有打印所以以打印的页数初始为0

            if (this.printGridView.DefaultPageSettings.Landscape == true)
            {
                this.x_unit = this.printGridView.DefaultPageSettings.PaperSize.Height / (this.gridviewTable.Columns.Count + 2);
                this.y_unit = this.printGridView.DefaultPageSettings.PaperSize.Width / this.printLines;
            }
            else
            {
                this.x_unit = this.printGridView.DefaultPageSettings.PaperSize.Width / (this.gridviewTable.Columns.Count + 2);
                this.y_unit = this.printGridView.DefaultPageSettings.PaperSize.Height / this.printLines;
            }
            //计算,余下的记录条数是否还可以在一页打印,不满一页时为假 
            if (this.gridviewTable.Rows.Count - this.printingPageNumber * this.printRecordNumber >= this.printRecordNumber)
            {
                this.pageRecordNumber = this.printRecordNumber;
            }
            else
            {
                this.pageRecordNumber = (this.gridviewTable.Rows.Count - this.printingPageNumber * this.printRecordNumber) % this.printRecordNumber;
            }


            while (this.printingPageNumber <= this.pageNumber)
            {
                //文档标题----------------打印开始 
                strPrint = this.gridviewSource.Caption;//文档标题 
                drawPoint = new PointF(this.x_unit, this.y_unit);
                this.ev.Graphics.DrawString(strPrint, printFont, drawBrush, drawPoint);
                //文档标题----------------打印结束

                //得到GridView的所有列名
                string[] columnText = new string[this.gridviewTable.Columns.Count];
                int iTable;

                for (this.Cols = 0; this.Cols < this.gridviewTable.Columns.Count; this.Cols++)
                {
                    columnText[this.Cols] = this.gridviewTable.Columns[this.Cols].ToString();
                    drawPoint = new PointF(this.x_unit * (this.Cols + 1), this.y_unit * 2);
                    this.ev.Graphics.DrawString(columnText[this.Cols], this.printFont, drawBrush, drawPoint);
                }

                drawPoint = new PointF(this.x_unit, this.y_unit * 2);
                DrawLine(drawPoint, this.ev);//画线
                //结束---------------------得到GridView的所有列名 

                int printingLine = 0;//当前页面已经打印的记录行数

                //用于确定是否换页的标记
                string strUpData = "";//当前数据的前一个数据
                string strNonce = ""; //当前数据
                while (printingLine < this.pageRecordNumber)
                {
                    this.gridviewRow = this.gridviewTable.Rows[this.printRecordComplete];//确定要当前要打印的记录的行号
                    for (this.Cols = 0; this.Cols < this.gridviewTable.Columns.Count; this.Cols++)
                    {
                        drawPoint.X = this.x_unit * (this.Cols + 1);
                        drawPoint.Y = this.y_unit * (printingLine + 1 + 2);

                        if (this.Cols == 0)//所要根据此列的数据分页
                        {
                            if (strUpData != "")
                            {
                                if (strUpData != this.gridviewRow[columnText[0]].ToString())
                                {
                                    this.ev.HasMorePages = true;
                                    return;
                                }
                            }
                        }
                        this.ev.Graphics.DrawString(this.gridviewRow[columnText[this.Cols]].ToString(), this.printFont, drawBrush, drawPoint);
                        strUpData = this.gridviewRow[columnText[0]].ToString();//当前行数据打印完成后,将打记录的第一列保存,(也可不用此语句,只为明确) 
                    }

                    drawPoint.X = this.x_unit + 1;
                    drawPoint.Y = this.y_unit * (printingLine + 1 + 2);
                    DrawLine(drawPoint, this.ev);

                    printingLine += 1;
                    this.printRecordComplete += 1;

                    //打印完最后一条记录后结束打印. 
                    //'如:当前有500条记录.从0开始打印,实际打印的为第一条记录.则打印500条时实际的是第501条记录.也就是最后一条 
                    //'datagridtable.rows.count得到就是表内的实际记录条数,共有多少条记录(从1开始),当 
                    //'printrecordcomplete>=datagridtable.rows.count也就是当前已经打印到了500条,加1后将要打印第501条,越界,则结束.
                    if (this.printRecordComplete >= this.gridviewTable.Rows.Count)
                    {
                        this.ev.HasMorePages = false;
                        return;
                    }
                }
                this.printingPageNumber += 1;
                if (this.printingPageNumber > this.pageNumber)
                {
                    this.ev.HasMorePages = false;
                }
                else
                {
                    this.ev.HasMorePages = true;
                    return;
                }
            }
        }


        //画线 只必指定当前行的打印文字的开始位置就可,x,y为当前行文字的打印位置 
        public void DrawLine(PointF point, PrintPageEventArgs ev)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            this.ev.Graphics.DrawLine(blackPen, point.X, point.Y + this.printFont.Height, point.X * (this.ColsCount + 1), point.Y + this.printFont.Height);
        }
    }
}
