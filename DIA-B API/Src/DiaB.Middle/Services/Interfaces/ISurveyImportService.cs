using CpTech.Core.Common.Dtos;
using CpTech.Core.Middle.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using ActionContext = DiaB.Common.Utilities.ActionContext;
using DiaB.Middle.Dtos.SurveyImportDtos;
using System;

namespace DiaB.Middle.Services.Interfaces
{
    public interface ISurveyImportService : ICoreService
    {
        Task<List<SurveyImportDtos.AppItem>> GetAll(ActionContext context);
        Task<IPagingData<SurveyImportDtos.AppItem>> GetPage(SurveyImportDtos.AppFilter input, ActionContext context);
        Task<SurveyImportDtos.AppItem> GetSurveyImportById(string userCode, string surveyCode, ActionContext context);
        Task<IList<Guid>> CreateSurveyImportResult(SurveyImportDtos.AppInput input, ActionContext context);
    }
}
