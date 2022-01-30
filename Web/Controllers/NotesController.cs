using Core.Domain.Notes;
using Core.Domain.Topics;
using Core.Entities;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private const int DefaultPageSize = 12;

        private INoteService noteService;
        private ITopicService topicService;
        private readonly TinyMCE tinyMCE;

        public NotesController(INoteService noteService, ITopicService topicService, IOptions<TinyMCE> tinyMCEOptions)
        {
            this.noteService = noteService;
            this.topicService = topicService;
            this.tinyMCE = tinyMCEOptions.Value;
        }

        // GET: NotesController
        public ActionResult Index(int page = 1, int size = DefaultPageSize, string query = "", string orderBy = "title")
        {
            var notes = noteService.GetNotes(page, size, query, orderBy);
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

            var topics = topicService.ListTopics();
            ViewBag.Topics = topics.Select(a => new SelectListItem() { Text = a.TopicName, Value = a.TopicId.ToString() });
            return View();
        }
         
        // POST: NotesController/Create
        [HttpPost]        
        public ActionResult Create([FromForm] CreateNoteModel model)
        {
            if (ModelState.IsValid)
            {
                noteService.CreateNote(model);
                return RedirectToAction(nameof(Index));
            }

            var topics = topicService.ListTopics();
            ViewBag.Topics = topics.Select(a => new SelectListItem() { Text = a.TopicName, Value = a.TopicId.ToString() });
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
