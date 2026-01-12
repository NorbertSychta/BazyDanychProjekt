using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Areas.Identity.Data;
using Projekt.Models;
using Projekt.Models.ViewModels;

namespace Projekt.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Orders/Create
        public async Task<IActionResult> Create()
        {
            var vm = new OrderCreateVM
            {
                Customers = await _context.Customers
                    .OrderBy(c => c.Name)
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToListAsync(),

                Products = await _context.Products
                    .OrderBy(p => p.NamePL)
                    .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.NamePL })
                    .ToListAsync(),

                Quantity = 1
            };

            return View(vm);
        }

        // POST: /Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                // odtwórz listy po błędzie walidacji
                vm.Customers = await _context.Customers
                    .OrderBy(c => c.Name)
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToListAsync();

                vm.Products = await _context.Products
                    .OrderBy(p => p.NamePL)
                    .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.NamePL })
                    .ToListAsync();

                return View(vm);
            }

            var product = await _context.Products.FirstAsync(p => p.Id == vm.ProductId);

            var order = new Order
            {
                CustomerId = vm.CustomerId,
                OrderDate = DateTime.UtcNow,
                Status = "New"
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(); // żeby Order dostał Id

            var item = new OrderItem
            {
                OrderId = order.Id,
                ProductId = vm.ProductId,
                Quantity = vm.Quantity,
                UnitPriceUSD = product.PriceUSD
            };

            _context.OrderItems.Add(item);

            // prosta aktualizacja stanu magazynowego
            product.StockQuantity -= vm.Quantity;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Products");
        }
    }
}
