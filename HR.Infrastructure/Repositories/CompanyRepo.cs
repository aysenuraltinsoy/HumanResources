using HR.Domain.Entities;
using HR.Domain.Repositories;
using HR.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.Infrastructure.Repositories
{
    public class CompanyRepo : BaseRepo<AppCompany>,ICompanyRepo
    {
        public CompanyRepo(HumanResourcesDbContext humanResourcesDbContext) : base(humanResourcesDbContext)
        {
           
        }
      
    }
}
