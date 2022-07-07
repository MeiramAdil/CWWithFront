using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CWWithFront.Data;
using CWWithFront.Models;
using CWWithFront.ViewModels;

namespace CWWithFront.Controllers
{
  public class InstructorsController : Controller
  {
    private readonly MyContext _context;

    public InstructorsController(MyContext context)
    {
      _context = context;
    }

    // GET: Instructors
    public async Task<IActionResult> Index(int? id, int? courseId)
    {
      var viewModel = new InstrIndexData();
      viewModel.Instructors =  await _context.Instructors
        .Include(x => x.OfficeAssignment)
        .Include(x => x.CourseAssignments)
          .ThenInclude(x => x.Course)
          .ThenInclude(x => x.Department)
          .OrderBy(x => x.LastName).ToListAsync();

      if(id != null)
      {
        ViewData["InstructorID"] = id.Value;
        Instructor instructor = viewModel.Instructors.Where(
          i => i.ID == id.Value).Single();
        viewModel.Courses = instructor.CourseAssignments.Select(s => s.Course);
      }

      if(courseId != null)
      {
        ViewData["CourseId"] = courseId.Value;
        Course course = viewModel.Courses.Where(i => i.CourseID == courseId.Value).Single();
        viewModel.Enrollments = course.Enrollments;
      }
      return _context.Instructors != null ?
                  View(await _context.Instructors.ToListAsync()) :
                  Problem("Entity set 'MyContext.Instructors'  is null.");
    }

    // GET: Instructors/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _context.Instructors == null)
      {
        return NotFound();
      }

      var instructor = await _context.Instructors
          .FirstOrDefaultAsync(m => m.ID == id);
      if (instructor == null)
      {
        return NotFound();
      }

      return View(instructor);
    }

    // GET: Instructors/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Instructors/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName,HireDate")] Instructor instructor)
    {
      if (ModelState.IsValid)
      {
        _context.Add(instructor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(instructor);
    }

    // GET: Instructors/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _context.Instructors == null)
      {
        return NotFound();
      }

      var instructor = await _context.Instructors.FindAsync(id);
      if (instructor == null)
      {
        return NotFound();
      }
      return View(instructor);
    }

    // POST: Instructors/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstMidName,HireDate")] Instructor instructor)
    {
      if (id != instructor.ID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(instructor);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!InstructorExists(instructor.ID))
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
      return View(instructor);
    }

    // GET: Instructors/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _context.Instructors == null)
      {
        return NotFound();
      }

      var instructor = await _context.Instructors
          .FirstOrDefaultAsync(m => m.ID == id);
      if (instructor == null)
      {
        return NotFound();
      }

      return View(instructor);
    }

    // POST: Instructors/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_context.Instructors == null)
      {
        return Problem("Entity set 'MyContext.Instructors'  is null.");
      }
      var instructor = await _context.Instructors.FindAsync(id);
      if (instructor != null)
      {
        _context.Instructors.Remove(instructor);
      }

      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool InstructorExists(int id)
    {
      return (_context.Instructors?.Any(e => e.ID == id)).GetValueOrDefault();
    }
  }
}
