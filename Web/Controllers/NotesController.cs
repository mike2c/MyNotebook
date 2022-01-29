using Core.Domain.Notes;
using Core.Entities;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers;

namespace Web.Controllers
{
    public class NotesController : Controller
    {
        private INoteService noteService;
        private readonly TinyMCE tinyMCE;

        public NotesController(INoteService noteService, IOptions<TinyMCE> tinyMCEOptions)
        {
            this.noteService = noteService;
            this.tinyMCE = tinyMCEOptions.Value;
        }

        // GET: NotesController
        public ActionResult Index()
        {
            var notes = this.noteService.GetNotes(0, 0, string.Empty);
            return View(notes);
        }

        // GET: NotesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NotesController/Create
        public ActionResult Create()
        {
            ViewBag.TinyMCEApiKey = tinyMCE.ApiKey;
            return View();
        }
         
        // POST: NotesController/Create
        [HttpPost]        
        public ActionResult Create([FromForm] CreateNoteModel model)
        {
            if (ModelState.IsValid)
            {
                this.noteService.CreateNote(model);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.TinyMCEApiKey = tinyMCE.ApiKey;
            return View();
        }

        // GET: NotesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NotesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NotesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
