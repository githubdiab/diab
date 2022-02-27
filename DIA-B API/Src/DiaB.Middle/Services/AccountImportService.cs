

using DiaB.Data.Database.Entities.Import;
using DiaB.Data.Repositories.Interfaces;
using DiaB.Middle.Abstracts;
using DiaB.Middle.Services.Interfaces;

namespace DiaB.Middle.Services
{
    public class AccountImportService : BaseService<AccountImportEntity>, IAccountImportService
    {

        public AccountImportService(IAppRepo<AccountImportEntity> repo)
            : base(repo)
        {
        }
    }
}
