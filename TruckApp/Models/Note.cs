using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TruckApp.Models
{
    public class Note
    {
        public int Id { get; set; }
        [Required]
        public string NoteContent { get; set; }
        public int LoadConfirmationId { get; set; }
        public LoadConfirmation LoadConfirmation { get; set; }
        public DateTime DateAdded { get; set; }
        public string Header { get; set; }
    }
}