﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reflex.Data;
using Reflex.Data.Models;
using Reflex.Services;

namespace Reflex.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ByggrController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IRepository _repository;

        public ByggrController(ApplicationDbContext applicationDbContext, IRepository repository)
        {
            _applicationDbContext = applicationDbContext;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<ByggrConfig> Get()
        {
            return _applicationDbContext.ByggrConfigs;
        }

        [HttpGet("{id}")]
        public ByggrConfig Get(Guid id)
        {
            return _applicationDbContext.ByggrConfigs.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public async Task Post(ByggrConfig byggrConfig)
        {
            await _repository.CreateByggr(byggrConfig);
        }

        [HttpPut]
        public async Task Put(ByggrConfig byggrConfig)
        {
            _applicationDbContext.ByggrConfigs.Update(byggrConfig);
            await _applicationDbContext.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            var config = _applicationDbContext.ByggrConfigs.FirstOrDefault(x => x.Id == id);
            _applicationDbContext.ByggrConfigs.Remove(config);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
