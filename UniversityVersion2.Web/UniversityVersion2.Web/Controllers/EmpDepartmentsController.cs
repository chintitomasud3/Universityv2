using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityVersion2.Web.Data;
using UniversityVersion2.Web.Models;

namespace UniversityVersion2.Web.Controllers
{
    public class EmpDepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpDepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmpDepartments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departments.ToListAsync());
        }

        // GET: EmpDepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empDepartment = await _context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empDepartment == null)
            {
                return NotFound();
            }

            return View(empDepartment);
        }

        // GET: EmpDepartments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Budget")] EmpDepartment empDepartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empDepartment);
        }

        // GET: EmpDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empDepartment = await _context.Departments.FindAsync(id);
            if (empDepartment == null)
            {
                return NotFound();
            }
            return View(empDepartment);
        }

        // POST: EmpDepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Budget")] EmpDepartment empDepartment)
        {
            if (id != empDepartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpDepartmentExists(empDepartment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(empDepartment);
        }

        // GET: EmpDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empDepartment = await _context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empDepartment == null)
            {
                return NotFound();
            }

            return View(empDepartment);
        }

        // POST: EmpDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empDepartment = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(empDepartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpDepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
