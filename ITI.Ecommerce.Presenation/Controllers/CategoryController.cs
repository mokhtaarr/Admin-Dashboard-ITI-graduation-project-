using DTOs;
using ITI.Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ITI.Ecommerce.Presenation.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryServie _categoryServie;

        public CategoryController(ICategoryServie categoryServie)
        {
            _categoryServie = categoryServie;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            await _categoryServie.add(categoryDto);
            return RedirectToAction("GetAllCategories");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryServie.GetAll();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoryByID()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetCategoryByID(int ID)
        {
            var category = await _categoryServie.GetById(ID);
            ViewBag.Done=true;
            return View(category);
        }
        //public IActionResult ConfirmDelete(int ID)
        //{
        //    var category = _categoryServie.Categories.SingleOrDefault(o => o.ID == id);
        //    _categoryServie.Delete(category); ;
        //    return RedirectToAction("GetAllCategories");
        //}
        //public IActionResult Delete(int id)
        //{
        //    _categoryServie.Delete();
        //    return RedirectToAction("GetAllCategories");
        //}
        public IActionResult Delete(CategoryDto categoryDto)
        {
            _categoryServie.Delete(categoryDto);
            return RedirectToAction("GetAllCategories");
        }
        //[HttpGet]
        //public IActionResult CDelete(int id)
        //{
        //    var ca =_categoryServie.GetById(id);
        //    return View(ca);
        //}
        public IActionResult CDelete(int id)
        {
            _categoryServie.CDelete(id);
            //_categoryServie.Delete(ca);
            return RedirectToAction("GetAllCategories");
        }
        [HttpGet]
        public async Task<IActionResult> UpDate(int id)
        {
            var category = await _categoryServie.GetById(id);
            return View(category);
        }
        //[HttpPost]
        //public async Task<IActionResult> UpDate(CategoryDto categoryDto)
        //{
        //    //categoryDto.ID = id;
        //    await _categoryServie.Update(categoryDto);
        //    return RedirectToAction("GetAllCategories");
        //}
        [HttpPost]
        public IActionResult CUpDate(CategoryDto categoryDto)
        {
            //categoryDto.ID = id;
            _categoryServie.Update(categoryDto);
            return RedirectToAction("GetAllCategories");
        }

        //[HttpGet]
        //public IActionResult CUpDate(int id)
        //{
        //    var category =  _categoryServie.CUpdate(id);
        //    return View(category);
        //}
        //[HttpPost]
        //public async Task<IActionResult> UpDate(CategoryDto categoryDto)
        //{
        //    //categoryDto.ID = id;
        //    await _categoryServie.Update(categoryDto);
        //    return RedirectToAction("GetAllCategories");
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllDeletedCategories()
        {
            var categories = await _categoryServie.GetAllDeleted();
            return View(categories);
        }

        public IActionResult Restore(int id)
        {
            _categoryServie.Restore(id);
            return RedirectToAction("GetAllCategories");
        }
    }
}
