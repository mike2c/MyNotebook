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
        private INoteService noteService;
        private ITopicService topicService;
        private readonly TinyMCE tinyMCE;

        public NotesController(INoteService noteService, ITopicService topicService, IOptions<TinyMCE> tinyMCEOptions)
        {
            this.noteService = noteService;
            this.topicService = topicService;
            this.tinyMCE = tinyMCEOptions.Value;
        }
        
        [HttpGet]
        public ActionResult Index(string query = "", string sort = "title")
        {
            var sortItems = GetSortListItems(sort);
            var notes = noteService.GetAllNotes(query, sort);

            ViewBag.SortItems = sortItems;
            return View(notes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TinyMCEApiKey = tinyMCE.ApiKey;
            ViewBag.Topics = GetTopicListItems();
            return View();
        }         
        
        [HttpPost]        
        public ActionResult Create([FromForm] CreateNoteModel model)
        {
            if (ModelState.IsValid)
            {
                noteService.CreateNote(model);
                return RedirectToAction(nameof(Index));
            }
                        
            ViewBag.Topics = GetTopicListItems();
            ViewBag.TinyMCEApiKey = tinyMCE.ApiKey;
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var note = this.noteService.GetNote(id);
            
            if(note == null)
            {
                return Redirect("error/404");
            }

            return View();
        }

        [HttpPost]        
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] UpdateNoteModel model)
        {

            if (ModelState.IsValid)
            {
                this.noteService.UpdateNote(model);
                return RedirectToAction(nameof(Index));
            }


            return View();
        }

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

        private List<SelectListItem> GetSortListItems(string current)
        {
            var sortListItems = new List<SelectListItem>()
            {
                new SelectListItem("Title", "title", current.Equals("title")),
                new SelectListItem("Topic", "topic", current.Equals("topic")),
                new SelectListItem("Creation Date", "date", current.Equals("date"))
            };

            if (!sortListItems.Any(a => a.Selected))
            {
                sortListItems.First().Selected = true;
            }

            return sortListItems;
        }

        private IEnumerable<SelectListItem> GetTopicListItems()
        {
            var topics = topicService.ListTopics();
            var topicListItems = topics.Select(a => new SelectListItem() { Text = a.TopicName, Value = a.TopicId.ToString() });
            return topicListItems;
        }
    }
} 