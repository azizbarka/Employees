using Employees.Models;
using Employees.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiRepository repository;
        public HomeController(ApiRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ViewResult> Index()
        {
            ViewBag.SelectedPage = 1;
            await repository.GetAllEmployees();
            return View();
        }

        [Route("add-emp")]
        public ViewResult AddEmployee(bool isSuccess)
        {
            ViewBag.SelectedPage = 2;
            ViewBag.IsSuccess = isSuccess;
            return View();
        }

        [HttpPost("add-emp")]   
        public async Task<IActionResult> AddEmployee(Employee emp)
        {   
          if(ModelState.IsValid)
            {
                var result = await repository.AddEmployee(emp);
                return RedirectToAction(nameof(AddEmployee), new {isSuccess = result == System.Net.HttpStatusCode.OK});
            }  
            ModelState.AddModelError("", "تأكد من القيم المدخلة");
            return View();
        }

        [Route("edit-emp")]
        public async Task<IActionResult> EditEmployee(int id , bool isSuccess)
        {
                ViewBag.IsSuccess = isSuccess;
                var emp = await repository.GetEmployee(id);
                return View(emp);
       
        }


        [HttpPost("edit-emp")]
        public async Task<IActionResult> EditEmployee(Employee emp)
        {

            if (ModelState.IsValid)
            {
                var result = await repository.UpdateEmployee(emp);
                return RedirectToAction(nameof(EditEmployee), new { id = emp.Id, isSuccess = result == System.Net.HttpStatusCode.OK });
            }
            ModelState.AddModelError("", "تأكد من القيم المدخلة");
            return View();
        }

        [Route("delete-emp")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await repository.DeleteEmployee(id);
            ViewBag.SelectedPage = 4;
            return View("Index");
        }
        [Route("show-emp")]
        public async Task<IActionResult> ShowEmployee(int id)
        {
            var emp = await repository.GetEmployee(id);
            if(emp is null)
            {
                RedirectToAction("Index");
            }
            return View(emp);
        }

    }
}
