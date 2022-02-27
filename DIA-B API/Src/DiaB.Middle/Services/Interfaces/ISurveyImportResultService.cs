using CpTech.Core.Middle.Services;
using System.Threading.Tasks;
using ActionContext = DiaB.Common.Utilities.ActionContext;
using DiaB.Middle.Dtos.SurveyImportResultDtos;
using System;
using DiaB.Data.Database.Entities.Import;

namespace DiaB.Middle.Services.Interfaces
{
    public interface ISurveyImportResultService : ICoreService
    {
        Task<SurveyImportResultDtos.AppItem> GetSurveyImportResultById(Guid id, ActionContext context = null);
        Task<Guid> CreateSurveyImportResult(SurveyImportEntity surveyImportEntity, ActionContext context);
        Task UpdateSurveyImportResult(SurveyImportResultDtos.AppUpdate input, ActionContext context);
        Task CloseSurveyImportResult(Guid id, ActionContext context);
        Task<SurveyImportResultDtos.AppItem> CreateSurveyImportResultReport(SurveyImportResultDtos.AppInput input, ActionContext context);
    }
}
