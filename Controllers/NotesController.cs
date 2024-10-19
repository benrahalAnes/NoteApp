using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NoteApp.Data;
using NoteApp.Models;

namespace NoteApp.Controllers
{

    public class NotesController : Controller
    {
        private readonly NoteContext _context;
         public NotesController(NoteContext context)
       {
            _context = context;
       }
        // Get all Notes
       public async Task<IActionResult> Index()
       {
            var note = await _context.Notes.ToListAsync();
            return View(note);
       }
       // Post Note
       public IActionResult Create()
       {
        return View();
       }
       [HttpPost]
       public async Task<IActionResult> Create([Bind("Id","Title","Description", "CreatedAt")] Note note)
       {
            if (ModelState.IsValid)
            {
                note.CreatedAt = DateTime.Now;
                _context.Notes.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(note);
       }
       public async Task<IActionResult> Edit(int id)
       {

            var note = await _context.Notes.FirstOrDefaultAsync(x=>x.Id == id);
            return View(note);
       }
       [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id","Title","Description", "CreatedAt")] Note note)
        {
            if (ModelState.IsValid)
            {
                note.CreatedAt = DateTime.Now;
                _context.Update(note);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(note);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(x=>x.Id==id);
            return View(note);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Remove(note);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(note);
        }
        





    }
}