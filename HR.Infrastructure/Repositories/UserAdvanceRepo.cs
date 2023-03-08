using HR.Domain.Entities;
using HR.Domain.Repositories;
using HR.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Infrastructure.Repositories
{
    public class UserAdvanceRepo : BaseRepo<AppUserAdvance>, IUserAdvanceRepo
    {
        public UserAdvanceRepo(HumanResourcesDbContext humanResourcesDbContext) : base(humanResourcesDbContext)
        {
        }
    }
}
