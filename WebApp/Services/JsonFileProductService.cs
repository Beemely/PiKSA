using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WebApp.Models;
using Microsoft.AspNetCore.Hosting;

namespace WebApp.Services
{
    public class JsonFileProductService
    {

        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "Products.json"); }
        }
        public IEnumerable<Product> GetProducts()
        {
            using (var JsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(JsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }





    }
}


