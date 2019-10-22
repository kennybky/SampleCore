using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleCore.Context;

namespace SampleCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {

        [HttpGet]
        public object GetSample()
        {
            int count;
            using (var context = new SampleContext())
            {
                count = context.Sample.Select(x => x.Count).DefaultIfEmpty().Max();
                return new { count };
            }
        }
    }
}