using AirlineManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirlineManagementSystem.Controllers
{
    public class AirlineController : Controller
    {
        private AirlineManagementContext _AirlineManagementContext;
        private string ErrorMessage = string.Empty;

        public AirlineController(AirlineManagementContext context)
        {

            _AirlineManagementContext = context;
        }

        
        public IActionResult Delete(int id)
        {
            try
            {
                Airline obj = _AirlineManagementContext.Airline.Find(id);
                _AirlineManagementContext.Airline.Remove(obj);
                _AirlineManagementContext.SaveChanges();
                ErrorMessage = "Successfully Record Deleted";
                return RedirectToAction("Index", "Airline",new { Message = ErrorMessage });
            }
            catch(Exception e)
            {
                ErrorMessage = e.Message.ToString();
                return RedirectToAction("Index", "Airline", new { Message = ErrorMessage });
            }
        }

        public IActionResult Edit(Airline airline)
        {
            //_AirlineManagementContext.Airline.Find(id)
            return View(airline);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRecord(Airline airline)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _AirlineManagementContext.Airline.Update(airline);
                    _AirlineManagementContext.SaveChanges();
                    ErrorMessage = "Successfully Record Edited";
                    return RedirectToAction("Index", "Airline", new { Message = ErrorMessage });
                }
                return View(airline);
            }
            catch(Exception e)
            {
                ErrorMessage = e.Message.ToString();
                return RedirectToAction("Index", "Airline", new { Message = ErrorMessage });
            }
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Airline airline)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _AirlineManagementContext.Airline.Add(airline);
                    _AirlineManagementContext.SaveChanges();
                    ErrorMessage = "Successfully Record Saved";
                    return RedirectToAction("Index","Airline", new { Message = ErrorMessage });
                }
                else
                {
                    ErrorMessage = "Something went wrong try again";
                    return RedirectToAction("Index", "Airline", new { Message = ErrorMessage });
                }
            }
            catch(Exception e)
            {
                ErrorMessage = e.Message.ToString();
                return RedirectToAction("Index", "Airline", ErrorMessage);
            }
        }




        // GET: /<controller>/
        public IActionResult Index(string Message)
        {
            try
            {
                if (Message != null)
                {
                    TempData["MessageInfo"]= Message.ToString();
                    return View(_AirlineManagementContext.Airline.ToList());
                }
                else
                {
                    TempData["MessageInfo"] = "";
                    return View(_AirlineManagementContext.Airline.ToList());
                }
            }
            catch(Exception e)
            {
                TempData["MessageInfo"] = e.Message.ToString();
                return View(_AirlineManagementContext.Airline.ToList());
            }
        }
    }
}
