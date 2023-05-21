﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleProjects.Server.Models;
using SampleProjects.Server.Services;

namespace SampleProjects.Web.BaseController
{
    public class BaseController<TEntity, TVModel> : Controller,
        IBaseController<TEntity, TVModel> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity, TVModel> _repository;
        private readonly IMapper _mapper;

        public BaseController(IRepository<TEntity, TVModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(nameof(Index))]
        public virtual async Task<IActionResult> Index()
        {
            var entity = await _repository.GetAllAsync();
            var model = _mapper.Map<IList<TVModel>>(entity);
            return Ok(model);
        }

        [HttpGet]
        [Route(nameof(Create))]
        public virtual async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Route(nameof(Create))]
        public virtual async Task<IActionResult> Create(TVModel entity)
        {
            var model = _mapper.Map<TEntity>(entity);

            var result = await _repository.AddAndSaveChangesAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route($"{nameof(Edit)}/{{id}}")]
        public virtual async Task<IActionResult> Edit(int id)
        {
            var model = await _repository.GetAsync(x => x.Id == id);
            var model2 = _mapper.Map<TVModel>(model);
            return Ok(model2);
        }

        [HttpPost]
        [Route(nameof(Edit))]
        public virtual async Task<IActionResult> Edit(TVModel entity)
        {
            var model = _mapper.Map<TEntity>(entity);
            var result = await _repository.EditAsync(model);
            return RedirectToAction("Index");
        }

        [HttpDelete($"{nameof(Delete)}/{{id}}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(x => x.Id == id);
            return Ok(result);
        }

        public virtual async Task<IActionResult> Details(int id)
        {
            var model = await _repository.GetAsync(x => x.Id == id);
            return View(model);
        }
    }
}
