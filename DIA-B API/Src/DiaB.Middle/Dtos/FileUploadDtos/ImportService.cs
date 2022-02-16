using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CpTech.Core.Common.Dtos;
using DiaB.Middle.Dtos.FileUploadDtos;
using DiaB.Middle.Services.Interfaces;
using OfficeOpenXml;

namespace DiaB.Middle.Services
{
    public class ImportService : IImportService
    {
        public ImportService()
            : base()
        {
        }


        public FileUploadDtos.StaffInfo ImportStaff(FileUploadDtos.AppImportStaff input, ActionContext context)
        {
            FileUploadDtos.StaffInfo result = new FileUploadDtos.StaffInfo();
            string rootFolder = "../";
            string fileName = Guid.NewGuid().ToString() + input.file.FileName;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));
            using (var stream = new MemoryStream())
            {
                input.file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                     package.SaveAs(file);
                    //save excel file in your wwwroot folder and get this excel file from wwwroot
                }
            }

            //After save excel file in wwwroot and then
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                if (worksheet == null)
                {

                }
                else
                {
                    //read excel file data and add data in  model.StaffInfoViewModel.StaffList
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        result.StaffList.Add(new FileUploadDtos.StaffInfo
                        {
                            user_name = (worksheet.Cells[row, 1].Value ?? string.Empty).ToString().Trim(),
                            user_code = Int32.Parse(worksheet.Cells[row, 2].Value.ToString()),
                            survey_type = (worksheet.Cells[row, 3].Value ?? string.Empty).ToString().Trim(),
                            survey_code = (worksheet.Cells[row, 4].Value ?? string.Empty).ToString().Trim(),
                            survey_name = (worksheet.Cells[row, 5].Value ?? string.Empty).ToString().Trim(),

                            user_yearofbirth = Int32.Parse(worksheet.Cells[row, 6].Value.ToString()),
                            user_gender = (worksheet.Cells[row, 7].Value ?? string.Empty).ToString().Trim(),
                            user_phone = (worksheet.Cells[row, 8].Value ?? string.Empty).ToString().Trim(),
                            survey_day = (worksheet.Cells[row, 9].Value ?? string.Empty).ToString().Trim(),
                            user_province = (worksheet.Cells[row, 10].Value ?? string.Empty).ToString().Trim(),

                            stt = Int32.Parse(worksheet.Cells[row, 11].Value.ToString()),
                            user_career = (worksheet.Cells[row, 12].Value ?? string.Empty).ToString().Trim(),
                            user_hoobit = (worksheet.Cells[row, 13].Value ?? string.Empty).ToString().Trim(),
                            user_address = (worksheet.Cells[row, 14].Value ?? string.Empty).ToString().Trim(),
                            story_success = (worksheet.Cells[row, 15].Value ?? string.Empty).ToString().Trim(),

                            course_goal = (worksheet.Cells[row, 16].Value ?? string.Empty).ToString().Trim(),
                            course_action = (worksheet.Cells[row, 17].Value ?? string.Empty).ToString().Trim(),
                            course_final_rate = (worksheet.Cells[row, 18].Value ?? string.Empty).ToString().Trim(),
                            user_typeofsick = (worksheet.Cells[row, 19].Value ?? string.Empty).ToString().Trim(),
                            year_foundout = Int32.Parse(worksheet.Cells[row, 20].Value.ToString()),

                            participation_package = (worksheet.Cells[row, 21].Value ?? string.Empty).ToString().Trim(),
                            survey_type_code = (worksheet.Cells[row, 22].Value ?? string.Empty).ToString().Trim(),
                            category_code = (worksheet.Cells[row, 23].Value ?? string.Empty).ToString().Trim(),
                            category = (worksheet.Cells[row, 24].Value ?? string.Empty).ToString().Trim(),
                            sub_category_code = (worksheet.Cells[row, 25].Value ?? string.Empty).ToString().Trim(),

                            sub_category = (worksheet.Cells[row, 26].Value ?? string.Empty).ToString().Trim(),
                            import_day = (worksheet.Cells[row, 27].Value ?? string.Empty).ToString().Trim(),
                            question_code = (worksheet.Cells[row, 28].Value ?? string.Empty).ToString().Trim(),
                            question_number = (worksheet.Cells[row, 29].Value ?? string.Empty).ToString().Trim(),
                            question_answer = (worksheet.Cells[row, 30].Value ?? string.Empty).ToString().Trim(),
                            question_result = Int32.Parse(worksheet.Cells[row, 31].Value.ToString()),
                        });

                    }



                }
            }
            return result;
        }
    }
}
