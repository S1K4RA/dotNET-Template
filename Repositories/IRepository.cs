using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using $safeprojectname$.Models;
using $safeprojectname$.Models.DTO;

namespace $safeprojectname$.Repositories
{
    /// <summary>
    /// IRepository digunakan sebagai interface dari
    /// repository
    /// </summary>
    public interface IRepository
    {
        Task<IEnumerable<Model>> ExampleTaskAsync(Dto dto);

        Task<IEnumerable<Model>> ExamplePaginatedTaskAsync(PaginatedDto dto);
    }
}