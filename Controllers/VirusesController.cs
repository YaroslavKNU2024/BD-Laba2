#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabaOne;
using ClosedXML.Excel;

namespace LabaOne.Controllers
{
    public class VirusesController : Controller
    {
        private readonly DBFinalContext _context;

        public VirusesController(DBFinalContext context)
        {
            _context = context;
        }

        // GET: Viruses
        public async Task<IActionResult> Index(int? id, string name)
        {
            if (id == null || name == null)
            {
                var viruses = _context.Viruses.Include(x => x.Group);
                return View(await viruses.ToListAsync());
            }
            ViewBag.GroupId = id;
            ViewBag.GroupName = name;
            var virusesByGroup = _context.Viruses.Where(x => x.GroupId == id).Include(x => x.Group);
            return View(await virusesByGroup.ToListAsync());
        }

        // GET: Virus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var virus = await _context.Viruses
                .Include(d => d.Group)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (virus == null)
                return NotFound();

            //return View(virus);
            return RedirectToAction("Index", "Variants", new { id = virus.Id, name = virus.VirusName });
        }


        // GET: Viruses/Create
        public IActionResult Create(int? groupId)
        {
            if (groupId == null)
            {
                ViewData["GroupId"] = new SelectList(_context.VirusGroups, "Id", "GroupName");
            }
            else
            {
                ViewBag.GroupId = groupId;
                ViewBag.GroupName = _context.VirusGroups.Where(f => f.Id == groupId).FirstOrDefault().GroupName;
            }
            return View();
        }

        // POST: Viruses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? groupId, [Bind("Id,VirusDateDiscovered, VirusName, GroupId")] Virus virus)
        {
            virus.GroupId = groupId;
            virus.Group = await _context.VirusGroups.FindAsync(virus.GroupId);
            ModelState.ClearValidationState(nameof(virus.Group));
            TryValidateModel(virus.Group, nameof(virus.Group));

            if (ModelState.IsValid)
            {
                _context.Add(virus);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Viruses", new { id = groupId, name = _context.VirusGroups.Where(c => c.Id == groupId).FirstOrDefault().GroupName });
            }
            return RedirectToAction("Index", "Viruses", new { id = groupId, name = _context.VirusGroups.Where(c => c.Id == groupId).FirstOrDefault().GroupName });
        }

        // GET: Viruses/Edit/5
        public async Task<IActionResult> Edit(int? id, int? groupId)
        {
            if (id == null)
                return NotFound();

            var virus = await _context.Viruses.FindAsync(id);
            virus.Group = await _context.VirusGroups.FindAsync(virus.GroupId);
            ViewBag.GroupId = virus.GroupId;
            if (groupId != null)
            {
                ViewBag.GroupName = _context.VirusGroups.Where(f => f.Id == virus.GroupId).FirstOrDefault().GroupName;
                ViewBag.GroupId = groupId;
            }
            else
            {
                ViewBag.GroupName = null;
                ViewData["GroupId"] = new SelectList(_context.VirusGroups, "Id", "GroupName", groupId);
            }

            if (virus == null)
                return NotFound();

            return View(virus);
        }

        // POST: Viruses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupId,VirusName,VirusDateDiscovered")] Virus virus)
        {
            if (id != virus.Id)
                return NotFound();

            virus.Group = await _context.VirusGroups.FindAsync(virus.GroupId);
            ModelState.ClearValidationState(nameof(virus.Group));
            TryValidateModel(virus.Group, nameof(virus.Group));
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(virus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VirusExists(virus.Id))
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
            ViewData["GroupId"] = new SelectList(_context.VirusGroups, "Id", "GroupName", virus.GroupId);
            return View(virus);
            //return RedirectToAction("Index", "Viruses", new { id = virus.GroupId, name = _context.VirusGroups.Where(f => f.Id == virus.GroupId).FirstOrDefault().GroupName });
        }

        // GET: Viruses/Delete/5
        public async Task<IActionResult> Delete(int? id, int? groupId)
        {
            if (id == null)
                return NotFound();

            var virus = await _context.Viruses
                .Include(d => d.Group)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (groupId != null)
                ViewBag.GroupName = _context.VirusGroups.Where(f => f.Id == virus.GroupId).FirstOrDefault().GroupName;
            else
                ViewBag.GroupName = null;

            if (virus == null)
                return NotFound();

            return View(virus);
        }

