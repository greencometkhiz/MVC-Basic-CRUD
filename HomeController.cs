using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace khizt.Controllers
{
    public class HomeController : Controller
    {
        khizdbEntities _context = new khizdbEntities();
        public ActionResult Index()
        {
            var listofData = _context.Table_1.ToList();
            return View(listofData);

        }
        	[HttpGet]  
	 public ActionResult Create()
	 {  
	     return View();  
	 }  	  
	 [HttpPost]  
	 public ActionResult Create(Table_1 model)
	 {              
	     _context.Table_1.Add(model);  
	     _context.SaveChanges();  
	     ViewBag.Message = "Data Insert Successfully";  
	     return View();
        }

        	[HttpGet]  
	public ActionResult Edit(int id)
	{               
	    var data = _context.Table_1.Where(x => x.EmployeeID == id).FirstOrDefault();  
	    return View(data);  
	}  
	[HttpPost]  
	public ActionResult Edit(Table_1 Model)
	{  
	    var data = _context.Table_1.Where(x => x.EmployeeID == Model.EmployeeID).FirstOrDefault();  
	    if (data != null)  
	    {  
	        data.EmployeeCity = Model.EmployeeCity;  
	        data.EmployeeName = Model.EmployeeName;  
	        data.EmployeeSalary = Model.EmployeeSalary;  
	        _context.SaveChanges();  
	    }

     return RedirectToAction("index");
        }  
			public ActionResult Details(int id)
	{  
	    var data = _context.Table_1.Where(x => x.EmployeeID == id).FirstOrDefault();  
	    return View(data);
        }
	public ActionResult Delete(int id)
	{  
	    var data = _context.Table_1.Where(x => x.EmployeeID == id).FirstOrDefault();  
	    _context.Table_1.Remove(data);  
	    _context.SaveChanges();  
	    ViewBag.Messsage = "Record Delete Successfully";  
	    return RedirectToAction("index");  
	}


    public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}