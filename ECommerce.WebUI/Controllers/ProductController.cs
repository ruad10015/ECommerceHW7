using ECommerce.Business.Abstract;
using ECommerce.Entities.Models;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECommerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(string search)
        {
            var vm = new SearchViewModel
            {
                Search = search
            };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string search)
        {
            var products = await _productService.GetAllByKeyAsync(search);
            return Json(products);
            //int pageSize = 10;

            //var products = new ProductListViewModel
            //{
            //    Products = datas.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            //    PageCount = (int)Math.Ceiling(datas.Count / (double)pageSize),
            //    PageSize = pageSize,
            //    CurrentPage = page,
            //    CurrentCategory = 0,
            //};
        }
    }
}
