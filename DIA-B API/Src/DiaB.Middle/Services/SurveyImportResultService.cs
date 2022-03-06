using CpTech.Core.Middle.Dtos;
using DiaB.Common.Constants;
using DiaB.Common.Enums;
using DiaB.Common.Extensions;
using DiaB.Data.Database.Entities.Import;
using DiaB.Data.Repositories.Interfaces;
using DiaB.Middle.Abstracts;
using DiaB.Middle.Dtos.ImageDtos;
using DiaB.Middle.Dtos.SurveyImportResultDtos;
using DiaB.Middle.Services.Interfaces;
using DocumentFormat.OpenXml.Office2010.Word.DrawingShape;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ActionContext = DiaB.Common.Utilities.ActionContext;
using Path = System.IO.Path;
using Rectangle = DocumentFormat.OpenXml.Drawing.Rectangle;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Drawing;
using Anchor = DocumentFormat.OpenXml.Drawing.Wordprocessing.Anchor;
using DocumentFormat.OpenXml.Drawing.Charts;
using Chart = DocumentFormat.OpenXml.Drawing.Chart;

namespace DiaB.Middle.Services
{
    public class SurveyImportResultService : BaseService<SurveyImportResultEntity>, ISurveyImportResultService
    {
        public IAccountImportService AccountImportService { get; set; }
        public IImageService ImageService { get; set; }

        public SurveyImportResultService(IAppRepo<SurveyImportResultEntity> repo)
            : base(repo)
        {
        }

        public async Task<SurveyImportResultDtos.AppItem> GetSurveyImportResultById(Guid id, ActionContext context = null)
        {
            var entity = await this.GetEntity(
               del => del.Where(r => !r.IsDeleted && r.Id == id && !r.IsClose),
               context);

            if (entity == null)
            {
                throw new ServiceException(ServiceExceptions.ObjectNotFound);
            }

            
            var result = this.Mapper.Map<SurveyImportResultDtos.AppItem>(entity);

            if (entity.SurveyImport.AccountImport.CoverId.HasValue && context != null)
            {
                result.Avatar = ImageService.GetImageUrl(entity.SurveyImport.AccountImport.CoverId.Value, context);
            }

            return result;
        }

        public async Task UpdateSurveyImportResult(SurveyImportResultDtos.AppUpdate input, ActionContext context)
        {
            var entity = await this.GetEntity(
                del => del.Where(r => !r.IsDeleted && r.Id == input.Id && !r.IsClose),
                context);

            if (entity == null)
            {
                throw new ServiceException(ServiceExceptions.ObjectNotFound);
            }

            if (entity.SurveyImport == null || entity.SurveyImport.IsDeleted)
            {
                throw new ServiceException(ServiceExceptions.ObjectNotFound);
            }

            if (entity.SurveyImport.AccountImport == null || entity.SurveyImport.AccountImport.IsDeleted)
            {
                throw new ServiceException(ServiceExceptions.ObjectNotFound);
            }

            Guid? coverId = null;

            if (input.Image != null)
            {
                coverId = await UploadImage(input.Image, context, entity.SurveyImport.AccountImport.CoverId);
            }

            var resultUpdateSurveyImportResult = await this.UpdateEntity(
                entity,
                del =>
                {
                    del.KtNxtq = input.KtNxtq;
                    del.KntcsNxtq = input.KntcsNxtq;
                    del.MdrcNxtq = input.MdrcNxtq;
                    del.KndctlNxtq = input.KndctlNxtq;
                    del.DltdNxtq = input.DltdNxtq;
                    del.Nxtq = input.KtNxtq;
                    del.DxvmtNxtq = input.DxvmtNxtq;
                    del.KhvhdNxtq = input.KtNxtq;

                    del.SurveyImport.AccountImport.UserName = input.UserName;
                    del.SurveyImport.AccountImport.UserGender = input.UserGender;
                    del.SurveyImport.AccountImport.UserYearofbirth = input.UserYearofbirth;
                    del.SurveyImport.AccountImport.UserCareer = input.UserCareer;
                    del.SurveyImport.AccountImport.UserHoobit = input.UserHoobit;
                    del.SurveyImport.AccountImport.UserProvince = input.UserProvince;
                    del.SurveyImport.AccountImport.UserTypeofsick = input.UserTypeofsick;
                    del.SurveyImport.AccountImport.YearFoundout = input.YearFoundout;
                    del.SurveyImport.AccountImport.CoverId = coverId ?? entity.SurveyImport.AccountImport.CoverId;
                },
                context) as ICoreResultDto;
        }

