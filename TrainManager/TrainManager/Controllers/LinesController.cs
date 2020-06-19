﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;

namespace ToDoManager.Controllers
{
    public class LinesController : Controller
    {
        private readonly ToDoManagerContext _context;

        public LinesController()
        {
            _context = new ToDoManagerContext();

       
            
        }

        // GET: Lines
       
        public async Task<IActionResult> Index(string value)
        {
           
            var line = from m in _context.Lines select m;

            if (!String.IsNullOrEmpty(value))
            {
                line = line.Where(s => s.To.Contains(value) || s.From.Contains(value) || s.Date.ToString().Contains(value));
            }
            //var toDoManagerContext = _context.Lines.Include(l => l.Train);
            return View(await line.ToListAsync());
        }
        // GET: Lines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var line = await _context.Lines
                .Include(l => l.Train)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (line == null)
            {
                return NotFound();
            }

            return View(line);
        }

        // GET: Lines/Create
        public IActionResult Create()
        {
            ViewData["TrainId"] = new SelectList(_context.Trains, "Id", "Name");
            return View();
        }

        // POST: Lines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainId,From,To,DepartureTime,ArrivalTime,Date,Id")] Line line)
        {
            if (ModelState.IsValid)
            {
                _context.Add(line);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrainId"] = new SelectList(_context.Trains, "Id", "Name", line.TrainId);
            return View(line);
        }

        // GET: Lines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var line = await _context.Lines.FindAsync(id);
            if (line == null)
            {
                return NotFound();
            }
            ViewData["TrainId"] = new SelectList(_context.Trains, "Id", "Name", line.TrainId);
            return View(line);
        }

        // POST: Lines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainId,From,To,DepartureTime,ArrivalTime,Date,Id")] Line line)
        {
            if (id != line.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(line);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineExists(line.Id))
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
            ViewData["TrainId"] = new SelectList(_context.Trains, "Id", "Name", line.TrainId);
            return View(line);
        }

        // GET: Lines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var line = await _context.Lines
                .Include(l => l.Train)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (line == null)
            {
                return NotFound();
            }

            return View(line);
        }

        // POST: Lines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var line = await _context.Lines.FindAsync(id);
            _context.Lines.Remove(line);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineExists(int id)
        {
            return _context.Lines.Any(e => e.Id == id);
        }
    }
}
