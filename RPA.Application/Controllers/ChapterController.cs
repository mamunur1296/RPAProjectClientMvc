using Microsoft.AspNetCore.Mvc;
using RPA.Application.Interfaces;
using RPA.Models;

namespace RPA.Application.Controllers
{
    public class ChapterController : Controller
    {
        private readonly IUnitOfWorkServices _unitOfWorkServices;
        public ChapterController(IUnitOfWorkServices unitOfWorkServices)
        {
            _unitOfWorkServices = unitOfWorkServices;
        }

        // GET: /Customer/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customers = await _unitOfWorkServices.chapterServiceRepogitory.GetAllAsync("Chapter/getAllChapter");
            return View(customers);
        }
        // GET: /Customer/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        [HttpPost]
        public async Task<IActionResult> Create(Chapter customer)
        {
            bool result = await _unitOfWorkServices.chapterServiceRepogitory.AddAsync(customer, "Chapter/Create");
            return result ? RedirectToAction("Index") : RedirectToAction("Error");
        }
        // GET: /Customer/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var customer = await _unitOfWorkServices.chapterServiceRepogitory.GetByIdAsync(id, "Customer/getCustomer");
            return View(customer);
        }

        // GET: /Customer/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var customer = await _unitOfWorkServices.chapterServiceRepogitory.GetByIdAsync(id, "Chapter/getChapter");
            return View(customer);
        }

        // POST: /Customer/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Chapter customer)
        {
            await _unitOfWorkServices.chapterServiceRepogitory.UpdateAsync(id, customer, "Chapter/UpdateChapter");
            return RedirectToAction("Index");
        }

        // GET: /Customer/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _unitOfWorkServices.chapterServiceRepogitory.GetByIdAsync(id, "Chapter/getChapter");
            return View(customer);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteChapter(Guid id)
        {
            await _unitOfWorkServices.chapterServiceRepogitory.DeleteAsync(id, "Chapter/DeleteChapter");
            return RedirectToAction("Index");
        }
    }
}
