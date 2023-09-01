#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Business.DataAccess.Entities;
using Business.DataAccess.Services;

namespace MVC.Controllers
{
    public class CategoriesController : Controller
    {
        // Add service injections here
        private readonly CategoryServiceBase _categoryService;

        public CategoriesController(CategoryServiceBase categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Categories
        public IActionResult Index(string message = null)
        {
            List<Category> categoryList = _categoryService.GetList();
            if (!string.IsNullOrWhiteSpace(message))
                ViewBag.Message = message;
            else
                ViewBag.Message = categoryList.Count == 0 ? "No categories found." : categoryList.Count == 1 ? "1 catregory found." : categoryList.Count + " categories found.";
            return View(categoryList);
        }

        // GET: Categories/Details/5
        public IActionResult Details(int id)
        {
            //Category category = _categoryService.Query().SingleOrDefault(c => c.Id == id);
            Category category = _categoryService.GetItem(id);
            if (category == null)
            {
                return View("_Error", "Category not found!");
            }
            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items

            return View(new Category());
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryService.Add(category);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(category);
        }

        // GET: Categories/Edit/5
        public IActionResult Edit(int id)
        {
            Category category = _categoryService.GetItem(id);
            if (category == null)
            {
                return View("_Error", "Category not found!");
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(category);
        }

        // POST: Categories/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryService.Update(category);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(category);
        }

        // GET: Categories/Delete/5
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(c => c.Id == id);
            return RedirectToAction(nameof(Index), new { message = result.Message });
        }


    }
}
