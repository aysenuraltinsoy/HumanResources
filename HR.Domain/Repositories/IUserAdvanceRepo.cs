using HR.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.Domain.Repositories
{
    public interface IUserAdvanceRepo : IBaseRepo<AppUserAdvance>
    {
       
    }
}
