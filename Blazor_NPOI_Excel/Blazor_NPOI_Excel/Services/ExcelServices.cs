using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_NPOI_Excel.Services
{
    public class ExcelServices
    {
        public void test()
        {
            using (var stream = new FileStream("wwwroot/template.xlsx", FileMode.Open))
            {
                IWorkbook workbook = new XSSFWorkbook(stream);
                ISheet excelSheet = workbook.GetSheet("报告");
                IRow row2 = excelSheet.GetRow(2);
                IRow row3 = excelSheet.GetRow(3);
                IRow row4 = excelSheet.GetRow(4);
                IRow row5 = excelSheet.GetRow(5);
                IRow row8 = excelSheet.GetRow(8);
                IRow row14 = excelSheet.GetRow(14);
                IRow row15 = excelSheet.GetRow(15);
                IRow row16 = excelSheet.GetRow(16);
                IRow row17 = excelSheet.GetRow(17);
                //姓名
                row2.GetCell(1).SetCellValue("王二麻子");
                row2.GetCell(3).SetCellValue("女");
                row2.GetCell(5).SetCellValue("23");


                row3.GetCell(1).SetCellValue("123456");
                row3.GetCell(3).SetCellValue("发热门诊");
                row3.GetCell(5).SetCellValue("temp");

                row4.GetCell(1).SetCellValue("temp");
                row4.GetCell(3).SetCellValue("发热门诊");
                row4.GetCell(5).SetCellValue("赵延东");

                row5.GetCell(1).SetCellValue("咽拭子");
                row5.GetCell(3).SetCellValue("ys1234");
                row5.GetCell(5).SetCellValue("良好");

                row8.GetCell(2).SetCellValue("阴性");

                row14.GetCell(1).SetCellValue("2021-01-17");
                row15.GetCell(1).SetCellValue("2021-01-17");
                row15.GetCell(4).SetCellValue("2021-01-17");
                row16.GetCell(1).SetCellValue("张中敏");
                row16.GetCell(4).SetCellValue("张中敏");
                row17.GetCell(1).SetCellValue("承钢医院检验科");
                row17.GetCell(4).SetCellValue("031400005451");


                var fs = new FileStream("wwwroot/template.xlsx", FileMode.Create, FileAccess.Write);
                workbook.Write(fs);
                fs.Dispose();


                Workbook workbook1 = new Workbook();
                workbook1.LoadFromFile(@"wwwroot/template.xlsx", ExcelVersion.Version2010);
                workbook1.SaveToFile(@"wwwroot/test.pdf", FileFormat.PDF);



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
