using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eZone.DAL;
using eZone.Models;
using eZone.DAL.DBO;
using eZone.DAL.Repositories;

namespace eZone.Controllers
{
    public class GroupController : Controller
    {
        private readonly IRepository<Group> _groupRepo;
        private readonly IRepository<Course> _courseRepo;
        private readonly IRepository<Teacher> _teacherRepo;

        public GroupController(IRepository<Group> groupRepo, IRepository<Course> courseRepo, IRepository<Teacher> teacherRepo)
        {
            _groupRepo = groupRepo;
            _courseRepo = courseRepo;
            _teacherRepo = teacherRepo;
        }

        // GET: Group
        public async Task<IActionResult> Index()
        {
            return View(await _groupRepo.GetAllAsync());
        }

        // GET: Group/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _groupRepo.GetByIdAsync(id.Value);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // GET: Group/Create
        public async Task<IActionResult> Create()
        {
            var groupViewModel = new GroupViewModel();
            groupViewModel.Courses = new SelectList(await _courseRepo.GetAllAsync(), "Id", "CourseDuration");
            groupViewModel.Teachers = new SelectList(await _teacherRepo.GetAllAsync(), "Id", "Email");           
            return View(groupViewModel);
        }

        // POST: Group/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupLevel,LessonDays,GroupTime,StartDate,NumOfStudents,CourseId,TeacherId")] GroupViewModel group)
        {
            if (ModelState.IsValid)
            {
                await _groupRepo.CreateAsync(group);
                return RedirectToAction(nameof(Index));
            }
            group.Courses = new SelectList(await _courseRepo.GetAllAsync(), "Id", "CourseDuration", group.CourseId);
            group.Teachers = new SelectList(await _teacherRepo.GetAllAsync(), "Id", "Email", group.TeacherId);
            return View(group);
        }

        // GET: Group/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _groupRepo.GetByIdAsync(id.Value);
            if (group == null)
            {
                return NotFound();
            }
            var groupViewModel = new GroupViewModel();
            groupViewModel.CopyFromGroup(group);
            groupViewModel.Courses = new SelectList(await _courseRepo.GetAllAsync(), "Id", "CourseDuration", group.CourseId);
            groupViewModel.Teachers = new SelectList(await _teacherRepo.GetAllAsync(), "Id", "Email", group.TeacherId);            
            return View(groupViewModel);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupLevel,LessonDays,GroupTime,StartDate,NumOfStudents,CourseId,TeacherId")] GroupViewModel group)
        {
            if (id != group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _groupRepo.UpdateAsync(group);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_groupRepo.Exists(group.Id))
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
            group.Courses = new SelectList(await _courseRepo.GetAllAsync(), "Id", "CourseDuration", group.CourseId);
            group.Teachers = new SelectList(await _teacherRepo.GetAllAsync(), "Id", "Email", group.TeacherId);
            return View(group);
        }

        // GET: Group/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _groupRepo.GetByIdAsync(id.Value);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _groupRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }        
    }
}
