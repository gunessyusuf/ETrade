#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Business.DataAccess.Context;
using Business.DataAccess.Entities;
using Business.DataAccess.Services;

namespace MVC.Controllers
{
    public class ProductsController : Controller
    {
        // Add service injections here
        private readonly ProductServiceBase _productService;
        private readonly CategoryServiceBase _categoryService;
        private readonly StoreServiceBase _storeService;
		public ProductsController(ProductServiceBase productService, CategoryServiceBase categoryService, StoreServiceBase storeService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_storeService = storeService;
		}

		// GET: Products
		public IActionResult Index()
        {
            List<Product> productList = _productService.Query(p => p.Category).ToList(); // TODO: Add get list service logic here
            return View(productList);
        }

        // GET: Products/Details/5
        public IActionResult Details(int id)
        {
            Product product = _productService.Query(p => p.Category).SingleOrDefault(p => p.Id == id); // TODO: Add get item service logic here
            if (product == null)
            {
                //return NotFound(); 404 Not Found HTTP Status Code
                return View("_Error", "Product Not Found");
            }
            return View(product); // 200 OK Http Status Code
        }

        // GET: Products/Create
        
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items

            List<Category> categories = _categoryService.Query().ToList();
            //ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            Product model = new Product()
            {
                ExpirationDate = DateTime.Today.AddMonths(6)
            };
            return View(model);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                var result = _productService.Add(product);
                if (result.IsSuccessful)
                {
                    //return RedirectToAction("Index");
					return RedirectToAction(nameof(Index));
				}
                
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["CategoryId"] = new SelectList(_categoryService.Query().ToList(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int id)
        {
            Product product = _productService.Query().SingleOrDefault(p => p.Id == id); // TODO: Add get item service logic here
            if (product == null)
            {
                return View("_Error", "Product not found!");
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["CategoryId"] = new SelectList(_categoryService.Query().ToList(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {

                var result = _productService.Update(product);
                if (true)
                {
                    TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Index));
				}
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["CategoryId"] = new SelectList(_categoryService.Query().ToList(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int id)
        {
            Product product = _productService.Query().SingleOrDefault(_p => _p.Id == id);

            if (product == null)
            {
                return View("_Error", "Product not found");
            }
            return View(product);
        }

        // POST: Products/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _productService.Delete(p => p.Id == id);
            TempData["Message"] = result.Message;

            return RedirectToAction(nameof(Index));
        }
    }
}
