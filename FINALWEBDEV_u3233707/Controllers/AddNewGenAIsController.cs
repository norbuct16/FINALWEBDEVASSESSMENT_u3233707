using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FINALWEBDEV_u3233707.Data;
using FINALWEBDEV_u3233707.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.Text.Json;


namespace FINALWEBDEV_u3233707.Controllers
{
    public class AddNewGenAIsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnv;

        private readonly ApplicationDbContext _db;

        

      

        public AddNewGenAIsController(ApplicationDbContext context, IHostingEnvironment hostingEnv)
        {
            _context = context;
            _hostingEnv = hostingEnv;
        }

       
        // GET: AddNewGenAIs
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated){
                foreach (var df in _context.AddNewGenAI.ToList())
                {

                    df.isLiked = true;
                    _context.Update(df);
                    await _context.SaveChangesAsync();
                }
            }
            
            return _context.AddNewGenAI != null ? 
            View(await _context.AddNewGenAI.ToListAsync()) :
            Problem("Entity set 'ApplicationDbContext.AddNewGenAI'  is null.");
        }



        // GET: AddNewGenAIs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AddNewGenAI == null)
            {
                return NotFound();
            }

            var addNewGenAI = await _context.AddNewGenAI
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addNewGenAI == null)
            {
                return NotFound();
            }

            return View(addNewGenAI);
        }



        // GET: AddNewGenAIs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddNewGenAIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GenAIName,Summary")] AddNewGenAI addNewGenAI, UploadFile uploadFile)
        {
            if (uploadFile.File != null)
            {
                var fileName = Path.GetFileName(uploadFile.File.FileName);
                var filePath = Path.Combine(_hostingEnv.WebRootPath, "images", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await uploadFile.File.CopyToAsync(fileStream);
                }
                addNewGenAI.AnchorLink = "/images/" + fileName; // Adjust the path accordingly
               
            }
            if (ModelState.IsValid)
            {
               
                _context.Add(addNewGenAI);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

          
            return View(addNewGenAI);
        }

        // GET: AddNewGenAIs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AddNewGenAI == null)
            {
                return NotFound();
            }

            var addNewGenAI = await _context.AddNewGenAI.FindAsync(id);
            if (addNewGenAI == null)
            {
                return NotFound();
            }
            return View(addNewGenAI);
        }

        // POST: AddNewGenAIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GenAIName,Summary")] AddNewGenAI addNewGenAI,  UploadFile uploadFile)
        {
            if (id != addNewGenAI.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    var existingAddNewGenAI = await _context.AddNewGenAI.FindAsync(id);
                    if (uploadFile.File != null)
                    {
                        var fileName = Path.GetFileName(uploadFile.File.FileName);
                        var filePath = Path.Combine(_hostingEnv.WebRootPath, "images", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await uploadFile.File.CopyToAsync(fileStream);
                        }
                        addNewGenAI.AnchorLink = "/images/" + fileName; // Adjust the path accordingly

                    }
                    else
                    {
                        return View(addNewGenAI);
                    }
                   
                    if (existingAddNewGenAI != null)
                    {

                        existingAddNewGenAI.GenAIName = addNewGenAI.GenAIName;
                        existingAddNewGenAI.Summary = addNewGenAI.Summary;
                        existingAddNewGenAI.AnchorLink = addNewGenAI.AnchorLink;
                    }
                    else
                    {
                        existingAddNewGenAI.AnchorLink = addNewGenAI.AnchorLink;
                    }
                    _context.Update(existingAddNewGenAI);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddNewGenAIExists(addNewGenAI.Id))
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
            return View(addNewGenAI);
        }

        // GET: AddNewGenAIs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AddNewGenAI == null)
            {
                return NotFound();
            }

            var addNewGenAI = await _context.AddNewGenAI
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addNewGenAI == null)
            {
                return NotFound();
            }

            return View(addNewGenAI);
        }

        // POST: AddNewGenAIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AddNewGenAI == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AddNewGenAI'  is null.");
            }
            var addNewGenAI = await _context.AddNewGenAI.FindAsync(id);
            if (addNewGenAI != null)
            {
                _context.AddNewGenAI.Remove(addNewGenAI);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddNewGenAIExists(int id)
        {
          return (_context.AddNewGenAI?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> IncreaseLike(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var addNewGenAI = await _context.AddNewGenAI.FindAsync(id);
            if (addNewGenAI == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (addNewGenAI.isLiked)
                    {
                        addNewGenAI.Like++;
                        addNewGenAI.isLiked = false;
                        Console.WriteLine("Falsified");
                        
                    }
                    _context.Update(addNewGenAI);
                    await _context.SaveChangesAsync();



                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddNewGenAIExists(addNewGenAI.Id))
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
            return RedirectToAction(nameof(Index));
        }

        



       
    }
}
