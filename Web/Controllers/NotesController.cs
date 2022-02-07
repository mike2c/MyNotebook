using Core.Domain.Notes;
using Core.Domain.Topics;
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
        private readonly INoteService noteService;
        private readonly ITopicService topicService;
        private readonly TinyMCE tinyMCE;

        public NotesController(INoteService noteService, ITopicService topicService, IOptions<TinyMCE> tinyMCEOptions)
        {
            this.noteService = noteService;
            this.topicService = topicService;
            this.tinyMCE = tinyMCEOptions.Value;            
        }
        
        [HttpGet]        
        public ActionResult Index(Pagination pagination)
        {            
            var notes = noteService.GetAllNotes(pagination);
            var links = ListNavigation.GenerateLinks(notes, pagination);

            ViewBag.SortOptions = GetSortOptions(pagination.OrderBy);
            ViewBag.Pagination = pagination;            
            ViewBag.Navigation = links;            

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
                return Redirect("error/404");
            
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
            private List<SelectListItem> GetSortOptions(string current)
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