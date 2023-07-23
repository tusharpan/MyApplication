using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApplication.Models;
namespace MyApplication.Controllers
{
    public class EmployeesController1 : Controller
    {
        // GET: EmployeesController1
        public ActionResult Index()
        { 
            List<Employee> employees = new List<Employee>();
            // employees.Add(new Employee() { Name="Tushar" , Basic=2000, Id=2});
            employees = Employee.GetEmployee();
            return View(employees);
        }

        // GET: EmployeesController1/Details/5
        public ActionResult Details(int id)
        {

            Employee obj = Employee.GetEmployeeById(id);

            return View(obj);
        }

        // GET: EmployeesController1/Create
        public ActionResult Create()
        {
          

            return View();
        }

        // POST: EmployeesController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee obj,IFormCollection collection)
        {
            Console.WriteLine("hello");
            try
            {

                Employee.Insert(obj);
                

               return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController1/Edit/5
        public ActionResult Edit(int id)
        {
            Employee obj = Employee.GetEmployeeById(id);
            return View(obj);
        }

        // POST: EmployeesController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection,Employee obj)
        {
            try
            {
                List<Employee> list = Employee.UpdateEmp(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                List<Employee> employees = Employee.DeleteEmp(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
