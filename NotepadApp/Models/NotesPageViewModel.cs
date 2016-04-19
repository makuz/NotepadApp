using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotepadApp.Models
{
    public class NotesPageViewModel
    {

        public NoteModel NoteModel { get; set; }

        public List<NoteModel> AllNotes { get; set; }


    }
}