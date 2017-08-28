using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZooFeeding.DAL;
using ZooFeeding.Models;

namespace ZooFeeding.Controllers
{
    public class AnimalsController : Controller
    {
        private IAnimalRepository animalRepository;

        public AnimalsController()
        {
            this.animalRepository = new AnimalRepository(new DAL.ZooContext());
        }

        // GET: Animals
        public ViewResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.Food1SortParm = sortOrder == "Food1" ? "1" : "1";
            ViewBag.Food2SortParm = sortOrder == "Food2" ? "2" : "2";
            ViewBag.Food3SortParm = sortOrder == "Food3" ? "3" : "3";
            ViewBag.Food4SortParm = sortOrder == "Food4" ? "4" : "4";
            ViewBag.Food5SortParm = sortOrder == "Food5" ? "5" : "5";
            ViewBag.Food6SortParm = sortOrder == "Food6" ? "6" : "6";
            ViewBag.Food7SortParm = sortOrder == "Food7" ? "7" : "7";
            ViewBag.Food8SortParm = sortOrder == "Food8" ? "8" : "8";
            ViewBag.Food9SortParm = sortOrder == "Food9" ? "9" : "9";
            ViewBag.Food10SortParm = sortOrder == "Food10" ? "10" : "10";
            var animals = from a in animalRepository.GetAnimals()
                         select a;
            switch (sortOrder)
            {
                case "name_desc":
                    animals = animals.OrderByDescending(a => a.AnimalName);
                    break;
                case "1":
                    animals = animals.Where(a => a.DryCatFood);
                    break;
                case "2":
                    animals = animals.Where(a => a.Fish);
                    break;
                case "3":
                    animals = animals.Where(a => a.Fruit);
                    break;
                case "4":
                    animals = animals.Where(a => a.Hay);
                    break;
                case "5":
                    animals = animals.Where(a => a.Insects);
                    break;
                case "6":
                    animals = animals.Where(a => a.Meat);
                    break;
                case "7":
                    animals = animals.Where(a => a.MonkeyChow);
                    break;
                case "8":
                    animals = animals.Where(a => a.Plants);
                    break;
                case "9":
                    animals = animals.Where(a => a.Rodents);
                    break;
                case "10":
                    animals = animals.Where(a => a.Vegetables);
                    break;
                default:
                    animals = animals.OrderBy(a => a.AnimalName);
                    break;
            }
            return View(animals.ToList());
        }

        // GET: Animals/Details/5
        public ViewResult Details(int id)
        {
            Animal animal = animalRepository.GetAnimalByID(id);
            return View(animal);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalId,AnimalName,DryCatFood,Fish,Fruit,Hay,Insects,Meat,MonkeyChow,Plants,Rodents,Vegetables")] Animal animal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    animalRepository.InsertAnimal(animal);
                    animalRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(animal);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int id)
        {
            Animal animal = animalRepository.GetAnimalByID(id);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalId,AnimalName,DryCatFood,Fish,Fruit,Hay,Insects,Meat,MonkeyChow,Plants,Rodents,Vegetables")] Animal animal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    animalRepository.UpdateAnimal(animal);
                    animalRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again , and if the problem persists contact your system administrator.");
            }
            return View(animal);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete faild. Try again, and if the problem persists see your system administrator.";
            }
            Animal animal = animalRepository.GetAnimalByID(id);
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Animal animal = animalRepository.GetAnimalByID(id);
                animalRepository.DeleteAnimal(id);
                animalRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            animalRepository.Dispose();
            base.Dispose(disposing);
        }

        //Get: Animals/ViewFoods
        public ActionResult ViewFoods()
        {
            return View();
        }

        //Get: Animals/EditFoods
        public ActionResult EditFoods()
        {
            return View();
        }
    }
}
