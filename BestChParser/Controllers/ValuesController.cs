using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestChParser.Model;
using Microsoft.AspNetCore.Mvc;
using ParseLib.MODEL.Work;

namespace BestChParser.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<BaseExchanger> Get()
        {
            return Parsing.Run();
        }
    }
}
