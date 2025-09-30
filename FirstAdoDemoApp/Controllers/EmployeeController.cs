using FirstAdoDemoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAdoDemoApp.Controllers;

public class EmployeeController : Controller
{
    private readonly EmployeeDataAccessLayerWithSp _dataAccessLayer;

    public EmployeeController()
    {
        _dataAccessLayer = new EmployeeDataAccessLayerWithSp();
    }

    public IActionResult Index()
    {
        var employees = _dataAccessLayer.GetEmployees();

        return View(employees);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            _dataAccessLayer.AddEmployee(employee);
            return RedirectToAction("Index");
        }
        else
        {
            return View(employee);
        }
    }

    public IActionResult Details(int id)
    {
        var emloyee = _dataAccessLayer.GetEmployee(id);
        return View(emloyee);
    }

    public IActionResult Edit(int id)
    {
        var emloyee = _dataAccessLayer.GetEmployee(id);
        return View(emloyee);
    }

    [HttpPost]
    public IActionResult Edit(Employee employee)
    {
        if (ModelState.IsValid)
        {
            _dataAccessLayer.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }
        else
        {
            return View(employee);
        }
    }

    public IActionResult Delete(int id)
    {
        var emloyee = _dataAccessLayer.GetEmployee(id);
        return View(emloyee);
    }

    public IActionResult DeleteData(int id)
    {
        _dataAccessLayer.DeleteEmployee(id); 
        return RedirectToAction("Index");
    }
}
