using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataCenter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataCenterController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DataCenterController> _logger;

        public DataCenterController(ILogger<DataCenterController> logger)
        {
            _logger = logger;
        }

       

        //[HttpGet]
        //public string Get()
        //{
        //    Processor processor = new Processor(3, 3, 12);

        //    processor.Disable(1, 2);
        //    processor.Disable(2, 1);
        //    processor.Disable(3, 3);
        //    var x1 = processor.GETMAX();
        //    processor.Reset(1);
        //    processor.Reset(2);
        //    processor.Disable(1, 2);
        //    processor.Disable(1, 3);
        //    processor.Disable(2, 2);
        //    var x2 = processor.GETMAX();
        //    processor.Reset(3);
        //    var x3 = processor.GETMIN();


        //    //Processor processor = new Processor(2, 3, 9);

        //    //processor.Disable(1, 1);
        //    //processor.Disable(2, 2);
        //    //processor.Reset(2);
        //    //processor.Disable(2, 1);
        //    //processor.Disable(2, 3);
        //    //processor.Reset(1);
        //    //var x2 = processor.GETMAX();
        //    //processor.Disable(2, 1);
        //    //var x3 = processor.GETMIN();

        //    return processor.GetResult();
        //}

        [HttpGet]
        public string Start(string str)
        {
            str = str.Trim();
            string[] comands = str.Split("\\n");
            var line1 = comands[0].Split(" ");

            int n = Int32.Parse(line1[0]);
            int m = Int32.Parse(line1[1]);
            int q = Int32.Parse(line1[2]);

            Processor processor = new Processor(n, m, q);

            for (int i = 1; i < comands.Length-1; i++)
            {
                var command = comands[i].Trim().Split(" ");
                
                switch (command[0])
                {
                    case "RESET":
                        {
                            var ii = int.Parse(command[1]);
                            processor.Reset(ii);
                            break;
                        }
                    case "DISABLE":
                        {
                            var ii = int.Parse(command[1]);
                            var jj = int.Parse(command[2]);
                            processor.Disable(ii, jj);
                            break;
                        }
                    case "GETMAX":
                        processor.GETMAX();
                        break;
                    case "GETMIN":
                        processor.GETMIN();
                        break;
                    default:
                        throw new Exception();
                        break;
                }
            }

            return processor.GetResult();
        }

    }
}