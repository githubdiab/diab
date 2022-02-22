using System;
using System.Linq;
using System.Threading.Tasks;
using CpTech.Core.Common.Dtos;
using CpTech.Core.WebApi.Results;
using DiaB.Middle.Dtos.AccountDtos;
using DiaB.Middle.Dtos.SurveyImportDtos;
using DiaB.Middle.Services.Interfaces;
using DiaB.WebApi.Controllers.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("list")]
        [SwaggerResponse(200, null, typeof(DataResult<IPagingData<SurveyImportDtos.AppItem>>))]
        public async Task<IActionResult> Get(SurveyImportDtos.AppFilter filter)
        {
            var result = await _surveyImportService.GetPage(filter, this.AdminContext);

            return new DataResult<IPagingData<SurveyImportDtos.AppItem>>(result);
        }
    }
}
