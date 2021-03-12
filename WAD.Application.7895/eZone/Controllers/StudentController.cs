using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eZone.DAL;
using eZone.Models;
using eZone.DAL.Repositories;
using eZone.DAL.DBO;

namespace eZone.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository<Student> _studentRepo;

        public StudentController(IRepository<Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(await _studentRepo.GetAllAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentRepo.GetByIdAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public async Task<IActionResult> Create()
        {
            ViewData["GroupId"] = new SelectList(await _studentRepo.GetAllAsync(), "Id", "Id");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Phone,FirstLesson,PaymentStatus,GroupId")] Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentRepo.CreateAsync(student);
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(await _studentRepo.GetAllAsync(), "Id", "Id", student.GroupId);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentRepo.GetByIdAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(await _studentRepo.GetAllAsync(), "Id", "Id", student.GroupId);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Phone,FirstLesson,PaymentStatus,GroupId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _studentRepo.UpdateAsync(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_studentRepo.Exists(student.Id))
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
            ViewData["GroupId"] = new SelectList(await _studentRepo.GetAllAsync(), "Id", "Id", student.GroupId);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentRepo.GetByIdAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await _studentRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
