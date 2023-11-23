using eTicket.DataAccess.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Education.Classes.Item.Assignments.Item.Submissions.Item.Return;

namespace eTicket.Core.Areas.Management.Controllers
{
    [Area("Management")]
    public class ProducerController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProducerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var producers = unitOfWork.Producer.GetAll();
            return View(producers);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var ProucerDbObj = unitOfWork.Producer.GetById(id);
            if (ProucerDbObj is null) return View(nameof(NotFound));
            var model = unitOfWork.Producer.GetActorMovies(ProucerDbObj);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producer model)
        {
            if(ModelState.IsValid)
            {
                unitOfWork.Producer.Add(model);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Obj = unitOfWork.Producer.GetById(id);
            if (Obj is null) return View(nameof(NotFound));
            return View(Obj);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Obj = unitOfWork.Producer.GetById(id);
            if (Obj is null) return View(nameof(NotFound));
            unitOfWork.Producer.RemoveEntity(Obj);
            await unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Obj = unitOfWork.Producer.GetById(id);
            if (Obj is null) return View(nameof(NotFound));
            return View(Obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producer model)
        {
            
            if (ModelState.IsValid)
            {
                await unitOfWork.Producer.UpdateAsync(id, model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
