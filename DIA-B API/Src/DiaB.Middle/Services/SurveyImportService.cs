using CpTech.Core.Common.Dtos;
using CpTech.Core.Middle.Dtos;
using DiaB.Data.Database.Entities.Import;
using DiaB.Data.Repositories.Interfaces;
using DiaB.Middle.Abstracts;
using DiaB.Middle.Dtos.SurveyImportDtos;
using DiaB.Middle.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActionContext = DiaB.Common.Utilities.ActionContext;

namespace DiaB.Middle.Services
{
    public class SurveyImportService : BaseService<SurveyImportEntity>, ISurveyImportService
    {
        public SurveyImportService(IAppRepo<SurveyImportEntity> repo)
            : base(repo)
        {
        }

        protected override IQueryable<SurveyImportEntity> FilterQuery(IQueryable<SurveyImportEntity> query, ICoreFilterDto input, IActionContext context)
        {
            if (!(input is SurveyImportDtos.Filter filter))
            {
                return base.FilterQuery(query, input, context);
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(x => x.AccountImport.UserCode.ToString() == filter.UserCode);
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(x => x.AccountImport.UserName.Contains(filter.Username, StringComparison.CurrentCultureIgnoreCase));
            }

            if (!string.IsNullOrEmpty(filter.UserPhone))
            {
                query = query.Where(x => x.AccountImport.UserPhone.Contains(filter.UserPhone, StringComparison.CurrentCultureIgnoreCase));
            }

            if (!string.IsNullOrEmpty(filter.SurveyType))
            {
                query = query.Where(x => x.SurveyType == filter.SurveyType);
            }

            if (!string.IsNullOrEmpty(filter.SurveyName))
            {
                query = query.Where(x => x.SurveyName.Contains(filter.SurveyName, StringComparison.CurrentCultureIgnoreCase));
            }

            if ("1".Equals(filter.SurveyStatus))
            {
                query = query.Where(x => x.SurveyImportResult != null);
            }

            if (!string.IsNullOrEmpty(filter.OrderBy))
            {
                if (filter.OrderBy.StartsWith("username asc"))
                {
                    query = query.OrderBy(x => x.AccountImport.UserName);
                }
                else if (filter.OrderBy.StartsWith("username desc"))
                {
                    query = query.OrderByDescending(x => x.AccountImport.UserName);
                }
                else if (filter.OrderBy.StartsWith("usercode asc"))
                {
                    query = query.OrderBy(x => x.AccountImport.UserCode);
                }
                else if (filter.OrderBy.StartsWith("usercode desc"))
                {
                    query = query.OrderByDescending(x => x.AccountImport.UserCode);
                }
                else if (filter.OrderBy.StartsWith("importDay asc"))
                {
                    query = query.OrderBy(x => x.ImportDay);
                }
                else if (filter.OrderBy.StartsWith("importDay desc"))
                {
                    query = query.OrderByDescending(x => x.ImportDay);
                }

                filter.OrderBy = string.Empty;
            }

            return base.FilterQuery(query, input, context);
        }

        public async Task<List<SurveyImportDtos.AppItem>> GetAll(ActionContext context)
        {
            var entities = await this.GetListEntity(del => del.Where(r => !r.IsDeleted), context);

            return this.Mapper.Map<List<SurveyImportDtos.AppItem>>(entities);
        }

        public async Task<IPagingData<SurveyImportDtos.AppItem>> GetPage(SurveyImportDtos.AppFilter input, ActionContext context)
        {
            var filter = this.Mapper.Map<SurveyImportDtos.Filter>(input);

            return await this.GetPage<SurveyImportDtos.AppItem>(filter, context);
        }

        public async Task<SurveyImportDtos.AppItem> GetSurveyImportById(int userCode, string surveyCode, ActionContext context = null)
        {
            var surveyImport = await this.GetEntity(del => del.Where(r => !r.IsDeleted &&  r.SurveyCode == surveyCode && r.AccountImport.UserCode == userCode), context);

            var result = this.Mapper.Map<SurveyImportDtos.AppItem>(surveyImport);

            return result;
        }
    }
}
