using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Application.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ErrorMessage { get; set; }
        public bool isSended { get; set; } = false;
    }
}
