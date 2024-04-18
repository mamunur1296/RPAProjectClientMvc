using Microsoft.AspNetCore.Mvc;
using RPA.Application.Interfaces;
using RPA.Models;
using RPA.Models.ViewModel;

namespace RPA.Application.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IUnitOfWorkServices _unitOfWorkServices;
        public QuestionsController(IUnitOfWorkServices unitOfWorkServices)
        {
            _unitOfWorkServices = unitOfWorkServices;
        }

        // GET: /Customer/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _unitOfWorkServices.questionsServiceRepogitory.GetAllAsync("Questions/getAllQuestions");
            return View(datas);
        }
        // GET: /Customer/Create
        [HttpGet]
        public async Task<IActionResult>  Create()
        {
            var topics = await _unitOfWorkServices.topicServiceRepogitory.GetAllAsync("Topic/getAllTopic");
            var questionsCreateViewModel = new QuestionsCreateViewModel();
            questionsCreateViewModel.TopicList = topics;
            return View(questionsCreateViewModel);
        }

        // POST: /Customer/Create
        [HttpPost]
        public async Task<IActionResult> Create(QuestionsCreateViewModel model)
        {
            bool result = await _unitOfWorkServices.questionsServiceRepogitory.AddAsync(model.Questions, "Questions/Create");
            return result ? RedirectToAction("Index") : RedirectToAction("Error");
        }
        // GET: /Customer/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var customer = await _unitOfWorkServices.questionsServiceRepogitory.GetByIdAsync(id, "Questions/getQuestions");
            return View(customer);
        }

        // GET: /Customer/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var quessain = await _unitOfWorkServices.questionsServiceRepogitory.GetByIdAsync(id, "Questions/getQuestions");
            var topicList = await _unitOfWorkServices.topicServiceRepogitory.GetAllAsync("Topic/getAllTopic");
            var queviewMode = new QuestionsCreateViewModel();
            queviewMode.TopicList = topicList;
            queviewMode.Questions = quessain;

            return View(queviewMode);
        }

        // POST: /Customer/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id,QuestionsCreateViewModel model)
        {
            await _unitOfWorkServices.questionsServiceRepogitory.UpdateAsync(id, model.Questions , "Questions/UpdateQuestions");
            return RedirectToAction("Index");
        }

        // GET: /Customer/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _unitOfWorkServices.questionsServiceRepogitory.GetByIdAsync(id, "Questions/getQuestions");
            return View(customer);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteChapter(Guid id)
        {
            await _unitOfWorkServices.questionsServiceRepogitory.DeleteAsync(id, "Questions/DeleteQuestions");
            return RedirectToAction("Index");
        }
    }
}