        // POST: Viruses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var virus = await _context.Viruses.FindAsync(id);
            _context.Viruses.Remove(virus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VirusExists(int id)
        {
            return _context.Viruses.Any(e => e.Id == id);
        }

        bool finder(Variant variant)
        {
            foreach (var c in _context.Variants)
                if (c.VariantName.Contains(variant.VariantName))
                    return true;
            return false;
        }

        bool cvfinder(Variant variant, Country country)
        {
            foreach (var cv in _context.CountriesVariants)
                if (cv.Country.CountryName.Contains(variant.VariantName) && cv.Variant.VariantName.Contains(country.CountryName))
                    return true;
            return false;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(IFormFile fileExcel) {
            if (ModelState.IsValid) {
                if (fileExcel != null) {
                    using (var stream = new FileStream(fileExcel.FileName, FileMode.Create)) {
                        await fileExcel.CopyToAsync(stream);
                        using (XLWorkbook vir = new XLWorkbook(stream, XLEventTracking.Disabled)) {
                            //перегляд усіх листів (в даному випадку категорій)
                            foreach (IXLWorksheet worksheet in vir.Worksheets) {
                                //worksheet.Name - назва категорії. Пробуємо знайти в БД, якщо відсутня, то створюємо нову
                                Virus newVirus;
                                var v = (from virs in _context.Viruses
                                         where virs.VirusName.Contains(worksheet.Name)
                                         select virs).ToList();
                                if (v.Count > 0) {
                                    newVirus = v[0];
                                }
                                else {
                                    newVirus = new Virus();
                                    newVirus.VirusName = worksheet.Name;
                                    _context.Viruses.Add(newVirus);
                                }
                                //перегляд усіх рядків                    
                                foreach (IXLRow row in worksheet.RowsUsed().Skip(1)) {
                                    try {
                                        Variant variant = new Variant();
                                        variant.VariantName = row.Cell(1).Value.ToString();
                                        //variant.Info = row.Cell(6).Value.ToString();
                                        variant.Virus = newVirus;
                                        if (!finder(variant))
                                        {
                                            _context.Variants.Add(variant);
                                        }
                                        //у разі наявності автора знайти його, у разі відсутності - додати
                                        for (int i = 2; i <= 5; i++) {
                                            if (row.Cell(i).Value.ToString().Length > 0) {
                                                Country country;

                                                var c = (from cry in _context.Countries
                                                         where cry.CountryName.Contains(row.Cell(i).Value.ToString())
                                                         select cry).ToList();
                                                if (c.Count > 0)
                                                    country = c[0];
                                                else {
                                                    country = new Country();
                                                    country.CountryName = row.Cell(i).Value.ToString();
                                                    
                                                        _context.Add(country);
                                                }
                                                CountriesVariant cv = new CountriesVariant();
                                                cv.Variant = variant;
                                                cv.Country = country;
                                                if (!cvfinder(variant, country))
                                                    _context.CountriesVariants.Add(cv);
                                            }
                                        }
                                    }
                                    catch (Exception e){}
                                }
                            }
                        }
                    }
                }

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        


        public ActionResult Export()
        {
            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var viruses = _context.Viruses.Include("Variants").ToList();
                int maxCol = _context.Countries.Count();
                foreach (var c in viruses) {
                    var worksheet = workbook.Worksheets.Add(c.VirusName);
                    worksheet.Cell("A1").Value = "Назва";
                    worksheet.Cell("B1").Value = "Країна 1";
                    worksheet.Cell("C1").Value = "Країна 2";
                    worksheet.Cell("D1").Value = "Країна 3";
                    worksheet.Cell("E1").Value = "Країна 4";
                    worksheet.Cell("F1").Value = "Вірус";

                    worksheet.Row(1).Style.Font.Bold = true;
                    var variants = c.Variants.ToList();

                    //нумерація рядків/стовпчиків починається з індекса 1 (не 0)
                    for (int i = 0; i < variants.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = variants[i].VariantName;
                        worksheet.Cell(i + 2, 6).Value = variants[i].Virus.VirusName;

                        var cv = _context.CountriesVariants.Where(a => a.VariantId == variants[i].Id).Include("Country").ToList();


                        //більше 4-ох нікуди писати
                        int j = 0;
                        foreach (var a in cv) {
                            if (j < 5) {
                                worksheet.Cell(i + 2, j + 2).Value = a.Country.CountryName;
                                j++;
                            }
                        }

                    }
                }
                using (var stream = new MemoryStream()) {
                    workbook.SaveAs(stream);
                    stream.Flush();

                    return new FileContentResult(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        //змініть назву файла відповідно до тематики Вашого проєкту

                        FileDownloadName = $"library_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }
        }







    }
}