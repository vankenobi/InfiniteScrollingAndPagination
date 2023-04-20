using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ScrollPagination.Model;


namespace ScrollPagination.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaginationController : Controller
    {
        [NonAction]
        public (int,List<Product>) ReadJsonFile()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(),"Data","Product.json");
            string json = System.IO.File.ReadAllText(path);
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
            var count = products.Count();
            
            return (count,products);
        }

        [HttpGet]
        public PageResult<Product> GetProductList(int page, int pageSize)
        {
            var result = ReadJsonFile();
            var count = result.Item1;
            List<Product> products = result.Item2;

            products = products.Skip((page - 1) * pageSize)
                                             .Take(pageSize)
                                             .ToList();

            PageResult<Product> pageResult = new PageResult<Product>() {
                Items = products,
                PageNumber = page,
                PageSize = pageSize,
                TotalRecord = count
            };
  
            return pageResult;     
        }
    }
}

