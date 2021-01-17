using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_NPOI_Excel.Data
{
    public class ExcelServices
    {
        public void test()
        {
            using (var stream = new FileStream("wwwroot/template.xlsx", FileMode.Open))
            {
                IWorkbook workbook = new XSSFWorkbook(stream);
                ISheet excelSheet = workbook.GetSheet("ttt");
                IRow row = excelSheet.GetRow(2);
                row.GetCell(1).SetCellValue("王二麻子");
                var fs = new FileStream("wwwroot/template.xlsx", FileMode.Create, FileAccess.Write);
                workbook.Write(fs);
                fs.Dispose();


                //try
                //{
                //    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                //    app.Visible = false;
                //    Microsoft.Office.Interop.Excel.Workbook wkb = app.Workbooks.Open("wwwroot/template.xlsx");
                //    wkb.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, "wwwroot/template.pdf");
                //    wkb.Close();
                //    app.Quit();

                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.StackTrace);
                //    throw;
                //}
            }




        }
    }
}
