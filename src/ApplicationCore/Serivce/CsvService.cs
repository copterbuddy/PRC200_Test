using ApplicationCore.ISerivce;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Serivce;

public class CsvService : ICsvService
{
    public async Task GenerateCsv()
    {
        try
        {

            List<Foo> data = new()
            {
                new("1"),
                new("2"),
                new("3"),
                new("4"),
                new("5"),
            };

            byte[] bytes;
            using MemoryStream stream = new();
            using CsvWriter csv = new(new StreamWriter(stream), CultureInfo.InvariantCulture);
            csv.WriteRecords(data);
            csv.Flush();

            stream.Seek(0, SeekOrigin.End);
            stream.SetLength(stream.Length);

            bytes = stream.ToArray();

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "filename.csv";
            File.WriteAllBytes(filePath, bytes);
            return;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public class Foo
    {
        public Foo(string id)
        {
            Id = id;
        }

        [Index(0)]
        public string Id { get; set; }
    }
}
