using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dbcourses.Include(c => c.group);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dbcourses == null)
            {
                return NotFound();
            }

            var course = await _context.Dbcourses
                .Include(c => c.group)
                .FirstOrDefaultAsync(m => m.IdCourses == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["IdGroups"] = new SelectList(_context.Dbgroups, "IdGroups", "GroupDescription");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCourses,CourseName,CourseDescription,IdGroups")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGroups"] = new SelectList(_context.Dbgroups, "IdGroups", "GroupDescription", course.IdGroups);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dbcourses == null)
            {
                return NotFound();
            }

            var course = await _context.Dbcourses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["IdGroups"] = new SelectList(_context.Dbgroups, "IdGroups", "GroupDescription", course.IdGroups);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCourses,CourseName,CourseDescription,IdGroups")] Course course)
        {
            if (id != course.IdCourses)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.IdCourses))
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
            ViewData["IdGroups"] = new SelectList(_context.Dbgroups, "IdGroups", "GroupDescription", course.IdGroups);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dbcourses == null)
            {
                return NotFound();
            }

            var course = await _context.Dbcourses
                .Include(c => c.group)
                .FirstOrDefaultAsync(m => m.IdCourses == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dbcourses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Dbcourses'  is null.");
            }
            var course = await _context.Dbcourses.FindAsync(id);
            if (course != null)
            {
                _context.Dbcourses.Remove(course);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
          return (_context.Dbcourses?.Any(e => e.IdCourses == id)).GetValueOrDefault();
        }
    }
}
