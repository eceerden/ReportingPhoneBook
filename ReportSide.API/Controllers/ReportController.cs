using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using ReportSide.API.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportSide.API.Controllers
{  
    [ApiController]
    public class ReportController : Controller
    {
            
            private readonly ReportContext _reportcontext;
            private ConsumerConfig _config;

            public ReportController(ReportContext reportcontext, ConsumerConfig config)
            {
            _reportcontext = reportcontext;
                this._config = config;
            }

         

            [Route("getperson")]
            [HttpGet]
            public IActionResult Get()
            {
                using (var consumer = new ConsumerBuilder<Null, string>(_config).Build())
                {
                    consumer.Subscribe("temp-topic-rpb");
                    while (true)
                    {
                    //var report = _reportcontext.reports.FirstOrDefault();
                        var cr = consumer.Consume();
                        var msg = cr.Message.Value;
                        return Ok(msg);
                    }
                }
            }
        
    }
}
