using CpTech.Core.Common.Dtos;
using CpTech.Core.Middle.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using ActionContext = DiaB.Common.Utilities.ActionContext;
using DiaB.Middle.Dtos.SurveyImportDtos;

namespace DiaB.Middle.Services.Interfaces
{
    public interface ISurveyImportService : ICoreService
    {
        Task<List<SurveyImportDtos.AppItem>> GetAll(ActionContext context);

        Task<IPagingData<SurveyImportDtos.AppItem>> GetPage(SurveyImportDtos.AppFilter input, ActionContext context);

        Task<SurveyImportDtos.AppItem> GetSurveyImportById(int userCode, string surveyCode, ActionContext context = null);
    }
}
