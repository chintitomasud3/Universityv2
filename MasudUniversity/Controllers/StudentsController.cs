using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MasudUniversity.Data;
using MasudUniversity.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace MasudUniversity.Controllers
{
  
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index(string searchString,int page=1)
        {


            //var students = from s in _context.Students
            //               select s;

            var students = _context.Students.OrderBy(s => s.StudentId).Skip((page - 1) * 5).Take(5);
            int totalPages = (int)Math.Ceiling((double)_context.Students.Count() / 5);
            ViewBag.Total = totalPages;
            ViewBag.currentPage = page;
            if (!String.IsNullOrEmpty(searchString))
            {
                //students = students.Where(s => s.StudentName.Contains(searchString)
                //                       || s.Email.Contains(searchString)||s.PhoneNumber.Contains(searchString));
              var  studentss = _context.Students.Where(s => s.StudentName.Contains(searchString)
                                           || s.Email.Contains(searchString) || s.PhoneNumber.Contains(searchString));

                return View(await studentss.ToListAsync());

            }
            


            return View(await students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                
                //return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                Response.StatusCode = 404;
                return View("StudentNotFound", id);
                // return NotFound();
            }

            return View(student);
        }
        public async Task<IActionResult> Detailsudpated(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var student = await _context.Students
            //    .FirstOrDefaultAsync(m => m.StudentId == id);

            var student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,Gender,Nationality,Religion,MartialStatus,Email,PhoneNumber,BloodGroup,DOB,Batch")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,Email,PhoneNumber,BloodGroup")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }

        public ActionResult JqueryDatatable() {
            IEnumerable <Student> StudentList= _context.Students.ToList();
            return View(StudentList);
        }

        public ActionResult Practice(int id)
        {
            
            Student studentsearch=_context.Students.Single(m=>m.StudentId==id);

          return  View(studentsearch);


        }


        public ActionResult StudentAddressCheck() {

            var contextresult = _context.Students.Include(s=>s.StudentAddresses).ToList();

            ViewBag.studentonly = _context.Students.ToList();
            return View(contextresult);
        }

        public ActionResult Jquerypractice() {


            return View(_context.Students.ToList());
        
        }

        public string JqueryString() {

            return "bolod masud";
        }
        public  JsonResult StudentList() {

            var json = JsonConvert.SerializeObject(_context.Students.ToList());
            return Json(_context.Students.ToList());
        }
        
    }

   
}
