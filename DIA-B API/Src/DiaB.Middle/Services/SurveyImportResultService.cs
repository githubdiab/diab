using CpTech.Core.Common.Dtos;
using CpTech.Core.Middle.Dtos;
using DiaB.Common.Constants;
using DiaB.Common.Enums;
using DiaB.Common.Extensions;
using DiaB.Data.Database.Entities.Import;
using DiaB.Data.Repositories.Interfaces;
using DiaB.Middle.Abstracts;
using DiaB.Middle.Dtos.ImageDtos;
using DiaB.Middle.Dtos.SurveyImportDtos;
using DiaB.Middle.Dtos.SurveyImportResultDtos;
using DiaB.Middle.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using ActionContext = DiaB.Common.Utilities.ActionContext;

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
                    MdrcDhVal =  5,
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

                await using (FileStream fileStream = new FileStream(physicalPath, FileMode.Create))
                {
                    await (new FileStream("../DiaB.Common/Template/bao_cao_dau_ra.docx", FileMode.Open, FileAccess.Read)).CopyToAsync(fileStream);
                }
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
    }
}
