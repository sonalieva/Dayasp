using Dayasp.DAL;
using Dayasp.Helpers;
using Dayasp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dayasp.Areas.Manage.Controllers
{
    [Area("manage")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeamController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var model = _context.Teams.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (team.ImageFile != null)
            {
                if (team.ImageFile.ContentType != "image/png" && team.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File format must be jpeg or png");
                    return View();
                }
                if (team.ImageFile.Length > 2097521)
                {
                    ModelState.AddModelError("ImageFile", " Must be 2 mb");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("ImageFile", "Image file dont be requireed");
                return View();
            }
            team.Image = FileManager.Save(_env.WebRootPath, "uploads/teams", team.ImageFile);
            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == id);
            if (team == null)
                return RedirectToAction("error", "dashboard");
          
            return View(team);
        }
        [HttpPost]
        public IActionResult Edit (Team team)
        {
            Team existsteam = _context.Teams.FirstOrDefault(x => x.Id == team.Id);
            if (team == null)
                return RedirectToAction("error", "dashboard");
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (team.ImageFile != null)
            {
                if (team.ImageFile.ContentType != "image/png" && team.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File format must be jpeg or png");
                    return View();
                }
                if (team.ImageFile.Length > 2097521)
                {
                    ModelState.AddModelError("ImageFile", " Must be 2 mb");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("ImageFile", "Image file dont be requireed");
                return View();
            }
              string newFileName = FileManager.Save(_env.WebRootPath, "uploads/teams", team.ImageFile);
            FileManager.Delete(_env.WebRootPath, "uploads/teams", team.Image);



            _context.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
