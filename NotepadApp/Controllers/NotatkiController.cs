using NotepadApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotepadApp.Controllers
{
    public class NotatkiController : Controller
    {
        // GET: Notatki
        public ActionResult AddNew()
        {
            return View("NotatkiPage");
        }

        [HttpPost]
        public ActionResult AddNew(NotesPageViewModel noteViewModel)
        {

            if (ModelState.IsValid == false)
            {
                return View("NotatkiPage");
            }

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(noteViewModel.NoteModel);
                ctx.SaveChanges();
            }


            return RedirectToAction("ShowAll");
        }

        public ActionResult ShowAll()
        {

            NotesPageViewModel noteViewModel = new NotesPageViewModel();

            using (var ctx = new ApplicationDbContext())
            {
                noteViewModel.AllNotes = ctx.Notes.ToList();
            }

            return View("AllNotesPage", noteViewModel);

        }
        public ActionResult DeleteNote(long Id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                NoteModel Note = ctx.Notes.Single(n => n.Id == Id);
                ctx.Notes.Remove(Note);
                ctx.SaveChanges();
            }

            return View("AllNotesPage");
        }

        public ActionResult Edit(long Id)
        {
            var viewmodel = new EditViewModel();
            using (var ctx = new ApplicationDbContext())
            {
                var Note = ctx.Notes.Single(n => n.Id == Id);
                ctx.Notes.Remove(Note);
                ctx.SaveChanges();
                viewmodel.NoteModel = Note;
            }

            return View("EditNotePage", viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel noteEM)
        {

            NoteModel noteToEdit = noteEM.NoteModel;

            using (var ctx = new ApplicationDbContext())
            {
                var note = ctx.Notes.Single(n => n.Id == noteToEdit.Id);
                note.Title = noteEM.NoteModel.Title;
                note.Content = noteEM.NoteModel.Content;
                ctx.SaveChanges();
            }

            return RedirectToAction("ShowAll");
        }

    }
}