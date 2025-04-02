using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOffice365Backend.DataAccess.DBModel
{
    public class Email
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SenderEmail { get; set; }
        public string RecipientEmail { get; set; }
        public DateTime SentDate { get; set; }
    }
}

