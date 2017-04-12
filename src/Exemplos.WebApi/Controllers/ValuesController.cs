using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlayFactory.AspNetCore.Mvc.Filters;
using PlayFactory.AspNetCore.Mvc.Filters.UnitOfWork;
using PlayFactory.Core.Domains;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exemplos.WebApi.Controllers
{
    public interface IAppTeste
    {
        
    }

    public class AppTeste : DomainService, IAppTeste
    {
        
    }

    [Route("api/[controller]")]
    [DisableUnitOfWork]
    //[DisableUnitOfWork]
    public class ValuesController : Controller
    {
        public ILogger<ValuesController> Logger { get; set; }

        public ValuesController(ILogger<ValuesController> logger, IAppTeste appTeste)
        {
            var a = appTeste as DomainService;
            Logger = logger;
        }

        // GET: api/values
        [HttpGet]
        [DisableUnitOfWork]
        public IEnumerable<string> Get()
        {
            throw new Exception("Erro de Teste.");
            Logger.LogDebug("Debug");
            Logger.LogInformation("Information");
            Logger.LogWarning("Warning");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [UnitOfWork]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
