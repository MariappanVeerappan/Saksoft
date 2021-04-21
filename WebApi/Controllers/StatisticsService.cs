using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace WebApi.Controllers
{
    public class StatisticsService
    {

            public List<Statistics> ReadCSVFile(string location)
            {
                try
                {
                    using (var reader = new StreamReader(location, Encoding.Default))
                    using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
                    {
                    csv.Context.RegisterClassMap<StatisticsMap>();
                        var records = csv.GetRecords<Statistics>().ToList();
                        return records;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
    }
    public sealed class StatisticsMap : ClassMap<Statistics>
    {
        public StatisticsMap()
        {
            Map(x => x.firstName).Name("firstName");
            Map(x => x.lastName).Name("lastName");
            Map(x => x.age).Name("age");
            Map(x => x.email).Name("email");
            Map(x => x.vantageScore).Name("vantageScore");
            Map(x => x.ficoScore).Name("ficoScore");
        }
    }
}