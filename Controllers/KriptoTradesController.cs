﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PinKripto05.Models;

namespace PinKripto05.Controllers
{
    public class KriptoTradesController : Controller
    {
        private readonly KriptoDBContext _context;

        public KriptoTradesController(KriptoDBContext context)
        {
            _context = context;
        }

        // GET: KriptoTrades
        public async Task<IActionResult> Index()
        {
            return View(await _context.KriptoTrades.ToListAsync());
        }

        // GET: KriptoTrades/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kriptoTrades = await _context.KriptoTrades
                .FirstOrDefaultAsync(m => m.KriptoName == id);
            if (kriptoTrades == null)
            {
                return NotFound();
            }

            return View(kriptoTrades);
        }

        // GET: KriptoTrades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KriptoTrades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KriptoId,KriptoRank,Symbol,KriptoName,Usd,DatumUnosa,Change1h,Change24h,Change7d")] KriptoTrades kriptoTrades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kriptoTrades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kriptoTrades);
        }

        // GET: KriptoTrades/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kriptoTrades = await _context.KriptoTrades.FindAsync(id);
            if (kriptoTrades == null)
            {
                return NotFound();
            }
            return View(kriptoTrades);
        }

        // POST: KriptoTrades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("KriptoId,KriptoRank,Symbol,KriptoName,Usd,DatumUnosa,Change1h,Change24h,Change7d")] KriptoTrades kriptoTrades)
        {
            if (id != kriptoTrades.KriptoName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kriptoTrades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KriptoTradesExists(kriptoTrades.KriptoName))
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
            return View(kriptoTrades);
        }

        // GET: KriptoTrades/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kriptoTrades = await _context.KriptoTrades
                .FirstOrDefaultAsync(m => m.KriptoName == id);
            if (kriptoTrades == null)
            {
                return NotFound();
            }

            return View(kriptoTrades);
        }

        // POST: KriptoTrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var kriptoTrades = await _context.KriptoTrades.FindAsync(id);
            _context.KriptoTrades.Remove(kriptoTrades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KriptoTradesExists(string id)
        {
            return _context.KriptoTrades.Any(e => e.KriptoName == id);
        }
    }
}
