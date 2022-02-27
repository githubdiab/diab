using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CpTech.Core.Common.Dtos;
using CpTech.Core.WebApi.Filters;
using CpTech.Core.WebApi.Results;
using DiaB.Common.Extensions;
using DiaB.Middle.Dtos.SurveyImportDtos;
using DiaB.Middle.Dtos.SurveyImportResultDtos;
using DiaB.Middle.Services.Interfaces;
using DiaB.WebApi.Controllers.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DiaB.WebApi.Controllers.Admin
{
    [SwaggerTag("Account Admin")]
    [Route("App/Admin/SurveyImport")]
    [ApiExplorerSettings(GroupName = "app")]
    public class SurveyImportAdminController : AppController
    {
        public ISurveyImportService _surveyImportService { get; set; }
        public ISurveyImportResultService _surveyImportResultService { get; set; }

        [HttpGet("list")]
        [SwaggerResponse(200, null, typeof(DataResult<IPagingData<SurveyImportDtos.AppItem>>))]
        public async Task<IActionResult> Get(SurveyImportDtos.AppFilter filter)
        {
            var result = await _surveyImportService.GetPage(filter, this.AdminContext);

            return new DataResult<IPagingData<SurveyImportDtos.AppItem>>(result);
        }

        [HttpGet("result/{surveyResultId}")]
        [SwaggerOperation(Summary = "lấy [controller] theo mã định danh")]
        [SwaggerResponse(200, null, typeof(DataResult<SurveyImportResultDtos.AppItem>))]
        public async Task<IActionResult> GetSurveyImportResultById(Guid surveyResultId)
        {
            var surveyImportResult = await _surveyImportResultService.GetSurveyImportResultById(surveyResultId, this.AdminContext);

            return new DataResult<SurveyImportResultDtos.AppItem>(surveyImportResult);
        }

        [HttpPost("result")]
        [SwaggerResponse(200, null, typeof(DataResult<IList<Guid>>))]
        public async Task<IActionResult> CreateSurveyImportResult([FromBody] SurveyImportDtos.AppInput input)
        {
            var resultList = await this._surveyImportService.CreateSurveyImportResult(input, this.ActionContext);
            return new DataResult<IList<Guid>>(resultList);
        }

        [HttpPut("result")]
        public async Task<IActionResult> UpdateSurveyImportResult([FromForm] SurveyImportResultDtos.AppUpdate input)
        {
            await this._surveyImportResultService.UpdateSurveyImportResult(input, this.AdminContext);

            return Ok();
        }

        [HttpPut("result/{surveyResultId}")]
        public async Task<IActionResult> CloseSurveyImportResult(Guid surveyResultId)
        {
            await _surveyImportResultService.CloseSurveyImportResult(surveyResultId, this.AdminContext);
            return Ok();
        }

        [HttpPost("result/download")]
        [SwaggerOperation(Summary = "lấy [controller] theo mã định danh")]
        [SwaggerResponse(200, null, typeof(FileStreamResult))]
        public async Task<IActionResult> DownloadReport([FromBody] SurveyImportResultDtos.AppInput input)
        {
            var result = await this._surveyImportResultService.CreateSurveyImportResultReport(input, this.ActionContext);
            return this.File(result.FileReport, result.FileReportTitle.GetMimeType());
        }
    }
}
