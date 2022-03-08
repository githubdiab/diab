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
        public ISurveyQuestionMappingService SurveyQuestionMappingService { get; set; }
        public ISurveyRangeValueService ISurveyRangeValueService { get; set; }

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
                    del.KhvhdNxtq = input.KhvhdNxtq;

                    del.SurveyImport.CourseGoal = input.CourseGoal;

                    del.SurveyImport.AccountImport.UserName = input.UserName;
                    del.SurveyImport.AccountImport.UserGender = input.UserGender;
                    del.SurveyImport.AccountImport.UserYearofbirth = input.UserYearofbirth;
                    del.SurveyImport.AccountImport.UserCareer = input.UserCareer;
                    del.SurveyImport.AccountImport.UserHoobit = input.UserHoobit;
                    del.SurveyImport.AccountImport.UserProvince = input.UserProvince;
                    del.SurveyImport.AccountImport.UserTypeofsick = input.UserTypeofsick;
                    del.SurveyImport.AccountImport.YearFoundout = input.YearFoundout;
                    del.SurveyImport.AccountImport.StorySuccess = input.StorySuccess;
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

            SurveyRangeValueEntity rangeValue = null;
            var Nxtq = "";
            var KtNxtq = "";

            // BMI
            var BmiVal = 0.0;
            var BmiPhanloai = "";
            var questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("TTA0001CH", context);
            if (questions.Count > 0)
            {
                var TTA0001CH04 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionId == "TTA0001CH04" && m.QuestionCode == r.QuestionCode)).FirstOrDefault();
                var TTA0001CH04Val = 0.0;
                if (TTA0001CH04 != null)
                {
                    double.TryParse(TTA0001CH04.QuestionAnswer, out TTA0001CH04Val);
                }

                var TTA0001CH05 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionId == "TTA0001CH05" && m.QuestionCode == r.QuestionCode)).FirstOrDefault();
                var TTA0001CH05Val = 0.0;
                if (TTA0001CH05 != null)
                {
                    double.TryParse(TTA0001CH05.QuestionAnswer, out TTA0001CH05Val);
                }
                if (TTA0001CH04Val != 0)
                {
                    BmiVal = Math.Round((TTA0001CH05Val / ((TTA0001CH04Val / 100) * (TTA0001CH04Val / 100))), 1);
                }
            }

            rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("BMI", "BMI", BmiVal, context);
            if (rangeValue != null)
            {
                BmiPhanloai = rangeValue.Description;
                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    Nxtq += Nxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            // HbA1C
            var Hba1cVal = 0.0;
            var Hba1cPhanloai = "";
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("TTA0001CH08", context);
            if (questions.Count > 0)
            {
                var TTA0001CH08 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionId == "TTA0001CH08" && m.QuestionCode == r.QuestionCode)).FirstOrDefault();
                var TTA0001CH08Val = 0.0;
                if (TTA0001CH08 != null)
                {
                    double.TryParse(TTA0001CH08.QuestionAnswer, out TTA0001CH08Val);
                }

                Hba1cVal = TTA0001CH08Val;
            }

            rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("HbA1C", "HbA1C", Hba1cVal, context);
            if (rangeValue != null)
            {
                Hba1cPhanloai = rangeValue.Description;
                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    Nxtq += Nxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            // Kiến thức
            var KtVal = 0.0;

            // Bệnh lý: KTD001CH01 ~ KTD001CH10
            var KtBlVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("KTD001", context);
            if (questions.Count > 0)
            {
                var countQuestionTrue = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted 
                        && questions.Any(m => m.QuestionCode == r.QuestionCode && m.QuestionAnswer == r.QuestionAnswer)).Count();

                KtBlVal = Math.Round(((countQuestionTrue * 10.0) / questions.Count), 1);
                KtVal += KtBlVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Kiến thức", "Bệnh lý", KtBlVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    KtNxtq += KtNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

          
            // Theo dõi chỉ số: KTT001CH01 ~ KTT001CH05
            var KtTdcsVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("KTT001", context);
            if (questions.Count > 0)
            {
                var countQuestionTrue = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionCode == r.QuestionCode && m.QuestionAnswer == r.QuestionAnswer)).Count();

                KtTdcsVal = Math.Round(((countQuestionTrue * 10.0) / questions.Count), 1);
                KtVal += KtTdcsVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Kiến thức", "Theo dõi chỉ số", KtTdcsVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    KtNxtq += KtNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }

            }

            // Dinh duong
            var KtDdVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("KTN001", context);
            if (questions.Count > 0)
            {
                var countQuestionTrue = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionCode == r.QuestionCode && m.QuestionAnswer == r.QuestionAnswer)).Count();

                KtDdVal = Math.Round(((countQuestionTrue * 10.0) / questions.Count), 1);
                KtVal += KtDdVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Kiến thức", "Dinh dưỡng", KtDdVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    KtNxtq += KtNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }

            }

            // Vận động
            var KtVdVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("KTE001", context);
            if (questions.Count > 0)
            {
                var countQuestionTrue = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionCode == r.QuestionCode && m.QuestionAnswer == r.QuestionAnswer)).Count();

                KtVdVal = Math.Round(((countQuestionTrue * 10.0) / questions.Count), 1);
                KtVal += KtVdVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Kiến thức", "Vận động", KtVdVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    KtNxtq += KtNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }

            }
            // TODO
            var KtThVal = 0;
            var KtTlhvVal = 0;
            var KtPhanloai = "";
            KtVal = Math.Round(KtVal / 4.0, 1);
            rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Kiến thức", "Kiến thức", KtVal, context);
            if (rangeValue != null)
            {
                KtPhanloai = rangeValue.Description;

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    Nxtq += Nxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
                
            }

            // Khả năng tự chăm sóc
            var KntcsVal = 0.0;
            var KntcsNxtq = "";

            // Khả năng tự chăm sóc - Chế độ ăn uống
            var KntcsCdauVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("CSN001CH", context);
            if (questions.Count > 0)
            {
                var CSN001CH01 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionId == "CSN001CH01" && m.QuestionCode == r.QuestionCode)).FirstOrDefault();
                var CSN001CH01Val = 0.0;
                if (CSN001CH01 != null)
                {
                   double.TryParse( CSN001CH01.QuestionAnswer,out CSN001CH01Val);
                }

                var CSN001CH02 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionId == "CSN001CH02" && m.QuestionCode == r.QuestionCode)).FirstOrDefault();
                var CSN001CH02Val = 0.0;
                if (CSN001CH02 != null)
                {
                    double.TryParse(CSN001CH02.QuestionAnswer, out CSN001CH02Val);
                }

                var CSN001CH03 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionId == "CSN001CH03" && m.QuestionCode == r.QuestionCode)).FirstOrDefault();
                var CSN001CH03Val = 0.0;
                if (CSN001CH03 != null)
                {
                    double.TryParse(CSN001CH03.QuestionAnswer, out CSN001CH03Val);
                }

                var CSN001CH04 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionId == "CSN001CH04" && m.QuestionCode == r.QuestionCode)).FirstOrDefault();
                var CSN001CH04Val = 0.0;
                if (CSN001CH04 != null)
                {
                    double.TryParse(CSN001CH04.QuestionAnswer, out CSN001CH04Val);
                }


                KntcsCdauVal = Math.Round((((CSN001CH01Val + CSN001CH02Val) / 2.0) + ((CSN001CH03Val + 7 - CSN001CH04Val) / 2.0)) / 2.0 * 10.0 / 7.0,  1);
                KntcsVal += KntcsCdauVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Khả năng tự chăm sóc", "Chế độ ăn uống", KntcsCdauVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    KntcsNxtq += KntcsNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            // Khả năng tự chăm sóc - Chế độ vận động
            var KntcsCdvdVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("CSE001CH", context);
            if (questions.Count > 0)
            {
                var CSE001CH01 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionId == "CSE001CH01" && m.QuestionCode == r.QuestionCode)).FirstOrDefault();
                var CSE001CH0Val = 0.0;
                if (CSE001CH01 != null)
                {
                    double.TryParse(CSE001CH01.QuestionAnswer, out CSE001CH0Val);
                }

                var CSE001CH02 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionId == "CSE001CH02" && m.QuestionCode == r.QuestionCode)).FirstOrDefault();
                var CSE001CH02Val = 0.0;
                if (CSE001CH02 != null)
                {
                    double.TryParse(CSE001CH02.QuestionAnswer, out CSE001CH02Val);
                }

                KntcsCdvdVal = Math.Round(((CSE001CH0Val + CSE001CH02Val) / 2.0) * 10.0 / 7.0, 1);
                KntcsVal += KntcsCdvdVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Khả năng tự chăm sóc", "Chế độ vận động", KntcsCdvdVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    KntcsNxtq += KntcsNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            // Khả năng tự chăm sóc - Theo dõi đường huyết
            var KntcsTddhVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("CST001CH", context);
            if (questions.Count > 0)
            {
                var CST001CH01 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionId == "CST001CH01" && m.QuestionCode == r.QuestionCode)).FirstOrDefault();
                var CST001CH01Val = 0.0;
                if (CST001CH01 != null)
                {
                    double.TryParse(CST001CH01.QuestionAnswer, out CST001CH01Val);
                }

                var CST001CH02 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionId == "CST001CH02" && m.QuestionCode == r.QuestionCode)).FirstOrDefault();
                var CST001CH02Val = 0.0;
                if (CST001CH02 != null)
                {
                    double.TryParse(CST001CH02.QuestionAnswer, out CST001CH02Val);
                }

                KntcsTddhVal = Math.Round(((CST001CH01Val + CST001CH01Val) / 2.0) * 10.0 / 7.0, 1);
                KntcsVal += KntcsTddhVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Khả năng tự chăm sóc", "Theo dõi đường huyết", KntcsTddhVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    KntcsNxtq += KntcsNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            // Khả năng tự chăm sóc - Đo đường huyết
            var KntcsCsbcVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("CSC001CH", context);
            if (questions.Count > 0)
            {
                var CSC001CH11 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionId == "CSC001CH11" && m.QuestionCode == r.QuestionCode)).FirstOrDefault();
                var CSC001CH11Val = 0.0;
                if (CSC001CH11 != null)
                {
                    double.TryParse(CSC001CH11.QuestionAnswer, out CSC001CH11Val);
                }

                var CSC001CH12 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted
                        && questions.Any(m => m.QuestionId == "CSC001CH12" && m.QuestionCode == r.QuestionCode)).FirstOrDefault();
                var CSC001CH12Val = 0.0;
                if (CSC001CH12 != null)
                {
                    double.TryParse(CSC001CH12.QuestionAnswer, out CSC001CH12Val);
                }

                KntcsCsbcVal = Math.Round(((CSC001CH11Val + CSC001CH12Val) / 2.0) * 10.0 / 7.0, 1);
                KntcsVal += KntcsCsbcVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Khả năng tự chăm sóc", "Chăm sóc bàn chân", KntcsCsbcVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    KntcsNxtq += KntcsNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            // Khả năng tự chăm sóc - Hút thuốc
            var KntcsHtVal = 0.0;

            var KntcsPhanloai = "";
            KntcsVal = Math.Round(KntcsVal / 4.0, 1);
            rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Khả năng tự chăm sóc", "Khả năng tự chăm sóc", KntcsVal, context);
            if (rangeValue != null)
            {
                KntcsPhanloai = rangeValue.Description;

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    Nxtq += Nxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }

            }

            // Mức độ rào cản
            var MdrcVal = 0.0;
            var MdrcPhanloai = "";
            var MdrcNxtq = "";

            // Mức độ rào cản - Chế độ ăn uống
            var MdrcCdauVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("RCN001CH", context);
            if (questions.Count > 0)
            {
                var outTemp = 0.0;
                var RCN001CHAvg = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted && Double.TryParse(r.QuestionAnswer, out outTemp) && outTemp > 0 
                        && questions.Any(m =>m.QuestionCode == r.QuestionCode)).Select( a => Double.Parse(a.QuestionAnswer)).DefaultIfEmpty().Average();

                MdrcCdauVal = Math.Round(RCN001CHAvg * 10.0 / 5.0, 1);
                MdrcVal += MdrcCdauVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Mức độ rào cản", "Chế độ ăn uống", MdrcCdauVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    MdrcNxtq += MdrcNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            // Mức độ rào cản - Chế độ vận động
            var MdrcCdvdVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("RCE001CH", context);
            if (questions.Count > 0)
            {
                var outTemp = 0.0;
                var RCE001CHAvg = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted && Double.TryParse(r.QuestionAnswer, out outTemp) && outTemp > 0
                        && questions.Any(m => m.QuestionCode == r.QuestionCode)).Select(a => Double.Parse(a.QuestionAnswer)).DefaultIfEmpty().Average();

                MdrcCdvdVal = Math.Round(RCE001CHAvg * 10.0 / 5.0, 1);
                MdrcVal += MdrcCdvdVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Mức độ rào cản", "Chế độ vận động", MdrcCdvdVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    MdrcNxtq += MdrcNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            // Mức độ rào cản - Dùng thuốc
            var MdrcDtVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("RCA001CH", context);
            if (questions.Count > 0)
            {
                var outTemp = 0.0;
                var RCA001CHAvg = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted && Double.TryParse(r.QuestionAnswer, out outTemp) && outTemp > 0
                        && questions.Any(m => m.QuestionCode == r.QuestionCode)).Select(a => Double.Parse(a.QuestionAnswer)).DefaultIfEmpty().Average();

                MdrcDtVal = Math.Round(RCA001CHAvg * 10.0 / 5.0, 1);
                MdrcVal += MdrcDtVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Mức độ rào cản", "Dùng thuốc", MdrcDtVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    MdrcNxtq += MdrcNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            // Mức độ rào cản - Đường huyết
            var MdrcTddhVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("RCT001CH", context);
            if (questions.Count > 0)
            {
                var outTemp = 0.0;
                var RCT001CHAvg = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted && Double.TryParse(r.QuestionAnswer, out outTemp) && outTemp > 0
                        && questions.Any(m => m.QuestionCode == r.QuestionCode)).Select(a => Double.Parse(a.QuestionAnswer)).DefaultIfEmpty().Average();

                MdrcTddhVal = Math.Round(RCT001CHAvg * 10.0 / 5.0, 1);
                MdrcVal += MdrcTddhVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Mức độ rào cản", "Đường huyết", MdrcTddhVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    MdrcNxtq += MdrcNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            MdrcVal = Math.Round(MdrcVal / 4.0, 1);
            rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Mức độ rào cản", "Mức độ rào cản", MdrcVal, context);
            if (rangeValue != null)
            {
                MdrcPhanloai = rangeValue.Description;
                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    Nxtq += Nxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            // Khả năng điều chỉnh tâm lý
            var KndctlVal = 0.0;
            var KndctlPhanloai = "";
            var KndctlNxtq = "";

            // Khả năng điều chỉnh tâm lý - Gánh nặng cảm xúc
            var KndctlGncxVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("TLA001CH", context);
            if (questions.Count > 0)
            {
                var outTemp = 0.0;
                var TLA001CHSum = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted && Double.TryParse(r.QuestionAnswer, out outTemp) && outTemp > 0
                        && questions.Any(m => m.QuestionCode == r.QuestionCode)).Select(a => Double.Parse(a.QuestionAnswer)).Sum();

                KndctlGncxVal = Math.Round(TLA001CHSum / questions.Count * 10.0 / 6.0, 1);
                KndctlVal += KndctlGncxVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Khả năng điều chỉnh tâm lý", "Gánh nặng cảm xúc", KndctlGncxVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    KndctlNxtq += KndctlNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            // Khả năng điều chỉnh tâm lý - Căng thẳng liên quan đến bác sĩ
            var KndctlCtlqdbsVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("TLA002CH", context);
            if (questions.Count > 0)
            {
                var outTemp = 0.0;
                var TLA002CHSum = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted && Double.TryParse(r.QuestionAnswer, out outTemp) && outTemp > 0
                        && questions.Any(m => m.QuestionCode == r.QuestionCode)).Select(a => Double.Parse(a.QuestionAnswer)).Sum();

                KndctlCtlqdbsVal = Math.Round(TLA002CHSum / questions.Count * 10.0 / 6.0, 1);
                KndctlVal += KndctlCtlqdbsVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Khả năng điều chỉnh tâm lý", "Căng thẳng liên quan đến bác sĩ", KndctlCtlqdbsVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    KndctlNxtq += KndctlNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            // Khả năng điều chỉnh tâm lý - Gánh nặng về tuân thủ điều trị
            var KndctlGnvttdtVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("TLA003CH", context);
            if (questions.Count > 0)
            {
                var outTemp = 0.0;
                var TLA003CHSum = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted && Double.TryParse(r.QuestionAnswer, out outTemp) && outTemp > 0
                        && questions.Any(m => m.QuestionCode == r.QuestionCode)).Select(a => Double.Parse(a.QuestionAnswer)).Sum();

                KndctlGnvttdtVal = Math.Round(TLA003CHSum / questions.Count * 10.0 / 6.0, 1);
                KndctlVal += KndctlGnvttdtVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Khả năng điều chỉnh tâm lý", "Gánh nặng về tuân thủ điều trị", KndctlGnvttdtVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    KndctlNxtq += KndctlNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            // Khả năng điều chỉnh tâm lý - Gánh nặng về tuân thủ điều trị
            var KndctlCttcmqhVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("TLA004CH", context);
            if (questions.Count > 0)
            {
                var outTemp = 0.0;
                var TLA004CHSum = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted && Double.TryParse(r.QuestionAnswer, out outTemp) && outTemp > 0
                        && questions.Any(m => m.QuestionCode == r.QuestionCode)).Select(a => Double.Parse(a.QuestionAnswer)).Sum();

                KndctlCttcmqhVal = Math.Round(TLA004CHSum / questions.Count * 10.0 / 6.0, 1);
                KndctlVal += KndctlCttcmqhVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Khả năng điều chỉnh tâm lý", "Căng thẳng trong các mối quan hệ", KndctlCttcmqhVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    KndctlNxtq += KndctlNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            KndctlVal = Math.Round(KndctlVal / 4.0, 1);
            rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Khả năng điều chỉnh tâm lý", "Khả năng điều chỉnh tâm lý", KndctlVal, context);
            if (rangeValue != null)
            {
                KndctlPhanloai = rangeValue.Description;
                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    Nxtq += Nxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }

            // Động lực thay đổi
            var DltdVal = 0.0;
            var DltdPhanloai = "";
            var DltdNxtq = "";

            // Động lực thay đổi - Động lực thay đổi bên trong
            var DltdDltdbtVal = 0.0;
            var DltdDltdbnVal = 0.0;
            questions = await this.SurveyQuestionMappingService.GetQuestionByPrefix("DLA001CH", context);
            string[] dongLucthayDoiBenTrongQuestion = new string[] { "DLA001CH02", "DLA001CH03", "DLA001CH07", "DLA001CH10", "DLA001CH13", "DLA001CH16", "DLA001CH18", "DLA001CH19"};
            string[] dongLucthayDoiBenNgoaiQuestion = new string[] { "DLA001CH01", "DLA001CH04", "DLA001CH05", "DLA001CH06", "DLA001CH08", "DLA001CH09", "DLA001CH11", "DLA001CH12", "DLA001CH14", "DLA001CH15", "DLA001CH17"};
            if (questions.Count > 0)
            {
                var questions1 = questions.Where(r => dongLucthayDoiBenTrongQuestion.Contains(r.QuestionId)).ToList();
                var questions2 = questions.Where(r => dongLucthayDoiBenNgoaiQuestion.Contains(r.QuestionId)).ToList();

                var outTemp = 0.0;
                var sum1 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted && Double.TryParse(r.QuestionAnswer, out outTemp) && outTemp > 0
                        && questions1.Any(m => m.QuestionCode == r.QuestionCode)).Select(a => Double.Parse(a.QuestionAnswer)).Sum();

                var sum2 = surveyImportEntity.SurveyImportDetails.Where(r => !r.IsDeleted && Double.TryParse(r.QuestionAnswer, out outTemp) && outTemp > 0
                       && questions2.Any(m => m.QuestionCode == r.QuestionCode)).Select(a => Double.Parse(a.QuestionAnswer)).Sum();

                DltdDltdbtVal = Math.Round(sum1 / questions1.Count * 10.0 / 7.0, 1);
                DltdDltdbnVal = Math.Round(sum2 / questions2.Count * 10.0 / 7.0, 1);
                DltdVal = DltdDltdbtVal + DltdDltdbnVal;

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Động lực thay đổi", "Động lực thay đổi bên trong", DltdDltdbtVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    DltdNxtq += DltdNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }

                rangeValue = await this.ISurveyRangeValueService.GetRangeValueByCategory("Động lực thay đổi", "Động lực thay đổi bên ngoài", DltdDltdbnVal, context);

                if (!string.IsNullOrEmpty(rangeValue?.MessageToCustomer))
                {
                    DltdNxtq += DltdNxtq != "" ? "\r\n" + rangeValue?.MessageToCustomer : rangeValue?.MessageToCustomer;
                }
            }
            DltdVal = Math.Round(DltdVal / 2.0, 1);

            var result = await this.CreateEntity(
                new SurveyImportResultEntity
                {
                    Hba1cVal = Hba1cVal,
                    Hba1cPhanloai = Hba1cPhanloai,
                    BmiVal = BmiVal,
                    BmiPhanloai = BmiPhanloai,

                    KtBlVal = KtBlVal,
                    KtTdcsVal = KtTdcsVal,
                    KtDdVal = KtDdVal,
                    KtVdVal = KtVdVal,
                    KtThVal = KtThVal,
                    KtTlhvVal = KtTlhvVal,
                    KtVal = KtVal,
                    KtPhanloai = KtPhanloai,
                    KtNxtq = KtNxtq,

                    KntcsHtVal = KntcsHtVal,
                    KntcsCsbcVal = KntcsCsbcVal,
                    KntcsTddhVal = KntcsTddhVal,
                    KntcsCdvdVal = KntcsCdvdVal,
                    KntcsCdauVal = KntcsCdauVal,
                    KntcsVal = KntcsVal,
                    KntcsPhanloai = KntcsPhanloai,
                    KntcsNxtq = KntcsNxtq,

                    MdrcDtVal = MdrcDtVal,
                    MdrcTddhVal = MdrcTddhVal,
                    MdrcCdvdVal = MdrcCdvdVal,
                    MdrcCdauVal = MdrcCdauVal,
                    MdrcVal = MdrcVal,
                    MdrcPhanloai = MdrcPhanloai,
                    MdrcNxtq = MdrcNxtq,

                    KndctlCtlqdbsVal = KndctlCtlqdbsVal,
                    KndctlCttcmqhVal = KndctlCttcmqhVal,
                    KndctlGnvttdtVal = KndctlGnvttdtVal,
                    KndctlGncxVal = KndctlGncxVal,
                    KndctlVal = KndctlVal,
                    KndctlPhanloai = KndctlPhanloai,
                    KndctlNxtq = KndctlNxtq,

                    DltdDltdbtVal = DltdDltdbtVal,
                    DltdDltdbnVal = DltdDltdbnVal,
                    DltdVal = DltdVal,
                    DltdPhanloai = DltdPhanloai,
                    DltdNxtq = DltdNxtq,

                    Nxtq = Nxtq,
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
                    if (values.Count >= 18)
                    {
                        values[5].Text = entity.KtBlVal == 0 ? "-" : entity.KtBlVal + "";
                        values[6].Text = entity.KtTdcsVal == 0 ? "-" : entity.KtTdcsVal + "";
                        values[7].Text = entity.KtDdVal == 0 ? "-" : entity.KtDdVal + "";
                        values[8].Text = entity.KtVdVal == 0 ? "-" : entity.KtVdVal + "";
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
                        values[6].Text = entity.MdrcCdvdVal == 0 ? "-" : entity.MdrcCdvdVal + "";
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
