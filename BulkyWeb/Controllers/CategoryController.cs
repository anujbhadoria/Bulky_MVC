using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var objCategoryList = _unitOfWork.Category.GetAll();   
            return View(objCategoryList);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category category = _unitOfWork.Category.Get(u => u.Id == id);
            if(category is null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost] 
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //atttribute added to tell that its a post request
        public IActionResult Create(Category obj) 
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj); //it will store the info that needs to be done in database
                _unitOfWork.Save(); //now it has made the entry in db.
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category category = _unitOfWork.Category.Get(u => u.Id == id);
            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost,ActionName("Delete")] //atttribute added to tell that its a post request
        public IActionResult DeletePOST(int? id)
        {
            Category category = _unitOfWork.Category.Get(u => u.Id == id);
            if(category is null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index", "Category");
        }
    }
}
