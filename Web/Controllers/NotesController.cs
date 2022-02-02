using Core.Domain.Notes;
using Core.Domain.Topics;
using Core.Entities;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using Web.Helpers;
using Web.Navigation;

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
        public ActionResult Index(string search, string orderBy, string direction, int page = 1, int size = 12)
        {
            search = search ?? string.Empty;
            direction = direction ?? "asc";
            orderBy = orderBy ?? "title";                        
            
            var notes = noteService.GetAllNotes(page, size, search, orderBy, direction);
            var links = Pagination.GenerateNavigationLinks<Note>(notes, page, search, orderBy, direction);

            ViewBag.SortOptions = GetSortListItems(orderBy);
            ViewBag.Direction = direction;
            ViewBag.Search = search;
            ViewBag.Page = page;

            ViewBag.PrevLink = links.Previous;
            ViewBag.NextLink = links.Next;

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
        [ValidateAntiForgeryToken]
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
            var note = noteService.GetNote(id);
            
            if(note == null)
            {
                return Redirect("error/404");
            }

            var model = new UpdateNoteModel()
            {
                NoteId = note.NoteId,
                Title = note.Title,
                Body = note.Body,
                CreatedDate = note.CreatedDate,
                LastModifiedDate = note.LastModifiedDate,
                TopicId = note.TopicId
            };
            
            ViewBag.TinyMCEApiKey = tinyMCE.ApiKey;
            ViewBag.Topics = GetTopicListItems();

            return View(model);
        }

        [HttpPost]        
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] UpdateNoteModel model)
        {
            if (ModelState.IsValid)
            {
                noteService.UpdateNote(model);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.TinyMCEApiKey = tinyMCE.ApiKey;
            ViewBag.Topics = GetTopicListItems();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] int id)
        {
            noteService.DeleteNote(id);
            return RedirectToAction(nameof(Index));
        }
               
        #region Get list items methods
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

        #endregion      
    }


} 