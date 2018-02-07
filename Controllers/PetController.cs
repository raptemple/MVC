using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;
using MVC.Repository;

namespace MVC.Controllers{

    public class PetController : Controller
    {
        private PetRepository _petRepository;
        private ApplicationDbContext _context;

        public PetController(ApplicationDbContext context)
        {
            _context = context;
            _petRepository = new PetRepository(_context);
        }

    public IActionResult Index(){
        var pets = _petRepository.GetAllPets();
        return View(pets);
    }

    public IActionResult Details(int id){
        var pet = _petRepository.GetSinglePet(id);
        return View(pet);
    }

    [HttpGet]
    public IActionResult New(){
        ViewBag.IsEditMode = "false";
        var pet = new Pet();
        return View(pet);
    }

    [HttpPost]

    public IActionResult New(Pet pet, string IsEditMode){
        if(IsEditMode.Equals("false"))
            _petRepository.Create(pet);
        else
            _petRepository.Edit(pet);       
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]

    public IActionResult Edit(int Id){
        ViewBag.IsEditMode = "true";
        var pet = _petRepository.GetSinglePet(Id);
        return View("New",pet);
    }

    public IActionResult Delete(int Id){
        var pet = _petRepository.GetSinglePet(Id);
        _petRepository.Delete(pet);
        return RedirectToAction(nameof(Index));
    }
    }

}