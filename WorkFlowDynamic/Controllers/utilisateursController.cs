using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkFlowDynamic.DataEntityTypes;
using WorkFlowDynamic.Models;

namespace WorkFlowDynamic.Controllers
{
    public class utilisateursController : Controller
    {
        private readonly WorkflowdynamicContext _context;

        public utilisateursController(WorkflowdynamicContext context)
        {
            _context = context;
        }

        // GET: utilisateurs
        public async Task<IActionResult> Index()
        {
            var workflowdynamicContext = _context.utilisateur.Include(u => u.id_specialiteNavigation).Include(u => u.structure_interneNavigation);
            return View(await workflowdynamicContext.ToListAsync());
        }

        // GET: utilisateurs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.utilisateur
                .Include(u => u.id_specialiteNavigation)
                .Include(u => u.structure_interneNavigation)
                .FirstOrDefaultAsync(m => m.id_utilisateur == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // GET: utilisateurs/Create
        public IActionResult Create()
        {
            ViewData["id_specialite"] = new SelectList(_context.specialite, "id", "id");
            ViewData["structure_interne"] = new SelectList(_context.structure_interne, "id", "nom_structure");
            return View();
        }

        // POST: utilisateurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("profil,id_utilisateur,active,adresse,datenaiss,email,login,nom,passwordd,prenom,sexe,telephone,specialite,fonction,structure_interne,id_specialite")] utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_specialite"] = new SelectList(_context.specialite, "id", "id", utilisateur.id_specialite);
            ViewData["structure_interne"] = new SelectList(_context.structure_interne, "id", "nom_structure", utilisateur.structure_interne);
            return View(utilisateur);
        }

        // GET: utilisateurs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.utilisateur.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            ViewData["id_specialite"] = new SelectList(_context.specialite, "id", "id", utilisateur.id_specialite);
            ViewData["structure_interne"] = new SelectList(_context.structure_interne, "id", "nom_structure", utilisateur.structure_interne);
            return View(utilisateur);
        }

        // POST: utilisateurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("profil,id_utilisateur,active,adresse,datenaiss,email,login,nom,passwordd,prenom,sexe,telephone,specialite,fonction,structure_interne,id_specialite")] utilisateur utilisateur)
        {
            if (id != utilisateur.id_utilisateur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilisateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!utilisateurExists(utilisateur.id_utilisateur))
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
            ViewData["id_specialite"] = new SelectList(_context.specialite, "id", "id", utilisateur.id_specialite);
            ViewData["structure_interne"] = new SelectList(_context.structure_interne, "id", "nom_structure", utilisateur.structure_interne);
            return View(utilisateur);
        }

        // GET: utilisateurs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.utilisateur
                .Include(u => u.id_specialiteNavigation)
                .Include(u => u.structure_interneNavigation)
                .FirstOrDefaultAsync(m => m.id_utilisateur == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // POST: utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var utilisateur = await _context.utilisateur.FindAsync(id);
            _context.utilisateur.Remove(utilisateur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool utilisateurExists(long id)
        {
            return _context.utilisateur.Any(e => e.id_utilisateur == id);
        }
    }
}
