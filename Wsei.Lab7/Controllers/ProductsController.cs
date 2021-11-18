using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Wsei.Lab7.Models;
using Microsoft.AspNetCore.Mvc;
using Wsei.Lab7.Database;
using Wsei.Lab7.Entities;
using Microsoft.EntityFrameworkCore;

namespace Wsei.Lab7.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _dbContext;
        public ProductsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List(string name)
        {
            IQueryable<ProductEntity> productsQuery = _dbContext.Products;
            if (!string.IsNullOrEmpty(name))
            {
                productsQuery = productsQuery.Where(x => x.Name.Contains(name));
            }
            var products = await productsQuery.ToListAsync();
            return View(products);
        }

        [HttpPost]

        public async Task<IActionResult> Add(ProductModel product)
        {
            var entity = new ProductEntity
            {
                Name = product.Name,
                Description = product.Description,
                IsVisible = product.IsVisible
            };

            var viewModel = new ProductStatsViewModel
            {
                NameLength = product.Name.Length,
                DescriptionLength = product.Description.Length,
            };

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return View(viewModel);
        }
    }
}
