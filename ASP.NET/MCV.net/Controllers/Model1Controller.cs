using MCV.net.Data;
using MCV.net.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCV.net.Controllers
{
    public class Model1Controller : Controller
    {
        private readonly ApplicationDbContext _db;
        public Model1Controller(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            //  IEnumerator<Model1> obj =  _db.ModleTable;
            var obj = _db.ModleTable.ToList();
            return View(obj);
        }

        //For Creating new Model
        [Authorize]
        public IActionResult Creat()
        {

            //  IEnumerator<Model1> obj =  _db.ModleTable;
            return View();
        }
        // Submit the Created Model 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creat(Model1 obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                //This will appear in the Summery div validation
                // ModelState.AddModelError("CustomerError", "Name Cannot Match the Dispaly Order");
                //This will appear in both under the Name Field and div of summery validation
                ModelState.AddModelError("name", "Name Cannot Match the Dispaly Order");
 
            }
            if (ModelState.IsValid)
            {


                //Add this record to the table in c#
                _db.ModleTable.Add(obj);
                // Add this record to the table in sql server database
                _db.SaveChanges();
                TempData["sucess"] = "Model created successfully";

                //return me to the Index view using index action method
                return RedirectToAction("Index");
            }
            TempData["error"] = "Fail to creat the Model";

            return View(obj);
        }
        //GET
        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {

                return NotFound();
            }

            var record = _db.ModleTable.Find(id);
            if (record == null) return NotFound();

            return View(record);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Model1 obj)
        {
            //Server side validation(done inside the controller )
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                //This will appear in the Summery div validation
                // ModelState.AddModelError("CustomerError", "Name Cannot Match the Dispaly Order");
                //This will appear in both under the Name Field and div of summery validation
                ModelState.AddModelError("name", "Name Cannot Match the Dispaly Order");

            }
            // all the submitted values is valid 
            if (ModelState.IsValid)
            {
                _db.ModleTable.Update(obj);
                _db.SaveChanges();
                TempData["sucess"] = "Model Edited successfully";

                return RedirectToAction("Index");
            }
            TempData["error"] = "Fail to edit the Model";

            return View(obj);


        }

        //GET
        [Authorize(Roles="Admin,SuperAdmin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {

                return NotFound();
            }

            var record = _db.ModleTable.Find(id);
            if (record == null) return NotFound();

            return View(record);
        }
        //POST
        
        [HttpPost ,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // you can recive Model1 obj or just the id 
        public IActionResult DeletePOST(int? id )
        {
            var obj = _db.ModleTable.Find(id);
            if (obj == null)
            {
                TempData["error"] = "Fail to delete the Model";
                return NotFound();
            }
            _db.ModleTable.Remove(obj);
            _db.SaveChanges();
            TempData["sucess"] = "Model deleted successfully";
            return RedirectToAction("Index");
              
        }
    }
}