using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eZone.DAL;
using eZone.DAL.DBO;
using eZone.DAL.Repositories;
using eZone.Models;

namespace eZone.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository<Student> _studentRepo;
        private readonly IRepository<Group> _groupRepo;

        public StudentController(IRepository<Student> studentRepo, IRepository<Group> groupRepo)
        {
            _studentRepo = studentRepo;
            _groupRepo = groupRepo;
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
            var studentViewModel = new StudentViewModel();
            studentViewModel.Groups = new SelectList(await _groupRepo.GetAllAsync(), "Id", "Id");
            return View(studentViewModel);
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstLesson,PaymentStatus,GroupId,Id,FirstName,LastName,Phone")] StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                await _studentRepo.CreateAsync(student);
                return RedirectToAction(nameof(Index));
            }
            student.Groups = new SelectList(await _groupRepo.GetAllAsync(), "Id", "Id", student.GroupId);
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
            var studentViewModel = new StudentViewModel();
            studentViewModel.CopyFromStudent(student);
            studentViewModel.Groups = new SelectList(await _groupRepo.GetAllAsync(), "Id", "Id", student.GroupId);
            return View(studentViewModel);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstLesson,PaymentStatus,GroupId,Id,FirstName,LastName,Phone")] StudentViewModel student)
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
            student.Groups = new SelectList(await _groupRepo.GetAllAsync(), "Id", "Id", student.GroupId);
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
