using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei.Lab7.Database;

namespace Wsei.Lab7.ViewComponents
{
    public class VisibleProductsList : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public VisibleProductsList(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(int max = 3)
        {
            var products = await _dbContext.Products
                .Where(x => x.IsVisible)
                .Take(max)
                .ToListAsync();

            return View("Default", products);
        }
    }
}
