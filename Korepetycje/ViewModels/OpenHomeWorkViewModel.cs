using Korepetycje.Models;
using System.Collections.Generic;

namespace Korepetycje.ViewModels
{
    public class OpenHomeWorkViewModel
    {
        public Exercises Exercise { get; set; }
        public IEnumerable<HomeworkChatMessages> Messages { get; set; }
        public int HomeWorkId { get; set; }
        public string LoggedUserId { get; set; }
        public string NewMessageConntent { get; set; }
        public string NewMessageFotoPath { get; set; }
    }
}