        public async Task CloseSurveyImportResult(Guid id, ActionContext context)
        {
            var entity = await this.GetEntity(
                del => del.Where(r => !r.IsDeleted && r.Id == id && !r.IsClose),
                context);

            if (entity == null)
            {
                throw new ServiceException(ServiceExceptions.ObjectNotFound);
            }

            if (entity.SurveyImport.AccountImport == null || entity.SurveyImport.AccountImport.IsDeleted)
            {
                throw new ServiceException(ServiceExceptions.ObjectNotFound);
            }

            var resultUpdateSurveyImportResult = await this.UpdateEntity(
                entity,
                del =>
                {
                    del.IsClose = true;
                },
                context) as ICoreResultDto;
        }

        private async Task<Guid?> UploadImage(IFormFile image, ActionContext context, Guid? deleteId = null)
        {
            if (deleteId.HasValue)
            {
                await this.DeleteImage(deleteId.Value, context);
            }

            var imageInput = new ImageDtos.AppInsert
            {
                Type = ImageTypes.Activity,
                images = new List<IFormFile> { image },
            };

            var imageId = await this.ImageService.UploadSingleImageAndGetId(imageInput, context);

            return imageId;
        }

        private async Task DeleteImage(Guid id, ActionContext context)
        {
            await this.ImageService.DeleteImages(new List<Guid> { id }, context);
        }

        public async Task<Guid> CreateSurveyImportResult(SurveyImportEntity surveyImportEntity, ActionContext context)
        {
            if (surveyImportEntity.SurveyResultId.HasValue)
            {
                await this.Delete(surveyImportEntity.SurveyResultId.Value, context);
            }

            var result = await this.CreateEntity(
                new SurveyImportResultEntity
                {
                    Hba1cVal = 5,
                    BmiVal =  5,

                    KtBlVal =  5,
                    KtTdcsVal = 5,
                    KtDdVal =  5,
                    KtVdVal =  5,
                    KtThVal =  5,
                    KtTlhvVal = 5,
                    KtVal =  5,
                    KtNxtq =  "",

                    KntcsHtVal =  5,
                    KntcsCsbcVal =  5,
                    KntcsTddhVal =  5,
                    KntcsCdvdVal =  5,
                    KntcsCdauVal =  5,
                    KntcsVal =  5,
                    KntcsNxtq =  "",

                    MdrcDtVal =  5,
                    MdrcTddhVal =  5,
                    MdrcCdvdVal =  5,
                    MdrcCdauVal =  5,
                    MdrcVal =  5,
                    MdrcNxtq =  "",

                    KndctlCtlqdbsVal =  5,
                    KndctlCttcmqhVal =  5,
                    KndctlGnvttdtVal =  5,
                    KndctlGncxVal =  5,
                    KndctlVal =  5,
                    KndctlNxtq =  "",

                    DltdDltdbtVal =  5,
                    DltdDltdbnVal =  5,
                    DltdVal =  5,
                    DltdNxtq =  "",

                    Nxtq =  "",
                    DxvmtNxtq =  "",
                    KhvhdNxtq =  "",
                    IsClose = false
                }, context);

            return (result as ICoreResultDto).Id;
        }

