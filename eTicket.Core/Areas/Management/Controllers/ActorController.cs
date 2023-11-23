using eTicket.DataAccess.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Education.Classes.Item.Assignments.Item.Submissions.Item.Return;

namespace eTicket.Core.Areas.Management.Controllers
{
    [Area("Management")]
    public class ActorController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ActorController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var actors = unitOfWork.Actor.GetAll();
            return View(actors);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var ActorDbObj = unitOfWork.Actor.GetById(id);
            if (ActorDbObj is null) return View(nameof(NotFound));
            var model = unitOfWork.Actor.GetActorMovies(ActorDbObj);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Actor model)
        {
            if(ModelState.IsValid)
            {
                unitOfWork.Actor.Add(model);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Obj = unitOfWork.Actor.GetById(id);
            if (Obj is null) return View(nameof(NotFound));
            return View(Obj);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Obj = unitOfWork.Actor.GetById(id);
            if (Obj is null) return View(nameof(NotFound));
            unitOfWork.Actor.RemoveEntity(Obj);
            await unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Obj = unitOfWork.Actor.GetById(id);
            if (Obj is null) return View(nameof(NotFound));
            return View(Obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Actor model)
        {
            
            if (ModelState.IsValid)
            {
                await unitOfWork.Actor.UpdateAsync(id, model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
