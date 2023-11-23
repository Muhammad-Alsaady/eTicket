using eTicket.DataAccess.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Education.Classes.Item.Assignments.Item.Submissions.Item.Return;

namespace eTicket.Core.Areas.Management.Controllers
{
    [Area("Management")]
    public class CinemaController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CinemaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var cinemas = unitOfWork.Cinema.GetAll();
            return View(cinemas);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var cinemaDbObj = unitOfWork.Cinema.GetById(id);
            if (cinemaDbObj is null) return View(nameof(NotFound));
            return View(cinemaDbObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cinema model)
        {
            if(ModelState.IsValid)
            {
                unitOfWork.Cinema.Add(model);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Obj = unitOfWork.Cinema.GetById(id);
            if (Obj is null) return View(nameof(NotFound));
            return View(Obj);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Obj = unitOfWork.Cinema.GetById(id);
            if (Obj is null) return View(nameof(NotFound));
            unitOfWork.Cinema.RemoveEntity(Obj);
            await unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Obj = unitOfWork.Cinema.GetById(id);
            if (Obj is null) return View(nameof(NotFound));
            return View(Obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cinema model)
        {
            
            if (ModelState.IsValid)
            {
                await unitOfWork.Cinema.UpdateAsync(id, model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
