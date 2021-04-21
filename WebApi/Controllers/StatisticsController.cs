using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Web;
using System.IO;
using Microsoft.AspNetCore.Http;




namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {

        private readonly ILogger<StatisticsController> _logger;

        public StatisticsController(ILogger<StatisticsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public List<Statistics> Get()
        {


            var _statisticsService = new StatisticsService();
            var path = @"/Users/mveerapp/Downloads/MOCK_DATA_TU.csv";
            //Here We are calling function to read CSV file  
            var resultData = _statisticsService.ReadCSVFile(path);
            int cnt = resultData.Count();

            List<Statistics> statistics = new List<Statistics>();
            // statistics.Count(resultData.Count);
            statistics = resultData;

            //statistics.Add(resultData[0]);
            return statistics;
        }
        [HttpGet]
        [Route("GetStatistics/{FirstName}")]
        public List<Statistics> GetStatistics(string FirstName)
        {


            var _statisticsService = new StatisticsService();
            var path = @"/Users/mveerapp/Downloads/MOCK_DATA_TU.csv";
            //Here We are calling function to read CSV file  
            var resultData = _statisticsService.ReadCSVFile(path);
            int cnt = resultData.Count();

            var statistics = from result in resultData
                             where result.firstName.Equals(FirstName)
                             select result;

            //statistics.Add(resultData[0]);
            return statistics.ToList();
        }

    }
}
