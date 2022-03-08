

using CpTech.Core.Common.Dtos;
using DiaB.Data.Database.Entities.Import;
using DiaB.Data.Repositories.Interfaces;
using DiaB.Middle.Abstracts;
using DiaB.Middle.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaB.Middle.Services
{
    public class SurveyRangeValueService : BaseService<SurveyRangeValueEntity>, ISurveyRangeValueService
    {

        public SurveyRangeValueService(IAppRepo<SurveyRangeValueEntity> repo)
            : base(repo)
        {
        }

        public async Task<SurveyRangeValueEntity> GetRangeValueByCategory(string category, string subCategory, double value, ActionContext context = null)
        {
            var result = await this.GetListEntity(q => q.Where(r => !r.IsDeleted && r.Category == category && r.SubCategory == subCategory && r.FromValue <= value && value < r.ToValue ), context);

            return result.FirstOrDefault();
        }
    }
}
