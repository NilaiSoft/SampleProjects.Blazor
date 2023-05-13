using Microsoft.AspNetCore.Mvc;
using SampleProjects.Server.Models;

namespace SampleProjects.Web.BaseController
{
    public interface IBaseController<TEntity, TVModel>
        where TEntity : BaseEntity
    {
        Task<IActionResult> Index();
        Task<IActionResult> Create();

        [HttpPost]
        Task<IActionResult> Create(TVModel entity);
        Task<IActionResult> Edit(int id);

        [HttpPost]
        Task<IActionResult> Edit(TVModel entity);

        Task<IActionResult> Delete(int id);

        Task<IActionResult> Details(int id);
    }
}