        public async Task<SurveyImportResultDtos.AppItem> CreateSurveyImportResultReport(SurveyImportResultDtos.AppInput input, ActionContext context)
        {
            if (input.Ids == null || input.Ids.Count == 0)
            {
                throw new ServiceException(ServiceExceptions.ObjectInvalid);
            }

            SurveyImportResultDtos.AppItem response = new SurveyImportResultDtos.AppItem();


            var directoryInfo = Directory.CreateDirectory(Path.Combine(CommonConstant.ReportWorkPath, DateTime.UtcNow.ToString("yyyyMMddHHmmssfff")));
            var templatePath = Path.Combine(CommonConstant.ReportTemplatePath, "bao_cao_dau_ra.docx");
            var physicalPath = string.Empty;
            foreach (Guid id in input.Ids)
            {
                var entity = await this.GetEntity(
                 del => del.Where(r => !r.IsDeleted && r.Id == id && !r.IsClose),
                 context);

                if (entity == null)
                {
                    throw new ServiceException(ServiceExceptions.ObjectNotFound);
                }

                physicalPath = Path.Combine(CommonConstant.ReportWorkPath, directoryInfo.Name, entity.SurveyImport.AccountImport.UserName.AppendTimeStamp() + ".docx");

                File.Copy(templatePath, physicalPath, true);

                // write

                this.WriteReport(entity, physicalPath, context);

            }

            if (input.Ids.Count == 1)
            {
                response.FileReportTitle = "bao_cao_dau_ra.docx";
                response.FileReport = new FileStream(physicalPath, FileMode.Open, FileAccess.Read);
            } else
            {
                var zipPath = Path.Combine(CommonConstant.ReportWorkPath, directoryInfo.Name + ".zip");
                ZipFile.CreateFromDirectory(directoryInfo.FullName, zipPath);

                response.FileReportTitle = "bao_cao_dau_ra.zip";
                response.FileReport = new FileStream(zipPath, FileMode.Open, FileAccess.Read);
            }

           

            return response;
        }

