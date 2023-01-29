using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MasudUniversity.Data;
using MasudUniversity.Models;
using MasudUniversity.Repositories.interfaces;

namespace MasudUniversity.Controllers
{
    public class EmployeesController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IEmployeeRepositories _context;
        public EmployeesController(IEmployeeRepositories context)
        {
            _context = context;
        }

        // GET: Employees
        public ActionResult Index()
        {
            return View(_context.GetAllEmployee());
        }

        // GET: Employees/Details/5
        
    }
}
