using eTicket.DataAccess.Services.IRepositories;
using eTicket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
//using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace eTicket.Core.Areas.Management.Controllers
{
    [Area("Management")]
    public class MovieController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public MovieController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var a = HttpContext.Session.GetString("CartId");
            ViewBag.CartId = a;
            var movies = unitOfWork.Movie.GetAll(IncludeProperties: ("Cinema"));
            return View(movies);
        }

        public IActionResult Filter(string searchString)
        {
            var movies = unitOfWork.Movie.GetAll(IncludeProperties: ("Cinema"));
            if(!String.IsNullOrEmpty(searchString))
            {
                var filteredResult = movies.Where(m => m.Title.Contains(searchString) || m.Description.Contains(searchString)).ToList();
                return View(nameof(Index), filteredResult);
            }
            return View(nameof(Index), movies);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var MovieDbObj = unitOfWork.Movie.GetMovieDetails(id);
            return View(MovieDbObj);
        }

        public IActionResult Create()
        {
            var model = new CreateMovieVM()
            {
                /// Populating the Select Lists
                CinemaList = unitOfWork.Cinema.GetAll().Select(a => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                }),
                ProducerList = unitOfWork.Producer.GetAll().Select(a => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                }),
                Actors = unitOfWork.Actor.GetAll().Select(a => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = a.Name, Value = a.Id.ToString() }),
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMovieVM model)
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie()
                {
                    Title = model.Title,
                    Description = model.Description,
                    ImageURL = model.ImageURL,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    ProducerID = model.ProducerID,
                    CinemaID = model.CinemaID,
                    MovieActors = model.ActorId.Select(a => new MovieActor { ActorID = a}).ToList(),
                };
                unitOfWork.Movie.Add(movie);
                unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var obj = new CreateMovieVM()
                {
                    /// Populating the Select Lists
                    CinemaList = unitOfWork.Cinema.GetAll().Select(a => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                    {
                        Text = a.Name,
                        Value = a.Id.ToString(),
                    }),
                    ProducerList = unitOfWork.Producer.GetAll().Select(a => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                    {
                        Text = a.Name,
                        Value = a.Id.ToString(),
                    }),
                    Actors = unitOfWork.Actor.GetAll().Select(a => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = a.Name, Value = a.Id.ToString() }),
                };
                return View(obj);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Obj = unitOfWork.Movie.GetById(id);
            if (Obj is null) return View(nameof(NotFound));
            return View(Obj);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Obj = unitOfWork.Movie.GetById(id);
            if (Obj is null) return View(nameof(NotFound));
            unitOfWork.Movie.RemoveEntity(Obj);
            await unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Obj = unitOfWork.Movie.GetMovieById(id);
            if (Obj is null) return View(nameof(NotFound));
            var model = new CreateMovieVM()
            {
                Title = Obj.Title,
                Description = Obj.Description,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Genre = Obj.Genre,
                ImageURL = Obj.ImageURL,
                ProducerID = Obj.ProducerID,
                CinemaID = Obj.CinemaID,
                ActorId = Obj.MovieActors.Select(x => x.ActorID).ToList(),
                Price = Obj.Price,
                /// Populating the Select Lists
                CinemaList = unitOfWork.Cinema.GetAll().Select(a => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                }),
                ProducerList = unitOfWork.Producer.GetAll().Select(a => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                }),
                Actors = unitOfWork.Actor.GetAll().Select(a => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = a.Name, Value = a.Id.ToString() }),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateMovieVM model)
        {
            var Obj = unitOfWork.Movie.GetMovieById(id);
            if(Obj == null) return View(nameof(NotFound));
            if (ModelState.IsValid)
            {
                await unitOfWork.Movie.UpdateAsync(id, model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