        private bool WriteReport(SurveyImportResultEntity entity, string pathOutput, ActionContext context)
        {
            var bgRed = "C00000";
            var bgBlue = "21A567";
            var bgYellow = "FDB913";

            var danhxung = "anh";
            var DanhXung = "Anh";
            var gender = "Nam";
            var ten = "";

            if (string.IsNullOrEmpty( entity.SurveyImport.AccountImport.UserGender))
            {
                if ("NỮ".Equals(entity.SurveyImport.AccountImport.UserGender.ToUpper()) || "NU".Equals(entity.SurveyImport.AccountImport.UserGender.ToUpper()))
                {
                    danhxung = "chị";
                    gender = "Chị";
                    gender = "Nữ";
                }
            }

            if (!string.IsNullOrEmpty(entity.SurveyImport.AccountImport.UserName))
            {
                var tens = entity.SurveyImport.AccountImport.UserName.Split(" ");
                for (var i = tens.Length -1; i >= 0;  i--)
                {
                    if (!string.IsNullOrEmpty(tens[i]))
                    {
                        if (ten == "")
                        {
                            ten = tens[i];
                        } else
                        {
                            ten = tens[i] + " " + ten;
                            break;
                        }
                    }
                }
            }


                var wordDoc = WordprocessingDocument.Open(pathOutput, true);
            using ((wordDoc))
            {

                var paragraphs = wordDoc.MainDocumentPart.Document.Descendants<Paragraph>().ToList();
                foreach (var paragraph in paragraphs)
                {
                    if (paragraph.InnerText.Contains("###ccnd###"))
                    {
                        this.ConvertPage(paragraph, "###ccnd###", entity.SurveyImport.AccountImport.StorySuccess);
                    }

                    if (paragraph.InnerText.Contains("###mtct###"))
                    {
                        this.ConvertPage(paragraph, "###mtct###", entity.SurveyImport.CourseGoal);
                    }

                    if (paragraph.InnerText.Contains("###nxtq###"))
                    {
                        this.ConvertPage(paragraph, "###nxtq###", entity.Nxtq);
                    }

                    if (paragraph.InnerText.Contains("###kt-nxtq###"))
                    {
                        this.ConvertPage(paragraph, "###kt-nxtq###", entity.KtNxtq);
                    }

                    if (paragraph.InnerText.Contains("###kntcs-nxtq###"))
                    {
                        this.ConvertPage(paragraph, "###kntcs-nxtq###", entity.KntcsNxtq);
                    }

                    if (paragraph.InnerText.Contains("###mdrc-nxtq###"))
                    {
                        this.ConvertPage(paragraph, "###mdrc-nxtq###", entity.MdrcNxtq);
                    }

                    if (paragraph.InnerText.Contains("###kndctl-nxtq###"))
                    {
                        this.ConvertPage(paragraph, "###kndctl-nxtq###", entity.KndctlNxtq);
                    }

                    if (paragraph.InnerText.Contains("###dltd-nxtq###"))
                    {
                        this.ConvertPage(paragraph, "###dltd-nxtq###", entity.DltdNxtq);
                    }

                    if (paragraph.InnerText.Contains("###dexuatvamuctieu###"))
                    {
                        this.ConvertPage(paragraph, "###dexuatvamuctieu###", entity.DxvmtNxtq);
                    }

                    if (paragraph.InnerText.Contains("###kehoachhanhdong###"))
                    {
                        this.ConvertPage(paragraph, "###kehoachhanhdong###", entity.KhvhdNxtq);
                    }
                }
             
                var range = wordDoc.MainDocumentPart.Document.Descendants<WordprocessingShape>().Where(a => a.NonVisualDrawingProperties?.Name == "RangeHbA1C").FirstOrDefault();
                if (range != null)
                {
                    var chartShape = range.Descendants<SolidFill>().First();

                    if (entity.Hba1cVal < 7)
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgBlue };
                    } else
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgRed };
                    }
                }


                range = wordDoc.MainDocumentPart.Document.Descendants<WordprocessingShape>().Where(a => a.NonVisualDrawingProperties?.Name == "RangeBMI").FirstOrDefault();
                if (range != null)
                {
                    var chartShape = range.Descendants<SolidFill>().First();

                    if (entity.BmiVal < 18)
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgYellow };
                    }
                    else if(entity.BmiVal > 23)
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgRed };
                    } else
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgBlue };
                    }
                }

                range = wordDoc.MainDocumentPart.Document.Descendants<WordprocessingShape>().Where(a => a.NonVisualDrawingProperties?.Name == "RangeKienthuc").FirstOrDefault();
                if (range != null)
                {
                    var chartShape = range.Descendants<SolidFill>().First();

                    if (entity.KtVal < 9)
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgYellow };
                    }
                    else if (entity.KtVal > 10)
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgRed };
                    }
                    else
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgBlue };
                    }
                }

                range = wordDoc.MainDocumentPart.Document.Descendants<WordprocessingShape>().Where(a => a.NonVisualDrawingProperties?.Name == "RangeKhanangtuchamsoc").FirstOrDefault();
                if (range != null)
                {
                    var chartShape = range.Descendants<SolidFill>().First();

                    if (entity.KntcsVal < 5)
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgYellow };
                    }
                    else if (entity.KntcsVal > 10)
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgRed };
                    }
                    else
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgBlue };
                    }
                }

                range = wordDoc.MainDocumentPart.Document.Descendants<WordprocessingShape>().Where(a => a.NonVisualDrawingProperties?.Name == "RangeMucdoraocan").FirstOrDefault();
                if (range != null)
                {
                    var chartShape = range.Descendants<SolidFill>().First();

                    if (entity.MdrcVal < 2)
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgYellow };
                    }
                    else if (entity.MdrcVal > 5)
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgRed };
                    }
                    else
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgBlue };
                    }
                }

                range = wordDoc.MainDocumentPart.Document.Descendants<WordprocessingShape>().Where(a => a.NonVisualDrawingProperties?.Name == "RangeKhanangedieuchinhtamly").FirstOrDefault();
                if (range != null)
                {
                    var chartShape = range.Descendants<SolidFill>().First();

                    if (entity.KndctlVal < 1)
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgYellow };
                    }
                    else if (entity.KndctlVal > 3)
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgRed };
                    }
                    else
                    {
                        chartShape.RgbColorModelHex = new RgbColorModelHex() { Val = bgBlue };
                    }
                }

                // tỉ lệ mắc bệnh đái tháo đường
                var rGTLDTDYear80 = wordDoc.MainDocumentPart.Document.Descendants<DocProperties>().Where(a => a.Name == "RGTLDTDYear80").FirstOrDefault();
                var rGTLDTDYear7079 = wordDoc.MainDocumentPart.Document.Descendants<DocProperties>().Where(a => a.Name == "RGTLDTDYear70-79").FirstOrDefault();
                var rGTLDTDYear6069 = wordDoc.MainDocumentPart.Document.Descendants<DocProperties>().Where(a => a.Name == "RGTLDTDYear60-69").FirstOrDefault();
                var rGTLDTDYear5059 = wordDoc.MainDocumentPart.Document.Descendants<DocProperties>().Where(a => a.Name == "RGTLDTDYear50-59").FirstOrDefault();
                var rGTLDTDYear4049 = wordDoc.MainDocumentPart.Document.Descendants<DocProperties>().Where(a => a.Name == "RGTLDTDYear40-49").FirstOrDefault();
                var oldYear = DateTime.Now.Year - entity.SurveyImport.AccountImport.UserYearofbirth;

                if (oldYear >= 80)
                {
                    rGTLDTDYear80.Hidden = false;
                    rGTLDTDYear7079.Hidden = true;
                    rGTLDTDYear6069.Hidden = true;
                    rGTLDTDYear5059.Hidden = true;
                    rGTLDTDYear4049.Hidden = true;
                } else if (oldYear >= 70)
                {
                    rGTLDTDYear80.Hidden = true;
                    rGTLDTDYear7079.Hidden = false;
                    rGTLDTDYear6069.Hidden = true;
                    rGTLDTDYear5059.Hidden = true;
                    rGTLDTDYear4049.Hidden = true;
                }
                else if (oldYear >= 60)
                {
                    rGTLDTDYear80.Hidden = true;
                    rGTLDTDYear7079.Hidden = true;
                    rGTLDTDYear6069.Hidden = false;
                    rGTLDTDYear5059.Hidden = true;
                    rGTLDTDYear4049.Hidden = true;
                }
                else if (oldYear >= 50)
                {
                    rGTLDTDYear80.Hidden = true;
                    rGTLDTDYear7079.Hidden = true;
                    rGTLDTDYear6069.Hidden = true;
                    rGTLDTDYear5059.Hidden = false;
                    rGTLDTDYear4049.Hidden = true;
                }
                else if (oldYear >= 40)
                {
                    rGTLDTDYear80.Hidden = true;
                    rGTLDTDYear7079.Hidden = true;
                    rGTLDTDYear6069.Hidden = true;
                    rGTLDTDYear5059.Hidden = true;
                    rGTLDTDYear4049.Hidden = false;
                } else
                {
                    rGTLDTDYear80.Hidden = true;
                    rGTLDTDYear7079.Hidden = true;
                    rGTLDTDYear6069.Hidden = true;
                    rGTLDTDYear5059.Hidden = true;
                    rGTLDTDYear4049.Hidden = true;
                }




                // chart 
                // kinh te tong the
                var selectChart = wordDoc.MainDocumentPart.Document.Descendants<DocProperties> ().Where(run => run.Name == "CharKienthuctongthe").Select(run => run.Parent.Descendants<ChartReference>().FirstOrDefault()).FirstOrDefault();
                if (selectChart != null)
                {
                    ChartPart charPart = (ChartPart)wordDoc.MainDocumentPart.GetPartById(selectChart.Id);

                    var values = charPart.ChartSpace.Descendants<NumericValue>().ToList();
                    if (values.Count >= 6)
                    {
                        values[2].Text = entity.KtVal + "";
                    }
                }
                // kinh te chi tiết
                selectChart = wordDoc.MainDocumentPart.Document.Descendants<DocProperties>().Where(run => run.Name == "ChartKienthucchitiet").Select(run => run.Parent.Descendants<ChartReference>().FirstOrDefault()).FirstOrDefault();
                if (selectChart != null)
                {
                    ChartPart charPart = (ChartPart)wordDoc.MainDocumentPart.GetPartById(selectChart.Id);

                    var values = charPart.ChartSpace.Descendants<NumericValue>().ToList();
                    if (values.Count >= 26)
                    {
                        values[7].Text = entity.KtBlVal == 0 ? "-" : entity.KtBlVal + "";
                        values[8].Text = entity.KtTdcsVal == 0 ? "-" : entity.KtTdcsVal + "";
                        values[9].Text = entity.KtDdVal == 0 ? "-" : entity.KtDdVal + "";
                        values[10].Text = entity.KtVdVal == 0 ? "-" : entity.KtVdVal + "";
                        values[11].Text = entity.KtThVal == 0 ? "-" : entity.KtThVal + "";
                        values[12].Text = entity.KtTlhvVal == 0 ? "-" : entity.KtTlhvVal  + "";
                    }
                }


                
                selectChart = wordDoc.MainDocumentPart.Document.Descendants<DocProperties>().Where(run => run.Name == "CharKhanangtuchamsoctongthe").Select(run => run.Parent.Descendants<ChartReference>().FirstOrDefault()).FirstOrDefault();
                if (selectChart != null)
                {
                    ChartPart charPart = (ChartPart)wordDoc.MainDocumentPart.GetPartById(selectChart.Id);

                    var values = charPart.ChartSpace.Descendants<NumericValue>().ToList();
                    if (values.Count >= 6)
                    {
                        values[2].Text = entity.KntcsVal + "";
                    }
                }
                selectChart = wordDoc.MainDocumentPart.Document.Descendants<DocProperties>().Where(run => run.Name == "CharKhanangtuchamsocchitiet").Select(run => run.Parent.Descendants<ChartReference>().FirstOrDefault()).FirstOrDefault();
                if (selectChart != null)
                {
                    ChartPart charPart = (ChartPart)wordDoc.MainDocumentPart.GetPartById(selectChart.Id);

                    var values = charPart.ChartSpace.Descendants<NumericValue>().ToList();
                    if (values.Count >= 18)
                    {
                        values[5].Text = entity.KntcsCdauVal == 0 ? "-" : entity.KntcsCdauVal + "";
                        values[6].Text = entity.KntcsCdvdVal == 0 ? "-" : entity.KntcsCdvdVal + "";
                        values[7].Text = entity.KntcsTddhVal == 0 ? "-" : entity.KntcsTddhVal + "";
                        values[8].Text = entity.KntcsCsbcVal == 0 ? "-" : entity.KntcsCsbcVal + "";

                    }
                }

                selectChart = wordDoc.MainDocumentPart.Document.Descendants<DocProperties>().Where(run => run.Name == "ChartMucdoraocantongthe").Select(run => run.Parent.Descendants<ChartReference>().FirstOrDefault()).FirstOrDefault();
                if (selectChart != null)
                {
                    ChartPart charPart = (ChartPart)wordDoc.MainDocumentPart.GetPartById(selectChart.Id);

                    var values = charPart.ChartSpace.Descendants<NumericValue>().ToList();
                    if (values.Count >= 6)
                    {
                        values[2].Text = entity.MdrcVal + "";
                    }
                }
                selectChart = wordDoc.MainDocumentPart.Document.Descendants<DocProperties>().Where(run => run.Name == "ChartMucdoraocanchitiet").Select(run => run.Parent.Descendants<ChartReference>().FirstOrDefault()).FirstOrDefault();
                if (selectChart != null)
                {
                    ChartPart charPart = (ChartPart)wordDoc.MainDocumentPart.GetPartById(selectChart.Id);

                    var values = charPart.ChartSpace.Descendants<NumericValue>().ToList();
                    if (values.Count >= 18)
                    {
                        values[5].Text = entity.MdrcCdauVal == 0 ? "-" : entity.MdrcCdauVal + "";
                        values[6].Text = entity.MdrcTddhVal == 0 ? "-" : entity.MdrcTddhVal + "";
                        values[7].Text = entity.MdrcDtVal == 0 ? "-" : entity.MdrcDtVal + "";
                        values[8].Text = entity.MdrcTddhVal == 0 ? "-" : entity.MdrcTddhVal + "";
                      
                    }
                }

                selectChart = wordDoc.MainDocumentPart.Document.Descendants<DocProperties>().Where(run => run.Name == "ChartKhanangdieuchinhtamlytongquat").Select(run => run.Parent.Descendants<ChartReference>().FirstOrDefault()).FirstOrDefault();
                if (selectChart != null)
                {
                    ChartPart charPart = (ChartPart)wordDoc.MainDocumentPart.GetPartById(selectChart.Id);

                    var values = charPart.ChartSpace.Descendants<NumericValue>().ToList();
                    if (values.Count >= 6)
                    {
                        values[2].Text = entity.KndctlVal + "";
                    }
                }
                selectChart = wordDoc.MainDocumentPart.Document.Descendants<DocProperties>().Where(run => run.Name == "ChartKhanangdieuchinhtamlychitiet").Select(run => run.Parent.Descendants<ChartReference>().FirstOrDefault()).FirstOrDefault();
                if (selectChart != null)
                {
                    ChartPart charPart = (ChartPart)wordDoc.MainDocumentPart.GetPartById(selectChart.Id);

                    var values = charPart.ChartSpace.Descendants<NumericValue>().ToList();
                    if (values.Count >= 18)
                    {
                        values[5].Text = entity.KndctlGncxVal == 0 ? "-" : entity.KndctlGncxVal + "";
                        values[6].Text = entity.KndctlCtlqdbsVal == 0 ? "-" : entity.KndctlCtlqdbsVal + "";
                        values[7].Text = entity.KndctlGnvttdtVal == 0 ? "-" : entity.KndctlGnvttdtVal + "";
                        values[8].Text = entity.KndctlCttcmqhVal == 0 ? "-" : entity.KndctlCttcmqhVal + "";

                    }
                }


                selectChart = wordDoc.MainDocumentPart.Document.Descendants<DocProperties>().Where(run => run.Name == "ChartDonglucthaydoitubentrong").Select(run => run.Parent.Descendants<ChartReference>().FirstOrDefault()).FirstOrDefault();
                if (selectChart != null)
                {
                    ChartPart charPart = (ChartPart)wordDoc.MainDocumentPart.GetPartById(selectChart.Id);

                    var values = charPart.ChartSpace.Descendants<NumericValue>().ToList();
                    if (values.Count >= 6)
                    {
                        values[2].Text = entity.DltdDltdbtVal + "";
                    }
                }

                selectChart = wordDoc.MainDocumentPart.Document.Descendants<DocProperties>().Where(run => run.Name == "ChartDonglucthaydoitubenngoai").Select(run => run.Parent.Descendants<ChartReference>().FirstOrDefault()).FirstOrDefault();
                if (selectChart != null)
                {
                    ChartPart charPart = (ChartPart)wordDoc.MainDocumentPart.GetPartById(selectChart.Id);

                    var values = charPart.ChartSpace.Descendants<NumericValue>().ToList();
                    if (values.Count >= 6)
                    {
                        values[2].Text = entity.DltdDltdbnVal + "";
                    }
                }

                wordDoc.Save();
                wordDoc.Close();
            }

            wordDoc = WordprocessingDocument.Open(pathOutput, true);
            using ((wordDoc))
             {
                // replase text
                string docText = null;
                var sr = new StreamReader(wordDoc.MainDocumentPart.GetStream());

                using (sr)
                {
                    docText = sr.ReadToEnd();
                    sr.Close();
                }


  

                var regexText = new Regex("###hba1c-val###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.Hba1cVal + ""));
                regexText = new Regex("###hba1c-phanloai###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.Hba1cPhanloai));

                regexText = new Regex("###bmi-val###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.BmiVal + ""));
                regexText = new Regex("###bmi-phanloai###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.BmiPhanloai));

                regexText = new Regex("###kt-bl-val###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KtBlVal + ""));
                regexText = new Regex("###kt-tdcs-val###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KtTdcsVal + ""));
                regexText = new Regex("###kt-dd-val###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KtDdVal + ""));
                regexText = new Regex("###kt-vd-val###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KtVdVal + ""));
                regexText = new Regex("###kt-th-val###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KtThVal + ""));
                regexText = new Regex("###kt-tlhv-val###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KtTlhvVal + ""));
                regexText = new Regex("###kt-val###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KtVal + ""));
                regexText = new Regex("###kt-phanloai###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KtPhanloai));

                // thứ bao nhiêu nữa?

                regexText = new Regex("###kntcs-ht###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KntcsHtVal + ""));
                regexText = new Regex("###kntcs-csbc###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KntcsCsbcVal + ""));
                regexText = new Regex("###kntcs-tddh###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KntcsTddhVal + ""));
                regexText = new Regex("###kntcs-cdvd###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KntcsCdvdVal + ""));
                regexText = new Regex("###kntcs-cdau###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KntcsCdauVal + ""));
                regexText = new Regex("###kntcs-val###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KntcsVal + ""));
                regexText = new Regex("###kntcs-phanloai###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KntcsPhanloai));


                // thứ bao nhiêu nữa?

                regexText = new Regex("###mdrc-dt###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.MdrcDtVal + ""));
                regexText = new Regex("###mdrc-tddh###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.MdrcTddhVal + ""));
                regexText = new Regex("###mdrc-cdvd###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.MdrcCdvdVal + ""));
                regexText = new Regex("###mdrc-cdau###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.MdrcCdauVal + ""));
                regexText = new Regex("###mdrc-val###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.MdrcVal + ""));
                regexText = new Regex("###mdrc-phanloai###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.MdrcPhanloai));

                // thứ bao nhiêu nữa?
                regexText = new Regex("###kndctl-ctlqdbs###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KndctlCtlqdbsVal + ""));
                regexText = new Regex("###kndctl-cttcmqh###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KndctlCttcmqhVal + ""));
                regexText = new Regex("###kndctl-gnvttdt###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KndctlGnvttdtVal + ""));
                regexText = new Regex("###kndctl-gncx###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KndctlGncxVal + ""));
                regexText = new Regex("###kndctl-val###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KndctlVal + ""));
                regexText = new Regex("###mdrc-phanloai###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.KndctlPhanloai));

                // thứ bao nhiêu nữa?
                regexText = new Regex("###dltd-dltdtbt###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.DltdDltdbtVal + ""));
                regexText = new Regex("###dltd-dltdtbn###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.DltdDltdbnVal + ""));
                regexText = new Regex("###dltd-val###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.DltdVal + ""));
                regexText = new Regex("###dltd-phanloai###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.DltdPhanloai));


                // thứ bao nhiêu nữa?

                regexText = new Regex("###hoten###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.SurveyImport.AccountImport.UserName));

                regexText = new Regex("###ten###");
                docText = regexText.Replace(docText, this.ConvertXML(ten));

                regexText = new Regex("###tuoi###");
                docText = regexText.Replace(docText, this.ConvertXML((DateTime.Now.Year - entity.SurveyImport.AccountImport.UserYearofbirth) + ""));

                regexText = new Regex("###thanhpho###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.SurveyImport.AccountImport.UserProvince));

                regexText = new Regex("###tip###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.SurveyImport.AccountImport.UserTypeofsick));

                docText = docText.Replace("###danhxung###", this.ConvertXML(danhxung));

                docText = docText.Replace("###Danhxung###", this.ConvertXML(DanhXung));

                regexText = new Regex("###gioitinh###");
                docText = regexText.Replace(docText, this.ConvertXML(gender));

                regexText = new Regex("###nghenghiep###");
                docText = regexText.Replace(docText, this.ConvertXML(entity.SurveyImport.AccountImport.UserCareer));

                regexText = new Regex("###nambenh###");
                docText = regexText.Replace(docText, this.ConvertXML("Từ năm " + entity.SurveyImport.AccountImport.YearFoundout));




                StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create));
                using (sr)
                {
                    sw.Write(docText);
                    sw.Close();
                }


                // TODO
                //var paragraphs = wordDoc.MainDocumentPart.Document.Descendants<Paragraph>().ToList();
                //foreach (var paragraph in paragraphs)
                //{
                //    if (paragraph.InnerText == string.Empty && paragraph.Descendants<Break>().Where(p => p.ty)
                //    {
                //        paragraph.Remove();
                //    }
                //}
                wordDoc.Save();
            }
            return true;
        }
        private string ConvertXML(String value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }

            return SecurityElement.Escape(value);


        }

        private void ConvertPage(Paragraph paragraph, string key, string text)
        {
            if (paragraph.InnerText.Contains(key))
            {
                var contents = text?.Split("\r\n");
                if (contents != null && contents.Length > 0)
                {
                    foreach (var content in contents)
                    {
                        if (string.IsNullOrEmpty(content))
                        {
                            continue;
                        }
                        var paragraphsNew = paragraph.CloneNode(true);
                        paragraphsNew.InnerXml = paragraphsNew.InnerXml.Replace(key, this.ConvertXML(content));
                        paragraph.Parent.InsertBefore(paragraphsNew, paragraph);
                    }
                }
                paragraph.Remove();
            }
        }
    }

}
