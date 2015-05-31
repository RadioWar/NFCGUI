/******************************************************************
* 创 建 人：  SamWang
* 创建时间：  2012-3-16 9:59
* 描    述：
*             导入导出Excel通用类
* 版    本：  V1.0      
* 环    境：  VS2005
******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
//using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Data.OleDb;

namespace NFCGui.Common
{
    public class ExcelIO : IDisposable
    {
        #region Constructors
        private ExcelIO()
        {
            status=IsExistExecl() ? 0 : -1;
        }

        public static ExcelIO GetInstance()
        {
            //if(instance == null)
            //{
            //    lock (syncRoot)
            //    {
            //         if(instance == null)
            //         {
            //            instance = new ExcelIO();
            //         }
            //    }
            //}
            //return instance;
            return new ExcelIO();
        }

        #endregion

        #region Fields
        private static ExcelIO instance;
        private static readonly object syncRoot=new object();
        private string returnMessage;
        private Excel.Application xlApp;
        private Excel.Workbooks workbooks=null;
        private Excel.Workbook workbook=null;
        private Excel.Worksheet worksheet=null;
        private Excel.Range range=null;
        private int status=-1;
        private bool disposed=false;//是否已经释放资源的标记
        #endregion

        #region Properties
        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMessage
        {
            get
            {
                return returnMessage;
            }
        }

        /// <summary>
        /// 状态:0-正常，-1-失败 1-成功
        /// </summary>
        public int Status
        {
            get
            {
                return status;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 判断是否安装Excel
        /// </summary>
        /// <returns></returns>
        protected bool IsExistExecl()
        {
            try
            {
                xlApp=new Excel.Application();
                if (xlApp == null)
                {
                    returnMessage="无法创建Excel对象，可能您的计算机未安装Excel!";
                    return false;
                }
            }
            catch (Exception ex)
            {
                returnMessage="请正确安装Excel！";
                //throw ex;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获得保存路径
        /// </summary>
        /// <returns></returns>
        //public static string SaveFileDialog()
        //{
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.DefaultExt = "xls";
        //    sfd.Filter = "Excel文件(*.xls)|*.xls";
        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        return sfd.FileName;
        //    }
        //    return string.Empty;
        //}

        /// <summary>
        /// 获得打开文件的路径
        /// </summary>
        /// <returns></returns>
        //public static string OpenFileDialog()
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.DefaultExt = "xls";
        //    ofd.Filter = "Excel文件(*.xls)|*.xls";
        //    if (ofd.ShowDialog() == DialogResult.OK)
        //    {
        //        return ofd.FileName;
        //    }
        //    return string.Empty;
        //}

        /// <summary>
        /// 设置单元格边框
        /// </summary>
        protected void SetCellsBorderAround()
        {
            range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, null);
            //if (dt.Rows.Count > 0)
            //{
            //    range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
            //    range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
            //    range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlThin;
            //}
            //if (dt.Columns.Count > 1)
            {
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].ColorIndex=Excel.XlColorIndex.xlColorIndexAutomatic;
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle=Excel.XlLineStyle.xlContinuous;
                range.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight=Excel.XlBorderWeight.xlThin;
            }
        }

        /// <summary>
        /// 将DataTable导出Excel
        /// </summary>
        /// <param name="dt">数据集</param>
        /// <param name="saveFilePath">保存路径</param>
        /// <param name="reportName">报表名称</param>
        /// <returns>是否成功</returns>
        public bool DataTableToExecl(DataTable dt, string saveFileName, string reportName)
        {
            //判断是否安装Excel
            bool fileSaved=false;
            if (status == -1)
                return fileSaved;
            //判断数据集是否为null
            if (dt == null)
            {
                returnMessage="无引出数据！";
                return false;
            }
            //判断保存路径是否有效
            if (!saveFileName.Contains(":"))
            {
                returnMessage="引出路径有误！请选择正确路径！";
                return false;
            }

            //创建excel对象
            workbooks=xlApp.Workbooks;
            workbook=workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            worksheet=workbook.Worksheets[1];//取得sheet1
            worksheet.Cells.Font.Size=10;
            worksheet.Cells.NumberFormat="@";
            long totalCount=dt.Rows.Count;
            long rowRead=0;
            float percent=0;
            int rowIndex=0;

            //第一行为报表名称，如果为null则不保存该行    
            ++rowIndex;
            worksheet.Cells[rowIndex, 1]=reportName;
            range=worksheet.Cells[rowIndex, 1];
            range.Font.Bold=true;

            //写入字段(标题)
            ++rowIndex;
            for (int i=0; i < dt.Columns.Count; i++)
            {
                worksheet.Cells[rowIndex, i + 1]=dt.Columns[i].ColumnName;
                range=worksheet.Cells[rowIndex, i + 1];

                range.Font.Color=ColorTranslator.ToOle(Color.Blue);
                range.Interior.Color=dt.Columns[i].Caption == "表体" ? ColorTranslator.ToOle(Color.SkyBlue) : ColorTranslator.ToOle(Color.Yellow);
            }

            //写入数据
            ++rowIndex;
            for (int r=0; r < dt.Rows.Count; r++)
            {
                for (int i=0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[r + rowIndex, i + 1]=dt.Rows[r][i].ToString();
                }
                rowRead++;
                percent=((float)(100 * rowRead)) / totalCount;
            }

            //画单元格边框
            range=worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[dt.Rows.Count + 2, dt.Columns.Count]);
            this.SetCellsBorderAround();

            //列宽自适应
            range.EntireColumn.AutoFit();

            //保存文件
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved=true;
                    workbook.SaveCopyAs(saveFileName);
                    fileSaved=true;
                }
                catch (Exception ex)
                {
                    fileSaved=false;
                    returnMessage="导出文件时出错,文件可能正被打开！\n" + ex.Message;
                }
            }
            else
            {
                fileSaved=false;
            }

            //释放Excel对应的对象（除xlApp,因为创建xlApp很花时间，所以等析构时才删除)
            //Dispose(false);
            Dispose();
            return fileSaved;
        }

        /// <summary>
        /// 导入EXCEL到DataSet
        /// </summary>
        /// <param name="fileName">Excel全路径文件名</param>
        /// <returns>导入成功的DataSet</returns>
        public DataSet ImportExcel(string fileName)
        {
            if (status == -1)
                return null;
            //判断文件是否被其他进程使用            
            try
            {
                workbook=xlApp.Workbooks.Open(fileName, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, 1, 0);
                worksheet=workbook.Worksheets[1];
            }
            catch
            {
                returnMessage="Excel文件处于打开状态，请保存关闭";
                return null;
            }

            //获得所有Sheet名称
            int n=workbook.Worksheets.Count;
            string[] sheetSet=new string[n];
            ArrayList al=new ArrayList();
            for (int i=0; i < n; i++)
            {
                sheetSet[i]=((Excel.Worksheet)workbook.Worksheets[i + 1]).Name;
            }

            //释放Excel相关对象
            Dispose();

            //把EXCEL导入到DataSet
            DataSet ds=null;
            //string connStr = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " + fileName + ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1;\""; 
            List<string> connStrs=new List<string>();
            connStrs.Add("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + fileName + ";Extended Properties=\"Excel 8.0;HDR=No;IMEX=1;\"");
            connStrs.Add("Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " + fileName + ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1;\"");
            //  connStrs.Add("Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};DBQ=" + fileName);
            foreach (string connStr in connStrs)
            {
                ds=GetDataSet(connStr, sheetSet);
                if (ds != null)
                    break;
            }
            return ds;
        }

        /// <summary>
        /// 通过olddb获得dataset
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <returns></returns>
        protected DataSet GetDataSet(string connStr, string[] sheetSet)
        {
            DataSet ds=null;
            using (OleDbConnection conn=new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    OleDbDataAdapter da;
                    ds=new DataSet();
                    for (int i=0; i < sheetSet.Length; i++)
                    {
                        string sql="select * from [" + sheetSet[i] + "$] ";
                        da=new OleDbDataAdapter(sql, conn);
                        da.Fill(ds, sheetSet[i]);
                        da.Dispose();
                    }
                    conn.Close();
                    conn.Dispose();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return ds;
        }

        /// <summary>
        /// 释放Excel对应的对象资源
        /// </summary>
        /// <param name="isDisposeAll"></param>
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        if (range != null)
                        {
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
                            range=null;
                        }
                        if (worksheet != null)
                        {
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                            worksheet=null;
                        }
                        if (workbook != null)
                        {
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                            workbook=null;
                        }
                        if (workbooks != null)
                        {
                            xlApp.Application.Workbooks.Close();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
                            workbooks=null;
                        }
                        if (xlApp != null)
                        {
                            xlApp.Quit();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                        }
                        int generation=GC.GetGeneration(xlApp);
                        System.GC.Collect(generation);
                    }
                    //非托管资源的释放
                    //KillExcel();
                }
                disposed=true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary> 
        /// 会自动释放非托管的该类实例的相关资源
        /// </summary>
        public void Dispose()
        {
            try
            {
                Dispose(true);
                //告诉垃圾回收器,资源已经被回收
                GC.SuppressFinalize(this);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            try
            {
                this.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~ExcelIO()
        {
            try
            {
                Dispose(false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 关闭Execl进程(非托管资源使用)
        /// </summary>
        private void KillExcel()
        {
            try
            {
                Process[] ps=Process.GetProcesses();
                foreach (Process p in ps)
                {
                    if (p.ProcessName.ToLower().Equals("excel"))
                    {
                        //if (p.Id == ExcelID)
                        {
                            p.Kill();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("ERROR " + ex.Message);
            }
        }
        #endregion
        #region Events
        #endregion
        #region IDisposable 成员
        #endregion
    }
}