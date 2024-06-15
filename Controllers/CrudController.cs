using Microsoft.AspNetCore.Mvc;
using SpecCrudPro.Models;
using System.Diagnostics.Metrics;

namespace SpecCrudPro.Controllers
{
    public class CrudController : Controller
    {
        public readonly DatabaseContext _context;
        public CrudController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Register(RegisterModel obj)
        {
            if(obj != null)
            {
                if (ModelState.IsValid)
                {
                    var res = new RegisterModel
                    {
                        Name = obj.Name,
                        Age = Convert.ToInt32(obj.Age),
                        gender = obj.gender,
                        email = obj.email,
                        phoneno = obj.phoneno,
                        country = obj.country,
                        state = obj.state,
                        status = Convert.ToBoolean(obj.status),
                    };
                    _context.Add(res);
                    int x = _context.SaveChanges();
                    if (x == 0)
                    {
                        ViewBag.message = "Try Again";
                    }
                    else
                    {
                        return RedirectToAction("showAll");
                    }
                }
            }
            


          
            return View();
        }
        
        public IActionResult ShowAll()
        {
            var res = from s in _context.RegisterModel select s;
            return View(res.ToList());
        }

        public IActionResult Details(int? id)
        {
            var res = from s in _context.RegisterModel where s.id == id select s;
            return View(res.ToList());
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var data = _context.RegisterModel.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(int? id, RegisterModel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj == null)
                {
                    ViewBag.message = "Select Data";
                }
                else
                {
                    _context.Update(obj);
                    int x = _context.SaveChanges();
                    if (x == 0)
                    {
                        return RedirectToAction("Edit");                    }
                    else
                    {
                        return RedirectToAction("ShowAll");
                    }
                }
            }
            else
            {
                return RedirectToAction("Edit");
            }
            
            return View();
        }

        public IActionResult Delete(int? id)
        {
            var data = _context.RegisterModel.Find(id);
            if(data != null)
            {
                _context.Remove(data);
                int x = _context.SaveChanges();
                if(x > 0)
                {
                    return RedirectToAction("showAll");
                    TempData["dltmsgsucces"] = "One record removed";
                }
                else
                {
                    TempData["dltmsg"] = "Record not deleted";
                }
            }
            return View();
        }


    }
}
