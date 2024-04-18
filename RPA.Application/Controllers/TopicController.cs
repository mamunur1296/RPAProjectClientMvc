using Microsoft.AspNetCore.Mvc;
using RPA.Application.Interfaces;
using RPA.Models;
using RPA.Models.ViewModel;

namespace RPA.Application.Controllers
{
    public class TopicController : Controller
    {
        private readonly IUnitOfWorkServices _unitOfWorkServices;
        public TopicController(IUnitOfWorkServices unitOfWorkServices)
        {
            _unitOfWorkServices = unitOfWorkServices;
        }

        // GET: /Customer/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var topics = await _unitOfWorkServices.topicServiceRepogitory.GetAllAsync("Topic/getAllTopic");
            return View(topics);
        }
        // GET: /Customer/Create
        [HttpGet]
        public async Task<IActionResult>  Create()
        {
            var chapter = await _unitOfWorkServices.chapterServiceRepogitory.GetAllAsync("Chapter/getAllChapter");
            var topicCreateviewModel = new TopicCreateViewModel();
            topicCreateviewModel.Chapter = chapter;
            return View(topicCreateviewModel);
        }

        // POST: /Customer/Create
        [HttpPost]
        public async Task<IActionResult> Create(TopicCreateViewModel model)
        {
            bool result = await _unitOfWorkServices.topicServiceRepogitory.AddAsync(model.Topic, "Topic/Create");
            return result ? RedirectToAction("Index") : RedirectToAction("Error");
        }
        // GET: /Customer/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var customer = await _unitOfWorkServices.topicServiceRepogitory.GetByIdAsync(id, "Topic/getTopic");
            return View(customer);
        }

        // GET: /Customer/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var chapter = await _unitOfWorkServices.chapterServiceRepogitory.GetAllAsync("Chapter/getAllChapter");
            var topic = await _unitOfWorkServices.topicServiceRepogitory.GetByIdAsync(id, "Topic/getTopic");
            var topicCreateviewModel = new TopicCreateViewModel();
            topicCreateviewModel.Chapter = chapter;
            topicCreateviewModel.Topic = topic;
            return View(topicCreateviewModel);
        }

        // POST: /Customer/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, TopicCreateViewModel model)
        {
            try
            {
                
                // Proceed with the update operation.
                await _unitOfWorkServices.topicServiceRepogitory.UpdateAsync(id, model.Topic, "Topic/UpdateTopic");

                // Redirect to index after successful update.
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes.
                // You can also return a specific error message if needed.
                string errorMessage = $"Failed to update resource: {ex.Message}";

                // Throw a new HttpRequestException with the custom error message.
                throw new HttpRequestException(errorMessage);
            }
        }


        // GET: /Customer/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _unitOfWorkServices.topicServiceRepogitory.GetByIdAsync(id, "Topic/getTopic");
            return View(customer);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteChapter(Guid id)
        {
            await _unitOfWorkServices.topicServiceRepogitory.DeleteAsync(id, "Topic/DeleteTopic");
            return RedirectToAction("Index");
        }
    }
}
