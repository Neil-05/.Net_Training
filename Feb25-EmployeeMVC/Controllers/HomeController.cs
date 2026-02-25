using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Feb25_EmployeeMVC.Models;

namespace Feb25_EmployeeMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.MyVariable="India,Italy,France,Spain";
        ViewBag.sgsg=true;
        ViewBag.NumberofLines=5;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
