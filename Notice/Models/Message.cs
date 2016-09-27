using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notice.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string TextMessage { get; set; }
        public string TimeMessage { get; set; }
    }
}