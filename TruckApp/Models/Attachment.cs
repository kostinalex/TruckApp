using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckApp.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public int LoadConfirmationId { get; set; }
        public LoadConfirmation LoadConfirmation { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
    }
}