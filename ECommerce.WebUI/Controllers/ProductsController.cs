using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Busniss_Logic.IunitofWork;
using Microsoft.IdentityModel.Tokens;
using ECommerce.Data.Models;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly database db;
        private readonly IUnitofWork work;
        private string? searth;

        public ProductsController(database context, IUnitofWork work)
        {
            db = context;
            work = work;
        }


        public async Task<IActionResult> Index()
        {

            var data = work.ProductRepo.GetAllAsync();
            var database = db.Products.Include(p => p.Category).Include(p => p.Discount);
            return View(await database.ToListAsync());
        }


        //public async Task<IActionResult> Index()
        //{
        //    var data = work.ProductRepo.GetAllAsync();
        //    var database = db.Products.Include(p => p.Category).Include(p => p.Discount);
        //    return View(await database.ToListAsync());
        //}

//
        //public async Task<IActionResult> Index() => View(await work.ProductRepo.GetAllAsync());
//edc6caccdb1b093ec418c3561f6c4c7c0941da46



        public async Task<IActionResult> Index(string? searth)
        {

            return View(await work.ProductRepo.GetAllAsync());
        }

        public async Task<IActionResult> Index1() => View(await work.ProductRepo.GetAllAsync());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await work.ProductRepo.FindByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Id");
            ViewData["DiscountId"] = new SelectList(db.Discounts, "Id", "Id");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,ProductName,Description,Price,StockQuantity,IsFeatured,DiscountId,AverageRating")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Id", product.CategoryId);
            ViewData["DiscountId"] = new SelectList(db.Discounts, "Id", "Id", product.DiscountId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Id", product.CategoryId);
            ViewData["DiscountId"] = new SelectList(db.Discounts, "Id", "Id", product.DiscountId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CategoryId,ProductName,Description,Price,StockQuantity,IsFeatured,DiscountId,AverageRating")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(product);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Id", product.CategoryId);
            ViewData["DiscountId"] = new SelectList(db.Discounts, "Id", "Id", product.DiscountId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Products
                .Include(p => p.Category)
                .Include(p => p.Discount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var product = await db.Products.FindAsync(id);
            if (product != null)
            {
                db.Products.Remove(product);
            }

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return db.Products.Any(e => e.Id == id);
        }
    }
}
